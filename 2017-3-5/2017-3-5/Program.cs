using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_5
{
    class Program
    {

        static string Binput = "0100000101101100011100101000";
        static string Tinput = "$#**\\";
        static string[][] codearray = new string[9][];
        static void Main(string[] args)
        {
            PullCodeToArray(Tinput);
            Console.Read();
        }
        static void PullCodeToArray(string input)
        {
            int lennow = 1;int numnow = 0;
            int end = input.Length;
            for (int i = 0; i < end; i++)
            {
                codearray[lennow] = new string[Squared(lennow) - 1];
                string temp = input.Substring(i, 1);
                codearray[lennow][numnow] = temp;
                if (numnow == (Squared(lennow) - 2))
                {
                    numnow = 0;lennow++;
                    codearray[lennow] = new string[Squared(lennow) - 1];
                }
                else
                    numnow++;
            }
        }
        static int Squared(int input)
        {
            int result = 2;
            for (int i = 1; i < input; i++)
                result *= 2;
            return result;
        }
    }

}
