#include <stdio.h>
#include <malloc.h> 
#include <limits.h>
typedef struct node
{
	long long data;
	struct node* lchild;
	struct node* rchild;
}bst;
void freebst(bst*root)
{
	if(root!=NULL)
	{
		freebst(root->lchild);
		freebst(root->rchild);
		free(root);
	}
}
void inorder(bst*root)
{
	if(root!=NULL)
	{
		inorder(root->lchild);
		printf("%lld ",root->data);
		inorder(root->rchild);
	}
}
//无重复是1，有重复是0 
int addtobst(bst*root,long long d)
{
	if(root->data==0)
	{
		root->data=d;
		return 1;
	}
	bst* pre;
	bst* worknode=root;
	do
	{
		pre=worknode;
		if(worknode->data==d)
		{
			return 0;
		}
		else if(worknode->data>d)
		{
			worknode=worknode->lchild;
		}
		else
		{
			worknode=worknode->rchild;
		}
	}while(worknode!=NULL);
	worknode=(bst*)malloc(sizeof(bst));
	worknode->data=d;
	worknode->lchild=NULL;
	worknode->rchild=NULL;
	if(pre->data<d)
	{
		pre->rchild=worknode;
	}
	else
	{
		pre->lchild=worknode;
	}
	return 1;
}
int uniqueMorseRepresentations(char** words, int wordsSize) 
{
	
    int i,j,k;
    char* code;
    char *codes[26]={".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
    bst*root=(bst*)malloc(sizeof(bst));
    root->data=0;
    root->lchild=NULL;
    root->rchild=NULL;
    int count=0;
    long long value;
    for(i=0;i<wordsSize;i++)
    {
    	value=1;
    	j=0;
    	while(words[i][j]!='\0')
    	{
    		code=codes[words[i][j]-'a'];
    		k=0;
    		while(code[k]!='\0')
    		{
    			if(code[k]=='-')
    			{
    				value*=2;
				}
				else
				{
					value=value*2+1; 
				}
				k++;
			}
    		j++;
		}
		count+=addtobst(root,value);
	}
	freebst(root);
	return count;
}
int* numberOfLines(int* widths, int widthsSize, char* S, int* returnSize) 
{
    int row=1;
	int count=0;
	int sindex=0;
	while(S[sindex]!='\0')
	{
		if(
		100< (count+=(widths[S[sindex]-'a']))
		)
		{
			count=widths[S[sindex]-'a'];
			row++;
		}
		sindex++;
	}
	*returnSize=2;
	int* r=(int*)malloc(sizeof(int)*2);
	r[0]=row;
	r[1]=count;
	return r;
}
int maxIncreaseKeepingSkyline(int** grid, int gridRowSize, int *gridColSizes) 
{
	int count=0;
	int i,j;
	int *rowmax=(int*)calloc(gridRowSize,sizeof(int));
	int *colmax=(int*)calloc(51,sizeof(int));
	int target;
	for(i=0;i<gridRowSize;i++)
	{
		for(j=0;j<gridColSizes[i];j++)
		{
			if(grid[i][j]>rowmax[i])
			{
				rowmax[i]=grid[i][j];
			}
			if(grid[i][j]>colmax[j])
			{
				colmax[j]=grid[i][j];
			}
		}
	}
	for(i=0;i<gridRowSize;i++)
	{
		for(j=0;j<gridColSizes[i];j++)
		{
			target=(rowmax[i]>colmax[j])?colmax[j]:rowmax[i];
			count+=target-grid[i][j];
		}
	}
	return count;
}
void main()
{

}
