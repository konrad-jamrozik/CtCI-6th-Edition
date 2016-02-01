using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_03.Stacks_and_Queues
{
    [TestClass]
    public class Q3StackOfPlatesTest
    {
        [TestMethod]
        public void TestQ3StackOfPlates()
        {
            int maxStackCapacity = 3;
            int maxStacks = 2;
            SetOfStacks<int> stacks = new SetOfStacks<int>(maxStackCapacity, maxStacks);
            MyAssert.Throws<InvalidOperationException>( () => stacks.Pop());
            stacks.Push(10);
            stacks.Push(20);
            stacks.Push(30);
            // assert: there is one full stack internally.
            stacks.Push(11);
            // assert: two stacks, second with one element.
            Assert.AreEqual(11, stacks.Peek());
            Assert.AreEqual(11, stacks.Pop());
            Assert.AreEqual(30, stacks.Peek());
            Assert.AreEqual(30, stacks.Pop());
            Assert.AreEqual(20, stacks.Peek());
            stacks.Push(30);
            stacks.Push(11);
            stacks.Push(21);
            stacks.Push(31);
            MyAssert.Throws<InvalidOperationException>(() => stacks.Push(41));
            Assert.AreEqual(31, stacks.Pop());

        }
    }
}