#include <stdio.h>
#include <malloc.h>
#define bool int
#define true 1
#define false 0
typedef struct
{
	int count;
	char* data;
	int maxsize;
}stack;
stack* crestack()
{
	stack* result=(stack*)malloc(sizeof(stack));
	result->data=(char*)malloc(100*sizeof(char));
	result->count=0;
	result->maxsize=100;
	return result;
}
int pop(stack* s,char* e)
{
	if(s->count==0)
		return 0;
	s->count--;
	*e=s->data[s->count];
	return 1;
}
void push(stack* s,char x)
{
	if(s->count==s->maxsize)
	{
		s->maxsize*=2;
		s->data=(char*)realloc(s->data,sizeof(char)*s->maxsize);
	}
	s->data[s->count]=x;
	s->count++;
}
void frees(stack* s)
{
	free(s->data);
	free(s);
}
bool isValid(char* s) 
{
    char now;
    char* e=(char*)malloc(sizeof(char));
    bool result=true;
    stack* mystack=crestack();
    while('\0'!=(now=*s))
    {
    	if(now=='('||now=='{'||now=='[')
    		push(mystack,now);
    	else
    	{
    		if(pop(mystack,e)==0)
    			return false;
    		switch(now)
    		{
    			case ')':
    				if(*e!='(')
    					result = false;
    				break;
    			case ']':
    				if(*e!='[')
    					result = false;
    				break;
    			case '}':
    				if(*e!='{')
    					result = false;
    				break;
			}
			if(!result)
			{
				frees(mystack);
				free(e);
				return result;
			}
		}
    	s++;
	}
	if(mystack->count!=0)
		result=false;
	free(e);
	frees(mystack); 
	return result;
}
int reverse(int x)
{
	int isminues=0;
	int intmax[10]={2,1,4,7,4,8,3,6,4,7};
	int len=10;
	if(x<0)
	{
		if(x==-2147483648)
			return 0;
		isminues=1;
		x*=-1;
		intmax[len-1]=8;
	}
    int count=0;
    int queue[len];
    while(x!=0)
    {
    	queue[count]=x%10;
    	count++;
    	x=x/10;
	}
	int i;
	if(count==len)
	{
		for(i=0;i<len;i++)
		{
			if(intmax[i]>queue[i])
			{
				break;
			}
			else if(intmax[i]<queue[i])
			{
				return 0;
			}
			else
			{
				continue;
			}
		}
	}
	int result=0;
	for(i=0;i<count;i++)
	{
		result*=10;
		result+=queue[i];
	}
	if(isminues)
		result*=-1;
	return result;
}
main()
{
	printf("%d",reverse(-2147483648));
}
