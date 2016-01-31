using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Ch_02.Linked_Lists
{
    public class Q2ReturnKthToLast
    {
        public Element GetKthToLast(Element listHead, int k) // assumption k is an int.
        {
            Contract.Requires(k >= 1);
            Contract.Requires(listHead != null);
            // will do it later assert list.Length >= k

            var front = listHead;
            var kthElement = listHead;

            // for k = 1 this loop will not execute.
            // for k = 2 this loop will execute once, moving the pointers once apart.
            // for k = l this loop will execute l-1 times, moving the pointers l-1 apart.
            foreach (int i in Enumerable.Range(1, k-1))
            {
                if (front.Next == null)
                    // precondition violation, maybe code contracts?
                    throw new ArgumentOutOfRangeException($"The length of the of list should be >= {k}. Instead, it is {i}");
                front = front.Next;
            }
            // assert front points to k-th element from front, with n-k elements remaining in front of it.
            // assert kthElement points to first element.

            // for list of size = 1 and k = 1 (the only allowed), the loop will never execute
            // for list of size = 2 and k = 1 there will be 2-1 elements if front of “front”, so the loop will execute once, so the kthElement will move once, so it will point to the second element: correct.
            // for list of size = 4 and k = 2 there will be 4-2 elements if front of “front”, so the loop will execute twice, so the kthElement will movetwice, so it will point to the third element: correct.
            while (front.Next != null)
            {
                front = front.Next;
                kthElement = kthElement.Next;
            }

            return kthElement;
        }

        // tests: write tests for boundary cases etc.
    }

    public class Element
    {
        public object Data;
        public Element Next;

        public Element(object data, Element next)
        {
            Data = data;
            Next = next;
        }
    }
}