using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_27
{
    class Program
    {
        static int begin = 1;
        static int end = 4;
        static int stationnum = 4;
        static int cxnum = 1;
        static int exnum = 4;
        static int[,] cxmap = new int[stationnum + 1, stationnum + 1];
        static int[,] exmap = new int[stationnum + 1, stationnum + 1];
        static int[] prenode = new int[stationnum + 1];

        static void Main(string[] args)
        {
            Airport();
        }
        static void Airport()
        {
            Fill(ref cxmap, 2, 4, 3);
            Fill(ref exmap, 1, 2, 2);
            Fill(ref exmap, 1, 3, 3);
            Fill(ref exmap, 2, 4, 4);
            Fill(ref exmap, 3, 4, 5);
            for (int i = 1; i <= stationnum; i++)
            {
                for (int k = 1; k <= stationnum; k++)
                {
                    if (cxmap[i, k] == 0)
                        cxmap[i, k] = 101;
                    if (exmap[i, k] == 0)
                        exmap[i, k] = 101;
                }
            }
            int[] DijkstraFromBegin = new int[stationnum + 1];
            int[] DijkstraFromEnd = new int[stationnum + 1];
            int[] DijkstraMapFromBegin = new int[stationnum + 1];
            int[] DijkstraMapFromEnd = new int[stationnum + 1];
            for (int i = 1; i < stationnum + 1; i++)
            {
                DijkstraFromBegin[i] = 100 * stationnum;
                DijkstraFromEnd[i] = 100 * stationnum;
            }
            
            for (int i = 1; i <= stationnum; i++)
            {
                DijkstraMapFromBegin[i] = 100 * stationnum;
                DijkstraMapFromEnd[i] = 100 * stationnum;
            }

            DijkstraFromBegin[begin] = DijkstraFromEnd[end] = 0;
            DijkstraMapFromBegin[begin] = DijkstraMapFromEnd[end] = 0;
            prenode[begin] = prenode[0] = -1;
            for (int i = 1; i <= stationnum; i++) 
            {
                int minroute = 101;
                int minnum = 0;
                for (int a = 1; a <= stationnum; a++)
                {
                    if (DijkstraMapFromBegin[a] != -1 && DijkstraMapFromBegin[a] < minroute) 
                    {
                        minroute = DijkstraMapFromBegin[a];
                        minnum = a;
                    }
                }
                DijkstraMapFromBegin[minnum] = -1;
                DijkstraFromBegin[minnum] = minroute;
                for (int a = 1; a <= stationnum; a++)
                {
                    if (DijkstraMapFromBegin[a] != -1 && exmap[a, minnum] + minroute < DijkstraMapFromBegin[a])
                    {
                        DijkstraMapFromBegin[a] = exmap[a, minnum] + minroute;
                    } 
                }


                minroute = 101;
                minnum = 0;
                for (int a = 1; a <= stationnum; a++)
                {
                    if (DijkstraMapFromEnd[a] != -1 && DijkstraMapFromEnd[a] < minroute)
                    {
                        minroute = DijkstraMapFromEnd[a];
                        minnum = a;
                    }
                }
                DijkstraMapFromEnd[minnum] = -1;
                DijkstraFromEnd[minnum] = minroute;
                for (int a = 1; a <= stationnum; a++)
                {
                    if (DijkstraMapFromEnd[a] != -1 && exmap[a, minnum] + minroute < DijkstraMapFromEnd[a])
                    {
                        DijkstraMapFromEnd[a] = exmap[a, minnum] + minroute;
                        prenode[a] = minnum;
                    }
                }
            }
            int min = DijkstraFromEnd[begin];
            int cxcost;
            bool is_usecx = false;
            int cxstation = 0;
            for (int i = 1; i <= stationnum; i++)
            {
                for (int k = 1; k <= stationnum; k++)
                {
                    cxcost = cxmap[i, k];
                    if (min > DijkstraFromBegin[i] + DijkstraFromEnd[k] + cxcost)
                    {
                        min = DijkstraFromBegin[i] + DijkstraFromEnd[k] + cxcost;
                        is_usecx = true;
                        cxstation = i;
                    }
                }
            }
            int node = prenode[begin];
            Console.Write(begin + " ");
            while (node != end) 
            {
                Console.Write(node + " ");
                node = prenode[node];
            }
            Console.Write(end);
            Console.WriteLine();
            if (is_usecx)
            {
                Console.WriteLine(cxstation);
            }
            else
            {
                Console.WriteLine("Ticket Not Used");
            }
            Console.WriteLine(min);
            Console.Read();
        }
        static void Fill(ref int[,] map, int index1, int index2, int length)
        {
            map[index1, index2] = length;
            map[index2, index1] = length;
        }
    }
}
