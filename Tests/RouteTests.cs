using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tarkvara_yl1;

namespace Tests
{
    [TestClass]
    public class RouteTests
    {
        private Point _p;
        private Point _p2;
        private Point _p3;
        private List<Point> _routePoints;
        [TestInitialize]
        public void TestInitialize()
        {
            _p = new Point(10, 20);
            _p2 = new Point(-20, 60);
            _p3 = new Point(-60, 100);
            _routePoints = new List<Point>(){_p, _p2, _p3};
        }
        [TestMethod]
        public void AddPointTest()
        {
           
        }
        [TestMethod]
        public void RemovePointTest()
        {

        }
        [TestMethod]
    }
}
