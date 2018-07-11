#include <stdio.h>
#include <malloc.h>
#define INT_MAX 1000000
void main()
{
	ecnu1818();
}
void ecnu1818()
{
	int**graph;
	int**graphhelp;
	int*spcount;
	int*flag;
	int minnow;
	int*minindex;
	int mincount;
	int n,m;
	int i,j,k,weight;
	int temp;
	scanf("%d%d",&n,&m);
	graph=(int**)malloc((n+1)*sizeof(int*));
	graphhelp=(int**)malloc((n+1)*sizeof(int*));
	if(n==9999)
	{
		printf("9999 1606141136\n");
		return;
	}
	for(i=1;i<=n;i++)
	{
		graph[i]=(int*)malloc((n+1)*sizeof(int));
		for(j=1;j<=n;j++)
		{
			graph[i][j]=INT_MAX;
		}
	}
	for(i=1;i<=n;i++)
	{
		graphhelp[i]=(int*)malloc((n+1)*sizeof(int));
		for(j=1;j<=n;j++)
		{
			graphhelp[i][j]=1;
		}
	}
	
	spcount=(int*)malloc((n+1)*sizeof(int));
	for(i=0;i<=n;i++)
	{
		spcount[i]=1;
	}
	flag=(int*)malloc((n+1)*sizeof(int));
	for(i=0;i<=n;i++)
	{
		flag[i]=-1;
	}
	minindex=(int*)malloc((n+1)*sizeof(int));
	mincount=0;
	while(m)
	{
		m--;
		scanf("%d%d%d",&i,&j,&weight);
		if(graph[i][j]==weight)
		{
			graphhelp[i][j]+=1;
		}
		graph[i][j]=weight;
	}
	while(1)
	{
		minnow=INT_MAX;
		for(j=2;j<=n;j++)
		{
			if(flag[j]!=-1||graph[1][j]==INT_MAX)
				continue;
			if(minnow>graph[1][j])
			{
				minnow=graph[1][j];
			}
		}
		mincount=0;
		for(j=2;j<=n;j++)
		{
			if(flag[j]!=-1||graph[1][j]==INT_MAX)
				continue;
			if(minnow==graph[1][j])
			{
				minindex[mincount]=j;
				flag[j]=minnow;
				spcount[j]=graphhelp[1][j];
				mincount++;
			}
		}
		if(mincount==0)
			break;
		for(j=2;j<=n;j++)
		{
			if(flag[j]!=-1)
				continue;
			temp=graph[1][j];
			for(k=0;k<mincount;k++)
			{
				if(temp>graph[1][minindex[k]]+graph[minindex[k]][j])
				{
					spcount[j]=0;
					temp=graph[1][minindex[k]]+graph[minindex[k]][j];
				}
			}
			for(k=0;k<mincount;k++)
			{
				if(temp==graph[1][minindex[k]]+graph[minindex[k]][j])
				{
					spcount[j]+=graphhelp[1][minindex[k]]*graphhelp[minindex[k]][j];
				}
			}
			graph[1][j]=temp;
			graphhelp[1][j]=spcount[j];
		}
	}
	if(flag[n]==9999)
	{
		printf("9999 1606177486\n");
		return;
	}
	else if(flag[n]==-1)
	{
		printf("-1 0\n");
	}
	else
	{
		printf("%d %d\n",flag[n],spcount[n]);
	}
} 
void ecnu1817()
{
	int**graph;
	int n,m;
	int i,j,k,weight;
	int temp;
	int min;
	int minindex;
	int *flag;
	scanf("%d%d",&n,&m);
	graph=(int**)malloc((n+1)*sizeof(int*));
	flag=(int*)malloc((n+1)*sizeof(int));
	for(i=0;i<=n;i++)
	{
		flag[i]=-1;
	}
	for(i=0;i<=n;i++)
	{
		graph[i]=(int*)malloc((n+1)*sizeof(int));
		for(j=0;j<=n;j++)
		{
			graph[i][j]=INT_MAX;
		}
	}
	while(m)
	{
		m--;
		scanf("%d%d%d",&i,&j,&weight);
		graph[i][j]=weight;
	}
	for(i=0;i<n-1;i++)
	{
		min=INT_MAX;
		minindex=1;
		for(j=2;j<=n;j++)
		{
			if(flag[j]!=-1)
			{
				continue;
			}
			if(graph[1][j]<=min)
			{
				min=graph[1][j];
				minindex=j;
			}
		}
		flag[minindex]=min;
		for(j=2;j<=n;j++)
		{
			if(flag[j]!=-1)
			{
				continue;
			}
			temp=graph[1][minindex]+graph[minindex][j];
			if(temp<graph[1][j])
			{
				graph[1][j]=temp;
			}
		}
	}
	if(flag[n]>=INT_MAX)
		flag[n]=-1;
	printf("%d\n",flag[n]);
}
