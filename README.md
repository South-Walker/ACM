# ACM
<br>3-3<br> 这几天忙着做大创网页<a href="https://github.com/South-Walker/dachuang" target="_blank" title="dachuang">@South-Walker/dachuang</a>所以算法方面的代码量少了，2月28之前的都是数据结构的学习记录，本人不打算参加ACM竞赛只是想学习算法方面的思想， 故语言上选择的是较为顺手的C#，今天的内容是吊死鬼游戏与发救济金，意识到了删除数据（节点）可以顺手做一个标记，或赋值0，可以省去后面判断的很多麻烦，在发救 济金中用到了双向循环链表，感觉是小题大做，明显没有答案用数组的简单。

<br>3-5<br> 
忙着做大创问卷录入，很惭愧的一星期，今天这道信息解码题做复杂了，可能是刚学完数据结构的原因，做了两个队列结果什么也没做出来，明明只是需要一个二元数字的事情，惭愧

<br>3-6<br>
725,11059应该是两道水题，从看题到有思路没有超过10分钟，值得学习的是725中标准答案的判断两个数是否有0~9的方法
我采用的是拼接字符串的方法，然后2个for循环嵌套检查是否充足重复数字。答案则是构造了数字，出现对应数字时，数组对应项值为1，
最后做sum判断是否是10。答案的方法简单明了，在于对任意2个数字就执行10次数组赋值，而我的方法一是要考虑存在0的情况多于答案二是
2层for循环代表我可能要执行100次才能判断正确与否，小处见真知，一直以来的工作都是在忙于实现，看似熟悉了工具，到了比拼算法的时候
不足就暴露出来了，惭愧惭愧。
11059怎么说呢，先反思一下自己数量级估计错误，用int导致溢出吧，然后自己明显是用一个复杂的方法去解决了一个很简单的问题
虽然就效率而言可能是我的算法比较快，但是用最简单的穷举也能保证在规定时间内完成，见仁见智吧。

<br>3-7<br>
10976,简单题，立即想到了枚举范围是K到2K以及需要对等式变形，美中不足是变形的不彻底导致了必须引入double类型代替int类型，
答案变形成了y * k % (y-k) == 0即y*k恰是y-k的x倍，总之算差强人意的完成了
<br>p.s. 今天遇到一个很难调试的bug，原理是这样的 C#中类、接口、数组和字符串被称为引用类型，变量储存的是其在内存中的地址，
故会出现
<br>int[] array = {1,2};
int[] temp = array;
temp[0] = 0;
console.write(array[0]);//输出0
<br>记之

<br>3-10<br>
524,乍看很难的一题，但是想清楚后发现可以很简单的递归实现，只是需要记得在递归结束后需要将数据还原，昨天书里的内容，感觉刷了这么多天题下来自己真的有变强。继续努力

<br>3-11<br>
129,看见题目人先傻掉了，英语能力有待提高，然后是理解题意后发现应该是简单题，加之前无重复，加之后重复，那重复的一个子集中一定包括末尾。
进一步分析，如果因为加入最后一个产生重复，那么最差的情况下重复的每个子集之和为全部集合，即各占一半。那么最多要查K/2次确定1个字母能否放入
最差需要判断L次才能知道下一个字母，乘法原理，LK^2次计算可得解，无论如何都不可能超时！
另外记一个网页http://www.uvatoolkit.com/problemssolve.php 既然无法在vjac那就自己拿数据自己帮自己ac

<br>3-12<br>
140,可能是这么多天最难的一题了？先是题目难以理解，理解之后思路首先是做递归全排列，因为只有8位，故可以o（n^2）。然后计算带宽是最难的部分
剪枝，还只是其次，因为用了二元数组表连接，差点被字母和数字之间的互换搞糊涂，然后是因为数组是引用类型，所以必须以字符串的形式
保存当前最小的带宽对应的次序，真的累。
<br>
1354，崩溃。。。。看了答案用了二叉，还没学到，下一周补上吧。

