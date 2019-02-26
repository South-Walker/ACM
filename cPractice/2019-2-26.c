#include <stdio.h>
#define MAX 99999
int now[100];
int matrix[100][100];
int n,m,k;
int min=MAX;
void find(int row)
{
	int from=0,to=0;
	int sum=now[0];
	int size;
	while(1)
	{
		size=(to-from+1)*row;
		if(sum>=k)
		{
			min=(min>size)?size:min;
			sum-=now[from];
			from++;
		}
		else
		{
			to++;
			if(to==m)
				return;
			sum+=now[to];
		}
		if(from>to)
		{
			to++;
			if(to==m)
				return;
			sum+=now[to];
		}
	}
}
int q1()
{
	int i,j,l,p;
	scanf("%d%d%d",&n,&m,&k);
	for(i=0;i<n;i++)
	{
		for(j=0;j<m;j++)
		{
			scanf("%d",&matrix[i][j]);
		}
	}
	for(i=0;i<n;i++)
	{
		for(l=0;l<m;l++)
		{
			now[l]=0;
		}
		for(l=i;l<n;l++)
		{
			for(j=0;j<m;j++)
			{
				now[j]+=matrix[l][j];
			}
			find(l-i+1);
		}
	}
	if(min==MAX)
	{
		printf("-1");
	}
	else
	{
		printf("%d",min);
	}
}

//0ÊÇ2; 
int num[110000];
int primenum[10000];
int q2()
{
	int i,j,time,v,count=0;
	for(i=0;i<110000;i++)
	{
		num[i]=1;
	}
	for(i=0;count<10000;i++)
	{
		if(num[i]==0)
		{
			continue;
		}
		primenum[count]=i+2;
		count++;
		j=2;v=j*(i+2);
		while(v<=110000)
		{
			j++;
			num[v-2]=0;
			v=j*(i+2);
		}
		//printf("%d ",primenum[count-1]);
	}
	while(scanf("%d",&k)!=EOF)
	{
		printf("%d\n",primenum[k-1]);
	}
}

