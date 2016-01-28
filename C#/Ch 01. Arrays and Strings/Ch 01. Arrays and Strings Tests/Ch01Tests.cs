using System;
using Ch_01.Arrays_and_Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_01.Arrays_and_Strings_Tests
{
    [TestClass]
    public class Ch01Tests
    {
        [TestMethod]
        public void Q1Test()
        {
            AssertCorrect(Q1.A1);
            AssertCorrect(Q1.A2);
        }

        private static void AssertCorrect(Func<string, bool> predicate)
        {
            Assert.AreEqual(true, predicate(""));
            Assert.AreEqual(true, predicate("abc"));
            Assert.AreEqual(false, predicate("aa"));
            Assert.AreEqual(true, predicate("abc"));
            Assert.AreEqual(false, predicate("abcc"));
            Assert.AreEqual(false, predicate("aabc"));
            Assert.AreEqual(false, predicate("abbc"));
            Assert.AreEqual(false, predicate("abcdea"));
        }
    }
}
