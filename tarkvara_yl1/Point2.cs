using System;
using System.Collections.Generic;
using System.Text;

namespace tarkvara_yl1
{
    public class Point2
    {
        public double _rho;
        public double _theta;
        public double _x;
        public double _y;

        public Point2(double x, double y)
        {
            _x = x;
            _y = y;
            Rho();
            Theta();

        }

        public double X() => _x = _rho * Math.Cos(_theta);
        
        
        public double Y()
        {
            _y = _rho * Math.Sin(_theta);
            return _y;
        }

        public double Rho()
        {
            _rho = Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            return _rho;
        }

        public double Theta()
        {
            _theta = Math.Atan2(_y, _x);
            return _theta;
        }


        public Point2 VectorTo(Point2 p2)
        {
            //VectorTo(other)
            //PRE: other !=null
            //POST: Result.x() = other.X() - X()
            //      Result.y() = other.Y() - Y()
            return new Point2(p2.X() - X(), p2.Y() - Y());
        }

        public double Distance(Point2 p2)
        {
            // Distance(other)
            // PRE: other != null
            // POST: Result = VectorTo(other).GetRho();
            return VectorTo(p2).Rho();
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
