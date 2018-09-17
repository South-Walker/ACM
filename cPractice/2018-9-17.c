#include <stdio.h> 
#include <malloc.h>
struct TreeNode 
{
    int val;
    struct TreeNode *left;
    struct TreeNode *right;
};
typedef struct Stack
{
	struct TreeNode **s;
	int topindex;
}stack;
struct TreeNode* pop(stack *s)
{
	if(s->topindex==0)
		return NULL;
	else
		return s->s[--s->topindex];
}
struct TreeNode* seek(stack *s)
{
	if(s->topindex==0)
		return NULL;
	else
		return s->s[s->topindex-1];
}
void push(stack *s,struct TreeNode* t)
{
	s->s[s->topindex++]=t;
}
int* postorder(struct TreeNode* root)
{
	if(root->left)
		postorder(root->left);
	if(root->right)
		postorder(root->right);
	printf("%d\n",root->val);
}
int* postorderTraversal(struct TreeNode* root, int* returnSize) 
{
	if(root==NULL)
	{
		return NULL;
	}
	int* answer=(int*)malloc(10000*sizeof(int));
	int answerindex=0;
    stack*s=(stack*)malloc(sizeof(stack));
    s->topindex=0;
    s->s=(struct TreeNode**)malloc(10000*sizeof(struct TreeNode*));
    struct TreeNode* temp=root;
    struct TreeNode* now= root;
    push(s,root);
    while(s->topindex)
    {
    	now=seek(s);
    	if((now->left==NULL&&now->right==NULL)||
		now->right==temp||
		(now->left==temp&&now->right==NULL))
    	{
    		pop(s);
    		answer[answerindex++]=now->val;
    		printf("%d\n",now->val);
    		temp=now;
		}
    	else if(now->left==temp||now->left==NULL)
    	{
    		push(s,now->right);
		}
		else
		{
			push(s,now->left); 
		}
	}
    
    free(s->s);
    free(s);
    *returnSize=answerindex;
    return answer;
}
int main()
{
	int test=0;
	
	struct TreeNode* t1 = (struct TreeNode*)malloc(sizeof(struct TreeNode));
	t1->val=1;
	t1->left=NULL;
	t1->right=NULL;
	struct TreeNode* t2 = (struct TreeNode*)malloc(sizeof(struct TreeNode));
	t2->val=2;
	t2->left=NULL;
	t2->right=NULL;
	struct TreeNode* t3 = (struct TreeNode*)malloc(sizeof(struct TreeNode));
	t3->val=3;
	t3->left=NULL;
	t3->right=NULL;
	struct TreeNode* t4 = (struct TreeNode*)malloc(sizeof(struct TreeNode));
	t4->val=4;
	t4->left=NULL;
	t4->right=NULL;
	struct TreeNode* t5 = (struct TreeNode*)malloc(sizeof(struct TreeNode));
	t5->val=5;
	t5->left=NULL;
	t5->right=NULL;
	struct TreeNode* t6 = (struct TreeNode*)malloc(sizeof(struct TreeNode));
	t6->val=6;
	t6->left=NULL;
	t6->right=NULL;
	
	t1->left=t2;
	t1->right=t3;
	t2->right=t4;
	t4->left=t6;
	t3->right=t5;
	
	t1->left=NULL;
	t1->right=t2;
	t2->right=NULL;
	t2->left=t3;
	t3->right=t3->right=NULL;
	
	//postorder(t1);
	postorderTraversal(t1, test);
	return 1;
}
