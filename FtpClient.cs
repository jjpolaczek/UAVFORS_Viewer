using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Reflection.Emit;

namespace FTP_Image_Browser
{
    class FtpClient
    {
        public FtpClient()
        {

        }
        public void Connect()
        {
            foreach(string dir in FtpListDirectory("UAVFORS/"))
            {
                Console.WriteLine(dir);
            }
        }
        ~FtpClient()
        {

        }
        public void FtpListDirectoryWorker(object sender, DoWorkEventArgs e)
        {
            string remoteDir = (string) e.Argument;
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
                MessageBox.Show("Cannot connect to remote server \r\nDescription:" + exception.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
        public List<string> FtpListDirectory(string remoteDir)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://"+ serverDomain_ + ":" + serverPort_ + "/" + remoteDir);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            FtpWebResponse response;
            request.Credentials = new NetworkCredential(username_, password_);
            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch(WebException  exception)
            {
                System.Console.WriteLine("Server not responding, message: " + exception.Message);
                return null;
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
           // Console.WriteLine(reader.ReadToEnd());
            List<string> dirListing = new List<string>();
            while(true)
            {
                string dirLine = reader.ReadLine();
                if (dirLine == null) break;
                else
                {
                    //Console.WriteLine(dirLine);
                    //Split directory line listing string//
                    string[] dirParam = dirLine.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
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

        // Decoding jpeg files 
        // Added by KŁ 11.06.2016
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SomeData
        {
            public UInt32 time;

            Int32 latitude;
            Int32 longtitude;
            Int32 altitude;

            float speedX;
            float speedY;

            float roll;
            float pitch;
            float yaw;

            float gyroX;
            float gyroY;
            float gyroZ;

            char status;
        }
        public struct ImageWithData
        {
            public Image image;

            public SomeData data;
        }
        public ImageWithData decode(string filename)
        {
            SomeData dataStructure = new SomeData();

            byte[] bytes = System.IO.File.ReadAllBytes(filename);

            int sizeOFStructure = System.Runtime.InteropServices.Marshal.SizeOf(typeof(SomeData));

            byte[] dataBytes = new byte[sizeOFStructure];

            for (int i = 0; i < sizeOFStructure; i++)
                dataBytes[i] = bytes[bytes.GetLength(0) - sizeOFStructure + i];

            int size = Marshal.SizeOf(dataStructure);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(dataBytes, 0, ptr, size);

            dataStructure = (SomeData)Marshal.PtrToStructure(ptr, dataStructure.GetType());
            Marshal.FreeHGlobal(ptr);

            ImageWithData iwd = new ImageWithData();


            iwd.image = Image.FromFile("image.jpg");
            iwd.data = dataStructure;

            return iwd;
        }

        //Server object
        //Default server parameters
        private string serverDomain_ = "srv40.ddns.net";
        private int serverPort_ = 2514;
        private string username_ = "melavio";
        private string password_ = "wietnamiec";
    }
}
