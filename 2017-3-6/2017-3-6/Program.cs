using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //11059
            /*
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            int[] input = { 2, 4, 0, -3, -1, 5, 7, -9, -4, -4 ,-4};
            int[] array = new int[18];
            int len = input.Length;
            int array_now = 0;
            int max = 0;
            for (int i = 0; i < len; i++)
            {
                if (input[i] == 0)
                {
                    int temp = CalcMax(array, i - 1);
                    if (temp >= max)
                        max = temp;
                    array_now = 0;
                    if (i < len - 1) 
                        continue;
                    else
                        break;
                }
                array[array_now] = input[i];
                array_now++;
            }
            int temp2 = CalcMax(array, array_now - 1);
            if (temp2 >= max)
                max = temp2;

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            Console.WriteLine("The maximum product is " + max.ToString());
            Console.ReadLine();*/
            //725
            #region
               int input = 4;
               int numeral;
               bool is_found = false;
               for (int i = 1234; i <= 49876; i++)
               {
                   numeral = input * i;
                   if (Check(numeral, i))
                   {
                       Console.WriteLine(numeral.ToString() + "/" + i.ToString() + "=" + input.ToString());
                       is_found = true;
                   }
               }
               if (!is_found)  
               {
                   Console.WriteLine("no solutions");
               }
               is_found = false;
               Console.Read();
            #endregion

        }
        static int CalcMax(int[]array,int end)
        {
            int minus = 0;
            int minus_first = 0;
            int minus_last = 0;
            for (int i = 0; i <= end; i++) 
            {
                if (array[i] < 0)
                {
                    minus++;
                    if(minus == 1)
                    {
                        minus_first = i;
                    }
                    minus_last = i;
                }
            }
            if (minus % 2 == 0) 
            {
                return Calc(array, 0, end);
            }
            else
            {
                int right = Calc(array, minus_first + 1, end - 1);
                int left = Calc(array, 0, minus_first - 1);
                if (left > right)
                    return left;
                else
                    return right;
            }
        }
        static int Calc(int[]array,int begin,int end)
        {
            if (end <= begin) 
                return 0;
            int result = 1;
            for (int i = begin; i <= end; i++)
            {
                result *= array[i];
            }
            return result;
        }
        static bool Check(int a, int b) // a is bigger
        {
            if (a >= 98765) 
            {
                return false;
            }
            string temp = a.ToString() + b.ToString();
            int len = temp.Length;
            if (len == 8)
                return false;
            else if (len == 9)
                foreach (char ch in temp)
                {
                    if (ch == '0') 
                        return false;
                }
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (temp.Substring(j, 1) == temp.Substring(i, 1)) 
                        return false;
                }
            }
            return true;
        }
    }
}
