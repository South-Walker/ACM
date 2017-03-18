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
        static Queue[] team = new Queue[1000];
        static Dictionary<int, int> ht = new Dictionary<int, int>();
        static Queue main = new Queue();
        static void Main(string[] args)
        {
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
            ReadCommand(command);
        }
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
        }
    }
}
