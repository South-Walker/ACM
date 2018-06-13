#include <stdio.h>
#include <malloc.h>
#include <limits.h>
#define MAXVEX 30
void prim(int c[MAXVEX][MAXVEX],int n)
{
	int i,j,k;
	int min;
	//�ӵ�ǰ�Ѽ��붥������������ڵ����̾��� 
	int lowcost[MAXVEX];
	//�Ѿ�����Ķ���Ϊ-1������洢��������һ���Ѽ���ڵ㵽lowcost��� 
	int closest[MAXVEX];
	//���i����Ϊ�±�ʹ�ã������Ա�֤ѭ������n-1�� 
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
			//�����ʵ���ᷢ�� 
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
