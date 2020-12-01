using System;
using System.Collections;
using System.IO;

namespace AdventOfCode {
    class Day1 {
        public static int[] add_to_list(string filename) {
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
        public static void sum_to_2020(int[] listIn, int pointer) {
            pointer--;
            if (pointer < 1)
            {
                return;
            }
            sum_to_2020(listIn, pointer);
            for (int x = 0; x < )
            return;
        }
        static void Main(string[] args) {
            int[] intList = add_to_list("expenses-report.txt");
            public static int listLen = intList.Length;
            sum_to_2020(intList, listLen - 1);
        }
    }
}
