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
	if(i<=0)
		return 0; 
	int j;
	for(j=0;j<i;j++)
	{
		head=head->next;
		if(head==NULL)
		{
			return 0;
		}
	}
	*e=head->data;
	return 1;
}
int locate(slink *head,ElemType e)
{
	int i=0;
	head=head->next;
	while(head!=NULL)
	{
		i++;
		if(head->data==e)
		{
			return i;
		}
		head=head->next;
	}
	return 0;
} 
int delete(slink *head,int i,ElemType *e)
{
	if(i<1)
		return 0; 
	slink *prenode=head,*frontnode=head->next;
	//frontnodeµÄÏÂ±ê 
	int j=1;
	while(j!=i)
	{
		if(frontnode==NULL)
			return 0;
		else
		{
			j++;
			prenode=frontnode;
			frontnode=frontnode->next;
		}
	}
	if(frontnode==NULL)
		return 0;
	prenode->next=frontnode->next;
	*e=frontnode->data;
	free(frontnode); 
	return 1; 
}
int insert(slink *head,int i,ElemType x)
{
	slink *p,*q;
	int j;
	if(i<1)
		return 0;
	p=head;j=0;
	while(p!=NULL&&j<i-1)
	{
		p=p->next;
		j++;
	}
	if(p==NULL)
		return 0;
	q=(slink *)malloc(sizeof(slink));
	q->data=x;
	q->next=p->next;
	p->next=q;
	return 1;
}
list(slink *head)
{
	head=head->next;
	while(head!=NULL)
	{
		printf("%5d",head->data);
		head=head->next;
	}
	printf("\n");
}
main()
{
	slink *link=creslink(50);
	int *e=(int *)malloc(sizeof(int));
	int r;
	r=delete(link,51,e);
	printf("%5d%5d\n",r,*e);
	r=delete(link,50,e);
	printf("%5d%5d\n",r,*e);
	r=delete(link,50,e);
	printf("%5d%5d\n",r,*e);
	list(link); 
	for(r=49;r>0;r--)
	{
		delete(link,r,e);
		insert(link,r,-(r-1));
	}
	list(link);
}
