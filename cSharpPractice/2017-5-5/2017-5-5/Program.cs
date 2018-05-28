using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_5
{
    class Program
    {
        static int[] Park = { 0, 0, 1, 2, 3, 4, 5, 6 };
        static int hight = 2;
        static int[] point = new int[(int)Math.Pow(2, hight + 1)];
        static int blastfloor = (int)Math.Pow(2, hight);
        static int elastfloor = (int)Math.Pow(2, hight + 1) - 1;
        static int needtoput = 0;
        static void Main(string[] args)
        {
            DarkPark();
        }
        static void DarkPark()
        {
            int now;
            for (int i = 1; i <= elastfloor; i++)
            {
                now = Park[i] + Park[i / 2];
                point[i] = now;
            }
            int max = -1;int maxindex = 0;
            for (int i = blastfloor; i <= elastfloor; i++)
            {
                if (max < point[i])
                {
                    max = point[i];
                    maxindex = i;
                }
            }
            for (int i = blastfloor; i <= elastfloor; i++)
            {
                point[i] = max - point[i];
            }
            Set(blastfloor, elastfloor);
            Console.WriteLine(needtoput);
            Console.Read();
        }
        static void Set(int begin, int end)
        {
            if (begin != end)
            {
                for (int i = begin; i <= end; i++)
                {
                    if (i % 2 != 0)
                    {
                        int than = Math.Abs(point[i] - point[i - 1]);
                        needtoput += than;
                        point[i / 2] = Math.Abs(point[i] + point[i - 1] - than) / 2;
                    }
                }
                Set(begin / 2, end / 2);
            }
        }
    }
}
