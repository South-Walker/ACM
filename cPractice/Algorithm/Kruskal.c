#include <stdio.h>
#include <malloc.h>
#define MAXE 30
typedef struct
{
	int beginv;
	int terminatev;
	int weight;	
}edge;
int seekstoend(int set[],int v)
{
	int i=v;
	while(set[i]>0)
	{
		i=set[i];
	}
	return i;
}
//这里要求vs按权重大小排序 
void kruskal(edge es[],int n,int e)
{
	int set[MAXE];
	int v1,v2;
	int i,j;
	for(i=0;i<n;i++)
	{
		set[i]=0;
	}
	i=0;j=0;
	while(j<n && i<e)
	{
		v1=seekstoend(set,es[i].beginv);
		v2=seekstoend(set,es[i].terminatev);
		if(v1!=v2)
		{
			printf("(%d,%d)",es[i].beginv,es[i].terminatev);
			set[v1]=v2;
			j++;
		}
		i++;
	}
}
void main()
{
	edge es[MAXE];
	int i;
	es[0].beginv=3;
	es[0].terminatev=4;
	es[0].weight=2;
	
	es[1].beginv=4;
	es[1].terminatev=2;
	es[1].weight=3;
	
	es[2].beginv=0;
	es[2].terminatev=3;
	es[2].weight=5;
	
	es[3].beginv=0;
	es[3].terminatev=1;
	es[3].weight=6;
	
	es[4].beginv=3;
	es[4].terminatev=1;
	es[4].weight=7;
	
	es[5].beginv=4;
	es[5].terminatev=1;
	es[5].weight=8;
	
	es[6].beginv=2;
	es[6].terminatev=0;
	es[6].weight=9;
	
	es[7].beginv=3;
	es[7].terminatev=2;
	es[7].weight=9;
	
	es[8].beginv=0;
	es[8].terminatev=4;
	es[8].weight=13;
	
	es[9].beginv=1;
	es[9].terminatev=2;
	es[9].weight=14;
	
	kruskal(es,5,10);
} 
