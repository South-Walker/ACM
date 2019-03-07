#include <stdio.h>
#include <string.h>
int cab(int a,int b)
{
	int i=1;
	int j=a;
	int r=1;
	if(b==0)
		return 1;
	for(i=a;i>=a-b+1;i--)
	{
		r*=i;
	}
	for(i=1;i<=b;i++)
	{
		r/=i;
	}
	return r;
}
char pre[30],post[30];
int m;
int treenum(int prea,int preb,int posta,int postb)
{
	int i,j;
	int imax,jmax;
	int r=1;
	int sub=0;
	int len;
	char temp;
	i=0;imax=0;j=0;jmax=0;
	i=prea+1;j=posta;
	imax=i;jmax=j;
	while(i<=preb)
	{
		temp=pre[i];
		while(post[jmax]!=temp)
		{
			jmax++;
			imax++;
		}
		sub++;
		r*=treenum(i,imax,j,jmax);
		imax++;
		jmax++;
		i=imax;
		j=jmax;
	}
	r*=cab(m,sub);
	return r;
}
int q1()
{
	int r; 
	while(scanf("%d %s %s",&m,pre,post)!=EOF)
	{
		r=treenum(0,strlen(pre)-1,0,strlen(post)-1);
		printf("%d\n",r);
	}
} 
#define MVALUE 100001
typedef struct
{
	int a;
	int b;
	int value;
}edge;
int map[100][100];
int check[100];
int lennow=1;
int n,m;
int addroad(int from,int to,int value)
{
	int i,j;
	int valuenow;
	map[from][to]=value;
	map[to][from]=value;
	for(i=0;i<n;i++)
	{
		if(i==to||i==from)
		{
			continue;
		}
		if(map[i][to]==MVALUE&&map[i][from]!=MVALUE)
		{
			valuenow=(map[from][to]+map[i][from])%100000;
			addroad(i,to,valuenow);
		}
	}
	for(j=0;j<n;j++)
	{
		if(j==to||j==from)
		{
			continue;
		}
		if(map[from][j]==MVALUE&&map[to][j]!=MVALUE)
		{
			valuenow=(map[from][to]+map[to][j])%100000;
			addroad(from,j,valuenow);
		}
	}
}
int q2m1false()
{
	int i,j,k;
	for(i=0;i<100;i++)
	{
		for(j=0;j<100;j++)
		{
			map[i][j]=MVALUE;
			if(i==j)
			{
				map[i][j]=0;
			}
		}
	}
	scanf("%d%d",&n,&m);
	while(m)
	{
		m--;
		scanf("%d%d",&i,&j);
		if(map[i][j]!=MVALUE&&map[j][i]!=MVALUE)
		{
			
		}
		else
		{
			addroad(i,j,lennow);
		}
		lennow*=2;
		lennow=lennow%100000;
	}
	
	for(i=1;i<n;i++)
	{
		if(map[0][i]==MVALUE)
		{
			printf("-1\n");
		}
		else
			printf("%d\n",map[0][i]);
	}
}
int iscircle()
{
	
}
void q2m2()
{
	int i,j;
	int max,min;
	edge es=[100];
	int lennow=1;
	int ecount=0;
	int temp;
	for(i=0;i<100;i++)
	{
		for(j=0;j<100;j++)
		{
			map[i][j]=MVALUE;
			if(i==j)
			{
				map[i][j]=0;
			}
		}
		check[i]=MVALUE;
	}
	scanf("%d%d",&n,&m);
	while(m)
	{
		m--;
		scanf("%d%d",&i,&j);
		max=(i>j)?i:j;
		min=(i>j)?j:i;
		i=max;j=min;
		while(1)
		{
			temp=check[max];
			if(temp==MVALUE)
			{
				check[max]=min;
				es[ecount].a=i;
				es[ecount].b=j;
				es[ecount].value=lennow;
			}
		}
		
		lennow*=2;
		lennow=lennow%100000;
	}
}
int main()
{
	q2m2();
}