总结：剪枝与回溯都是在函数递归中为减少计算量而使用的方法，使用前要仔细思考是否多剪，是否少回。
p.s.uva140的代码写太丑了！！要减少全局变量的使用。
<br>
<br>3-13<br>
题目超级。。简单，可能是为了熟悉c++特性的，没什么好讲，特别的是今天做大创的后台数据提取也用到的算法思维，题目是这样的：
<br>肖某在一个星期前在网上发布了一副调查问卷，一个星期来一共收集了501张问卷，其中，问卷有多选，单项，简答三种题型
其中，为图存储方便，肖某录入数据库的形式是这样的，如果问题是简答，那么以字符串的形式存储，如果问题是多选，单选，则按
A=1，B=2，C=4，D=8，E=16......（选项最多有11个即H=1024）的方式，将回答做加和，以加和的形式存入。一个星期后，肖某需要
提取这些数字继续问卷分析，其中，最复杂的的分析是这样的。
<br>输入<br><br>
2
A,B,D
4
<br>输出<br>
<br>
一个一元数组（由数组画出表格的程序已经写好），横坐标表示第四题的所有选项，纵坐标表示选择该选项，且在第二题同时选择了A,B,D选项（包括选择A,B,C,D的人，但是显然不包括选择B,D的人）
对应的人数。
<br>
<br>
ok,搞定，思路如下：<br>
以输入为例，定义2为依赖项，构造一元bool数组，递归法把数组中第0,1,3标示为true，（先判断回答是否大于1024，若是，第11项
为true，然后减去1024。之后，再判断是否大于512，若是，第10项为true，然后减去512......至答案值为0）得到一个表示所选选项的
数组，同理，对第四题构造同样数组，循环判断：如果存在int i 满足对2的bool[i] == true，对4的bool[i] == false，则该条舍弃，
否则入栈执行和之前所写的普通查询一样的程序。<a href="http://xiaoliming96.com/RelatedSelect.aspx" target="_blank" title="dachuang">应用该算法的页面</a>
<br>
<br>3-14<br>
101,看得不是特别明白，大致上好像是要自己实现一个栈的结构（题目里多次出现stack），支持特定的增删改查操作（vector in c++ == arraylist in c#？），显然的，每一个栈中，如果存在木块，第一个木块序号肯定是当前栈的序号。
因为没有任何方法能在不指定上一块木块的情况下，将任意木块移动到任意位置，讲道理代码复用率太高，肯定要重构写成方法去优化的
但是。。没必要。。。算了吧，还有大创要做
<br>3-15<br>
10815,题外话，刚刚才发现昨天题目日期写了3-15..今天的题目改成true3-15好了。安迪的字典，显然的二叉添加与查询，显然的中序遍历
拿来练手正好，自己实现了一个普通的二叉树。。（自己写的比书上写的丑太多了。。）性能优化方面可以试试看avl平衡二叉，不过没有这个必要
暂时就算了吧，有点羡慕C++啊，一个set什么都搞定了。
<br>uva1354,今天弄明白了解答是如何穷举及如何存放穷举的，运用了二叉的思想，但是没有用二叉的结构，
第一次见识到，运用数组表示二叉的方法，i项-1表示节点，2i及2i+1对应节点上的两子节点，递归考虑也是很周全，回溯回来必须将数据
返回原来的值就不说了，每一个if判断的剪枝位置也是正好。。。。真是羡慕啊
<br>3-16<br>
<br>uva156我不记得了，反正是简单题，但是当我用冒泡去排序的时候我知道我输了，虽然复杂度应该还是o(n^2)这个量级，但是毕竟是慢了好多<br>
今天应该能够把uva1354终结了，归并排序和快速排序也可以提上日程了。已经终结。
<br>3-18<br>
<br>uva12096血崩，得几个教训总结一下吧，一个是现在的能力不能随意的使用结构的嵌套，原因有2，一是结构体大多为引用类型，二是结构体的嵌套无法递归
比较大小（如今水平）如果说uva1354是从逻辑上把人打死，那12096就是从语言特性上堵住了路，很难受
<br>debug笔记<br>
        static public void Cadd()
        {
            ArrayList al_1 = (ArrayList)stack_main.Pop();
            ArrayList al_2 = (ArrayList)stack_main.Pop();
            al_2.Add(al_1);
            stack_main.Push(al_2);
            Console.WriteLine(((ArrayList)stack_main.Peek()).Count);
        }
