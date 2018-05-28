using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_2
{
    class Program
    {

        static void Main(string[] args)
        {
            //     Deposits(5, 5, "****@\r\n*@@*@\r\n*@**@\r\n@@@*@\r\n@@**@");
         //   Transfiguration();
        }
        static void Transfiguration()
        {
            string[] words = { "so", "soon", "river", "goes", "them", "got", "moon", "begin", "big" };
            Dictionary<string, bool> HasTransed = new Dictionary<string, bool>();
            HasTransed.Add("b", true);
            Stack<string> WaitingRoom = new Stack<string>();
            WaitingRoom.Push("b");
            while (WaitingRoom.Count != 0)
            {
                string a = WaitingRoom.Pop();
                foreach (string now in words) 
                {
                    if (now.Substring(0, 1) == a)
                    {
                        string waittransed = now.Substring(now.Length - 1, 1);
                        bool thisisfalse = false;
                        if (!HasTransed.TryGetValue(waittransed, out thisisfalse))
                        {
                            HasTransed.Add(waittransed, true);
                            WaitingRoom.Push(waittransed);
                        }
                    }
                }
            }
            Console.Read();
        }
        static void Deposits(int a, int b,string input)
        {
            int[,] deposit = new int[a, b];
            input = input.Replace("\r", "");
            string[] arrinput = input.Split('\n');
            string now;
            for (int i = 0; i < a; i++) 
            {
                for (int k = 0; k < b; k++) 
                {
                    now = arrinput[i].Substring(k, 1);
                    if (now == "@")
                    {
                        deposit[i, k] = 1;
                    }
                    else if (now == "*") 
                    {
                        deposit[i, k] = 0;
                    }
                }
            }
            int num = 0;
            for (int i = 0; i < a; i++)
            {
                for (int k = 0; k < b; k++)
                {
                    if (deposit[i, k] == 1)
                    {
                        num++;
                        TurnStar(i, k, deposit);
                    }
                }
            }
            Console.WriteLine(num);
            Console.Read();
        }
        static void TurnStar(int a, int b, int[,] deposit)
        {
            if (deposit[a, b] == 1) 
            {
                deposit[a, b] = 0;
                if (a > 0)
                    TurnStar(a - 1, b, deposit);
                if (a < deposit.GetLength(0) - 1) 
                    TurnStar(a + 1, b, deposit);
                if (b > 0)
                    TurnStar(a, b - 1, deposit);
                if (b < deposit.GetLength(1) - 1) 
                    TurnStar(a, b + 1, deposit);
            }
        }
    }
}
