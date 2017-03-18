using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uva1353
{
    class Program
    {
        static double r = 2;
        static int s = 3;
        static int[] sarray = { 1, 2, 1 };//output should be about 1.7142857
        static int[] tree = new int[100];
        static bool[] is_used = new bool[sarray.Length];
        static double max = 0;
        static void Main(string[] args)
        {
            tree[1] = -1;
            CreateTree(2, 2, s);
            Console.Write(max);
            Console.Read();
        }
        static int Judge(int arrayindex)
        {
            double[] value = new double[arrayindex];
            double[] right = new double[arrayindex];
            double[] left = new double[arrayindex];
            for (int i = arrayindex - 1; i > 0; i--) 
            {
                if (tree[i] == -1)
                {
                    value[i] = value[2 * i] + value[2 * i + 1];
                    double thisleft = value[2 * i] / value[i];
                    double thisright = value[2 * i + 1] / value[i];
                    left[i] = Min(-thisleft + left[2 * i], thisright + left[2 * i + 1]);
                    right[i] = Max(-thisleft + right[2 * i], thisright + right[2 * i + 1]);
                }
                else
                    value[i] = tree[i];
            }
            double now = right[1] - left[1];
            if (now <= r && now > max)
                max = now;
            else if (now >= r) 
                max = r;
            return 0;
        }
        static int CreateTree(int arrayindex,int position,int rest)
        {
            if (rest == 0)
            {
                Judge(arrayindex);
                return 0;
            }
            if (tree[arrayindex/2] != -1)
            {
                CreateTree(arrayindex + 1, position, rest);
            }
            else
            {
                if(rest>position)
                {
                    tree[arrayindex] = -1;
                    CreateTree(arrayindex + 1, position + 1, rest);
                    tree[arrayindex] = 0;
                }
                if (position == 1 && rest > 1)
                    return 0;
                for (int i = 0; i < sarray.Length; i++)
                {
                    if(!is_used[i])
                    {
                        is_used[i] = true;
                        tree[arrayindex] = sarray[i];
                        CreateTree(arrayindex + 1, position - 1, rest - 1);
                        tree[arrayindex] = 0;
                        is_used[i] = false;
                    }
                }
            }

            return 1;
        }
        public static double Max(double a,double b)
        {
            double max = a;
            if (b > a)
                max = b;
            return max;
        }
        public static double Min(double a, double b)
        {
            double min = a;
            if (b < a)
                min = b;
            return min;
        }
    }
}
