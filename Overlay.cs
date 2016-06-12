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
        public void AddToOverlay(string filename)
        {
            Bitmap imageTest = new Bitmap("..\\..\\images\\folder2.png");

            // imageTest.SetResolution(10, 10);
            GMarkerGoogle markerTest = new GMarkerGoogle(new GMap.NET.PointLatLng(52.2297700, 21.0117800), imageTest);
            markerTest.Offset = new Point(0, 0);
            markerTest.Size = new Size(50, 50);
            overlayImg_.Markers.Add(markerTest);
        }
        public void ResizeAll(double zoom)
        {
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
        double zoomMaxOverlay_ = 20;
        double zoomMinOverlay_ = 12;
        GMapOverlay overlayImg_;

        // Decoding jpeg files 
        // Added by KŁ 11.06.2016
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
    }
}
