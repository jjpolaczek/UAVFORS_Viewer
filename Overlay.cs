using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Reflection.Emit;
using System.ComponentModel;

namespace FTP_Image_Browser
{
    class Overlay
    {
        //There are two structures - OverlayFilter for filtered images and collection of iwd - image with data in RAM
        //On each update AddToOverlay is called where iwd is added to collection and filtered with current filters
        //In case of global filter change a background worker is called to iterate data and filter it once again
        public Overlay(GMapOverlay overlayDisplay, GMapOverlay overlayZoom, GMapControl gmap)
        {
            gmap_ = gmap;
            overlayImg_ = overlayDisplay;
            overlayZoom_ = overlayZoom;
            downPointScale_ = new GMarkerGoogle(new GMap.NET.PointLatLng(0.0, 0.0), GMarkerGoogleType.blue_dot);
            downPointScale_.Tag = "left";
            downPointScale_.Size = new Size(0, 0);
            upPointScale_ = new GMarkerGoogle(new GMap.NET.PointLatLng(10.0 / 111000, 0.0), GMarkerGoogleType.blue_dot);
            upPointScale_.Tag = "right";
            upPointScale_.Size = new Size(0, 0);
            overlayZoom_.Markers.Add(downPointScale_);
            overlayZoom_.Markers.Add(upPointScale_);
            imageCollection_ = new List<ImageWithData>();
            imageFilters_ = new MarkerFilters(new Scores(0), -1, 0);
        }
        //Markers for scaling the images
        private GMarkerGoogle downPointScale_, upPointScale_;

