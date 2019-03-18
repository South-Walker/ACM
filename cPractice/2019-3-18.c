#include <stdio.h>
#include <math.h>
#include <limits.h>
int isprime(int num)
{
	int sq=sqrt(num);
	int i;
	for(i=2;i<sq;i++)
	{
		if(num%i==0)
			return 0;
	}
	return 1;
}
int q1()
{
	int num;
	int p=1;
	int now;
	int begin,end;
	long long sequencevalue=1;
	int i,j;
	scanf("%d",&num);
	if(isprime(num))
	{
		printf("%d\n",1);
		printf("%d",num);
		return 0;
	}
	now=num;
	while(now%p==0)
	{
		now/=p;
		p++;
	}
	begin=2;
	end=p;
	for(i=begin;i<=end;i++)
	{
		sequencevalue*=i;
	}
	while(sequencevalue<num)
	{
		if(num%sequencevalue==0)
			break;
		sequencevalue/=begin;
		begin++;end++;
		sequencevalue*=end;
	}
	if(num%sequencevalue==0)
	{
		printf("%d\n",p-1);
		for(i=begin;i<end;i++)
		{
			printf("%d*",i);
		}
		printf("%d",end);
	}
	else
	{
		printf("%d\n",p-2);
		for(i=2;i<p-1;i++)
		{
			printf("%d*",i);
		}
		printf("%d",p-1);
	}
	return 0; 
} 
typedef struct
{
	int next;
	int key;
	int isused;
}node;
int main()
{
	node memory[100000];
	int keys[10001];
	int headposition;
	int n;
	int prep;
	int nowp;
	int dhead=-1;
	int dnow=dhead;
	int i,j;
	int position;
	int abkey;
	scanf("%d%d",&headposition,&n);
	for(i=0;i<100000;i++)
	{
		memory[i].isused=0;
	}
	for(i=0;i<=10000;i++)
	{
		keys[i]=0;
	}
	while(n)
	{
		n--;
		scanf("%d",&position);
		scanf("%d%d",&memory[position].key,&memory[position].next);
		memory[position].isused=1;
	}
	prep=headposition;
	abkey=(memory[prep].key>=0)?memory[prep].key:-1*memory[prep].key;
	keys[abkey]=1;
	nowp=memory[prep].next;
	
	while(memory[nowp].isused)
	{
		abkey=(memory[nowp].key>=0)?memory[nowp].key:memory[nowp].key*-1;
		if(keys[abkey]!=0)
		{
			if(dhead==-1)
			{
				dhead=nowp;
				dnow=dhead;
			}
			else
			{
				memory[dnow].next=nowp;
				dnow=nowp;
			}
			memory[prep].next=memory[nowp].next;
			nowp=memory[nowp].next;
			memory[dnow].next=-1;
		}
		else
		{
			keys[abkey]=1;
			prep=nowp;
			nowp=memory[nowp].next;
		}
	}
	memory[prep].next=-1;
	nowp=headposition;
	while(memory[nowp].isused)
	{
		printf("%05d %d ",nowp,memory[nowp].key);
		if(memory[nowp].next==-1)
		{
			printf("-1\n");
		}
		else
		{
			printf("%05d\n",memory[nowp].next);
		}
		nowp=memory[nowp].next;
	}
	dnow=dhead;
	while(memory[dnow].isused)
	{
		printf("%05d %d ",dnow,memory[dnow].key);
		if(memory[dnow].next==-1)
		{
			printf("-1\n");
		}
		else
		{
			printf("%05d\n",memory[dnow].next);
		}
		dnow=memory[dnow].next;
	}
	return 0;
}
