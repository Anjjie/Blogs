USE master
GO
IF DB_ID('MyBlogsDB') IS NOT NULL
  DROP DATABASE MyBlogsDB
GO
CREATE DATABASE MyBlogsDB
ON
(
	NAME='MyBlogsDB',
	FILENAME='D:\学习资料\兴趣班\石小龙 - 个人项目（前端）\MyBlogs_System\DB\MyBlogsDB.mdf'
)
GO


USE MyBlogsDB
-----------------------------------------------------------------【   创建表   】 -----------------------------------------------------------------------------

----【站主信息】
IF OBJECT_ID('PersonageInfo') IS NOT NULL
  DROP TABLE PersonageInfo
GO
CREATE TABLE PersonageInfo
(
	P_LoginName NVARCHAR(16) PRIMARY KEY NOT NULL,  --登录名称
	P_LoginPwd NVARCHAR(16) NOT NULL,				--登录密码
	P_NickName NVARCHAR(16) NOT NULL,				--昵称
	P_Head NVARCHAR(200) NOT NULL,					--头像
	P_Phone NVARCHAR(11) NOT NULL,					--联系电话
	P_MyExplain NVARCHAR(2000),						--我的说明（站主说明）
	P_DataTime NVARCHAR(200)						--创建账号时间
)
GO

----【网站信息表】
IF OBJECT_ID('WebInfo') IS NOT NULL
  DROP TABLE WebInfo
GO
CREATE TABLE WebInfo
(
	Web_No INT IDENTITY(0,1) PRIMARY KEY,			--序号
	Web_Name NVARCHAR(16) NOT NULL,					--网站名称
	Web_Index NVARCHAR(2000) NOT NULL,				--网站主页
	Web_Date DATETIME NOT NULL,						--创建网站日期
)
GO

----【文章表】
IF OBJECT_ID('Article') IS NOT NULL
  DROP TABLE Article
GO
CREATE TABLE Article
(
	A_No INT IDENTITY(0,1) PRIMARY KEY,				--序号
	A_Title NVARCHAR(100) NOT NULL,					--标题
	A_Content NVARCHAR(400) NOT NULL,				--内容
	A_TypeName NVARCHAR(20) NOT NULL,				--文章类型
	A_DateTime NVARCHAR(50) NOT NULL,				--发表时间
	A_Author NVARCHAR(100) NOT NULL					--作者
)
GO

----【评价表】
IF OBJECT_ID('Comment') IS NOT NULL
  DROP TABLE Comment
GO
CREATE TABLE Comment
(
	Com_No INT IDENTITY(0,1) PRIMARY KEY,				--序号
	A_No INT NOT NULL,									--文章序号
	NickName NVARCHAR(16) NOT NULL,						--昵称
	Com_Content NVARCHAR(200) NOT NULL,					--评价内容
	Com_Datetime NVARCHAR(50) NOT NULL,					--评价时间
	Aduit_No INT NOT NULL,								--审核序号
	Com_Cause NVARCHAR(200) 							--失败原因
)
GO

----【回复表】
IF OBJECT_ID('Reply') IS NOT NULL
  DROP TABLE Reply
GO
CREATE TABLE Reply
(
	R_No INT IDENTITY(0,1) PRIMARY KEY,					--序号
	Com_No INT NOT NULL,								--评价序号
	R_Content NVARCHAR(200) NOT NULL,					--回复内容
	R_Datetime NVARCHAR(50) NOT NULL,					--时间
)
GO

----【留言表】
IF OBJECT_ID('MassageBoard') IS NOT NULL
  DROP TABLE MassageBoard
GO
CREATE TABLE MassageBoard
(
	Mb_No INT IDENTITY(0,1) PRIMARY KEY,					--序号
	Mb_NickName NVARCHAR(16) NOT NULL,						--昵称
	Mb_Content NVARCHAR(200) NOT NULL,						--留言内容
	Mb_Datetime NVARCHAR(50) NOT NULL,						--留言时间
	Aduit_No INT NOT NULL,									--审核序号
	Mb_Cause NVARCHAR(200) NOT NULL,						--失败原因
)
GO

----【审核表】
IF OBJECT_ID('Aduit') IS NOT NULL
  DROP TABLE Aduit
GO
CREATE TABLE Aduit
(
	Aduit_No INT IDENTITY(0,1) PRIMARY KEY,					--序号
	Aduit_Name NVARCHAR(50) NOT NULL						--昵称
)
GO

----【信息统计表】
IF OBJECT_ID('InfoCount') IS NOT NULL
  DROP TABLE InfoCount
GO
CREATE TABLE InfoCount
(
	A_No INT ,											--文章序号
	IC_Count NVARCHAR(50) NOT NULL						--浏览量
)
GO


