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
            downPointScale_ = new GMarkerGoogle(new GMap.NET.PointLatLng(0.0, 0.0), GMarkerGoogleType.blue_dot);
            downPointScale_.Tag = "left";
            downPointScale_.Size = new Size(0, 0);
            upPointScale_ = new GMarkerGoogle(new GMap.NET.PointLatLng(10.0/111000, 0.0), GMarkerGoogleType.blue_dot);
            upPointScale_.Tag = "right";
            upPointScale_.Size = new Size(0, 0);
            overlayImg_.Markers.Add(downPointScale_);
            overlayImg_.Markers.Add(upPointScale_);
            //Todo scale variably edepending on latitude
        }
        public GMarkerGoogle downPointScale_, upPointScale_;
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
            //overlayImg_.OnRender();
            int pixdist = downPointScale_.LocalArea.Y - upPointScale_.LocalArea.Y;
            Console.WriteLine(pixdist.ToString());
            int sizenew = pixdist + resizetest;
            if (zoom < zoomMinOverlay_) sizenew = 0;
            //Console.WriteLine(sizenew.ToString() + " - zoom");
            if(overlayImg_ != null)
            {
                foreach (GMapMarker marker in overlayImg_.Markers)
                {
                    if((string) marker.Tag != "left" && (string)marker.Tag != "right")
                    marker.Size = new Size(sizenew, sizenew);
                    
                }
                
            }
        }
        public int resizetest = 10;
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
        double zoomMinOverlay_ = 5;
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
