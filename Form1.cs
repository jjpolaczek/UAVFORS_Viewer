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
            Image folderIcon = System.Drawing.Image.FromFile("..\\..\\images\\folder.png");
            treeViewFolders.ImageList = new ImageList();
            treeViewFolders.ImageList.Images.Add(folderIcon);
            
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

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> dirListing = this.ftpClient.FtpListDirectory("");
            
            if (dirListing !=null && dirListing.Contains("UAVFORS"))
            {
                Console.WriteLine("We have the connection and appropriate folder");
                dirListing.Clear();
                dirListing = this.ftpClient.FtpListDirectory("UAVFORS");
                foreach(string str in dirListing)
                {
                    this.treeViewFolders.Nodes.Add(str);
                }
                for(int i = 0; i < treeViewFolders.Nodes.Count;++i)
                {
                    treeViewFolders.Nodes[i].SelectedImageIndex = 0;
                    treeViewFolders.Nodes[i].ImageIndex = 0;
                }
                
            }
            else
            {
                MessageBox.Show("Connection failed - invalid server parameters","Error",MessageBoxButtons.OK);
            }

        }

        private void buttonMagic_Click(object sender, EventArgs e)
        {
            BackgroundWorker ftpRequestWorker = new BackgroundWorker();
            ftpRequestWorker.DoWork += new DoWorkEventHandler(ftpClient.FtpListDirectoryWorker);
            ftpRequestWorker.ProgressChanged += new ProgressChangedEventHandler(progressChanged);
            ftpRequestWorker.WorkerReportsProgress = true;
            ftpRequestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workCompleted);
            ftpRequestWorker.RunWorkerAsync("UAVFORS");
        }
        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            progressBar.Value = (int) e.ProgressPercentage;
            labelStatus.Text = (string)e.UserState;
        }
        private void workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> dirListing = (List<string>) e.Result;
            Console.WriteLine(dirListing[0].ToString());
            labelStatus.Text = "Idle";
            progressBar.Value = 0;
        }
    }
}
