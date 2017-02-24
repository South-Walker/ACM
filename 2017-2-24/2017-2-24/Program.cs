using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace _2017_2_24
{
    class Program
    {
        public enum MyEnum
        {
            one = 1, ten = 10
        }
        static int[] input = { 21, 22, 34, 66, 43, 22, 65, 76, 83, 99, 96, 43, 25, 87, 5, 8 };
        static int[] output = new int[input.Count()];
        static void Main(string[] args)
        {
            Queue[] queuearray = new Queue[10];
            for (int i = 0; i < 10; i++)
            {
                queuearray[i] = new Queue();
            }
            Sort(queuearray, MyEnum.one);
            BuildArray(queuearray, input);
            foreach (int a in input)
            {
                Console.Write(a.ToString() + " ");
            }
            Console.WriteLine();
            Sort(queuearray, MyEnum.ten);
            BuildArray(queuearray, output);
            foreach (int a in output)
            {
                Console.Write(a.ToString() + " ");
            }
            Console.ReadLine();

        }
        public static void Sort(Queue[] queuearray,MyEnum group)
        {
            if(group == MyEnum.one)
            {
                foreach(int a in input)
                {
                    int i = a % 10;
                    queuearray[i].Enqueue(a);
                }
            }
            else
            {
                foreach (int a in input)
                {
                    int i = a / 10;
                    queuearray[i].Enqueue(a);
                }

            }
        }
        public static void BuildArray(Queue[]queuearray,int[]intarray)
        {
            int i = 0;
            foreach(Queue queue in queuearray)
            {
                while(queue.Count!=0)
                {
                    intarray[i] = Convert.ToInt32(queue.Dequeue());
                    i++;
                }
            }
        }
    }
    
}
