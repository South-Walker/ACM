#include <stdio.h>
#include <malloc.h>

struct TreeNode 
{
    int val;
    struct TreeNode *left;
    struct TreeNode *right;
};
struct TreeNode* buildTree(int* preorder, int preorderSize, int* inorder, int inorderSize) 
{
	if(preorderSize==0)
		return NULL;
	struct TreeNode* root=(struct TreeNode*)malloc(sizeof(struct TreeNode));
	root->val=preorder[0];
	int i;
	for(i=0;i<inorderSize;i++)
	{
		if(inorder[i]==root->val)
		{
			break;
		}
	}
	root->left=buildTree(preorder+1,i,inorder,i);
	root->right=buildTree(preorder+1+i,preorderSize-i-1,inorder+1+i,inorderSize-i-1);
	return root;
}
struct TreeNode* buildTreeFromPostIn(int* inorder, int inorderSize, int* postorder, int postorderSize) 
{
	if(inorderSize==0)
	{
		return NULL;
	}
	struct TreeNode* root=(struct TreeNode*)malloc(sizeof(struct TreeNode));
	root->val=postorder[postorderSize-1];
	int rsize=0,lsize=0;
	int i;
	for(i=0;i<inorderSize;i++)
	{
		if(inorder[i]==root->val)
		{
			break;
		}
	}
	root->right=buildTree(inorder+i+1,inorderSize-i-1,postorder+i,postorderSize-i-1);
	root->left=buildTree(inorder,i,postorder,i);
	return root;
}
void preorder(struct TreeNode* root)
{
	if(root!=NULL)
	{
		printf("%4d",root->val);
		preorder(root->left);
		preorder(root->right);
	}
}
void inorder(struct TreeNode* root)
{
	if(root!=NULL)
	{
		inorder(root->left);
		printf("%10d",root->val);
		inorder(root->right);
	}
}
void postorder(struct TreeNode* root)
{
	if(root!=NULL)
	{
		postorder(root->left);
		postorder(root->right);
		printf("%4d",root->val);	
	}
} 
int numTrees(int n) 
{
	int dp[n+1];
	int i,j;
	dp[0]=1;
	for(i=1;i<=n;i++)
	{
		dp[i]=0;
		for(j=0;j<i;j++)
		{
			dp[i]+=dp[j]*dp[i-j-1];
		}
	}
    return dp[n];
}
struct TreeNode** generateTrees(int n, int* returnSize) 
{
	int dp[n+1];
	int*nown=(int*)malloc(sizeof(int));
	struct TreeNode** model[n+1];
	int count;
	int i,j,k,q,p;
	dp[0]=1;
	model[0]=(struct TreeNode**)malloc(sizeof(struct TreeNode*));
	model[0][0]=NULL;
	if(n==0)
		return model[0];
	for(i=1;i<=n;i++)
	{
		dp[i]=0;
		for(j=0;j<i;j++)
		{
			dp[i]+=dp[j]*dp[i-j-1];
		}
		model[i]=(struct TreeNode**)malloc(sizeof(struct TreeNode*)*dp[i]);
		//构造模板二叉搜索树
		int count=0;
		for(j=0;j<i;j++)
		{
			for(q=0;q<dp[j];q++)
			{
				for(p=0;p<dp[i-j-1];p++)
				{
					struct TreeNode*root=(struct TreeNode*)malloc(sizeof(struct TreeNode));
					model[i][count]=root;
					count++;
					root->left=model[j][q];
					root->right=model[i-j-1][p];
				}
			}
		}
	}
	struct TreeNode** result=(struct TreeNode**)malloc(sizeof(struct TreeNode*)*dp[i-1]);
	for(i=0;i<dp[n];i++)
	{
		result[i]=(struct TreeNode*)malloc(sizeof(struct TreeNode));
		*nown=1;
		subinorder(model[n][i],result[i],nown);
	}
	*returnSize=dp[n];
	return result;
}
void subinorder(struct TreeNode* model,struct TreeNode* root,int* n)
{
	if(model->left==NULL)
		root->left=NULL;
	else 
	{
		root->left=(struct TreeNode*)malloc(sizeof(struct TreeNode));
		subinorder(model->left,root->left,n);
	}
	root->val=*n;
	*n+=1;
	if(model->right==NULL)
		root->right=NULL;
	else 
	{
		root->right=(struct TreeNode*)malloc(sizeof(struct TreeNode));
		subinorder(model->right,root->right,n);
	}
}
main()
{
	int*i=(int *)malloc(sizeof(int));
	struct TreeNode** r=generateTrees(3,i);
	int j;
	for(j=0;j<*i;j++)
	{
		inorder(r[j]);
		printf("\n");
	}
	
}
