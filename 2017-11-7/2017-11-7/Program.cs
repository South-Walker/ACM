using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            int aa = 46340;
            checked
            {
                aa = aa * aa;
            }
            a.MySqrt(2147395599);
            Console.Read();
        }
    }
    public class Solution
    {
        public int MySqrt(int x)
        {
            return _mysqrt(0, x, x); 
        }
        private int _mysqrt(int begin, int end, int target)
        {
            if (begin == end)
                return begin;
            if (end - begin == 1)
            {
                if (end * end > target)
                    return begin;
                else
                    return end;
            }
            int now = (begin + end) / 2;
            if (now >= 46341)
            {
                return _mysqrt(begin, now, target);
            }
            int nowvalue = now * now;
            if (nowvalue == target)
                return now;
            //小于可能能取，大于一定不能取
            if (nowvalue > target) 
            {
                return _mysqrt(begin, now - 1, target);
            }
            else
            {
                return _mysqrt(now, end, target);
            }
        }
    }
}
