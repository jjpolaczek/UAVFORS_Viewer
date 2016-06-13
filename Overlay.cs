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
        public Overlay(GMapOverlay overlayImg, GMapOverlay overlayZoom, GMapControl gmap)
        {
            gmap_ = gmap;
            overlayImg_ = overlayImg;
            overlayZoom_ = overlayZoom;
            downPointScale_ = new GMarkerGoogle(new GMap.NET.PointLatLng(0.0, 0.0), GMarkerGoogleType.blue_dot);
            downPointScale_.Tag = "left";
            downPointScale_.Size = new Size(0, 0);
            upPointScale_ = new GMarkerGoogle(new GMap.NET.PointLatLng(10.0/111000, 0.0), GMarkerGoogleType.blue_dot);
            upPointScale_.Tag = "right";
            upPointScale_.Size = new Size(0, 0);
            overlayZoom_.Markers.Add(downPointScale_);
            overlayZoom_.Markers.Add(upPointScale_);
            //Todo scale variably edepending on latitude
        }
        public GMarkerGoogle downPointScale_, upPointScale_;
        //Overlay handlers:
        //Add image minature to overlay
        public struct MarkerData
        {
            public MarkerData(int x, int y)
            {
                baseX = x;
                baseY = y;
            }
            public int baseX;
            public int baseY;
        }
        private void AddToOverlay(string filename)
        {
            ImageWithData iwd = decode(filename);
            //Reject no - gps frames
            if (Math.Abs(iwd.data.targetLongitude) < 0.01)
                return;
            // imageTest.SetResolution(10, 10);new GMarkerGoogle(new GMap.NET.PointLatLng(52.2297700, 21.0117800), imageTest);
            GMarkerGoogle markerTest = new GMarkerGoogle(new GMap.NET.PointLatLng(iwd.data.targetLatitude, iwd.data.targetLongitude), (Bitmap)iwd.image);
            markerTest.Offset = new Point(0, 0);
            markerTest.Tag = new MarkerData(iwd.image.Size.Width, iwd.image.Size.Height);
            overlayImg_.Markers.Add(markerTest);
        }
        public void ResizeAll()
        {
            gmap_.UpdateMarkerLocalPosition(downPointScale_);
            gmap_.UpdateMarkerLocalPosition(upPointScale_);
            //overlayImg_.OnRender();
            int pixdist = downPointScale_.LocalArea.Y - upPointScale_.LocalArea.Y;
            int size10m = pixdist + resizetest;
            //Console.WriteLine(sizenew.ToString() + " - zoom");
            if(overlayImg_ != null)
            {
                foreach (GMapMarker marker in overlayImg_.Markers)
                {
                    MarkerData imgParam = (MarkerData)marker.Tag;
                    double width =  (double)imgParam.baseX / (double) cameraPixelSize_;//width in m
                    double height = (double)imgParam.baseY / (double)cameraPixelSize_;//height in m
                    marker.Size = new Size((int) Math.Round(10.0 * width * size10m) , (int)Math.Round(10.0 * height * size10m));
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
        GMapOverlay overlayImg_, overlayZoom_;
        GMapControl gmap_;

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
        private int cameraPixelSize_ = 63;// pix/m
    }
}
