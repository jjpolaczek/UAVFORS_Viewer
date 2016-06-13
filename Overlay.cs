using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Reflection.Emit;
namespace FTP_Image_Browser
{
    class Overlay
    {
        public Overlay(GMapOverlay overlay)
        {
            overlayImg_ = overlay;
        }
        //Overlay handlers:
        //Add image minature to overlay
        private void AddToOverlay(string filename)
        {
            ImageWithData iwd = decode(filename);

            // imageTest.SetResolution(10, 10);new GMarkerGoogle(new GMap.NET.PointLatLng(52.2297700, 21.0117800), imageTest);
            GMarkerGoogle markerTest = new GMarkerGoogle(new GMap.NET.PointLatLng(iwd.data.targetLatitude, iwd.data.targetLongitude), (Bitmap)iwd.image);
            markerTest.Offset = new Point(0, 0);
           // markerTest.Size = new Size(50, 50);
            overlayImg_.Markers.Add(markerTest);
        }
        public void ResizeAll(double zoom)
        {
            return;
            int sizenew = (int)(4.0 * Math.Pow(zoom,2) / zoomMaxOverlay_);
            if (zoom < zoomMinOverlay_) sizenew = 0;
            //Console.WriteLine(sizenew.ToString() + " - zoom");
            if(overlayImg_ != null)
            {
                foreach(GMapMarker marker in overlayImg_.Markers)
                {
                    marker.Size = new Size(sizenew, sizenew);
                }
                
            }
        }
        public void OverlayWorkingDir()
        {
            //Create list of local files (with paths)
            string[] newImg = Directory.GetFiles(WorkingDir);
            if (newImg == null) return;
            int imagesTotal = newImg.Count();
            int imageCurrent = 1;
            foreach (string file in newImg)
            {
                AddToOverlay(file);
                imageCurrent++;
            }
        }
        public void OverlayNew(string[] newImg)
        {
            if (newImg == null) return;
            int imagesTotal = newImg.Count();
            int imageCurrent = 1;
            foreach(string file in newImg)
            {
                AddToOverlay(WorkingDir + "/" + file);
                imageCurrent++;
            }

        }
        double zoomMaxOverlay_ = 20;
        double zoomMinOverlay_ = 12;
        GMapOverlay overlayImg_;

        // Decoding jpeg files 
        // Added by KŁ 11.06.2016
        public struct ImageData
        {
            public UInt32 time;

            public float targetLatitude;
            public float targetLongitude;

            public float planeAltitude;
            public float planeLatitude;
            public float planeLongitude;

            /*Int32 latitude;
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

            char status;*/
        }
        public struct ImageWithData
        {
            public Image image;

            public ImageData data;
        }
        public ImageWithData decode(string filename)
        {
            ImageData dataStructure = new ImageData();

            byte[] bytes = System.IO.File.ReadAllBytes(filename);

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
        public string WorkingDir { get; set; }
    }
}