----【类型表】
IF OBJECT_ID('ArticleType') IS NOT NULL
  DROP TABLE ArticleType
GO
CREATE TABLE ArticleType
(
	At_No INT IDENTITY(0,1) PRIMARY KEY,					--序号
	At_Name NVARCHAR(50) NOT NULL							--类型名称
)
GO

----【登录日志】
IF OBJECT_ID('LoginLog') IS NOT NULL
  DROP TABLE LoginLog
GO
CREATE TABLE LoginLog
(
	Log_No INT IDENTITY(0,1) PRIMARY KEY,						--序号
	P_LoginName NVARCHAR(50) NOT NULL,							--登录账号
	Log_ipAddress NVARCHAR(15) NOT NULL,						--登录IP地址
	Log_Country NVARCHAR(15) NOT NULL,							--国家
	Log_Province NVARCHAR(15) NOT NULL,							--省份
	Log_City NVARCHAR(15) NOT NULL,								--城市
	Log_Date NVARCHAR(15) NOT NULL								--时间
)
GO

----【密保问题】
IF OBJECT_ID('Issue') IS NOT NULL
  DROP TABLE Issue
GO
CREATE TABLE Issue
(
	Issue_No INT IDENTITY(0,1) PRIMARY KEY,						--序号
	P_LoginName NVARCHAR(50) NOT NULL,							--账号
	Issue_1 NVARCHAR(200) NOT NULL,								--问题1
	Issue_2 NVARCHAR(200) NOT NULL,								--问题2
	Issue_3 NVARCHAR(200) NOT NULL,								--问题3
	Answer_1 NVARCHAR(200) NOT NULL,							--答案1
	Answer_2 NVARCHAR(200) NOT NULL,							--答案2
	Answer_3 NVARCHAR(200) NOT NULL								--答案3
)
GO


----【问题库】
IF OBJECT_ID('Issue_library') IS NOT NULL
  DROP TABLE Issue_library
GO
CREATE TABLE Issue_library
(
	IssueI_No INT IDENTITY(0,1) PRIMARY KEY,					--序号
	IssueI_Name NVARCHAR(50) NOT NULL							--问题
)
GO


----【邮箱】
IF OBJECT_ID('Email') IS NOT NULL
  DROP TABLE Email
GO
CREATE TABLE Email
(
	Email_No INT IDENTITY(0,1) PRIMARY KEY,						--序号
	P_LoginName NVARCHAR(50) NOT NULL,							--账号
	Email_Name NVARCHAR(200) NOT NULL,							--邮箱信息
	Email_Activate NVARCHAR(200) NOT NULL						--是否激活
	
)
GO



-----------------------------------------------------------------【建立外键关系】 -----------------------------------------------------------------------------

IF EXISTS(SELECT * FROM sys.objects WHERE name='FK_CommentA_No')
   ALTER TABLE Comment
     DROP CONSTRAINT FK_CommentA_No
  GO
  ALTER TABLE Comment
	 ADD CONSTRAINT FK_CommentA_No
		FOREIGN KEY (A_No) REFERENCES Article(A_No)
GO


IF EXISTS(SELECT * FROM sys.objects WHERE name='FK_CommentAduit_No')
   ALTER TABLE Comment
     DROP CONSTRAINT FK_CommentAduit_No
  GO
  ALTER TABLE Comment
	 ADD CONSTRAINT FK_CommentAduit_No
		FOREIGN KEY (Aduit_No) REFERENCES Aduit(Aduit_No)
GO


IF EXISTS(SELECT * FROM sys.objects WHERE name='FK_ReplyCom_No')
   ALTER TABLE Reply
     DROP CONSTRAINT FK_ReplyCom_No
  GO
  ALTER TABLE Reply
	 ADD CONSTRAINT FK_ReplyCom_No
		FOREIGN KEY (Com_No) REFERENCES Comment(Com_No)
GO


IF EXISTS(SELECT * FROM sys.objects WHERE name='FK_MassageBoardAduit_No')
   ALTER TABLE MassageBoard
     DROP CONSTRAINT FK_MassageBoardAduit_No
  GO
  ALTER TABLE MassageBoard
	 ADD CONSTRAINT FK_MassageBoardAduit_No
		FOREIGN KEY (Aduit_No) REFERENCES Aduit(Aduit_No)
GO

IF EXISTS(SELECT * FROM sys.objects WHERE name='FK_InfoCountA_No')
   ALTER TABLE InfoCount
     DROP CONSTRAINT FK_InfoCountA_No
  GO
  ALTER TABLE InfoCount
	 ADD CONSTRAINT FK_InfoCountA_No
		FOREIGN KEY (A_No) REFERENCES Article(A_No)
GO

























