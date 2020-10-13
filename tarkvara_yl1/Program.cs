using System;

namespace tarkvara_yl1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 20);
            Point p2 = new Point(-20, 60);
            double distance = p1.Distance(p2);
            Console.WriteLine("1. yl vastus on : {0}", distance);
            Point p3 = new Point(15, 0);
            p3.CentreRotate(Math.PI / 3);
            Console.WriteLine("2. yl vastus on : {0}, {1}", p3.GetRho(), p3.GetTheta());

        }

    }
}
