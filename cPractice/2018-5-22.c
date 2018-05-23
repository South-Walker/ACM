#include <stdio.h>
#include <malloc.h>
struct ListNode 
{
    int val;
    struct ListNode *next;
};

list(struct ListNode* head)
{
	while(head!=NULL)
	{
		printf("%5d",head->val);
		head=head->next;
	}
	printf("\n");
}
struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2) 
{
    if(l1==NULL)
    	return l2;
    if(l2==NULL)
    	return l1;
    int flag=0;
    struct ListNode* result=l1;
    while(l1->next!=NULL&&l2->next!=NULL)
    {
    	l1->val+=l2->val+flag;
    	flag=0;
    	if(l1->val>=10)
    	{
    		l1->val-=10;
    		flag=1;
		}
		l1=l1->next;
		l2=l2->next;
	}
    l1->val+=l2->val+flag;
    flag=0;
    if(l1->val>=10)
    {
    	l1->val-=10;
    	flag=1;
	}
	//保证l1最长 
	if(l1->next==NULL)
	{
		l1->next=l2->next;
	}
	while(l1->next!=NULL&&flag!=0)
	{
		l1=l1->next;
		l1->val+=flag;
		if(l1->val>=10)
		{
			l1->val-=10;
		}
		else
		{
			flag=0;
		}
	}
	if(flag)
	{
		l1->next=(struct ListNode*)malloc(sizeof(struct ListNode));
		l1=l1->next;
		l1->val=1;
		l1->next=NULL;
	}
	return result;
}
main()
{
	int a1[]={5};
	int a2[]={5};
	int i;
	int len1=sizeof(a1)/sizeof(int);
	int len2=sizeof(a2)/sizeof(int);
	struct ListNode *l1;
	struct ListNode *l2;
	
	struct ListNode *head;
	head=(struct ListNode *)malloc(sizeof(struct ListNode));
	head->next=NULL;
	l1=head;
	struct ListNode *temp=(struct ListNode *)malloc(sizeof(struct ListNode));
	for(i=0;i<len1;i++)
	{
		temp->val=a1[i];
		temp->next=NULL;
		head->next=temp;
		head=temp;
		temp=(struct ListNode *)malloc(sizeof(struct ListNode));
	}
	head=l1;
	l1=l1->next;
	
	temp=(struct ListNode *)malloc(sizeof(struct ListNode));
	head->next=NULL;
	l2=head;
	for(i=0;i<len2;i++)
	{
		temp->val=a2[i];
		temp->next=NULL;
		head->next=temp;
		head=temp;
		temp=(struct ListNode *)malloc(sizeof(struct ListNode));
	}
	head=l2;
	l2=l2->next;
	free(head);
	list(l1);
	list(l2);
	
	struct ListNode *result=addTwoNumbers(l1,l2);
	list(result);
}
