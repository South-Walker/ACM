using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxArea(1,2);
            
        }

        public static int MaxArea(params int[] height)
        {
            int result = 0;int begin = 0;int end = height.Length - 1;
            int now;
            while (end > begin) 
            {
                now = end - begin;
                if (height[end] > height[begin])
                {
                    now = now * height[begin];
                    begin++;
                }
                else
                {
                    now = now * height[end];
                    end--;
                }
                if (now > result) 
                {
                    result = now;
                }
            }
            return result;
        }
    }
}
