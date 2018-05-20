#include <stdio.h>
#include <malloc.h>
#include <limits.h>
main()
{
	int *dungeon[3],i=0;
	int now1[]={-2,-3,3};
	int now2[]={-5,-10,1};
	int now3[]={10,30,-5};
	dungeon[0]=now1;
	dungeon[1]=now2;
	dungeon[2]=now3;
	int rowlen=3;
	int collens[]={3,3,3};
	printf("%d", calculateMinimumHP(dungeon,rowlen,collens));
}
int calculateMinimumHP(int** dungeon, int dungeonRowSize, int *dungeonColSizes)
{
	int *dp[dungeonRowSize];
	int i,j;
	int nextMinHP=INT_MAX;
	for(i=0;i<dungeonRowSize;i++)
	{
		dp[i]=(int*)malloc(dungeonColSizes[i]*sizeof(int));
	}
	for(i=dungeonRowSize-1;i>=0;i--)
	{
		for(j=dungeonColSizes[i]-1;j>=0;j--)
		{
			nextMinHP=INT_MAX;
			if(j==dungeonColSizes[i]-1 && i==dungeonRowSize-1)
				nextMinHP=0;
			else
			{
				if(j<dungeonColSizes[i]-1)
				{
					nextMinHP=(nextMinHP>dp[i][j+1])?dp[i][j+1]:nextMinHP;
				}
				if(i<dungeonRowSize-1)
				{
					nextMinHP=(nextMinHP>dp[i+1][j])?dp[i+1][j]:nextMinHP;
				}
			}
			if(dungeon[i][j]<0)
			{
				dp[i][j]=nextMinHP-dungeon[i][j];
			}
			else
			{
				dp[i][j]=(0>nextMinHP-dungeon[i][j])?0:nextMinHP-dungeon[i][j]; 
			}
		}
	}
	return dp[0][0]+1;    
}
int maxArea(int* height, int heightSize) 
{
	if(heightSize<=1)
	{
		return 0;
	}
    int x=(height[0]>height[heightSize-1])?height[heightSize-1]:height[0];
    x*=(heightSize-1);
    int *PFronter=height,*PLatter=height+heightSize-1;
    int temp;
    while(PFronter<PLatter)
    {
    	if(*PFronter<=*PLatter)
    	{
    		temp=*PFronter;
    		while(*PFronter<=temp)
    		{
  	  			PFronter++;
			}
		}
		else
		{
    		temp=*PLatter;
    		while(*PLatter<=temp)
    		{
    			PLatter--;
			}
		}
		temp=(*PFronter>=*PLatter)?*PLatter:*PFronter;
		temp*=(PLatter-PFronter);
		x=(temp>x)?temp:x;
	}
	return x;
}
