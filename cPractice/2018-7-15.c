#include <stdio.h>
#include <malloc.h>
#define MAX 1000000
typedef struct
{
	long* p;
	int count;
}minheap;
//Ê§°Ü·µ»ØMAX£» 
long pop(minheap*h)
{
	long temp;
	long answer;
	int nowindex;
	if(h->count==0)
	{
		return -1;
	}
	answer=h->p[1];
	nowindex=1;
	h->p[1]=MAX;
	while(1)
	{
		if(nowindex*2+1<=h->count)
		{
			if(h->p[nowindex*2]>=h->p[nowindex*2+1])
			{
				temp=h->p[nowindex];
				h->p[nowindex]=h->p[nowindex*2+1];
				h->p[nowindex*2+1]=temp;
				nowindex=nowindex*2+1;
			}
			else
			{
				temp=h->p[nowindex];
				h->p[nowindex]=h->p[nowindex*2];
				h->p[nowindex*2]=temp;
				nowindex*=2;
			}
		}
		else if(nowindex*2<=h->count)
		{
			temp=h->p[nowindex];
			h->p[nowindex]=h->p[nowindex*2];
			h->p[nowindex*2]=temp;
			nowindex*=2;
		}
		else
		{
			break;
		}
	}
	return answer;
}
void push(minheap*h,long p)
{
	int nowindex;
	h->count++;
	nowindex=h->count;
	h->p[h->count]=p;
	while(nowindex!=1)
	{
		if(h->p[nowindex/2]<=p)
		{
			break;
		}
		h->p[nowindex]=h->p[nowindex/2];
		nowindex/=2;
		h->p[nowindex]=p;
	}
}
void main()
{
	ecnu20();
}
void ecnu20()
{
	long n,s,x;
	long*w,*p;
	long temp;
	int i,j,k;
	long cost;
	int flag;
	minheap*h;
	h=(minheap*)malloc(sizeof(minheap));
	while(scanf("%ld%ld%ld",&n,&s,&x)==3)
	{
		h->p=(long*)malloc(n*sizeof(long));
		h->count=0;
		cost=0;
		flag=1;
		w=(long*)malloc(n*sizeof(long));
		p=(long*)malloc(n*sizeof(long));
		for(i=0;i<n;i++)
		{
			scanf("%ld",&w[i]);
		}
		for(i=0;i<n;i++)
		{
			scanf("%ld",&p[i]);
		}
		for(i=0;i<n&&flag;i++)
		{
			if(s>=w[i])
			{
			}
			else
			{
				while(s<w[i])
				{
					temp=pop(h);
					if(temp==MAX)
					{
						flag=0;
						break;
					}
					else
					{
						cost+=temp;
						s+=x;
					}
				}
			}
			s-=w[i];
			push(h,p[i]);
		}
		if(flag)
		{
			printf("%ld\n",cost);
		}
		else
		{
			printf("-1\n");
		}
		free(h->p);
	}
}
void ecnu18()
{
	unsigned long long n,a,b,c,d;
	unsigned long long temp,answer;
	while(scanf("%llu%llu%llu%llu%llu",&n,&a,&b,&c,&d)==5)
	{
		answer=0;
		if(a-b>=c-d)
		{
			if(n>=c)
			{
				temp=n-c;
				temp=temp/(c-d);
				temp+=1;
				n+=temp*d;
				n-=temp*c;
				answer+=temp;
			}
			if(n>=a)
			{
				temp=n-a;
				temp=temp/(a-b);
				temp+=1;
				n+=temp*b;
				n-=temp*a;
				answer+=temp;
			}
		}
		else
		{
			if(n>=a)
			{
				temp=n-a;
				temp=temp/(a-b);
				temp+=1;
				n+=temp*b;
				n-=temp*a;
				answer+=temp;
			}
			if(n>=c)
			{
				temp=n-c;
				temp=temp/(c-d);
				temp+=1;
				n+=temp*d;
				n-=temp*c;
				answer+=temp;
			}
		}
		printf("%llu\n",answer);
	}
} 
