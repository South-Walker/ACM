using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_5_31
{
    class Program
    {
        static void Main(string[] args)
        {
            LengthOfLongestSubstring("bb");
        }
        public static string Convert2(string s, int numRows)
        {
            if (s == "")
                return "";
            if (numRows == 1)
                return s;
            string temp = "";
            char[] array = s.ToCharArray();
            int len = s.Length;int n;int num = 0;
            for (int i = 1; i <= numRows; i++)
            {
                num = 0;
                n = 2 * numRows * num - 2 * num + i;
                while (n <= len)
                {
                    temp += array[n - 1];
                    num++;
                    if (i != 1 && i != numRows) 
                    {
                        n = 2 * numRows * num - 2 * num - i + 2;
                        if (n <= len)
                            temp += array[n - 1];
                    }
                    n = 2 * numRows * num - 2 * num + i;
                }
            }
            return temp;
        }
        public static string Convert(string s, int numRows)
        {
            if (s == "")
                return "";
            if (numRows == 1)
                return s;
            Queue<string>[] arraylist = new Queue<string>[numRows];
            for (int i = 0; i < arraylist.Length; i++) 
            {
                arraylist[i] = new Queue<string>();
            }
            int len = s.Length;string temp;
            int now = 0;int index;
            while(true)
            {
                temp = s.Substring(now, 1);
                index = now % (2 * numRows - 2);
                if (index < numRows - 1) 
                {
                    arraylist[index].Enqueue(temp);
                }
                else
                {
                    index = 2 * numRows - 2 - index;
                    arraylist[index].Enqueue(temp);
                }
                now++;
                if (now == len)
                    break;
            }
            temp = "";
            for (int i = 0; i < arraylist.Length; i++)
            {
                Queue<string> nowq = arraylist[i];
                while (nowq.Count != 0)
                {
                    temp = temp + nowq.Dequeue();
                }
            }
            return temp;
        }
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            double y = x;
            double z = 0;
            while (true)
            {
                z = z * 10 + x % 10;
                x = x / 10;
                if (x == 0)
                    break;
            }
            return (z == y) ? true : false;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, bool> hashtable = new Dictionary<char, bool>();

            int end = 0; char temp; int nowmax = 0; char now; int max = 0;int len = s.Length;int begin = 0;char[] array = s.ToCharArray();
            for (; end < len; end++) 
            {
                now = array[end];
                if (hashtable.ContainsKey(now) && hashtable[now]) 
                {
                    nowmax = end - begin;
                    if (nowmax > max)
                        max = nowmax;
                    nowmax = 0;
                    for (; begin < end; begin++)
                    {
                        temp = array[begin];
                        if (temp == now)
                        {
                            begin++;
                            break;
                        }
                        else
                        {
                            hashtable[temp] = false;
                        }
                    }
                }
                else
                {
                    hashtable[now] = true;
                }
            }
            nowmax = end - begin;
            if (nowmax > max)
                max = nowmax;
            return max;
        }
    }
}
