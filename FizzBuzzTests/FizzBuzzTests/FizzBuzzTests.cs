using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzApplication;

namespace FizzBuzzTests
{
    [TestClass]
    public class FizzBuzzTests {
        // Create FizzBuzz object with default constructor
        FizzBuzz fb1 = new FizzBuzz();

        // Create FizzBuzz object with args
        FizzBuzz fb2 = new FizzBuzz(1, 20);


        [TestMethod]
        public void fb1IsFizzBuzzObject() {
            Assert.IsInstanceOfType(fb1, typeof(FizzBuzz));
        }

        [TestMethod]
        public void fb1InitialProperties() {
            Assert.AreEqual(fb1.startNumber, 0);
            Assert.AreEqual(fb1.endNumber, 0);
            Assert.AreEqual(fb1.result, "");
        }

        [TestMethod]
        public void fb1SetRange() {
            fb1.SetRange(10, 50);
            Assert.AreEqual(fb1.startNumber, 10);
            Assert.AreEqual(fb1.endNumber, 50);
        }

        [TestMethod]
        public void fb2IsFizzBuzzObject() {
            Assert.IsInstanceOfType(fb2, typeof(FizzBuzz));
        }

        [TestMethod]
        public void fb2InitialProperties() {
            Assert.AreEqual(fb2.startNumber, 1);
            Assert.AreEqual(fb2.endNumber, 20);
            Assert.AreEqual(fb2.result, "");
        }

        [TestMethod]
        public void fb1Output() {
            Assert.AreEqual(fb1.getOutput(), "fizzbuzz");
        }

        [TestMethod]
        public void fb2Output20() {
            Assert.AreEqual(fb2.getOutput(), "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz");
        }

        [TestMethod]
        public void fb2Output100() {
            fb2.SetRange(1, 100);
            Assert.AreEqual(fb2.getOutput(), "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz fizz 22 23 fizz buzz 26 fizz 28 29 fizzbuzz 31 32 fizz 34 buzz fizz 37 38 fizz buzz 41 fizz 43 44 fizzbuzz 46 47 fizz 49 buzz fizz 52 53 fizz buzz 56 fizz 58 59 fizzbuzz 61 62 fizz 64 buzz fizz 67 68 fizz buzz 71 fizz 73 74 fizzbuzz 76 77 fizz 79 buzz fizz 82 83 fizz buzz 86 fizz 88 89 fizzbuzz 91 92 fizz 94 buzz fizz 97 98 fizz buzz");
        }
    }
}
