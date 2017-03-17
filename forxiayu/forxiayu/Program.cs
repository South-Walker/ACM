using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace forxiayu
{
    class Program
    {
        static string st_input_1 = "8888888899992323";//假设没有数据类型能保存他们
        static string st_input_2 = "2535425234214312315";
        static void Main(string[] args)
        {
            string st_result = "";
            ArrayList sta_input_1 = GetAL(st_input_1);
            ArrayList sta_input_2 = GetAL(st_input_2);
            int al_1 = sta_input_1.Count;
            int al_2 = sta_input_2.Count;
            if (al_1 < al_2)
            {
                for (int i = 0; i < al_1; i++)
                {
                    int int_result = Convert.ToInt32(sta_input_1[i]) + Convert.ToInt32(sta_input_2[i]);
                    if (int_result > 9)
                    {
                        int_result -= 10;
                        sta_input_2[i + 1] = Convert.ToInt32(sta_input_2[i + 1]) + 1;
                    }
                    st_result = int_result + st_result;
                }
                for (int i = al_1; i < al_2; i++)
                    st_result = sta_input_2[i] + st_result;
            }

            Console.Write(st_result);
            Console.Read();
        }
        static ArrayList GetAL(string input)
        {
            ArrayList result = new ArrayList();
            int length = input.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                result.Add(Convert.ToInt32(input.Substring(i, 1)));
            }
            return result;
        }
    }
}
