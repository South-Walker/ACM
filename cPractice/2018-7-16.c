#include <stdio.h>
#include <malloc.h>
void main()
{
	eoj22();
}
void eoj22()
{
	int i,j,k,temp,x,len,xnow;
	int *flag;
	int iszerobegin;
	char num[20];
	//dp[len][count][string];
	//count<=len=string-1;
	char dp[20][20][21];
	scanf("%s",num);
	scanf("%d",&x);
	for(i=0;i<20;i++)
	{
		for(j=0;j<20;j++)
		{
			dp[i][j][0]='!';
		}
	}
	for(i=0;i<20;i++)
	{
		for(j=0;j<=i;j++)
		{
			k=0;
			temp=i-j;
			while(temp)
			{
				temp--;
				dp[i][j][k]='9';
				k++;
			}
			while(k<i)
			{
				dp[i][j][k]='1';
				k++;
			}
			dp[i][j][k]='\0';
		}
	}
	len=0;xnow=0;
	while(num[len]!='\0')
	{
		if(num[len]=='0'||num[len]=='1')
		{
			xnow++;
		}
		len++;
	}
	if(xnow==x)
	{
		printf("%s\n",num);
		return;
	}
	for(i=len-1;i>=0;i--)
	{
		while(num[i]!='0')
		{
			if(num[i]=='2')
			{
				xnow++;
			}
			if(i==0&&num[i]=='1')
			{
				xnow--;
			}
			if(num[i]!='0')
			{
				num[i]-=1;
			}
			if(xnow<=x&&dp[len-i-1][x-xnow][0]!='!')
			{
				iszerobegin=1;
				for(j=0;j<=i;j++)
				{
					if(iszerobegin&&num[j]=='0'&&j!=len-1)
						continue;
					else
					{
						iszerobegin=0;
					}
					printf("%c",num[j]);
				}
				printf("%s\n",dp[len-i-1][x-xnow]);
				return;
			}
		}
		if(num[i]=='0'||num[i]=='1')
		{
			xnow--;
		}
	}
	printf("test\n");
}
