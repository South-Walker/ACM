#include <stdio.h>
int howmany(char*x,int xcount,char*guo,int guocount)
{
	int i,j=0;
	int r=0;
	for(i=0;i<guocount;i++)
	{
		if(x[j]==guo[i])
		{
			r++;
		}
		j++;
		if(j>=xcount)
		{
			j=0;
		}
	}
	return r;
}
int q1()
{
	char*a="ABC";
	char*b="BABC";
	char*c="CCAABB";
	int n;
	int ia,ib,ic;
	int max;
	char guo[200];
	scanf("%d",&n);
	scanf("%s",guo);
	ia=howmany(a,3,guo,n);
	ib=howmany(b,4,guo,n);
	ic=howmany(c,6,guo,n);
	max=(ia>ib)?ia:ib;
	max=(max>ic)?max:ic;
	printf("%d\n",max);
	if(max==ia)
	{
		printf("Adrian\n");
	}
	if(max==ib)
	{
		printf("Bruno\n");
	}
	if(max==ic)
	{
		printf("Goran\n");
	}
	return 0;
}
typedef struct
{
	int havetime;
	int no;
}guest;
int cmp(const void*a,const void*b)
{
	return ((guest*)a)->havetime-((guest*)b)->havetime; 
}
int q2()
{
	int guestnum;
	int i,j;
	int a,b;
	guest guests[10000];
	scanf("%d",&guestnum);
	for(i=0;i<guestnum;i++)
	{
		scanf("%d%d",&a,&b);
		guests[i].no=i+1;
		guests[i].havetime=a+b;
	}
	qsort(guests,guestnum,sizeof(guests[0]),&cmp);
	for(i=0;i<guestnum;i++)
	{
		printf("%d ",guests[i].no);
	}
	return 0;
}  
typedef struct node
{
	int ai;
	int time;
	struct node*left;
	struct node*right;
}tree;
tree* create(int now)
{
	tree*r=(tree*)malloc(sizeof(tree));
	r->ai=now;
	r->time=1;
	r->left=NULL;
	r->right=NULL;
	return r;
}
void add(tree*root,int now)
{
	if(root->ai==now)
	{
		root->time++;
		return;
	}
	if(root->ai<now)
	{
		if(root->right!=NULL)
		{
			add(root->right,now);
			return;
		}
		else
		{
			root->right=create(now);
			return;
		}
	}
	else
	{
		if(root->left!=NULL)
		{
			add(root->left,now);
			return;
		}
		else
		{
			root->left=create(now);
			return;
		}
	}
}
int allxian=0;
void searchall(tree*root)
{
	if(root==NULL)
		return;
	searchall(root->left);
	searchall(root->right);
	if(root->time%2!=0)
	{
		allxian++;
	}
}
int q3()
{
	int alla[100001];
	int allcount=0;
	int i,j;
	int now;
	tree*root;
	scanf("%d",&allcount);
	scanf("%d",&now);
	root=create(now);
	for(i=0;i<allcount-1;i++)
	{
		scanf("%d",&now);
		add(root,now);
	}
	searchall(root);
	printf("%d",allxian);
	return 0;
} 
typedef struct
{
	int time;
	int value;
}xiancao;
xiancao all[20];
int check[20];
int max=0;
int count;
void search(int timenow,int value)
{
	int i;
	for(i=0;i<count;i++)
	{
		if(check[i]==0)
		{
			if(timenow>=all[i].time)
			{
				check[i]=1;
				search(timenow-all[i].time,value+all[i].value);
				check[i]=0;
			}
		}
	}
	max=(value>max)?value:max;
}
int q4()
{
	int alltime;
	int i,j;
	int a,b;
	scanf("%d%d",&alltime,&count);
	for(i=0;i<count;i++)
	{
		scanf("%d%d",&a,&b);
		all[i].time=a;
		all[i].value=b;
		check[i]=0;
	}
	search(alltime,0);
	printf("%d",max);
	return 0;
} 
long long all[30000];
long long max=999999999;
int allcount=0;
int check(long long num)
{
	int have3=0;
	int have5=0;
	int have7=0;
	long long now=num;
	while(now!=0)
	{
		if(now%10==3)
		{
			have3=1;
		}
		else if(now%10==5)
		{
			have5=1;
		}
		else
		{
			have7=1;
		}
		now/=10;
	}
	if(have3==1&&have5==1&&have7==1)
	{
		return 1;
	}
	return 0;
}
void getall(long long now)
{
	if(now>max)
		return;
	if(check(now)==1)
	{
		all[allcount]=now;
		allcount++;
	}
	getall(now*10+3);
	getall(now*10+5);
	getall(now*10+7);
}
int cmp(const void*a,const void*b)
{
	long long la=*(long long*)a;
	long long lb=*(long long*)b;
	if(la>=lb)
		return 1;
	else
		return -1;
}
int q5()
{
	int i,j;
	long long time;
	getall(3);
	getall(5);
	getall(7);
	qsort(all,allcount,sizeof(all[0]),&cmp);
	scanf("%lld",&time);
	for(i=0;i<allcount;i++)
	{
		if(all[i]<=time)
		{
			continue;
		}
		else
		{
			break; 
		}
	}
	printf("%d",i);
	return 0;
} 
long long booknum[51];
int aorb(long long n,long long k)
{
	long long ppn,pn;
	if(n==0||n==1)
	{
		return n;
	}
	ppn=booknum[n-2];
	pn=booknum[n-1];
	if(k<=ppn)
	{
		return aorb(n-2,k);
	}
	else
	{
		return aorb(n-1,k-ppn);
	}
}
int q6()
{
	long long a1=1,a2=1,now;
	long long n,k;
	int i,j;
	int num;
	booknum[0]=1;
	booknum[1]=1;
	for(i=2;i<51;i++)
	{
		now=a1+a2;
		booknum[i]=now;
		a1=a2;a2=now;
	}
	scanf("%d",&num);
	while(num)
	{
		num--;
		scanf("%lld %lld",&n,&k);
		if(aorb(n,k)==0)
		{
			printf("a\n");
		}
		else
		{
			printf("b\n");
		}
	}
	return 0;
} 
