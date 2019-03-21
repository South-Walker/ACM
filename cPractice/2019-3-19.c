#include <stdio.h>
#include <string.h>
int q1()
{
	int n;
	int publiclen;
	int nowlen;
	int publicstart;
	int nowstart;
	int i,j;
	char publicc[300];
	char now[300];
	scanf("%d\n",&n);
	n--;
	gets(publicc);
	publiclen=strlen(publicc);
	publicstart=publiclen-1;
	while(n)
	{
		n--;
		gets(now);
		nowlen=strlen(now);
		nowstart=nowlen-1;
		for(i=0;i<publiclen;i++)
		{
			if(publicc[publicstart-i]!=now[nowstart-i])
			{
				publiclen=i;
				break;
			}
		}
	}
	if(i==0)
	{
		printf("nai");
	} 
	else
	{
		for(i=publicstart-publiclen+1;i<=publicstart;i++)
		{
			printf("%c",publicc[i]);
		}
	}
}
int main()
{
	
	return 0;
}
