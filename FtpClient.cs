﻿using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

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
        public void CheckForFullImages()
        {

        }

        public void FtpListDirectoryWorker(object sender, DoWorkEventArgs e)
        {
            autoWorking = true;
            string remoteDir = (string)e.Argument;
            (sender as BackgroundWorker).ReportProgress(0, "Connecting to Server");
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverDomain_ + ":" + serverPort_ + "/" + remoteDir);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

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
                autoWorking = false;
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
                    //Split directory line listing string//
                    string[] dirParam = dirLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //Last parameter is the folder/file name - assume it soes not contain any space separators
                    dirListing.Add(dirParam[dirParam.Length - 1]);
                    //Console.WriteLine(dirParam[dirParam.Length-1]);
                }
            }

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
            (sender as BackgroundWorker).ReportProgress(100, "Directory list complete!");
            reader.Close();
            response.Close();
            e.Result = dirListing;
            autoWorking = false;
            return;
        }
        public void FtpCommDirectoryWorker(object sender, DoWorkEventArgs e)
        {
            commWorking = true;
            string remoteDir = (string)e.Argument;
            List<string> dirListing;
            dirListing = FtpListDirectory(remoteDir);
            if (dirListing != null)
            {
                for (int i = 0; i < dirListing.Count; i++)
                {
                    if (dirListing.ElementAt(i).Contains(".jpg"))
                    {
                        Console.WriteLine(dirListing.ElementAt(i));
                        DownloadFile("UAVFORS/comm", dirListing.ElementAt(i), "UAVFORS/comm");
                        //RemoveFile("UAVFORS/comm", dirListing.ElementAt(i));
                        e.Result = "UAVFORS/comm/" + dirListing.ElementAt(i);
                        break;
                    }
                }
            }
            commWorking = false;
            return;
        }
        public void DownloadAllWorkingDirWorker(object sender, DoWorkEventArgs e)
        {
            autoWorking = true;
            //Ensure directory existence
            if (!Directory.Exists(WorkingDir))
            {
                Directory.CreateDirectory(WorkingDir);
            }
            //Get list of remote files
            (sender as BackgroundWorker).ReportProgress(5, "Listing working directory");
            List<string> dirFiles = FtpListDirectory(WorkingDir);
            //Create list of local files
            string[] localFiles = Directory.GetFiles(WorkingDir);
            (sender as BackgroundWorker).ReportProgress(10, "Sorting downloaded files");
            for (int i = 0; i < localFiles.Length; ++i)
            {
                localFiles[i] = Path.GetFileName(localFiles[i]);
            }
            //Remove all existing files from download worklist
            foreach (string existingFile in localFiles)
            {
                dirFiles.Remove(existingFile);
            }
            e.Result = new string[dirFiles.Count];
            dirFiles.CopyTo((string[]) e.Result);
            //Start downloading remaining files
            int filesTotal = dirFiles.Count;
            int fileDownloaded = 1;
            //Parallelize execution
            Object lockStatus = new Object();
            Parallel.ForEach(dirFiles, (file) =>
            {
                DownloadFileWorkingDir(file);
                lock (lockStatus)
                {
                    double progress = (double)fileDownloaded / filesTotal * 90;
                    (sender as BackgroundWorker).ReportProgress(10 + (int)progress, "Downloading files: " + fileDownloaded.ToString() + "/" + filesTotal.ToString());
                    fileDownloaded++;
                }
            });
            while (dirFiles.Count != 0)
            {
                //double progress = (double)fileDownloaded / filesTotal * 90;
                //(sender as BackgroundWorker).ReportProgress(10 + (int)progress, "Downloading files: " + fileDownloaded.ToString() + "/" + filesTotal.ToString());
               // string fileToDownload = dirFiles[0];
               // DownloadFileWorkingDir(fileToDownload);
                dirFiles.RemoveAt(0);
                //fileDownloaded++;
            }
            (sender as BackgroundWorker).ReportProgress(100, "File Sync completed");
            autoWorking = false;
            return;
        }
        //Synchronous methods
        public void DownloadAllWorkingDir()
        {
            //Ensure directory existence
            if (!Directory.Exists(WorkingDir))
            {
                Directory.CreateDirectory(WorkingDir);
            }
            //Get list of remote files
            List<string> dirFiles = FtpListDirectory(WorkingDir);
            //Create list of local files
            string[] localFiles = Directory.GetFiles(WorkingDir);
            for(int i = 0; i < localFiles.Length; ++i)
            {
                localFiles[i] = Path.GetFileName(localFiles[i]);
            }
            //Remove all existing files from download worklist
            foreach(string existingFile in localFiles)
            {
                dirFiles.Remove(existingFile);
            }
            //Start downloading remaining files
            int filesTotal = dirFiles.Count;
            while(dirFiles.Count != 0)
            {
                string fileToDownload = dirFiles[0];
                DownloadFileWorkingDir(fileToDownload);
                dirFiles.RemoveAt(0);
            }
            
        }
        public void RequestImage(string filename)
        {
            //List directory to look for existing request
            List<string> dirlist = FtpListDirectory("UAVFORS/comm");
            if (dirlist.Contains("request.txt")) return;
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverDomain_ + ":" + serverPort_ + "/UAVFORS/comm/request.txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username_, password_);

            // Copy the contents of the file to the request stream.
            //StreamReader sourceStream = new StreamReader("testfile.txt");
            byte[] fileContents = Encoding.UTF8.GetBytes(filename);
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException exception)
            {
                System.Console.WriteLine("Server not responding, message: " + exception.Message);
                return;
            }
            response.Close();
        }
        public void RemoveFile(string remotePath, string filename)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverDomain_ + ":" + serverPort_ + "/" + remotePath + "/" + filename);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            
            request.Credentials = new NetworkCredential(username_, password_);
            request.KeepAlive = true;

            FtpWebResponse response;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException exception)
            {
                System.Console.WriteLine("Server not responding, message: " + exception.Message);
                return;
            }
            Console.WriteLine("Delete Complete, status {0}", response.StatusDescription);

        }
        public void DownloadFile(string remotePath, string filename, string destinationPath)
        {
            //string remotePath = WorkingDir + "/" + filename;
            //Ensure directory existence
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverDomain_ + ":" + serverPort_ + "/" + remotePath + "/" + filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // use binary mode for file transfer
            request.Credentials = new NetworkCredential(username_, password_);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;

            FtpWebResponse response;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException exception)
            {
                System.Console.WriteLine("Server not responding, message: " + exception.Message);
                return;
            }
            //Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            //Write file to disk directory
            var fileStream = File.Create(destinationPath + "/" + filename);
            //responseStream.Seek(0, SeekOrigin.Begin);
            responseStream.CopyTo(fileStream);
            fileStream.Flush();
            fileStream.Close();
            reader.Close();
            response.Close();

        }
        public void DownloadFileWorkingDir(string filename)
        {
            DownloadFile(WorkingDir, filename, WorkingDir);
        }
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


           // Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();

            return dirListing;
        }




        public string WorkingDir { get; set; }
        public bool autoWorking { get; set; }
        public bool commWorking { get; set; }
        //Server object
        //Default server parameters
        private string serverDomain_ = "srv40.ddns.net";
        private int serverPort_ = 2514;
        private string username_ = "melavio";
        private string password_ = "wietnamiec";
    }
}
