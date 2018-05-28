using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_18
{
    class Program
    {
        #region
        /*
        static Queue[] team = new Queue[1000];
        static Dictionary<int, int> ht = new Dictionary<int, int>();
        static Queue main = new Queue();*/
        #endregion
        static void Main(string[] args)
        {
            #region
            /*
            ht.Add(259001, 0);
            ht.Add(259002, 0);
            ht.Add(259003, 0);
            ht.Add(259004, 0);
            ht.Add(259005, 0);
            ht.Add(260001, 1);
            ht.Add(260002, 1);
            ht.Add(260003, 1);
            ht.Add(260004, 1);
            ht.Add(260005, 1);
            ht.Add(260006, 1);
            string command = Console.ReadLine();
            ReadCommand(command);*/
            #endregion
            int[] test = { 32131, 55, 78, 2, 35, 7645, 23, 7, 3, 98, 34, 5, 24, 6 };
            MergeSort(test, 0, test.Length - 1);
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i]);
            }
            Console.Read();
        }
        #region
        /*
        static public void ReadCommand(string command)
        {
            if(command == "enqueue")
            {
                int i = Convert.ToInt32(Console.ReadLine());
                Enqueue(i);
                string anocommand = Console.ReadLine();
                ReadCommand(anocommand);
            }
            else if(command == "dequeue")
            {
                Dequeue();
                string anocommand = Console.ReadLine();
                ReadCommand(anocommand);
            }
            else
            {

            }
        }
        static public void Enqueue(int id)
        {
            int teamid = ht[id];
            if (team[teamid] == null)
            {
                team[teamid] = new Queue();
                main.Enqueue(teamid);
            }
            team[teamid].Enqueue(id);
        }
        static public void Dequeue()
        {
            int id = (int)main.Peek();
            if (team[id].Count != 0)
                Console.WriteLine(team[id].Dequeue());
            else
            {
                main.Dequeue();
                Dequeue();
            }
        }*/
        #endregion
        static void MergeSort(int[] array, int first, int last)//这个应该是归并大脑，负责递归对半拆分数组，将任务分配给sortcore，我也不知道为什么他这么命名
        {
            if (first != last) //即至少有1的数组长度
            {
                int mid = (first + last) / 2;
                MergeSort(array, first, mid);
                MergeSort(array, mid + 1, last);
                SortCore(array, first, mid, last);//这个过程显然是在只有长度1的数组的时候才会开始调用的，那么这两个长度1的数组毫无疑问是有序的，一开始是将两个1的数组整合成2，然后2变4。。同时要保证有序性
            }
        }
        static void SortCore(int[]array,int first,int mid,int last)
        {
            int beginA = first;
            int beginB = mid + 1;
            int[] result = new int[last - first + 1];
            int resultindex = 0;
            while (beginA <= mid && beginB <= last)
            {
                if (array[beginA] <= array[beginB])
                {
                    result[resultindex] = array[beginA];
                    resultindex++;
                    beginA++;
                }
                else
                {
                    result[resultindex] = array[beginB];
                    resultindex++;
                    beginB++;
                }
            }
            while (beginA <= mid)
            {
                result[resultindex] = array[beginA];
                resultindex++;
                beginA++;
            }
            while(beginB<=last)
            {
                result[resultindex] = array[beginB];
                resultindex++;
                beginB++;
            }
            resultindex = 0;
            for (int i = first; i <= last; i++)
            {
                array[i] = result[resultindex];
                resultindex++;
            }
        }
    }
}
