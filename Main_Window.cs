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
using System.Runtime.InteropServices;

namespace UAVFORS_Viewer
{
    public partial class Form1 : Form
    {

        FtpClient ftpClient;
        public Form1()
        {
            ServerSettingsDialog serverSettings = new ServerSettingsDialog();
            ftpClient = new FtpClient(serverSettings.settings);
            treeViewFolders = new TreeView();

            InitializeComponent();
            UAVcollection = new ImageList();
            //FtpListDirectory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize map:
            if (FtpClient.CheckForInternetConnection())
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
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (connectionState_ == FtpConnectionState.FolderListing)
            {
                treeViewFolders.Nodes.Clear();
                ListWorkingDirectoryAsync();
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ftpClient.Disconnect();
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
            ftpClient.RequestTerrain((float)69.0, (float)-68.0);
            //gMapControl_OnMapZoomChanged();
            //gMapControl.ZoomAndCenterMarkers("images");
            // overlayImg.SetFiltersWorker(new object(), new DoWorkEventArgs(new Overlay.MarkerFilters(1000, 0, 1400000, 1300000)));
        }



        //event handlers for specific tasks
        //Handle directory list return value
        private void FtpListFolders(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> dirListing = (List<string>)e.Result;
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
            else if (dirListing != null && ftpClient.WorkingDir.Contains("UAVFORS/"))
            {
                
            }
        }
        //Handle file sync return value
        private void FtpDownloadedFiles(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] filesDownloaded = (string[])e.Result;

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
                    int no;
                    if(Int32.TryParse(localFiles[i], out no))
                    {
                       //We have images in correct format, load them into the image collection
                    }
                }
                //Refresh local files in node
                foreach (string str in localFiles)
                {
                    treeViewFolders.Nodes[0].Nodes.Add(str);
                }
                //Take 1st image and display it
                pictureBox_main.Image = Image.FromFile(ftpClient.WorkingDir + "//" + localFiles[0]);
                if (Int32.TryParse(Path.GetFileNameWithoutExtension(localFiles[0]), out current_filename))
                {
                    label_imgcount.Text = 1.ToString() + "/" + localFiles.Length.ToString();
                    //We have images in correct format, load them into the image collection
                }
            }
            else if (connectionState_ == FtpConnectionState.Synchronised)
            {
                //Add only new nodes //todo outofrange exception here
                if (filesDownloaded == null)
                    return;
                foreach (string str in filesDownloaded)
                    treeViewFolders.Nodes[0].Nodes.Add(str);
            }
            //overlayImg.ResizeAll();
        }

        //Handle communication work
        private void FtpCommComplete(object sender, RunWorkerCompletedEventArgs e)
        {

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
            switch (result)
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
        ImageList UAVcollection;

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


        int current_filename = -1;
        struct NumName
        {
            public NumName(int num, string path)
            {
                number = num;
                filepath = path;
            }
            public int number;
            public string filepath;
        }
        private List<NumName>GetSortedNumNameList(string path)
        {
            List<NumName> result = new List<NumName>();
            string[] localFiles = Directory.GetFiles(ftpClient.WorkingDir);

            foreach (string str in localFiles)
            {
                try
                {
                    result.Add(new NumName(Int32.Parse(Path.GetFileNameWithoutExtension(str)), str));
                }
                catch
                {

                }
            }
            result.Sort((x, y) => x.number.CompareTo(y.number));
            return result;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (current_filename != -1)
            {
                List<NumName> files = GetSortedNumNameList(ftpClient.WorkingDir);
                //Get current image index in array
                var index = files.FindIndex(x => x.number == current_filename);
                //Take 1st image and display it
                label_imgcount.Text = index.ToString() + "/" + files.Count.ToString();

                switch (e.KeyCode)
                {
                    case Keys.Right:
                        if(++index < files.Count)
                        {
                            pictureBox_main.Image = Image.FromFile(files[index].filepath);
                            current_filename = files[index].number;
                        }
                        break;
                    case Keys.Left:
                        if(--index - 1 >= 0)
                        {
                            pictureBox_main.Image = Image.FromFile(files[index].filepath);
                            current_filename = files[index].number;
                        }
                        break;
                    default:
                        break;
                }
            }
        }



        public ImageWithData decode(string filename)
        {
            if (!filename.EndsWith(".jpg"))
                return new ImageWithData();
            ImageData dataStructure = new ImageData();
            byte[] bytes;
            try
            {
                bytes = System.IO.File.ReadAllBytes(filename);
            }
            catch
            {
                return new ImageWithData();
            }
            if (bytes.GetLength(0) == 0) return new ImageWithData();

            int sizeOFStructure = System.Runtime.InteropServices.Marshal.SizeOf(typeof(ImageData));

            byte[] dataBytes = new byte[sizeOFStructure];

            for (int i = 0; i < sizeOFStructure; i++)
                dataBytes[i] = bytes[bytes.GetLength(0) - sizeOFStructure + i];

            int size = Marshal.SizeOf(dataStructure);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(dataBytes, 0, ptr, size);

            dataStructure = (ImageData)Marshal.PtrToStructure(ptr, dataStructure.GetType());
            Marshal.FreeHGlobal(ptr);
            ImageWithData iwd = new ImageWithData();
            iwd.image = Image.FromFile(filename);
            iwd.data = dataStructure;

            return iwd;
        }
    }
    // Decoding jpeg files 
    // Added by KŁ 11.06.2016
    public struct ImageData
    {
        unsafe public fixed byte imageName[32];
        public UInt32 time;
        public UInt32 score;
        public float targetLatitude;
        public float targetLongitude;

        public float planeAltitude;
        public float planeLatitude;
        public float planeLongitude;
        public float planeYaw;
        // unsafe public fixed char imageName[60];
    }
    public struct ImageWithData
    {
        public Image image;

        public ImageData data;
    }
}
