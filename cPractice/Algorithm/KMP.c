#include <stdio.h>
#include <malloc.h>
void getnext(char* c,int csize,int* next)
{
	next[0]=-1;
	int j=0,k=-1;
	while(j<csize)
	{
		if(k==-1||c[j]==c[k])
		{
			j++;k++;
			next[j]=k;
		}
		else
		{
			//这一步实际上是把当前的最大公共前缀和c[j]拼接在一起然后递归找最大公共长度
			//想明白c[j]前k个长度的字符与c前k个长度的字符是一样的 
			k=next[k];
		}
	}
}
//这个是自己写的m方级别的预处理方法 
void mygetnext(char*t,int csize,int*result)
{
	result[0]=-1;
	int j=0,k=-1;
	int hasValued;
	int i;
	for(j=0;j<csize;j++)
	{
		if(k==-1||t[j]==t[k])
		{
			k++;
			result[j+1]=k;
		}
		else
		{
			for(;k>=0;k--)
			{
				for(i=0;i<k;i++)
				{
					hasValued=1;
					if(t[i]!=t[j+1+i-k])
					{
						hasValued=0;
						break;
					}
				}
				if(hasValued)
				{
					result[j+1]=k;
					break;
				}
				else
				{
					if(k<=0)
					{
						k=0;
						result[j+1]=k;
						break;
					}
				}
			}
		}
	}
}
int strStr(char* haystack, char* needle) 
{
	if(*needle=='\0')
		return 0;
	int len1=0;
	int len2=0;
	int i=0,j=0;
	while(haystack[len1])
	{
		len1++;
	}
	while(needle[len2])
	{
		len2++;
	}
	if(len2>len1)
	{
		return -1;
	} 
	int* next=(int*)malloc(len2*sizeof(int));
    mygetnext(needle,len2-1,next);
    int isfind=1; 
    while(1)
    {
    	if(j==-1||haystack[i]==needle[j])
    	{
    		i++;j++;
		}
		else
		{
			j=next[j];
		}
		if(j==len2)
			break;
		if(i==len1)
		{
			isfind=0;
			break;
		}
	}
	free(next);
	if(isfind)
	{
		return i-j;
	}
	else
	{
		return -1;
	}
}
main()
{
	char c[]="abaabcac";
	int len=sizeof(c)/sizeof(char);
	int i;
	char *c1="mississippi";
	char *c2="issipi";
	printf("%d",strStr(c1,c2));
}
