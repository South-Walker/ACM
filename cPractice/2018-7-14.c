#include <stdio.h>
#include <malloc.h>
void main()
{
	ecnu15();
} 
void ecnu15()
{
	int*a;
	int*b;
	int n;
	int i,j;
	while(1)
	{
		scanf("%d",&n);
		a=(int*)malloc(n*sizeof(int));
		b=(int*)malloc(n*sizeof(int));
		for(i=0;i<n;i++)
		{
			scanf("%d",&a[i]);
		}
		for(i=0;i<n;i++)
		{
			scanf("%d",&b[i]);
		}
		qsort(a,0,n-1);
		qsort(b,0,n-1);
	}
}
void qsort(int*array,int begin,int end)
{
	int cbegin,cend;
	int temp;
	cbegin=begin;
	cend=end;
	if(end<=begin)
		return;
	while(cend>cbegin)
	{
		while(cend>cbegin&&array[cend]>=array[cbegin])
		{
			cend--;
		}
		if(cend>cbegin)
		{
			temp=array[cend];
			array[cend]=array[cbegin];
			array[cbegin]=temp;
			cbegin++;
		}
		while(cend>cbegin&&array[cend]>=array[cbegin])
		{
			cbegin++;
		}
		if(cend>cbegin)
		{
			temp=array[cend];
			array[cend]=array[cbegin];
			array[cbegin]=temp;
			cend--;
		}
	}
	qsort(array,begin,cbegin-1);
	qsort(array,cend+1,end);
}
