using System;
using System.Collections.Generic;
using System.Linq;

namespace SnailSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<List<int>>()
            {
                new List<int> { 1, 2, 3, 4, 5},
                new List<int> { 16, 17, 18, 19, 6},
                new List<int> { 15, 24, 25, 20, 7},
                new List<int> { 14, 23, 22, 21, 8},
                new List<int> { 13, 12, 11, 10, 9}
            };
            var rows = CheckZeroRaws(list1);
            var columns = ListCount(list1) / rows; 
            var snailArray = new List<int>(); //final array
            PrintArray(list1, rows, columns);
            var snailList = Snail(list1, rows, columns, snailArray);
            Console.WriteLine("Snail:");
            foreach (var item in snailList)
                Console.Write($"{item} ");
            Console.ReadKey();
        }

        public static List<int> Snail(List<List<int>> list, int rows, int columns, List<int> snailArray)
        {
            var fullRowChecker = true; //checks, if full row needed to print
            var lastRowChecker = false; //checks last row
            for (int i = 0; i < rows; i++)
            {
                if (list.Count == i + 1)
                {
                    list[i].Reverse();
                    fullRowChecker = true;
                    lastRowChecker = true;
                }
                for (int j = 0; j < columns; j++)
                {
                    if (fullRowChecker)
                        snailArray.Add(list[i][j]);
                    else if (rows > list.Count && lastRowChecker)
                    {
                        snailArray.Add(list[rows - i].First());
                        break;
                    }
                    else
                    {
                        snailArray.Add(list[i].Last());
                        ++rows;
                        break;
                    }
                }
                fullRowChecker = false;
            }

            //removing used elements in list 
            for (int i = list.Count - 1; i >= 0; i--)
            {
                for (int j = list[i].Count - 1; j >= 0; j--)
                    if (snailArray.Contains(list[i][j]))
                        list[i].RemoveAt(j);
                if (list[i].Count == 0)
                    list.RemoveAt(i);
            }

            if (list.Count() == 0)
                return snailArray;
            else return Snail(list, rows = list.Count, columns = ListCount(list) / rows, snailArray);
        }

        public static int CheckZeroRaws(List<List<int>> list)
        {
            if (list.Count == 0) return 1;
            else return list.Count;
        }

        public static int ListCount(List<List<int>> list)
        {
            var count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    count++;
                }
            }
            return count;
        }

        public static void PrintArray(List<List<int>> list, int rows, int columns)
        {
            Console.WriteLine($"Rows in list: {rows}\nColumns in list: {columns}\n" +
                $"Default array is: ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{list[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}