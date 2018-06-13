#include <stdio.h>
#include <malloc.h>
#include <limits.h>
#define MAXVEX 30
void prim(int c[MAXVEX][MAXVEX],int n)
{
	int i,j,k;
	int min;
	//从当前已加入顶点出发到索引节点的最短距离 
	int lowcost[MAXVEX];
	//已经加入的顶点为-1，否则存储具体是哪一个已加入节点到lowcost最短 
	int closest[MAXVEX];
	//这个i不作为下标使用，仅用以保证循环发生n-1次 
	for(i=1;i<n;i++)
	{
		lowcost[i]=c[0][i];
		closest[i]=0;
	}
	closest[0]=-1;
	for(i=1;i<n;i++)
	{
		min=INT_MAX;
		k=-1;
		for(j=1;j<n;j++)
		{
			if(lowcost[j]<min&&closest[j]!=-1)
			{
				min=lowcost[j];
				k=j;
			}
		}
		if(k==-1)
		{
			//这个其实不会发生 
			break;
		} 
		printf("(%d,%d) ",closest[k],k);
		closest[k]=-1;
		for(j=1;j<n;j++)
		{
			if(lowcost[j]>c[j][k]&&closest[j]!=-1)
			{
				lowcost[j]=c[j][k];
				closest[j]=k;
			}
		}
	}
}
void main()
{
	int edge[MAXVEX][MAXVEX];
	edge[0][1]=edge[1][0]=6;
	edge[0][2]=edge[2][0]=9;
	edge[0][3]=edge[3][0]=5;
	edge[0][4]=edge[4][0]=13;
	
	edge[1][2]=edge[2][1]=14;
	edge[1][3]=edge[3][1]=7;
	edge[1][4]=edge[4][1]=8;	
	
	edge[2][3]=edge[3][2]=9;
	edge[2][4]=edge[4][2]=3;
	
	edge[3][4]=edge[4][3]=2;
	prim(edge,5);
}  
