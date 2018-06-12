#include <stdio.h>
#include <malloc.h>
#include <limits.h>
//poj1521 
typedef struct Node
{
	struct Node* parent;
	double probability;
	char litter;
	struct Node* lchild;
	struct Node* rchild;
}HT;
void inorder(HT* root);
void preorder(HT* root);
int main()
{
	int tempindex;
	char s[10000];
	int encoding[27];
	double litter[27];
	int asciicount;
	int slength; 
	int n;
	int nodecount,huffmancount;
	int i,j;
	double min;
	HT** mytree;
	HT* temp;
	while(1)
	{
		scanf("%s",&s);
		if(isEnd(s))
			break;
		for(i=0;i<27;i++)
		{
			litter[i]=0;
		}
		asciicount=0;
		i=0;n=0;
		while(s[i]!='\0')
		{
			if(s[i]=='_')
			{
				n+=(litter[26]==0);
				litter[26]++;
			}
			else
			{
				n+=(litter[s[i]-'A']==0);
				litter[s[i]-'A']++;
			}
			i++;
			asciicount+=8;
		}
		if(i==0)
		{
			printf("0 0 0");
			continue;
		}
		slength=i;
		for(i=0;i<27;i++)
		{
			litter[i]=litter[i]/slength;
		}
		//初始化huffman树 
		nodecount=2*n-1;
		mytree=(HT**)malloc(sizeof(HT*)*nodecount);
		for(i=0,j=0;i<n;i++)
		{
			while(litter[j]==0)
			{
				j++;
			}
			mytree[i]=(HT*)malloc(sizeof(HT));
			mytree[i]->lchild=NULL;
			mytree[i]->rchild=NULL;
			mytree[i]->parent=NULL;
			mytree[i]->probability=litter[j];
			if(j==26)
			{
				mytree[i]->litter='_';
			}
			else
			{
				mytree[i]->litter=j+'A';
			}
			j++;
		}
		//开始生成huffman树 
		for(i=n;i<nodecount;i++)
		{
			mytree[i]=(HT*)malloc(sizeof(HT));
			mytree[i]->lchild=NULL;
			mytree[i]->rchild=NULL;
			mytree[i]->parent=NULL;
			
			min=1.1f;
			tempindex=-1;
			for(j=0;j<i;j++)
			{
				if(mytree[j]->parent==NULL)
				{
					if(mytree[j]->probability<min)
					{
						tempindex=j;
						min=mytree[j]->probability;
					}
				}
			}
			mytree[tempindex]->parent=mytree[i];
			mytree[i]->lchild=mytree[tempindex];
			
			min=1.1f;
			tempindex=-1;
			for(j=0;j<i;j++)
			{
				if(mytree[j]->parent==NULL)
				{
					if(mytree[j]->probability<min)
					{
						tempindex=j;
						min=mytree[j]->probability;
					}
				}
			}
			mytree[tempindex]->parent=mytree[i];
			mytree[i]->rchild=mytree[tempindex];
			mytree[i]->probability=mytree[i]->lchild->probability+mytree[i]->rchild->probability;
		}
		//开始计算编码长度
		for(i=0;i<27;i++)
		{
			encoding[i]=0;
		}
		for(i=0;i<n;i++)
		{
			temp=mytree[i];
			j=-1;
			while(temp!=NULL)
			{
				j++;
				temp=temp->parent;
			}
			if(j==0)
				j=1;
			if(mytree[i]->litter=='_') 
				encoding[26]=j;
			else
				encoding[mytree[i]->litter-'A']=j;
		} 
		huffmancount=0;
		for(i=0;i<slength;i++)
		{
			if(s[i]=='_')
				huffmancount+=encoding[26];
			else
				huffmancount+=encoding[s[i]-'A'];
		}
		printf("%d %d %.1f\n",asciicount,huffmancount,(double)asciicount/(double)huffmancount);
	}
	return 1;
}
void preorder(HT* root)
{
	if(root!=NULL)
	{
		printf("%c:%f\n",root->litter,root->probability);
		preorder(root->lchild);
		preorder(root->rchild);
	}
}
void inorder(HT* root)
{
	if(root!=NULL)
	{
		inorder(root->lchild);
		printf("%c:%f\n",root->litter,root->probability);
		inorder(root->rchild);		
	}
}
int isEnd(char*s)
{
	return s[0]=='E' && s[1]=='N' && s[2]=='D' && s[3]=='\0';
}
