#include <stdio.h>
#include <malloc.h>
#include <limits.h>
#define MAXVEX 30
void main()
{
	
} 
//∂‘”–œÚÕº 
void Dijkstra()
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
