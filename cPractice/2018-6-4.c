#include <stdio.h>
#include <malloc.h>
#include <limits.h>
typedef int bool;
#define false 0
#define true 1
void myswap(int*,int,int);
void myqsort(int*,int,int);
struct stack
{
	char*datas;
	int count;
};
struct newstack
{
	int*datas;
	int count;
};
int calPoints(char** ops, int opsSize) 
{
	int result=0;
    struct newstack* s=(struct newstack*)malloc(sizeof(struct newstack));
    s->datas=(int*)malloc(sizeof(int)*opsSize);
    s->count=0;
    int i;int temp;int isminues;
    int index;
    for(i=0;i<opsSize;i++)
    {
    	if(ops[i]=="C")
    	{
    		if(s->count)
    		{
    			s->count--;
			}
		}
		else if(ops[i]=="D") 
		{
			if(s->count)
			{
				s->datas[s->count]=2 * s->datas[s->count-1];
				s->count++;
			}
		}
		else if(ops[i]=="+")
		{
			if(s->count>=2)
			{
				s->datas[s->count]=s->datas[s->count-1]+s->datas[s->count-2];
				s->count++;
			}
		}
		else
		{
			isminues=0;
			temp=0;
			index=0;
			if(ops[i][0]=='-')
			{
				isminues=1;
				index++;
			}
			while(ops[i][index]<='9'&&ops[i][index]>='0')
			{
				temp*=10;
				temp+=ops[i][index]-'0';
				index++;
			}
			s->datas[s->count]=temp;
			s->count++;
		}
	}
    for(index=0;index<s->count;index++)
    {
    	result+=s->datas[index];
	}
	free(s->datas);
    free(s);
    return result;
}
bool backspaceCompare(char* S, char* T) 
{
    struct stack* s1=(struct stack*)malloc(sizeof(struct stack));
    struct stack* s2=(struct stack*)malloc(sizeof(struct stack));
    s1->datas=(char*)calloc(200,sizeof(char));
    s2->datas=(char*)calloc(200,sizeof(char));
    s1->count=0;
    s2->count=0;
    while(*S!='\0')
    {
    	if(*S=='#')
    	{
    		if(s1->count)
    		{
    			s1->count--;
			}
		}
		else
		{
			s1->datas[s1->count]=*S;
			s1->count++;
		}
		S++;	
	}
    while(*T!='\0')
    {
    	if(*T=='#')
    	{
    		if(s2->count)
    		{
    			s2->count--;
			}
		}
		else
		{
			s2->datas[s2->count]=*T;
			s2->count++;
		}
		T++;	
	}
	bool flag=true;
	if(s1->count!=s2->count)
	{
		flag=false;
	} 
	else
	{
		while(s1->count)
		{
			s1->count--;
			s2->count--;
			if(s1->datas[s1->count]!=s2->datas[s2->count])
			{
				flag=false;
				break;
			}
		}
	}
	free(s1->datas);
	free(s1);
	free(s2->datas);
	free(s2);
	return flag;
}
struct keyvalue
{
	int key;
	int value;
};
bool isNStraightHand(int* hand, int handSize, int W) 
{
    int i,j;
    myqsort(hand,0,handSize-1);
    struct keyvalue kvs[handSize];
    int pre=INT_MAX;
    int count=0;
    for(i=0;i<handSize;i++)
    {
    	if(hand[i]!=pre)
    	{
    		kvs[count].key=hand[i];
    		kvs[count].value=1;
    		pre=hand[i];
    		count++;
		}
		else
		{
			kvs[count-1].value++;
		}
	}
	int times=0;
	for(i=0;i<count;i++)
	{
		if(kvs[i].value==0)
		{
			continue;
		}
		if(kvs[i].value<0||i>count-W)
		{
			return false;
		}
		times=kvs[i].value;
		for(j=0;j<W;j++)
		{
			if(kvs[i+j].key!=kvs[i].key+j)
				return false;
			kvs[i+j].value-=times;
		}
	}
	return true;
}
void myqsort(int* hand,int begin,int end)
{
	if(end<=begin)
		return;
	int f=end;
	int b=begin;
	while(f>b)
	{
		while(f>b&&hand[f]>=hand[b])
		{
			f--;
		}
		if(hand[f]<hand[b])
		{
			myswap(hand,f,b);
			b++;
		}
		while(f>b&&hand[f]>=hand[b])
		{
			b++;
		}
		if(hand[f]<hand[b])
		{
			myswap(hand,f,b);
			f--;
		}
	}
	if(f==b)
	{
		myqsort(hand,begin,b-1);
		myqsort(hand,f+1,end);
	}
	else//f<b
	{
		myqsort(hand,begin,f);
		myqsort(hand,b,end);
	}
}
void myswap(int* array,int a,int b)
{
	int temp;
	temp=array[a];
	array[a]=array[b];
	array[b]=temp;
}
void main()
{
	int opsSize=5;
	char**ops=(char**)malloc(sizeof(char*)*opsSize);
	ops[0]="5";
	ops[1]="2";
	ops[2]="C";
	ops[3]="D";
	ops[4]="+";
	calPoints(ops,opsSize);
}
