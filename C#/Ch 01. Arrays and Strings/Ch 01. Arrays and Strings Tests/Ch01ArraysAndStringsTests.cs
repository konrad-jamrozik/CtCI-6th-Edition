using System;
using System.Collections.Generic;
using Ch_01.Arrays_and_Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_01.Arrays_and_Strings_Tests
{
    [TestClass]
    public class Ch01ArraysAndStringsTests
    {
        [TestMethod]
        public void Q1IsUniqueTest()
        {
            AssertCorrect(Q1IsUnique.A1);
            AssertCorrect(Q1IsUnique.A2);
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
        public void Q2CheckPermutationTest()
        {
            Assert.IsTrue(Q2CheckPermutation.A1("", "", 128));
            Assert.IsTrue(Q2CheckPermutation.A1("abc", "abc", 128));
            Assert.IsTrue(Q2CheckPermutation.A1("abc", "cba", 128));
            Assert.IsFalse(Q2CheckPermutation.A1("abc", "abcde", 128));
            Assert.IsFalse(Q2CheckPermutation.A1("abc","cde",128));

            Assert.IsFalse(Q2CheckPermutation.A1("aaaaa", "baaaa", 128));
            Assert.IsFalse(Q2CheckPermutation.A1("aaaaa", "aaaab", 128));
            Assert.IsFalse(Q2CheckPermutation.A1("aaaccxxxxx", "cccaaaxxxx", 128));
            Assert.IsTrue(Q2CheckPermutation.A1("aaaccxxxxc", "cccaaaxxxx", 128));
        }

        [TestMethod]
        public void Q3UrlifyTest()
        {
            AssertUrlify("Mr John Smith    ", 13, "Mr%20John%20Smith");
            AssertUrlify("Mr John Smith       ", 13, "Mr%20John%20Smith   ");
            AssertUrlify("", 0, "");
            AssertUrlify("   ", 1, "%20");
            AssertUrlify(" ", 0, " ");

        }

        private static void AssertUrlify(string str, int trueLength, string expected)
        {
            var charArray = str.ToCharArray();
            new Q3Urlify().Urlify(charArray, trueLength);
            Assert.AreEqual(expected, new string(charArray));
        }
    }
}
