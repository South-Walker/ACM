#include <stdio.h>
#include <malloc.h>
int find(char*,char);
char* intToRoman(int); 
int totalNQueens(int);
char*** solveNQueens(int,int*);
void setChess2(int n,int[n][n],int,int,char***,int*);
main()
{
	int*returnSize,n=9,size=0;
	returnSize=&size;
	char*** boards=solveNQueens(n,returnSize);
	int i,j,k;
	char** aboard,*row;
	for(i=0;i<*returnSize;i++)
	{
		aboard=boards[i];
		for(j=0;j<n;j++)
		{
			row=aboard[j];
			for(k=0;k<n;k++)
			{
				printf("%c",row[k]);
			}
			printf("\n");
		}
		printf("\n\n\n");
	}
}
char*** solveNQueens(int n, int* returnSize) 
{
    int board[n][n];
    int i,j;
	char ***result=(char***)malloc(sizeof(char**)*400);
    for(i=0;i<n;i++)
    {
    	for(j=0;j<n;j++)
    	{
    		board[i][j]=0;
		}
	}
	for(i=0;i<n;i++)
	{
		setChess2(n,board,0,i,result,returnSize);
	}
	result=(char***)realloc(result,sizeof(char**)*(*returnSize));
	return result;
}
void setChess2(int n,int board[n][n],int row,int col,char*** result,int* returnSize)
{
	int i,j,k;
	board[row][col]=1;
	row+=1;
	if(row==n)
	{
		//save
		char** cboard=(char**)malloc(sizeof(char*)*n);
		for(i=0;i<n;i++)
		{
			char *row=(char *)malloc(sizeof(char)*(n+1));
			for(j=0;j<n;j++)
			{
				row[j]=(board[i][j])?'Q':'.';
			}
			row[n]='\0';
			cboard[i]=row;	
		}
		int index = *returnSize;
		result+=index;
		*result=cboard; 
		*returnSize+=1;
	}
	else
	{
		for(i=0;i<n;i++)
		{
			int could=1;
			for(j=0;j<row;j++)
			{
				for(k=0;k<n;k++)
				{
					if(could&&board[j][k])
					{
						if(k==i||
						(j-k==row-i)||
						(j+k)==row+i)
						{
							could=0;
						}
					}
				}
			}
			if(could)
			{
				setChess2(n,board,row,i,result,returnSize);
			}
		}
	}
	board[row-1][col]=0;
}
int totalNQueens(int n) 
{
    int board[n][n];
    int i,j,result=0;
    for(i=0;i<n;i++)
    {
    	for(j=0;j<n;j++)
    	{
    		board[i][j]=0;
		}
	}
	for(i=0;i<n;i++)
	{
		result+=setChess(n,board,0,i);
	}
	return result;
}
int setChess(int n,int board[n][n],int row,int col)
{
	int i,j,k,result=0;
	board[row][col]=1;
	row+=1;
	if(row==n)
	{
		result=1;
	}
	else
	{
		for(i=0;i<n;i++)
		{
			int could=1;
			for(j=0;j<row;j++)
			{
				for(k=0;k<n;k++)
				{
					if(could&&board[j][k])
					{
						if(k==i||
						(j-k==row-i)||
						(j+k)==row+i)
						{
							could=0;
						}
					}
				}
			}
			if(could)
			{
				result+=setChess(n,board,row,i);
			}
		}
	}
	board[row-1][col]=0;
	return result;	
}
char* intToRoman(int num) 
{
    static char romanChar[]={'M','D','C','L','X','V','I','\0'};
    static int romanValue[]={1000,500,100,50,10,5,1};
    char *result=(char *)malloc(sizeof(char)*30);
    int ptwrite=0;
    int position=0;
    while(num!=0)
    {
    	if(num>=romanValue[position])
    	{
    		result[ptwrite]=romanChar[position];
    		num-=romanValue[position];
    		ptwrite++;
		}
		else if((position==1||position==3||position==5)&&
		num+romanValue[position+1]>=romanValue[position])
		{
    		result[ptwrite]=romanChar[position+1];
    		num+=romanValue[position+1];
    		ptwrite++;
    		result[ptwrite]=romanChar[position];
    		num-=romanValue[position];
    		ptwrite++;
    		position++;
		}
		else if((position==0||position==2||position==4)&&
		num+romanValue[position+2]>=romanValue[position])
		{
    		result[ptwrite]=romanChar[position+2];
    		num+=romanValue[position+2];
    		ptwrite++;
    		result[ptwrite]=romanChar[position];
    		num-=romanValue[position];
    		ptwrite++;
    		position++;
		}
		else
		{
			position++;
		}
	}
	result[ptwrite]='\0';
	//result=(char*)realloc(result,sizeof(char)*ptwrite);
	return result;
}
int romanToInt(char* s) 
{
	//¼Óstatic 
    static char romanChar[]={'M','D','C','L','X','V','I','\0'};
    static int romanValue[]={1000,500,100,50,10,5,1};
    int romanCharPosition;
    int position=0,repeatnum=0;
    int result=0,now,post;
    while(s[position]!='\0')
    {
    	repeatnum++;
    	now=find(romanChar,s[position]);
    	post=find(romanChar,s[position+1]);
    	if(s[position]==s[position+1])
    	{
		}
		else if(now>post)
		{
			result-=repeatnum*romanValue[now];
			repeatnum=0;
		}
    	else
    	{
    		result+=repeatnum*romanValue[now];
    		repeatnum=0;
		}
		position++;
	}
	return result;
} 
int find(char* s,char target)
{
	int index=0;
	while(*s!='\0')
	{
		if(*s==target)
			break;
		index++;
		s++;
	}
	return index;
}
