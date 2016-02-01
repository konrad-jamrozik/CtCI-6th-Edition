using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Ch_01.Arrays_and_Strings
{
    public class Q3Urlify
    {

        // Time complexity: O(n)
        // Space complexity: O(1)
        public void Urlify(char[] charArray, int trueLength)
        {
            Contract.Requires(charArray != null);
            Contract.Requires(charArray.Length >= trueLength);
            Contract.Requires(trueLength >= 0);

            if (trueLength == 0)
                return;

            UrlifySpaces(charArray, GetTrueSpaces(charArray, trueLength), trueLength);

            Contract.Ensures(Contract.OldValue(charArray).Length == charArray.Length);
            // post-conditions 
        }

        private int GetTrueSpaces(char[] charArray, int trueLength)
        {
            int index = 0;
            int trueSpaces = 0;

            foreach (char c in charArray)
            {
                index++;
                if (index > trueLength)
                    break;
                if (c == ' ')
                    trueSpaces++;
            }
            return trueSpaces;
        }

        private char[] UrlifySpaces(char[] charArray, int trueSpaces, int trueLength)
        {
            int trueLengthIndex = trueLength - 1;
            int insertIndex = trueLengthIndex + trueSpaces * 2;
            int movedIndex = trueLengthIndex;
            foreach (int i in Enumerable.Range(0, movedIndex + 1).Reverse())
            {
                if (charArray[i] == ' ')
                {
                    charArray[insertIndex - 2] = '%';
                    charArray[insertIndex - 1] = '2';
                    charArray[insertIndex] = '0';
                    insertIndex -= 3;
                }
                else
                {
                    charArray[insertIndex] = charArray[i];
                    insertIndex--;
                }
            }
            return charArray;
        }
    }
}