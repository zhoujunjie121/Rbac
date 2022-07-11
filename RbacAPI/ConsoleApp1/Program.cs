using System;
using System.Linq;
using System.Timers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }


        #region Timers定时
        /*static void Main(string[] args)
        {
            #region 数组转换类型
            //int[] arr1 = { 1, 2, 3, 4 };
            //string[] arr2 = { "1", "2", "3", "4" };
            ////强转
            //arr1 = Array.ConvertAll(arr2, int.Parse);

            ////Linq转换
            //arr1 = arr2.Select(int.Parse).ToArray();
            //Console.WriteLine(arr1[0]);
            #endregion

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.Second);
        }*/
        #endregion
    }
}
