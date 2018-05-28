using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] g = { 10, 9, 8, 7 }; int[] s = { 5, 6, 7, 8 };
            Solution a = new Solution();
            a.FindContentChildren(g, s);
        }
    }
    public class Solution
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            if (g.Length == 0 || s.Length == 0)
                return 0;
            qsort(g, 0, g.Length - 1);
            qsort(s, 0, s.Length - 1);
            int answer = 0;int sindex = -1;
            for (int i = 0; i < g.Length; i++)
            {
                while (s.Length > sindex + 1)
                {
                    sindex++;
                    if (s[sindex] >= g[i])
                    {
                        answer++;
                        break;
                    }
                }
            }
            return answer;
        }
        public void qsort(int[] array, int begin, int end)
        {
            Action<int, int> swap = (int b, int e) =>
              {
                  int temp = array[b];
                  array[b] = array[e];
                  array[e] = temp;
              };
            if (end <= begin)
                return;
            int nowb = begin;int nowe = end;
            while (nowe > nowb) 
            {
                while (nowe > nowb && array[nowb] < array[nowe]) 
                {
                    nowb++;
                }
                if (nowe > nowb)
                {
                    swap(nowe, nowb);
                    nowe--;
                }
                while (nowe > nowb && array[nowb] < array[nowe])
                {
                    nowe--;
                }
                if (nowe > nowb)
                {
                    swap(nowe, nowb);
                    nowb++;
                }
            }
            qsort(array, begin, nowb - 1);
            qsort(array, nowe + 1, end);
        }
    }
}
