using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_1
{
    class Program
    {
        static Dictionary<string, int> roman = new Dictionary<string, int>();
        public static int RomanToInt(string s)
        {
            int result = 0;
            if (roman.Count == 0)
            {
                roman.Add("I", 1);
                roman.Add("V", 5);
                roman.Add("X", 10);
                roman.Add("L", 50);
                roman.Add("C", 100);
                roman.Add("D", 500);
                roman.Add("M", 1000);
            }
            int len = s.Length;string temp;int nowvalue;int value = 0;
            for (int i = len - 1; i >= 0; i--) 
            {
                temp = s.Substring(i, 1);
                nowvalue = roman[temp];
                if (nowvalue >= value)
                {
                    result += nowvalue;
                    value = nowvalue;
                }
                else
                {
                    result = result - nowvalue;
                }
            }
            return result;
        }
        public static string IntToRoman(int num)
        {
            string result = "";
            string[] roman = { "I", "V", "X", "L", "C", "D", "M" };
            int now = 0;int romannow = 0;
            while (num != 0) 
            {
                now = num % 10;
                num = num / 10;
                switch (now)
                {
                    case 1:
                        result = roman[romannow] + result;
                        break;
                    case 2:
                        result = roman[romannow] + roman[romannow] + result;
                        break;
                    case 3:
                        result = roman[romannow] + roman[romannow] + roman[romannow] + result;
                        break;
                    case 4:
                        result = roman[romannow] + roman[romannow + 1] + result;
                        break;
                    case 5:
                        result = roman[romannow + 1] + result;
                        break;
                    case 6:
                        result = roman[romannow + 1] + roman[romannow] + result;
                        break;
                    case 7:
                        result = roman[romannow + 1] + roman[romannow] + roman[romannow] + result;
                        break;
                    case 8:
                        result = roman[romannow + 1] + roman[romannow] + roman[romannow] + roman[romannow] + result;
                        break;
                    case 9:
                        result = roman[romannow] + roman[romannow + 2] + result;
                        break;
                    default:
                        break;
                }
                romannow += 2;
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            Console.Write(LongestPalindrome2("tattarrattat"));
            Console.Read();
        }
        static public string LongestPalindrome2(string s)
        {
            int index = 0;int halfmaxlen = 0;int halfnow = 0;
            char[] source = s.ToCharArray();
            List<char> sourcelist = new List<char>();
            sourcelist.Add('%');
            for (int i = 0; i < source.Length; i++)
            {
                sourcelist.Add(source[i]);
                sourcelist.Add('%');
            }
            for (int i = 0; i < sourcelist.Count; i++)
            {
                halfnow = 0;
                while (true)
                {
                    if (i - halfnow >= 0 && i + halfnow < sourcelist.Count && sourcelist[i - halfnow] == sourcelist[i + halfnow])
                    {
                        halfnow++;
                    }
                    else
                    {
                        if (sourcelist[i] == '%')
                        {
                            halfnow = halfnow - 1;
                            halfnow = halfnow / 2;
                        }
                        else
                        {
                            halfnow = halfnow + 1;
                            halfnow = halfnow / 2;
                        }
                        if (halfnow > halfmaxlen)
                        {
                            index = i;halfmaxlen = halfnow;
                        }
                        break;
                    }
                }
            }
            string aim = "";
            if (sourcelist[index] == '%')
            {
                halfmaxlen = halfmaxlen * 2;
                halfmaxlen = halfmaxlen + 1;
                if (halfmaxlen == 1)
                {
                    return source[0].ToString();
                }
            }
            else
            {
                halfmaxlen = halfmaxlen * 2;
                halfmaxlen = halfmaxlen - 1;
            }
            for (int i = index - halfmaxlen; i <= index + halfmaxlen; i++)
            {
                if (sourcelist[i] != '%')
                    aim += sourcelist[i];
            }
            return aim;
        }
        static public string LongestPalindrome(string s)
        {
            char[] source = s.ToCharArray();
            for (int k = source.Length - 1; k >= 0; k--)
            {
                int[] ret = new int[k + 1];
                for (int p = 1; p < k; p++)
                {
                    int temp = 0;
                    for (int q = 0; q < k;)
                    {
                        while (p < k + 1 && q + 1 < k && source[k - p] == source[k - q]) 
                        {
                            ret[p] = ++temp;
                            p++;
                            q++;
                        }
                        break;
                    }
                }

                int i = 0, j = 0;
                for (i = 0; i < source.Length;)
                {
                    for (j = 0; j < k + 1;) 
                    {
                        if (i < source.Length && source[i] == source[k - j]) 
                        {
                            i++;
                            j++;
                        }
                        else
                        {
                            i = j > 0 ? i - ret[j - 1] : i + 1;
                            break;
                        }
                    }
                    if (j == k)
                    {
                        string aim = "";
                        for (int w = k; w >= 0; w--)
                        {
                            aim += source[w];
                        }
                        return aim;
                    }
                }
            }
            return source[0].ToString();
        }
        static int getStartIndex(string source, string target)
        {
            char[] s = source.ToCharArray();
            char[] t = target.ToCharArray();
            int time = 0;//统计计算的次数
            int[] next = initNext(t);
            int i = 0, j = 0;
            for (i = 0; i < s.Length;)
            {
                for (j = 0; j < t.Length;)
                {
                    time++;
                    if (s[i] == t[j])
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        i = j > 0 ? i - next[j - 1] : i + 1;
                        break;
                    }
                }
                if (j == t.Length)
                    return i - t.Length;
            }
            return -1;
        }
        static int[] initNext(char[] t)
        {
            int[] ret = new int[t.Length];
            for (int i = 1; i < t.Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < t.Length;)
                {
                    while (i < t.Length && j < t.Length && t[i] == t[j]) 
                    {
                        ret[i] = ++temp;
                        i++;
                        j++;
                    }
                    break;
                }
            }
            return ret;
        }
    }
}
