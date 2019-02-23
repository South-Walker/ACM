#include <stdio.h> 
typedef struct
{
	unsigned long long u;
	unsigned long long d;
}nums;
void printfnums(nums r)
{
	char output[50]; 
	int io=0,i;
	while(r.u)
	{
		output[io]=r.u%10+'0';
		r.u/=10;
		io++; 
	}
	for(i=io-1;i>=0;i--)
	{
		putchar(output[i]);
	}
	putchar('/');
	io=0;
	while(r.d)
	{
		output[io]=r.d%10+'0';
		r.d/=10;
		io++; 
	}
	for(i=io-1;i>=0;i--)
	{
		putchar(output[i]);
	}
	putchar('\n');
}
unsigned long long getmin(unsigned long long a,unsigned long long b)
{
	if(a%b==0)
		return b;
	else
		return getmin(b,a%b);
	
}
unsigned long long getmax(unsigned long long a,unsigned long long b)
{
	unsigned long long min=getmin(a,b);
	unsigned long long r=a/min*b;
	return r;
}
nums add(nums a,nums b)
{
	unsigned long long max=getmax(a.d,b.d);
	unsigned long long min;
	unsigned long long au=a.u*(max/a.d);
	unsigned long long bu=b.u*(max/b.d);
	unsigned long long allu=au+bu;
	min=getmin(max,allu);
	nums r;
	r.u=allu/min;
	r.d=max/min;
	return r;
}
int q1()
{
	int t;
	unsigned long long a,b,c;
	nums all[3];
	nums temp;
	nums r;
	unsigned long long u,d;
	int i,j;
	char output[50];
	char io;
	scanf("%d",&t);
	while(t)
	{
		for(i=0;i<3;i++)
		{
			scanf("%lld/%lld",&u,&d);
			all[i].u=u;
			all[i].d=d;
		}
		a=all[0].u*all[1].d*all[2].d+all[1].u*all[0].d*all[2].d+all[2].u*all[0].d*all[1].d;
		b=all[0].d*all[1].d*all[2].d;
		c=getmin(a,b);
		printf("%lld/%lld\n",a/c,b/c);
//		temp=add(all[0],all[1]);
//		r=add(all[2],temp);
//		printfnums(r);
		t--;
	}
	return 0;
}
int q2()
{
	int enums[1001];
	int count,i;
	double total;
	double max=0;
	int temp;
	while(scanf("%d",&count)!=EOF)
	{
		total=0;
		max=0;
		for(i=0;i<count;i++)
		{
			scanf("%d",&temp);
			enums[i]=temp;
			max=(max>enums[i])?max:enums[i];
			total+=enums[i];
		}
		if(total-max>=max)
		{
			printf("%.1f\n",(float)total/2); 
		}
		else
		{
			printf("%.1f\n",(float)total-(float)max);
		}
	}
	return 0;
}
int q3()
{
	int r,c;
	int i,j,k;
	int before;
	int a;
	int dot;
	char nows[50001];
	char all[50001][50001];
	scanf("%d%d",&r,&c);
	for(i=0;i<r;i++)
	{
		scanf("%s",nows);
		for(j=0;j<c;j++)
		{
			all[i][j]=nows[j];
		}
	}
	for(j=0;j<c;j++)
	{
		before=0;
		a=0;
		dot=0;
		for(i=0;i<r;i++)
		{
			if(all[i][j]=='#')
			{
				for(k=before;k<i;k++)
				{
					if(dot)
					{
						all[k][j]='.';
						dot--;
					}
					else if(a)
					{
						all[k][j]='a';
						a--;
					}
				}
				before=i+1;
			}
			else if(all[i][j]=='.')
			{
				dot++;
			}
			else
			{
				a++;
			}
		}
		for(k=before;k<r;k++)
		{
			if(dot)
			{
				all[k][j]='.';
				dot--;
			}
			else if(a)
			{
				all[k][j]='a';
				a--;
			}
		}
	}
	for(i=0;i<r;i++)
	{
		for(j=0;j<c;j++)
		{
			printf("%c",all[i][j]);
		}
		printf("\n");
	}
	return 0;
}
int check[5];
int all[5];
int answer;
void solution(int now,int value)
{
	int i;
	if(value==23&&now==5)
	{
		answer=1;
		return;
	}
	if(answer)
	{
		return;
	}
	for(i=0;i<5;i++)
	{
		if(check[i])
			continue;
		check[i]=1;
		if(now==0)
		{
			solution(now+1,all[i]);
		}
		else
		{
			solution(now+1,value+all[i]);
			solution(now+1,value-all[i]);
			solution(now+1,value*all[i]);
		}
		check[i]=0;
	}
}
int q4()
{
	int i,j,k;
	int flag=1;
	while(1)
	{
		answer=0;
		for(i=0;i<5;i++)
		{
			scanf("%d",&all[i]);
			check[i]=0;
			if(all[i]!=0)
			{
				flag=0;
			}
		}
		if(flag)
		{
			break;
		}
		solution(0,0);
		if(answer)
		{
			printf("Possible\n");
		}
		else
		{
			printf("Impossible\n");
		}
		flag=1;
	}
	return 0;
}

