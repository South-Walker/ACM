#include <stdio.h> 
#include <malloc.h>
int q1()
{
	int twos[18];
	char cs[18][50];
	char r[100];
	int check[18];
	int n;
	int i,j,num,k1,k2;
	scanf("%d",&n);
	cs[0][0]='2';
	cs[0][1]='(';
	cs[0][2]='0';
	cs[0][3]=')';
	cs[0][4]='\0';
	cs[1][0]='2';
	cs[1][1]='\0';
	cs[3][0]='2';
	cs[3][1]='(';
	cs[3][2]='2';
	cs[3][3]=')';
	cs[3][4]='\0';
	cs[7][0]='2';
	cs[7][1]='(';
	cs[7][2]='2';
	cs[7][3]='+';
	cs[7][4]='2';
	cs[7][5]='(';
	cs[7][6]='0';
	cs[7][7]=')';
	cs[7][8]=')';
	cs[7][9]='\0';
	cs[15][0]='2';
	cs[15][1]='(';
	cs[15][2]='2';
	cs[15][3]='(';
	cs[15][4]='2';
	cs[15][5]=')';
	cs[15][6]=')';
	cs[15][7]='\0';
	twos[0]=1;
	for(i=1;i<18;i++)
	{
		twos[i]=2*twos[i-1];
	}
	for(i=2;i<18;i++)
	{
		num=i+1;
		if(num==4||num==8||num==16)
		{
			continue;
		}
		for(j=0;j<18;j++)
		{
			check[j]=0;
		}
		j=0;
		while(num)
		{
			if(num%2)
			{
				check[j]=1;
			}
			num/=2;
			j++;
		}
		k1=0;k2=0;
		for(;j>=0;j--)
		{
			k2=0;
			if(check[j])
			{
				while(cs[twos[j]-1][k2])
				{	
					cs[i][k1]=cs[twos[j]-1][k2];
					k2++;k1++;
				}
				cs[i][k1]='+';
				k1++;
			}
		}
		cs[i][k1-1]='\0';
	}
	for(j=0;j<18;j++)
	{
		check[j]=0;
	}
	j=0;
	while(n)
	{
		if(n%2)
		{
			check[j]=1;
		}
		n/=2;
		j++;
	}
		k1=0;k2=0;
		for(;j>=0;j--)
		{
			k2=0;
			if(check[j])
			{
				if(j<4)
				{
					while(cs[twos[j]-1][k2])
					{	
						r[k1]=cs[twos[j]-1][k2];
						k2++;k1++;
					}
				}
				else
				{
					r[k1]='2';
					k1++;
					r[k1]='(';
					k1++;
					while(cs[j-1][k2])
					{	
						r[k1]=cs[j-1][k2];
						k2++;k1++;
					}
					r[k1]=')';
					k1++;
				}
				r[k1]='+';
				k1++;
			}
		}
		r[k1-1]='\0';
		printf("%s",r);
		return 0;
}
int q2()
{
	double nums[10000];
	int numsindex=0;
	char method[10000];
	int methodindex=0;
	double now=0;
	double a,b,c;
	char s[1000];
	int i=0,j;
	scanf("%s",s);
	
	while(s[i])
	{
		if(s[i]-'0'<=9&&s[i]-'0'>=0)
		{
			now*=10;
			now+=s[i]-'0';
		}
		else// if(s[i]=='+'||s[i]=='-'||s[i]=='*'||s[i]=='\')
		{
			nums[numsindex]=now;
			numsindex++;
			now=0;
			if(methodindex>0)
			{
				if(method[methodindex-1]=='*')
				{
					numsindex--;
					b=nums[numsindex];
					numsindex--;
					a=nums[numsindex];
					nums[numsindex]=a*b;
					numsindex++;
					methodindex--;
				}
				else if(method[methodindex-1]=='/') 
				{
					numsindex--;
					b=nums[numsindex];
					numsindex--;
					a=nums[numsindex];
					nums[numsindex]=a/b;
					numsindex++;
					methodindex--;
				}
			}
			method[methodindex]=s[i];
			methodindex++;
		}
		i++;
	}
	nums[numsindex]=now;
	numsindex++;
	if(methodindex>0)
	{
		if(method[methodindex-1]=='*')
		{
			numsindex--;
			b=nums[numsindex];
			numsindex--;
			a=nums[numsindex];
			nums[numsindex]=a*b;
			numsindex++;
			methodindex--;
		}
		else if(method[methodindex-1]=='/') 
		{
			numsindex--;
			b=nums[numsindex];
			numsindex--;
			a=nums[numsindex];
			nums[numsindex]=a/b;
			numsindex++;
			methodindex--;
		}
	}
	j=0;
	a=nums[0];
	for(i=1;i<numsindex;i++)
	{
		b=nums[i];
		switch(method[j])
		{
			case '-':
				a=a-b;
				break;
			case '+':
				a=a+b;
				break;
		}
		j++;
	}
	printf("%d",(int)a);
	return 0;
}
int q3()
{
	int n,a;
	int pnum[]={2,3,5,7,11,13,17,19,23,29,31};
	int pcount[11];
	int pcount2[11];
	int i,j,now;
	int k=99999;
	int maxp;
	scanf("%d%d",&n,&a);
	for(i=0;i<=10;i++)
	{
		pcount[i]=0;
		pcount2[i]=0;
	}
	for(i=10;i>=0;i--)
	{
		now=a;
		while(now%pnum[i]==0)
		{
			pcount[i]++;
			now/=pnum[i];
		}
	}
	for(i=2;i<=n;i++)
	{
		now=i;
		for(j=0;j<=10;j++)
		{
			while(now%pnum[j]==0)
			{
				pcount2[j]++;
				now/=pnum[j];
			}
		}
	}
	for(i=0;i<=10;i++)
	{
		if(pcount[i]==0)
		{
			continue;
		}
		k=(k>pcount2[i]/pcount[i])?pcount2[i]/pcount[i]:k;
	}
	printf("%d",k);
} 
