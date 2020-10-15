using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
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
        private Route _testRoute;
        private List<Point> _routePoints;
        [TestInitialize]
        public void TestInitialize()
        {
            _p = new Point(2, 4);
            _p2 = new Point(4, 6);
            _p3 = new Point(6, 8);
            _testRoute = new Route();
            _routePoints = _testRoute.GetList();

        }

        [TestMethod]
        public void CreateRouteTest()
        {
            TestInitialize();
            Assert.AreEqual(0, _testRoute.GetRouteCount());
            Assert.AreEqual(0,_testRoute.GetLength());
        }
        [TestMethod]
        public void AddPointTest()
        {
            int previousCount = _testRoute.GetRouteCount();
            _testRoute.AddPoint(_p.GetX(), _p.GetY(), 0);
            Assert.AreEqual(previousCount + 1, _testRoute.GetRouteCount());
            Assert.AreEqual(_routePoints[0].GetX(), _p.GetX());
            Assert.AreEqual(_routePoints[0].GetY(), _p.GetY());


        }
        [TestMethod]
        public void RemovePointTest()
        {
            _testRoute.AddPoint(_p.GetX(),_p.GetY(), 0);
            _testRoute.AddPoint(_p2.GetX(), _p2.GetY(), 1);
            int previousCount = _testRoute.GetRouteCount();
            _testRoute.RemovePoint(0);
            int afterCount = _testRoute.GetRouteCount();
            Assert.AreEqual(previousCount - 1, afterCount);
            Assert.AreNotEqual(_routePoints[0].GetX(), _p.GetX());
            Assert.AreNotEqual(_routePoints[0].GetY(), _p.GetY());
        }
        [TestMethod]
        public void IsSuitableIndexTest()
        {
            int count = _testRoute.GetRouteCount();
            bool expectFalse = _testRoute.IsSuitableIndex(count + 1);
            bool expectTrue = _testRoute.IsSuitableIndex(count);
            Assert.AreEqual(false, expectFalse);
            Assert.AreEqual(true, expectTrue);
        }

        [TestMethod]
        public void GetLengthTest()
        {
            _testRoute.AddPoint(_p.GetX(), _p.GetY(), 0);
            _testRoute.AddPoint(_p2.GetX(), _p2.GetY(), 1);
            _testRoute.AddPoint(_p3.GetX(), _p3.GetY(), 2);
            double distance = _testRoute.GetLength();
            Assert.AreEqual(Math.Sqrt(8)*2, distance);

        }

    }
}
