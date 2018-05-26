#include <stdio.h> 
#include <malloc.h>
#define INITSIZE 100
typedef int ElemType;
typedef struct
{
	int count;
	ElemType *base;
	int stacksize;
}sqstack;
void initstack(sqstack *s)
{
	s->base=(ElemType *)malloc(INITSIZE * sizeof(ElemType));
	s->count=0;
	s->stacksize=INITSIZE;
}
int getlen(sqstack *s)
{
	return s->count;
}
int seek(sqstack *s,ElemType *e)
{
	if(s->count==0)
		return 0;
	*e=s->base[s->count-1];
	return 1;
}
int push(sqstack *s,ElemType x)
{
	if(s->count>=s->stacksize)
	{
		ElemType* temp=(ElemType *)realloc(s->base,(s->stacksize+1)*sizeof(ElemType));
		if(!temp)
			return 0;
		s->base=temp;
		s->stacksize++;
	}
	s->base[s->count]=x;
	s->count++;
	return 1;
}
int pop(sqstack *s,ElemType *e)
{
	if(s->count==0)
		return 0;
	s->count--;
	*e=s->base[s->count];
	return 1;
}
int emptystack(sqstack *s)
{
	if(s->count==0)
		return 1;
	returm 0;
}
void list(sqstack *s)
{
	int i;
	for(i=s->count-1;i>=0;i--)
	{
		printf("%4d",s->base[i]);
	}
	printf("\n");
}
