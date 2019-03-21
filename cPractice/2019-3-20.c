#include <stdio.h>
typedef struct 
{
	int father;
	int good;
	int g;
}person;
int main()
{
	double r;
	int n;
	int root;
	int temp;
	int passg;
	double total=0;
	double price;
	person ps[100001];
	double prices[100001];
	int i,j;
	int a,b;
	scanf("%d%lf%lf",&n,&price,&r);
	r/=100;
	r+=1;
	for(i=0;i<100001;i++)
	{
		ps[i].father=-1;
		ps[i].good=-1;
		ps[i].g=-1;
		if(i==0)
		{
			prices[i]=price;
		}
		else
		{
			prices[i]=r*prices[i-1];
		}
	}
	for(i=0;i<n;i++)
	{
		scanf("%d",&a);
		if(a==0)
		{
			scanf("%d",&ps[i].good);
		}
		else
		{
			for(j=0;j<a;j++)
			{
				scanf("%d",&b);
				ps[b].father=i;
			}
		}
	}
	for(i=0;i<n;i++)
	{
		if(ps[i].father==-1)
		{
			root=i;
			break;
		}
	}
	ps[root].g=0;
	for(i=0;i<n;i++)
	{
		if(ps[i].g!=-1)
		{
			continue;
		}
		temp=i;
		passg=0;
		while(ps[temp].g==-1)
		{
			temp=ps[temp].father;
			passg++;
		}
		passg+=ps[temp].g;
		temp=i;
		while(ps[temp].g==-1)
		{
			ps[temp].g=passg;
			passg--;
			temp=ps[temp].father;
		}
	}
	for(i=0;i<n;i++)
	{
		if(ps[i].good!=-1)
		{
			total+=ps[i].good*prices[ps[i].g];
		}
	}
	printf("%.1llf",total);
}
