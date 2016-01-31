using System.Collections.Generic;

namespace Ch_03.Stacks_and_Queues
{
    public static class StackExtensions { 
        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            return stack.Count == 0; 
        }
    }
}