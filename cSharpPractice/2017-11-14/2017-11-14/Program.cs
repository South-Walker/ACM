using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.GetPermutation(3, 5);
        }
    }
    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            var array = new int[n + 1];
            StringBuilder sb = new StringBuilder();
            while (n != 0)  
            {
                int now = Next(array, ref k, ref n);
                sb.Append(now);
            }
            return sb.ToString();
        }
        public int Next(int[] array, ref int k, ref int n)
        {
            int jiechen = GetJiechen(n);
            int result = 0;
            int once = jiechen / n;
            int nowtime = (k - 1) / once;
            k = k - once * nowtime;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    if (nowtime == 0)
                    {
                        array[i] = 1;
                        result = i;
                        break;
                    }
                    nowtime -= 1;
                }
            }
            n--;
            return result;
        }
        public int GetJiechen(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
