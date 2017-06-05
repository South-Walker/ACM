using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "a", "aa" };
            Console.WriteLine(LongestCommonPrefix(input));
            Console.Read();
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            char[] now;string result = "";char[] commonsubstring;int min = 999999;int index = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < min) 
                {
                    min = strs[i].Length;
                    index = i;
                    if (min == 0)
                        return "";
                }
            }
            commonsubstring = strs[index].ToCharArray();
            for (int i = 0; i < strs.Length; i++)
            {
                now = strs[i].ToCharArray();
                bool iscommon = true;
                for (int k = 0; k < commonsubstring.Length; k++)
                {
                    if (iscommon && now[k] == commonsubstring[k]) 
                    {
                        continue;
                    }
                    iscommon = false;
                    commonsubstring[k] = '$';
                }
            }
            for (int i = 0; i < commonsubstring.Length; i++)
            {
                if (commonsubstring[i] != '$')
                    result = result + commonsubstring[i];
            }
            return result;
        }
    }
}
