/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
#include <stdio.h>
#include <malloc.h>
#include <limits.h>
int* twoSum(int*,int,int);
int* twoSumWithoutSort(int*,int,int);
void qSort(int*,int,int);
void Swap(int*,int*);
int** fourSum(int*,int,int,int*);
int** threeSum(int*,int,int*);

main()
{
	int nums[] = {-1,-5,-5,-3,2,5,0,4};
	int length = sizeof(nums)/sizeof(nums[0]);
	int i,j;
	int *returnSize = (int *)malloc(sizeof(int)); 
	int **answers = fourSum(nums,length,-7,returnSize);
	for(i=0;i<length;i++)
	{
		printf("%d ",nums[i]);
	}
	printf("\n%d",*returnSize);
	for(i=0;i<*returnSize;i++)
	{
		int*now = answers[i];
		printf("\n%5d %5d %5d %5d",now[0],now[1],now[2],now[3]);
	}
}
int** fourSum(int* nums, int numsSize, int target, int* returnSize)
{
    qSort(nums,0,numsSize-1);
    int i,j,k,l;
    int lasti=INT_MAX,lastj=INT_MAX,lastk=INT_MAX;
    int nowvalue;
    int **result, *oneanswer;
    int count=0,pointLen=sizeof(int*),quaLen=4*sizeof(int);
    for(i=0;i<numsSize-3;i++)
    {
    	if(nums[i]==lasti)
    		continue;
    	lastj=INT_MAX,lastk=INT_MAX;
    	for(j=i+1;j<numsSize-2;j++)
    	{
    		if(nums[j]==lastj)
    			continue;
    		lastk=INT_MAX;
    		k=j+1,l=numsSize-1;
    		while(k!=l)
    		{
    			nowvalue = nums[i]+nums[j]+nums[k]+nums[l];
    			if(nowvalue>target)
    			{
    				l--;
				}
				else if(nowvalue<target)
				{
					k++;
				}
				else
				{
					if(nums[k]==lastk)
					{
						k++;
						continue;
					}
					oneanswer = (int *)malloc(quaLen);
					oneanswer[0] = nums[i];
					oneanswer[1] = nums[j];
					oneanswer[2] = nums[k];
					oneanswer[3] = nums[l];
					if(count)
					{
						result = (int **)realloc(result,(count+1)*pointLen);
					}
					else
					{
						result = (int **)malloc(pointLen);
					}
					result[count] = oneanswer;
					lasti = nums[i];
					lastj = nums[j];
					lastk = nums[k];
					count++;
					k++;
				}
			}
		}
	}
	*returnSize = count;
	return result;
}
int** threeSum(int* nums, int numsSize, int* returnSize) 
{
	int count = 0;
	int triLen = 3*sizeof(int);
	int pointLen = sizeof(int*);
	int **result,*oneanswer;
	qSort(nums,0,numsSize-1);
	int i,j,k,nowvalue,lasti=1,lastj=INT_MAX;
	for(i=0;i<numsSize - 2;i++)
	{
		if(nums[i]==lasti)
			continue;
		else
			lasti=nums[i];
		j = i+1;
		k = numsSize-1;
		while(j!=k)
		{
			nowvalue =  nums[i]+nums[j]+nums[k];
			if(nowvalue>0)
			{
				k--;
			}
			else if(nowvalue<0)
			{
				j++;
			}
			else
			{
				if(nums[j]==lastj)
				{
					j++;
					continue;
				}
				lastj = nums[j];
				oneanswer = (int *)malloc(triLen);
				oneanswer[0] = nums[i];
				oneanswer[1] = nums[j];
				oneanswer[2] = nums[k];
				if(count==0)
				{
					result = (int **)malloc(pointLen);
				}
				else
				{
					result = (int **)realloc(result,(count+1)*pointLen);
				}
				result[count]=oneanswer;
				count++;
				j++;
			}
		}
		lastj=INT_MAX;
	}
	*returnSize = count;
	return result;
}
void qSort(int* nums,int beginindex,int endindex)
{
	if(endindex<=beginindex)
		return;
	int nowbegin = beginindex,nowend = endindex;
	while(nowend>nowbegin)
	{
		while(nums[nowbegin]<=nums[nowend] && nowend>nowbegin)
		{
			nowbegin++;
		}
		Swap(nums+nowbegin,nums+nowend); 
		while(nums[nowbegin]<=nums[nowend] && nowend>nowbegin)
		{
			nowend--;
		}
		Swap(nums+nowbegin,nums+nowend);
	}
	if(nowbegin-1<endindex)
	{
		qSort(nums,beginindex,nowbegin-1);
	}
	if(nowend+1>beginindex)
	{
		qSort(nums,nowend+1,endindex);
	}
}
void Swap(int*a,int*b)
{
	int temp = *a;
	*a = *b;
	*b = temp;
}
int* twoSum(int* nums,int numsSize,int target)
{
	qSort(nums,0,numsSize);
	int *result = (int *)malloc(sizeof(int) * 2);
	//基于有序数组 
	int former = 0,latter = numsSize-1;
	int nowvalue;
	while(former!=latter)
	{
		nowvalue = nums[former]+nums[latter];
		if(nowvalue==target)
		{
			result[0]=former;
			result[1]=latter;
			break;
		}
		else if(nowvalue<target)
		{
			former++;
		}
		else
		{
			latter--;
		}
	}
	return result; 
}
int* twoSumWithoutSort(int* nums, int numsSize, int target)
{
    int *result = (int *)malloc(sizeof(int) * 2);
    int i = 0,j = 0;
    for(;i<numsSize;i++)
    {
    	for(j=i+1;j<numsSize;j++)
    	{
    		if(nums[i] + nums[j] == target)
    		{
    			result[0] = i;
    			result[1] = j;
    			return result;
			}
		}
	}
    return result;
}
