using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_20
{
    class Program
    {
        #region
        static int process_num = 3;
        static int[] cost = { 0, 1, 1, 1, 1, 1 };
        static int totalmoney = 1;
        static int has_finished = 0;
        static bool[] is_locked = new bool[process_num + 1];
        static Queue[] process_arr = new Queue[process_num + 1];
        static int input_now = 1;
        static Hashtable ht = new Hashtable();
        #endregion
        static void Main(string[] args)
        {
            #region
            /*
            for (int i = 1; i < process_num + 1; i++)
            {
                process_arr[i] = new Queue();
            }
            while(input_now != process_num + 1)
            {
                string input = Console.ReadLine();
                ReadCommand(input);
            }
            while (has_finished != process_num)
            {
                for (int i = 1; i <= process_num; i++)
                {
                    if (process_arr[i].Count == 0)
                        continue;
                    int nowmoney = totalmoney;
                    int task = (int)process_arr[i].Peek();
                    nowmoney = nowmoney - cost[task];
                    while (nowmoney >= 0)
                    {
                        if (is_locked[i] != true)
                        {
                            task = (int)process_arr[i].Dequeue();
                            if (task == 1)
                            {
                                string variable = process_arr[i].Dequeue().ToString();
                                string constant = process_arr[i].Dequeue().ToString();
                                if (!ht.Contains(variable))
                                    ht.Add(variable, constant);
                                else
                                    ht[variable] = constant;
                            }
                            else if (task == 2)
                            {
                                string variable = process_arr[i].Dequeue().ToString();
                                Console.WriteLine(i + ":" + ht[variable]);
                            }
                            else if (task == 3)
                            {
                                for (int j = 1; j < i; j++)
                                {
                                    is_locked[j] = true;
                                }
                                for (int j = i + 1; j <= process_num; j++)
                                {
                                    is_locked[j] = true;
                                }
                            }
                            else if (task == 4)
                            {
                                for (int j = 1; j <= process_num; j++)
                                {
                                    is_locked[j] = false;
                                }
                            }
                        }
                        else
                        {
                            if (task == 2)
                            {
                                process_arr[i].Dequeue();
                                string variable = process_arr[i].Dequeue().ToString();
                                Console.WriteLine(i + ":" + ht[variable]);
                            }
                        }
                        if (process_arr[i].Count == 0)
                        {
                            has_finished++;
                            break;
                        }
                        task = (int)process_arr[i].Peek();
                        nowmoney = nowmoney - cost[task];
                    }
                }
            }
            Console.Read();
            */
            #endregion
            int[] testarray = { 27, 6, 38, 2, 62, 12, 60, 16, 49 };
            QSort(testarray, 0, testarray.Length - 1);
            Console.Read();
        }
        static public int Partition(int[] array, int begin, int end)
        {
            int i = begin;int j = end;
            while (j > i)
            {
                while (j > i && array[i] <= array[j]) i++;
                if (j > i)
                {
                    int temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                    j--;
                }
                while (j > i && array[i] <= array[j]) j--;
                if (j > i)
                {
                    int temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                    i++;
                }
            }
            return j;
        }
        static public void QSort(int[] array, int begin, int end)
        {
            if (begin < end)
            {
                int j = Partition(array, begin, end);
                QSort(array, begin, j - 1);
                QSort(array, j + 1, end);
            }
        }
        static public void ReadCommand(string input)
        {
            if (input == "end")
                input_now++;
            else if (input == "lock")
                process_arr[input_now].Enqueue(3);
            else if (input == "unlock")
                process_arr[input_now].Enqueue(4);
            else if (input.IndexOf('=') > 0)
            {
                string[] str_array = input.Split(' ');
                process_arr[input_now].Enqueue(1);
                process_arr[input_now].Enqueue(str_array[0]);
                process_arr[input_now].Enqueue(str_array[2]);
            }
            else if (input.IndexOf("print") >= 0)
            {
                string[] str_array = input.Split(' ');
                process_arr[input_now].Enqueue(2);
                process_arr[input_now].Enqueue(str_array[1]);
            }
            else
                Console.WriteLine("warning");
        }
    }
}
