using System;
using System.Collections;
using System.IO;

namespace AdventOfCode {
    class Day1 {
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
        public static int[] sum_2_to_2020(int[] listIn, int pointer)
        {
            pointer--;
            if (pointer < 1)
            {
                return new int[]{0,0};
            }
            int[] returnNums = sum_2_to_2020(listIn, pointer); //recurse to index 0
            int y = listIn[pointer];
            foreach(int x in listIn)
            { // Check each element in the list
                if (y + x == 2020)
                {
                    int[] foundNums = {x,y};
                    return foundNums;
                }
            }
            return returnNums;
        }
        public static int[] sum_3_to_2020(int[] listIn, int pointer) {
            
        }
        private static void Main(string[] args)
        {
            int[] intList = add_to_list("expenses-report.txt");
            int topIndex = intList.Length - 1;
            int[] foundNums = sum_2_to_2020(intList, topIndex);
            Console.WriteLine($"{foundNums[0]*foundNums[1]}");
            int[] foundNums2 = sum_3_to_2020(intList, topIndex);
        }
    }
}
