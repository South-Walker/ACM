#include <stdio.h>
#include <malloc.h>
typedef char ElemType;
typedef struct Node
{
	ElemType data;
	struct Node* lchild,* rchild;
}BitTree;

void PreOrder(BitTree*bt)
{
	if(bt!=NULL)
	{
		printf("%c ",bt->data);
		PreOrder(bt->lchild);
		PreOrder(bt->rchild);
	}
}
void InOrder(BitTree*bt)
{
	if(bt!=NULL)
	{
		InOrder(bt->lchild);
		printf("%c ",bt->data);
		InOrder(bt->rchild);
	}
}
void PostOrder(BitTree*bt)
{
	if(bt!=NULL)
	{
		PostOrder(bt->lchild);
		PostOrder(bt->rchild);
		printf("%c ",bt->data); 
	}
}
BitTree *CreBiTree()
{
	BitTree *bt;
	ElemType x;
	scanf("%c",&x);
	if(x==' ')
	{
		bt=NULL;
	}
	else
	{
		bt=(BitTree*)malloc(sizeof(BitTree));
		bt->data=x;
		bt->lchild=CreBiTree();
		bt->rchild=CreBiTree();
	}
	return bt;
}