        public struct MarkerData
        {
            public MarkerData(int x, int y, float yawAngle, float alt, int pixdens, string filename)
            {
                baseX = x;
                baseY = y;
                altitude = alt;
                yaw = yawAngle;
                pixelDensity = pixdens;//Default value change at initialization
                sourceFileName = filename;
                if (filename[0] != 'i')
                    Console.WriteLine("WTF");
                //imgName = imgname;
            }
            public int baseX;
            public int baseY;
            public float altitude;
            public int pixelDensity;
            public float yaw;
            public string sourceFileName;
            //public string imgName;
        }
        public struct MarkerFilters
        {
            //-1 roimax means infinite
            public MarkerFilters(Scores scoreFilter, int roimax, int roimin)
            {
                scoreMin = scoreFilter;
                timeMax = roimax;
                timeMin = roimin;
            }
            public Scores scoreMin;
            public int timeMax, timeMin;
        }
        public void Clear()
        {
            overlayImg_.Clear();
            imageCollection_.Clear();
            timeRoiMin_ = 0;
            timeRoiMax_ = 1;
            scoreRoiMin_ = new Scores(0);
            imageFilters_ = new MarkerFilters(scoreRoiMin_, -1, (int)timeRoiMin_);
        }
        //Overlay handlers:
        //Add image minature to overlay
        public void SetFilters(MarkerFilters filters)
        {
            imageFilters_ = filters;
            GMapOverlay newOverlay = new GMapOverlay();
            //Iterate over range of roi count
            overlayImg_.Clear();
            Parallel.ForEach(imageCollection_, (image) =>
             {
                 AddToOverlay(image);
             });
            ResizeAll();
        }
        public double AddPOI(double lat, double lng)
        {
            overlayZoom_.Markers.Add(new GMarkerGoogle(new GMap.NET.PointLatLng(lat, lng), GMarkerGoogleType.blue_dot));
            //Calculate total distance on map in meters//
            double distance = 0;
            if (overlayZoom_.Markers.Count > 3)
            {
                for (int i = 2; i < overlayZoom_.Markers.Count; ++i)
                {
                    //overlayZoom_.Routes.Add(new)
                }
            }
            return distance;
        }
        public int sizeSkew_ = 0;
        public void ResizeAll()
        {
            gmap_.UpdateMarkerLocalPosition(downPointScale_);
            gmap_.UpdateMarkerLocalPosition(upPointScale_);
            //overlayImg_.OnRender();
            int pixdist = downPointScale_.LocalArea.Y - upPointScale_.LocalArea.Y;
            int size10m = pixdist;
            //Console.WriteLine(sizenew.ToString() + " - zoom");
            if (overlayImg_ != null)
            {
                foreach (GMapMarker marker in overlayImg_.Markers)
                {
                    MarkerData imgParam = (MarkerData)marker.Tag;
                    double width = (double)imgParam.baseX / (double)imgParam.pixelDensity;//width in m
                    double height = (double)imgParam.baseY / (double)imgParam.pixelDensity;//height in m
                    marker.Size = new Size((int)Math.Round(width * size10m + +sizeSkew_), (int)Math.Round(height * size10m + sizeSkew_));
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
            Parallel.ForEach(newImg, (file) =>
            {
                AddToOverlay(file);
                imageCurrent++;
            });
        }
        public void OverlayNew(string[] newImg)
        {
            if (newImg == null) return;
            int imagesTotal = newImg.Count();
            int imageCurrent = 1;
            foreach (string file in newImg)
            {
                AddToOverlay(WorkingDir + "/" + file);
                imageCurrent++;
            }
        }
        private void AddToOverlay(ImageWithData iwd)
        {
            //Reject no - gps frames
            if (Math.Abs(iwd.data.targetLongitude) < 0.01)
                return;


            if (Math.Abs(iwd.data.planeLatitude) > 90.0 || Math.Abs(iwd.data.planeLongitude) > 180.0)
            {
                Console.WriteLine("Invalid coordinates");
                return;
            }
            //verify filters
            //Filter score
            Scores imageScore = new Scores(iwd.data.score);
            imageScore.score[2] = 1;
            imageScore.score[3] = 1;
            if (imageScore > imageFilters_.scoreMin)
                return;
            if (iwd.data.time < imageFilters_.timeMin)
                return;
            if (imageFilters_.timeMax != -1)
            {
                //infinite rois
                if (iwd.data.time > imageFilters_.timeMax)
                    return;
            }
            GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(iwd.data.targetLatitude, iwd.data.targetLongitude), (Bitmap)iwd.image);
            //GMarkerGoogle markerTest = new GMarkerGoogle(new GMap.NET.PointLatLng(iwd.data.planeLatitude, iwd.data.planeLongitude), (Bitmap)iwd.image);
            marker.Offset = new Point(0, 0);
            unsafe
            {
                marker.Tag = new MarkerData(iwd.image.Size.Width, iwd.image.Size.Height, iwd.data.planeYaw, iwd.data.planeAltitude,
                    GetPixelDensity(iwd.data.planeAltitude), convertImageName(iwd.data.imageName));
            }
            lock (overlayImgLock_)
            {
                overlayImg_.Markers.Add(marker);
            }
        }

        private void AddToOverlay(string filename)
        {
            ImageWithData iwd = decode(filename);
            if (iwd.image == null)
                return;
            //Reject no - gps frames
            if (Math.Abs(iwd.data.targetLongitude) < 0.01)
                return;


            if (Math.Abs(iwd.data.planeLatitude) > 90.0 || Math.Abs(iwd.data.planeLongitude) > 180.0)
            {
                Console.WriteLine("Invalid coordinates");
                return;
            }
            //Add to general image collection
            lock (imageCollectionLock_)
            {
                imageCollection_.Add(iwd);
                //Update collection limits//
                if (timeRoiMin_ == 0) timeRoiMin_ = iwd.data.time;
                if (iwd.data.time < timeRoiMin_) timeRoiMin_ = iwd.data.time;
                if (iwd.data.time > timeRoiMax_) timeRoiMax_ = iwd.data.time;
            }
            //verify filters
            //Filter score
            Scores imageScore = new Scores(iwd.data.score);
            imageScore.score[2] = 1;
            imageScore.score[3] = 1;
            if ((imageScore > imageFilters_.scoreMin))
                return;
            if (iwd.data.time < imageFilters_.timeMin)
                return;
            if (imageFilters_.timeMax != -1)
            {
                //infinite rois
                if (iwd.data.time > imageFilters_.timeMax)
                    return;
            }
            GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(iwd.data.targetLatitude, iwd.data.targetLongitude), (Bitmap)iwd.image);
            //GMarkerGoogle markerTest = new GMarkerGoogle(new GMap.NET.PointLatLng(iwd.data.planeLatitude, iwd.data.planeLongitude), (Bitmap)iwd.image);
            marker.Offset = new Point(0, 0);
            unsafe
            {
                marker.Tag = new MarkerData(iwd.image.Size.Width, iwd.image.Size.Height, iwd.data.planeYaw, iwd.data.planeAltitude,
                    GetPixelDensity(iwd.data.planeAltitude), convertImageName(iwd.data.imageName));
            }
            lock (overlayImgLock_)
            {
                overlayImg_.Markers.Add(marker);
            }
        }

