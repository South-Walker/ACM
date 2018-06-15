#include <stdio.h>
#include <malloc.h>
#include <limits.h>
typedef struct lnode
{
	struct lnode* next;
	int content;
}link;
void freelink(link* head);
typedef struct
{
	link* adjacent;
	int isused;
	unsigned int howmanyin;
}vnode;
typedef struct
{
	vnode** v;
	int count;
	int size;
}stack; 
void freevnode(vnode* vn)
{
	freelink(vn->adjacent);
	free(vn);
}
void freelink(link* head)
{
	link* work;
	link* temp;
	temp=head;
	while(temp!=NULL)
	{
		work=temp->next;
		free(temp);
		temp=work;
	}
}
stack* cres(int size)
{
	stack* result=(stack*)malloc(sizeof(stack));
	result->v=(vnode**)malloc(sizeof(vnode*)*size);
	result->count=0;
	result->size=size;
	return result;
}
void freestack(stack*s)
{
	free(s->v);
	free(s);
}
//栈空返回NULL
vnode* pop(stack* st)
{
	if(st->count==0)
	{
		return NULL;
	}
	st->count--;
	return st->v[st->count];
}
//成功为1，失败为0 
int push(stack* st,vnode* v)
{
	if(st->count==st->size)
	{
		return 0;
	}
	st->v[st->count]=v;
	st->count++;
	return 1;
}
void main()
{
	poj1094();
}
//栈空而存在入度不为0的点，有回路：Inconsistency found after xxx relations.
//有两点以上入度为0，两点大小无法判断：Sorted sequence cannot be determined.  
//栈空而不存在入度不为0的点，成功排序：Sorted sequence determined after xxx relations: yyy...y.  
void poj1094()
{
	int n,m;
	int edgecount;
	int i,j,k;
	char a,b;
	char s[10];
	int isprint;
	char result[26];
	int resultindex;
	//有多少节点入度不为0 
	int haspre;
	int lastnode;
	int map[26][26];
	
	vnode** litter;
	stack* st;
	link* temp;
	vnode* vtemp;
	
	while(1)
	{
		isprint=0;
		resultindex=0;
		edgecount=1;
		scanf("%d %d",&n,&m);
		if(n==0)
		{
			return;
		}
		lastnode=n;
		haspre=0;
		if(m==0)
		{
			isprint=1;
			printf("Sorted sequence cannot be determined.\n");
		}
		for(i=0;i<26;i++)
		{
			for(j=0;j<26;j++)
			{
				map[i][j]=0;
			}
		}
		st=cres(m);
		litter=(vnode**)malloc(n*sizeof(vnode*));
		for(i=0;i<n;i++)
		{
			litter[i]=(vnode*)malloc(sizeof(vnode));
			litter[i]->adjacent=NULL;
			litter[i]->howmanyin=0;
			litter[i]->isused=0;
		}
		
		while(m)
		{
			scanf("%s",s);
			a=s[0];
			b=s[2];
			i=a-'A';j=b-'A';
			if(map[i][j])
			{
				m--;
				edgecount++;
				continue;
			} 
			map[i][j]=1;
			for(k=0;k<26;k++)
			{
				if(map[j][k])
				{
					map[i][k]=1;
				}
				if(map[k][i])
				{
					map[k][j]=1;
				}
			}
			if(map[j][i]||litter[j]->isused)
			{
				isprint=1;
				printf("Inconsistency found after %d relations.\n",edgecount);
				m--;
				break;
			}
			if(litter[j]->howmanyin==0)
			{
				haspre++;
			}
			litter[j]->howmanyin++;
			if(litter[i]->adjacent==NULL)
			{
				litter[i]->adjacent=(link*)malloc(sizeof(link));
				litter[i]->adjacent->next=NULL;
				litter[i]->adjacent->content=j;
			}
			else
			{
				temp=litter[i]->adjacent;
				while(temp->next!=NULL)
				{
					temp=temp->next;			
				}
				temp->next=(link*)malloc(sizeof(link));
				temp->next->next=NULL;
				temp->next->content=j;
			}
			while(haspre==lastnode-1)
			{
				for(k=0;k<n;k++)
				{
					if(litter[k]->isused==0&&litter[k]->howmanyin==0)
					{
						result[n-lastnode]='A'+k;
						litter[k]->isused=1;
						temp=litter[k]->adjacent;
						while(temp)
						{
							if(litter[temp->content]->isused==0)
							{
								litter[temp->content]->howmanyin--;
								if(litter[temp->content]->howmanyin==0)
								{
									haspre--;
								}
							}
							temp=temp->next;
						}
						break;
					}
				}
				lastnode--;
			}
			if(lastnode==0)
			{
				isprint=1;
				printf("Sorted sequence determined after %d relations: ",edgecount);
				for(i=0;i<n;i++)
				{
					printf("%c",result[i]);
				}
				printf(".\n");
				m--;
				break;
			}
			edgecount++;
			m--;
		}
		if(lastnode&&isprint==0)
		{
			printf("Sorted sequence cannot be determined.\n");
		}
		while(m)
		{
			scanf("%s",s);
			m--;
		}
		for(i=0;i<n;i++)
		{
			freevnode(litter[i]);
		}
		freestack(st);
		free(litter);
	}
} 
