using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace tarkvara_yl1
{
    public class Point
    {
        private double x1;
        private double y1;

        public Point(double x, double y)
        {
            x1 = x;
            y1 = y;
                
        }
        public double GetX()
        {
            return x1;
        }
        public void SetX(double x)
        {
            x1 = x;
        }
        public double GetY()
        {
            return y1;
        }
        public void SetY(double y)
        {
            y1 = y;
        }

        public double GetRho()
        {
            return Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
        }

        public double GetTheta()
        {
            return Math.Atan2(y1, x1);

        }

        public double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.GetX() - p2.GetX(), p1.GetY() - p2.GetY()));
        }

        public Point VectorTo(Point p1, Point p2)
        {
            return new Point(p2.GetX() - p1.GetX(), p2.GetY() - p1.GetY());
        }

        public double Distance(Point p1, Point p2)
        {
            return p1.VectorTo(p1, p2).GetRho();
        }

        public void Translate(Point p1, double dx, double dy)
        {
            p1.x1 += dx;
            p1.y1 += dy;
        }

        public void Scale(Point p1, double factor)
        {
            p1.x1 *= factor;
            p1.y1 *= factor;
        }

        public Point CentreRotate(Point p1, double angle)
        {
            double tempx = p1.GetRho() * Math.Cos(p1.GetTheta() + angle);
            double tempy = p1.GetRho() * Math.Sin(p1.GetTheta() + angle);
            p1.x1 = tempx;
            p1.y1 = tempy;
            return p1;
        }

        public void Rotate(Point p, double angle)
        {
            p.Translate(p,-(p.x1), -(p.y1));
            p.CentreRotate(p, angle);
            p.Translate(p,p.x1,p.y1);
                

        }
    }

}
