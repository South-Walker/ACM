using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_11
{
    class Program
    {
        static string[] letter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "N", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        static bool is_end = false;
        static bool is_now_true = false;
        static void Main(string[] args)
        {
            int k = 70;
            int l = 26;
            int is_4 = 0;
            int is_16 = 0;
            string aim = "";
            k--;is_4++;aim += "A";Console.Write(aim);
            while (k != 0 && !is_end) 
            {
                for (int i = 0; i < l; i++)
                {
                    is_repeat(aim, letter[i], 1);
                    if (is_now_true)  
                    {
                        is_now_true = false;
                        aim += letter[i];
                        if (is_16 != 0 && is_16 % 16 == 0)
                        {
                            Console.WriteLine();
                            is_16++;
                        }
                        else if (is_4 != 0 && is_4 % 4 == 0)
                        {
                            is_16++;
                            Console.Write(" ");
                        }
                        Console.Write(letter[i]);
                        k--;
                        is_4++;
                        break;
                    }
                }
            }
            Console.Read();
        }
        static void is_repeat(string aim, string next, int now_worklenth)
        {
            string testaim = aim + next;
            if (2 * now_worklenth > testaim.Length)
            {
                is_now_true = true;
            }
            else
            {
                string subaim = testaim.Substring(testaim.Length - now_worklenth, now_worklenth);
                string anothersub = testaim.Substring(testaim.Length - 2 * now_worklenth, now_worklenth);
                if (subaim == anothersub)
                { }
                else
                    is_repeat(aim, next, now_worklenth + 1);
            }
        }
    }
}
