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
        static void Main(string[] args)
        {
        }

        public static bool A1(String s)
        {
            Contract.Requires(s != null);
            Contract.Requires(s.Length >= 0);

            // preconditons: s != null, s >= 0
            var dict = new Dictionary<char, char>(s.Length);
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    return false;
                else
                    dict.Add(c, c);
            }
            return true;
        }
    }
}
