using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch_03.Stacks_and_Queues
{
    // From http://stackoverflow.com/a/5634337/986533
    public static class MyAssert
    {
        public static void Throws<T>(Action func) where T : Exception
        {
            var exceptionThrown = false;
            try
            {
                func.Invoke();
            }
            catch (T)
            {
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                throw new AssertFailedException(
                    $"An exception of type {typeof (T)} was expected, but not thrown"
                    );
            }
        }
    }
}
