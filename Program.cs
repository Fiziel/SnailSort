using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<List<int>>()
            {
                new List<int> { 1, 2, 3},
                new List<int> { 4, 5, 6},
                new List<int> { 7, 8, 9}
            };
            var rows = list1.Count;
            var columns = ListCount(list1) / rows;

            PrintArray(list1, rows, columns);
            var snailList = Snail(list1, rows, columns);
            Console.WriteLine("Snail:");
            foreach (var item in snailList)
            {
                Console.WriteLine($"{item} ");
            }
            Console.ReadKey();
        }

        public static List<int> Snail(List<List<int>> list, int rows, int columns)
        {
            var snailArray = new List<int>();
            var firstChecker = false;

            for (int i = 0; i < rows + (rows - 2); i++)
            {
                if (rows == i + 1)
                {
                    list[i].Reverse();
                    firstChecker = false;
                }
                for (int j = 0; j < columns - i; j++)
                {
                    if (!firstChecker)
                        snailArray.Add(list[i][j]);
                    else snailArray.Add(list[i].Last());
                }
                firstChecker = true;
            }

            if (ListCount(list) == snailArray.Count)
                return snailArray;
            else return Snail(list, rows-2, columns-2);
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