using System;
using System.Diagnostics.Eventing.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_05.Bit_Manipulation
{
    [TestClass]
    public class Ch05Intro
    {
        [TestMethod]
        public void TestCh05Intro()
        {
            var b000 = Convert.ToInt32("000", 2);
            var b010 = Convert.ToInt32("010", 2);
            var b100 = Convert.ToInt32("100", 2);
            var b101 = Convert.ToInt32("101", 2);
            var b110 = Convert.ToInt32("110", 2);
            var b111 = Convert.ToInt32("111", 2);
            var b1110 = Convert.ToInt32("1110", 2);

            Assert.AreEqual(false, getBit(b110, 0));
            Assert.AreEqual(true, getBit(b110, 1));
            Assert.AreEqual(true, getBit(b110, 2));
            Assert.AreEqual(false, getBit(b110, 3));

            Assert.AreEqual(b101, setBit(b100, 0));
            Assert.AreEqual(b110, setBit(b100, 1));
            Assert.AreEqual(b100, setBit(b100, 2));

            Assert.AreEqual(b110, clearBit(b110, 0));
            Assert.AreEqual(b100, clearBit(b110, 1));
            Assert.AreEqual(b010, clearBit(b110, 2));

            Assert.AreEqual(b000, clearBitsMSBthroughI(b110, 0));
            Assert.AreEqual(b000, clearBitsMSBthroughI(b110, 1));
            Assert.AreEqual(b010, clearBitsMSBthroughI(b110, 2));
            Assert.AreEqual(b110, clearBitsMSBthroughI(b110, 3));

            Assert.AreEqual(b110, clearBitsIthrough0(b110, 0));
            Assert.AreEqual(b100, clearBitsIthrough0(b110, 1));
            Assert.AreEqual(b000, clearBitsIthrough0(b110, 2));
            Assert.AreEqual(b000, clearBitsIthrough0(b110, 3));

            Assert.AreEqual(b110, updateBit(b110, 0, false));
            Assert.AreEqual(b100, updateBit(b110, 1, false));
            Assert.AreEqual(b010, updateBit(b110, 2, false));
            Assert.AreEqual(b110, updateBit(b110, 3, false));

            Assert.AreEqual(b111, updateBit(b110, 0, true));
            Assert.AreEqual(b110, updateBit(b110, 1, true));
            Assert.AreEqual(b110, updateBit(b110, 2, true));
            Assert.AreEqual(b1110, updateBit(b110, 3, true));

        }

        Boolean getBit(int num, int i)
        {
            return Convert.ToBoolean(num & 1 << i);
        }

        int setBit(int num, int i)
        {
            return num | 1 << i;
        }

        int clearBit(int num, int i)
        {
            return num & ~(1 << i);
        }

        int clearBitsMSBthroughI(int num, int i)
        {
            return num & ~(Int32.MinValue >> (31 - i));
        }

        int clearBitsIthrough0(int num, int i)
        {
            return num & (Int32.MinValue >> (30 - i));
        }

        int updateBit(int num, int i, Boolean bitIs1)
        {
            int mask = ~(1 << i);
            return (num & mask) | (bitIs1 ? (1 << i) : 0);
        }
    }
}
