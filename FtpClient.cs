using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;

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

        private List<string> FtpListDirectory(string remoteDir)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://"+ serverDomain_ + ":" + serverPort_ + "/" + remoteDir);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username_, password_);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

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
        //Server object
        //Default server parameters
        private string serverDomain_ = "srv40.ddns.net";
        private int serverPort_ = 2514;
        private string username_ = "melavio";
        private string password_ = "wietnamiec";
    }
}
