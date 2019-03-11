#include <stdio.h>
int map[21][21];
int check[21];
int now[21];
int nowcount=0;
int routenum=0;
int before[21];
int dist;
void printfnow()
{
	int i;
	for(i=0;i<nowcount;i++)
	{
		printf("%d",now[i]);
		if(i!=nowcount-1)
		{
			printf(" ");
		}
	}
	printf("\n");
}
void getall(int position)
{
	int i,j;
	if(position==dist)
	{
		printfnow();
		routenum++;
		return;
	}
	for(i=2;i<21;i++)
	{
		if(map[i][position]!=0&&check[i]==0)
		{
			check[i]=1;
			now[nowcount]=i;
			nowcount++;
			getall(i);
			nowcount--; 
			check[i]=0;
		}
	}
}
void addroad(int i,int j)
{
	int min,max;
	int temp;
	max=(i>j)?i:j;
	min=i+j-max;
	while(before[max]>min)
	{
		max=before[max];
	}
	if(before[max]==min)
		return;
	else
	{
		temp=before[max];
		before[max]=min;
		addroad(temp,min);
	}
}
int islink()
{
	int temp=dist;
	while(1)
	{
		temp=before[temp];
		if(temp==1)
			return 1;
		if(temp==0)
			return 0;
	}
}
void q1()
{
	int i,j;
	int a,b;
	int casenum=0;
	while(1)
	{
		casenum+=1;
		nowcount=0;
		routenum=0;
		for(i=0;i<21;i++)
		{
			for(j=0;j<21;j++)
			{
				map[i][j]=0;
			}
			check[i]=0;
			before[i]=0;
		}
		if(scanf("%d",&dist)<=0)
		{
			return;
		}
		while(1)
		{
			scanf("%d%d",&a,&b);
			if(a==0&&b==0)
			{
				break;
			}
			map[a][b]=1;
			map[b][a]=1;
			addroad(a,b);
		}
		check[1]=1;
		now[nowcount]=1;
		nowcount++;
		printf("CASE %d:\n",casenum);
		if(islink())
			getall(1);
		printf("There are %d routes from the firestation to streetcorner %d.\n",routenum,dist);
	}
}
int q2()
{
	long long a,b,c;
	int i=0;
	int n;
	scanf("%d",&n);
	while(n!=i)
	{
		i++;
		scanf("%lld%lld%lld",&a,&b,&c);
		if(a+b>c)
		{
			printf("Case #%d: true\n",i);
		}
		else
		{
			printf("Case #%d: false\n",i);
		}
	}
	return 0;
}
int q3()
{
	int num[1001];
	int n;
	int i;
	int sign=1;
	int a4count=0;
	double a4=0;
	int a1=0,a2=0,a3=0,a5=0;
	scanf("%d",&n);
	for(i=0;i<n;i++)
	{
		scanf("%d",&num[i]);
	}
	for(i=0;i<n;i++)
	{
		if(num[i]%10==0)
		{
			a1+=num[i];
		}
		else if(num[i]%5==1)
		{
			a2+=num[i]*sign;
			sign*=-1;
		}
		else if(num[i]%5==2)
		{
			a3++;
		}
		else if(num[i]%5==3)
		{
			a4count++;
			a4+=num[i];
		}
		else if(num[i]%5==4)
		{
			a5=(a5>num[i])?a5:num[i];
		}
	}
	if(a1==0)
	{
		printf("N ");
	}
	else
	{
		printf("%d ",a1);
	}
	if(a2==0)
	{
		printf("N ");
	}
	else
	{
		printf("%d ",a2);
	}
	if(a3==0)
	{
		printf("N ");
	}
	else
	{
		printf("%d ",a3);
	}
	if(a4==0)
	{
		printf("N ");
	}
	else
	{
		
		a4/=a4count;
		printf("%.1f ",a4);
	}
	if(a5==0)
	{
		printf("N");
	}
	else
	{
		printf("%d",a5);
	}
	return 0;
}
int q4()
{
	int num[110001];
	int i,j;
	int m,n;
	int outputnum=0;
	for(i=0;i<110001;i++)
	{
		num[i]=1;
	}
	for(i=2;i<1000;i++)
	{
		if(num[i]==1)
		{
			for(j=i+1;j<110001;j++)
			{
				if(0==j%i)
					num[j]=0;
			}
		}
	}
	scanf("%d %d",&m,&n);
	i=2;
	while(outputnum!=m)
	{
		if(num[i])
		{
			outputnum++;
		}
		i++;
	}
	i--;
	while(1)
	{
		if(num[i])
		{
			printf("%d",i);
			if(outputnum==n)
				break;
			if((outputnum-m+1)%10!=0)
			{
				printf(" ");
			}
			else
			{
				printf("\n");
			}
			outputnum++;
		}
		i++;
	}
	return 0;
}

int main()
{
	q1();
	return 0;
} 
