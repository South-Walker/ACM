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
        static int readed = 0;
        static string[][] codearray = new string[9][];
        static void Main(string[] args)
        {
            PullCodeToArray(Tinput);int len_now;
            while(true)
            {
                if (readed == Binput.Length)
                    break;
                len_now = GetLen();
                if (len_now == 0)
                    break;
                while (true)
                {
                    string now = Binput.Substring(readed, len_now);
                    int output = BSttoInt(now);
                    readed += len_now;
                    if (output == Squared(len_now) - 1)
                        break;
                    else
                        Console.Write(codearray[len_now][output]);
                }
            }
            Console.Read();
        }
        static void PullCodeToArray(string input)
        {
            codearray[1] = new string[1];
            int lennow = 1;int numnow = 0;
            int end = input.Length;
            for (int i = 0; i < end; i++)
            {
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
        static int GetLen()
        {
            string len = Binput.Substring(readed, 3);
            int result = Convert.ToInt32(len.Substring(0, 1)) * 4 + Convert.ToInt32(len.Substring(1, 1)) * 2 + Convert.ToInt32(len.Substring(2, 1));
            readed += 3;
            return result;
        }
        static int BSttoInt(string bst)
        {
            int result = 0;int num = 1;
            for (int i = bst.Length; i > 0; i--)
            {
                result += Convert.ToInt32(bst.Substring(i - 1, 1)) * num;
                num *= 2;
            }
            return result;
        }
    }

}
