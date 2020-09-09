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

        public double GetDistance( Point p2)
        {
            return Math.Sqrt(Math.Pow(GetX() - p2.GetX(), GetY() - p2.GetY()));
        }

        public Point VectorTo(Point p2)
        {
            return new Point(p2.GetX() - GetX(), p2.GetY() - GetY());
        }
        public double Distance( Point p2)
        {
            return VectorTo(p2).GetRho();
        }

        public void Translate(double dx, double dy)
        {
            x1 += dx;
            y1 += dy;
        }

        public void Scale(double factor)
        {
            x1 *= factor;
            y1 *= factor;
        }

        public void CentreRotate(double angle)
        {
            double tempx = GetRho() * Math.Cos(GetTheta() + angle);
            double tempy = GetRho() * Math.Sin(GetTheta() + angle);
            x1 = tempx;
            y1 = tempy;
           
        }

        public void Rotate(Point p, double angle)
        {
            Translate(-(p.x1), -(p.y1));
            CentreRotate( angle);
            Translate(p.x1,p.y1);
        }
    }

}
