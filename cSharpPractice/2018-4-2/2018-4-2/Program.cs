using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums0 = { 4, 3, 4, 1, 1, 4, 1, 4 };
            Solution a = new Solution();
            a.FirstMissingPositive(nums0);
            Console.Read();
            int[] mynums = new int[10000];
            Random m = new Random();
            for (int i = 0; i < mynums.Length; i++)
            {
                mynums[i] = m.Next(0, 200000);
            }
            int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18 };
            Solution b = new Solution();
            b.LengthOfLIS(nums);
            //现在速度是差不多，但是第一个里面的s如果不用链表，用平衡二叉树（普通的不行，插入的一般都是大值，容易退化），理论上会快一点
            Console.WriteLine(ActionExtension.Profiler(() => test2(mynums), 20));
            Console.WriteLine(ActionExtension.Profiler(() => test(mynums), 20));
            Console.Read();
        }
        static void test(int[] nums)
        {
            Solution a = new Solution();
            Console.WriteLine(a.slowLengthOfLIS(nums));
        }
        static void test2(int[]nums)
        {
            Solution b = new Solution();
            Console.WriteLine(b.slowLengthOfLIS(nums));
        }
    }
    public class Solution
    {
        public struct State
        {
            public int Length { get; }
            public int Tail { get; }
            public State(int length, int tail)
            {
                Length = length;
                Tail = tail;
            }
        }
        public int slowLengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int[] m = new int[nums.Length];
            int[] d = new int[nums.Length];
            m[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                m[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        m[i] = Math.Max(m[i], m[j] + 1);
                    }
                }
            }
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, m[i]);
            }
            return max;
        }
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            List<State> s = new List<State>();
            for (int i = 0; i < nums.Length; i++)
            {
                int length = 1;int tail = nums[i];
                foreach (var item in s)
                {
                    if (item.Tail < tail)
                    {
                        length = Math.Max(item.Length + 1, length);
                    }
                }
                State news = new State(length, tail);
                for (int k = s.Count - 1; k >= 0; k--) 
                {
                    if (s[k].Tail >= tail && s[k].Length <= length)
                    {
                        s.RemoveAt(k);
                    }
                }
                s.Add(news);
            }
            int maxLength = int.MinValue;
            foreach (var item in s)
            {
                maxLength = Math.Max(item.Length, maxLength);
            }
            return maxLength;
        }
        public int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
                return 1;
            for (int i = 0; i < nums.Length; i++)
            {
                SeekNum(nums[i], nums);
            }
            for (int i = 0; i < nums.Length; i++) 
            {
                if (nums[i] - i != 1)
                    return i + 1;
            }
            return nums.Length + 1;
        }
        private void SeekNum(int num, int[] nums)
        {
            if (num > nums.Length || num <= 0) 
                return;
            if (nums[num - 1] == num) 
                return;
            else
            {
                int temp = nums[num - 1];
                nums[num - 1] = -1;
                SeekNum(temp, nums);
                nums[num - 1] = num;
            }
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
