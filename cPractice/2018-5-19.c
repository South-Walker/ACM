#include <stdio.h>
#include <malloc.h> 
double findMedianSortedArrays(int*,int,int*,int);

main()
{
	int nums1[] = {1};
	int nums2[] = {2,3,4,5,6,7,8};
	int nums1Size = sizeof(nums1)/sizeof(int);
	int nums2Size = sizeof(nums2)/sizeof(int);
	
	double result = findMedianSortedArrays(nums1,nums1Size,nums2,nums2Size);
	printf("%f",result);
}
double findMedianSortedArrays(int* nums1, int nums1Size, int* nums2, int nums2Size)
{
	int sum = nums1Size + nums2Size;
	int midnum1,midnum2;
	if(sum%2)
	{
		midnum1 = midnum2 = findKth(sum/2,nums1,nums1Size,nums2,nums2Size);
	}
	else
	{
		midnum1 = findKth(sum/2,nums1,nums1Size,nums2,nums2Size);
		midnum2 = findKth(sum/2-1,nums1,nums1Size,nums2,nums2Size);
	}
	return (double)(midnum1+midnum2)/2;
}
//k表示num1与num2归并后的下标 
int findKth(int k,int* nums1,int nums1Size,int* nums2,int nums2Size)
{
	//保证num1最大 
	if(nums1Size<nums2Size)
	{
		return findKth(k,nums2,nums2Size,nums1,nums1Size);
	}
	if(nums1Size==0)
	{
		return nums2[k];
	}
	if(nums2Size==0)
	{
		return nums1[k];
	}
	if(!k)
	{
		return (nums1[0]>nums2[0])?nums2[0]:nums1[0]; 
	}
	if(k==1)
	{
		if(nums1[0]>nums2[0])
		{
			return findKth(k-1,nums1,nums1Size,nums2+1,nums2Size-1);
		}
		else
		{
			return findKth(k-1,nums1+1,nums1Size-1,nums2,nums2Size);
		}
	}
	//要除去一个这个下标之前的 
	int halfk = k/2;
	if(halfk>=nums2Size)
	{
		if(nums1[halfk]>nums2[nums2Size-1])
			return findKth(k-nums2Size,nums1,nums1Size,nums2+nums2Size,0);
		else
		{
			nums1+=halfk;
			return findKth(k-halfk,nums1,nums1Size-halfk,nums2,nums2Size);
		}
	}
	if(nums1[halfk]>nums2[halfk])
	{
		nums2+=halfk;
		return findKth(k-halfk,nums1,nums1Size,nums2,nums2Size-halfk);
	}
	else
	{
		nums1+=halfk;
		return findKth(k-halfk,nums1,nums1Size-halfk,nums2,nums2Size);
	}
}
