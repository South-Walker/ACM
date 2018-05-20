#include <stdio.h>
main()
{
	int height[]={2,3,4,5,18,17,6};
	int len=sizeof(height)/sizeof(int);
	printf("%d", maxArea(height,len));
}
int maxArea(int* height, int heightSize) 
{
	if(heightSize<=1)
	{
		return 0;
	}
    int x=(height[0]>height[heightSize-1])?height[heightSize-1]:height[0];
    x*=(heightSize-1);
    int *PFronter=height,*PLatter=height+heightSize-1;
    int temp;
    while(PFronter!=PLatter)
    {
    	temp=*PFronter;
    	while(*PFronter<=temp&&PFronter!=PLatter)
    	{
    		PFronter++;
		}
		temp=(*PFronter>=*PLatter)?*PLatter:*PFronter;
		temp*=(PLatter-PFronter);
		x=(temp>x)?temp:x;
		
    	temp=*PLatter;
    	while(*PLatter<=temp&&PFronter!=PLatter)
    	{
    		PLatter--;
		}
		temp=(*PFronter>=*PLatter)?*PLatter:*PFronter;
		temp*=(PLatter-PFronter);
		x=(temp>x)?temp:x;
	}
	return x;
}
