using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzApplication;

namespace FizzBuzzTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        FizzBuzz fb = new FizzBuzz();

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(fb.sayTrue());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsFalse(fb.sayFalse());
        }
    }
}
