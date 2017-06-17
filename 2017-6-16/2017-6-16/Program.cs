using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_6_16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 0, 0, -1, 2, -2 };
            Program a = new Program();
            a.FourSum(nums, 0);
        }
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            qsort(nums, 0, nums.Length - 1);
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> temp = new List<int>();
            if (nums.Length == 0)
                return result;
            int beginindex;int endindex;
            for (int a = 0; a <= nums.Length - 4; a++)
            {
                for (int b = a + 1; b <= nums.Length - 3; b++) 
                {
                    beginindex = b + 1;
                    endindex = nums.Length - 1;
                    while (beginindex < endindex)
                    {
                        if (nums[a] + nums[b] + nums[beginindex] + nums[endindex] > target)
                        {
                            int endnow = nums[endindex];
                            while (beginindex < endindex)
                            {
                                if (endnow == nums[endindex])
                                    endindex--;
                                else
                                    break;
                            }
                        } 
                        else if(nums[a] + nums[b] + nums[beginindex] + nums[endindex] < target)
                        {
                            int beginnow = nums[beginindex];
                            while(beginindex<endindex)
                            {
                                if (beginnow == nums[beginindex])
                                    beginindex++;
                                else
                                    break;
                            }
                        }
                        else
                        {
                            temp.Add(nums[a]);temp.Add(nums[b]);temp.Add(nums[beginindex]);temp.Add(nums[endindex]);
                            result.Add(temp);
                            temp = new List<int>();
                            int endnow = nums[endindex];
                            while (beginindex < endindex)
                            {
                                if (endnow == nums[endindex])
                                    endindex--;
                                else
                                    break;
                            }
                            int beginnow = nums[beginindex];
                            while (beginindex < endindex)
                            {
                                if (beginnow == nums[beginindex])
                                    beginindex++;
                                else
                                    break;
                            }
                        }
                    }

                    int testb = nums[b + 1];
                    while (testb == nums[b])
                    {
                        b++;
                        if (b >= nums.Length - 3)
                            break;
                        testb = nums[b + 1];
                    }
                }
                int testa = nums[a + 1];
                while (testa == nums[a])
                {
                    a++;
                    if (a >= nums.Length - 4)
                        break;
                    testa = nums[a + 1];
                }
            }


            return result;
        }
        public void qsort(int[] nums, int begin, int end)
        {
            if (begin < end)
            {
                int b = begin; int e = end; int temp;
                while (b < e)
                {
                    while (b < e && nums[b] <= nums[e])
                    {
                        b++;
                    }
                    temp = nums[b]; nums[b] = nums[e]; nums[e] = temp;
                    while (b < e && nums[e] >= nums[b])
                    {
                        e--;
                    }
                    temp = nums[b]; nums[b] = nums[e]; nums[e] = temp;
                }
                qsort(nums, begin, b - 1);
                qsort(nums, e + 1, end);
            }
        }


        static string[][] table = new string[10][];
        public IList<string> LetterCombinations(string digits)
        {
            inittable();
            IList<string> result = new List<string>();
            Stack<string> a = new Stack<string>();
            Stack<string> b = new Stack<string>();
            if (digits.Length == 0)
            {
                return result;
            }
            string temp = "";
            a.Push("");
            for (int i = 0; i < digits.Length; i++)
            {
                while (a.Count != 0)
                {
                    temp = a.Pop();
                    int nowindex = Convert.ToInt32(digits[i].ToString());
                    foreach (string now in table[nowindex]) 
                    {
                        b.Push(temp + now);
                    }
                }
                a = b;
                b = new Stack<string>();
            }
            while (a.Count != 0)
            {
                result.Add(a.Pop());
            }
            return result;
        }
        public static void inittable()
        {
            if (table[2] == null)
            {
                for (int i = 2; i < 7; i++)
                {
                    table[i] = new string[3];
                }
                table[7] = new string[4];
                table[8] = new string[3];
                table[9] = new string[4];
                table[2][0] = "a";
                table[2][1] = "b";
                table[2][2] = "c";
                table[3][0] = "d";
                table[3][1] = "e";
                table[3][2] = "f";
                table[4][0] = "g";
                table[4][1] = "h";
                table[4][2] = "i";
                table[5][0] = "j";
                table[5][1] = "k";
                table[5][2] = "l";
                table[6][0] = "m";
                table[6][1] = "n";
                table[6][2] = "o";
                table[7][0] = "p";
                table[7][1] = "q";
                table[7][2] = "r";
                table[7][3] = "s";
                table[8][0] = "t";
                table[8][1] = "u";
                table[8][2] = "v";
                table[9][0] = "w";
                table[9][1] = "x";
                table[9][2] = "y";
                table[9][3] = "z";
            }
        }
    }
}
