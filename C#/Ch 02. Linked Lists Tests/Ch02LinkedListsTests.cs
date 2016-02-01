using System;
using Ch_02.Linked_Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_02.Linked_Lists_Tests
{
    [TestClass]
    public class Ch02LinkedListsTests
    {
        [TestMethod]
        public void Q2ReturnKthToLastTest()
        {

            Element head = BuildListOfLength(1);
            Assert.AreEqual(1, new Q2ReturnKthToLast().GetKthToLast(head, 1).Data);
            ArgumentOutOfRangeException expected = null;
            try
            {
                Assert.AreEqual(-1, new Q2ReturnKthToLast().GetKthToLast(head, 2).Data);
            }
            catch (ArgumentOutOfRangeException e)
            {
                expected = e;
            }
            Assert.IsNotNull(expected);
            head = BuildListOfLength(3);
            Assert.AreEqual(1, new Q2ReturnKthToLast().GetKthToLast(head, 1).Data);
            Assert.AreEqual(2, new Q2ReturnKthToLast().GetKthToLast(head, 2).Data);
            Assert.AreEqual(3, new Q2ReturnKthToLast().GetKthToLast(head, 3).Data);
        }

        private Element BuildListOfLength(int i)
        {
            if (i == 0)
                return null;
            return new Element(i, BuildListOfLength(i-1));
        }
    }
}
