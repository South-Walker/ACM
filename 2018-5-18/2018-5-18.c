/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
#include <stdio.h>
#include <malloc.h>
int* twoSum(int*,int,int);
int* twoSumWithoutSort(int*,int,int);
void Swap(int*,int*);

main()
{
	int nums[] = {2,7,11,15};
	int length = sizeof(nums)/sizeof(nums[0]);
	int i;
	int *answer = twoSum(nums,length,9);
	for(i=0;i<length;i++)
	{
		printf("%d ",nums[i]);
	}
	printf("\n%d %d",*answer,*(answer+1));
}
int** threeSum(int* nums, int numsSize, int* returnSize) {
    
}
void qSort(int* nums,int beginindex,int endindex)
{
	int nowbegin = beginindex,nowend = endindex;
	while(nowend>nowbegin)
	{
		while(nums[nowbegin]<nums[nowend] && nowend>nowbegin)
		{
			nowbegin++;
		}
		Swap(nums+nowbegin,nums+nowend); 
		while(nums[nowbegin]<nums[nowend] && nowend>nowbegin)
		{
			nowend--;
		}
		Swap(nums+nowbegin,nums+nowend); 
	}
	if(nowbegin-1>beginindex)
	{
		qSort(nums,beginindex,nowbegin-1);
	}
	if(nowend+1<endindex)
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
