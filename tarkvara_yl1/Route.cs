using System.Collections.Generic;

namespace tarkvara_yl1
{
    public class Route
    {
        private readonly List<Point> RoutePoints;
        private double _distance;
        public Route()
        {
            //Eeltingimused: -
            //Järeltingimused: On tekitatud uus tühi  marsruut, mis on määratud töös olevaks marsruudiks

            RoutePoints = new List<Point>();
        }


        public bool IsSuitableIndex(int index)
        {
            return 0 <= index && index <= RoutePoints.Count;
        }
        public void AddPoint(double x, double y, int index)
        {
            //Eeltingimused: 0 <= indeks <= töös oleva marsruudi elementide arv
            //Järeltingimused: Marsruuti on positsioonile indeks  lisatud uus punkt koordinaatidega x, y.Töös oleva marsruudi elementide arv on suurenenud ühe võrra.
            if (IsSuitableIndex(index))
            {
                RoutePoints.Insert(index, new Point(x, y));
            }
        }

        public void RemovePoint(int index)
        {
            if (IsSuitableIndex(index))
            {
                RoutePoints.RemoveAt(index);
            }   
        }

        public double GetLength()
        {
            //Eeltingimused: -
            //Järeltingimused:
            //Kui töös oleva marsruudi elementide(e0, …, en - 1) arv n on suurem kui üks, siis

            //Tulem =∑_(i = 0) ^ (n - 2)▒〖dist(e_i, e_(i + 1))〗   

            //    , kus dist on kahe elemendi vaheline kaugus.

            //    Kui töös oleva marsruudi elementide arv n on väiksem või võrdne ühega, siis
            //Tulem = 0.
            _distance = 0;
            if (RoutePoints.Count <= 1) return _distance;
            for (int i = 0; i < RoutePoints.Count - 1; i++)
            {
                _distance += RoutePoints[i].Distance(RoutePoints[i + 1]);
            }

            return _distance;
        }

        public int GetRouteCount()
        {
            return RoutePoints.Count;
        }

        public List<Point> GetList()
        {
            return RoutePoints;
        }
    }
}
