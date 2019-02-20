#include <stdio.h> 
#include <malloc.h>
int q1()
{
	int i,j,k;
	int x,y,z;
	int r,flag=0;
	int num,now;
	int n;
	scanf("%d%d%d%d",&n,&x,&y,&z);
	num=x*1000+y*100+z*10;
	for(i=9;i>0;i--)
	{
		for(j=9;j>=0;j--)
		{
			now=i*10000+j+num;
			if(now%n==0)
			{
				flag=1;
				break;
			}
		}
		if(flag)
			break;
	}
	if(flag)
	{
		printf("%d %d %d\n",i,j,now/n);
	}
	else
	{
		printf("0\n");
	}
}
int flag;
int d[10];
int check[10];
int aim;
void solution(int now)
{
	int i;
	if(now==aim)
	{
		flag=1;
	}
	if(flag)
		return;
	for(i=0;i<10;i++)
	{
		if(check[i])
			continue;
		check[i]=1;
		solution(now+d[i]);
		check[i]=0;
	}
}
int q2()
{
	int i,j,now;
	now=1;
	for(i=0;i<10;i++)
	{
		if(i!=0)
			now*=i;
		d[i]=now;
		check[i]=0;
	}
	scanf("%d",&aim);
	solution(0);
	if(flag)
	{
		printf("YES");
	}
	else
	{
		printf("NO");
	}
}
typedef struct node
{
	struct node*bro;
	struct node*son;
	char name[50];
}link;
int cmp(char*a,char*b)
{
	while(*a==*b)
	{
		if(*a=='\0')
			return 0;
		a++;
		b++;
	}
	return *a-*b;
}
void copy(char*source,char*aim)
{
	while(*source)
	{
		*aim=*source;
		source++;
		aim++;
	}
	*source='\0';
}
link*hand(char*now)
{
	link*head=(link*)malloc(sizeof(link));
	link*next=head;
	next->name[0]='\0';
	next->son=NULL;
	next->bro=NULL;
	int index=0;
	while(*now)
	{
		index=0;
		while(*now!='\\'&&*now!='\0')
		{
			next->name[index]=*now;
			index++;
			now++;
		}
		next->name[index]='\0';
		if(*now=='\\')
		{
			now++;
		}
		if(*now)
		{
			next->son=(link*)malloc(sizeof(link));
			next=next->son;
			next->name[0]='\0';
			next->son=NULL;
			next->bro=NULL;
		}
	}
	
	return head;
}
//这两个在公共盘下 
void subinside(link*mainhead,link*head)
{
	char*nowname;
	int cmpr;
	if(head->son==NULL)
		return;
	link*temp;
	nowname=head->son->name;
	if(mainhead->son==NULL)
	{
		mainhead->son=head->son;
		return;
	}
	cmpr=cmp(mainhead->son->name,nowname);
	if(cmpr==0)
	{
		subinside(mainhead->son,head->son);
		return;
	}
	else if(cmpr<0)
	{
		mainhead=mainhead->son;
	}
	else
	{
		temp=mainhead->son;
		mainhead->son=head->son;
		head->son->bro=temp;
		return;
	}
	while(mainhead->bro!=NULL)
	{
		cmpr=cmp(mainhead->bro->name,nowname);
		if(cmpr==0)
		{
			subinside(mainhead->bro,head);
			return;
		}
		else if(cmpr<0)
		{
			mainhead=mainhead->bro;
		}
		else//head在mainhead后面,bro前面 
		{
			temp=mainhead->bro;
			mainhead->bro=head->son;
			head->son->bro=temp;
			return;
		}
	}
	mainhead->bro=head->son;
	return;
}
void inside(link*mainhead,link*head)
{
	char*nowname;
	int cmpr;
	if(head==NULL)
		return;
	link*temp;
	nowname=head->name;
	if(mainhead->bro==NULL)
	{
		mainhead->bro=head;
		return;
	}
	while(mainhead->bro!=NULL)
	{
		cmpr=cmp(mainhead->bro->name,nowname);
		if(cmpr==0)
		{
			subinside(mainhead->bro,head);
			return;
		}
		else if(cmpr<0)
		{
			mainhead=mainhead->bro;
		}
		else//head在mainhead后面,bro前面 
		{
			temp=mainhead->bro;
			mainhead->bro=head;
			head->bro=temp;
			return;
		}
	}
	mainhead->bro=head;
	return;
}
void printfnodes(link*first,int deep)
{
	int i;
	while(first!=NULL)
	{
		for(i=0;i<deep;i++)
		{
			printf("  ");
		}
		printf("%s\n",first->name);
		printfnodes(first->son,deep+1);
		if(deep==0)
		{
			printf("\n");
		}
		first=first->bro;
	}
}
int main()
{
	int n,i,j;
	int index;
	char now[51];
	char temp[51];
	scanf("%d",&n);
	link*head=(link*)malloc(sizeof(link));
	head->name[0]='\0';
	head->bro=NULL;
	head->son=NULL;
	link*nowlinkhead;
	while(n)
	{
		n--;
		scanf("%s",now);
		nowlinkhead=hand(now);
		inside(head,nowlinkhead);
	}
	printfnodes(head->bro,0);
}
