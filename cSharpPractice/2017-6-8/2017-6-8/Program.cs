using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p1 = new Program();
            Console.Write(p1.isMatch("a", "ab*"));
            Console.Read();
        }
        public bool MYIsMatch(string s, string p)
        {
            Check(s.ToCharArray(), p.ToCharArray(), 0, 0);
            return temp;
        }
        bool temp = false;
        public void Check(char[] cs, char[] cp, int indexs, int indexp)
        {
            if (indexs >= cs.Length && indexp >= cp.Length)
            {
                temp = true;
                return;
            }
            char after = '$';char nows;char nowp;
            while (indexp < cp.Length)
            {
                nows = (indexs >= cs.Length) ? '$' : cs[indexs];
                nowp = cp[indexp];
                if (indexp < cp.Length - 1)
                {
                    after = cp[indexp + 1];
                }
                if (after != '*')
                {
                    if (nows == '$')
                        return;
                    if (nowp == '.' || nowp == nows)
                    {
                        indexp++; indexs++;
                    }
                    else
                    {
                        return;
                    }
                }
                else//if(after=='*')
                {
                    Check(cs, cp, indexs, indexp + 2);
                    while (indexs < cs.Length) 
                    {
                        nows = cs[indexs];
                        if (nowp == '.' || nows == nowp) 
                        {
                            Check(cs, cp, indexs + 1, indexp + 2);
                        }
                        else
                            break;
                        indexs++;
                    }
                    break;
                }
            }
            if (indexs >= cs.Length && indexp >= cp.Length)
            {
                temp = true;
                return;
            }
        }
        public bool isMatch(String s, String p)
        {
            if (s.Length == 0 && p.Length == 0)
                return true;
            if (p.Length == 0)
                return false;
            bool[,] res = new bool[s.Length + 1,p.Length + 1];
            res[0,0] = true;
            for (int j = 0; j < p.Length; j++)
            {
                if (p[j] == '*')
                {
                    if (j > 0 && res[0,j - 1]) res[0,j + 1] = true;
                    if (j < 1) continue;
                    if (p[j - 1] != '.')
                    {
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (res[i + 1,j] || j > 0 && res[i + 1,j - 1]
                            || i > 0 && j > 0 && res[i,j + 1] && s[i] == s[i - 1] && s[i - 1] == p[j - 1])
                                res[i + 1,j + 1] = true;
                        }
                    }
                    else
                    {
                        int i = 0;
                        while (j > 0 && i < s.Length && !res[i + 1,j - 1] && !res[i + 1,j])
                            i++;
                        for (; i < s.Length; i++)
                        {
                            res[i + 1,j + 1] = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == p[j] || p[j] == '.')
                            res[i + 1,j + 1] = res[i,j];
                    }
                }
            }
            return res[s.Length, p.Length];
        }
    }
}
