using System;
using System.IO;
using System.Net;

namespace FTP_Image_Browser
{
    class FtpClient
    {
        public FtpClient()
        {

        }
        ~FtpClient()
        {

        }

        private void FtpListDirectory()
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://srv40.ddns.net:2514/UAVFORS");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("melavio", "wietnamiec");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();
        }
    }
}
