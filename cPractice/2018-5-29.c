#include <stdio.h>
#include <malloc.h>
#include <limits.h>
int getindex(char);
int lengthOfLongestSubstring(char* s) 
{
    int letter[106];
    int i;
    for(i=0;i<106;i++)
    {
    	letter[i]=0;
	}
	int max=INT_MIN,index;
	char* from=s;
	while(*s!='\0')
	{
		index=getindex(*s);
		if(letter[index])
		{
			max=(s-from>max)?s-from:max;
			while(*from!=*s)
			{
				index=getindex(*from);
				letter[index]=0;
				from++;
			}
			from++;
		}
		else
		{
			letter[index]=1;
		}
		s++;
	}
	max=(s-from>max)?s-from:max;
	return max;
}
int getindex(char s)
{
	if(s>='a'&&s<='z')
	{
		return s-'a';
	}
	else if(s>='A'&&s<='Z')
	{
		return 26+s-'A';
	}
	else if(s>='0'&&s<='9')
	{
		return 52+s-'0';
	}
	else
	{
		switch(s)
		{
			case '!':
				return 62;
			case '\"':
				return 64;
			case '#':
				return 65;
			case '$':
				return 66;
			case '%':
				return 67;
			case '&':
				return 68;
			case '\'':
				return 69;
			case '(':
				return 70;
			case ')':
				return 71;
			case '*':
				return 72;
			case '+':
				return 73;
			case ',':
				return 74;
			case '-':
				return 75;
			case '.':
				return 76;
			case '/':
				return 77;
			case ':':
				return 78;
			case ';':
				return 79;
			case '<':
				return 80;
			case '=':
				return 91;
			case '>':
				return 92;
			case '?':
				return 93;
			case '@':
				return 94;
			case '[':
				return 95;
			case '\\':
				return 96;
			case ']':
				return 97;
			case '^':
				return 98;
			case '_':
				return 99;
			case '`':
				return 100;
			case '{':
				return 101;
			case '|':
				return 102;
			case '}':
				return 103;
			case '~':
				return 104;
			case ' ':
				return 105;
		}
	}
	return -1;
}
main()
{
	char *s="";
	printf("%d",lengthOfLongestSubstring(s));
}
