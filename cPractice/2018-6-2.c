#include <stdio.h>
#include <malloc.h>
#include <limits.h>
int main()
{
	ecnu3();
	return 0;
}
void ecnu4()
{
	int casenum;int nowcase=0;
	scanf("%d\n",&casenum);
	char s[60];
	int nums[10];
	int i,j,temp;
	while(casenum>nowcase)
	{
		nowcase++;
		i=0;j=0;temp=0;
		gets(s);
		while(s[i]!=' ')
		{
			i++;
		}
		i++;
		while(s[i]!='\0')
		{
			if(s[i]==' ')
			{
				nums[j]=temp;
				temp=0;
				j++;
			}
			else
			{
				temp*=10;
				temp+=s[i]-'0';
			}
			i++;
		}
		nums[j]=temp;
		
		printf("%d ",nowcase);
		int max=INT_MIN;
		int biggest=INT_MAX;
		for(i=0;i<3;)
		{
			if(max!=INT_MIN)
				biggest=max;
			max=INT_MIN;
			for(j=0;j<10;j++)
			{
				if(nums[j]<biggest&&nums[j]>max)
				{
					max=nums[j];
				}
			}
			for(j=0;j<10;j++)
			{
				if(max==nums[j])
				{
					i++;
				}
			}
		}
		printf("%d",max);
		printf("\n");
	}
}
void ecnu2()
{
	char*s=(char*)calloc(101,sizeof(char));
	while(gets(s))
	{
	int*p1=(int*)calloc(50,sizeof(int));
	int*p2=(int*)calloc(50,sizeof(int));
	int*answer=(int*)calloc(100,sizeof(int));
	int*workp=p1;
	int i=0,j=0;
	
	int power;
	char now;
	int xishu;
	int temp=0;
	int isminue=0;
	while(s[i]!='\0')
	{
		if(s[i]==' ')
		{
			workp=p2;
			i++;
			continue;
		}
		if(s[i]=='+')
		{
			i++;
		}
		else if(s[i]=='-')
		{
			isminue=1;
			i++;
		} 
		if(s[i]=='x')
		{
			xishu=(isminue)?-1:1;
			isminue=0;
			i++;
		}
		else
		{
			temp=0;
			while(s[i]!='x'&&s[i]!='\0'&&s[i]!=' ')
			{
				temp*=10;
				temp+=s[i]-'0';
				i++;
			}
			xishu=(isminue)?-1:1;
			isminue=0;
			xishu*=temp;
			if(s[i]=='\0'||s[i]==' ')
			{
				workp[0]=xishu;
				continue;
			}
			else
			{
				i++;
			}
		}
		if(s[i]!='^')
		{
			workp[1]=xishu;
		}
		else
		{
			i++;
			temp=0;
			while(s[i]-'0'>=0&&s[i]-'0'<=9)
			{
				temp*=10;
				temp+=s[i]-'0';
				i++;
			}
			power=temp;
			workp[power]=xishu;
		}
	}
	for(i=0;i<50;i++)
	{
		for(j=0;j<50;j++)
		{
			answer[j+i]+=p1[i]*p2[j];
		}
	}
	int count=0;
	for(i=99;i>=0;i--)
	{
		if(answer[i]==0)
		{
			continue;
		}
		if(count)
		{
			printf(" ");
		}
		count++;
		printf("%d",answer[i]);
	}
	printf("\n");
	}
}
void ecnu2820()
{
	char s[51];
	scanf("%s",s);
	int max=0;
	int index=0;
	int nowcount=0;
	char pre='x';
	while(s[index]!='\0')
	{
		if(s[index]==pre)
		{
			max=(max>=nowcount)?max:nowcount;
			nowcount=1;
		}
		else
		{
			nowcount++;
		}
		pre=s[index];
		index++;
	}
	max=(max>=nowcount)?max:nowcount;
	printf("%d",max);
}
void ecnu2822()
{
	unsigned char *s=(unsigned char*)calloc(50,sizeof(unsigned char));
	unsigned char *temp;
	int i;double d;
	while(scanf("%s",s)!=EOF)
	{
		
		int i;
		int isint=1;
		for(i=0;i<50;i++)
		{
			if(s[i]=='\0')
			{
				break;
			}
			if(s[i]=='.')
			{
				isint=0;
				break;
			}
		}
		if(isint)
		{
			sscanf(s,"%d",&i);
			temp=(unsigned char*)&i;
			printf("%02x %02x %02x %02x \n",temp[0],temp[1],temp[2],temp[3]);
		}
		else
		{
			sscanf(s,"%lf",&d);
			temp=(unsigned char*)&d;
			printf("%02x %02x %02x %02x %02x %02x %02x %02x \n",temp[0],temp[1],temp[2],temp[3],temp[4],temp[5],temp[6],temp[7]);
		}
	}
}
void ecnu2819()
{
	int casenum;
	int candynum;
	int paper;
	scanf("%d",&casenum);
	while(casenum)
	{
		int money;
		candynum=0;
		paper=0;
		scanf("%d",&money);
		while(money)
		{
			candynum+=money;
			paper+=money;
			money=paper/3;
			paper-=money*3;
		}
		printf("%d\n",candynum);
	}
} 