<br>这个代码的错误在 al_1 == al_2 的时候，它把一个盒子放到了自己里面（al_2存储了一个指向al_2本身的指针）
<br>
uva540。。。。。，难度梯度要不要这么大啊，简单题，要求常数级别的复杂度，问题出在入队的时候，即不能通过遍历队列来插队，那就空间换时间咯
哈希表存组，main队列存储组数，各组集合构成一个队列数组，在其中存储元素，出队入队都是常数级，完美。
<br>uva136。。。。我居然。。不会做。。。看了书，使用了优先队列，c#里没有内置，在百度上抄了别人实现的代码解决了，这个真的叫阴沟里翻船。。

<br>p.s.今天fork了一份归并排序的算法，算是对分治法的复习，离完全脱离资料写出来还有点距离，还需要复习与在实践中熟悉

<br>3-19<br>模拟题，第一题不用编程，1806没什么毛病，第二题 40096，没毛病，直接输出应该也不用考虑复杂度，第三题，什么鬼。。
考虑如下数组{ "q", "p", "o", "n", "m", "l", "k", "j", "i", "h", "g", "f", "e", "d", "c", "b", "a" }
0 = {16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0}
1 = {16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,0,1}
2 = {16,15,14,13,12,11,10,9,8,7,6,5,4,3,1,2,0}
3 = {16,15,14,13,12,11,10,9,8,7,6,5,4,3,1,0,2}
4 = {16,15,14,13,12,11,10,9,8,7,6,5,4,3,0,2,1}

aim = {15,14,6,11,0,5,16,7,9,12,4,10,8,2,13,3,1}
<br>总结出如下规律<br>1.所有字母不重复，且全部出现一次<br>2.从左至右一个个比较，较大的数字一定先小于较小的数字。
<br>

<br>第四题，java版本，初步猜测应该是return (t / (Math.Abs(t))) * (Math.Abs(t) + 1);（其实我不会java，这个是c#）
确实是对的
<br>第五题，1秒时间，计算机每秒千万级运算，假设年利率30%，6月还完，换成分差不多是191666，就算我傻乎乎从1算到20w也不可能超过1s，怎么想都可以暴力,
<br>剩下第三第四第五，复习归并排序，学习快速排序，先休息一下（可能要休息一天）<br>第五题想错了，因为最多有24个月，每个月都算其实是很危险的
需要类似剪枝的操作，拿当前枚举的数乘以月数，小于1W的可以排除，大于2W的同理

<br>3-20<br>
uva210,看题目花了很久，总结出几点<br>1.lock住的本质是不执行除print以外的指令，没必要再实例化一个队列存放以外<br>2.指令本身不是委派，最多是一个指向方法的指针
<br>3.只有同一进程内部存在严格的先后关系，故用n个队列的数组存进程，用一个哈希表存变量值<br>4.end没必要存放在队列中，因为end即使不执行也没有影响。<br>
解决，挺有意思的一道题，看清要求后还算简单。就是代码有点丑，有个函数写得太长，重复率太高，对没错，我说的就是主方法，搞得我都不知道把快排写哪里。
以后一定要养成题目写方法里面的习惯，主方法尽量空出。
<br>今天挑战盲打快排算法，第一次因为一些小细节，加加减减没有处理好，导致无限递归栈溢出，第二次看了一下源码（c++版）才跑起来了。
感觉上对快排思想的思想是理解了，但是细枝末节的地方还需要加深，递归毕竟是需要考虑周全才能下手的，再慢慢熟悉吧。

