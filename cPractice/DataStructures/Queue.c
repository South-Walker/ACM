#include <stdio.h>
#include <malloc.h>
#define MAXQSIZE 16
typedef int ElemType;
typedef struct
{
	ElemType *data;
	int front;
	int rear;
} squeue;
squeue* crequeue()
{
	squeue* s=(squeue*)malloc(sizeof(squeue));
	s->front=0;
	s->rear=0;
	s->data=(ElemType *)malloc(sizeof(ElemType)*MAXQSIZE);
	return s;
}
int getlen(squeue* s)
{
	return (s->rear-s->front+MAXQSIZE) % MAXQSIZE;
}
int enqueue(squeue* s,ElemType x)
{
	//这里牺牲了下标为MAXQSIZE-1的位置保证了不出现二义性，
	//即指向队尾的指针当且仅当为空队列时等于指向队首的指针 
	if((s->rear+1)%MAXQSIZE==s->front)
		return 0;
	s->data[s->rear]=x;
	s->rear=(s->rear+1)%MAXQSIZE;
	return 1;
}
int outqueue(squeue* s,ElemType* x)
{
	if(s->front==s->rear)
		return 0;
	*x=s->data[s->front];
	s->front=(s->front+1)%MAXQSIZE;
	return 1;	
}
void list(squeue* s)
{
	int front=s->front;
	int rear=s->rear;
	while(front!=rear)
	{
		printf("%4d",s->data[front]);
		front=(front+1)%MAXQSIZE;
	}
	printf("\n");
}
main()
{
	squeue* q=crequeue();
	int i;
	for(i=0;i<15;i++)
	{
		enqueue(q,i);
	}
	list(q);
	int* quiti=(int*)malloc(sizeof(int));
	for(i=0;i<5;i++)
	{
		outqueue(q,quiti);
	}
	list(q);
	for(i=15;i<20;i++)
	{
		enqueue(q,i);
	}
	list(q);
	for(i=0;i<4;i++)
	{
		outqueue(q,quiti);
	}
	list(q);
}
