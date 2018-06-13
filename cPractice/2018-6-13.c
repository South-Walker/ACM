#include <stdio.h>
#include <malloc.h>
#include <limits.h>
void main()
{
	int n;
	while(scanf("%d",&n))
	{
		printf("%d\n",poj1258(n));
	} 
} 
int poj1258(int n)
{
	int i,j,k;
	int matrix[n][n];
	int set[n];
	int mindistance[n];
	int totalcost=0;
	int min;
	for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
		{
			scanf("%d",&matrix[i][j]);
		}
	}
	for(i=0;i<n;i++)
	{
		mindistance[i]=matrix[0][i];
		set[i]=0;
	}
	set[0]=-1;
	for(i=1;i<n;i++)
	{
		min=INT_MAX;
		k=-1;
		for(j=1;j<n;j++)
		{
			if(set[j]!=-1&&mindistance[j]<min)
			{
				k=j;
				min=mindistance[j];
			}
		}
		if(k==-1)
		{
			break;
		}
		totalcost+=min;
		set[k]=-1;
		for(j=0;j<n;j++)
		{
			if(set[j]!=-1&&mindistance[j]>matrix[j][k])
			{
				mindistance[j]=matrix[j][k];
				set[j]=k;
			}
		} 
	}
	return totalcost;
}
void ecnu3()
{
	int n,m;
	int i,a,s;
	int temp;
	int indexnow;
	scanf("%d %d",&n,&m);
	char*ss[n];
	int f[n];
	for(i=0;i<n;i++)
	{
		ss[i]=(char*)malloc(11*sizeof(char));
		scanf("%d %s",&f[i],ss[i]);
	}
	indexnow=0;
	for(i=0;i<m;i++)
	{
		scanf("%d %d",&a,&s);
		temp=a^f[indexnow];
		if(!temp)
		{
			temp=-1;
		}
		temp=temp*s;
		indexnow+=temp;
		if(indexnow<0)
		{
			indexnow+=n;
		}
		if(indexnow>=n)
		{
			indexnow-=n;
		}
	}
	printf("%s",ss[indexnow]);	
}
void ecnu3452()
{
	
}
