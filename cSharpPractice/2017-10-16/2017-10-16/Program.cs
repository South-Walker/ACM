using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_10_16
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> test = new List<Interval>();
            test.Add(new Interval(1, 5));
         //   test.Add(new Interval(6, 9));
            Solution a = new Solution();
            a.Insert(test, new Interval(6, 7));
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
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            List<Interval> result = new List<Interval>();bool inserting = false;

            if (intervals.Count == 0)
            {
                result.Add(newInterval);
                return result;
            }
            if (newInterval.start > intervals[intervals.Count - 1].end)
            {
                intervals.Add(newInterval);
                return intervals;
            }
            Interval now = null;
            for (int i = 0; i < intervals.Count; i++)
            {
                now = intervals[i];
                if (inserting)
                {
                    newInterval.start = Math.Min(newInterval.start, now.start);
                    if (now.start > newInterval.end)
                    {
                        result.Add(newInterval);
                        result.Add(now);
                        inserting = false;
                    }
                    else if (newInterval.end <= now.end)
                    {
                        newInterval.end = now.end;
                        result.Add(newInterval);
                        inserting = false;
                    }
                }
                else
                {
                    if (now.end < newInterval.start || now.start > newInterval.end) 
                    {
                        result.Add(now);
                        continue;
                    }
                    else
                    {
                        inserting = true;
                        i--;
                    }
                }
            }
            if (inserting) 
                result.Add(newInterval);
            return result;
        }
    }
}
