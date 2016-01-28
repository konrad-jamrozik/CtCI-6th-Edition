using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ch_01.Arrays_and_Strings
{
    public class Q2
    {
        public static bool A1(string s1, string s2, int alphabetSize)
        {
            Contract.Requires(s1 != null);
            Contract.Requires(s2 != null);

            if (s1.Length != s2.Length)
                return false;

            short[] counts  = new short[alphabetSize];
            foreach (var c in s1)
                counts[(short) c]++;

            foreach (char c in s2)
            {
                if (counts[(short) c] == 0)
                    return false;
                counts[(short) c]--;
            }
            return true;
        }
    }
}