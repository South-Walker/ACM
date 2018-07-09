#include <stdio.h>
#include <malloc.h>

int main()
{
	ecnu11();
}
void ecnu11()
{
	char s[51];
	int i,j;
	int len=0;
	char now='a';
	int dp[51][27];
	char litter[27]="abcdefghijklmnopqrstuvwxyz\0";
	scanf("%s",s);
	while(1)
	{
		if(s[len]=='\0')
		{
			len++;
			break;
		}
		len++;
	}
	for(i=0;i<len;i++)
	{
		for(j=0;j<26;j++)
		{
			dp[i][j]=0;
		}
	}
	for(i=0;i<51;i++)
	{
		for(j=0;j<27;j++)
		{
			if(i!=0)
			{
				if(j!=0)
				{
					dp[i][j]=(dp[i-1][j]>dp[i][j-1]+1)?dp[i][j-1]+1:dp[i-1][j];
					if(s[i-1]==litter[j-1])
					{
						dp[i][j]=(dp[i][j]>dp[i-1][j-1])?dp[i-1][j-1]:dp[i][j];
					}
				}
				else
				{
					dp[i][j]=dp[i-1][j];
				}
			}
			else if(j!=0)
			{
				dp[i][j]=dp[i][j-1]+1;
			}
			else
			{
				dp[i][j]=0;
			}
		}
	}
	printf("%d",dp[len-1][26]);
} 
void ecnu10()
{
	unsigned int pow[32];
	int i,j,n;
	int p,q;
	int casenum;
	int count;
	scanf("%d",&casenum);
	count=0;
	while(casenum)
	{
		casenum--;
		count++;
		scanf("%d",&n);
		pow[0]=1;
		for(i=1;i<32;i++)
		{
			pow[i]=pow[i-1]*2;
		}
		for(i=31;i>=0;i--)
		{
			if(pow[i]<=n)
			{
				n-=pow[i];
				i--; 
				break;
			}
		}
		p=1;
		q=1;
		for(;i>=0;i--)
		{
			if(n>=pow[i])
			{
				n-=pow[i];
				p+=q;
			}
			else
			{
				q+=p;
			}
		}
		printf("Case %d: %d/%d",count,p,q);
		if(casenum)
		{
			printf("\n");
		}
	}
}
void ecnu9()
{
	int n,m;
	int i,j;
	int now;
	scanf("%d%d",&n,&m);
	for(i=0;i<n;i++)
	{
		now=i+1;
		for(j=0;j<m;j++)
		{
			printf("%d",now);
			now+=n;
			if(j!=m-1)
			{
				printf(" ");
			}
			else
			{
				printf("\n");
			}
		}
	}
}
