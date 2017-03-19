using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_3_19
{
    class Program
    {
        static void Main(string[] args)
        {
            q_5(5, 24);
            Console.Read();
        }
        static public void q_5(Double r, double n)
        {
            double min = 1000000;
            double lasttime = 0;
            double all = 1000000;
            r = r / 1200 + 1;
            double i = 8333;//假设1W，10年还
            double total = i * n;
            while (true)
            {
                for (int k = 1; k <= n; k++)
                {
                    all *= r;
                    all = all - i;
                }
                i++;
                if (all < 100) 
                {
                    if (min > Math.Abs(all))
                    {
                        min = Math.Abs(all);
                        lasttime = i - 1;
                    }
                    if (all < -100)
                        break;
                }
                all = 1000000;
            }
            Console.Write(lasttime);
        }
        static public int q_4(string s1, string s2)
        {
            char x = s1.ToCharArray()[0];
            char y = s2.ToCharArray()[0];

            if (x < y) return -1;
            if (x > y) return 1;

            int t = q_4(s1.Substring(1), s2.Substring(1));
            if (t == 0) return 0;
            return (t / (Math.Abs(t))) * (Math.Abs(t) + 1);
        }
        static public void q_3()
        {
            string[] letter = { "q", "p", "o", "n", "m", "l", "k", "j", "i", "h", "g", "f", "e", "d", "c", "b", "a" };
            string input = "bckfqlajhemgiodnp";
            char[] charr = input.ToCharArray();
            for (int i = 0; i < charr.Length; i++)
            {
                string now = charr[i].ToString();
                for (int k = 0; k < letter.Length; k++)
                {
                    if (letter[k] == now)
                    {
                        Console.Write(k+" ");
                        break;
                    }
                }
            }
            Console.Read();

        }
        static public void q_2()
        {
            int[] array = new int[10];
            int now = 100;
            while (now <= 998)
            {
                for (int i = 1; i < 10; i++)
                {
                    int first = now * i;
                    if (first >= 1000 || first < 100)
                    {
                        continue;
                    }
                    for (int j = 1; j < 10; j++)
                    {
                        int second = now * j;
                        if (second >= 1000 || second < 100)
                        {
                            continue;
                        }
                        for (int k = 1; k < 10; k++)
                        {
                            int third = now * k;
                            if (third >= 1000 || third < 100)
                            {
                                continue;
                            }
                            array[i] += 1;
                            array[j] += 1;
                            array[k] += 1;
                            CheckFour(first, second, third, now, array);
                            array = new int[10];
                        }
                    }
                }
                now++;
            }
        }
        static public bool CheckFour(int one, int two, int third, int four, int[] array)
        {
            int total = one + two * 10 + third * 100;
            if (total > 99999)
                return false;
            else
            {
                SubCheck(array, total % 1000);
                int wan = total / 10000;
                int qian = total / 1000 - wan * 10;
                array[wan] += 1;
                array[qian] += 1;
            }
            SubCheck(array, one);
            SubCheck(array, two);
            SubCheck(array, third);
            SubCheck(array, four);
            foreach(int a in array)
            {
                if (a != 2)
                    return false;
            }
            Console.WriteLine(total);
            Console.Read();
            return true;
        }
        static public void SubCheck(int[] array, int a)
        {
            int bai = a / 100;
            int shi = a / 10 - bai * 10;
            int ge = a % 10;
            array[bai] += 1;
            array[shi] += 1;
            array[ge] += 1;
        }
    }
}
