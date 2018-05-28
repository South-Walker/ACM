using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_16
{
    class Program
    {
        static int row = 5;
        static int nowworking = 0;
        static int column = 6;
        static int[,] map = new int[5, 6];
        static int[,] weight = new int[5, 6];
        static string[,] state = new string[5, 6];
        static void Main(string[] args)
        {
            fill("3 4 1 2 8 6", 0);
            fill("6 1 8 2 7 4", 1);
            fill("5 9 3 9 9 5", 2);
            fill("8 4 1 3 2 6", 3);
            fill("3 7 2 8 6 4", 4);

            while (nowworking != column)
            {
                if (nowworking == 0)
                {
                    for (int i = 0; i < row; i++)
                    {
                        state[i, nowworking] = (i + 1).ToString();
                        weight[i, 0] = map[i, 0];
                    }
                }
                else
                {
                    for (int i = 0; i < row; i++)
                    {
                        int min = 9999999; string now = "";
                        if (i == 0)
                        {
                            if (min > weight[1, nowworking - 1])
                            {
                                min = weight[1, nowworking - 1];
                                now = state[1, nowworking - 1] + " 2";
                            }
                            if (min > weight[0, nowworking - 1])
                            {
                                min = weight[0, nowworking - 1];
                                now = state[0, nowworking - 1] + " 1";
                            }
                            if (min > weight[row - 1, nowworking - 1])
                            {
                                min = weight[row - 1, nowworking - 1];
                                now = state[row - 1, nowworking - 1] + " " + row.ToString();
                            }
                            weight[i, nowworking] = min + map[i, nowworking];
                            state[i, nowworking] = now;
                        }
                        else if (i == row - 1)
                        {
                            if (min > weight[0, nowworking - 1])
                            {
                                min = weight[0, nowworking - 1];
                                now = state[0, nowworking - 1] + " 1";
                            }
                            if (min > weight[i, nowworking - 1])
                            {
                                min = weight[i, nowworking - 1];
                                now = state[i, nowworking - 1] + " " + (i + 1).ToString();
                            }
                            if (min > weight[row - 2, nowworking - 1])
                            {
                                min = weight[row - 2, nowworking - 1];
                                now = state[row - 2, nowworking - 1] + " " + (row - 1).ToString();
                            }
                            weight[i, nowworking] = min + map[i, nowworking];
                            state[i, nowworking] = now;
                        }
                        else
                        {
                            if (min > weight[i - 1, nowworking - 1])
                            {
                                min = weight[i - 1, nowworking - 1];
                                now = state[i - 1, nowworking - 1] + " " + i.ToString();
                            }
                            if (min > weight[i, nowworking - 1])
                            {
                                min = weight[i, nowworking - 1];
                                now = state[i, nowworking - 1] + " " + (i + 1).ToString();
                            }
                            if (min > weight[i + 1, nowworking - 1])
                            {
                                min = weight[i + 1, nowworking - 1];
                                now = state[i + 1, nowworking - 1] + " " + (i + 2).ToString();
                            }
                            weight[i, nowworking] = min + map[i, nowworking];
                            state[i, nowworking] = now;
                        }
                    }
                }
                nowworking++;
            }
            Console.Read();
        }
        static void fill(string input, int nowrow)
        {
            string[] now = input.Split(' ');
            for (int i = 0; i < column; i++)
            {
                map[nowrow, i] = Convert.ToInt32(now[i]);
            }
        }
    }
}
