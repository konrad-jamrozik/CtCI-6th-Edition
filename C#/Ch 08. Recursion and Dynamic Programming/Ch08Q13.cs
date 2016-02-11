using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_08.Recursion_and_Dynamic_Programming
{
    [TestClass]
    public class Ch08Q13
    {
        [TestMethod]
        public void TestQ13GetMaxHeight()
        {
            var boxes = new List<Box>();
            Assert.AreEqual(0, GetMaxHeight(boxes));

            boxes = new List<Box> {Box.Build(1), Box.Build(2), Box.Build(4,5,6) };
            Assert.AreEqual(9, GetMaxHeight(boxes));

            boxes = new List<Box> {
                Box.Build(10, 5, 10), // skip
                Box.Build(10, 10, 9), // take as 1.
                Box.Build(9, 9, 8), // take as 2.
            };
            Assert.AreEqual(17, GetMaxHeight(boxes));

            boxes = new List<Box> {
                Box.Build(10, 5, 10), // take as 1.
                Box.Build(10, 10, 9), // skip
                Box.Build(9, 9, 4), // skip
                Box.Build(8, 7, 3), // skip
                Box.Build(10, 4, 9) // take as 2.
            };
            Assert.AreEqual(19, GetMaxHeight(boxes));
        }

        public Int32 GetMaxHeight(List<Box> boxes)
        {
            Contract.Requires(boxes != null);
            // Contract.Requires(boxes.HaveUniqueIndexes());

            if (!boxes.Any())
                return 0;

            var sortedBoxes = boxes.OrderByDescending(box => box.Width);

            // Instead of memoizing maxes for each possible combination of boxes, just memoize one value per one box. Such value represents
            // the height of tallest stack having given box at the bottom.
            // This works because when we memoize for the first time a max having given box at the bottom, it will never be overriden.
            Dictionary<String, Int32> memoizedMaxes = new Dictionary<String, Int32>();

            var max = sortedBoxes.Select(bottomBox =>
            {
                return bottomBox.Height + GetMaxHeightDFS(sortedBoxes.TakeSmallerThan(bottomBox), memoizedMaxes);
            }).Max();

            // DEBUG
            Console.Out.WriteLine("maxes keys: "+memoizedMaxes.Keys.Count);
            foreach (var key in memoizedMaxes.Keys)
                Console.Out.WriteLine("key = {0}", key);
            // /DEBUG

            return max;
        }

        private Int32 GetMaxHeightDFS(List<Box> sortedBoxes, Dictionary<String, Int32> memoizedMaxes)
        {
            Contract.Requires(sortedBoxes != null);
            Contract.Requires(memoizedMaxes != null);
            // Contract.Requires(sortedBoxes.AreSortedByWidth());

            if (!sortedBoxes.Any())
                return 0;

            if (!memoizedMaxes.ContainsKey(sortedBoxes.GetIndicatorString()))
            {
                var max = sortedBoxes.Select(bottomBox =>
                {
                    return bottomBox.Height + GetMaxHeightDFS(sortedBoxes.TakeSmallerThan(bottomBox), memoizedMaxes);
                }).Max();

                memoizedMaxes[sortedBoxes.GetIndicatorString()] = max;

                // Contract.Ensures(memoizedMaxes.KeyCount >= memoizedMaxes_oldValue.KeyCount);            
            }
            return memoizedMaxes[sortedBoxes.GetIndicatorString()];
        }
    }

    public class Box
    {
        public String Id;

        public Int32 Width;
        public Int32 Depth;
        public Int32 Height;


        public static Box Build(int dimension)
        {
            return new Box {Id = dimension.ToString(), Width = dimension, Depth = dimension, Height = dimension};
        }

        public static Box Build(int width, int depth, int height)
        {
            return new Box { Id = width.ToString() +"-" + depth + "-" + height, Width = width, Depth = depth, Height = height};
        }
    }

    public static class Extensions
    {
        public static List<Box> TakeSmallerThan(this IEnumerable<Box> sortedBoxes, Box bottomBox)
        {
            // assert all params are not null;
            // assert sortedBoxes are sorted;
            // assert sortedBoxes.Contains(bottomBox);

            return sortedBoxes
                // This has linear complexity, could be made constant if the boxes are kept in an array and index of bottomBox is known.
                .SkipWhile(box => box != bottomBox)
                .Skip(1)
                .Where(box =>
                    box.Height < bottomBox.Height
                    && box.Depth < bottomBox.Depth
                ).ToList();
        }

        // Instead of this method we could just use GetHashCode() (which we might need to implement). 
        // Then no explicit method call will be necessary when keying a map.
        public static String GetIndicatorString(this IEnumerable<Box> boxes)
        {
            Contract.Requires(boxes != null);
            Contract.Requires(boxes.Any());

            return boxes.Select(box => box.Id).Join(",");
        }

        public static String Join(this IEnumerable<String> strings, String separator)
        {
            return string.Join(separator, strings);
        }
    }
}