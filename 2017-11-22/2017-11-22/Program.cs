using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_11_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.NumTrees(5);
        }
    }
    public class Solution
    {
        static int[] dptable = new int[30];
        public int NumTrees(int n)
        {
            if (n == 0)
                return n;
            dptable[1] = 1;
            dptable[0] = 1;
            dptable[2] = 2;
            if (dptable[n] == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (dptable[i] == 0)
                    {
                        int now = 0;
                        for (int k = 0;; k++)
                        {
                            if ((i - 1) % 2 == 0 && k == (i - 1) / 2)
                                break;
                            if ((i - 1) % 2 != 0 && k == (i + 1) / 2)
                                break;
                            now = now + dptable[k] * dptable[i - 1 - k];
                        }
                        now *= 2;
                        if ((i - 1) % 2 == 0)
                        {
                            now += dptable[(i - 1) / 2] * dptable[(i - 1) / 2];
                        }
                        dptable[i] = now;
                    } 
                }
            }
            return dptable[n];
        }
    }
}
