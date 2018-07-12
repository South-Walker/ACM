#include <stdio.h>
#include <malloc.h>
#define MAX 1000000 
void main()
{
	ecnu13();
}
int checkecnu13(int***eudokuboard,int**eudokucount,int i,int j,int n)
{
	int check[10];
	
}
void subecnu13(int***eudokuboard,int**eudokucount,int i,int j,int n)
{
	int k;
	for(k=1;k<=9;k++)
	{
		eudokuboard[i][j][n]=k;
		if(checkecnu13(eudokuboard,eudokucount,i,j,n))
		{
			if(eudokucount[i][j]-n==1)
			{
				if(j==5&&i==5)
					return;
				if(j==5)
					subecnu13(eudokuboard,eudokucount,i+1,0,0);
				else
			}
			else
			{
				subecnu13(eudokuboard,eudokucount,i,j,n+1);	
			}
		}
		eudokuboard[i][j][n]=0;
	}
}
void ecnu13()
{
	int*eudokuboard[6][6];
	int eudokucount[6][6];
	int i,j;
	char s[10];
	for(i=0;i<6;i++)
	{
		for(j=0;j<6;j++)
		{
			scanf("%s",s);
			if(s[1]=='\0')
			{
				eudokucount[i][j]=1;
				eudokuboard[i][j]=(int*)malloc(sizeof(int));
				if(s[0]=='-')
				{
					eudokuboard[i][j][0]=0;
				}
				else
				{
					eudokuboard[i][j][0]=s[0]-'0';
				}
			}
			else//if(s[1]=='/')
			{
				eudokucount[i][j]=2;
				eudokuboard[i][j]=(int*)malloc(2*sizeof(int));
				if(s[0]=='-')
				{
					eudokuboard[i][j][0]=0;
				}
				else
				{
					eudokuboard[i][j][0]=s[0]-'0';
				}
				if(s[2]=='-')
				{
					eudokuboard[i][j][1]=0;
				}
				else
				{
					eudokuboard[i][j][1]=s[2]-'0';
				}
			}
		}
	}
	subecnue13(eudokuboard,eudokucount,0,0,0);
	for(i=0;i<6;i++)
	{
		for(j=0;j<6;j++)
		{
			if(eudokucount[i][j]==1)
			{
				printf("%d ",eudokuboard[i][j][0]);
			}
			else
			{
				printf("%d/%d ",eudokuboard[i][j][0],eudokuboard[i][j][1]);
			}
		}
		printf("\n");
	}
}
typedef struct IpValue
{
	int n1;
	int n2;
	int n3;
	int n4;
}*IpAddress; 
int isEqualIP(IpAddress a,IpAddress b)
{
	if(a->n1==b->n1 && a->n2==b->n2
	&& a->n3==b->n3 && a->n4==b->n4)
	{
		return 1;
	}
	return 0;
}
IpAddress cresIpAddress(int n1,int n2,int n3,int n4)
{
	IpAddress temp;
	temp=(IpAddress)malloc(sizeof(struct IpValue));
	temp->n1=n1;
	temp->n2=n2;
	temp->n3=n3;
	temp->n4=n4;
	return temp;
}
void ecnu1028()
{
	int n,m;
	int t;
	int i,j,k,weight;
	int an1,an2,an3,an4,bn1,bn2,bn3,bn4;
	IpAddress temp;
	IpAddress*Ips;
	int**graph;
	scanf("%d%d",&n,&m);
	Ips=(IpAddress*)malloc(sizeof(IpAddress)*n);
	for(i=0;i<n;i++)
	{
		Ips[i]=NULL;
	}
	graph=(int**)malloc(sizeof(int*)*n);
	for(i=0;i<n;i++)
	{
		graph[i]=(int*)malloc(sizeof(int)*n);
		for(j=0;j<n;j++)
		{
			if(i==j)
				graph[i][j]=0;
			else
				graph[i][j]=MAX;
		}
	}
	while(m)
	{
		m--;
		scanf("%d.%d.%d.%d %d.%d.%d.%d %d",&an1,&an2,&an3,&an4,&bn1,&bn2,&bn3,&bn4,&weight);
		temp=cresIpAddress(an1,an2,an3,an4);
		for(i=0;i<n;i++)
		{
			if(Ips[i]==NULL||isEqualIP(temp,Ips[i]))
			{
				if(Ips[i]==NULL)
				{
					Ips[i]=temp;
				}
				break;
			}
		}
		temp=cresIpAddress(bn1,bn2,bn3,bn4);
		for(j=0;j<n;j++)
		{
			if(Ips[j]==NULL||isEqualIP(temp,Ips[j]))
			{
				if(Ips[j]==NULL)
				{
					Ips[j]=temp;
				}
				break;				
			}
		}
		graph[i][j]=weight;
		graph[j][i]=weight;
	}
	for(k=0;k<n;k++)
	{
		for(i=0;i<n;i++)
		{
			for(j=0;j<i;j++)
			{
				if(graph[i][j]>graph[i][k]+graph[k][j])
				{
					graph[i][j]=graph[i][k]+graph[k][j];
					graph[j][i]=graph[i][k]+graph[k][j];
				}
			}
		}
	}
	scanf("%d",&t);
	while(t)
	{
		t--;
		scanf("%d.%d.%d.%d %d.%d.%d.%d",&an1,&an2,&an3,&an4,&bn1,&bn2,&bn3,&bn4);
		temp=cresIpAddress(an1,an2,an3,an4);
		for(i=0;i<n;i++)
		{
			if(isEqualIP(temp,Ips[i]))
			{
				break;
			}
		}
		temp=cresIpAddress(bn1,bn2,bn3,bn4);
		for(j=0;j<n;j++)
		{
			if(isEqualIP(temp,Ips[j]))
			{
				break;
			}
		}
		if(i==n||j==n)
		{
			printf("-1\n");
		}
		else
		{
			if(graph[i][j]==MAX)
			{
				printf("-1\n");
			}
			else
			{
				printf("%d\n",graph[i][j]);
			}
		}
	}
} 
