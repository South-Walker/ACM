using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_24
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime t1 = DateTime.Now;
            uva122();
            DateTime t2 = DateTime.Now;
            Console.WriteLine(t1.Subtract(t1).Milliseconds);
            Console.Read();
        }
        public static void uva122()
        {
            string input = Console.ReadLine();
            Dictionary<int, string> BTree = new Dictionary<int, string>();
            BTree = Reader(input);
            Print(BTree);
        }
        public static void Print(Dictionary<int, string> input)
        {
            bool is_finish = true;
            Queue<string> answer = new Queue<string>();
            string worry = "not complete";
            if (!input.ContainsKey(1))
            {
                is_finish = false;
                Console.WriteLine(worry);
            }
            else
            {
                int length = Convert.ToInt32(input[0]);
                int now = 1;
                Queue<int> key = new Queue<int>();
                key.Enqueue(now);
                while (length != 0)
                {
                    now = key.Dequeue();
                    if (input.ContainsKey(now))
                    {
                        answer.Enqueue(input[now]);
                        key.Enqueue(now * 2);
                        key.Enqueue(now * 2 + 1);
                        length--;
                    }
                    else { }
                    if (key.Count == 0 && length != 0)
                    {
                        is_finish = false;
                        Console.WriteLine(worry);
                        break;
                    }
                }
                if (is_finish)
                {
                    while (answer.Count != 0)
                    {
                        Console.Write(answer.Dequeue() + " ");
                    }
                }
            }
        }
        public static Dictionary<int,string> Reader(string input)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            string[] allnode = input.Split(' ');
            int length = allnode.Length;
            result.Add(0, (length - 1).ToString());
            string now;int douhao;int key;string st_value;
            for (int i = 0; i < length - 1; i++)
            {
                key = 1;
                now = allnode[i];
                douhao = now.IndexOf(',');
                st_value = now.Substring(1, douhao - 1);
                now = now.Substring(douhao + 1, now.Length - 2 - douhao);
                for (int j = 0; j < now.Length; j++)
                {
                    if (now.Substring(j, 1) == "R")
                    {
                        key = key * 2 + 1;
                    }
                    else key *= 2;
                }
                result.Add(key, st_value);
            }
            return result;
        }
    }
}
