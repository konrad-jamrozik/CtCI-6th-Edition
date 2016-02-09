using System;
using System.Collections.Generic;

namespace Ch_04.Trees_and_Graphs
{
    public class ListWithDepth<T> : Tuple<int, List<Node<T>>>
    {
        public ListWithDepth(int depth, List<Node<T>> nodes) : base(depth, nodes)
        {
        }

        public List<Node<T>> ToList()
        {
            return this.Item2;
        }
    }

}