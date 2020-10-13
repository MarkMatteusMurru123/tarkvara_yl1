using System;

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
        //INVARIANT: 0 <= theta <= 360
        public bool InvariantCheck()
        {
            if (_theta >= 0 && _theta <= 2* Math.PI)
            {
                return true;
            }

            return false;
        }
        public double X() => _rho * Math.Cos(_theta);

        // PRE: -
        // POST: result.x = rho * math.cos(_theta)

        public double Y() => _rho * Math.Sin(_theta);

        // PRE: -
        // POST: result.y = rho * math.sin(_theta)

        public double Rho()
        {
            // PRE: -
            // POST: result._rho

            _rho = Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            return _rho;
        }

        public double Theta()
        {
            // PRE: 0 <= theta <= 360
            // POST: result._theta

            _theta = Math.Atan2(_y, _x);
            if (InvariantCheck()) return _theta;
            _theta += 2 * Math.PI;
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
            return VectorTo(p2)._rho;
        }

        public void Translate(double dx, double dy)
        {
            //PRE: -
            //POST:
            //x == old x + dx(viitab vanale väärtusele)
            //y == old y + dy
            _x = X() + dx;
            _y = Y() + dy;
            Theta();
            Rho();
        }

        public void Scale(double factor)
        {
            //PRE: angle != null
            //POST: GetRho() = old GetRho()* factor
            _rho *= factor;
        }

        public void CentreRotate(double angle)
        {
            //PRE not(x==0 and y == 0)
            //POST: GetTheta = old GetTheta() + angle % (2*PI)
            _theta = (_theta + angle) % (2 * Math.PI);

        }

        public void Rotate(Point2 p, double angle)
        {
            //PRE: not(x == p.x and y == p.y)
            //POST: p.VectorTo(this).GetTheta() = (p.VectorTo(old this).GetTheta() + angle) % (2*PI)
            if (_x == p._x && _y == p._y)
            {
                
            }
            else
            {
                Translate(-p._x, -p._y);
                CentreRotate(angle);
                Translate(p._x, p._y);
            }
        }

    }
}
