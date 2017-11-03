using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.AddBinary("0", "0");
        }
    }
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            string result = "";
            bool isbeyond = false;
            var chars = new Stack<char>();
            int bprocess = b.Length - 1;
            int aprocess = a.Length - 1;
            for (; bprocess >= 0 && aprocess >= 0; bprocess--, aprocess--)  
            {
                if (isbeyond) 
                {
                    #region isbeyond = true
                    if (a[aprocess] == '1')
                    {
                        if (b[bprocess] == '0')
                        {
                            chars.Push('0');
                        }
                        else
                        {
                            chars.Push('1');
                        }
                    }
                    else
                    {
                        if (b[bprocess] == '0')
                        {
                            chars.Push('1');
                            isbeyond = false;
                        }
                        else
                        {
                            chars.Push('0');
                        }
                    }
                    #endregion
                }
                else
                {
                    #region isbeyond = false
                    if (a[aprocess] == '1')
                    {
                        if (b[bprocess] == '0')
                        {
                            chars.Push('1');
                        }
                        else
                        {
                            chars.Push('0');
                            isbeyond = true;
                        }
                    }
                    else
                    {
                        if (b[bprocess] == '0')
                        {
                            chars.Push('0');
                        }
                        else
                        {
                            chars.Push('1');
                        }
                    }
                    #endregion
                }
            }
            while (aprocess >= 0) 
            {
                char now = a[aprocess];
                if (isbeyond)
                {
                    if (now == '1')
                    {
                        chars.Push('0');
                    }
                    else
                    {
                        chars.Push('1');
                        isbeyond = false;
                    }
                }
                else
                    chars.Push(now);
                aprocess--;
            }
            while (bprocess >= 0)
            {
                char now = b[bprocess];
                if (isbeyond)
                {
                    if (now == '1')
                    {
                        chars.Push('0');
                    }
                    else
                    {
                        chars.Push('1');
                        isbeyond = false;
                    }
                }
                else
                    chars.Push(now);
                bprocess--;
            }
            if (isbeyond)
            {
                chars.Push('1');
            }
            while (chars.Count != 0)
            {
                result += chars.Pop();
            }
            return result;
        }
    }
}
