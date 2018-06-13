#include <stdio.h>
#include <malloc.h>
#include <limits.h>
void list(int* r);
void time(int* r,int* a,int b);
void add(int* r,int* temp);
void main()
{
	int n;
	scanf("%d",&n);
	fakeecnu5(n);
} 
void ecnu5(int n)
{
	//int n;
	int i,j,k;
	int temp;
	int *atemp=(int*)calloc(10000,sizeof(int));
	//scanf("%d",&n);
	//dp[n]表示n一定会有 
	int* dp[n+1];
	for(i=0;i<=n;i++)
	{
		dp[i]=(int*)calloc(10000,sizeof(int));
	}
	dp[0][0]=-1;
	for(i=1;i<=n;i++)
	{
		temp=i*i;
		k=0;
		while(temp)
		{
			dp[i][k]=temp%10;
			temp/=10;
			k++;
		}
		dp[i][k]=-1;
		for(j=1;j<i-1;j++)
		{
			atemp[0]=-1;
			time(atemp,dp[j],i*i);
			add(dp[i],atemp);
		}
	}
	atemp[0]=-1;
	for(i=0;i<=n;i++)
	{
		add(atemp,dp[i]);
	}
	list(atemp);
}
void equal(int* r,int temp)
{
	int atemp=temp;
	int k=0;
	while(atemp)
	{
		r[k]=atemp%10;
		atemp/=10;
		k++;
	}
	r[k]=-1;
}
void list(int* r)
{
	int len=0;
	while(r[len]!=-1)
	{
		len++;
	}
	len--;
	int i;
	for(i=len;i>=0;i--)
	{
		printf("%d",r[i]);
	}
	if(len<0)
	{
		printf("0");
	}
	printf("\n");
}
void time(int* r,int* a,int b)
{
	//优化这个，已经过了8个样例了，加油！ 
	int i,j,k; 
	int tonext=0;
	for(i=0;i<10000;i++)
	{
		r[i]=0;
	}
	i=0;j=0;
	while(a[i]!=-1)
	{
		r[j]=a[i]*b;
		i++;j++;
	}
	for(i=0;i<10000;i++)
	{
		r[i]+=tonext;
		tonext=0;
		if(r[i]>=10)
		{
			tonext=r[i]/10;
			r[i]=r[i]%10;
		}
	}
	for(i=9999;i>=0;i--)
	{
		if(r[i]!=0)
		{
			r[i+1]=-1;
			break;
		}
	}
	if(i==-1)
	{
		r[0]=-1;
	}
}
void add(int* r,int* temp)
{
	int tonext=0;
	int rindex=0;
	int tempindex=0;
	while(temp[tempindex]!=-1&&r[rindex]!=-1)
	{
		r[rindex]=r[rindex]+temp[tempindex]+tonext;
		tonext=0;
		if(r[rindex]>=10)
		{
			r[rindex]-=10;
			tonext+=1;
		}
		rindex++;
		tempindex++;
	}
	if(temp[tempindex]==-1)
	{
		while(tonext==1&&r[rindex]!=-1)
		{
			r[rindex]+=tonext;
			tonext=0;
			if(r[rindex]>=10)
			{
				r[rindex]-=10;
				tonext+=1;
			}
			rindex++;
		}
		if(tonext==0)
			return;
		else
		{
			r[rindex]=tonext;
			rindex++;
			r[rindex]=-1;
			return;
		}
	}
	else
	{
		while(tonext==1&&temp[tempindex]!=-1)
		{
			r[rindex]=temp[tempindex]+tonext;
			tonext=0;
			if(r[rindex]>=10)
			{
				r[rindex]-=10;
				tonext+=1;
			}
			rindex++;
			tempindex++;
			r[rindex]=-1;
		}
		if(tonext==0)
		{
			while(temp[tempindex]!=-1)
			{
				r[rindex]=temp[tempindex];
				rindex++;
				tempindex++;
				r[rindex]=-1;
			}
			return;
		}
		else
		{
			r[rindex]=tonext;
			rindex++;
			r[rindex]=-1;
		}
	}
}
void fakeecnu5(int n)
{
//	int n;
	int i,j;
//	scanf("%d",&n);
	if(n==0)
	{
		return 0;
	}
	//dp[n]表示n一定会有 
	long long dp[n+1];
	dp[0]=0;
	for(i=1;i<=n;i++)
	{
		dp[i]=0;
		dp[i]+=i*i;
		for(j=1;j<i-1;j++)
		{
			dp[i]+=i*i*dp[j];
		}
	}
	int result=0;
	for(i=0;i<=n;i++)
	{
		result+=dp[i];
	}
	printf("%lld\n",result);
}
int poj1258(int n)
{
	int i,j,k;
	int matrix[n][n];
	int set[n];
	int mindistance[n];
	int totalcost=0;
	int min;
	for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
		{
			scanf("%d",&matrix[i][j]);
		}
	}
	for(i=0;i<n;i++)
	{
		mindistance[i]=matrix[0][i];
		set[i]=0;
	}
	set[0]=-1;
	for(i=1;i<n;i++)
	{
		min=INT_MAX;
		k=-1;
		for(j=1;j<n;j++)
		{
			if(set[j]!=-1&&mindistance[j]<min)
			{
				k=j;
				min=mindistance[j];
			}
		}
		if(k==-1)
		{
			break;
		}
		totalcost+=min;
		set[k]=-1;
		for(j=0;j<n;j++)
		{
			if(set[j]!=-1&&mindistance[j]>matrix[j][k])
			{
				mindistance[j]=matrix[j][k];
				set[j]=k;
			}
		} 
	}
	return totalcost;
}
void ecnu3()
{
	int n,m;
	int i,a,s;
	int temp;
	int indexnow;
	scanf("%d %d",&n,&m);
	char*ss[n];
	int f[n];
	for(i=0;i<n;i++)
	{
		ss[i]=(char*)malloc(11*sizeof(char));
		scanf("%d %s",&f[i],ss[i]);
	}
	indexnow=0;
	for(i=0;i<m;i++)
	{
		scanf("%d %d",&a,&s);
		temp=a^f[indexnow];
		if(!temp)
		{
			temp=-1;
		}
		temp=temp*s;
		indexnow+=temp;
		if(indexnow<0)
		{
			indexnow+=n;
		}
		if(indexnow>=n)
		{
			indexnow-=n;
		}
	}
	printf("%s",ss[indexnow]);	
}

