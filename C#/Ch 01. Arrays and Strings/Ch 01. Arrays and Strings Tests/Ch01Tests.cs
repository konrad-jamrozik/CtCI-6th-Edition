using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void Q2Test()
        {
            Assert.IsTrue(Q2.A1("", "", 128));
            Assert.IsTrue(Q2.A1("abc", "abc", 128));
            Assert.IsTrue(Q2.A1("abc", "cba", 128));
            Assert.IsFalse(Q2.A1("abc", "abcde", 128));
            Assert.IsFalse(Q2.A1("abc","cde",128));

            Assert.IsFalse(Q2.A1("aaaaa", "baaaa", 128));
            Assert.IsFalse(Q2.A1("aaaaa", "aaaab", 128));
            Assert.IsFalse(Q2.A1("aaaccxxxxx", "cccaaaxxxx", 128));
            Assert.IsTrue(Q2.A1("aaaccxxxxc", "cccaaaxxxx", 128));
        }
    }
}
