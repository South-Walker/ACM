#include <stdio.h>
int main()
{
	int n;
	int a[101];
	int b[101];
	int c[101];
	int i,j;
	int last;
	int pre;
	int split;
	scanf("%d",&n);
	for(i=0;i<n;i++)
	{
		scanf("%d",&a[i]);
	}
	for(i=0;i<n;i++)
	{
		scanf("%d",&b[i]);
	}
	for(i=n-1;i>=0;i--)
	{
		if(a[i]!=b[i])
		{
			break;
		}
	}
	split=i;pre=b[0];
	for(i=0;i<=split;i++)
	{
		if(b[i]<pre)
		{
			printf("Heap Sort\n");
			i=n-1;
			while(i>=0&&b[i]>=b[0])
			{
				i--;
			}
			j=b[0];
			b[0]=b[i];
			b[i]=j;
			last=i;
			j=0;
			for(i=1;i<last;i=2*j+1)
			{
				if(i+1<last&&b[i]<b[i+1])
					i++;
				if(b[j]>b[i])
					break;
				pre=b[j];
				b[j]=b[i];
				b[i]=pre;	
				j=i;
			}
			for(i=0;i<n;i++)
			{
				printf("%d ",b[i]);
			}
			return 0;
		}
		pre=b[i];
	}
	pre=b[split+1];
	i=0;j=0;
	while(i<=split&&j<=split+1)
	{
		if(b[i]<=pre)
		{
			c[j]=b[i];
			i++;
			j++;
		}
		else
		{
			if(i==j)
			{
				c[j]=pre;
				j++;
			}
			else
			{
				c[j]=b[i];
				i++;j++;
			}
		}
	}
	if(i==j)
	{
		c[j]=pre;
		j++;
	}
	else
	{
		c[j]=b[i];
		j++;
	}
	for(j=split+2;j<n;j++)
	{
		c[j]=b[j];
	}
	printf("Insertion Sort\n");
	for(i=0;i<n;i++)
	{
		printf("%d ",c[i]);
	}
	return 0;
} 
