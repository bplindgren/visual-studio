using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzApplication;

namespace FizzBuzzTwoTests {
    [TestClass]
    public class FizzBuzzTwoTests {
        // Create FizzBuzzTwo object with default constructor
        FizzBuzzTwo fb1 = new FizzBuzzTwo();

        // Create FizzBuzzTwo object with args
        FizzBuzzTwo fb2 = new FizzBuzzTwo(1, 20);

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
            Assert.IsInstanceOfType(fb2, typeof(FizzBuzzTwo));
        }

        [TestMethod]
        public void fb2InitialProperties() {
            Assert.AreEqual(fb2.startNumber, 1);
            Assert.AreEqual(fb2.endNumber, 20);
            Assert.AreEqual(fb2.result, "");
        }

        [TestMethod]
        public void fb1Output() {
            Assert.AreEqual(fb1.GetOutput(), "fizzbuzz");
        }

        [TestMethod]
        public void fb2Output20() {
            Assert.AreEqual(fb2.GetOutput(), "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz");
            Assert.AreEqual(fb2.GetReport(), "fizz: 4 \nbuzz: 3 \nfizzbuzz: 1 \nlucky: 2 \ninteger: 10");
        }

        [TestMethod]
        public void fb2Output100() {
            fb2.SetRange(1, 100);
            Assert.AreEqual(fb2.GetOutput(), "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz fizz 22 lucky fizz buzz 26 fizz 28 29 lucky lucky lucky lucky lucky lucky lucky lucky lucky lucky buzz 41 fizz lucky 44 fizzbuzz 46 47 fizz 49 buzz fizz 52 lucky fizz buzz 56 fizz 58 59 fizzbuzz 61 62 lucky 64 buzz fizz 67 68 fizz buzz 71 fizz lucky 74 fizzbuzz 76 77 fizz 79 buzz fizz 82 lucky fizz buzz 86 fizz 88 89 fizzbuzz 91 92 lucky 94 buzz fizz 97 98 fizz buzz");
            Assert.AreEqual(fb2.GetReport(), "fizz: 21 \nbuzz: 13 \nfizzbuzz: 5 \nlucky: 19 \ninteger: 42");
        }
    }
}
