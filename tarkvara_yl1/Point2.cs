using System;
using System.Collections.Generic;
using System.Text;

namespace tarkvara_yl1
{
    public class Point2
    {
        private double _rho;
        private double _theta;
        private double _x;
        private double _y;

        public Point2(double x, double y)
        {
            _x = x;
            _y = y;
            _rho = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            _theta = Math.Atan2(x, y);

        }
        public double X()
        {
            return Rho() * Math.Cos(Theta());
        }
        
        public double Y()
        {
            return Rho() * Math.Sin(Theta());
        }

        public double Rho()
        {
            return _rho;
        }

        public double Theta()
        {
            return _theta;
        }


        public Point VectorTo(Point p2)
        {
            //VectorTo(other)
            //PRE: other !=null
            //POST: Result.x() = other.X() - X()
            //      Result.y() = other.Y() - Y()
            return new Point(p2.GetX() - X(), p2.GetY() - Y());
        }

        public double Distance(Point p2)
        {
            // Distance(other)
            // PRE: other != null
            // POST: Result = VectorTo(other).GetRho();
            return VectorTo(p2).GetRho();
        }

        public void Translate(double dx, double dy)
        {
            //PRE: -
            //POST:
            //x == old x + dx(viitab vanale väärtusele)
            //y == old y + dy
            _x += X() + dx;
            _y += Y() + dy;
            _rho = Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            _theta = Math.Atan2(_x, _y);
        }

        public void Scale(double factor)
        {
            //PRE: angle != null
            //POST: GetRho() = old GetRho()* factor
            _rho *= factor;
        }

        public void CentreRotate(double angle)
        {
            //PRE - 
            //POST: GetTheta = old GetTheta() + angle % (2*PI)
            _theta = (_theta + angle) % (2 * Math.PI);

        }

        public void Rotate(Point2 p, double angle)
        {
            //PRE: P != null
            //POST: p.VectorTo(this).GetTheta() = (p.VectorTo(old this).GetTheta() + angle) % (2*PI)
            Translate(-p.X(), -(p.Y()));
            CentreRotate(angle);
            Translate(p.X(), p.Y());
        }

    }
}
