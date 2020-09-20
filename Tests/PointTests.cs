using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using tarkvara_yl1;

namespace Tests
{
    [TestClass]
    public class PointTests
    {
        private Point _p;
        private Point _p2;
        [TestInitialize]
        public void TestInitialize()
        {
            _p = new Point(10, 20);
            _p2 = new Point(-20, 60);
        }

        [TestMethod]
        public void GetXTest()
        {
            double expected = 20;
            _p.SetX(expected);
            double actual = _p.GetX();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetXTest()
        {
            double expected = 20;
            _p.SetX(expected);
            double actual = _p.GetX();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetYTest()
        {
            double expected = 20;
            _p.SetY(expected);
            double actual = _p.GetY();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetYTest()
        {
            double expected = 20;
            _p.SetY(expected);
            double actual = _p.GetY();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRhoTest()
        {
            double expected = _p.GetRho();
            double actual = Math.Sqrt(Math.Pow(_p.GetX(), 2) + Math.Pow(_p.GetY(), 2));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetThetaTest()
        {
            double expected = _p.GetTheta();
            double actual = Math.Atan2(_p.GetY(), _p.GetX());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VectorToTest()
        {
            Point expected = _p.VectorTo(_p2);
            Point actual = new Point(_p2.GetX()-_p.GetX(),_p2.GetY() - _p.GetY());
            Assert.AreEqual(expected.GetX(), actual.GetX());
            Assert.AreEqual(expected.GetY(), actual.GetY());
        }

        [TestMethod]
        public void DistanceTest()
        {
            double expected = _p.Distance(_p2);
            double actual = _p.VectorTo(_p2).GetRho();
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ScaleTest()
        {
            Point expected = new Point(20, 50);
            expected.Scale(2);
            Assert.AreEqual(expected.GetX(), 40);
            Assert.AreEqual(expected.GetY(), 100);

        }
        [TestMethod]
        public void TranslateTest()
        {
            double x = _p.GetX();
            double y = _p.GetY();
            double dx = 15;
            double dy = 10;
            _p.Translate(dx, dy);
            Point expected = new Point(x +dx, y+dy);
            Assert.AreEqual(expected.GetX(), _p.GetX());
            Assert.AreEqual(expected.GetY(), _p.GetY());
        }
        [TestMethod]
        public void CentreRotateTest()
        {
            double angle = Math.PI / 3;

            double x = _p.GetRho() * Math.Cos(_p.GetTheta() + angle);
            double y = _p.GetRho() * Math.Sin(_p.GetTheta() + angle);
            _p.CentreRotate(angle);
            Assert.AreEqual(x, _p.GetX());
            Assert.AreEqual(y,_p.GetY());
        }
        [TestMethod]
        public void RotateTest()
        { 
            double angle = Math.PI / 3;
            var before = _p.VectorTo(_p2).GetTheta();


        }
       
    }
}
