#include <stdio.h>
#include <malloc.h>
#include <limits.h>
typedef int bool;
#define true 1;
#define false 0;
int* splitIntoFibonacci(char* S, int* returnSize);
int getnum(char* S,int begin,int end,int*answer);
typedef struct linknode
{
	char data;
	struct linknode* next;
}linktable;
void crecharlink(linktable*lt,char* datas,int len)
{
	lt->data=datas[0];
	lt->next=lt;
	linktable* temp;
	linktable* work;
	temp=lt;
	int i;
	for(i=1;i<len;i++)
	{
		work=(linktable*)malloc(sizeof(linktable));
		work->data=datas[i];
		work->next=lt;
		temp->next=work;
		temp=work;
	}
}
bool isequal(linktable*la,linktable*lb)
{
	linktable*nowa=la;
	linktable*nowb=lb;
	bool result=true;
	do
	{
		if(nowa->data==nowb->data)
		{
			nowa=nowa->next;
			nowb=nowb->next;
		}
		else
		{
			result=false;
			break;
		}
	}
	while(nowa!=la);
	return result;
}
int getlen(char*s)
{
	int i=0;
	while(s[i]!='\0')
	{
		i++;
	}
	return i;
}
void freelink(linktable*lt,int len)
{
	linktable* work=lt->next;
	linktable* pre;
	int i;
	while(work!=lt)
	{
		pre=work;
		work=work->next;
		free(pre);
	}
	free(work);
}
bool rotateString(char* A, char* B) 
{
    int len1=getlen(A);
    int len2=getlen(B);
    if(len1!=len2)
    {
    	return false;
	}
	if(len1==0)
	{
		return true;
	}
	linktable* la=(linktable*)malloc(sizeof(linktable));
	linktable* lb=(linktable*)malloc(sizeof(linktable));
	crecharlink(la,A,len1);
	crecharlink(lb,B,len2);
	int i;
	
	
	bool flag=false;
	for(i=0;i<len1;i++)
	{
		flag=isequal(la,lb);
		la=la->next;
		if(flag)
		{
			break;
		}
	}
	freelink(la,len1);
	freelink(lb,len2);
	return flag;
}
main()
{
	char*a="abcde";
	char*b="cdeab";
	printf("%d",rotateString(a,b));
}
int* splitIntoFibonacci(char* S, int* returnSize) 
{
	int* a=(int*)malloc(sizeof(int));
	int* b=(int*)malloc(sizeof(int));
	int* c=(int*)malloc(sizeof(int));
	int flag;
	flag=0;
	int i,j;
	*returnSize=0;
	int* result=(int*)malloc(201*sizeof(int));
	//i是终点 
	for(i=0;S[i+2]!='\0';i++)
	{
		*returnSize=0; 
		*a=0;
		if(getnum(S,0,i,a))
		{
			result[0]=*a;
			*returnSize=1;
			for(j=i+1;S[j+1]!='\0';j++)
			{
				*b=0;
				if(getnum(S,i+1,j,b))
				{
					result[1]=*b;
					*returnSize=2;
					//给定的前两项可以唯一确定一个斐波拉契数列，故这个方法只需要线性时间 
					flag=findNextFibonacci(S,j+1,result,returnSize);
				}
				else
				{
					break;
				}
				if(flag)
				{
					break;										
				}
			}
		}
		else
		{
			break;
		}
		if(flag)
		{
			break;
		}
	}
	
	free(a);
	free(b);
	free(c);
	if(*returnSize>2)
	{
		result=(int*)realloc(result,*returnSize*sizeof(int));
 		return result;
	}
	else
	{
		*returnSize=0;
		free(result);
		return NULL;
	}
}
int findNextFibonacci(char* S,int beginindex,int* fib,int* fibsize)
{
	if(S[beginindex]=='\0')
		return 1;
	int i=beginindex;
	int* a=(int*)malloc(sizeof(int));
	while(S[i]!='\0')
	{
		if(getnum(S,beginindex,i,a))
		{
			if(fib[*fibsize-1]==*a-fib[*fibsize-2])
			{
				fib[*fibsize]=*a;
				*fibsize+=1;
				free(a);
				return findNextFibonacci(S,i+1,fib,fibsize);
			}
		}
		else
		{
			free(a);
			return 0;
		}
		i++;
	}
	return 0;
} 
int getnum(char* S,int begin,int end,int*answer)
{
	if(S[begin]=='0')
	{
		*answer=0;
		return begin==end;
	}
	if(end-begin>=10||end<begin)
	{
		return 0;
	}
	int temp=0;
	int i;
	for(i=begin;i<end;i++)
	{
		temp*=10;
		temp+=S[i]-'0';	
	}
	if(temp > (INT_MAX-(S[end]-'0'))/10)
	{
		return 0;
	}
	temp*=10;
	temp+=S[i]-'0';	
	*answer=temp;
	return 1;
}
