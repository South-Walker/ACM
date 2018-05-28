using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Point a1 = new Point(0, 0);
            Point a2 = new Point(1, 6);
            Point a3 = new Point(2, 3);
            Point a4 = new Point(5, 2);
            Point a5 = new Point(6, 5);
            Point a6 = new Point(7, 1);
            Point a7 = new Point(8, 4);
            List<Point> points = new List<Point>();
            points.Add(a1);
            points.Add(a2);
            points.Add(a3);
            points.Add(a4);
            points.Add(a5);
            points.Add(a6);
            points.Add(a7);
            double answer = s.双调欧几里得旅行商(points);
            Console.WriteLine();
        }
    }
    public class Solution
    {
        public double 双调欧几里得旅行商(List<Point> points)
        {
            int length = points.Count;
            //一维下标小于等于二维下标
            double[,] d = new double[length, length];
            d[0, 1] = Dist(points[0], points[1]);
            for (int j = 2; j < length; j++)
            {
                for (int i = 0; i <= j - 2; i++) 
                {
                    d[i, j] = d[i, j - 1] + Dist(points[j - 1], points[j]);
                }
                //i=j-1
                d[j - 1, j] = int.MaxValue;
                for (int k = 0; k <= j - 2; k++) 
                {
                    double temp = d[k, j - 1] + Dist(points[k], points[j]);
                    if (temp < d[j - 1, j])
                    {
                        d[j - 1, j] = temp;
                    }
                }
            }
            //i必须和i-1连在一起，不然不能成双调环，故，只需找到d[5,6]的最小值即可，因为6与5必然要连一起
            d[length - 1, length - 1] = d[length - 2, length - 1] + Dist(points[length - 1], points[length - 2]);
            return d[length - 1, length - 1];
        }
        public double Dist(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
    public struct Point
    {
        public int X;public int Y;
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
