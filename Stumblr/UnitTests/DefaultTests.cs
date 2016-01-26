using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stumblr;

namespace UnitTests
{
    [TestClass]
    public class DefaultTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = GenericTools.GetDefault<int>();

            Assert.AreEqual(0, a);

            var b = GenericTools.GetDefault<DefaultTests>();

            Assert.AreEqual(null, b);

        }
    }
}