int getlen(char*s)
{
	int i=0;
	while(*s)
	{
		i++;
		s++;
	}
	return i;
}
char snow[310];
char s[310];
int dp[310][310];
int dpstate[310][310];
int max;
void getmaxsub(int abegin,int bbegin,int len)
{
	int aend=bbegin-1;
	int bend=len-1;
	int i,j,k;
	int max,state;
	for(i=0;i+abegin<=aend;i++)
	{
		for(j=0;j+bbegin<=bend;j++)
		{
			dp[i][j]=0;
			dpstate[i][j]=0;
		}
	}
	for(i=0;i+abegin<=aend;i++)
	{
		for(j=0;j+bbegin<=bend;j++)
		{
			max=-1;
			if(i==0||j==0)
			{
				if(i==0)
				{
					if(j==0)
					{
						if(s[abegin+i]==s[bbegin+j])
						{
							dp[i][j]=1;
						}
						else
						{
							dp[i][j]=0;
						}
					}
					else
					{
						if(s[abegin+i]==s[bbegin+j])
						{
							dp[i][j]=1;
						}
						else
						{
							dp[i][j]=dp[i][j-1];
							dpstate[i][j]=3;
						}
					}
				}
				else if(j==0)
				{
					//i!=0;
					if(s[abegin+i]==s[bbegin+j])
					{
						dp[i][j]=1;
					}
					else
					{
						dp[i][j]=dp[i-1][j];
						dpstate[i][j]=2;
					}
				}
				
			}
			if(s[abegin+i]==s[bbegin+j])
			{
				max=dp[i-1][j-1]+1;
				dpstate[i][j]=1;
			}
			if(max<dp[i-1][j])
			{
				max=dp[i-1][j];
				dpstate[i][j]=2;
			}
			if(max<dp[i][j-1])
			{
				max=dp[i][j-1];
				dpstate[i][j]=3;
			}
			dp[i][j]=max;
		}
	}
	
}
int q5()
{
	int i,j,len,now,p,k;
	int psnow;
	while(1)
	{
		scanf("%s",s);
		max=0;
		if(s[0]=='#'&&s[1]=='E'&&s[2]=='N'&&s[3]=='D'&&s[4]=='\0')
		{
			break;
		}
		len=getlen(s);
		for(j=1;j<len;j++)
		{
			getmaxsub(0,j,len);
			if(max<dp[j-1][len-1-j])
			{
				max=dp[j-1][len-1-j];
				psnow=max;
				snow[psnow]='\0';
				p=j-1;k=len-1-j;
				while(psnow)
				{
					psnow--;
					while(1)
					{
						if(dpstate[p][k]==1)
						{
							break;
						}
						else if(dpstate[p][k]==2)
						{
							p--;
						}
						else if(dpstate[p][k]==3)
						{
							k--;
						}
					}
					snow[psnow]=s[p];
					p--;k--;
				}
				
			}
		}
		
		printf("%s",snow);
		printf("\n");
	}
	return 0;
}
