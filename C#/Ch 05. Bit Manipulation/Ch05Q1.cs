using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_05.Bit_Manipulation
{
    [TestClass]
    public class Ch05Q1
    {
        [TestMethod]
        public void Ch05Q1_Test1()
        {
            var N = Convert.ToInt32("10000000000", 2);
            var M = Convert.ToInt32("10011", 2);
            var expected = Convert.ToInt32("10001001100", 2);
            Assert.AreEqual(expected, insertAt(N,M,2,6));
        }

        [TestMethod]
        public void Ch05Q1_Test2()
        {
            var N = Convert.ToInt32("11111110000", 2);
            var M = Convert.ToInt32("100111", 2);
            var expected = Convert.ToInt32("11001001110", 2);
            Assert.AreEqual(expected, insertAt(N, M, 1, 8));
        }

        private int insertAt(int target, int inserted, int start, int end)
        {
            Contract.Requires(start <= 0);
            Contract.Requires(end <= 31);
            Contract.Requires(start <= end);
            int maskLength = end - start + 1;
            return (target & ~GetShiftedMask(inserted, start, maskLength)) | GetShifted(inserted, start);
        }

        private int GetShifted(int inserted, int start)
        {
            return inserted << start;
        }

        private int GetShiftedMask(int inserted, int start, int maskLength)
        {
            return GetMask(inserted, maskLength) << start;
        }

        private int GetMask(int inserted, int maskLength)
        {
            // int maskLength = GetBitLength(inserted);
            return (1 << maskLength) - 1;
        }

        private int GetBitLength(int inserted)
        {
            int length = 0;
            int curr = 1;
            while (curr <= 31)
            {
                if ((inserted & 1) == 1)
                    length = curr;
                inserted = inserted/2;
                curr++;
            }
            return length;
        }
    }
}