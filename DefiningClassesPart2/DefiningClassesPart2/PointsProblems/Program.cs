using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        public struct Point3D
        {
            private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

            public Point3D(int pointX, int pointY, int pointZ)
                : this()
            {
                this.X = pointX;
                this.Y = pointY;
                this.Z = pointZ;
            }

            public Point3D ZeroPoint
            {
                get { return zeroPoint; }
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public override string ToString()
            {
                return string.Format("Point: {0} {1} {2}", this.X, this.Y, this.Z);
            }
        }

        public static class DistanceBetweenTwoPoints
        {
            static int xDinstance;
            static int yDinstance;
            static int zDinstance;
            static double distance;

            public static double CalculatingDistance(Point3D firstPoint, Point3D secondPoint)
            {
                xDinstance = firstPoint.X - secondPoint.X;
                yDinstance = firstPoint.Y - secondPoint.Y;
                zDinstance = firstPoint.Z - secondPoint.Z;

                distance = Math.Sqrt(Math.Pow(xDinstance, 2) + Math.Pow(yDinstance, 2) + Math.Pow(zDinstance, 2));

                return distance;
            }
        }

        public static class Path
        {
            static private List<Point3D> points = new List<Point3D>();

            public static void Adding(Point3D point)
            {
                points.Add(point);
            }
        }

        static class PathStorage
        {
            public static void SaveFile(List<Point3D> points)
            {
                StreamWriter file = new StreamWriter(@"\..\..file.txt");

                using (file)
                {
                    foreach (var point in points)
                    {
                        file.WriteLine("X -> {0}, y -> {1}, z -> {2}", point.X, point.Y, point.Z);
                    }
                }
            }

            public static string ReadFile(string filePath)
            {
                StringBuilder result = new StringBuilder();
                StreamReader path = new StreamReader(filePath);
                using (path)
                {
                    result.Append(path.ReadToEnd());
                }

                return result.ToString();
            }
        }

        static void Main(string[] args)
        {
            //Checking if the print works good
            Point3D point = new Point3D();
            point.X = 5;
            point.Y = 10;
            point.Z = 15;
            Console.WriteLine(point);

            //Calculating dinstance between two points
            Point3D firstPoint = new Point3D(5, 8, 123);
            Point3D secondPoint = new Point3D(12, 21, 51);
            Console.WriteLine( DistanceBetweenTwoPoints.CalculatingDistance(firstPoint, secondPoint));

            //Zero point
            Console.WriteLine(point.ZeroPoint);
        }
    }
}
