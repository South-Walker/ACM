using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_4_28
{
    class Program
    {
        static int cities = 5;
        static int roads = 5;
        static int[] price = { 10, 10, 20, 12, 13 };
        static int[,] road = new int[cities, cities];

        static void Main(string[] args)
        {
            Pretreatment();
            FullTank(10, 0, 3);
            FullTank(20, 1, 4);
            Console.Read();
        }
        static void Pretreatment()
        {
            for (int a = 0; a < cities; a++)
            {
                for (int b = 0; b < cities; b++)
                {
                    road[a, b] = 10000;
                }
            }
            FillRoad(0, 1, 9);
            FillRoad(0, 2, 8);
            FillRoad(1, 2, 1);
            FillRoad(1, 3, 11);
            FillRoad(2, 3, 7);
        }
        static void FullTank(int c_capacity, int s_starting, int e_goal)
        {
            int[,] BFS = new int[cities, c_capacity + 1];
            Stack<Node> next = new Stack<Node>();
            for (int a = 0; a < cities; a++)
            {
                for (int b = 0; b <= c_capacity; b++)
                {
                    BFS[a, b] = 10000;
                }
            }
            BFS[s_starting, 0] = 0;
            next.Push(new Node(s_starting, 0));
            while (next.Count != 0)
            {
                Node nowstate = next.Pop();
                if (nowstate.fuel < c_capacity && BFS[nowstate.position, nowstate.fuel + 1] > price[nowstate.position] + BFS[nowstate.position, nowstate.fuel])
                {
                    BFS[nowstate.position, nowstate.fuel + 1] = price[nowstate.position] + BFS[nowstate.position, nowstate.fuel];
                    next.Push(new Node(nowstate.position, nowstate.fuel + 1));
                }
                for (int i = 0; i < cities; i++)
                {
                    if (nowstate.fuel >= road[nowstate.position, i] && BFS[i, nowstate.fuel - road[nowstate.position, i]] > BFS[nowstate.position, nowstate.fuel])
                    {
                        BFS[i, nowstate.fuel - road[nowstate.position, i]] = BFS[nowstate.position, nowstate.fuel];
                        next.Push(new Node(i, nowstate.fuel - road[nowstate.position, i]));
                    } 
                }
            }
            if (BFS[e_goal, 0] == 10000)
            {
                Console.WriteLine("impossible");
            }
            else
            {
                Console.WriteLine(BFS[e_goal, 0]);
            }
        }
        static void FillRoad(int index1, int index2, int length)
        {
            road[index1, index2] = length;
            road[index2, index1] = length;
        }
    }
    class Node
    {
        public int position;
        public int fuel;
        public Node(int thisposition,int thisfuel)
        {
            position = thisposition;
            fuel = thisfuel;
        }
    }
}
