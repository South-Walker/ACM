using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2017_2_23
{
    class Program
    {
        static myStack stack = new myStack();
        static void Main(string[] args)
        {
            Console.Read(); 
        }
        static void changejinzhi(int input)//用栈实现的进制转换
        {
            if(input == 1)
            {
                stack.Push(1);
            }
            else
            {
                stack.Push((input % 2).ToString ());
                changejinzhi(input / 2);
            }
        }
    }
    class myStack
    {
        private int s_index;
        private ArrayList s_list;
        public myStack()
        {
            s_list = new ArrayList();
            s_index = -1;
        }
        public int count
        {
            get
            {
                return s_list.Count;
            }
        }
        public void Push(object item)
        {
            s_list.Add(item);
            s_index++;
        }
        public object Pop()
        {
            object obj = s_list[s_index];
            s_list.RemoveAt(s_index);
            s_index--;
            return obj;
        }
        public void Clear()
        {
            s_list.Clear();
            s_index = -1;
        }
        public object Peek()
        {
            return s_list[s_index];
        }
        public string toString()
        {
            string result = "";
            while (count != 0) 
            {
                result += Pop().ToString();
            }
            return result;
        }
    }//实现push，pop，clear的栈类,打印用toString()
    class myQueue
    {
        private ArrayList q_list;
        public myQueue()
        {
            q_list = new ArrayList();
        }
        public object DeQueue()
        {
            object obj = q_list[0];
            q_list.RemoveAt(0);
            return obj;
        }
        public void EnQueue(object item)
        {
            q_list.Add(item);
        }
        public object Peek()
        {
            return q_list[0];
        }
        public int count
        {
            get
            {
                return q_list.Count;
            }
        }
        public void Clear()
        {
            q_list.Clear();
        }
        public string toString()
        {
            string result = "";
            while (count != 0) 
            {
                result += DeQueue().ToString();
            }
            return result;
        }
    }//实现enqueue，dequeue，clear的队列，打印用toString()
}
