using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode {
    class Day1 {
        public static int foundNums = 0;
        public static int[] add_to_list(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string fileString = sr.ReadToEnd();
            string[] wordList = fileString.Split('\n');
            int listLen = wordList.Length;
            int[] intList = new int[listLen];
            int x;
            for (x = 0; x < wordList.Length; x++)
            {
                intList[x] = Int32.Parse(wordList[x]);
            }
            return intList;
        }
        
        public static int sum_2_to_2020(int[] listIn, int pointer)
        {
            pointer--;
            if (pointer < 1)
            {
                return 0;
            }
            int product = sum_2_to_2020(listIn, pointer); //recurse to index 0
            if (foundNums != 1)
            {
                int x = listIn[pointer];
                foreach(int y in listIn)
                { // Check each element in the list
                    if (y + x == 2020)
                    {
                        Console.WriteLine($"{x},{y}");
                        product = x*y;
                        foundNums = 1;
                        return product;
                    }
                }
            }
            return product;
        }
        public static int sum_3_to_2020(int[] listIn, int pointer)
        {
            pointer--;
            if (pointer < 1)
            {
                return 0;
            }
            int product = sum_3_to_2020(listIn, pointer); //recurse to index 0
            int z = listIn[pointer];
            if (foundNums != 1)
            {
                foreach (int x in listIn)
                { // Check each element in the list
                    foreach (int y in listIn)
                    {
                        if (x + y + z == 2020)
                        {
                            Console.WriteLine($"{x},{y},{z}");
                            product = x*y*z;
                            foundNums = 1;
                            return product;
                        }
                    }
                }
            }
            return product;
        }
        private static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            int[] intList = add_to_list("expenses-report.txt");
            //Array.Sort(intList); // Sorts in ascending order
            int topIndex = intList.Length - 1;
            Console.WriteLine($"{sum_2_to_2020(intList, topIndex)}");
            foundNums = 0;
            Console.WriteLine($"{sum_3_to_2020(intList, topIndex)}");
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
