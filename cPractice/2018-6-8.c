#include <stdio.h>
#include <malloc.h>
typedef int bool;
#define true 1;
#define false 0;
bool subSymmetric(struct TreeNode*,struct TreeNode*);
main()
{
	
}
//�������ⳤ�ȴ���1��ż�����飬����ȫ�����k!=0���������ܴ���һ����x������x xor k!=0
//��֤��������������x����x xor k==0����������x==k����Ϊk!=0�������鳤�ȱ�Ϊ�� 
//����һ��ʼk��Ϊ0��ֻҪ����Ϊż����һ��ȡ�������ܲ���һ����ʹ�õڶ�����Ӯ���ˣ�ֱ���ֵ��Լ�������Ϊ�� 
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
