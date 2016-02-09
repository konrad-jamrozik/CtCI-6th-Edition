using System.Collections.Generic;
using System.Linq;

namespace Ch_04.Trees_and_Graphs
{
    public class DepthLists<T> : List<ListWithDepth<T>>
    {
        public List<List<Node<T>>> ListOfLists
        {
            get { return this.Select(listWithDepth => listWithDepth.ToList()).ToList(); }
        }
    }
}