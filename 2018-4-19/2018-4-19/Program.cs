using System;

namespace _2018_4_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution a = new Solution();
            a.KnightProbability(3, 2, 0, 0);
        }
    }
    public class Solution
    {
        public double KnightProbability(int N, int K, int r, int c)
        {
            double[,] newdp = new double[N, N];
            double[,] olddp = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    olddp[i, j] = 1;
                }
            }
            for (int k = 0; k < K; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i >= 2)
                        {
                            if (j >= 1)
                                newdp[i, j] += olddp[i - 2, j - 1];
                            if (j <= N - 2)
                                newdp[i, j] += olddp[i - 2, j + 1];
                        }
                        if (i >= 1)
                        {
                            if (j >= 2)
                                newdp[i, j] += olddp[i - 1, j - 2];
                            if (j <= N - 3)
                                newdp[i, j] += olddp[i - 1, j + 2];
                        }
                        if (i <= N - 3)
                        {
                            if (j >= 1)
                                newdp[i, j] += olddp[i + 2, j - 1];
                            if (j <= N - 2)
                                newdp[i, j] += olddp[i + 2, j + 1];
                        }
                        if (i <= N - 2)
                        {
                            if (j >= 2)
                                newdp[i, j] += olddp[i + 1, j - 2];
                            if (j <= N - 3)
                                newdp[i, j] += olddp[i + 1, j + 2];
                        }
                        newdp[i, j] = newdp[i, j] * 0.125;
                    }
                }
                olddp = newdp;
                newdp = new double[N, N];
            }
            return olddp[r, c];
        }
    }
}
