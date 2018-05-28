using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - i;
            }
            int[] array2 = { 58, 21, 72, 77, 48, 9, 38, 71, 68, 77, 82, 47, 25, 94, 89, 54, 26, 54, 54, 99, 64, 71, 76, 63, 81, 82, 60, 64, 29, 51, 87, 87, 72, 12, 16, 20, 21, 54, 43, 41, 83, 77, 41, 61, 72, 82, 15, 50, 36, 69, 49, 53, 92, 77, 16, 73, 12, 28, 37, 41, 79, 25, 80, 3, 37, 48, 23, 10, 55, 19, 51, 38, 96, 92, 99, 68, 75, 14, 18, 63, 35, 19, 68, 28, 49, 36, 53, 61, 64, 91, 2, 43, 68, 34, 46, 57, 82, 22, 67, 89 };
            Solution a = new Solution();
            a.Candy(array2);
            Action l = () => { a.Candy(array); };
            Console.WriteLine(l.Profiler(10));
            Console.Write("");
        }
    }
    public class Solution
    {
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int count = gas.Length;
            for (int i = 0; i < gas.Length; i++)
            {
                int restGas = 0;
                int position = i;
                while (true)
                {
                    restGas += gas[position];
                    restGas -= cost[position];
                    if (restGas < 0)
                        break;
                    position = (position == count - 1) ? 0 : position + 1;
                    if (position == i)
                        return i;
                }
            }
            return -1;
        }
        public int Candy(int[] ratings)
        {
            if (ratings.Length == 1)
                return 1;
            int length = ratings.Length;
            int[] indexs = new int[length];
            int[] forkRatings = new int[length];
            for (int i = 0; i < length; i++)
            {
                indexs[i] = i;
            }
            Array.Copy(ratings, forkRatings, length);
            random(forkRatings, indexs);
            qsort(forkRatings, indexs, 0, length - 1);
            int totalcandy = 0;
            int[] candies = new int[length];
            for (int i = 0; i < length; i++)
            {
                int index = indexs[i];
                if (index == 0)
                {
                    if (ratings[index + 1] >= ratings[index]) 
                        candies[index] = 1;
                    else
                        candies[index] = candies[index + 1] + 1;
                }
                else if (index == length - 1) 
                {
                    if (ratings[index - 1] >= ratings[index])
                        candies[index] = 1;
                    else
                        candies[index] = candies[index - 1] + 1;
                }
                else
                {
                    if (ratings[index - 1] >= ratings[index] && ratings[index + 1] >= ratings[index])
                        candies[index] = 1;
                    else if (ratings[index - 1] < ratings[index] && ratings[index + 1] < ratings[index])
                        candies[index] = Math.Max(candies[index - 1], candies[index + 1]) + 1;
                    else if (ratings[index - 1] >= ratings[index] && ratings[index + 1] < ratings[index])
                        candies[index] = candies[index + 1] + 1;
                    else
                        candies[index] = candies[index - 1] + 1;
                }
                totalcandy += candies[index];
            }
            return totalcandy;
        }
        public void qsort(int[] ratings, int[] indexs, int begin, int end)
        {
            if (end <= begin)
                return;
            int nowB = begin;int nowE = end;
            while (nowE > nowB)
            {
                while (nowE > nowB && ratings[nowB] <= ratings[nowE])  
                {
                    nowB++;
                }
                if (nowE > nowB)
                {
                    swap(nowB, nowE, ratings);
                    swap(nowB, nowE, indexs);
                    nowE--;
                }
                while (nowE > nowB && ratings[nowB] <= ratings[nowE])
                {
                    nowE--;
                }
                if (nowE > nowB)
                {
                    swap(nowB, nowE, ratings);
                    swap(nowB, nowE, indexs);
                    nowB++;
                }
            }
            qsort(ratings, indexs, begin, nowE - 1);
            qsort(ratings, indexs, nowE + 1, end);
        }
        public void random(int[] array, int[] index)
        {
            Random r = new Random();
            int target;
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                target = r.Next(i, length);
                swap(target, i, index);
                swap(target, i, array);
            }
        }
        public void swap(int indexa, int indexb, int[] array)
        {
            int temp = array[indexa];
            array[indexa] = array[indexb];
            array[indexb] = temp;
        }
    }
    public static class ActionExtension
    {
        public static string Profiler(this Action func, int runcount)
        {
            Stopwatch watch = Stopwatch.StartNew();//创建一个监听器
            for (int i = 0; i < runcount; i++)
            {
                func();//执行某个方法
            }
            watch.Stop();

            float sec = watch.ElapsedMilliseconds / 1000.0f;
            float freq = sec / runcount;

            return string.Format("总体执行时间为:{0}秒,总体执行次数为:{1},平均执行时间为:{2}秒", sec, runcount, freq);
        }
    }
}
