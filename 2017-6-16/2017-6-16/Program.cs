using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Program a = new Program();
            a.LetterCombinations("23");
        }
        static string[][] table = new string[10][];
        public IList<string> LetterCombinations(string digits)
        {
            inittable();
            IList<string> result = new List<string>();
            Stack<string> a = new Stack<string>();
            Stack<string> b = new Stack<string>();
            if (digits.Length == 0)
            {
                return result;
            }
            string temp = "";
            a.Push("");
            for (int i = 0; i < digits.Length; i++)
            {
                while (a.Count != 0)
                {
                    temp = a.Pop();
                    int nowindex = Convert.ToInt32(digits[i].ToString());
                    foreach (string now in table[nowindex]) 
                    {
                        b.Push(temp + now);
                    }
                }
                a = b;
                b = new Stack<string>();
            }
            while (a.Count != 0)
            {
                result.Add(a.Pop());
            }
            return result;
        }
        public static void inittable()
        {
            if (table[2] == null)
            {
                for (int i = 2; i < 7; i++)
                {
                    table[i] = new string[3];
                }
                table[7] = new string[4];
                table[8] = new string[3];
                table[9] = new string[4];
                table[2][0] = "a";
                table[2][1] = "b";
                table[2][2] = "c";
                table[3][0] = "d";
                table[3][1] = "e";
                table[3][2] = "f";
                table[4][0] = "g";
                table[4][1] = "h";
                table[4][2] = "i";
                table[5][0] = "j";
                table[5][1] = "k";
                table[5][2] = "l";
                table[6][0] = "m";
                table[6][1] = "n";
                table[6][2] = "o";
                table[7][0] = "p";
                table[7][1] = "q";
                table[7][2] = "r";
                table[7][3] = "s";
                table[8][0] = "t";
                table[8][1] = "u";
                table[8][2] = "v";
                table[9][0] = "w";
                table[9][1] = "x";
                table[9][2] = "y";
                table[9][3] = "z";
            }
        }
    }
}
