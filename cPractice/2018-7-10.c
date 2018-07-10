#include <stdio.h>
#include <malloc.h>
#include <math.h>
void main()
{
	float salary;
	printf("\atest salary:");
	printf("$_____\b\b\b\b\b");
	scanf("%f",&salary);
	printf("\n$%.2f month is $%,2f a year",salary,salary * 12.0);
	printf("\rGee!\n");
} 
void ecnu17()
{
	int count;
	double point[1001];
	int i,j;
	int caseclass;
	int a,b;
	double pa,sa,ka,pb,sb,kb;
	int temp;
	for(i=0;i<1001;i++)
	{
		point[i]=1500l;
	}
	scanf("%d",&count);
	while(count)
	{
		count--;
		scanf("%d",&caseclass);
		if(caseclass==3)
		{
			scanf("%d",&a);
			printf("%4.6lf\n",point[a]);
		}
		else
		{
			scanf("%d%d",&a,&b);
			pa=1.0/(1+pow(10,(point[b]-point[a])/400.0));
			pb=1.0/(1+pow(10,(point[a]-point[b])/400.0));
			if(point[a]<2100)
			{
				ka=32;
			}
			else if(point[a]<2400)
			{
				ka=24;
			}
			else
			{
				ka=16;
			}
			if(point[b]<2100)
			{
				kb=32;
			}
			else if(point[b]<2400)
			{
				kb=24;
			}
			else
			{
				kb=16;
			}
			if(caseclass==1)
			{
				sa=1.0;
				sb=0;
			}
			else
			{
				sa=0.5;
				sb=0.5;
			}
			point[a]=point[a]+ka*(sa-pa);
			point[b]=point[b]+kb*(sb-pb);
		}
	}
}
void ecnu12()
{
	int casenum;
	int pathnum;
	int citynum;
	int**graph;
	int*classa;
	int*classb;
	int alen;
	int blen;
	int i,j;
	int a,b;
	int could=1;
	int now=0;
	scanf("%d",&casenum);
	while(casenum)
	{
		now++;
		could=1;
		casenum--;
		scanf("%d",&citynum);
		graph=(int**)malloc(citynum*sizeof(int*));
		
		classa=(int*)malloc(citynum*sizeof(int));
		alen=0;
		classb=(int*)malloc(citynum*sizeof(int));
		blen=0;
		for(i=0;i<citynum;i++)
		{
			graph[i]=(int*)malloc(citynum*sizeof(int));
			for(j=0;j<citynum;j++)
			{
				graph[i][j]=0;
			}
		}
		scanf("%d",&pathnum);
		for(i=0;i<pathnum;i++)
		{
			scanf("%d%d",&a,&b);
			graph[a-1][b-1]=1;
			graph[b-1][a-1]=1;
		}
		
		for(i=0;i<citynum;i++)
		{
			if(graph[0][i])
			{
				classb[blen]=i;
				blen++;
			}
			else
			{
				classa[alen]=i;
				alen++;
			}
		}
		for(i=1;i<citynum;i++)
		{
			for(j=citynum-1;j>i;j--)
			{
				if(searchin(classa,alen,i))
				{
					if(graph[i][j]==0)
					{
						if(searchin(classa,alen,j))
						{
							could=0;
						}
					}
					else
					{
						if(searchin(classb,blen,j))
						{
							could=0;
						}
					}
				}
				else
				{
					if(graph[i][j]==0)
					{
						if(searchin(classb,blen,j))
						{
							could=0;
						}
					}
					else
					{
						if(searchin(classa,alen,j))
						{
							could=0;
						}
					}
				}
			}
		}
		printf("Case %d: ",now);
		if(could)
		{
			printf("YES\n");
		}
		else
		{
			printf("NO\n");
		}
		for(i=0;i<citynum;i++)
		{
			free(graph[i]);
		}
		free(classa);
		free(classb);
		free(graph);
	}
}
int searchin(int*set,int len,int target)
{
	int i;
	for(i=0;i<len;i++)
	{
		if(set[i]==target)
		{
			return 1;
		}
	}
	return 0;
}
