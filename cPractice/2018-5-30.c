#include <stdio.h>
# include <malloc.h> 
//ecnu 1015
void main()
{
	int n,m;
	int i,j,k;
	long long dp[6][51];
	dp[1][0]=1;
	dp[1][1]=1;
	for(i=2;i<6;i++)
	{
		dp[i][0]=1;
		dp[i][1]=2;
	}
	for(i=1;i<6;i++)
	{
		for(j=2;j<51;j++)
		{
			if(j<i)
			{
				dp[i][j]=2*dp[i][j-1];
			}
			else if(j==i)
			{
				dp[i][j]=2*dp[i][j-1]-1;
			}
			else
			{
				dp[i][j]=0;
				//m=3,x²»·Å£¬o·Å 
				//??x
				//?xo
				//xoo
				for(k=1;k<=i;k++)
				{
					dp[i][j]+=dp[i][j-k];
				}
				//dp[i][j]=dp[i][j-1]*2-dp[i][j-i-1];
			}
		}
	}
    while(scanf("%d %d",&n,&m)!=EOF)
    {
		printf("%lld\n",dp[m][n]);
	}
}
