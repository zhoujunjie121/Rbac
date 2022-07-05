using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4 };
            string[] arr2 = { "1", "2", "3", "4" };
            //强转
            arr1 = Array.ConvertAll(arr2, int.Parse);


            //Linq转换
            arr1 = arr2.Select(int.Parse).ToArray();

            Console.WriteLine(arr1[0]);
        }
    }
}
