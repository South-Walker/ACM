#include <stdio.h>
#include <string.h>
#include <limits.h>
void invs(char* a,int len)
{
	int i;
	char temp;
	for(i=0;i<len/2;i++)
	{
		temp=a[len-i-1];
		a[len-i-1]=a[i];
		a[i]=temp;
	}
}
int isabigger(char*a,char*b)
{
	int minues=0;
	if(a[0]=='-')
	{
		a++;
	}
	if(b[0]=='-')
	{
		b++;
	}
	if(strlen(a)!=strlen(b))
	{
		if(strlen(a)>strlen(b))
		{
			return 1;
		}
		else
			return 0;
	}
	while(*a)
	{
		if(*a>*b)
		{
			return 1;
		}
		else if(*b>*a)
		{
			return 0;
		}
		else
		{
			a++;b++;
		}
	}
}
char ra[410];
char rb[410];
char rc[1000];
int lena,lenb;
int isaminues=0,isbminues=0;
int isabig=0;

void getra(char*a,char*b)
{
	int i=0;
	int now;
	int temp=0;
	while(a[i]&&b[i])
	{
		now=a[i]-'0'+b[i]-'0'+temp;
		temp=0;
		while(now>=10)
		{
			now-=10;
			temp++;
		}
		ra[i]=now+'0';
		i++;
	}
	while(a[i])
	{
		now=a[i]-'0'+temp;
		temp=0;
		while(now>=10)
		{
			now-=10;
			temp++;
		}
		ra[i]=now+'0';
		i++;
	}
	while(b[i])
	{
		now=b[i]-'0'+temp;
		temp=0;
		while(now>=10)
		{
			now-=10;
			temp++;
		}
		ra[i]=now+'0';
		i++;
	}
	if(temp!=0)
	{
		ra[i]=temp+'0';
		temp=0;
		i++;
	}
	ra[i]='\0';
}
void getrb(char*a,char*b)
{
	int i=0;
	int now;
	int temp=0;
	while(a[i]&&b[i])
	{
		now=a[i]-b[i]+temp;
		temp=0;
		while(now<0)
		{
			now+=10;
			temp--;
		}
		rb[i]=now+'0';
		i++;
	}
	while(a[i])
	{
		now=a[i]+temp-'0';
		temp=0;
		while(now<0)
		{
			now+=10;
			temp--;
		}
		rb[i]=now+'0';
		i++;		
	}
	if(rb[i-1]=='0')
	{
		i--;
	}
	rb[i]='\0';
}
void getrc(char*a,char*b)
{
	int i=0,j,k;
	char tempnum[410];
	int temp=0;
	int now,nowa,nowb;
	for(i=0;i<1000;i++)
	{
		rc[i]='0';
	}
	i=0;
	while(*a)
	{
		j=0;
		nowa=*a-'0';
		temp=0;
		while(b[j])
		{
			nowb=b[j]-'0';
			now=nowa*nowb+temp;
			temp=0;
			while(now>=10)
			{
				now-=10;
				temp++;
			}
			tempnum[j]=now+'0';
			j++;
		}
		if(temp)
		{
			tempnum[j]=temp+'0';
			temp=0;
			j++;
		}
		tempnum[j]='\0';
		j=0;
		k=i;
		temp=0;
		while(tempnum[j])
		{
			rc[k]=rc[k]-'0'+tempnum[j]+temp;
			temp=0;
			while(rc[k]>'9')
			{
				temp++;
				rc[k]-=10;
			}
			k++;j++;
		}
		while(temp)
		{
			rc[k]=rc[k]+temp;
			temp=0;
			while(rc[k]>'9')
			{
				temp++;
				rc[k]-=10;
			}
			k++;
		}
		i++;
		a++;
	}
	for(i=1000-1;i>=0;i--)
	{
		if(rc[i]!='0')
			break;
		rc[i]='\0';
	}
}
char a[500];
char b[500];
int q1()
{
	scanf("%s",a);
	scanf("%s",b);
	isaminues=(a[0]=='-');
	isbminues=(b[0]=='-');
	isabig=isabigger(a,b); 
	lena=strlen(a);
	lenb=strlen(b);
	
	invs(a,lena);
	invs(b,lenb);
	if(isaminues)
	{
		lena--;
		a[lena]='\0';
	}
	if(isbminues)
	{
		lenb--;
		b[lenb]='\0';
	}
	getra(a,b);
	if(isabig)
		getrb(a,b);
	else
		getrb(b,a);
	getrc(a,b);
	invs(ra,strlen(ra));
	invs(rb,strlen(rb));
	invs(rc,strlen(rc));
	if(isaminues&&isbminues)
	{
		printf("-%s\n",ra);
		if(isabig)
		{
			printf("-%s\n",rb);
		}
		else
		{
			printf("%s\n",rb);
		}
	}
	else if(isaminues)
	{
		if(isabig)
		{
			printf("-%s\n",rb);
		}
		else
		{
			printf("%s\n",rb);
		}
		printf("-%s\n",ra);
	}
	else if(isbminues)
	{
		if(isabig)
		{
			printf("%s\n",rb);
		}
		else
		{
			printf("-%s\n",rb);
		}
		printf("%s\n",ra);
	}
	else
	{
		printf("%s\n",ra);
		if(isabig)
		{
			printf("%s\n",rb);
		}
		else
		{
			printf("-%s\n",rb);
		}
	}
	if(isbminues||isaminues)
	{
		if(isbminues&&isaminues)
		{
			
		}
		else
		{
			printf("-");
		}
	}
	printf("%s\n",rc);
} 
#define MAX 99999
int matrix[100][100];
int min=MAX;
int total(int x1,int y1,int x2,int y2)
{
	int r=0;
	int i,j;
	for(i=x1;i<=x2;i++)
	{
		for(j=y1;j<=y2;j++)
		{
			r+=matrix[i][j];
		}
	}
	return r;
}
int main()
{
	int n,m,k;
	int i,j,u,l;
	int sizenow;
	scanf("%d%d%d",&n,&m,&k);
	for(i=0;i<n;i++)
	{
		for(j=0;j<m;j++)
		{
			scanf("%d",&matrix[i][j]);
		}
	}
	for(i=0;i<n;i++)
	{
		for(j=0;j<m;j++)
		{
			for(u=i;u<n;u++)
			{
				for(l=j;l<m;l++)
				{
					sizenow=(l-j+1)*(u-i+1);
					if(min<=sizenow)
					{
						break;
					}
					if(total(i,j,u,l)>=k)
					{
						min=sizenow;
					}
				}
			}
		}
	}
	if(min==MAX)
	{
		printf("-1");
	}
	else
	{
		printf("%d",min);
	}
}
