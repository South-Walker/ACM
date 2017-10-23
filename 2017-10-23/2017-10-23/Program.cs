using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_23
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != 9)
                {
                    return plana(digits);
                }
            }
            return planb(digits);
        }
        public int[] plana(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--) 
            {
                if (digits[i] != 9)
                {
                    digits[i] = digits[i] + 1;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                }
            }
            return digits;
        }
        public int[] planb(int[] digits)
        {
            int[] result = new int[digits.Length + 1];
            result[0] = 1;
            return result;
        }
    }
}
