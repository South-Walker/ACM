#include <stdio.h> 
typedef struct
{
	int floor;
	int father;
	int sonnum;
}person;
int q1()
{
	person ps[100001];
	int pcount;
	double price;
	double r;
	int i,j;
	person*temp;
	int floornum;
	int count=0;
	int maxfloor=0;
	scanf("%d%lf%lf",&pcount,&price,&r);
	r+=100;
	r=r/100;
	for(i=0;i<pcount;i++)
	{
		scanf("%d",&j);
		ps[i].floor=-1;
		ps[i].father=j;
		if(j==-1)
		{
			ps[i].floor=0;
		}
	}
	for(i=0;i<pcount;i++)
	{
		if(ps[i].floor!=-1)
			continue;
		floornum=0;
		temp=&ps[ps[i].father];
		floornum++;
		while(temp->floor==-1)
		{			
			temp=&ps[temp->father];
			floornum++;
		}
		floornum+=temp->floor;
		if(floornum>maxfloor)
		{
			maxfloor=floornum;
		}
		temp=&ps[i];
		while(temp->floor==-1)
		{
			temp->floor=floornum;
			temp=&ps[temp->father];
			floornum--;
		}
	}
	for(i=0;i<pcount;i++)
	{
		if(ps[i].floor==maxfloor)
			count++;
	}
	for(i=0;i<maxfloor;i++)
	{
		price*=r;
	}
	printf("%.2lf %d",price,count);
	return 0;
}

int q2()
{
	person ps[100];
	int gnum[100];
	int pcount;
	int f,sn;
	int i,j;
	int sonnum;
	int floornum;
	person*temp;
	int n;
	int max=0;
	for(i=0;i<100;i++)
	{
		ps[i].floor=0;
		ps[i].father=0;
		ps[i].sonnum=0;
		gnum[i]=0;
	}
	gnum[1]=1;
	ps[1].floor=1;
	scanf("%d%d",&pcount,&n);
	while(n)
	{
		n--;
		scanf("%d%d",&f,&sn);
		ps[f].sonnum=sn;
		for(i=0;i<sn;i++)
		{
			scanf("%d",&j);
			ps[j].father=f;
		}
	}
	gnum[2]=ps[1].sonnum;
	for(i=1;i<=pcount;i++)
	{
		if(ps[i].floor!=0)
			continue;
		floornum=0;
		temp=&ps[ps[i].father];
		floornum++;
		while(temp->floor==0)
		{			
			temp=&ps[temp->father];
			floornum++;
		}
		floornum+=temp->floor;
		temp=&ps[i];
		while(temp->floor==0)
		{
			temp->floor=floornum;
			gnum[floornum+1]+=temp->sonnum;
			temp=&ps[temp->father];
			floornum--;
		}
	}
	for(i=1;i<100;i++)
	{
		max=(max>gnum[i])?max:gnum[i];
	}
	for(i=1;i<100;i++)
	{
		if(max==gnum[i])
		{
			printf("%d %d\n",max,i);
			break;
		}
	}
	
	return 0;
}
