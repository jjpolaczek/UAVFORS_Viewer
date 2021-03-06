﻿using System;
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

namespace UAVFORS_Viewer
{
    public partial class Form1 : Form
    {
        
        FtpClient ftpClient;
        Overlay overlayImg;
        public Form1()
        {
            ServerSettingsDialog serverSettings = new ServerSettingsDialog();
            ftpClient = new FtpClient(serverSettings.settings);
            treeViewFolders = new TreeView();

            InitializeComponent();
            //FtpListDirectory();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize map:
            gMapControl.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.SetPositionByKeywords("Dalby, Australia");
            //Initialize image overlay
            GMapOverlay imageOverlay = new GMapOverlay("images");
            GMapOverlay scaleOverlay = new GMapOverlay("scale");
            gMapControl.Overlays.Add(imageOverlay);
            gMapControl.Overlays.Add(scaleOverlay);
            overlayImg = new Overlay(imageOverlay, scaleOverlay, gMapControl);
            gMapControl.IgnoreMarkerOnMouseWheel = true;
            gMapControl.LevelsKeepInMemmory = 18;
            if(FtpClient.CheckForInternetConnection())
            {
                connectToolStripMenuItem_Click(new object(), new EventArgs());
            }
        }
        private void ListWorkingDirectoryAsync()
        {
            if (ftpClient.autoWorking == true) return;
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
        private void ListCommDirAsync()
        {
            if (ftpClient.commWorking == true) return;
            //start new file synchronization task in background
            BackgroundWorker ftpRequestWorker = new BackgroundWorker();
            ftpRequestWorker.DoWork += new DoWorkEventHandler(ftpClient.FtpCommDirectoryWorker);
            ftpRequestWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            ftpRequestWorker.WorkerReportsProgress = false;
            ftpRequestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FtpCommComplete);
            ftpRequestWorker.RunWorkerAsync("UAVFORS/comm");
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset working directory
            ftpClient.WorkingDir = "UAVFORS";
            ListWorkingDirectoryAsync();
        }
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ftpClient.Disconnect();
            overlayImg.Clear();
            treeViewFolders.Nodes.Clear();
            if (isAutoMode_)
            {
                timerAutoSync_.Dispose();
                timerCommUAV_.Dispose();
                isAutoMode_ = false;
            }

        }
        private void buttonMagic_Click(object sender, EventArgs e)
        {
            // ftpClient.RequestImage("jebaj sie");
            // return;
            //ListCommDirAsync();
            //return;
            ftpClient.RequestTerrain((float)69.0,(float) -68.0);
            //gMapControl_OnMapZoomChanged();
            //gMapControl.ZoomAndCenterMarkers("images");
           // overlayImg.SetFiltersWorker(new object(), new DoWorkEventArgs(new Overlay.MarkerFilters(1000, 0, 1400000, 1300000)));
        }
        


        //event handlers for specific tasks
        private void SliderChanged(object sender, EventArgs e)
        {
            if (trackBarTimeMax.Maximum != trackBarTimeMax.Value)
                overlayImg.imageFilters_.timeMax = (int)overlayImg.timeRoiMax_;
            else
                overlayImg.imageFilters_.timeMax = -1;

            UpdateSlidersFromOverlay();
            if (trackBarTimeMax.Maximum != trackBarTimeMax.Value)
                overlayImg.SetFilters(new Overlay.MarkerFilters(new Overlay.Scores((byte) trackBarScoreDensity.Value, (byte)trackBarScoreHue.Value,0,0), trackBarTimeMax.Value, trackBarTime.Value));
            else
                overlayImg.SetFilters(new Overlay.MarkerFilters(new Overlay.Scores((byte)trackBarScoreDensity.Value, (byte)trackBarScoreHue.Value, 0, 0), -1, trackBarTime.Value));
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
                connectionState_ = FtpConnectionState.FolderListing;

            }
            else if(dirListing != null && ftpClient.WorkingDir.Contains("UAVFORS/"))
            {
                

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
                trackBarTime.TickFrequency = 1000;
                trackBarTimeMax.TickFrequency = 1000;
            }
            else if(connectionState_ == FtpConnectionState.Synchronised)
            {
                //Add only new nodes //todo outofrange exception here
                if (filesDownloaded == null)
                    return;
                foreach (string str in filesDownloaded)
                    treeViewFolders.Nodes[0].Nodes.Add(str);
                overlayImg.OverlayNew(filesDownloaded);
            }
            //overlayImg.ResizeAll();

