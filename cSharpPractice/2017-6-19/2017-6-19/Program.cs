namespace _2017_6_19
{
    public class Program
    {

        public static void Main()
        {
            string line;
            while ((line = System.Console.ReadLine()) != null)
            {//注意while处理多个case
                #region 1
                /*
                int i = 0;int j = 0;
                for (int k = 0; k < line.Length; k++)
                {
                    if (line[k] == 'B')
                    {
                        i++;
                    }
                    k++;
                    if (k >= line.Length)
                        break;
                    if (line[k] == 'W')
                    {
                        i++;
                    }
                }
                for (int k = 0; k < line.Length; k++)
                {
                    if (line[k] == 'W')
                    {
                        j++;
                    }
                    k++;
                    if (k >= line.Length)
                        break;
                    if (line[k] == 'B')
                    {
                        j++;
                    }
                }
                if (i <= j)
                    Console.WriteLine(i);
                else
                    Console.WriteLine(j);*/
                #endregion
                #region 2
                /*
                if (line.Length == 1)
                {
                    System.Console.WriteLine(1);
                    break;
                }
                char before = line[0];char now;int times = 1;
                for (int i = 1; i < line.Length; i++)
                {
                    now = line[i];
                    if (now != before)
                    {
                        times++;
                    }
                    before = line[i];
                }
                System.Console.WriteLine(times);*/
                #endregion
                #region 3
                /*
                string[] firstline = line.Split(' ');
                line = System.Console.ReadLine();
                string[] secondline = line.Split(' ');
                third(System.Convert.ToInt32(firstline[1]), secondline);
                */
                #endregion
                #region 4
                /*
                line = System.Console.ReadLine();
                string[] array = line.Split(' ');
                int times = 0;
                bool isrepate = false;
                for (int i = 0; i < array.Length - 1; i++) 
                {
                    for (int k = i + 1; k < array.Length; k++) 
                    {
                        if (array[i] != array[k])
                        {
                            times++;
                        }
                        else
                            isrepate = true;
                    }
                }
                if (isrepate)
                    times++;
                System.Console.WriteLine(times);*/
                #endregion
                #region 5
                if (line.Length <= 1)
                    System.Console.WriteLine(0);
                int uglypoint = 0;int nowindex = 0;
                while (nowindex < line.Length)
                {
                    if (line[nowindex] != '?')
                    {
                        break;
                    }
                    else
                        nowindex++;
                }
                if (nowindex == line.Length)
                {
                    System.Console.WriteLine(0);
                    continue;
                }
                char before = line[nowindex];char now;
                for (int i = nowindex + 1; i < line.Length; i++) 
                {
                    now = line[i];
                    if (now == '?')
                    {
                        if (before == 'A')
                            now = 'B';
                        else
                            now = 'A';
                    }
                    else
                    {
                        if (now == before)
                            uglypoint++;
                    }
                    before = now;
                }
                System.Console.WriteLine(uglypoint);
                #endregion
            }
        }
        public static void third(int before, string[] feed)
        {
            for (int i = 0; i < feed.Length; i++)
            {
                if (before.ToString() == feed[i])
                {
                    before = before * 2;
                }
            }
            System.Console.WriteLine(before);
        }
    }
}
