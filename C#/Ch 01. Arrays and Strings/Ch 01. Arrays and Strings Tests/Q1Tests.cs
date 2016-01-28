using System;
using Ch_01.Arrays_and_Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_01.Arrays_and_Strings_Tests
{
    [TestClass]
    public class Q1Tests
    {
        [TestMethod]
        public void Q1A1Test()
        {
            Assert.AreEqual(true, Q1.A1(""));
            Assert.AreEqual(true, Q1.A1("abc"));
            Assert.AreEqual(false, Q1.A1("aa"));
            Assert.AreEqual(false, Q1.A1("abcabc"));
            Assert.AreEqual(false, Q1.A1("abcaabc"));
        }
    }
}
