using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(XmlNode node)
        {
            XmlNode nx = node.SelectSingleNode("./x");
            XmlNode ny = node.SelectSingleNode("./y");
            XmlNode nz = node.SelectSingleNode("./z");

            X = double.Parse(nx.InnerText.Replace(".", ","));
            Y = double.Parse(ny.InnerText.Replace(".", ","));
            Z = double.Parse(nz.InnerText.Replace(".", ","));
        }

        public bool Equals(Point3D p2)
        {
            return this.X == p2.X && this.Y == p2.Y && this.Z == p2.Z;
        }

        public Point3D Multiply(double multiplier)
        {
            Point3D p = new Point3D(X, Y, Z);
            p.X *= multiplier;
            p.Y *= multiplier;
            p.Z *= multiplier;
            return p;
        }

        public override string ToString()
        {
            return X.ToString() + "," + Y.ToString() + "," + Z.ToString();
        }

    }
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2D(XmlNode node)
        {
            XmlNode nx = node.SelectSingleNode("./x");
            XmlNode ny = node.SelectSingleNode("./y");

            X = double.Parse(nx.InnerText.Replace(".", ","));
            Y = double.Parse(ny.InnerText.Replace(".", ","));
        }

        public bool Equals(Point2D p2)
        {
            return this.X == p2.X && this.Y == p2.Y;
        }

        public Point2D Multiply(double multiplier)
        {
            Point2D p = new Point2D(X, Y);
            p.X *= multiplier;
            p.Y *= multiplier;
            return p;
        }

        public override string ToString()
        {
            return X.ToString() + "," + Y.ToString();
        }

    }

}