<br>3-21<br>
uva514,第一反应是穷举所有子段，将子段倒序输出以穷举所有情况，算了一下复杂度应该是O(2^n)数据最多有1000，显然不能用，然后觉得
应该用比较法，但是思路局限在出栈检测时把数据全部出栈，（对于2 1 3的输入判断错误），看了一下答案，答案的检查只检查栈顶，换句话说，
一次操作只有三种可能a=》b（其实是a=》c=》b），a=》c，c=》b，分别判断第一种及第二种能否发生，若能，必然发生，若不能必然执行第三种
复杂度o（n）

<br>3-22<br>
uva11988,简单题，尤其是还被剧透了用链表，算是写的比较熟的数据结构。没什么好说的，c#好像没有内置链表结构，就自己写了一个可以双向插入的链表，用起来还行。
<br>3-23<br>
uva679,考察二叉，简单题，最多52W次遍历，，每次遍历有20次运算，理论上复杂度是o（dm）即千万级别，要考虑一下化简，
首先想到的是所求的数据前任意组是无意义的，然后最后落入的数字在数值上与所经历的格子上的bool对应的二进制位组成的二进制数最前方加上1后化为十进制
的数值相等，故讨巧一点可以使用二进制转换的方法，再讨巧一点，构造二叉树的时候可以花点空间放置当前的叶子节点，这样构造下一层
时只需要遍历叶子就行，少花了一半的时间，在d=20，n=524288的时候运行时间是1.1S应该没道理超时。
<br>看了答案，用答案的代码写了一份答案。。。效率优化了1100倍，d=20，n=524288时只需1ms，空间复杂度基本可以看做0，我崩溃了，
答案的思路很简单，根本没有使用二叉，上一层如果向右走，值乘以2+1，如果向左走，值乘以2，到叶子即输出，用通过该点小球的奇偶性判断
走向，空间复杂度是o（1），时间复杂度是o（d）基本当做没有吧。。我都可以手算。。然后答案的思路我只需要二十行代码，我自己写答案包括构造树
结构一共花了八十行。以前只听说过同样的题目不同的人解出来运行时间有差距，没想到无论是空间，时间，还是代码量都可以是天差地别，惭愧惭愧。。
<br>3-24<br>
uva122,感觉上应该是简单题啊。。。做个队列就行了吧，原理是，队列一开始存储root，然后每出队一个元素，就把它的左右节点分别入柜
直到队列空为止，等一下，我反应过来了，难点在于构造二叉树本身，如果没有上层节点，我要怎么存下层数据！答案很简单了，那就不用做树了，
这题的数据结构是字典，或者说哈希表，等级是索引，用等级存储值复杂度o（nlogn），至于怎么计算等级uva679提示过了根节点是1，向左*2，向右*2+1
剩下一个问题是如何判断一个节点是否有父节点，因为乘法原理，找出父节点的算法复杂度将直接乘到nlogn上（反正才256个节点。。）答案很简单，
只需从上到下输出时把索引/2，如果得到的新索引有值，那就说明它可以挂在树上复杂度o（1）。最后吐槽一下这个输入的范例，到底是有空格还是没空格，
到底会不会换行，C#没有c这么方便的占位符机制，这样搞我只能上正则的！
<br>写完了，确实是简单题，最后还是要说，明明这两天是在学二叉，但是为什么最好的算法都用不到二叉树，摔~。
<br>3-25<br>
uva548,难题，首先要注意权值与实际的二叉排列没有关系，故要绘制二叉结构必须借助中序，权和节点数不会多于1W，对性能要求很大，o(n^2)
以上是基本不要想了。看了答案，利用了后序排列的性质，最后一个数据必然是right的根来减少了运算量。
<br>3-26<br>
今天出去踏青了，应该就只能写一题了，留一题到下星期写


