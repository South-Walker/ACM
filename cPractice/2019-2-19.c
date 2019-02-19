#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>
#define MAX 999999999
 
int count;
void kmpMatch(char * s,int sLength,char * p,int pLength,int *prefix)
{
    int pPoint=0;
    int i;
    for(i=0; i<sLength;i++)
    {
 
 
        while(pPoint!=0&&(s[i]!=p[pPoint]))
        {
            pPoint = prefix[pPoint-1];
        }
        if(s[i]==p[pPoint])
        {
            pPoint++;
            if(pPoint == pLength)
            {
                count++;
                i=i-pPoint+2;
                pPoint=0;
			}
        }
 
 
    }
}
 
void kmpPrefixFunction(char *p,int length,int *prefix)
{
    prefix[0]=0;
    int k = 0,i;//前缀的长度
    for(i=1; i<length; i++)
    {
        while(k>0&&p[k]!=p[i])
        {
            k=prefix[k-1];
        }
        if(p[k]==p[i])//说明p[0...k-1]共k个都匹配了
        {
            k=k+1;
        }
        prefix[i]=k;
    }
}
 
 
int q1()
{
    char s[MAX],p[MAX];
    scanf("%s%s",s,p);
    int pLength = strlen(p);
    int *prefix = (int *)malloc(pLength*sizeof(int));
    int i;
    count=0;
    kmpPrefixFunction(p,pLength,prefix);
    kmpMatch(s,strlen(s),p,pLength,prefix);
    printf("%d",count);
    return 0;
}

char change(char a)
{
	switch(a)
	{
		case 'W':
			return 'Q';
		case 'S':
			return 'A';
		case 'X':
			return 'Z';
		case 'E':
			return 'W';
		case 'D':
			return 'S';
		case 'C':
			return 'X';
		case 'R':
			return 'E';
		case 'F':
			return 'D';
		case 'V':
			return 'C';
		case 'T':
			return 'R';
		case 'G':
			return 'F';
		case 'B':
			return 'V';
		case 'Y':
			return 'T';
		case 'H':
			return 'G';
		case 'N':
			return 'B';
		case 'U':
			return 'Y';
		case 'J':
			return 'H';
		case 'M':
			return 'N';
		case 'I':
			return 'U';
		case 'K':
			return 'J';
		case ',':
			return 'M';
		case 'O':
			return 'I';
		case 'L':
			return 'K';
		case '.':
			return ',';
		case 'P':
			return 'O';
		case ';':
			return 'L' ;
		case '/':
			return '.';
		case '[':
			return 'P';
		case '\'':
			return ';';
		case ']':
			return '[';
		case '\\':
			return ']';
		case '1':
			return '`';
		case '2':
			return '1';
		case '3':
			return '2';
		case '4':
			return '3';
		case '5':
			return '4';
		case '6':
			return '5';
		case '7':
			return '6';
		case '8':
			return '7';
		case '9':
			return '8';
		case '0':
			return '9';
		case '-':
			return '0';
		case '=':
			return '-';
	}
	return ' ';
}
int q2()
{
	int i;
	char s[10000];
	gets(s);
	i=0;
	while(s[i])
	{
		s[i]=change(s[i]);
		
		putchar(s[i]);
		i++; 
	}
	return 0;
}

int cmp(const void*a,const void*b)
{
	return *(int*)a-*(int*)b;
}
int q3()
{
	int num[1001];
	int n,i=0,last=INT_MAX;
	scanf("%d",&n);
	while(n!=i)
	{
		scanf("%d",&num[i]);
		i++;
	}
	qsort(num,n,sizeof(num[0]),&cmp);
	for(i=0;i<n;i++)
	{
		if(num[i]!=last)
		{
			if(last!=INT_MAX)
			{
				printf(" ");
			}
			printf("%d",num[i]);
			last=num[i];
		}
	}
}

int cost[6][6];
int dp[6][6][4];
int bx,by,ex,ey;
void solution(int x,int y,int state,int tcost)
{
	int i;
	int nowstate,nowcost;
	int flag=1;
	if(x<5)
	{		
		nowcost=state*cost[x+1][y];
		nowstate=nowcost%4+1;
		flag=1;
		for(i=0;i<nowstate;i++)
		{
			if(dp[x+1][y][i]<tcost+nowcost)
				flag=0;
		}
		if(flag)
		{		
			dp[x+1][y][nowstate-1]=tcost+nowcost;
			solution(x+1,y,nowstate,dp[x+1][y][nowstate-1]);
		}
	}
	if(x>0)
	{
		nowcost=state*cost[x-1][y];
		nowstate=nowcost%4+1;
		flag=1;
		for(i=0;i<nowstate;i++)
		{
			if(dp[x-1][y][i]<tcost+nowcost)
				flag=0;
		}
		if(flag)
		{
			dp[x-1][y][nowstate-1]=tcost+nowcost;
			solution(x-1,y,nowstate,dp[x-1][y][nowstate-1]);
		}
	}	
	if(y<5)
	{		
		nowcost=state*cost[x][y+1];
		nowstate=nowcost%4+1;
		flag=1;
		for(i=0;i<nowstate;i++)
		{
			if(dp[x][y+1][i]<tcost+nowcost)
				flag=0;
		}
		if(flag)
		{
			dp[x][y+1][nowstate-1]=tcost+nowcost;
			solution(x,y+1,nowstate,dp[x][y+1][nowstate-1]);
		}
	}
	if(y>0)
	{
		nowcost=state*cost[x][y-1];
		nowstate=nowcost%4+1;
		flag=1;
		for(i=0;i<nowstate;i++)
		{
			if(dp[x][y-1][i]<tcost+nowcost)
				flag=0;
		}
		if(flag)
		{
			dp[x][y-1][nowstate-1]=tcost+nowcost;
			solution(x,y-1,nowstate,dp[x][y-1][nowstate-1]);
		}
	}
}
int main()
{
	int i,j,k;
	int now;
	int min=MAX;
	for(i=0;i<6;i++)
	{
		for(j=0;j<6;j++)
		{
			scanf("%d",&now);
			cost[i][j]=now; 
			for(k=0;k<4;k++)
			{
				dp[i][j][k]=MAX;
			} 
		}
	}
	scanf("%d%d%d%d",&bx,&by,&ex,&ey);
	dp[bx][by][0]=0;
	solution(bx,by,1,0);
	for(i=0;i<4;i++)
	{
		min=(dp[ex][ey][i]<min)?dp[ex][ey][i]:min;
	}
	printf("%d",min);
}
