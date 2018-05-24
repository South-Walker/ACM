#include <stdio.h>
#include <malloc.h> 
typedef int* datatype;
typedef struct
{
	//这个list有多大开多大
	int length;
	datatype* datas;
}list;
list* crelist()
{
	list *r=(list*)malloc(sizeof(list));
	r->length=0;
	r->datas=(datatype*)malloc(0);
	return r;
}
void addto(list *l,datatype data)
{
	l->length+=1;
	l->datas=(datatype*)realloc(l->datas,sizeof(datatype)*l->length);
	l->datas[l->length-1]=data;
}
int** permute(int* nums, int numsSize, int* returnSize) 
{
    int i,add=1;
	for(i=1;i<=numsSize;i++)
	{
		add*=i;
	} 
	int now[numsSize];
	int flag[numsSize];
	for(i=0;i<numsSize;i++)
	{
		flag[i]=0;
	}
	list* list=crelist();
	subpermute(nums,numsSize,list,flag,now,0);
	*returnSize=list->length;
	int**result=list->datas;
	free(list);
	return result;
}
void subpermute(int*nums,int numsSize,list* list,int* flag,int* now,int nowlen)
{
	int i,j;
	if(nowlen!=numsSize)
	{
		for(i=0;i<numsSize;i++)
		{
			if(flag[i])
			{
				continue;
			}
			flag[i]=1;
			now[nowlen]=nums[i];
			subpermute(nums,numsSize,list,flag,now,nowlen+1);
			flag[i]=0;
		}
	}
	else
	{
		int *newa=(int*)malloc(sizeof(int)*nowlen);;
		for(i=0;i<nowlen;i++)
		{
			newa[i]=now[i];
		}
		addto(list,newa);
	}
}
main()
{
	int nums[]={1,2,3};
	int numslen=sizeof(nums)/sizeof(int);
	int* returnSize=(int*)malloc(sizeof(int));
	*returnSize=0;
	int** answer=permute(nums,numslen,returnSize);
	int i,j;
	int size=*returnSize;
	for(i=0;i<*returnSize;i++)
	{
		for(j=0;j<numslen;j++)
		{
			printf("%5d",answer[i][j]);
		}
		printf("\n");
	}
	printf("end");
	free(answer);
}
