#include <stdio.h>
#include <string.h> 
#include <malloc.h>
typedef struct 
{
	unsigned int weight;
	unsigned int parent,lchild,rchild;
}HTNode,*HuffmanTree;
typedef char** HuffmanCode;
void HuffmanCoding(HuffmanTree* HT,HuffmanCode* HC,int *w,int n)
{
	int i,j,m,c,start,s1,s2,f,cdlen;
	HuffmanTree p;
	char *cd;
	if(n<=1)
		return;
	m=2*n-1;
	*HT=(HuffmanTree)malloc((m+1)*sizeof(HTNode));
	for(p=*HT,i=1;i<=n;i++)
	{
		p[i].weight=w[i];
		p[i].parent=0;
		p[i].lchild=0;
		p[i].rchild=0;
	}
	for(;i<=m;i++)
	{
		p[i].weight=0;
		p[i].parent=0;
		p[i].lchild=0;
		p[i].rchild=0;
	}
	//build huffmantree 
	for(i=n+1;i<=m;i++)
	{
		j=1;p=*HT;
		while(j<=i-1&&p[j].parent!=0)
		{
			j++;
		}
		s1=j;
		while(j<=i-1)
		{
			if(p[j].parent==0&&p[j].weight<p[s1].weight)
			{
				s1=j;
			}
			j++;
		}
		p[s1].parent=i;
		
		
		j=1;p=*HT;
		while(j<=i-1&&p[j].parent!=0)
		{ 
			j++;
		}
		s2=j;
		while(j<=i-1)
		{
			if(p[j].parent==0&&p[j].weight<p[s2].weight)
			{
				s2=j;
			}
			j++;
		}
		
		if(s1>s2)
		{
			j=s1;s1=s2;s2=j;
		}
		(*HT)[s1].parent=i;
		(*HT)[s2].parent=i;
		(*HT)[i].lchild=s1;
		(*HT)[i].rchild=s2;
		(*HT)[i].weight=(*HT)[s1].weight+(*HT)[s2].weight;
	}
	*HC=(HuffmanCode)malloc((n+1)*sizeof(char*));
	cd=(char *)malloc(n*sizeof(char));
	cd[n-1]='\0';
	for(i=1;i<=n;i++)
	{
		start=n-1;
		for(c=i,f=(*HT)[i].parent;f!=0;c=f,f=(*HT)[f].parent)
		{
			if((*HT)[f].lchild==c)
			{
				cd[--start]='0';
			}
			else
			{
				cd[--start]='1';
			}
		}
		(*HC)[i]=(char*)malloc((n-start)*sizeof(char));
		strcpy((*HC)[i],cd+start);
	}
	free(cd);
}
main()
{
	HuffmanTree *pHT;
	HuffmanCode *pHC;
	pHT=(HuffmanTree*)malloc(sizeof(HuffmanTree));
	pHC=(HuffmanCode*)malloc(sizeof(HuffmanCode));
	int w[]={10000,5,29,7,8,14,23,3,11};
	HuffmanCoding(pHT,pHC,w,8);
	int i,j;
	for(i=1;i<=8;i++)
	{
		printf("%s\n",(*pHC)[i]);
	}
}
