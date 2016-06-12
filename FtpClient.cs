using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace FTP_Image_Browser
{
    class FtpClient
    {
        public FtpClient()
        {
            WorkingDir = "UAVFORS";
        }
        public void Connect()
        {
            foreach (string dir in FtpListDirectory("UAVFORS/"))
            {
                Console.WriteLine(dir);
            }
        }
        ~FtpClient()
        {

        }
        public void FtpListDirectoryWorker(object sender, DoWorkEventArgs e)
        {
            string remoteDir = (string)e.Argument;
            (sender as BackgroundWorker).ReportProgress(0, "Connecting to Server");
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverDomain_ + ":" + serverPort_ + "/" + remoteDir);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            FtpWebResponse response;
            request.Credentials = new NetworkCredential(username_, password_);

            (sender as BackgroundWorker).ReportProgress(25, "Connecting to Server");
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException exception)
            {
                System.Console.WriteLine("Server not responding, message: " + exception.Message);
                MessageBox.Show("Cannot connect to remote server \r\nDescription:" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Result = null;
                return;
            }
            (sender as BackgroundWorker).ReportProgress(75, "Directory listing recieved, processing");
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            // Console.WriteLine(reader.ReadToEnd());
            List<string> dirListing = new List<string>();
            while (true)
            {
                string dirLine = reader.ReadLine();
                if (dirLine == null) break;
                else
                {
                    //Console.WriteLine(dirLine);
                    //Split directory line listing string//
                    string[] dirParam = dirLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //Last parameter is the folder/file name - assume it soes not contain any space separators
                    dirListing.Add(dirParam[dirParam.Length - 1]);
                    //Console.WriteLine(dirParam[dirParam.Length-1]);
                }
            }


            // Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
            (sender as BackgroundWorker).ReportProgress(100, "Directory list complete!");
            reader.Close();
            response.Close();
            e.Result = dirListing;
            return;
        }

        //Synchronous methods
        public List<string> FtpListDirectory(string remoteDir)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverDomain_ + ":" + serverPort_ + "/" + remoteDir);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            FtpWebResponse response;
            request.Credentials = new NetworkCredential(username_, password_);
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException exception)
            {
                System.Console.WriteLine("Server not responding, message: " + exception.Message);
                return null;
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            // Console.WriteLine(reader.ReadToEnd());
            List<string> dirListing = new List<string>();
            while (true)
            {
                string dirLine = reader.ReadLine();
                if (dirLine == null) break;
                else
                {
                    //Console.WriteLine(dirLine);
                    //Split directory line listing string//
                    string[] dirParam = dirLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //Last parameter is the folder/file name - assume it soes not contain any space separators
                    dirListing.Add(dirParam[dirParam.Length - 1]);
                    //Console.WriteLine(dirParam[dirParam.Length-1]);
                }
            }


            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();

            return dirListing;
        }
        public string WorkingDir { get; set; }
        //Server object
        //Default server parameters
        private string serverDomain_ = "srv40.ddns.net";
        private int serverPort_ = 2514;
        private string username_ = "melavio";
        private string password_ = "wietnamiec";
    }
}
