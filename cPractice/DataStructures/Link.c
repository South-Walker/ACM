#include <stdio.h>
#include <malloc.h>
typedef int ElemType;
typedef struct node
{
	ElemType data;
	struct node *next;
} slink;
slink *creslink(int n)
{
	slink *head,*p,*s;
	int i;
	p=head=(slink *)malloc(sizeof(slink));
	for(i=0;i<n;i++)
	{
		s=(slink *)malloc(sizeof(slink));
		s->data=i;
		p->next=s;
		p=s;
	}
	p->next=NULL;
	return head;
}
int getlen(slink *head)
{
	int len=-1;
	while(head!=NULL)
	{
		len++;
		head=head->next;
	}
	return len;
}
int getelem(slink *head,int i,ElemType *e)
{
	
}
main()
{
	slink *link=creslink(50);
	printf("%5d",getlen(link));
	printf("%5d",getlen(link));
	printf("%5d",link->next->data);
}
