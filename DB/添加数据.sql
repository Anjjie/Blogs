Use MyBlogsDB

GO

--EXEC Insert_PersonageInfo 'Anjjie_Blogs888','Anjjie_.**123','小龙','MyHead.png','17607560135','日积月累，丰富的知识。存放在自己的网站与大家共同学习！','2017-11-20'

--EXEC Insert_WebInfo 'XLong Blogs','Index.html','2017-11-20'

--EXEC Insert_Aduit '正在审核'
--EXEC Insert_Aduit '通过'
--EXEC Insert_Aduit '未通过'

--EXEC INSERT_ArticleType '技术'
--EXEC INSERT_ArticleType '新闻'
--EXEC INSERT_ArticleType '日常'
--EXEC INSERT_ArticleType '随手写'

EXEC Insert_Article 'DIV + CSS3 和 html5 + CSS3 有什么区别？','HTML5是HTML的最新标准版本，而css3则是css的最新标准版本。平时大家说HTML5+CSS3，其实指的就是利用这二者的新特性来开发项目。
<br />HTML5相对于以前的HTML4版本，主要朝着语义化、现代化的方向发展，去掉了一些纯表现形式的标签，增加了一些语义化的标签和多媒体标签，更加符合现代开发需要。而CSS3呢，基本上是向下兼容以前的标准，在以前的基础上添加了不少新特性。利用HTML5+CSS3组合，可能简单几行代码就能够实现以前需要很多代码配合js才能实现的功能。','日常','2017-11-24 09:37:00','小龙','default.png'

EXEC Insert_Article 'CSS3变形记(上)：千变万化的Div','传统上，css就是用来对网页进行布局和渲染网页样式的。然而，css3的出现彻底打破了这一格局。了解过css3的人都知道，css3不但可以对网页进行布局和渲染样式，还可以绘制一些图形、对元素进行2D和3D变换。从而可以替代一些以前必须使用图片实现的功能，大大加快了网页的响应速度。例如，css3可以实现渐变背景、绘制圆角和一些小图标等！
<br />
　　今天，就来说说如何用css3绘制一些小图标和css3中的变形。建议用chrome浏览器查看,这里为了方便大家理解，暂时没有写其他浏览器前缀！。
<br />一、div和css3在一起会发生什么
<br />在没有css3的时候，div在大家的眼中就是一个四四方方的方框，一个容器，有时候会有一个背景和边框。由于背景不在今天的讨论范围之内，那么，我们就从边框说起吧，下面我们来看看css3中的边框有哪些特性。

下面，我们看到的是css3的新特性，就是可以单独设置div每条border的样式，包括width和color。
<br />
.box1 {
        width: 100px;
        height: 100px;
        border: 20px solid #333;
        border-left-color:red;
        border-right-color:yellow;
        border-bottom-color:blue;
        border-top-color:green;
    }
.......
<br />
转自：http://www.cnblogs.com/yunfeifei/p/4671930.html' ,'日常','2017-11-24 09:42:00','小龙','default.png'



EXEC Insert_Article '日常测试1：检验是否能加载出来','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试2：检验长度是否不会溢出当前装载的html标签；越长越好的名称','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试3：测试数据是否对齐，文字长度溢出后是否消失或者显示...表示','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试4：人类进化论，宇宙大爆炸、银河系毁灭，何去何从？','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试5：文章就是这么乱打出来的测试数据','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试6：文章是什么？什么是文章？你能理解吗？','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试7：文章有什么作用？没用那我们为什么要写呢？','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试8：技术不是问题，问题是没有技术','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试9：学习是个无止境的过程，日积月累，方能成山','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'
EXEC Insert_Article '日常测试10：博客是什么？有什么用？为什么要做？怎么做？','没有报错是最好的选择','日常','2017-11-24 09:37:00','小龙','default.png'


exec Select_Article


EXEC Insert_MassageBoard '草不怪你就怪它','很棒，继续努力！','2017-11-20 11:10:10',1,''
EXEC Insert_MassageBoard '技术魅我diao','还不错还不错','2017-11-21 12:20:10',1,''
EXEC Insert_MassageBoard '天呼啦的小小小','加油','2017-11-22 13:30:10',1,''
EXEC Insert_MassageBoard '什么是什么中的什么','看好你哟','2017-11-23 14:40:10',1,''
EXEC Insert_MassageBoard 'C#技术就这样','有机会请教一下','2017-11-25 15:50:10',1,''
EXEC Insert_MassageBoard '前端是什么？','看看留言，快乐一天','2017-11-29 16:59:10',1,''




--Exec [Insert_Issue_library] '您目前的姓名是？'
--Exec [Insert_Issue_library] '您配偶的生日是？'
--Exec [Insert_Issue_library] '您的学号（或工号）是？'
--Exec [Insert_Issue_library] '您母亲的生日是？'
--Exec [Insert_Issue_library] '您高中班主任的名字是？'
--Exec [Insert_Issue_library] '您父亲的姓名是？'
--Exec [Insert_Issue_library] '您小学班主任的名字是？'
--Exec [Insert_Issue_library] '您父亲的生日是？'
--Exec [Insert_Issue_library] '您配偶的姓名是？'
--Exec [Insert_Issue_library] '您初中班主任的名字是？'
--Exec [Insert_Issue_library] '对您影响最大的人名字是？'
--Exec [Insert_Issue_library] '您最熟悉的学校宿舍舍友名字是？'
--Exec [Insert_Issue_library] '您最熟悉的童年好友名字是？'


