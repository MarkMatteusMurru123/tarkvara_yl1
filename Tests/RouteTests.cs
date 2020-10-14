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
        private Route _testRoute;
        [TestInitialize]
        public void TestInitialize()
        {
            _p = new Point(10, 20);
            _p2 = new Point(-20, 60);
            _p3 = new Point(-60, 100);
            _testRoute = new Route();
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
            _testRoute.AddPoint(20, 30, 3);
            Assert.AreEqual(previousCount + 1, _testRoute.GetRouteCount());
            _testRoute.AddPoint(10, 15, 2);

        }
        [TestMethod]
        public void RemovePointTest()
        {

        }
        [TestMethod]
    }
}
