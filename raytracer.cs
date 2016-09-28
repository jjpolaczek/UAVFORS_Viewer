using System;

namespace UAVFORS_Viewer
{
    class Raytracer
    {
        public CameraParams camPar;

       public Raytracer()
        {
            camPar.focalLength = 0.0036f;
            camPar.matrixWidth = 0.00376f;
            camPar.matrixHeight = 0.00274f;
            camPar.widthPixels = 2592;
            camPar.heightPixels = 1944;
        }
        public struct Quaternion
        {
            public double x;
            public double y;
            public double z;
            public double w;

            public Quaternion(double sx, double sy, double sz, double sw)
            {
                x = sx;
                y = sy;
                z = sz;
                w = sw;
            }

            public Quaternion(Vec3 axis, double angle)
            {
                double sinus = Math.Sin(angle / 2);

                x = axis.x * sinus;
                y = axis.y * sinus;
                z = axis.z * sinus;
                w = Math.Cos(angle / 2);
            }

            public Quaternion multiply(Quaternion multiplier)
            {
                Quaternion result;

                result.x = w * multiplier.x + x * multiplier.w + y * multiplier.z - z * multiplier.y;
                result.y = w * multiplier.y - x * multiplier.z + y * multiplier.w + z * multiplier.x;
                result.z = w * multiplier.z + x * multiplier.y - y * multiplier.x + z * multiplier.w;
                result.w = w * multiplier.w - x * multiplier.x - y * multiplier.y - z * multiplier.z;

                return result;
            }

            public Quaternion conjugate()
            {
                Quaternion q;

                q.w = w;
                q.x = -x;
                q.y = -y;
                q.z = -z;

                return q;
            }

        }

        public struct Vec3
        {
            public double x;
            public double y;
            public double z;

            public Vec3(double sx, double sy, double sz)
            {
                x = sx;
                y = sy;
                z = sz;
            }

            public Vec3 rotate(Vec3 axis, double angle)
            {
                Quaternion a = new Quaternion(x, y, z, 0);

                Quaternion b = new Quaternion(axis, angle);

                Quaternion b_conjugate = b.conjugate();

                Quaternion c = b.multiply(a);

                c = c.multiply(b_conjugate);

                return new Vec3(c.x, c.y, c.z);
            }

            public void normalize()
            {
                double invSize = 1 / Math.Sqrt(x * x + y * y + z * z);

                x = x * invSize;
                y = y * invSize;
                z = z * invSize;
            }

            public static Vec3 operator *(Vec3 a, double scalar)
            {
                Vec3 res;

                res.x = a.x * scalar;
                res.y = a.y * scalar;
                res.z = a.z * scalar;

                return res;
            }

            public static Vec3 operator +(Vec3 a, Vec3 b)
            {
                Vec3 res;

                res.x = a.x + b.x;
                res.y = a.y + b.y;
                res.z = a.z + b.z;

                return res;
            }


            public static Vec3 operator -(Vec3 a, Vec3 b)
            {
                Vec3 res;

                res.x = a.x - b.x;
                res.y = a.y - b.y;
                res.z = a.z - b.z;

                return res;
            }
        }

        public struct Pos
        {
            public double lattitude;
            public double longtitude;

            public Pos(double x, double y)
            {
                lattitude = x;
                longtitude = y;
            }
        }

        public struct CameraParams
        {
            public float focalLength;
            public float matrixWidth;
            public float matrixHeight;

            public int widthPixels;
            public int heightPixels;
        }
        
        public static double toRadian(double degree)
        {
            return ((2 * 3.14) / 360) * degree;
        }

        public static double DotProduct(Vec3 a, Vec3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Pos Raycast(int pointOnImageX, int pointOnImageY, CameraParams camPar, ImageData imgData)
        {
            double longtitude = imgData.longitude;
            double latitude = imgData.latitude;
            double altitude = imgData.altitude;

            double yaw = -imgData.yaw;                                     // Cause z is down 
            double pitch = imgData.pitch; 
            double roll = imgData.roll; 

            Vec3 cameraOrigin = new Vec3(0, 0, altitude);

            Vec3 vectorForward = new Vec3(0, 1, 0);
            Vec3 vectorUp = new Vec3(0, 0, 1);
            Vec3 vectorRight = new Vec3(1, 0, 0);

            // Yaw rotation first ,  up vector do not revolve
            vectorForward.rotate(vectorUp, yaw);
            vectorRight.rotate(vectorUp, yaw);

            // Next is pitch rotation trough right vector
            vectorForward.rotate(vectorRight, pitch);
            vectorUp.rotate(vectorRight, pitch);

            // Last is roll rotation trough front vector
            vectorUp.rotate(vectorForward, roll);
            vectorRight.rotate(vectorForward, roll);

            vectorForward.normalize();
            vectorUp.normalize();
            vectorRight.normalize();

            pointOnImageY = camPar.heightPixels - pointOnImageY;                // Left upper corner is (0,0) , recalculating Y

            Vec3 pointCameraCenter;

            pointCameraCenter = cameraOrigin + vectorForward * camPar.focalLength;

            double xScaled = ((double)pointOnImageX / (double)camPar.widthPixels) * 2 - 1;
            double yScaled = ((double)pointOnImageY / (double)camPar.heightPixels) * 2 - 1;

            Vec3 pointOnCameraScreen = pointCameraCenter + vectorUp * 0.5 * camPar.matrixHeight * yScaled + vectorRight * 0.5 * camPar.matrixWidth * xScaled;

            Vec3 planeOrigin = new Vec3(0, 0, 0);
            Vec3 planeNormal = new Vec3(0, 0, 1);

            Vec3 rayOrigin = cameraOrigin;
            Vec3 rayDirection = pointOnCameraScreen - rayOrigin;
            rayDirection.normalize();

            if(Math.Abs(DotProduct(rayDirection, planeNormal)) < 0.00001)
            {
                return new Pos(0, 0);
            }

            double distance = DotProduct(planeOrigin - cameraOrigin, planeNormal) /
            DotProduct(rayDirection, planeNormal);

            Vec3 pointOnPlane;

            if (distance < 0.00001)
            {
                return new Pos(0, 0);
            }

            pointOnPlane = rayOrigin + rayDirection * distance;

            pointOnPlane.y = (pointOnPlane.y) / (111196.672);
	        pointOnPlane.x = (pointOnPlane.x) / (111196.672 * Math.Abs(Math.Cos(toRadian(latitude))));

            Vec3 GlobalPoint;

	        GlobalPoint.x = pointOnPlane.x + longtitude;
	        GlobalPoint.y = pointOnPlane.y + latitude;

            return new Pos(pointOnPlane.y, pointOnPlane.x);
        }
    }
}