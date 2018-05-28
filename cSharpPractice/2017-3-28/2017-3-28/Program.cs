using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_28
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime t1 = DateTime.Now;
            uva699();
            DateTime t2 = DateTime.Now;
            TimeSpan ts = t2.Subtract(t1);
            Console.WriteLine(ts.Milliseconds);
            Console.ReadLine();
        }
        public static void uva699()
        {
            int[] aim = new int[10000];
            int now = 5000;
            int stindex = -1;
            string input = "8 2 9 -1 -1 6 5 -1 -1 12 -1 -1 3 7 -1 -1 -1";
            string[] sta = input.Split(' ');
            Sum(aim, now, ref stindex, sta);
            for (int i = 0; i < 10000; i++)
            {
                if(aim[i] == 0)
                {
                    continue;
                }
                Console.Write(aim[i] + " ");
            }
            Console.WriteLine();
        }
        public static void Sum(int[] aim, int now, ref int index, string[] sta)
        {
            index += 1;
            if (sta[index] != "-1")
            {
                aim[now] += Convert.ToInt32(sta[index]);
                Sum(aim, now - 1, ref index, sta);
                Sum(aim, now + 1, ref index, sta);
            }
        }
    }
}