<br>3-27<br>
uva839,不看答案，难题，看答案中等题，看懂答案，中等偏简单题。（顺路吐槽一下c++真的是难看懂），
<br>debug笔记<br>
答案应用了一种指针传参的技巧（本人不会c与c++，如果说错，也不负责）
在c#中int是值类型，本身不会随方法中的修改而修改，类似的技巧是ref类型的传参。（实际上是将int型由传递值，改为了传递内存地址）
<br>然后要注意的是先序遍历树的逻辑关系，给出先序的顺序实际上是提示我们一行行至顶而下的处理input，如果遇上有子树的节点无法处理
那么就需要递归到叶子去计算重量。注意：因为每一个input数组中的元素永远只能用一次，故对index参数也需要使用ref类型，每递归一次便加1，
以免回溯时index被减去。
<br>p.s.以后看答案还是看java版本的吧，语法比c++接近一点。
<br>3-28<br>
uva699,难题，首先想到的是传一个数组，随输入顺序逐层递归，因为数组是引用类型，也就不需要用ref的技巧。（当然，也是不需要真的建树的（笑））
写了30分钟出答案了！！这是简单题啊！！尤其是已经有了uva839的铺垫的情况下。代码量小，递归逻辑简单，当然也可以说是我自己进步了？（笑）
<br>3-29<br>
这个星期布置的任务是链表，然而一是我在寒假期间已经基本熟悉了链表（包括双向与循环）的实现（当然是C#），二是c语言的书我看起来也不会太方便。
所以这周我就按我自己的节奏来熟悉二叉树（初步计划是实现自平衡与红黑树），练习使用树的结构（包括利用树存储四则运算在内）。
今天的内容是实现AVL自平衡二叉树的增与查。自平衡二叉树是指在增加节点后通过自我调整（旋转与翻转）使得左右子树高度的差值之绝对值小于等于1的二叉树，
在AVL中不会出现因为二叉树左偏或右偏使得增删改查效率下降的情况。
<br>最简单的，在第一次插入一个问题数据使得树结构不满足avl之前，该树肯定是满足avl结构的，那么只要保证在插入一个数据后，树依旧满足avl结构，
那该树就是一直保持avl结构的，还可以进一步发现，插入的问题数据，到因为问题数据而左右子树高度差=2或-2的根节点高度差最大为三，证明如下：
<br>首先假定添加一个数据后树失衡，那么从将被插入的节点向上数一个高度取一个子树，该子树有且只有三种排列可能。1.有2个节点，子节点在父节点左边且问题数据将
插入到子节点左或右。2.有2个节点，子节点在父节点右边且问题数据将插入到子节点左或右。3.有三个节点，父节点左右节点都不是空节点，问题数据将插入任意子节点上。
<br>显然，对应1,2两种情况，只需要把子树的2个节点与问题数据本身翻转，即可保证子树在插入问题数据前后左右高度差不变，因为插入前满足AVL，插入后也自然满足AVL。(其实极端一点，只要我插入时发现父节点的父节点上存在空节点，我不管avl结构有没有崩溃都可以把它们三个节点进行翻转，有利无害)
困难在于第三种情况的翻转,分析这种情况，需要再多取一个高度，这样在插入前最小子树就又有2种情况，下述一种及其镜像。<br>
第一层 节点a<br>
第二层 节点b 节点c<br>
第三层 节点d 节点e 空节点 空节点<br>
这样问题数据可能要插入d节点或e节点，接下来讲诉插入d节点的情况
针对这种情况，应该执行的翻转处理是，将高度大的一端的第二层父节点（上述是节点b）放入第一层，源第一层节点（a）与高度小的一端的节点（假设是右节点）（c）移入上移节点的右节点与右节点的右节点处
同时第三层右节点e移入a的左节点，将节点d上移至b的左节点（可以在把节点b移动到第一层后，依次进行acde的add操作，这个操作不会使avl崩溃）
结果如下：
第一层 节点b<br>
第二层 节点d 节点a<br>
第三层 空节点 空节点 节点e 节点c<br>
这个时候问题数据会插入两个空节点中的一个，高度保持在三层avl结构不变<br>
其实仔细想了一下当count>3时，最开始的两种情况其实是节点d或节点e为空的情况。故可以全部一般化成三层的情况。<br>
然后最重要的一点，子树也是树，就是说他本身也能是树这个类的实例<br>
总结一下：<br>
节点类，不赘述<br>
树类<br>
实例化可以选择空，也可以选择以一个节点为参数（方便旋转），如果是以节点为参数，递归计算count值。
属性包括一个根节点，包括一个count表明数量。<br>
Add函数，如果count是等于2的，加之后判断根节点（函数代码为#函数），如果根节点存在左右空节点，旋转。如果count大于等于3，就很麻烦。。最简单的思路是穷举计算6！次，但是现在是在学习，故不讨论。
首先要以插入节点的父父节点做根建树判断是否需要旋转（#函数），如果需要，旋转后高度不变不会导致avl崩溃，如果不需要就以父父父节点做树，计算高度（函数代码为*函数），差不为2，就不需旋转，若为2，就需要旋转，旋转函数很多而且需要上一下节点的指针。
<br>注#函数已经实现，作为代价原Add函数作为avl类私有方法，实现一个不判断直接add的封装，增添了trueAdd方法供添加时调用.
<br>查找最小错误子树的方法已经写好了，写了一个挺漂亮的递归，同时把该树的树根存储在了一个属性里。
<br>搞定！！一共277行代码。可能会有点小bug，明天试着写个单元测试乱序插入1-2^10看看会不会乱
<br>单元测试没通过，原因是有一种翻转判断错误，继续debug
<br>看了一下别人的源码，还是在node类里面塞了一个表示左右节点高度差的属性，做了一个修改它的方法。
<br>在1-1024中乱序插入的结果基本正确，做了一下断点，树也是满足avl结构的，查找和插入已经算是实现了。总结一下：
感觉实现的过程就是一道道算法题目的堆叠，一个个解出来很有成就感，但是最可怕的是自己都不知道自己需要怎么样的方法。另外在树结构中，
递归（中序先序后序）的作用非常大，很多地方只能用递归来处理。
目前代码量是304行，明天开始尝试添加删除功能（今天时间：3-31）
<br>4-1<br>
愚人节快乐，先说一下今天的任务，一个是把物化实验的数据自己写程序来处理，这个完成了一半了（大抵上是1900条如下的数据，要求是回归拟合会外推法处理误差<br>
0,201049,76410,0<br>
1,200902,76402,0<br>
2,201058,76434,0）线函数类已经封装好了，明天应该还要处理一下交点的问题，然后图表基本也画好了，需要在加上一下必要的说明（好像R值还没算，这个再说）界面再友好一点，这个还算简单的
<a href="https://github.com/South-Walker/DataHandingForLab" target="_blank" title="DataHandingForLab">源码@South-Walker/DataHandingForLab</a>
然后是avl的删除方法（处理完就去搞红黑树）删除方法，1.真实删除，删除后调整二叉树，再旋转成avl结构。2.懒惰删除，给节点类添加一个标记属性，删除时标记节点（节点
仍在树，故不需要调整与需要旋转树）<br>
学习嘛，就是要挑战自己，所以我会尝试真实地删除数据。
首先，对正常的树执行删除操作，有三种情况1.删除的节点是叶子节点，直接删除即可。2.删除的节点只有右子树或左子树，将删除节点的父节点所存储的引向该节点的指针引向该节点的右（左）子树的根即可
3.删除的节点有左右子树，这个是难点，方法是中序遍历树，把删除节点前的一个节点放到删除节点的位置（改变删除节点父节点，该节点父节点，该节点的属性）
显然的，中序得到的，是小于待删除节点的最大值，故一定没有右节点，即满足2的条件，按2删除它，替换带删除节点的位置。
<br>然后在avl中由于我的节点类中有一个表明左右节点高度差的属性，而树类中旋转需要依靠这个属性，所以在删除后，需要重新写入这个属性，然后，与
插入一样，这个属性只会在删除经过节点时才会需要修改，然后回溯时，与插入不同，插入是由绝对值减小（1，-1变成0）表示树变得平衡，不需回溯，而删除是
0变成-1,1表示树此时是平衡的，不需回溯，原理是删除一个根属性值为0的树上的叶子节点不会导致这课树本身的高度发生改变（当然，根左右节点的高度差可能会变）
注意：一种特殊情况
<br>
第一层 节点b<br>
第二层 节点d 节点a<br>
第三层 空节点 空节点 节点e 节点c<br>
删除节点d后失衡的情况在插入中没有出现过，需注意。
<br>正常的二叉删除已经实现。（4-1）
<br>走远了。。。贪简单写了个插入和删除都是o（n）的算法。。。哦，不对，插入里面给的是最小子树，只有o（log2n），但是删除是真的慢了。也证明了懒惰删除的必要性（笑）

