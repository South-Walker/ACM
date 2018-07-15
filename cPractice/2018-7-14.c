#include <stdio.h>
#include <stdlib.h> 
void main()
{
	ecnu15();
} 
int cmp(const void*a,const void *b)
{
	return *(long*)a-*(long*)b;
}
void poj2388()
{
	int a[10000];
	int i,j,n;
	scanf("%d",&n);
	for(i=0;i<n;i++)
	{
		scanf("%d",&a[i]);
	}
	myqsort(a,0,n-1);
	printf("%d\n",a[i/2]);
}
void ecnu15()
{
	long a[200000];
	long b[200000];
	int n;
	int i,j;
	long temp;
	long answer;
	while(scanf("%d",&n)==1)
	{
		answer=0;
		for(i=0;i<n;i++)
		{
			scanf("%lld",&a[i]);
		}
		for(i=0;i<n;i++)
		{
			scanf("%lld",&b[i]);
		}
		qsort(a,n,sizeof(long),cmp);
		qsort(b,n,sizeof(long),cmp);
	//	myqsort(a,0,n-1);
	//	myqsort(b,0,n-1);
		for(i=0;i<n;i++)
		{
			temp=a[i]+b[n-i-1];
			temp=temp*temp;
			answer+=temp;
		}
		printf("%lld\n",answer);
	}
}
void testsort(long*array,int begin,int end)
{
	int i,j;
	long temp;
	for(i=0;i<=end;i++)
	{
		for(j=1;j<=end;j++)
		{
			if(array[j]<array[j-1])
			{
				temp=array[j];
				array[j]=array[j-1];
				array[j-1]=temp;
			}
		}
	}
}
void myqsort(long*array,int begin,int end)
{
    int i=begin,j=end,x=array[begin];
    if(begin < end)
    {
        while(i<j)
        {
            while(i<j && array[j]>=x)//从右到左找到第一个小于x的数  
                j--;
            if(i<j)
                array[i++]=array[j];
            
            while(i<j && array[i]<=x)//从左往右找到第一个大于x的数  
                i++;
            if(i<j)
                array[j--]=array[i]; 
            
        }
        
        array[i]=x;//i = j的时候，将x填入中间位置  
        myqsort(array,begin,i-1);//递归调用 
        myqsort(array,i+1,end);        
    }
}
