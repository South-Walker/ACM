#include <stdio.h>
#include <malloc.h>
typedef int bool;
#define true 1
#define false 0
struct ListNode 
{
    int val;
    struct ListNode *next;
};
bool isPalindrome(struct ListNode* head) 
{
	int size=10;
	int *num=(int*)malloc(size*sizeof(int));
	int count=0;
	while(head)
	{
		if(count==size)
		{
			size*=2;
			num=(int*)realloc(num,size*sizeof(int));
		}
		num[count]=head->val;
		head=head->next;
		count++;
	}
	int begin=0;
	int end=count-1;
	bool result=true;
	while(end>begin)
	{
		if(num[end]!=num[begin])
		{
			result=false;
			break;
		}
		end--;begin++;
	}
	free(num);
	return result;
}
bool aisPalindrome(int x) 
{
    if(x<0)
    {
    	return false;
	}
	int nums[10],index=-1,begin=0;
	while(x!=0)
	{
		index++;
		nums[index]=x%10;
		x/=10;
	}
	while(begin<index)
	{
		if(nums[begin]!=nums[index])
			return false;
		begin++;
		index--;
	}
	return true;
}
main()
{
	struct ListNode* head=(struct ListNode*)malloc(sizeof(struct ListNode));
	head->next=NULL;
	struct ListNode* temp;
	struct ListNode* per=head;
	int num[]={1};
	int len=sizeof(num)/sizeof(int);
	int begin;
	for(begin=0;begin<len;begin++)
	{
		temp=(struct ListNode*)malloc(sizeof(struct ListNode));
		temp->val=num[begin];
		temp->next=NULL;
		per->next=temp;
		per=temp;
	}
	printf("%d",isPalindrome(head->next));
}
