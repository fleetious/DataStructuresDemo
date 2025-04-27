/*
 * All of the data structures encountered later on will be implemented with generics. As you will see, this approach is especially useful with collection classes.
 * All of the data structures encountered later on will be implemented with generics. As you will see, this approach is especially useful with collection classes.
 * All of the data structures encountered later on will be implemented with generics. As you will see, this approach is especially useful with collection classes.
 * All of the data structures encountered later on will be implemented with generics. As you will see, this approach is especially useful with collection classes.
*/

/*
 * TODO:
 *  HIGH PRIORITY:
 *      Unit tests for all functions
 *      More test cases
 *      A demo implementation to ensure that List can work in real-worldish situations.
 */

using System;
using System.Collections.Generic;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = new();
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(3);

            testList.Remove(2);

            for (int i = 0; i < testList.Count; i++)
            {
                Console.WriteLine($"{i}: {testList[i]}");
            }

        }
    }
    
}