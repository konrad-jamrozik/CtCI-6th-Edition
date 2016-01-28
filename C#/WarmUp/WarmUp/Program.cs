using System;
using System.Text;
using static System.Linq.Enumerable;

namespace WarmUp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HelloWorld();
            FizzBuzz();
        }

        private static void HelloWorld()
        {
            Console.Out.WriteLine("Hello World!");
        }

        /// <summary>
        ///     Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz”
        ///     instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples
        ///     of both three and five print “FizzBuzz”.
        ///     http://c2.com/cgi/wiki?FizzBuzzTest
        /// </summary>
        private static void FizzBuzz()
        {
            foreach (var i in Range(1, 100))
            {
                var s = new StringBuilder();

                if (i%3 == 0)
                    s.Append("Fizz");
                if (i%5 == 0)
                    s.Append("Buzz");

                if (s.Length == 0)
                    Console.Out.WriteLine(i);
                else
                    Console.Out.WriteLine(s.ToString());
            }
        }
    }
}