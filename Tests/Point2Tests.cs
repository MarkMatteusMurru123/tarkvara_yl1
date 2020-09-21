﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tarkvara_yl1;

namespace Tests
{
    [TestClass]
    public class Point2Tests
    {
        private Point2 _p;
        private Point2 _p2;
        [TestInitialize]
        public void TestInitialize()
        {
            _p = new Point2(10, 20);
            _p2 = new Point2(-20, 60);
        }

        [TestMethod]
        public void XTest()
        {
            var result = _p._x;
            var expected = _p.X();
            Assert.AreEqual(expected, result, 0.00001);
        }
        [TestMethod]
        public void YTest()
        {
            var result = _p._y;
            var expected = _p.Y();
            Assert.AreEqual(expected, result, 0.00001);
        }
        [TestMethod]
        
        public void GetRhoTest()
        {
            double expected = _p.Rho();
            double actual = Math.Sqrt(Math.Pow(_p.X(), 2) + Math.Pow(_p.Y(), 2));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetThetaTest()
        {
            double expected = _p.Theta();
            double actual = Math.Atan2(_p.Y(), _p.X());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VectorToTest()
        {
            Point2 expected = _p.VectorTo(_p2);
            Point2 actual = new Point2(_p2.X() - _p.X(), _p2.Y() - _p.Y());
            Assert.AreEqual(expected.X(), actual.X());
            Assert.AreEqual(expected.Y(), actual.Y());
            Assert.AreEqual(expected._rho, actual._rho);
            Assert.AreEqual(expected._theta, actual._theta);

        }

        [TestMethod]
        public void DistanceTest()
        {
            double expected = _p.Distance(_p2);
            double actual = _p.VectorTo(_p2).Rho();
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ScaleTest()
        {
            Point2 expected = new Point2(20, 50);
            expected.Scale(2);
            Assert.AreEqual(expected.X(), 40, 0.0000001);
            Assert.AreEqual(expected.Y(), 100,0.0000001);

        }
        [TestMethod]
        public void TranslateTest()
        {
            double x = _p.X();
            double y = _p.Y();
            double dx = 15;
            double dy = 10;
            _p.Translate(dx, dy);
            Point2 expected = new Point2(x + dx, y + dy);
            Assert.AreEqual(expected.X(), _p.X());
            Assert.AreEqual(expected.Y(), _p.Y());
        }
        [TestMethod]
        public void CentreRotateTest()
        {
            double angle = Math.PI / 3;

            double x = _p.Rho() * Math.Cos(_p.Theta() + angle);
            double y = _p.Rho() * Math.Sin(_p.Theta() + angle);
            _p.CentreRotate(angle);
            Assert.AreEqual(x, _p.X());
            Assert.AreEqual(y, _p.Y());
        }
        [TestMethod]
        public void RotateTest()
        {
            double angle = Math.PI / 3;
            var before = _p.VectorTo(_p2).Theta();


        }

    }
}
