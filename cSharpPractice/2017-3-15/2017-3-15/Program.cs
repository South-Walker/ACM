using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace _2017_3_15
{
    class Program
    {
        static int num_static = 0;static ArrayList[] all;
        static void Main(string[] args)
        {
            if (num_static == 0)
            {
                num_static = Convert.ToInt32(Console.ReadLine());
                all = new ArrayList[num_static];
                for (int i = 0; i < num_static; i++)
                {
                    all[i] = new ArrayList();
                    all[i].Add(i); 
                }
            }
            string command = Console.ReadLine();
            CheckInput(command, args);
            Main(args);
        }
        static public void CheckInput(string command, string[] args)
        {
            Regex regex = new Regex("(?<moveorpile>[a-z]+) (?<firstnum>[0-9]+) (?<ontoorover>[a-z]+) (?<secondnum>[0-9]+)");
            Match match = regex.Match(command);
            GroupCollection groupcollection = match.Groups;
            if (command == "quit")
            {
                for (int i = 0; i < num_static; i++)
                {
                    Console.Write(i.ToString() + ":");
                    int length = all[i].Count;
                    for (int k = 0; k < length; k++)
                    {
                        Console.Write(" " + all[i][k]);
                    }
                    Console.WriteLine();
                }
            }
            else if (groupcollection["moveorpile"].Value == "move")
            {
                if (groupcollection["ontoorover"].Value == "onto")
                {
                    int a = Convert.ToInt32(groupcollection["firstnum"].Value);
                    int b = Convert.ToInt32(groupcollection["secondnum"].Value);
                    move_onto(a, b);
                }
                else if (groupcollection["ontoorover"].Value == "over")
                {
                    int a = Convert.ToInt32(groupcollection["firstnum"].Value);
                    int b = Convert.ToInt32(groupcollection["secondnum"].Value);
                    move_over(a, b);
                }
            }
            else if (groupcollection["moveorpile"].Value == "pile") 
            {

                if (groupcollection["ontoorover"].Value == "onto")
                {
                    int a = Convert.ToInt32(groupcollection["firstnum"].Value);
                    int b = Convert.ToInt32(groupcollection["secondnum"].Value);
                    pile_onto(a, b);
                }
                else if (groupcollection["ontoorover"].Value == "over")
                {
                    int a = Convert.ToInt32(groupcollection["firstnum"].Value);
                    int b = Convert.ToInt32(groupcollection["secondnum"].Value);
                    pile_over(a, b);
                }
            }
        }
        static void move_onto(int a, int b)
        {
            int[] a_position = Query(a);//a所在位置，index = 0 表示栈序号，index = 1，表示栈中位置。
            int a_length = all[a_position[0]].Count;//a所处栈的长度
            for (int i = a_position[1] + 1; i < a_length; i++)
            {
                all[(int)all[a_position[0]][a_position[1] + 1]].Add(all[a_position[0]][i]);//将a之后的元素放回原来位置.
                all[a_position[0]].RemoveAt(a_position[1] + 1);//删除a之后的元素
            }
            int[] b_position = Query(b);
            int b_length = all[b_position[0]].Count;
            for (int i = b_position[1] + 1; i < b_length; i++)
            {
                all[(int)all[b_position[0]][a_position[1] + 1]].Add(all[b_position[0]][i]);
                all[b_position[0]].RemoveAt(b_position[1] + 1);
            }
            all[b_position[0]].Add(a);
            all[a_position[0]].RemoveAt(a_position[1]);
        }
        static void move_over(int a, int b)
        {
            int[] a_position = Query(a);//a所在位置，index = 0 表示栈序号，index = 1，表示栈中位置。
            int a_length = all[a_position[0]].Count;//a所处栈的长度
            for (int i = a_position[1] + 1; i < a_length; i++)
            {
                all[(int)all[a_position[0]][a_position[1] + 1]].Add(all[a_position[0]][i]);//将a之后的元素放回原来位置.
                all[a_position[0]].RemoveAt(a_position[1] + 1);//删除a之后的元素
            }
            int[] b_position = Query(b);
            all[b_position[0]].Add(a);
            all[a_position[0]].RemoveAt(a_position[1]);
        }
        static void pile_onto(int a, int b)
        {
            int[] b_position = Query(b);//b所在位置，index = 0 表示栈序号，index = 1，表示栈中位置。
            int b_length = all[b_position[0]].Count;//b所处栈的长度
            for (int i = b_position[1] + 1; i < b_length; i++)
            {
                all[(int)all[b_position[0]][b_position[1] + 1]].Add(all[b_position[0]][i]);//将b之后的元素放回原来位置.
                all[b_position[0]].RemoveAt(b_position[1] + 1);//删除b之后的元素
            }
            int[] a_position = Query(a);
            int a_length = all[a_position[0]].Count;
            for (int i = a_position[1]; i < a_length; i++)
            {
                all[b_position[0]].Add(all[a_position[0]][a_position[1]]);
                all[a_position[0]].RemoveAt(a_position[1]);
            }
        }
        static void pile_over(int a, int b)
        {
            int[] b_position = Query(b);
            int[] a_position = Query(a);
            int a_length = all[a_position[0]].Count;
            for (int i = a_position[1]; i < a_length; i++)
            {
                all[b_position[0]].Add(all[a_position[0]][a_position[1]]);
                all[a_position[0]].RemoveAt(a_position[1]);
            }
        }
        static int[] Query(int aim)
        {
            int[] result = new int[2];
            for (int i = 0; i < num_static; i++)
            {
                int length = all[i].Count;
                for (int k = 0; k < length; k++)
                {
                    if ((int)all[i][k] == aim)
                    {
                        result[0] = i;
                        result[1] = k;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
