using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_08.Recursion_and_Dynamic_Programming
{
    [TestClass]
    public class Ch08Q4
    {
        [TestMethod]
        public void TestQ4PowerSet()
        {
        }

        // TODO untested
        public HashSet<HashSet<T>> Q4PowerSet<T>(HashSet<T> set)
        {
            Contract.Requires(set != null);

            // Possible optimization: instead of computing indicator functions, just immediately select the elements.
            // However, in bigger context it might be useful to precompute indicator function once.
            List<List<bool>> indicatorFunctions = ComputePowerSetIndicatorFunctions(set.Count);

            HashSet<HashSet<T>> outputPowerSet = new HashSet<HashSet<T>>();
            List<T> setAsList = new List<T>(set);

            foreach (List<bool> indicatorFunction in indicatorFunctions)
            {
                HashSet<T> currentSubset = new HashSet<T>();
                int index = 0;
                // Ideally we should have here: findAllWithIndex(); We would find elements whose indicator == true and return setAsList[index_of_given_indivator];
                indicatorFunction.ForEach(indicator =>
                {
                    if (indicator)
                        currentSubset.Add(setAsList[index]);
                    index++;
                });
                outputPowerSet.Add(currentSubset);
            }

            Contract.Ensures(outputPowerSet.All(subset => subset.Count <= set.Count));
            Contract.Ensures(outputPowerSet.All(subset => subset.All(set.Contains)));
            return outputPowerSet;
        }

        List<List<bool>> ComputePowerSetIndicatorFunctions(Int32 length)
        {
            if (length == 0)
                return new List<List<bool>>();
            if (length == 1)
            {
                return new List<List<bool>> { new List<bool> { true }, new List<bool> { false } };
            }
            var tailFunctions = ComputePowerSetIndicatorFunctions(length - 1);
            List<List<bool>> output = new List<List<bool>>();
            foreach (List<bool> tail in tailFunctions)
            {
                output.Add(new List<bool>(tail) { false });
                output.Add(new List<bool>(tail) { true });
            }
            return output;
        }


    }
}
