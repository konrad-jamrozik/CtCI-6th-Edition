using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_08.Recursion_and_Dynamic_Programming
{
    [TestClass]
    public class Ch08
    {
        [TestMethod]
        public void TestQ1TripleStep()
        {
            AssertTripleStep(1, 0);
            AssertTripleStep(1, 1);
            AssertTripleStep(2, 2);
            AssertTripleStep(4, 3);
            AssertTripleStep(7, 4);
            AssertTripleStep(13, 5);
            AssertTripleStep(24, 6);
        }

        private void AssertTripleStep(int expected, int argument)
        {
            Assert.AreEqual(expected, actual: Q1TripleStep(argument));
        }

        public Int32 Q1TripleStep(Int32 steps) // assumption that steps fists in n
        {
            List<Int32> ways = new List<Int32> { 1, 1, 2 };

            if (steps <= 1)
                return ways[steps]; // here we assume that 0 steps can be chosen in one way.

            // Hangs. Bug?
            // Contract.Assert(steps > 2);

            int stepsRemaining = steps - 2;
            while (stepsRemaining > 0)
            {
                stepsRemaining--;
                ways.Add(ways.Sum());
                ways.RemoveAt(0);
            }

            Contract.Ensures(ways.Count == 3);
            return ways.Last();
        }
    }
}
