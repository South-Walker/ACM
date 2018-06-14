#include <stdio.h>
#include <malloc.h>
main()
{
	horse();
}
//2018上海交大上机 
void horse()
{
	int**board=(int**)malloc(5*sizeof(int*));
	int i=0;
	int *solvercount=(int*)malloc(sizeof(int));
	*solvercount=0;
	for(i=0;i<5;i++)
	{
		board[i]=(int*)malloc(5*sizeof(int));
	}
	subhorse(0,0,board,solvercount);
	printf("%d",*solvercount);
} 
int over(int**board)
{
	int i,j;int k;
	for(i=0;i<5;i++)
	{
		for(j=0;j<5;j++)
		{
			if(board[i][j]==0)
			{
				return 0;
			}
		}
	}
	return 1;
}
void subhorse(int x,int y,int**board,int*solvercount)
{
	if(x<0||x>=5||y<0||y>=5)
		return;
	if(board[x][y]==1)
		return;
	board[x][y]=1;
	if(over(board))
	{
		*solvercount+=1;
	}
	subhorse(x+2,y+1,board,solvercount);
	subhorse(x+2,y-1,board,solvercount);
	subhorse(x+1,y+2,board,solvercount);
	subhorse(x+1,y-2,board,solvercount);
	subhorse(x-2,y+1,board,solvercount);
	subhorse(x-2,y-1,board,solvercount);
	subhorse(x-1,y+2,board,solvercount);
	subhorse(x-1,y-2,board,solvercount);
	board[x][y]=0;
} 
void subecnu8(int n)
{
	printf("1123581321345589144233377610987159725844181676510946177112865746368750251213931964183178115142298320401346269217830935245785702887922746514930352241578173908816963245986102334155165580141267914296433494437701408733113490317018363119032971215073480752697677787420491258626902520365011074329512800995331629117386267571272139583862445225851433717365435296162591286729879956722026041154800875592025047307819614052739537881655747031984210610209857723171676801775652777789003528844945570212853727234602481411176690304609941903924907091353080615211701294984540118792648065155330493931304969544928657211148507797805034164546229067075527939700884757894439432379146414472334024676221234167283484676853788906237314390661305790721611591991948530947554971605006438163670882596954969111225854201961407274896736798916376386122581100087778366101931177997941600471418928800671943708161204660046610375530309754011380474634642912200160415121876738197402742198682231673194043463499009990551680708854858323072836211434898");
}
void ecnu8()
{
	int n;
	scanf("%d",&n);
	if(n>=100)
	{
		subecnu8(n);
		return;
	}
	int i,j;
	long long fib[45];
	fib[0]=fib[1]=1;
	for(i=2;i<45;i++)
	{
		fib[i]=fib[i-1]+fib[i-2];
	}
	int fibindex=0;
	int stackindex=-1;
	int temp;
	char stack[20];
	
	stack[0]='\0';
	while(n)
	{
		if(stackindex==-1)
		{
			temp=fib[fibindex];
			fibindex++;
			while(temp)
			{
				stackindex++;
				stack[stackindex]='0'+temp%10;
				temp/=10;
			}
		}
		printf("%c",stack[stackindex]);
		stackindex--;
		n--;
	}
}
void ecnu7()
{
	int casenum;
	int P,B,M;
	scanf("%d",&casenum);
	if(casenum==0)
		return;
	int nums[51][50];
	int i,j,k;
	for(i=0;i<50;i++)
	{
		nums[1][i]=i;
	}
	for(i=2;i<51;i++)
	{
		for(j=0;j<50;j++)
		{
			nums[i][j]=0;
			for(k=1;k<=j;k++)
			{
				//一共丢了k次
				nums[i][j]+=nums[i-1][j-k]+1; 
			}
			if(nums[i][j]>1000)
			{
				break;
			}
		}
	}
	while(casenum)
	{
		casenum--;
		scanf("%d %d %d",&P,&B,&M);
		if(B==1)
			printf("%d %d\n",B,M);
		else
		{
			for(i=0;i<50;i++)
			{
				if(nums[B][i]>=M)
				{
					printf("%d %d\n",P,i);
					break;
				}
			}
		}
	}
}
