#include <stdio.h>
#include <malloc.h>
typedef int ElemType;
#define INITSIZE 100
typedef struct
{
	ElemType *data;
	int length;
	int listsize;
}sqlist;
void initlist(sqlist *L)
{
	L->data=(ElemType*)malloc(sizeof(ElemType)*INITSIZE);
	L->length=0;
	L->listsize=INITSIZE;
}
int getlen(sqlist *L)
{
	return (L->length);
}
void add(sqlist *L,ElemType x)
{
	if(L->length==L->listsize)
	{
		L->data=(ElemType*)realloc(L->data,(L->listsize+1)*sizeof(ElemType));
		L->listsize++;
	}
	L->data[L->length]=x;
	L->length++;
}
int getelem(sqlist *L,int i,ElemType *e)
{
	if(i<1||i>L->length)
		return 0;
	*e=L->data[i-1];
	return 1;
}
int locate(sqlist *L,ElemType x)
{
	int i=0;
	while(i<L->length)
	{
		if(L->data[i]==x)
			return i+1;
		else
			i++;
	}
	return 0;
}
int insert(sqlist*L,int i,ElemType x)
{
	int j;
	ElemType *data=L->data;
	int length=L->length;
	if(i<1||i>L->length+1)
		return 0;
	if(L->length==L->listsize)
	{
		data=(ElemType*)realloc(data,(L->listsize+1)*sizeof(ElemType));
		L->listsize++;
		L->data=data;
	}
	for(j=L->length-1;j>=i-1;j--)
	{
		data[j+1]=data[j];
	}
	data[i-1]=x;
	L->length++;
	return 1;
}
int delete(sqlist*L,int i,ElemType *e)
{
	int j;
	ElemType *data=L->data;
	int length=L->length;
	if(i<1||i>length+1)
		return 0;
	*e=data[i-1];
	for(j=i-1;j<length;j++)
	{
		data[j]=data[j+1];
	}
	L->length--;
	return 1;
}
void plist(sqlist*L)
{
	int i,length=L->length;
	ElemType *data=L->data;
	for(i=0;i<length;i++)
	{
		printf("%5d",data[i]);
	}
	printf("\n");
}
main()
{
	sqlist *list=(sqlist*)malloc(sizeof(sqlist));
	initlist(list);
	int i;
	ElemType*pi=(ElemType*)malloc(sizeof(int));
	for(i=0;i<200;i++)
	{
		add(list,i);
	}
	for(i=0;i<50;i++)
	{
		delete(list,2,pi);
	}
	for(i=1;i<=50;i++)
	{
		insert(list,1+i,i);
	}
	plist(list);
}
