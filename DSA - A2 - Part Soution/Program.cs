//Use the code in this class to prove that the SplitMix64 PRNG implemented is 
//indeed correct and intractaable as described in Task 2 of the Assignment Brief


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSA___A2___Part_Soution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SplitMix64 rng = new SplitMix64();
            List<ulong> numbers = new List<ulong>();

            for (int i = 0; i < 100; i++)
            {
                numbers.Add(rng.Next(1, 1000));
            }

            bool allInRange = numbers.All(n => n >= 1 && n <= 1000);
            Console.WriteLine("All numbers within range 1 to 1000: " + allInRange);

            bool isSortedAscending = numbers.SequenceEqual(numbers.OrderBy(n => n));
            Console.WriteLine("Not sorted in ascending order: " + !isSortedAscending);

            bool isSortedDescending = numbers.SequenceEqual(numbers.OrderByDescending(n => n));
            Console.WriteLine("Not sorted in descending order: " + !isSortedDescending);

            Console.WriteLine("\nGenerated Numbers:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("\nPART B\n");

            int[] testSizes = { 1000, 10000, 100000, 1000000 };
            Console.WriteLine("Empirical Timing Results:");
            Console.WriteLine("Count\tTime (Ticks)");

            foreach (int size in testSizes)
            {
                List<ulong> result = new List<ulong>(size);
                Stopwatch sw = new Stopwatch();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                sw.Start();
                for (int i = 0; i < size; i++)
                {
                    result.Add(rng.Next(1, 1000));
                }
                sw.Stop();

                Console.WriteLine($"{size}\t{sw.ElapsedTicks}");
            }
        }
    }
}



