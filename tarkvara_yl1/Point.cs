using System;


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
            //VectorTo(other)
            //PRE: other !=null
            //POST: Result.x() = other.X() - X()
            //      Result.y() = other.Y() - Y()
            return new Point(p2.GetX() - GetX(), p2.GetY() - GetY());
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
            x1 += dx;
            y1 += dy;
            
        }

        public void Scale(double factor)
        {
            //PRE: angle != null
            //POST: GetRho() = old GetRho()* factor
            x1 *= factor;
            y1 *= factor;
        }

        public void CentreRotate(double angle)
        {
            //PRE - 
            //POST: GetTheta = old GetTheta() + angle % (2*PI)
            double tempx = GetRho() * Math.Cos(GetTheta() + angle);
            double tempy = GetRho() * Math.Sin(GetTheta() + angle);
            x1 = tempx;
            y1 = tempy;
           
        }

        public void Rotate(Point p, double angle)
        {
            //PRE: P != null
            //POST: p.VectorTo(this).GetTheta() = (p.VectorTo(old this).GetTheta() + angle) % (2*PI)
            Translate(-(p.x1), -(p.y1));
            CentreRotate( angle);
            Translate(p.x1,p.y1);
        }
    }

}
