using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FTP_Image_Browser
{
    public partial class Form1 : Form
    {
        FtpClient ftpClient;
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
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.SetPositionByKeywords("Warsaw, Poland");
        }
        private void ListWorkingDirectoryAsync()
        {
            //start new task in background
            BackgroundWorker ftpRequestWorker = new BackgroundWorker();
            ftpRequestWorker.DoWork += new DoWorkEventHandler(ftpClient.FtpListDirectoryWorker);
            ftpRequestWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            ftpRequestWorker.WorkerReportsProgress = true;
            ftpRequestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FtpListFolders);
            ftpRequestWorker.RunWorkerAsync(ftpClient.WorkingDir);
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset working directory
            ftpClient.WorkingDir = "UAVFORS";
            ListWorkingDirectoryAsync();
        }

        private void buttonMagic_Click(object sender, EventArgs e)
        {

        }
        
        //event handlers for specific tasks

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

            }
            else if(dirListing != null && ftpClient.WorkingDir.Contains("UAVFORS/"))
            {
                //Listing image subdirectory
                ftpClient.DownloadFileWorkingDir(dirListing[0]);
                foreach (string str in dirListing)
                {
                    Console.WriteLine(str);
                }

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
            Console.WriteLine(e.Node.Text);
            ftpClient.WorkingDir = "UAVFORS/" + e.Node.Text;
            ListWorkingDirectoryAsync();
        }
    }
}
