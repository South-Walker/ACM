using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            Console.WriteLine(a.Divide(-2147483648, -1109186033));
            Console.Read();
        }
    }
    public class Solution
    {
        public static bool Isminus(int dividend, int divisor)
        {
            bool ispositive = (dividend >> 31) - (divisor >> 31) == 0;
            return ispositive;
        }
        public int Divide(int dividend, int divisor)
        {
            int result = 0;
            if (divisor == 0)
                return int.MaxValue;
            bool ispositive = Isminus(dividend, divisor);
            if (dividend == int.MinValue)
            {
                if (divisor != int.MinValue)
                {
                    if (divisor == -1)
                    {
                        return int.MaxValue;
                    }
                    if (ispositive)
                    {
                        dividend = dividend + divisor;
                        result++;
                    }
                    else
                    {
                        dividend = dividend - divisor;
                        result++;
                    }
                }
                else
                {
                    return 1;
                }
            }
            if (divisor == int.MinValue)
            {
                return 0;
            }
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);
            while (dividend > divisor) 
            {
                int has_righttimes = 0;int divisornow = divisor;
                while (dividend > divisornow && divisornow < 1073741824) 
                {
                    has_righttimes += 1;
                    divisornow = divisornow << 1;
                }
                if (dividend <= divisornow)
                {
                    divisornow = divisornow >> 1;
                    has_righttimes--;
                }
                dividend = dividend - divisornow;
                result += 1 << has_righttimes;
            }
            if (divisor == dividend)
                result++;
            if (!ispositive)
            {
                result *= -1;
            }
            return result;
        }
    }
}
