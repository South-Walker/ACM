#include <stdio.h>
#include <malloc.h>
#include <limits.h>
typedef int DATATYPE;
typedef struct
{
	int count;
	DATATYPE* data;
	int size;
}stack;
stack* crestack()
{
	int initsize=100;
	stack* result=(stack*)malloc(sizeof(stack));
	result->count=0;
	result->data=(DATATYPE*)malloc(initsize*sizeof(DATATYPE)); 
	result->size=initsize;
	return result;
}
void list(stack* s)
{
	int i,len=s->count;
	for(i=0;i<len;i++)
	{
		printf("%4d",s->data[i]);
	}
	printf("\n");
}
int pop(stack* s,DATATYPE* e)
{
	if(s->count==0)
		return 0;
	s->count--;
	*e=s->data[s->count];
	return 1;
}
void freestack(stack* s)
{
	free(s->data);
	free(s);
}
void push(stack* s,DATATYPE x)
{
	if(s->count==s->size)
	{
		s->data=(DATATYPE*)realloc(s->data,s->size*2*sizeof(DATATYPE)); 
		s->size*=2;
	}
	s->data[s->count]=x;
	s->count++;
}
int trap(int* height, int heightSize) 
{
	if(heightSize<=1)
		return 0;
	//´æµÄÊÇindex
    stack* s;
    int totalrain=0;
    int i,j,max=INT_MIN,maxindex=-1;
    int minues;
    for(i=0;i<heightSize;i++)
    {
    	if(height[i]>max)
		{
			max=height[i];
			maxindex=i;
		}
	}
	int *top=(int*)malloc(sizeof(int));
	int *now=(int*)malloc(sizeof(int));
	s=crestack();
	push(s,maxindex);
	for(i=maxindex+1;i<heightSize;i++)
	{
		pop(s,top);
		while(s->count!=0&&
		height[*top]<height[i])
		{
			pop(s,top);
		}
		push(s,*top);
		push(s,i);
	}
	pop(s,top);
	for(i=s->count-1;i>=0;i--)
	{
		minues=0;
		pop(s,now);
		for(j=*top;j>*now;j--)
		{
			minues+=height[j];
		}
		totalrain+=(*top-*now)*(height[*top]);
		totalrain-=minues;
		*top=*now;
	}
    freestack(s);
	s=crestack();
	push(s,maxindex);
	for(i=maxindex-1;i>=0;i--)
	{
		pop(s,top);
		while(s->count!=0&&
		height[*top]<height[i])
		{
			pop(s,top);
		}
		push(s,*top);
		push(s,i);
	}
	pop(s,top);
	for(i=s->count-1;i>=0;i--)
	{
		minues=0;
		pop(s,now);
		for(j=*top;j<*now;j++)
		{
			minues+=height[j];
		}
		totalrain+=(*now-*top)*(height[*top]);
		totalrain-=minues;
		*top=*now;
	}
    freestack(s);
    free(top);
	free(now);
    return totalrain;
}


main()
{
	char tasks[]="ASHKJHFEQASADAAA";
	int len=sizeof(tasks)/sizeof(char);
	leastInterval(tasks,len,1); 
}
int leastInterval(char* tasks, int tasksSize, int n) 
{
    int task[26];
    int i;
    for(i=0;i<26;i++)
    {
    	task[i]=0;
	}
	for(i=0;i<tasksSize;i++)
	{
		int index=(tasks[i]-'A');
		task[index]++;
	}
	sort(task,26);
	int temp=25;
	while(temp>=0 && task[25]==task[temp])
	{
    	temp--;
    }
	int result=(task[25]-1)*(n+1)+25-temp;
	result=(result>=tasksSize)?result:tasksSize;
    return result;
}
void sort(int* task,int size)
{
	int i,j,temp;
	for(i=0;i<size;i++)
	{
		for(j=i+1;j<size;j++)
		{
			if(task[j]<task[i])
			{
				temp=task[i];
				task[i]=task[j];
				task[j]=temp;
			}
		}
	}
}
