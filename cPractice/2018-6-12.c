#include <stdio.h>
#include <malloc.h>
//poj2051
typedef struct
{
	int Q_num;
	int Period;
	int endtime;
}task;
task* headfloat(task **tasks,int count);
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
	
	for(i=1;i<=Qcount;i++)
	{
	//	printf("%d ",tasks[i]->Q_num);
	}
	//printf("\n");
	
	scanf("%d",&k);
	if(k==0)
		return;
	for(i=0;i<k;i++)
	{
		printf("%d",headfloat(tasks,Qcount)->Q_num);
		if(i!=k-1)
		{
			printf("\n");
		}
	}
} 
task* headfloat(task **tasks,int count)
{
	task* result=tasks[1];
	int index=1; 
	task* temp;
	tasks[1]->endtime+=tasks[1]->Period;
	//将原最小值下沉
	while(1)
	{
		if(index*2+1<=count&&index*2<=count)
		{
			if(isAsmaller(tasks[index*2],tasks[index]))
			{
				if(isAsmaller(tasks[index*2],tasks[index*2+1]))
				{
					temp=tasks[index];
					tasks[index]=tasks[index*2];
					tasks[index*2]=temp;
					index*=2;
				}
				else
				{
					temp=tasks[index];
					tasks[index]=tasks[index*2+1];
					tasks[index*2+1]=temp;
					index=index*2+1;
				}
			}
			else if(isAsmaller(tasks[index*2+1],tasks[index]))
			{
				temp=tasks[index];
				tasks[index]=tasks[index*2+1];
				tasks[index*2+1]=temp;
				index=index*2+1;
			}
			else
			{
				break;
			}
		}
		else if(index*2<=count)
		{
			if(isAsmaller(tasks[index],tasks[index*2]))
			{
				break;
			}
			else
			{
				temp=tasks[index];
				tasks[index]=tasks[index*2];
				tasks[index*2]=temp;
			}
			index*=2;
		}
		else
		{
			break;
		}
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
int isAsmaller(task *a,task *b)
{
	if(a->endtime<b->endtime)
		return 1;
	else if(a->endtime>b->endtime)
		return 0;
	else
		return a->Q_num < b->Q_num;
}
