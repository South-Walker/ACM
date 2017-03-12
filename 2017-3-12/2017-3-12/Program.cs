using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_12
{
    class Program
    {
        //140静态变量
        #region
        static string input = "A:FB;B:GC;D:GC;F:AGH;E:HD";
        static Regex regex;
        static int minbandwidth = 100;
        static int max_bandwidth_now = 0;
        static string mins = "";
        static bool[][] is_linked = new bool[8][];
        static string[] st_array = { "A", "B", "C", "D", "E", "F", "G", "H" };
        #endregion
        static void Main(string[] args)
        {
            //140main函数
            #region
            input += ";";
            for (int o = 0; o < 8; o++)
            {
                is_linked[o] = new bool[8];
            }
            for (int i = 0; i < 8; i++)
            {
                regex = new Regex(st_array[i] + ":\\w*;");
                string value = regex.Match(input).Value;
                if (value == "")
                    continue;
                value = value.Substring(2, value.Length - 2);
                foreach (char ch in value)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (st_array[j] == ch.ToString())
                        {
                            is_linked[i][j] = true;
                            is_linked[j][i] = true;
                            break;
                        }
                    }
                }
            }
            Get_All(1, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });

            Console.Write(mintostring(mins)+"=> ");
            Console.Write(minbandwidth);
            Console.Read();
            #endregion
        }
        //140函数
        #region
        static string mintostring(string mins)
        {
            string result = "";
            for (int i = 0; i < mins.Length; i++) 
            {
                result += st_array[Convert.ToInt32(mins.Substring(i, 1))] + " ";
            }
            return result;
        }
        public static void Get_All(int now, int[] array)
        {
            if (now == array.Length - 1)
            {
                Get_Bandwidth(0, array);
            }
            else
            {
                for (int i = now; i < array.Length; i++)
                {
                    int temp = array[i];
                    array[i] = array[now];
                    array[now] = temp;
                    Get_All(now + 1, array);
                    temp = array[i];
                    array[i] = array[now];
                    array[now] = temp;
                }
            }
        }
        public static void Get_Bandwidth(int now, int[] array)
        {
            if (now != 8)
            {
                int temp = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (is_linked[array[now]][i])
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (array[j] == i)
                            {
                                if (temp < Math.Abs(j - now))
                                    temp = Math.Abs(j - now);
                                break;
                            }
                        }
                    }
                }
                if (temp > max_bandwidth_now)
                {
                    max_bandwidth_now = temp;
                }
                temp = 0;
                Get_Bandwidth(now + 1, array);
            }
            else
            {
                if (max_bandwidth_now < minbandwidth)
                {
                    minbandwidth = max_bandwidth_now;
                    string min = "";
                    for (int t = 0; t < 8; t++)
                    {
                        min += array[t];
                        mins = min;
                    }
                }
            }
            max_bandwidth_now = 0;
        }
        #endregion
    }
}
