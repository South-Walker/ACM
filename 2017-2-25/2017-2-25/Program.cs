using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_2_25
{
    class Program
    {
        static void Main(string[] args)
        {
            Linked link = new Linked();
            for (int i = 0; i < 100; i++)
            {
                link.Insert(i, i);
            }
            Console.Read();
        }
    }
    class Node//构造节点类
    {
        public Node link;//下一节点
        public object content;//当前节点存储内容
        public Node()
        {
            content = null;
            link = null;
        }
        public Node(object obj)
        {
            content = obj;
            link = null;
        }
    }
    class Linked//构造链类
    {
        protected Node header;//根节点
        public Linked()
        {
            header = new Node("header");
        }
        public Node Find(object obj,Boolean is_return_the_end)
        {
            Node temp = header;
            while (temp.link != null && temp.content != obj) 
            {
                temp = temp.link;
            }
            if (is_return_the_end || temp.content == obj)
                return temp;
            else return new Node();
        }
        public Node Find_Previous(object obj)
        {
            Node temp = header;
            while (temp.link != null && temp.link.content != obj)
            {
                temp = temp.link;
            }
            return temp;
        }
        public void Insert(object acontent,object after)
        {
            Node new_node = new Node(acontent);
            Node temp = Find(after,true);
            new_node.link = temp.link;
            temp.link = new_node;
        }
        public void Remove(object thecontent)
        {
            Node temp = Find_Previous(thecontent);
            if (temp.link != null)
                temp.link = temp.link.link;
        }
    }
}
