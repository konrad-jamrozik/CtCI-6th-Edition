using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_08.Recursion_and_Dynamic_Programming
{
    public class Ch08Q13
    {
        public Int32 GetMaxHeight(List<Box> boxes)
        {
            Contract.Requires(boxes != null);
            // Contract.Requires(boxes.HaveUniqueIndexes());

            if (boxes.Count == 0)
            {
                return 0;
            }

            var sortedBoxes = boxes.OrderByDescending(box => box.Width);

            Dictionary<String, Int32> memoizedMaxes = new Dictionary<String, Int32>();

            return sortedBoxes.Select(bottomBox =>
            {
                return bottomBox.Height + GetMaxHeightDFS(sortedBoxes.TakeSmallerThan(bottomBox), memoizedMaxes);
            }).Max();
        }

        private Int32 GetMaxHeightDFS(List<Box> sortedBoxes, Dictionary<String, Int32> memoizedMaxes)
        {
            Contract.Requires(sortedBoxes != null);
            Contract.Requires(memoizedMaxes != null);
            // Contract.Requires(sortedBoxes.AreSortedByWidth());

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
        public Int32 Width;
        public Int32 Height;
        public Int32 Depth;
        public String Id;
    }

    public static class Extensions
    {
        public static List<Box> TakeSmallerThan(this IEnumerable<Box> sortedBoxes, Box bottomBox)
        {
            // assert all params are not null;
            // assert sortedBoxes are sorted;
            // assert sortedBoxes.Contains(bottomBox);

            return sortedBoxes
                .SkipWhile(box => box != bottomBox)
                .Skip(1)
                .Where(box =>
                    box.Height < bottomBox.Height
                    && box.Depth < bottomBox.Depth
                ).ToList();
        }

        public static String GetIndicatorString(this IEnumerable<Box> boxes)
        {
            // assert boxes != null;

            return boxes.Select(box => box.Id).Join(",");
        }

        public static String Join(this IEnumerable<String> strings, String separator)
        {
            return string.Join(separator, strings);
        }
    }
}