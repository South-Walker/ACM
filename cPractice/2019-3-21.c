#include <stdio.h>
void q1()
{
	int d,k;
	int i,j;
	double xi[200];
	double*t=xi;
	int ai[200];
	double fenmu;
	ai[0]=0;
	ai[1]=1;
	while(scanf("%d%d",&d,&k)>0)
	{
		if(k>=200)
		{
			k=199;
		}
		for(i=2;i<200;i++)
		{
			ai[i]=ai[i-1]+d;
		}
		for(i=1;i<=k;i++)
		{
			fenmu=0;
			for(j=i;j>0;j--)
			{
				fenmu+=ai[j];
				fenmu=1.0/fenmu;
			}
			xi[i]=fenmu;
		}
		printf("%.16lf",xi[k]);
	}
}
typedef struct
{
	int x;
	int y;
}queen;
int cmp1(const void*a,const void*b)
{
	return ((queen*)a)->x-((queen*)b)->x;
}
int cmp2(const void*a,const void*b)
{
	return ((queen*)a)->y-((queen*)b)->y;
}
int cmp3(const void*a,const void*b)
{
	queen*qa=(queen*)a;
	queen*qb=(queen*)b;
	return (qa->x-qa->y)-(qb->x-qb->y);
}
int cmp4(const void*a,const void*b)
{
	queen*qa=(queen*)a;
	queen*qb=(queen*)b;
	return (qa->x+qa->y)-(qb->x+qb->y);
}
void q2()
{
	queen qs[100001];
	int n;
	int a,b;
	int i,j;
	int temp;
	long long num;
	long long howmany=0;
	scanf("%d",&n);
	for(i=0;i<n;i++)
	{
		scanf("%d%d",&a,&b);
		qs[i].x=a;
		qs[i].y=b;
	}
	qsort(qs,n,sizeof(qs[0]),&cmp1);
	temp=-1;num=0;
	for(i=0;i<n;i++)
	{
		if(qs[i].x==temp)
		{
			num++;
		}
		else
		{
			if(num<2)
			{
				
			}
			else
			{
				howmany+=num*(num-1)/2;
			}
			temp=qs[i].x;
			num=1;
		}
	}
	if(num<2)
	{
		
	}
	else
	{
		howmany+=num*(num-1)/2;
	}
	qsort(qs,n,sizeof(qs[0]),&cmp2);
	temp=-1;num=0;
	for(i=0;i<n;i++)
	{
		if(qs[i].y==temp)
		{
			num++;
		}
		else
		{
			if(num<2)
			{
				
			}
			else
			{
				howmany+=num*(num-1)/2;
			}
			temp=qs[i].y;
			num=1;
		}
	}
	if(num<2)
	{
		
	}
	else
	{
		howmany+=num*(num-1)/2;
	}
	
	qsort(qs,n,sizeof(qs[0]),&cmp3);
	temp=-1;num=0;
	for(i=0;i<n;i++)
	{
		if(qs[i].x-qs[i].y==temp)
		{
			num++;
		}
		else
		{
			if(num<2)
			{
				
			}
			else
			{
				howmany+=num*(num-1)/2;
			}
			temp=qs[i].x-qs[i].y;
			num=1;
		}
	}
	if(num<2)
	{
		
	}
	else
	{
		howmany+=num*(num-1)/2;
	}
	
	
	qsort(qs,n,sizeof(qs[0]),&cmp4);
	temp=-1;num=0;
	for(i=0;i<n;i++)
	{
		if(qs[i].x+qs[i].y==temp)
		{
			num++;
		}
		else
		{
			if(num<2)
			{
				
			}
			else
			{
				howmany+=num*(num-1)/2;
			}
			temp=qs[i].x+qs[i].y;
			num=1;
		}
	}
	if(num<2)
	{
		
	}
	else
	{
		howmany+=num*(num-1)/2;
	}
	printf("%ld",howmany);
}
int prime[1001];  
int is_prime[1001];
int primenum;
void sieve(int n)
{
	int i,j;
    int p = 0;
    for(i = 0; i <= n; ++i)
        is_prime[i] = 1;
    is_prime[0] = is_prime[1] = 0;
    for (i = 2; i <= n; ++i){   //  注意数组大小是n
        if(is_prime[i]){
            prime[p++] = i;
            for(j = i + i; j <= n; j += i)  //  轻剪枝，j必定是i的倍数
                is_prime[j] = 0;
        }
    }
    primenum=p;   //  返回素数个数
}
void q3()
{
	int q,n;
	int i,j,numnow;
	int temp;
	int total;
	int right[300001];
	scanf("%d%d",&q,&n);
	sieve(1000);
	right[1]=1;
	for(i=2;i<=300000;i++)
	{
		temp=i;
		j=0;
		numnow=0;
		total=1;
		while(temp!=1)
		{
			if(temp%prime[j]==0)
			{
				numnow++;
				temp/=prime[j];
			}
			else
			{
				total*=(numnow+1);
				numnow=0;
				j++;
			}
		}
		if(numnow!=0)
		{
			total*=(numnow+1);
		}
		right[i]=total;
	}
	if(q==1)
	{
		printf("%d",right[n]);
	}
	else
	{
		total=0;
		for(i=1;i<n;i++)
		{
			total+=(right[i]*right[n-i]);
		}
		printf("%d",total);
	}
}
int main()
{
	q3();
	return 0;
}
