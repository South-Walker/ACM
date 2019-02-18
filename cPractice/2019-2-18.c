#include <stdio.h>
#include <math.h>
typedef struct{
	int x2;
	int x1;
	int x0;
}function; 
function handle(char*f)
{
	int i,now,isminues;
	function result;
	i=0;
	now=0;
	isminues=0;
	result.x0=0;
	result.x1=0;
	result.x2=0;
	while(f[i])
	{
		if(f[i]=='+')
		{
			if(isminues)
			{
				now*=-1;
			}
			result.x0+=now;
			now=0;
			isminues=0;
			i++;
		}
		else if(f[i]=='-')
		{
			if(isminues)
			{
				now*=-1;
			}
			result.x0+=now;
			now=0;
			isminues=1;
			i++;
		}
		else if(f[i]-'0'<10&&f[i]-'0'>=0)
		{
			now*=10;
			now+=f[i]-'0';
			i++;
		}
		else if(f[i]=='x')
		{
			if(now==0)
			{
				now=1;
			}
			if(f[i+1]=='^')
			{
				if(isminues)
				{
					now*=-1;
				}
				result.x2+=now;
				i++;i++;i++;
			}
			else
			{
				if(isminues)
				{
					now*=-1;
				}
				result.x1+=now;
				i++;
			}
			now=0;
			isminues=0;
		}
		else
		{
			printf("wwww");
		}
	}
	if(isminues)
	{
		now*=-1;
	}
	result.x0+=now;
	return result;
}
void q1()//二次方程计算器
{
	char f[100];
	char left[100],right[100];
	function fleft,fright;
	int i,j;
	double d;
	double a,b,c;
	double x1,x2;
	double min,max;
	scanf("%s",f);
	i=0; 
	while(f[i]!='=')
	{
		left[i]=f[i];
		i++;
	}
	left[i]='\0';
	i++;
	j=0;
	while(f[i])
	{
		right[j]=f[i];
		i++;
		j++; 
	}
	right[j]='\0';
	fleft=handle(left);
	fright=handle(right);
	a=fleft.x2-fright.x2;
	b=fleft.x1-fright.x1;
	c=fleft.x0-fright.x0;
	d=b*b-4*a*c;
	if(d<0)
	{
		printf("No Solution");
	}
	else
	{
		d=sqrt(d);
		x1=(-1*b-d)/2/a;
		x2=(-1*b+d)/2/a;
		min=(x1>x2)?x2:x1;
		max=(x1>x2)?x1:x2;
		printf("%.2f %.2f",min,max);
	}
}
int q2()
{
	int n,i;
	unsigned long long x1;
	unsigned long long x2;
	unsigned long long x3;
	scanf("%d",&n);
	if(n==0)
	{
		printf("%d",0);
		return 0;
	}
	x1=0;x2=1;
	for(i=1;i<n;i++)
	{
		x3=x1+x2;
		x1=x2;
		x2=x3;
	}
	printf("%u",x2);
}

int di(int num)
{
	int result=0;
	while(num)
	{
		result*=10;
		result+=num%10;
		num/=10;
	}
	return result;
}
int q3()
{
	int a,b;
	int da,db;
	int r,dr;
	while(scanf("%d%d",&a,&b))
	{
		da=di(a);
		db=di(b);
		r=a+b;
		dr=di(r);
		if(dr==da+db)
		{
			printf("%d\n",r);
		}
		else
		{
			printf("NO");
		}
	}
}

