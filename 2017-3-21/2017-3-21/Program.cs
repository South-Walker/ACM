using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_21
{
    class Program
    {
        static void Main(string[] args)
        {
            q3_21();
        }
        static void q3_21()
        {
            int max = Convert.ToInt32(Console.ReadLine());
            string aim = "";
            do
            {
                aim = Console.ReadLine();
                q3_21_check(ref aim, max);
            } while (aim != "0");
        }
        static void q3_21_check(ref string aim, int max)
        {
            Stack<int> stack = new Stack<int>();
            string[] aimarray = aim.Split(' ');
            int[] aimintarray = new int[aimarray.Length + 1];
            for (int i = 1; i <= aimarray.Length; i++)
            {
                aimintarray[i] = Convert.ToInt32(aimarray[i - 1]);
            }
            int totaltrue = 1;int search = 1;
            while (search != max + 1)
            {
                if (search <= max && aimintarray[totaltrue] == search) 
                {
                    totaltrue++;
                    search++;
                }
                else if (stack.Count != 0 && stack.Peek() == aimintarray[totaltrue]) 
                {
                    stack.Pop();
                    totaltrue++;
                }
                else
                {
                    stack.Push(search);
                    search++;
                }
            }
            if (totaltrue == max + 1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