        //Gets density of pixels at given altitude
        public int GetPixelDensity(double altitude)
        {
            //Clip altitude to avoid errors on ground
            if (altitude < 0) altitude = 0;
            double avgResolution = (1936.0 + 1216) / 2;//pix
            if (viewAngle_ < 0)
            {
                double focalLength = 16;//mm
                double avgSensorDim = (12.454 + 9.83) / 2;//mm
                viewAngle_ = 2 * Math.Atan2(avgSensorDim, 2 * focalLength);
            }
            double projectedLength = Math.Tan(viewAngle_ / 2) * altitude * 2;
            return (int)Math.Round(avgResolution / projectedLength);
        }
        // Decoding jpeg files 
        // Added by KŁ 11.06.2016
        public struct ImageData
        {
            unsafe public fixed byte imageName[32];
            public UInt32 time;
            public UInt32 score;
            public float targetLatitude;
            public float targetLongitude;

            public float planeAltitude;
            public float planeLatitude;
            public float planeLongitude;
            public float planeYaw;
            // unsafe public fixed char imageName[60];
        }
        public struct ImageWithData
        {
            public Image image;

            public ImageData data;
        }
        public class Scores
        {
            public byte[] score;
            public Scores(uint scoreToDecode)
            {
                score = new byte[4];
                for (int i = 0; i < 4; ++i)
                {
                    score[i] = (byte)(0xFF & ((uint)scoreToDecode >> 8 * i));
                }
                int a = 5;
            }
            public Scores(byte[] scoreTable)
            {
                score = scoreTable;
            }
            public Scores(byte density, byte hue, byte hog, byte unknown)
            {
                byte[] scoreTable = new byte[4];
                scoreTable[0] = density;
                scoreTable[1] = hue;
                scoreTable[2] = hog;
                scoreTable[3] = unknown;

                score = scoreTable;
            }
            public static bool operator <=(Scores a, Scores b)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (a.score[i] >= b.score[i])
                        return false;
                }
                return true;
            }
            public static bool operator >=(Scores a, Scores b)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (a.score[i] <= b.score[i])
                        return false;
                }
                return true;
            }
            public static bool operator <(Scores a, Scores b)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (a.score[i] > b.score[i])
                        return true;
                }
                return false;
            }
            public static bool operator >(Scores a, Scores b)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (a.score[i] < b.score[i])
                        return true;
                }
                return false;
            }
        }


        private unsafe string convertImageName(byte* input)
        {
            byte[] resbyt = new byte[32];
            for (int i = 0; i < 32; i++) resbyt[i] = input[i];
            string result = System.Text.Encoding.ASCII.GetString(resbyt);
            //result = result.Replace("\0", string.Empty);
            string asAscii = Encoding.ASCII.GetString(
                Encoding.Convert(
                Encoding.UTF8,
                Encoding.GetEncoding(
                Encoding.ASCII.EncodingName,
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback()
            ),
            Encoding.UTF8.GetBytes(result)
                )
            );
            int start = asAscii.IndexOf("img_");
            int stop = asAscii.IndexOf(".bin");
            string name = asAscii.Substring(start, stop - start + ".bin".Length);

            return name;
        }
        public ImageWithData decode(string filename)
        {
            if (!filename.EndsWith(".jpg"))
                return new ImageWithData();
            ImageData dataStructure = new ImageData();
            byte[] bytes;
            try {
                bytes = System.IO.File.ReadAllBytes(filename);
            }
            catch
            {
                return new ImageWithData();
            }
            if (bytes.GetLength(0) == 0) return new ImageWithData();

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
            //DEcoding of image name, bad bad c#
            //byte[] resbyt = new byte[32];
            //unsafe
            //{
            //    for (int i = 0; i < 32; i++) resbyt[i] = dataStructure.imageName[i];
            //}

            //string result = System.Text.Encoding.ASCII.GetString(resbyt);
            iwd.image = Image.FromFile(filename);
            iwd.data = dataStructure;

            return iwd;
        }
        public string WorkingDir { get; set; }
        private double viewAngle_ = -1;

        public void LatLongtoUTM(double Lat, double Long,
            out double UTMNorthing, out double UTMEasting,
                out string Zone)
        {
            double deg2rad = Math.PI / 180.0;
            double a = 6378137; //WGS84
            double eccSquared = 0.00669438; //WGS84
            double k0 = 0.9996;

            double LongOrigin;
            double eccPrimeSquared;
            double N, T, C, A, M;

            //Make sure the longitude is between -180.00 .. 179.9
            double LongTemp = (Long + 180) - ((int)((Long + 180) / 360)) * 360 - 180; // -180.00 .. 179.9;

            double LatRad = Lat * deg2rad;
            double LongRad = LongTemp * deg2rad;
            double LongOriginRad;
            int ZoneNumber;

            ZoneNumber = ((int)((LongTemp + 180) / 6)) + 1;

            if (Lat >= 56.0 && Lat < 64.0 && LongTemp >= 3.0 && LongTemp < 12.0)
                ZoneNumber = 32;

            // Special zones for Svalbard
            if (Lat >= 72.0 && Lat < 84.0)
            {
                if (LongTemp >= 0.0 && LongTemp < 9.0) ZoneNumber = 31;
                else if (LongTemp >= 9.0 && LongTemp < 21.0) ZoneNumber = 33;
                else if (LongTemp >= 21.0 && LongTemp < 33.0) ZoneNumber = 35;
                else if (LongTemp >= 33.0 && LongTemp < 42.0) ZoneNumber = 37;
            }
            LongOrigin = (ZoneNumber - 1) * 6 - 180 + 3; //+3 puts origin in middle of zone
            LongOriginRad = LongOrigin * deg2rad;

            //compute the UTM Zone from the latitude and longitude
            Zone = ZoneNumber.ToString() + UTMLetterDesignator(Lat);

            eccPrimeSquared = (eccSquared) / (1 - eccSquared);

            N = a / Math.Sqrt(1 - eccSquared * Math.Sin(LatRad) * Math.Sin(LatRad));
            T = Math.Tan(LatRad) * Math.Tan(LatRad);
            C = eccPrimeSquared * Math.Cos(LatRad) * Math.Cos(LatRad);
            A = Math.Cos(LatRad) * (LongRad - LongOriginRad);

            M = a * ((1 - eccSquared / 4 - 3 * eccSquared * eccSquared / 64 - 5 * eccSquared * eccSquared * eccSquared / 256) * LatRad
            - (3 * eccSquared / 8 + 3 * eccSquared * eccSquared / 32 + 45 * eccSquared * eccSquared * eccSquared / 1024) * Math.Sin(2 * LatRad)
            + (15 * eccSquared * eccSquared / 256 + 45 * eccSquared * eccSquared * eccSquared / 1024) * Math.Sin(4 * LatRad)
            - (35 * eccSquared * eccSquared * eccSquared / 3072) * Math.Sin(6 * LatRad));

            UTMEasting = (double)(k0 * N * (A + (1 - T + C) * A * A * A / 6
            + (5 - 18 * T + T * T + 72 * C - 58 * eccPrimeSquared) * A * A * A * A * A / 120)
            + 500000.0);

            UTMNorthing = (double)(k0 * (M + N * Math.Tan(LatRad) * (A * A / 2 + (5 - T + 9 * C + 4 * C * C) * A * A * A * A / 24
            + (61 - 58 * T + T * T + 600 * C - 330 * eccPrimeSquared) * A * A * A * A * A * A / 720)));
            if (Lat < 0)
                UTMNorthing += 10000000.0; //10000000 meter offset for southern hemisphere
        }
        private char UTMLetterDesignator(double Lat)
        {
            char LetterDesignator;

            if ((84 >= Lat) && (Lat >= 72)) LetterDesignator = 'X';
            else if ((72 > Lat) && (Lat >= 64)) LetterDesignator = 'W';
            else if ((64 > Lat) && (Lat >= 56)) LetterDesignator = 'V';
            else if ((56 > Lat) && (Lat >= 48)) LetterDesignator = 'U';
            else if ((48 > Lat) && (Lat >= 40)) LetterDesignator = 'T';
            else if ((40 > Lat) && (Lat >= 32)) LetterDesignator = 'S';
            else if ((32 > Lat) && (Lat >= 24)) LetterDesignator = 'R';
            else if ((24 > Lat) && (Lat >= 16)) LetterDesignator = 'Q';
            else if ((16 > Lat) && (Lat >= 8)) LetterDesignator = 'P';
            else if ((8 > Lat) && (Lat >= 0)) LetterDesignator = 'N';
            else if ((0 > Lat) && (Lat >= -8)) LetterDesignator = 'M';
            else if ((-8 > Lat) && (Lat >= -16)) LetterDesignator = 'L';
            else if ((-16 > Lat) && (Lat >= -24)) LetterDesignator = 'K';
            else if ((-24 > Lat) && (Lat >= -32)) LetterDesignator = 'J';
            else if ((-32 > Lat) && (Lat >= -40)) LetterDesignator = 'H';
            else if ((-40 > Lat) && (Lat >= -48)) LetterDesignator = 'G';
            else if ((-48 > Lat) && (Lat >= -56)) LetterDesignator = 'F';
            else if ((-56 > Lat) && (Lat >= -64)) LetterDesignator = 'E';
            else if ((-64 > Lat) && (Lat >= -72)) LetterDesignator = 'D';
            else if ((-72 > Lat) && (Lat >= -80)) LetterDesignator = 'C';
            else LetterDesignator = 'Z'; //Latitude is outside the UTM limits
            return LetterDesignator;
        }

        Object overlayImgLock_ = new Object();
        GMapOverlay overlayImg_, overlayZoom_;
        GMapControl gmap_;
        Object imageCollectionLock_ = new Object();
        List<ImageWithData> imageCollection_;
        public MarkerFilters imageFilters_;
        public uint timeRoiMin_ = 0, timeRoiMax_ = 1;
        public Scores scoreRoiMin_ = new Scores(0);
    }

}

//Code for later development of custom overlay
//GMapPolygon polygon;
//List<PointLatLng> points = new List<PointLatLng>();
//points.Add(new PointLatLng(56.1865, 11.8129));
//points.Add(new PointLatLng(56.1865, 25.1576));
//points.Add(new PointLatLng(48.1334, 25.1576));
//points.Add(new PointLatLng(48.1334, 11.8129));
//polygon = new GMapPolygon(points, "mypolygon");
//GMapImage image = new GMapImage();
//Bitmap bmp = list[index].generateBitmap(new BourkyScale());
//polygon.Fill = new TextureBrush(bmp);
//polygon.Stroke = new Pen(Color.Red, 1);
//GMapOverlay polyOverlay = new GMapOverlay("polygons");
//gMapControl1.Overlays.Add(polyOverlay);
//polyOverlay.Polygons.Add(polygon);