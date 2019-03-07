#include <stdio.h>
#include <math.h>
#include <string.h>
int all[24][6]={
	{1,2,3,4,5,6},{1,4,2,5,3,6},{1,3,5,2,4,6},{1,5,4,3,2,6},
	{2,6,3,4,1,5},{2,4,6,1,3,5},{2,3,1,6,4,5},{2,1,4,3,6,5},
	{3,2,6,1,5,4},{3,5,1,6,2,4},{3,1,2,5,6,4},{3,6,5,2,1,4},
	{4,2,1,6,5,3},{4,6,2,5,1,3},{4,5,6,1,2,3},{4,1,5,2,6,3},
	{5,6,4,3,1,2},{5,4,1,6,3,2},{5,3,6,1,4,2},{5,1,3,4,6,2},
	{6,5,3,4,2,1},{6,4,5,2,3,1},{6,2,4,3,5,1},{6,3,2,5,4,1}};
int isthesame(char*a,char*b)
{
	int i,j,k;
	for(i=0;i<24;i++)
	{
		for(j=0;j<6;j++)
		{
			if(b[all[i][j]-1]!=a[j])
			{
				break;
			}
			if(j==5)
				return 1;
		}
	}
	return 0;
}
int main()
{
	char s[20];
	FILE*input=fopen("C:\\Users\\lenovo\\Desktop\\test.txt","r");
	while(fscanf(input,"%s",s)!=EOF)
	{
		if(isthesame(&s[0],&s[6]))
		{
			printf("TRUE\n");
		}
		else
		{
			printf("FALSE\n");
		}
	}
	return 0;
}
int board[11][10];
int a,b,c,d;
int canchecap(int cx,int cy,int x,int y)
{
	int i,j,k;
	if(cx==x)
	{
		for(i=cy+1;i<y;i++)
		{
			if(board[x][i]!=0)
			{
				return 0;
			}
		}
		for(i=cy-1;i>y;i--)
		{
			if(board[x][i]!=0)
			{
				return 0;
			}
		}
	}
	else if(cy==y)
	{
		for(i=cx+1;i<x;i++)
		{
			if(board[i][y]!=0)
			{
				return 0;
			}
		}
		for(i=cx-1;i>x;i--)
		{
			if(board[i][y]!=0)
			{
				return 0;
			}
		}
	}
	else
	{
		return 0;
	}
	return 1;
}
int canpaocap(int px,int py,int x,int y)
{
	int haspassnum;
	int i,j,k;
	if(px==x)
	{
		haspassnum=0;
		for(i=py+1;i<y;i++)
		{
			if(board[x][i]!=0)
			{
				haspassnum++;
			}
		}
		for(i=py-1;i>y;i--)
		{
			if(board[x][i]!=0)
			{
				haspassnum++;
			}
		}
		if(haspassnum!=1)
		{
			return 0;
		}
	}
	else if(py==y)
	{
		haspassnum=0;
		for(i=px+1;i<x;i++)
		{
			if(board[i][y]!=0)
			{
				haspassnum++;
			}
		}
		for(i=px-1;i>x;i--)
		{
			if(board[i][y]!=0)
			{
				haspassnum++;
			}
		}		
		if(haspassnum!=1)
		{
			return 0;
		}
	}
	else
	{
		return 0;
	}
	return 1;
}
int canmacap(int mx,int my,int x,int y)
{
	if(mx+2==x)
	{
		if(board[mx+1][my]!=0)
			return 0;
		if(my+1==y||my-1==y)
			return 1;
	}
	else if(mx-2==x)
	{
		if(board[mx-1][my]!=0)
			return 0;
		if(my+1==y||my-1==y)
			return 1;
	}
	else if(my+2==y)
	{
		if(board[mx][my+1]!=0)
			return 0;
		if(mx+1==x||mx-1==x)
			return 1;
	}
	else if(my-2==y)
	{
		if(board[mx][my-1]!=0)
			return 0;
		if(mx+1==x||mx-1==x)
			return 1;
	}
	else
	{
		return 0;
	}
	return 0;
}
int canbecap(int x,int y)
{
	int i,j;
	int can=0;
	int flag;
	flag=0;
	if(y<4||y>6||x<1||x>3)
		return 1;
	for(i=1;i<11;i++)
	{
		for(j=1;j<10;j++)
		{
			if(i==x&&j==y)
				continue;
			switch(board[i][j])
			{
				case 2:
				case 3:
					if(canchecap(i,j,x,y))
						return 1;
					break;
				case 4:
					if(canmacap(i,j,x,y))
						return 1;
					break;
				case 5:
					if(canpaocap(i,j,x,y))
						return 1;
					break;
				default:
					break;
			}
		}
	}
	return 0;
}
int uva1589()
{
	int i,j,k;
	int n;
	int isredlost=0;
	char ch;
	while(1)
	{
		isredlost=0;
		for(i=0;i<11;i++)
		{
			for(j=0;j<10;j++)
			{
				board[i][j]=0;
			}
		}
		scanf("%d",&n);
		scanf("%d%d",&i,&j);
		if(i==0)
			break;
		a=i,b=j;
		while(n)
		{	
			n--;
			getchar();
			scanf("%c%d%d",&ch,&i,&j);
			switch(ch)
			{
				case 'G':
					board[i][j]=3;
					c=i;d=j;
					break;
				case 'R':
					board[i][j]=3;
					break;
				case 'H':
					board[i][j]=4;
					break;
				case 'C':
					board[i][j]=5;
					break;
			}
		}
		if(d=b)
		{
			isredlost=1;
			for(i=a;i<c;i++)
			{
				if(board[i][d]!=0)
				{
					isredlost=0;
				}
			}
		}
		if(canbecap(a-1,b)!=0&&canbecap(a+1,b)!=0&&canbecap(a,b+1)!=0&&canbecap(a,b-1)!=0&&isredlost!=1)
		{
			printf("YES\n");
		}
		else
		{
			printf("NO\n");
		}
	}
	return 0;
}
void change(char*a,int acount,char*b,int bcount)
{
	char temp;
	int max=199;
	int i;
	for(i=0;i<max+1;i++)
	{
		temp=a[i];
		a[i]=b[i];
		b[i]=temp;
	}
}
int getlen(char*a,char*b)
{
	int i,j,aindex,bindex,min;
	i=0;j=0;aindex=0;bindex=0;
	while(a[aindex]!='\0'&&b[bindex]!='\0')
	{
		if(a[aindex]=='2'&&b[bindex]=='2')
		{
			i++;j=0;
			aindex=i;bindex=j;
		}
		else
		{
			aindex++;bindex++;
		}
	}
	if(b[bindex]=='\0')
	{
		min=strlen(a);
	}
	else
	{
		min=strlen(a)+strlen(b)-bindex;
	}
	return min;
}
int uva1588()
{
	char a[201];
	char b[201];
	int i=0,j=0;
	int aindex=0,bindex=0;
	int min;
	while(scanf("%s%s",a,b)==2)
	{
		i=getlen(a,b);
		j=getlen(b,a);
		min=(i>j)?j:i;
		printf("%d\n",min);
	}
	return 0;
}
int uva202()
{
	int a,b,i,j;
	int last[10000];
	int lastcount=0;
	int nums[10000];
	int numscount=0;
	int beforepoint=0;
	int begin,end;
	int flag;
	int now;
	while(scanf("%d %d",&a,&b)!=EOF)
	{
		lastcount=0;
		numscount=0;
		beforepoint=a/b;
		now=a-beforepoint*b;
		flag=1;
		while(flag&&numscount<10000)
		{
			now*=10;
			nums[numscount]=now/b;
			numscount++;
			last[lastcount]=now;
			lastcount++;
			for(i=0;i<lastcount-1;i++)
			{
				if(last[i]==now)
				{
					begin=i;
					end=lastcount-1;
					flag=0;
					break;
				}
			}
			now=now%b;
		}
		if(flag!=0)
		{
			begin=0;
			end=50;
		}
		printf("%d/%d = %d.",a,b,beforepoint);
		for(i=0;i<begin;i++)
		{
			printf("%d",nums[i]);
		}
		printf("(");
		if(end<50)
		{
			for(;i<end;i++)
			{
				printf("%d",nums[i]);
			}
		}
		else
		{
			for(;i<50;i++)
			{
				printf("%d",nums[i]);
			}
		}
		if(flag!=0||end>50)
		{
			printf("...");
		}
		printf(")\n");
		printf("   %d = number of digits in repeating cycle\n\n",(flag)?99:end-begin);
	}
} 
