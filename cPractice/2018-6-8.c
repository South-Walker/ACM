#include <stdio.h>
#include <malloc.h>
typedef int bool;
#define true 1;
#define false 0;
bool subSymmetric(struct TreeNode*,struct TreeNode*);
main()
{
	
}
//给定任意长度大于1的偶数数组，若其全部异或k!=0，数组内总存在一个数x，满足x xor k!=0
//反证法，若对于所有x都有x xor k==0，则有任意x==k，因为k!=0，故数组长度必为奇 
//故若一开始k不为0，只要长度为偶，第一个取的人总能擦掉一个数使得第二个人赢不了，直到轮到自己的数组为空 
bool xorGame(int* nums, int numsSize) 
{
	int i;
	int k=0;
	for(i=0;i<numsSize;i++) 
	{
		k^=nums[i];
	}
	if(k==0)
		return true;
	if(numsSize%2)
		return false;
	return true;
}
struct TreeNode 
{
    int val;
    struct TreeNode *left;
    struct TreeNode *right;
};
bool isSymmetric(struct TreeNode* root) 
{
	if(root==NULL)
	{
		return true;
	}
    return subSymmetric(root->left,root->right);
}
bool subSymmetric(struct TreeNode* lchild,struct TreeNode* rchild)
{
	if(lchild==NULL||rchild==NULL)
	{
		if(lchild==NULL&&rchild==NULL)
		{
			return true;
		}
		return false;
	}
	if(lchild->val!=rchild->val)
		return false;
	return subSymmetric(lchild->left,rchild->right)&&subSymmetric(lchild->right,rchild->left);
}
