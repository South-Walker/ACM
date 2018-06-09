#include <stdio.h>
#include <malloc.h>
#include <time.h>
char** restoreIpAddresses(char* s, int* returnSize);
char* stringDeepCopyFrom(int* temp);
void subRestoreIpAddresses(int* now,int nowcount,char *s,int sindex,char** result,int* rcount);

main()
{
	char* input="010010";
	int* returnsize=(int*)malloc(sizeof(int));
	*returnsize=0;
	char**output=restoreIpAddresses(input,returnsize);
	int i;
	for(i=0;i<*returnsize;i++)
	{
		printf("%s\n",output[i]);
	}
} 
struct ListNode 
{
    int val;
    struct ListNode *next;
};
typedef struct 
{
	struct ListNode* head;
	int time;
} Solution;
Solution* solutionCreate(struct ListNode* head) 
{
    Solution* s=(Solution*)malloc(sizeof(Solution));
    s->head=head;
    s->time=0;
    return s;
}
int solutionGetRandom(Solution* obj) 
{
    srand((unsigned)(time(NULL)+obj->time));
    obj->time++;
    int i=1;
    struct ListNode*temp=obj->head;
    struct ListNode*pool;
    while(temp!=NULL)
    {
    	if(rand()%i<1)
		{
    		pool=temp;	
		}
		temp=temp->next;
		i++;
	}
	return pool->val;
}
void solutionFree(Solution* obj) 
{
    free(obj);
}
char** restoreIpAddresses(char* s, int* returnSize) 
{
    char**result=(char**)malloc(100*sizeof(char*));
	*returnSize=0;
	int* temp=(int*)malloc(4*sizeof(int));
	subRestoreIpAddresses(temp,0,s,0,result,returnSize);
	free(temp);
	result=(char**)realloc(result,sizeof(char*)**returnSize);
	return result; 
}
void subRestoreIpAddresses(int* now,int nowcount,char *s,int sindex,char** result,int* rcount)
{
	if(s[sindex]=='\0')
		return;
	int i=sindex;
	int temp=0;
	if(nowcount==3)
	{
		while(s[i]!='\0')
		{
			temp*=10;
			temp+=s[i]-'0';
			i++;
			if(temp==0&&s[i]!='\0')
				return;
		}
		if(temp<0||temp>255)
			return;
		now[3]=temp;
		result[*rcount]=stringDeepCopyFrom(now);
		*rcount+=1;
	}
	else
	{
		while(s[i]!='\0'&&temp<26)
		{
			temp*=10;
			temp+=s[i]-'0';
			i++;
			if(temp<0||temp>255)
				return;
			now[nowcount]=temp;
			subRestoreIpAddresses(now,nowcount+1,s,i,result,rcount);
			if(temp==0)
				return;
		}
	}
}
char* stringDeepCopyFrom(int* itemp)
{
	int i,j;
	char* temp=(char*)malloc(4*sizeof(char));
	char* result=(char*)malloc(16*sizeof(char));
	int length=0;
	for(i=0;i<4;i++)
	{
		sprintf(temp,"%d",itemp[i]);
		j=0;
		while(temp[j]!='\0')
		{
			result[length]=temp[j];
			length++; 
			j++;
		}
		result[length]='.';
		length++;
	}
	length--;
	result[length]='\0';
	result=(char*)realloc(result,sizeof(char)*(length+1));
	free(temp);
	return result;
}
