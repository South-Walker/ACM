#include <stdio.h>
#include <malloc.h>
#include <limits.h>
struct ListNode 
{
    int val;
    struct ListNode *next;
};
list(struct ListNode*head)
{
	while(head!=NULL)
	{
		printf("%5d",head->val);
		head=head->next;
	}
	printf("\n");
}
struct ListNode* mergeKLists(struct ListNode** lists, int listsSize) 
{
	int i;
    for(i=0;i<listsSize;i++)
    {
    	if(lists[i]==NULL)
    	{
    		listsSize--;
    		lists[i]=lists[listsSize];
    		i--;
		}
	}
	if(listsSize==0)
		return NULL;
	struct ListNode* temp=(struct ListNode*)malloc(sizeof(struct ListNode));
    struct ListNode *result,*head;
    head=temp;
    result=head;
    temp->next=NULL;
    int min=INT_MAX,index;
    while(listsSize!=0)
    {
    	for(i=0;i<listsSize;i++)
    	{
    		if(min>=lists[i]->val)
    		{
    			min=lists[i]->val;
    			index=i;
			}
		}
		lists[index]=lists[index]->next;
		if(lists[index]==NULL)
		{
			listsSize--;
			lists[index]=lists[listsSize];
		}
		temp=(struct ListNode*)malloc(sizeof(struct ListNode));
		temp->val=min;
		temp->next=NULL;
		head->next=temp;
		head=temp;
		min=INT_MAX;
	}
    head=result;
    result=result->next;
    free(head);
    return result;
}
struct ListNode* creList(int a[],int len)
{
	int i;
	struct ListNode* temp=(struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* head=temp;
	struct ListNode* result=temp;
	result->next=NULL; 
	for(i=0;i<len;i++)
	{
		temp=(struct ListNode*)malloc(sizeof(struct ListNode));
		temp->val=a[i];
		temp->next=NULL;
		head->next=temp;
		head=temp;
	}
	head=result;
	result=result->next;
	free(head);
	return result;
}
main()
{
	int a1[]={1,4,5};
	int a2[]={1,3,4};
	int a3[]={2,6};
	struct ListNode* l1=creList(a1,sizeof(a1)/sizeof(int));
	struct ListNode* l2=creList(a2,sizeof(a2)/sizeof(int));
	struct ListNode* l3=creList(a3,sizeof(a3)/sizeof(int));
	struct ListNode** input=(struct ListNode**)malloc(sizeof(struct ListNode*)*3);
	input[0]=NULL;
	//input[1]=l2;
	//input[2]=l3;
	struct ListNode* answer=mergeKLists(input,1);
	list(answer);
}

