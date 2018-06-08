#include <stdio.h>
#include <malloc.h>
#include <limits.h>
typedef int bool;
#define true 1
#define false 0
main()
{
	preimageSizeFZF(0);
	 
}
bool validTicTacToe(char** board, int boardSize) 
{
    int i,j;
    int xcount=0,ocount=0;
    for(i=0;i<boardSize;i++)
    {
    	j=0;
    	while(board[i][j]!='\0')
    	{
    		if(board[i][j]=='X')
    			xcount++;
    		else if(board[i][j]=='O')
    			ocount++;
    		j++;
		}
	}
	if(ocount>xcount||xcount>=ocount+2)
		return false;
	if(ocount==xcount)
	{
		if(board[0][0]=='X'&&board[0][1]=='X'&&board[0][2]=='X')
		{
			return false;
		}
		if(board[1][0]=='X'&&board[1][1]=='X'&&board[1][2]=='X')
		{
			return false;
		}
		if(board[2][0]=='X'&&board[2][1]=='X'&&board[2][2]=='X')
		{
			return false;
		}
		if(board[0][0]=='X'&&board[1][0]=='X'&&board[2][0]=='X')
		{
			return false;
		}
		if(board[0][1]=='X'&&board[1][1]=='X'&&board[2][1]=='X')
		{
			return false;
		}
		if(board[0][2]=='X'&&board[1][2]=='X'&&board[2][2]=='X')
		{
			return false;
		}
		if(board[0][0]=='X'&&board[1][1]=='X'&&board[2][2]=='X')
		{
			return false;
		}
		if(board[0][2]=='X'&&board[1][1]=='X'&&board[2][0]=='X')
		{
			return false;
		}
	}
	else//xcount==ocount+1
	{
		if(board[0][0]=='O'&&board[0][1]=='O'&&board[0][2]=='O')
		{
			return false;
		}
		if(board[1][0]=='O'&&board[1][1]=='O'&&board[1][2]=='O')
		{
			return false;
		}
		if(board[2][0]=='O'&&board[2][1]=='O'&&board[2][2]=='O')
		{
			return false;
		}
		if(board[0][0]=='O'&&board[1][0]=='O'&&board[2][0]=='O')
		{
			return false;
		}
		if(board[0][1]=='O'&&board[1][1]=='O'&&board[2][1]=='O')
		{
			return false;
		}
		if(board[0][2]=='O'&&board[1][2]=='O'&&board[2][2]=='O')
		{
			return false;
		}
		if(board[0][0]=='O'&&board[1][1]=='O'&&board[2][2]=='O')
		{
			return false;
		}
		if(board[0][2]=='O'&&board[1][1]=='O'&&board[2][0]=='O')
		{
			return false;
		}
	}
	return true;
}
int preimageSizeFZF(int K) 
{
	int max=INT_MAX;int target;
    long long* array=(long long*)calloc(20,sizeof(long long));
    int i=0,j;
    do
    {
    	i++;
    	array[i]=5*array[i-1]+1;
	}
    while(array[i]<=max);
    i=0;
    while(array[i+1]<K)i++;
    for(;i>0;i--)
    {
    	if(K==5*array[i])
    		return 0;
    	K=K%array[i];
	}
	return 5;
}
