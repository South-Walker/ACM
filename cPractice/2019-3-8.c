#include <stdio.h>
int uva12108()
{
	int allstate[10];
	int ch[10][2];
	int i,j;
	int a,b,c,now;
	int chnum;
	int sleepchnum=0;
	int cansleep;
	int casenum=0;
	FILE* output=fopen("C:\\Users\\lenovo\\Desktop\\o.txt","w");
	FILE* input=fopen("C:\\Users\\lenovo\\Desktop\\test.txt","r");
	while(fscanf(input,"%d",&chnum)==1)
	{
		if(chnum==0)
			break;
		casenum++;
		fprintf(output,"Case %d: ",casenum);
		sleepchnum=0;
		for(i=0;i<10;i++)
		{
			allstate[i]=0;
		}
		for(i=0;i<chnum;i++)
		{
			fscanf(input,"%d%d%d",&a,&b,&c);
			ch[i][0]=a;
			ch[i][1]=b;
			allstate[i]=c;
			if(c>a)
			{
				sleepchnum++;
			}
		}
		if(sleepchnum==0)
		{
			fprintf(output,"1\n");
		}
		else
		{
		for(j=0;j<3000;j++)
		{
			cansleep=(2*sleepchnum>chnum)?1:0;
			for(i=0;i<chnum;i++)
			{
				now=allstate[i]+1;
				if(now<=ch[i][0])
				{
					allstate[i]=now;
				}
				else if(now==ch[i][0]+1)
				{
					if(cansleep==1)
					{
						sleepchnum++;
						allstate[i]=now;
					}
					else
					{
						allstate[i]=1;
					}
				}
				else if(now<=ch[i][0]+ch[i][1])
				{
					allstate[i]=now;
				}
				else
				{
					allstate[i]=now-ch[i][0]-ch[i][1];
					sleepchnum--;
				}
			}
			if(sleepchnum==0)
			{
				fprintf(output,"%d\n",j+2);
				break;
			}
			if(j==2999)
			{
				fprintf(output,"%d\n",-1);
			}
		}
		}
	}
	return 0;
}
void diptoiip(int*iip,int*dip)
{
	int i,j;
	int now;
	int value=128;
	for(i=0;i<4;i++)
	{
		now=dip[i];
		value=128;
		for(j=0;j<8;j++)
		{
			if(now>=value)
			{
				now-=value;
				iip[i*8+j]=1;
			}
			else
			{
				iip[i*8+j]=0;
			}
			value/=2;
		}
	}
}
void iiptodip(int*dip,int*iip)
{
	int i,j,now,value=128;
	for(i=0;i<4;i++)
	{
		now=0;
		value=128;
		for(j=0;j<8;j++)
		{
			if(iip[i*8+j]==1)
			{
				now+=value;
			}
			value/=2;
		}
		dip[i]=now;
	}
}
int uva1590()
{
	int n,i,j,k,flag;
	int dsourceIP[4];
	int isourceIP[32];
	int inetworkIP[32];
	int imaskIP[32];
	int tempnetworkIP[32][2];
	int diptemp[4];
	while(scanf("%d",&n)==1)
	{
		for(i=0;i<32;i++)
		{
			for(j=0;j<2;j++)
			{
				tempnetworkIP[i][j]=0;
			}
			inetworkIP[i]=0;
			imaskIP[i]=0;
		}
		while(n)
		{
			n--;
			scanf("%d.%d.%d.%d",&dsourceIP[0],&dsourceIP[1],&dsourceIP[2],&dsourceIP[3]);
			diptoiip(isourceIP,dsourceIP);
			for(i=0;i<32;i++)
			{
				if(isourceIP[i]==1)
				{
					tempnetworkIP[i][1]=1;
				}
				else
				{
					tempnetworkIP[i][0]=1;
				}
			}
		}
		i=0;
		while(i<32)
		{
			if(tempnetworkIP[i][0]==1&&tempnetworkIP[i][1]==1)
			{
				break;
			}
			imaskIP[i]=1;
			if(tempnetworkIP[i][0]==1)
			{
				inetworkIP[i]=0;
			}
			else if(tempnetworkIP[i][1]==1)
			{
				inetworkIP[i]=1;
			}
			else
			{
				return 0;
			}
			i++;
		}
		iiptodip(diptemp,inetworkIP);
		printf("%d.%d.%d.%d\n",diptemp[0],diptemp[1],diptemp[2],diptemp[3]);
		iiptodip(diptemp,imaskIP);
		printf("%d.%d.%d.%d\n",diptemp[0],diptemp[1],diptemp[2],diptemp[3]);
	}
	return 0;
} 
