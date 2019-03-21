#include <stdio.h>
int q1()
{
	int r;int n;int casenum=0;
	scanf("%d",&n);
	while(n)
	{
		n--;
		scanf("%d",&r);
		casenum++;
		printf("Case #%d: ",casenum);
		printf("%d %d 0 0 0 0\n",r,r);
	}
	return 0;
}
int main()
{
	int n;
	int all[200001];
	int i,j;
	int p;
	int max=-1;
	int x;
	long long total;
	scanf("%d",&n);
	total=n;
	i=0;
	for(i=0;i<n;i++)
	{
		scanf("%d",&all[i]);
		max=(all[i]>max)?all[i]:max;
	}
	p=max+1;
	x=all[0];
	for(i=1;i<n;i++)
	{
		if(all[i]>x)
		{
			total=total+all[i]-x-1;
		}
		else
		{
			total=total+p+all[i]-x-1;
		}
		x=all[i];
	}
	printf("%ld",total);
	return 0;
}
