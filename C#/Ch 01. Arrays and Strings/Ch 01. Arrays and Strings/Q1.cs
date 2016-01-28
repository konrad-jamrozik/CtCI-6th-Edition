using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_01.Arrays_and_Strings
{
    public class Q1
    {
        public static void Main()
        {
            
        }

        // Time complexity: O(min(n,c)) where c is the asciiCharsetSize
        // Space complexity: O(n + c) // n for the input string c for the dictionary
        public static bool A1(String s)
        {
            Contract.Requires(s != null);
            Contract.Requires(s.Length >= 0);

            var asciiCharsetSize = 128;
            if (s.Length > asciiCharsetSize) return false;

            // preconditons: s != null, s >= 0
            var dict = new Dictionary<char, char>(asciiCharsetSize);
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    return false;
                else
                    dict.Add(c, c);
            }
            return true;
        }

        // Time complexity: O(n log(n))
        // Space complexity: O(n) // n for the input string
        public static bool A2(String s)
        {
            Contract.Requires(s != null);
            Contract.Requires(s.Length >= 0);

            var asciiCharsetSize = 128;
            if (s.Length > asciiCharsetSize) return false;

            var chars = s.ToCharArray();
            Array.Sort(chars);
            for (var i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                    return false;
            }
            return true;
        }
    }
}
