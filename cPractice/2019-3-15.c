#include <stdio.h>
#define INT_MAX 9999999
int map[501][501];
int djs[501];
int djscheck[501];
int bikenum[501];
int neednum;
int problemstation;
int stationnum;
int roadn;
int minroad;
int check[501];
int result[501]; 
int minsetbike=INT_MAX;
int minleftbike=INT_MAX;
void dfs(int nowposition,int roadleft,int setbike,int leftbike,int index)
{
	int i;
	if(roadleft==0)
	{
		if(nowposition==problemstation)
		{
			if(setbike>minsetbike)
			{
				return;
			}
			else if(setbike==minsetbike&&leftbike>minleftbike)
			{
				return;
			}
			minsetbike=setbike;
			minleftbike=leftbike;
			for(i=0;i<=stationnum;i++)
			{
				if(check[i]!=0)
				{
					result[check[i]]=i;
				}
			}
			result[0]=0;
			return;
		}
		else
		{
			return;
		}
	}
	else if(roadleft<0)
	{
		return;
	}
	for(i=1;i<=stationnum;i++)
	{
		if(check[i]==0)
		{
			check[i]=index;
			if(neednum>bikenum[i])
			{
				if(leftbike>=neednum-bikenum[i])
					dfs(i,roadleft-map[nowposition][i],setbike,leftbike-neednum+bikenum[i],index+1);
				else
					dfs(i,roadleft-map[nowposition][i],setbike+neednum-bikenum[i]-leftbike,0,index+1);
			}
			else if(neednum<bikenum[i])
			{
				dfs(i,roadleft-map[nowposition][i],setbike,leftbike-neednum+bikenum[i],index+1);
			}
			else
			{
				dfs(i,roadleft-map[nowposition][i],setbike,0,index+1);
			}
			check[i]=0;
		}
	}
}
int main()
{
	int i,j,v;
	int a,b;
	int min;
	for(i=0;i<501;i++)
	{
		djs[i]=INT_MAX;
		check[i]=0;
		for(j=0;j<501;j++)
		{
			map[i][j]=INT_MAX;
		}
		map[i][i]=0;
		result[i]=0;
		djscheck[i]=0;
	}
	scanf("%d%d%d%d",&neednum,&stationnum,&problemstation,&roadn);
	for(i=1;i<=stationnum;i++)
	{
		scanf("%d",&bikenum[i]);
	}
	while(roadn)
	{
		roadn--;
		scanf("%d%d%d",&i,&j,&v);
		map[i][j]=v;
		map[j][i]=v;
	}
	for(i=1;i<=stationnum;i++)
	{
		djs[i]=map[0][i];
	}
	neednum=neednum/2;
	j=0;
	while(1)
	{
		min=INT_MAX;
		for(i=1;i<=stationnum;i++)
		{
			if(djscheck[i]==1)
				continue;
			if(min>djs[i])
			{
				min=djs[i];
			}
		}
		if(min==INT_MAX)
			break;
		for(i=1;i<=stationnum;i++)
		{
			if(djs[i]==min)
			{
				djscheck[i]=1;
				for(j=1;j<=stationnum;j++)
				{
					if(djscheck[j]==1)
						continue;
					if(djs[i]+map[i][j]<djs[j])
					{
						djs[j]=djs[i]+map[i][j];
					}
				}
			}
		}
	}
	minroad=djs[problemstation];
	dfs(0,minroad,0,0,1);
	printf("%d ",minsetbike);
	i=0;
	while(result[i]!=problemstation)
	{
		printf("%d->",result[i]);
		i++;
	}
	printf("%d %d",problemstation,minleftbike);
	return 0;
} 
