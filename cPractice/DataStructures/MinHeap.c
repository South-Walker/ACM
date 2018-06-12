#include <stdio.h> 
#include <malloc.h>
#include <limits.h>
//以最小堆排序的方式演示 
//实现的是非原址排序 
main()
{
	int array[]={12,4,35,6,72,47,234,7,24,72,342,24,123131,345,1236,54};
	//int array[]={12,4,35,6,72,345,1236,54};
	int len=sizeof(array)/sizeof(int);
	int i;
	MinHeapSort(array,len);
	for(i=0;i<len;i++)
	{
		printf("%d ",array[i]);
	}
}
void MinHeapSort(int *array,int len)
{
	//下标为0的位置不用 	
	int *MinHeap=(int*)malloc((len+1)*sizeof(int)); 
	int i,j;
	for(i=0;i<len;i++)
	{
		push(MinHeap,i,array[i]);
	}
	for(i=0;i<len;i++)
	{
		array[i]=pop(MinHeap,len);
	}
}
void push(int *heap,int len,int newint)
{
	int index=len+1;
	int temp;
	heap[index]=newint;
	while(index!=1&&heap[index]<heap[index/2])
	{
		temp=heap[index];
		heap[index]=heap[index/2];
		heap[index/2]=temp;
		index/=2;
	}
}
int pop(int *heap,int maxindex)
{
	if(maxindex==0)
		return -1;
	int result=heap[1];
	heap[1]=INT_MAX;
	int index=1;
	int temp;
	int min;
	while(1)
	{
		if(index*2<=maxindex&&index*2+1<=maxindex)
		{
			if(heap[index*2]>=heap[index*2+1])
			{
				temp=heap[index];
				heap[index]=heap[index*2+1];
				heap[index*2+1]=temp;
				index=index*2+1;
			}
			else
			{
				temp=heap[index];
				heap[index]=heap[index*2];
				heap[index*2]=temp;
				index*=2;
			}
		}
		else if(index*2<=maxindex)
		{
			temp=heap[index];
			heap[index]=heap[index*2];
			heap[index*2]=temp;
			index*=2;
		}
		else
		{
			break;
		}
	}
	return result;
}
