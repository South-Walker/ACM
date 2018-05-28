using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_15
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /**
 * Definition for an interval.
 */ public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }
 
    public class Solution
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> listintervals = intervals.ToList();
            listintervals.Sort((x, y) =>
            {
                return x.start.CompareTo(y.start);
            });
            List<Interval> result = new List<Interval>();
            if (listintervals.Count == 0)
                return result;
            Interval before = listintervals[0];
            Interval now;
            result.Add(before);
            for (int i = 1; i < listintervals.Count; i++)
            {
                now = listintervals[i];
                if (now.start > before.end)
                {
                    result.Add(now);
                }
                else if (now.end >= before.end) 
                {
                    result[result.Count - 1].end = now.end;
                }
                before = result[result.Count - 1];
            }
            return result;
        }
    }
}
