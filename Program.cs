using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Globalization;

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
        private static void Main1(string[] args)
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
    class Day2 {
        public static string[] add_to_list(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string fileString = sr.ReadToEnd();
            string[] wordList = fileString.Split('\n');
            return wordList;
        }
        public static ArrayList[] split_str_array(int listLen, string[] listIn)
        {
            ArrayList[] newList = new ArrayList[listLen];
            int x;
            string[] tempArr = new string[4];
            for (x = 0; x < listLen; x++)
            {
                ArrayList currentLine = new ArrayList();
                tempArr = listIn[x].Split(' ','-'); //split each line by the spaces
                currentLine.Insert(0, int.Parse(tempArr[0]));
                currentLine.Insert(1, int.Parse(tempArr[1]));
                currentLine.Insert(2, tempArr[2].ToCharArray()[0]);
                currentLine.Insert(3, tempArr[3]);
                newList[x] = currentLine;
            }
            return newList;
        }
        public static int count_correct1(int listLen, ArrayList[] lineArray)
        {
            int count = 0;
            int x, freq;
            string pass;
            char char1;
            for (x = 0; x < listLen; x++)
            {
                freq = 0;
                pass = (string) lineArray[x][3];
                char1 = (char) lineArray[x][2];
                foreach (char y in pass)
                {
                    if (y == char1)
                    {
                        freq++;
                    }
                }
                if (freq >= (int) lineArray[x][0] && freq <= (int) lineArray[x][1])
                {
                    count++;
                }
            }
            return count;
        }
        public static int count_correct2(int listLen, ArrayList[] lineArray)
        {
            int count = 0;
            int x,ind1,ind2;
            char checkChar;
            string pass;
            char temp1, temp2;
            for (x = 0; x < listLen; x++)
            {
                checkChar = (char) lineArray[x][2];
                pass = (string) lineArray[x][3];
                ind1 = (int) lineArray[x][0] - 1;
                ind2 = (int) lineArray[x][1] - 1;
                temp1 = pass[ind1];
                temp2 = pass[ind2];
                if (temp1 == checkChar ^ temp2 == checkChar)
                {
                    count++;
                }
            }
            return count;
        }
        private static void Main2(string[] args)
        {
            string[] strList = add_to_list("passlist.txt");
            int listLen = strList.Length;
            ArrayList[] lineArray = split_str_array(listLen, strList);
            int count = count_correct1(listLen, lineArray);
            Console.WriteLine(count);
            count = count_correct2(listLen, lineArray);
            Console.WriteLine(count);
        }
    }
    class Day3
    {
        public static string[] add_to_list(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string fileString = sr.ReadToEnd();
            string[] wordList = fileString.Split('\n');
            int listLen = wordList.Length;
            string[] strList = new string[listLen];
            int x;
            for (x = 0; x < wordList.Length; x++)
            {
                strList[x] = wordList[x];
            }
            return strList;
        }
        public static int is_tree(int x, int y, string[] tobMap)
        {
            int isTree;
            if ((char) tobMap[y][x] == '#')
            {
                isTree = 1;
            }
            else
            {
                isTree = 0;
            }
            return isTree;
        }
        public static long iterateThrough(string[] tobMap, int stepx, int stepy)
        {
            int x = 0;
            int y = 0;
            long count = 0;
            while (y < tobMap.Length)
            {
                x = x % 31;
                if (is_tree(x, y,tobMap) == 1)
                {
                    count++;
                }
                y += stepy;
                x += stepx;
            }
            return count;
        }
        
        private static void Main3(String[] args)
        {
            string[] tobMap = add_to_list("toboggan-map.txt");
            long product = iterateThrough(tobMap, 1, 1) * iterateThrough(tobMap, 3, 1) * iterateThrough(tobMap, 5, 1) * iterateThrough(tobMap, 7, 1) * iterateThrough(tobMap, 1, 2);
            Console.Write(product);
        }
    }
    class Day4
    {
        public static string[] add_to_list(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string fileString = sr.ReadToEnd();
            string[] wordList = fileString.Split("\n\r");
            for (int x = 0; x < wordList.Length; x++)
            {
                wordList[x] = wordList[x].Trim();
            }
            return wordList;
        }
        public static string[][] get_values(string[] wordList)
        {
            int listLen = wordList.Length;
            string[][] valueArray = new string[listLen][];
            for (int x = 0; x < listLen; x++)
            {

                valueArray[x] = wordList[x].Split(':',' ');
            }
            return valueArray;
        }
        public static int valid_count(string[][] valueArray)
        {
            int count = 0;
            for (int x = 0; x < valueArray.Length; x++)
            {
                if (
                    Array.IndexOf(valueArray[x], "byr") != -1 &&
                    Array.IndexOf(valueArray[x], "iyr") != -1 &&
                    Array.IndexOf(valueArray[x], "eyr") != -1 &&
                    Array.IndexOf(valueArray[x], "hgt") != -1 &&
                    Array.IndexOf(valueArray[x], "hcl") != -1 &&
                    Array.IndexOf(valueArray[x], "ecl") != -1 &&
                    Array.IndexOf(valueArray[x], "pid") != -1
                    )
                {
                    
                    count++;
                }
            }
            return count;
        }
        private static void Main(String[] Args)
        {
            string[] fileString = add_to_list("passport.txt");
            string[][] valueArray = get_values(fileString);
            int count = valid_count(valueArray);
            Console.WriteLine(count);
        }
    }
}
