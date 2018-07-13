#include <stdio.h>
#include <malloc.h>
#define MAXLEN 121
void main()
{
	ecnu98();
}
void testecnu98()
{
	long long max,min,temp;
	int i,j;
	int n;
	scanf("%d",&n);
	n--;
	scanf("%lld",&temp);
	min=temp;
	max=temp;
	while(n)
	{
		n--;
		scanf("%lld",&temp);
		if(temp>max)
		{
			max=temp;
		}
		if(temp<min)
		{
			min=temp;
		}
	}
	printf("%llu",max-min);
}
void ecnu98()
{
	char *max;
	char *min;
	char *temp=(char*)malloc(sizeof(char)*MAXLEN);
	int i,j;
	int n;
	scanf("%d",&n);
	max=(char*)malloc(MAXLEN*sizeof(char));
	min=(char*)malloc(MAXLEN*sizeof(char));
	max[0]='-';
	min[0]='9';
	for(i=0;i<120;i++)
	{
		min[i]='9';
		min[i]='9';
	}
	min[MAXLEN-1]='\0';
	max[MAXLEN-1]='\0';
	while(n)
	{
		n--;
		temp=(char*)malloc(sizeof(char)*MAXLEN);
		scanf("%s",temp);
		if(compare(temp,max))
		{
			//free(max);
			max=temp;
		}
		if(compare(min,temp))
		{
			//free(min);
			min=temp;
		}
		if((&max!=&temp) && (&min!=&temp));
			//free(temp);
	}
	minues(max,min);
	i=0;
	while(max[i]=='0')
	{
		i++;
	}
	if(max[i]=='\0')
		printf("0\n");
	else
	{
		i=0;
		while(max[i]=='0')
		{
			i++;
		}
		while(max[i]!='\0')
		{
			printf("%c",max[i]);
			i++;
		}
		printf("\n");
	}
}
void minues(char*a,char*b)
{
	int alen,blen;
	int aflag,bflag;
	char*temp;
	int i,j,k;
	aflag=1;
	bflag=1;
	alen=0;
	blen=0;
	while(aflag||bflag)
	{
		if(a[alen]=='\0')
		{
			aflag=0;
		}
		if(b[blen]=='\0')
		{
			bflag=0;
		}
		if(aflag)
		{
			alen++;
		}
		if(bflag)
		{
			blen++;
		}
	}
	
	i=alen;
	j=blen;
	if(a[0]!='-'&&b[0]!='-')
	{
		while(j)
		{
			i--;
			j--;
			a[i]=a[i]-b[j]+'0';
		}
		for(i=alen-1;i>=1;i--)
		{
			if(a[i]<'0')
			{
				a[i-1]=a[i-1]-1;
				a[i]+=10;
			}
		}
	}
	else if(a[0]=='-')
	{
		temp=(char*)malloc(MAXLEN*sizeof(char));
		for(i=1;i<=blen;i++)
		{
			temp[i-1]=b[i];
		}
		minues(temp,a+1);
		for(i=0;;i++)
		{
			a[i]=temp[i];
			if(temp[i]=='\0')
			{
				break;
			}
		}
	}
	else//if (b[0]=='-')
	{
		temp=(char*)malloc(MAXLEN*sizeof(char));
		k=0;
		while(i&&j!=1)
		{
			i--;j--;
			temp[k]=a[i]-'0'+b[j];
			k++;
		}
		if(i)
		{
			while(i)
			{
				i--;
				temp[k]=a[i];
				k++;
			}
		}
		if(j)
		{
			while(j!=1)
			{
				j--;
				temp[k]=b[j];
				k++;
			}
		}
		temp[k]='0';
		temp[k+1]='\0';
		for(i=0;i<k;i++)
		{
			if(temp[i]>'9')
			{
				temp[i]-=10;
				temp[i+1]+=1;
			}
		}
		i=0;
		while(k!=-1)
		{
			a[i]=temp[k];
			i++;
			k--;
		}
		a[i]='\0';
	}
}
//a大返回1，a小返回0 
int compare(char*a,char*b)
{
	int i,len;
	if(a[0]=='-'||b[0]=='-')
	{
		if(a[0]=='-'&&b[0]=='-')
		{
			return compare(b+1,a+1);
		}
		else if(a[0]=='-')
		{
			return 0;
		}
		else
		{
			return 1;
		}
	}
	len=0;
	while(1)
	{
		if(a[len]=='\0'&&b[len]=='\0')
		{
			break;
		}
		else if(a[len]=='\0')
		{
			return 0;
		}
		else if(b[len]=='\0')
		{
			return 1;
		}
		else
			len++;
	}
	for(i=0;i<len;i++)
	{
		if(a[i]>b[i])
		{
			return 1;
		}
		else if(a[i]<b[i])
		{
			return 0;
		}
	}
	return 1;
}
void ecnu1042()
{
	int n,m;
	int i,j;
	int num[7];
	int value[7];
	value[0]=100;
	value[1]=50;
	value[2]=20;
	value[3]=10;
	value[4]=5;
	value[5]=2;
	value[6]=1;
	scanf("%d",&n);
	while(n)
	{
		n--;
		scanf("%d",&m);
		for(i=0;i<7;i++)
		{
			if(m>=value[i])
			{
				num[i]=m/value[i];
				m=m%value[i];
			}
			else
			{
				num[i]=0;
			}
		}
		for(i=0;i<7;i++)
		{
			printf("%d",num[i]);
			if(i!=6)
				printf(" ");
			else
				printf("\n");
		}
	}
}
