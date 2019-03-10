#include <stdio.h>
#include <string.h>
#include <malloc.h>
//using namespace std;
void q1()
{
	char t[200];
	char s[200];
	int i,j,k;
	int ssize;
	int tsize;
	scanf("%s%s",s,t);
	ssize=strlen(s);
	tsize=ssize;
	for(i=0;i<tsize;i++)
	{
		j=i;k=0;
		while(k!=ssize)
		{
			if(s[j]!=t[k])
			{
				break;
			}
			k++;
			j++;
			if(j==tsize)
			{
				j=0;
			}
		}
		if(k==ssize)
		{
			printf("Yes");
			return;
		}
	}
	printf("No");
}

int magicvalue=50001;
void addinstudent(int*allstudent,int a,int b)
{
	int temp;
	int min,max;
	if(a==b)
		return;
	min=(a>b)?b:a;
	max=(a>b)?a:b;
	while(allstudent[max]>min)
	{
		if(allstudent[max]==magicvalue)
		{
			allstudent[max]=min;
			return;
		}
		max=allstudent[max];
	}
	if(allstudent[max]==min)
		return;
	temp=allstudent[max];
	allstudent[max]=min;
	addinstudent(allstudent,temp,min);
}
void q2()
{
	int allstudent[50001];
	int i,j,k;
	int min,max,n,m;
	int r=0;
	int casenum=0;
	while(1)
	{
		r=0;
		casenum++;
		scanf("%d%d",&n,&m);
		if(n==0&&m==0)
			return;
		for(i=1;i<=n;i++)
		{
			allstudent[i]=magicvalue;
		}
		while(m)
		{
			m--;
			scanf("%d%d",&i,&j);
			addinstudent(allstudent,i,j);
		}
		for(i=1;i<=n;i++)
		{
			if(allstudent[i]==magicvalue)
			{
				r++;
			}
		}
		printf("Case %d: %d\n",casenum,r);
	}
}
typedef struct
{
	int x;
	int y;
	int timenow;
}point;
typedef struct
{
	point ps[128];
	int head;
	int tail;
}queue;
point dequeue(queue*q)
{
	point r=q->ps[q->head];
	q->head+=1;
	if(q->head>=128)
	{
		q->head=0;
	}
	return r;
}
void enqueue(queue*q,point p)
{
	q->ps[q->tail]=p;
	q->tail+=1;
	if(q->tail>=128)
	{
		q->tail=0;
	}
}
int canjump(point newp)
{
	if(newp.x<0||newp.y<0)
		return 0;
	if(newp.x>=8||newp.y>=8)
		return 0;
	return 1;
}
void q3()
{
	int board[8][8];
	char cx1,cx2;
	point now;
	point newp;
	point dir;
	queue oq;
	queue*q=&oq;
	int i,j;
	int y1,y2;
	while(scanf("%c%d %c%d",&cx1,&y1,&cx2,&y2)>0)
	{
		q->head=0;
		q->tail=0;
		getchar();
		for(i=0;i<8;i++)
		{
			for(j=0;j<8;j++)
			{
				board[i][j]=-1;
			}
		}
		now.x=cx1-'a';
		now.y=y1-1;
		now.timenow=0;
		dir.x=cx2-'a';
		dir.y=y2-1;
		board[now.x][now.y]=0;
		enqueue(q,now);
		while(board[dir.x][dir.y]==-1&&q->head!=q->tail)
		{
			now=dequeue(q);
		//	printf("%d\n",now.timenow);
			newp.timenow=now.timenow+1;
			newp.x=now.x+2;
			newp.y=now.y+1;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}
			newp.x=now.x+2;
			newp.y=now.y-1;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}
			newp.x=now.x-2;
			newp.y=now.y+1;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}
			newp.x=now.x-2;
			newp.y=now.y-1;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}
			newp.x=now.x+1;
			newp.y=now.y+2;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}
			newp.x=now.x+1;
			newp.y=now.y-2;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}			
			newp.x=now.x-1;
			newp.y=now.y+2;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}			
			newp.x=now.x-1;
			newp.y=now.y-2;
			if(canjump(newp)&&board[newp.x][newp.y]==-1)
			{
				board[newp.x][newp.y]=newp.timenow;
				enqueue(q,newp);
			}
		}
		printf("To get from %c%d to %c%d takes %d knight moves.\n",cx1,y1,cx2,y2,board[dir.x][dir.y]);
	} 
}
int dp[30][30][30];
int map[30][30];
int m,n;
int s;
void dfs(int x,int y,int time,int num)
{
	int newnum;
	if(x>=m||y>=n||num>s)
		return;
	if(dp[x][y][num]==-1||dp[x][y][num]>time)
	{
		dp[x][y][num]=time;
	}
	else// if(dp[x][y][num]<=time)
	{
		return;
	}
	if(map[x][y]==1)
		newnum=num+1;
	else
		newnum=0;
	dfs(x+1,y,time+1,newnum);
	dfs(x-1,y,time+1,newnum);
	dfs(x,y+1,time+1,newnum);
	dfs(x,y-1,time+1,newnum);
}
void q4()
{
	int casenum;
	int i,j,k;
	int min=999999;
	scanf("%d",&casenum);
	while(casenum)
	{
		min=999999;
		casenum--;
		scanf("%d%d",&m,&n);
		scanf("%d",&s);
		for(i=0;i<m;i++)
		{
			for(j=0;j<n;j++)
			{
				scanf("%d",&map[i][j]);
				for(k=0;k<=s;k++)
				{
					dp[i][j][k]=-1;
				}
			}
		}

		dfs(0,0,0,0);
		for(k=0;k<=s;k++)
		{
			if(dp[m-1][n-1][k]!=-1)
			{
				min=(min>dp[m-1][n-1][k])?dp[m-1][n-1][k]:min;
			}
		}
		if(min==999999)
		{
			printf("-1\n");
		}
		else
		{
			printf("%d\n",min);
		}
	}
}
int main()
{
	q4();
	return 0;
} 