<br>4-3<br>
今天开始研究别人的AVL实现。
<br>debug笔记:<br>
(value < prev.Data) ? prev.Left : prev.Right
这一行的作用等同于
if(value<prev.Data)
return prev.Left;
else
return prev.Right
更加简洁，优雅。
<br>总结一下：AVL是从接触数据结构开始，我遇到的最复杂的，当然也是最高效的结构，因为高效的要求，在实现的时候更是要分外小心，很多时候可能会被逼着使用一下抽象水平很高的方法
这几天的学习还是挺有收获的，范例的源码在git下4-3的地方，可取之处1是存储了插入和删除时的路径，方便取用，同时将删除的复杂度减少到o（logn），比我的递归猴戏好多了，2是把所有旋转根据插入顺序
分为了LL,LR,RR,RL，旋转操作更加简洁，3是在删除时如果同时存在左右子节点，处理节点交换时只是交换数据，这样就显得简单，明后天应该会开始对红黑树的学习？或者回到做题的日子？无论如何，谨记，留给自己的时间已经不多了。
学完红黑后要找个时间好好复习
<br>4-5<br>
妈的什么鬼？！我需要消化一下。
先说明一下为什么红黑效率比avl高，首先红黑并不是严格平衡的二叉树，在它的规则下，允许存在左右高度差大于二的子树，在它的条件下，显然的在插入数据时，首先，
需要旋转的次数就会小于avl（因为它更‘宽容’）而考虑删除时的情况，找到删除点后，为了对avl还是红黑，都存在一个旋转的最小子树，对这个子树旋转，复杂度都是o(1)，但是,对avl而言，删除后，最坏最坏的情况，需要回溯到所有经过的路径上，检查是否平衡这个复杂度是o（logn），而
‘据说’红黑对于任一删除动作都只需要旋转三次（这一步还需要后期学习证明）<br>
所以，理论上，红黑在数据插入以及删除方面应该会有更好的表现，由于它不是严格平衡的二叉树，所以在查询方面它的性能理论上会稍弱于avl。
查资料时看见了一句话：叫“二叉搜索树都是在平衡度与插删时效的一个trade-off。”没有绝对优秀的结构，一切都是在不同方面性能之间的妥协。
范例的源码传了一份在4-5上，这星期慢慢看，慢慢学。
<br>4-6<br>
<br>debug笔记<br>讲讲题外话，在使用httprequest时如果在你拿到了请求流，而且手动把它关掉了，那么你接下来对这个请求的所有操作，包括写header加cookies都是写不进去的。<br>
先钻研插入的情况。首先，最基本的一点，记录插入时的原始路径是必要的，这有助于在回溯时，方便的找到对应点的指针，而不是用猴戏的递归（这里写递归算法最主要的问题是会导致之后提取节点困难，因为红黑在插入时最坏的表现需要回溯到根节点。）
<br>4-7<br>
出现问题，修整，看算法导论
