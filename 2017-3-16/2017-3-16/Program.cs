using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2017_3_16
{
    class Program
    {
        static string input = "ladder came tape soon leader acme RIDE lone Dreis peat ScAlE orb eye Rides dealer NotE derail LaCeS drIed noel dire Disk mace Rob dries";
        static void Main(string[] args)
        {
            string[] all = input.Split(' ');
            ArrayList arr = new ArrayList();
            for (int i = 0; i < all.Length; i++) 
            {
                string now = all[i];
                for (int k = i + 1; k < all.Length; k++)
                {
                    if (is_left(now, all[k]) == -1)
                    {
                        string temp = all[k];
                        all[k] = now;
                        now = temp;
                    }
                    all[i] = now;
                }
            }
            for (int i = 0; i < all.Length; i++)
            {
                string now = all[i];
                for (int k = i + 1; k < all.Length; k++) 
                {
                    if (ssort(now) == ssort(all[k]))
                    {
                        arr.Add(i);
                        arr.Add(k);
                    }
                }
            }
            for (int i = 0; i < all.Length; i++)
            {
                bool could_used = false;
                foreach(object a in arr)
                {
                    if (i == (int)a)
                        could_used = true;
                }
                if (!could_used)
                {
                    Console.WriteLine(all[i]);
                }
            }
            Console.Read();
        }
        static string ssort(string str)
        {
            char[] charr = str.ToLower().ToCharArray();
            for (int i = 0; i < charr.Length; i++)
            {
                char now = charr[i];
                for (int k = i; k < charr.Length; k++)
                {
                    char test = charr[k];
                    if (test < now)
                    {
                        charr[k] = now;
                        now = test;
                    }
                }
                charr[i] = now;
            }
            return new string(charr);
        }
        static int is_left(string test, string standard)
        {
            if (test == standard)
                return 0;
            int length = test.Length;
            if (standard.Length < length)
                length = standard.Length;
            for (int i = 0; i < length; i++)
            {
                if (test.Substring(i, 1).ToLower().ToCharArray()[0] > standard.Substring(i, 1).ToLower().ToCharArray()[0]) 
                {
                    return -1;
                }
                if (test.Substring(i, 1).ToLower().ToCharArray()[0] < standard.Substring(i, 1).ToLower().ToCharArray()[0])
                {
                    return 1;
                }
            }
            if (test.Length <= standard.Length)
                return 1;
            else
                return -1;
        }
    }
}
