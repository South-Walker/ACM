using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uva1353
{
    class Program
    {
        static double r = 1.7143;
        static int s = 4;
        static int[] sarray = { 1, 2, 3, 5 };//output should be about 1.7142857
        static int[] tree = new int[sarray.Length * 2 + 1];
        static bool[] is_used = new bool[sarray.Length];
        static void Main(string[] args)
        {
            tree[1] = -1;
            CreateTree(2, 2, s);
        }
        static int CreateTree(int arrayindex,int position,int rest)
        {
            if (rest == 0)
            {
                //judge
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
    }
}
