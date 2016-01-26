using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stumblr;

namespace UnitTests
{
    [TestClass]
    public class SwapTests
    {
        [TestMethod]
        public void SwapInts()
        {
            var a = 1;
            var b = 2;

            GenericTools.Swap(ref a, ref b);

            Assert.AreEqual(2, a);
            Assert.AreEqual(1, b);
        }

        [TestMethod]
        public void SwapStrings()
        {

            var a = "asdf";
            var b = "qwert";

            GenericTools.Swap(ref a, ref b);

            Assert.AreEqual("qwert", a);
            Assert.AreEqual("asdf", b);
        }

        [TestMethod]
        public void SwapObjects()
        {
            var a = new Tester { Test = 1 };
            var b = new Tester { Test = 2 };
            GenericTools.Swap(ref a, ref b);

            Assert.AreEqual(2, a.Test);
            Assert.AreEqual(1, b.Test);
        }

        [TestMethod]
        public void DoesNotCompile()
        {
            var a = new Tester { Test = 1 };
            var b = 1;

            //GenericTools.Swap(ref a, ref b);
            
        }

        private class Tester
        {
            public int Test { get; set; }
        }
    }
}
