USE master
GO
IF DB_ID('MyBlogsDB') IS NOT NULL
  DROP DATABASE MyBlogsDB
GO
CREATE DATABASE MyBlogsDB
ON
(
	NAME='MyBlogsDB',
	FILENAME='D:\ѧϰ����\��Ȥ��\ʯС�� - ������Ŀ��ǰ�ˣ�\MyBlogs_System\DB\MyBlogsDB.mdf'
)
GO


USE MyBlogsDB
-----------------------------------------------------------------��   ������   �� -----------------------------------------------------------------------------

----��վ����Ϣ��
IF OBJECT_ID('PersonageInfo') IS NOT NULL
  DROP TABLE PersonageInfo
GO
CREATE TABLE PersonageInfo
(
	P_LoginName NVARCHAR(16) PRIMARY KEY NOT NULL,  --��¼����
	P_LoginPwd NVARCHAR(16) NOT NULL,				--��¼����
	P_NickName NVARCHAR(16) NOT NULL,				--�ǳ�
	P_Head NVARCHAR(200) NOT NULL,					--ͷ��
	P_Phone NVARCHAR(11) NOT NULL,					--��ϵ�绰
	P_MyExplain NVARCHAR(2000),						--�ҵ�˵����վ��˵����
	P_DataTime NVARCHAR(200)						--�����˺�ʱ��
)
GO

----����վ��Ϣ��
IF OBJECT_ID('WebInfo') IS NOT NULL
  DROP TABLE WebInfo
GO
CREATE TABLE WebInfo
(
	Web_No INT IDENTITY(0,1) PRIMARY KEY,			--���
	Web_Name NVARCHAR(16) NOT NULL,					--��վ����
	Web_Index NVARCHAR(2000) NOT NULL,				--��վ��ҳ
	Web_Date DATETIME NOT NULL,						--������վ����
)
GO

----�����±�
IF OBJECT_ID('Article') IS NOT NULL
  DROP TABLE Article
GO
CREATE TABLE Article
(
	A_No INT IDENTITY(0,1) PRIMARY KEY,				--���
	A_Title NVARCHAR(100) NOT NULL,					--����
	A_Content NVARCHAR(400) NOT NULL,				--����
	A_TypeName NVARCHAR(20) NOT NULL,				--��������
	A_DateTime NVARCHAR(50) NOT NULL,				--����ʱ��
	A_Author NVARCHAR(100) NOT NULL					--����
)
GO

----�����۱�
IF OBJECT_ID('Comment') IS NOT NULL
  DROP TABLE Comment
GO
CREATE TABLE Comment
(
	Com_No INT IDENTITY(0,1) PRIMARY KEY,				--���
	A_No INT NOT NULL,									--�������
	NickName NVARCHAR(16) NOT NULL,						--�ǳ�
	Com_Content NVARCHAR(200) NOT NULL,					--��������
	Com_Datetime NVARCHAR(50) NOT NULL,					--����ʱ��
	Aduit_No INT NOT NULL,								--������
	Com_Cause NVARCHAR(200) 							--ʧ��ԭ��
)
GO

----���ظ���
IF OBJECT_ID('Reply') IS NOT NULL
  DROP TABLE Reply
GO
CREATE TABLE Reply
(
	R_No INT IDENTITY(0,1) PRIMARY KEY,					--���
	Com_No INT NOT NULL,								--�������
	R_Content NVARCHAR(200) NOT NULL,					--�ظ�����
	R_Datetime NVARCHAR(50) NOT NULL,					--ʱ��
)
GO

----�����Ա�
IF OBJECT_ID('MassageBoard') IS NOT NULL
  DROP TABLE MassageBoard
GO
CREATE TABLE MassageBoard
(
	Mb_No INT IDENTITY(0,1) PRIMARY KEY,					--���
	Mb_NickName NVARCHAR(16) NOT NULL,						--�ǳ�
	Mb_Content NVARCHAR(200) NOT NULL,						--��������
	Mb_Datetime NVARCHAR(50) NOT NULL,						--����ʱ��
	Aduit_No INT NOT NULL,									--������
	Mb_Cause NVARCHAR(200) NOT NULL,						--ʧ��ԭ��
)
GO

----����˱�
IF OBJECT_ID('Aduit') IS NOT NULL
  DROP TABLE Aduit
GO
CREATE TABLE Aduit
(
	Aduit_No INT IDENTITY(0,1) PRIMARY KEY,					--���
	Aduit_Name NVARCHAR(50) NOT NULL						--�ǳ�
)
GO

----����Ϣͳ�Ʊ�
IF OBJECT_ID('InfoCount') IS NOT NULL
  DROP TABLE InfoCount
GO
CREATE TABLE InfoCount
(
	A_No INT ,											--�������
	IC_Count NVARCHAR(50) NOT NULL						--�����
)
GO


----�����ͱ�
IF OBJECT_ID('ArticleType') IS NOT NULL
  DROP TABLE ArticleType
GO
CREATE TABLE ArticleType
(
	At_No INT IDENTITY(0,1) PRIMARY KEY,					--���
	At_Name NVARCHAR(50) NOT NULL							--��������
)
GO

----����¼��־��
IF OBJECT_ID('LoginLog') IS NOT NULL
  DROP TABLE LoginLog
GO
CREATE TABLE LoginLog
(
	Log_No INT IDENTITY(0,1) PRIMARY KEY,						--���
	P_LoginName NVARCHAR(50) NOT NULL,							--��¼�˺�
	Log_ipAddress NVARCHAR(15) NOT NULL,						--��¼IP��ַ
	Log_Country NVARCHAR(15) NOT NULL,							--����
	Log_Province NVARCHAR(15) NOT NULL,							--ʡ��
	Log_City NVARCHAR(15) NOT NULL,								--����
	Log_Date NVARCHAR(15) NOT NULL								--ʱ��
)
GO

----���ܱ����⡿
IF OBJECT_ID('Issue') IS NOT NULL
  DROP TABLE Issue
GO
CREATE TABLE Issue
(
	Issue_No INT IDENTITY(0,1) PRIMARY KEY,						--���
	P_LoginName NVARCHAR(50) NOT NULL,							--�˺�
	Issue_1 NVARCHAR(200) NOT NULL,								--����1
	Issue_2 NVARCHAR(200) NOT NULL,								--����2
	Issue_3 NVARCHAR(200) NOT NULL,								--����3
	Answer_1 NVARCHAR(200) NOT NULL,							--��1
	Answer_2 NVARCHAR(200) NOT NULL,							--��2
	Answer_3 NVARCHAR(200) NOT NULL								--��3
)
GO


----������⡿
IF OBJECT_ID('Issue_library') IS NOT NULL
  DROP TABLE Issue_library
GO
CREATE TABLE Issue_library
(
	IssueI_No INT IDENTITY(0,1) PRIMARY KEY,					--���
	IssueI_Name NVARCHAR(50) NOT NULL							--����
)
GO


----�����䡿
IF OBJECT_ID('Email') IS NOT NULL
  DROP TABLE Email
GO
CREATE TABLE Email
(
	Email_No INT IDENTITY(0,1) PRIMARY KEY,						--���
	P_LoginName NVARCHAR(50) NOT NULL,							--�˺�
	Email_Name NVARCHAR(200) NOT NULL,							--������Ϣ
	Email_Activate NVARCHAR(200) NOT NULL						--�Ƿ񼤻�
	
)
GO



-----------------------------------------------------------------�����������ϵ�� -----------------------------------------------------------------------------

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

























