using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace FTP_Image_Browser
{
    public partial class Form1 : Form
    {
        
        FtpClient ftpClient;
        Overlay overlayImg;
        public Form1()
        {
            ftpClient = new FtpClient();
            treeViewFolders = new TreeView();
            Image folderIcon1 = System.Drawing.Image.FromFile("..\\..\\images\\folder2.png");
            Image folderIcon2 = System.Drawing.Image.FromFile("..\\..\\images\\folder.png");
            treeViewFolders.ImageList = new ImageList();
            treeViewFolders.ImageList.Images.Add(folderIcon1);
            treeViewFolders.ImageList.Images.Add(folderIcon2);
            InitializeComponent();
            //FtpListDirectory();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize map:
            gMapControl.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.SetPositionByKeywords("Warsaw, Poland");
            //Initialize image overlay
            GMapOverlay imageOverlay = new GMapOverlay("images");
            GMapOverlay scaleOverlay = new GMapOverlay("scale");
            gMapControl.Overlays.Add(imageOverlay);
            gMapControl.Overlays.Add(scaleOverlay);
            overlayImg = new Overlay(imageOverlay, scaleOverlay, gMapControl);
        }
        private void ListWorkingDirectoryAsync()
        {
            //start new list directory task in background
            BackgroundWorker ftpRequestWorker = new BackgroundWorker();
            ftpRequestWorker.DoWork += new DoWorkEventHandler(ftpClient.FtpListDirectoryWorker);
            ftpRequestWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            ftpRequestWorker.WorkerReportsProgress = true;
            ftpRequestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FtpListFolders);
            ftpRequestWorker.RunWorkerAsync(ftpClient.WorkingDir);
        }
        private void SyncWorkingDirectoryAsync()
        {
            if (ftpClient.autoWorking == true) return;
            //start new file synchronization task in background
            BackgroundWorker ftpRequestWorker = new BackgroundWorker();
            ftpRequestWorker.DoWork += new DoWorkEventHandler(ftpClient.DownloadAllWorkingDirWorker);
            ftpRequestWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            ftpRequestWorker.WorkerReportsProgress = true;
            ftpRequestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FtpDownloadedFiles);
            ftpRequestWorker.RunWorkerAsync();
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset working directory
            ftpClient.WorkingDir = "UAVFORS";
            ListWorkingDirectoryAsync();
        }

        private void buttonMagic_Click(object sender, EventArgs e)
        {
            //if(overlayImg.resizetest == 10)
            //    overlayImg.resizetest = 0;
            //else if(overlayImg.resizetest == 0 )
            //    overlayImg.resizetest = 10;
            //gMapControl_OnMapZoomChanged();
            //gMapControl.ZoomAndCenterMarkers("images");
           // overlayImg.SetFiltersWorker(new object(), new DoWorkEventArgs(new Overlay.MarkerFilters(1000, 0, 1400000, 1300000)));
        }
        


        //event handlers for specific tasks
        private void SliderChanged(object sender, EventArgs e)
        {
            if(trackBarScoreMax.Maximum != trackBarScoreMax.Value)
                overlayImg.SetFilters(new Overlay.MarkerFilters(trackBarScoreMax.Value, trackBarScore.Value, trackBarTimeMax.Value, trackBarTime.Value));
            else
                overlayImg.SetFilters(new Overlay.MarkerFilters(trackBarScoreMax.Value, trackBarScore.Value, -1, trackBarTime.Value));
        }
        //Handle directory list return value
        private void FtpListFolders(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> dirListing = (List<string>) e.Result;
            labelStatus.Text = "Idle";
            progressBar.Value = 0;
            //Check for exception and proper directory//
            if (dirListing == null)
            {
                MessageBox.Show("Connection failed - invalid directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ftpClient.WorkingDir == "UAVFORS")
            {
                Console.WriteLine("We have the connection and appropriate folder");
                dirListing.Clear();
                dirListing = this.ftpClient.FtpListDirectory("UAVFORS");
                foreach (string str in dirListing)
                {
                    this.treeViewFolders.Nodes.Add(str);
                }
                for (int i = 0; i < treeViewFolders.Nodes.Count; ++i)
                {
                    treeViewFolders.Nodes[i].SelectedImageIndex = 1;
                    treeViewFolders.Nodes[i].ImageIndex = 0;
                }
                connectionState_ = FtpConnectionState.FolderListing;

            }
            else if(dirListing != null && ftpClient.WorkingDir.Contains("UAVFORS/"))
            {
                //Listing image subdirectory
                foreach (string str in dirListing)
                {
                    Console.WriteLine(str);
                }

            }
        }
        //Handle file sync return value
        private void FtpDownloadedFiles(object sender, RunWorkerCompletedEventArgs e)
        {
            string [] filesDownloaded = (string[])e.Result;

            labelStatus.Text = "Idle";
            progressBar.Value = 0;
            if (connectionState_ == FtpConnectionState.FolderListing)
            {
                connectionState_ = FtpConnectionState.Synchronised;
                //Create list of local files
                string[] localFiles = Directory.GetFiles(ftpClient.WorkingDir);
                for (int i = 0; i < localFiles.Length; ++i)
                {
                    localFiles[i] = Path.GetFileName(localFiles[i]);
                }
                //Refresh local files in node
                foreach(string str in localFiles)
                    treeViewFolders.Nodes[0].Nodes.Add(str);
                overlayImg.WorkingDir = ftpClient.WorkingDir;
                overlayImg.OverlayWorkingDir();
                trackBarTime.TickFrequency = 10000;
                trackBarTimeMax.TickFrequency = 10000;
            }
            else if(connectionState_ == FtpConnectionState.Synchronised)
            {
                //Add only new nodes
                foreach (string str in filesDownloaded)
                    treeViewFolders.Nodes[0].Nodes.Add(str);
                overlayImg.OverlayNew(filesDownloaded);
            }
            overlayImg.ResizeAll();
            //Update sliders//
            trackBarTime.Minimum = (int)overlayImg.timeRoiMin_;
            trackBarTime.Maximum = (int)overlayImg.timeRoiMax_;
            if (trackBarTime.Value < trackBarTime.Minimum) trackBarTime.Value = trackBarTime.Minimum;
            trackBarTimeMax.Minimum = (int)overlayImg.timeRoiMin_;
            trackBarTimeMax.Maximum = (int)overlayImg.timeRoiMax_;
            if (trackBarTimeMax.Value < trackBarTimeMax.Minimum) trackBarTimeMax.Value = trackBarTimeMax.Minimum;
            if (overlayImg.imageFilters_.timeMax == -1) trackBarTimeMax.Value = trackBarTimeMax.Maximum;
                  
        }
        //General utility handlers
        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = (int)e.ProgressPercentage;
            labelStatus.Text = (string)e.UserState;
        }

        private void treeViewFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ftpClient.WorkingDir = "UAVFORS/" + e.Node.Text;
            string dirSynched = e.Node.Text;
            DialogResult result = MessageBox.Show("Do you want to enable auto synchronisation mode?", "Auto mode", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch(result)
            {
                case DialogResult.Yes:
                    //Start synchronisation
                    SyncWorkingDirectoryAsync();
                    //Enable automode flag
                    isAutoMode_ = true;
                    //Clear tree of folders in preparation for files
                    treeViewFolders.Nodes.Clear();
                    treeViewFolders.Nodes.Add(dirSynched);
                    timerAutoSync_ = new Timer();
                    timerAutoSync_.Interval = 5000;
                    timerAutoSync_.Tick += AutoTimerTick;
                    timerAutoSync_.Start();
                    break;
                case DialogResult.No:
                    //Start synchronisation
                    SyncWorkingDirectoryAsync();
                    isAutoMode_ = false;
                    treeViewFolders.Nodes.Clear();
                    treeViewFolders.Nodes.Add(dirSynched);
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }

        }
        private void AutoTimerTick(object sender, EventArgs e)
        {
            SyncWorkingDirectoryAsync();
        }
        //Menu map handlers//
        private void satelliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        private void roadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        private void hybridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        private void satelliteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        private void roadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        private void hybridToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        //State variables
        private bool isAutoMode_ = false;
        private enum FtpConnectionState
        {
            Disconnected,
            Connected,
            FolderListing,
            Synchronised
        };
        private FtpConnectionState connectionState_ = FtpConnectionState.Disconnected;
        private Timer timerAutoSync_;

        private void gMapControl_OnMapZoomChanged()
        {
            overlayImg.ResizeAll();
        }

        private void zoomInMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl_OnMapZoomChanged();
            gMapControl.ZoomAndCenterMarkers("images");
        }

        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStripMap.Show((GMapControl)sender,e.Location);
            }
        }
    }
}

namespace GMap.NET.WindowsForms.Markers
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class GMapMarkerImage : GMapMarker
    {
        public System.Drawing.Image Image;

        public GMapMarkerImage(PointLatLng p) : base(p)
        {
        }

        public override void OnRender(Graphics g)
        {
            g.DrawImage(Image, System.Convert.ToInt32(LocalPosition.X - Size.Width / 2), System.Convert.ToInt32(LocalPosition.Y - Size.Height / 2), Size.Width, Size.Height);
        }
    }
}