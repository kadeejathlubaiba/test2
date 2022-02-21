using MainProject.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Testmethods
{
    class MathBlTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindSum()
        {
           
            var Bl = new MathBl();
            int result = Bl.FindSum(12, 5);
            Assert.IsTrue(result == 17);
        }

        [Test]
        public void TestFindProduct()
        {
            Assert.Pass();
        }
    }

}
