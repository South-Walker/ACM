#include <stdio.h>
#include <malloc.h>
#define MAX 1000000
void main()
{
	
}
void floyd()
{
	int**graph;
	int n,m;
	int i,j,k,weight;
	scanf("%d%d",&n,&m);
	graph=(int**)malloc(sizeof(int*)*n);
	for(i=0;i<n;i++)
	{
		graph[i]=(int*)malloc(sizeof(int)*n);
		for(j=0;j<n;j++)
		{
			if(i==j)
				graph[i][j]=0;
			else
				graph[i][j]=MAX;
		}
	}
	while(m)
	{
		m--;
		scanf("%d%d%d",&i,&j,&weight);
		graph[i][j]=weight;
		graph[j][i]=weight;
	}
	for(k=0;k<n;k++)
	{
		for(i=0;i<n;i++)
		{
			for(j=0;j<n;j++)
			{
				if(graph[i][j]>graph[i][k]+graph[k][j])
				{
					graph[i][j]=graph[i][k]+graph[k][j];
					graph[j][i]=graph[i][k]+graph[k][j];
				}
			}
		}
	}
}
