#include <stdio.h>
#include <malloc.h>
void main()
{
	
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
