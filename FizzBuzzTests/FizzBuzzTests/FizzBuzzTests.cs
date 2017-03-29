using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzApplication;

namespace FizzBuzzTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        // Create FizzBuzz object with default constructor
        FizzBuzz fb1 = new FizzBuzz();

        // Create FizzBuzz object with args
        FizzBuzz fb2 = new FizzBuzz(1, 20);


        [TestMethod]
        public void fb1IsFizzBuzzObject()
        {
            Assert.IsInstanceOfType(fb1, typeof(FizzBuzz));
        }

        [TestMethod]
        public void fb1InitialProperties()
        {
            Assert.AreEqual(fb1.startNumber, 0);
            Assert.AreEqual(fb1.endNumber, 0);
        }

        [TestMethod]
        public void fb1SetRange()
        {
            fb1.SetRange(10, 50);
            Assert.AreEqual(fb1.startNumber, 10);
            Assert.AreEqual(fb1.endNumber, 50);
        }

        [TestMethod]
        public void fb2IsFizzBuzzObject()
        {
            Assert.IsInstanceOfType(fb2, typeof(FizzBuzz));
        }

        [TestMethod]
        public void fb2InitialProperties()
        {
            Assert.AreEqual(fb2.startNumber, 1);
            Assert.AreEqual(fb2.endNumber, 20);
        }

        [TestMethod]
        public void fb2Output()
        {
            Assert.AreEqual(fb2.getOutput(), "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz");
        }
    }
}
