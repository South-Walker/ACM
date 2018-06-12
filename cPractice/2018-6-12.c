#include <stdio.h>
#include <malloc.h>
//poj2051
typedef struct
{
	int Q_num;
	int Period;
	int endtime;
}task;
main()
{
	int Qcount=1;
	int printcount;
	char s[100];
	//下标为0不用 
	task *tasks[10001];
	int i,j,k;
	task *temp;
	while(1)
	{
		scanf("%s",&s);
		if(s[0]=='#')
			break;
		scanf("%d %d",&i,&j);
		temp=(task*)malloc(sizeof(task));
		temp->Q_num=i;
		temp->Period=j;
		temp->endtime=j;
		push(tasks,Qcount,temp);
		Qcount++;
	}
	Qcount--;
	scanf("%d",&k);
	if(k==0)
		return;
	for(i=0;i<k;i++)
	{
		temp=pop(tasks,Qcount);
		printf("%d\n",temp->Q_num);
		temp->endtime+=temp->Period;
		push(tasks,Qcount,temp);
	}
} 
task* pop(task **tasks,int count)
{
	task*result=tasks[1];
	int index=1;
	while(1)
	{
		//最小堆上浮 
		if(isAsmaller)
	}
	return result;
}
void push(task **tasks,int count,task *newtask)
{
	task* temp;
	int index;
	tasks[count]=newtask;
	if(count==1)
		return;
	index=count;
	//只有son不为root且son比parent小才互换 
	while(index!=1&&isAsmaller(tasks[index],tasks[index/2]))
	{
		temp=tasks[index];
		tasks[index]=tasks[index/2];
		tasks[index/2]=temp;
		index/=2;
	}
}
void
int isAsmaller(task *a,task *b)
{
	if(a->endtime<b->endtime)
		return 1;
	else if(a->endtime>b->endtime)
		return 0;
	else
		return a->Q_num < b->Q_num;
}
