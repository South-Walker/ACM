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
	int k;
	int a,b;
	if(eudokucount[i][j]==2)
	{
		if(eudokuboard[i][j][0]>eudokuboard[i][j][1]&&eudokuboard[i][j][1]!=0)
			return 0;
	} 
	for(k=0;k<10;k++)
	{
		check[k]=0;
	}
	for(k=0;k<6;k++)
	{
		if(eudokucount[i][k]==1)
		{
			check[eudokuboard[i][k][0]]++;
		}
		else
		{
			check[eudokuboard[i][k][0]]++;
			check[eudokuboard[i][k][1]]++;
		}
	}
	for(k=1;k<10;k++)
	{
		if(check[k]>1)
			return 0;
	}
	for(k=0;k<10;k++)
	{
		check[k]=0;
	}
	for(k=0;k<6;k++)
	{
		if(eudokucount[k][j]==1)
		{
			check[eudokuboard[k][j][0]]++;
		}
		else
		{
			check[eudokuboard[k][j][0]]++;
			check[eudokuboard[k][j][1]]++;
		}
	}
	for(k=1;k<10;k++)
	{
		if(check[k]>1)
			return 0;
	}
	for(k=0;k<10;k++)
	{
		check[k]=0;
	}
	a=i/2;
	b=j/3;
	a=a*2;
	b=b*3;
	//a,b;a,b+1;a,b+2;
	//a+1,b;a+1,b+1;a+1,b+2; 
	if(eudokucount[a][b]==1)
	{
		check[eudokuboard[a][b][0]]++;
	}
	else
	{
		check[eudokuboard[a][b][0]]++;
		check[eudokuboard[a][b][1]]++;
	}
	if(eudokucount[a][b+1]==1)
	{
		check[eudokuboard[a][b+1][0]]++;
	}
	else
	{
		check[eudokuboard[a][b+1][0]]++;
		check[eudokuboard[a][b+1][1]]++;
	}
	if(eudokucount[a][b+2]==1)
	{
		check[eudokuboard[a][b+2][0]]++;
	}
	else
	{
		check[eudokuboard[a][b+2][0]]++;
		check[eudokuboard[a][b+2][1]]++;
	}
	if(eudokucount[a+1][b]==1)
	{
		check[eudokuboard[a+1][b][0]]++;
	}
	else
	{
		check[eudokuboard[a+1][b][0]]++;
		check[eudokuboard[a+1][b][1]]++;
	}
	if(eudokucount[a+1][b+1]==1)
	{
		check[eudokuboard[a+1][b+1][0]]++;
	}
	else
	{
		check[eudokuboard[a+1][b+1][0]]++;
		check[eudokuboard[a+1][b+1][1]]++;
	}
	if(eudokucount[a+1][b+2]==1)
	{
		check[eudokuboard[a+1][b+2][0]]++;
	}
	else
	{
		check[eudokuboard[a+1][b+2][0]]++;
		check[eudokuboard[a+1][b+2][1]]++;
	}
	for(k=1;k<10;k++)
	{
		if(check[k]>1)
		{
			return 0;
		}
	}
	return 1;
}
void subecnu13(int***eudokuboard,int**eudokucount,int i,int j,int n,int*flag)
{
	int k;
	if(*flag==0)
		return;
	if(eudokuboard[i][j][n]!=0)
	{
		if(eudokucount[i][j]-n==1)
		{
			if(j==5&&i==5)
			{
				*flag=0;
			}
			if(j==5)
				subecnu13(eudokuboard,eudokucount,i+1,0,0,flag);
			else
				subecnu13(eudokuboard,eudokucount,i,j+1,0,flag);
		}
		else
		{
			subecnu13(eudokuboard,eudokucount,i,j,n+1,flag);	
		}
	}
	else
	{
	for(k=1;k<=9;k++)
	{
		eudokuboard[i][j][n]=k;
		if(checkecnu13(eudokuboard,eudokucount,i,j,n))
		{
			if(eudokucount[i][j]-n==1)
			{
				if(j==5&&i==5)
				{
					*flag=0;
				}
				if(j==5)
					subecnu13(eudokuboard,eudokucount,i+1,0,0,flag);
				else
					subecnu13(eudokuboard,eudokucount,i,j+1,0,flag);
			}
			else
			{
				subecnu13(eudokuboard,eudokucount,i,j,n+1,flag);	
			}
		}
		if(*flag==0)
		{
			return;
		}
		eudokuboard[i][j][n]=0;
	}
	}
}
void ecnu13()
{
	int***eudokuboard;
	int**eudokucount;
	int*flag;
	int i,j;
	char s[10];
	flag=(int*)malloc(sizeof(int));
	*flag=1; 
	eudokuboard=(int***)malloc(6*sizeof(int**));
	for(i=0;i<6;i++)
	{
		eudokuboard[i]=(int**)malloc(6*sizeof(int*));
	}
	eudokucount=(int**)malloc(6*sizeof(int*));
	for(i=0;i<6;i++)
	{
		eudokucount[i]=(int*)malloc(6*sizeof(int));
		for(j=0;j<6;j++)
		{
			eudokucount[i][j]=0;
		}
	}
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
	subecnu13(eudokuboard,eudokucount,0,0,0,flag);
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
		if(i!=5)
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