            //Update sliders//
            UpdateSlidersFromOverlay();

        }
        private void UpdateSlidersFromOverlay()
        {
            trackBarTime.Minimum = (int)overlayImg.timeRoiMin_;
            trackBarTime.Maximum = (int)overlayImg.timeRoiMax_;
            if (trackBarTime.Value < trackBarTime.Minimum) trackBarTime.Value = trackBarTime.Minimum;
            trackBarTimeMax.Minimum = (int)overlayImg.timeRoiMin_;
            trackBarTimeMax.Maximum = (int)overlayImg.timeRoiMax_;
            if (trackBarTimeMax.Value < trackBarTimeMax.Minimum) trackBarTimeMax.Value = trackBarTimeMax.Minimum;
            if (trackBarTimeMax.Value > trackBarTimeMax.Maximum) trackBarTimeMax.Value = trackBarTimeMax.Maximum;
            if (overlayImg.imageFilters_.timeMax == -1) trackBarTimeMax.Value = trackBarTimeMax.Maximum;
            //Additional condition to add proper 10s divisionand 1s precision
            if(trackBarTime.Maximum - trackBarTime.Minimum > 10000)
            {
                trackBarTime.TickFrequency = 10000;
                trackBarTime.LargeChange = 5000;
                trackBarTime.SmallChange = 1000;
                trackBarTimeMax.LargeChange = 5000;
                trackBarTimeMax.SmallChange = 1000;
                trackBarTimeMax.TickFrequency = 10000;
            }
            
        }
        //Handle communication work
        private void FtpCommComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            string fileToDisplay = (string)e.Result;
            if(fileToDisplay != null)
            {
                TopViewDialog imageDisplay = new TopViewDialog(fileToDisplay);
                imageDisplay.Show();
            }
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

                    timerCommUAV_ = new Timer();
                    timerCommUAV_.Interval = 1000;
                    timerCommUAV_.Tick += CommTimerTick;
                    timerCommUAV_.Start();
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
        private void CommTimerTick(object sender, EventArgs e)
        {
            ListCommDirAsync();
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
        private Timer timerCommUAV_;

        private void gMapControl_OnMapZoomChanged()
        {
            gMapControl.Refresh();
            overlayImg.ResizeAll();
        }

        private void zoomInMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gMapControl_OnMapZoomChanged();
            gMapControl.ZoomAndCenterMarkers("images");
        }
        private void addPOIToolStripMenuItem_Click(object sender, EventArgs e)
        {

            double X = gMapControl.FromLocalToLatLng(locationTemp_.X, locationTemp_.Y).Lng;
            double Y = gMapControl.FromLocalToLatLng(locationTemp_.X, locationTemp_.Y).Lat;
            string longitude = X.ToString("#.0000000");
            string latitude = Y.ToString("#.0000000");
            
            
        }
        private void clearPOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gMapControl.Overlays[1].Markers.Count > 2)
            {
                //Clear additional markers and distance calculation
                for(int i = 2; i < gMapControl.Overlays[1].Markers.Count; ++i)
                {
                    gMapControl.Overlays[1].Markers.RemoveAt(2);
                }
            }
        }
        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                double X = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
                string longitude = X.ToString("#.0000000");
                string latitude = Y.ToString("#.0000000");
                labelLonLatch.Text = longitude;
                labelLatLatch.Text = latitude;

                double UTMN, UTME;
                string UTMzone;
                overlayImg.LatLongtoUTM(Y, X, out UTMN, out UTME, out UTMzone);
                labelUTME.Text = UTME.ToString("#.00") + "E";
                labelUTMN.Text = UTMN.ToString("#.00") + "N";
                labelUTMzone.Text = UTMzone.ToString();
            }
        }
        
        private void gMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                locationTemp_ = e.Location;
                contextMenuStripMap.Show((GMapControl)sender, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if(isOverMarker_ && isAutoMode_)
                {
                    RoiDialog ask = new RoiDialog(((Overlay.MarkerData)overMarker.Tag).latitude, ((Overlay.MarkerData)overMarker.Tag).longitude);
                    DialogResult result = ask.ShowDialog();//MessageBox.Show("Download corresponding image named " + ((Overlay.MarkerData)overMarker.Tag).sourceFileName, "ROI ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ftpClient.RequestImage(((Overlay.MarkerData)overMarker.Tag).sourceFileName);
                    }
                    else if (result == DialogResult.OK)
                    {
                        ftpClient.RequestTerrain(((Overlay.MarkerData)overMarker.Tag).latitude, ((Overlay.MarkerData)overMarker.Tag).longitude);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        private Point locationTemp_;
        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            double X = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            string longitude = X.ToString("#.0000000");
            string latitude = Y.ToString("#.0000000");
            labelLongitude.Text = longitude;
            labelLatitude.Text = latitude;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if(connectionState_ == FtpConnectionState.FolderListing)
            {
                treeViewFolders.Nodes.Clear();
                ListWorkingDirectoryAsync();
            }
        }

        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //Show coordinates and messagebox//

            double X = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            string longitude = X.ToString("#.0000000");
            string latitude = Y.ToString("#.0000000");
            labelLonLatch.Text = longitude;
            labelLatLatch.Text = latitude;

            double UTMN, UTME;
            string UTMzone;
            overlayImg.LatLongtoUTM(Y, X, out UTMN, out UTME, out UTMzone);
            labelUTME.Text = UTME.ToString("#.00") + "E";
            labelUTMN.Text = UTMN.ToString("#.00") + "N";
            labelUTMzone.Text = UTMzone.ToString();
        }

        bool isOverMarker_ = false;
        GMapMarker overMarker;
        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            overMarker = item;
            isOverMarker_ = true;
        }


        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {
            isOverMarker_ = false;
        }

        private void trackBarSize_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            if (trackBar != null)
            {
                overlayImg.sizeSkew_ = trackBar.Value;
                overlayImg.ResizeAll();
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerSettingsDialog settingsDialog = new ServerSettingsDialog();
            var result = settingsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //disconnectf all connections//
                disconnectToolStripMenuItem_Click(new object(), new EventArgs());
                //Modify server parameters//
                ftpClient.SetServerParams(settingsDialog.settings);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSendLocation_Click(object sender, EventArgs e)
        {
            float latitude, longitude;
            try
            {
                latitude = Convert.ToSingle(textBoxLatitudeLand.Text);
                longitude = Convert.ToSingle(textBoxLongitudeLand.Text);
            }
            catch
            {
                MessageBox.Show("Error", "It was not possible to read the location from the text boxes.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ftpClient.RequestLanding(latitude, longitude);
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