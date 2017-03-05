using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_3
{
    class Program
    {
        static void Main(string[] args) 
        {
            //while (MyGame()) ;//吊死鬼游戏
            RunGame(10, 4, 3);
            Console.Read();
        }
        static Boolean MyGame()
        {
            Boolean is_again = true;
            Boolean is_win = false; int chance = 7; Boolean is_found = false;
            int round = Convert.ToInt32(Console.ReadLine());
            if (round == -1)
            {
                return false;
            }
            int int_now = 0;
            char[] s1 = Console.ReadLine().ToCharArray();
            char[] s2 = Console.ReadLine().ToCharArray();
            Console.WriteLine("Round " + round.ToString());
            while (chance != 0 || is_win)
            {
                char temp = s2[int_now];
                is_found = false;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] == temp)
                    {
                        s1[i] = ' ';
                        is_found = true;
                    }
                }
                if (!is_found)
                    chance--;
                is_found = false;
                is_win = Check_is_win(s1);
                int_now++;
                if (int_now >= s2.Length)
                    break;
            }
            if (is_win)
                Console.WriteLine("you win");
            else if (chance == 0)
                Console.WriteLine("you lost");
            else
                Console.WriteLine("you give up");
            return is_again;
        }
        static Boolean Check_is_win(char[] test)
        {
            Boolean result = true;
            foreach (char ch in test)
            {
                if (ch != ' ')
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        static void RunGame(int n, int k, int m)
        {
            Linked link = new Linked(1, k, m);
            for (int i = 1; i <= n; i++)
            {
                link.Add(i);
            }
            while(link.count != 0)
            {
                int node_a = link.NextRemoveOfA().id;
                int node_b = link.NextRemoveOfB().id;
                if(node_a == node_b)
                {
                    Console.WriteLine(link.Remove(node_a));
                }
                else
                {
                    Console.Write(link.Remove(node_a) + ",");
                    Console.WriteLine(link.Remove(node_b));
                }
                Console.WriteLine("-----------next-----------");
                link.A_node = link.A_node.next;
                link.B_node = link.B_node.last;
            }
        }
    }
    class Node //用上双向循环链表不算犯规吧?不算，算小题大做。
    {
        public Node next = null;
        public Node last = null;
        public int id;
        public Node(int thisid)
        {
            id = thisid;
        }
    }
    class Linked
    {
        Node zero = null;
        public int count = 0;
        public Node A_node = null;
        public Node B_node = null;
        int k;int m;
        public Linked(int n,int thisk,int thism)
        {
            zero = new Node(0);
            k = thisk;
            m = thism;
        }
        public int Remove(int ID)
        {
            Node temp = zero;
            if (count == 0)
                return -1;
            while (temp.next != zero)
            {
                temp = temp.next;
                if (temp.id == ID) 
                {
                    temp.last.next = temp.next;
                    temp.next.last = temp.last;
                    temp.id = 0;
                    count--;
                    return ID;
                }
            }
            return -1;
        }
        public int Add(int id)
        {
            Node newnode = new Node(id);
            if (zero.last == null)
            {
                newnode.last = zero;
                newnode.next = zero;
                zero.next = newnode;
                zero.last = newnode;
                A_node = newnode;
            }
            else
            {
                zero.last.next = newnode;
                newnode.last = zero.last;
                zero.last = newnode;
                newnode.next = zero;
            }
            count++;
            B_node = zero.last;
            return count;
        }
        public Node NextRemoveOfA()
        {
            for (int i = 1; i < k; i++) 
            {
                if (A_node.id == 0)
                    i--;
                A_node = A_node.next;
                if (A_node.id == 0)
                    A_node = A_node.next;
            }
            return A_node;
        }
        public Node NextRemoveOfB()
        {
            for (int i = 1; i < m; i++)
            {
                if (B_node.id == 0)
                    i--;
                B_node = B_node.last;
                if (B_node.id == 0)
                    B_node = B_node.last;
            }
            return B_node;
        }
    }
}
