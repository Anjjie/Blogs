USE MyBlogsDB

------��վ����Ϣ���洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_PersonageInfo')
  DROP PROC Select_PersonageInfo
 GO
 CREATE PROC Select_PersonageInfo
 AS
 SELECT * FROM PersonageInfo
 
 GO
 
 
 --���
 IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_PersonageInfo')
  DROP PROC Insert_PersonageInfo
 GO
 CREATE PROC Insert_PersonageInfo
	@P_LoginName NVARCHAR(16) ,				--��¼����
	@P_LoginPwd NVARCHAR(16),				--��¼����
	@P_NickName NVARCHAR(16),				--�ǳ�
	@P_Head NVARCHAR(200),					--ͷ��
	@P_Phone NVARCHAR(11),					--��ϵ�绰
	@P_MyExplain NVARCHAR(2000),			--�ҵ�˵����վ��˵����
	@P_DataTime NVARCHAR(200)				--�����˺�ʱ��
	AS
	INSERT INTO PersonageInfo
	values(@P_LoginName,@P_LoginPwd,@P_NickName,@P_Head,@P_Phone,@P_MyExplain,@P_DataTime)
	
	
GO
 --�޸�
  IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_PersonageInfo')
  DROP PROC Update_PersonageInfo
 GO
 CREATE PROC Update_PersonageInfo
	@P_LoginName NVARCHAR(16) ,				--��¼����
	@P_LoginPwd NVARCHAR(16),				--��¼����
	@P_NickName NVARCHAR(16),				--�ǳ�
	@P_Head NVARCHAR(200),					--ͷ��
	@P_Phone NVARCHAR(11),					--��ϵ�绰
	@P_MyExplain NVARCHAR(2000),			--�ҵ�˵����վ��˵����
	@P_DataTime NVARCHAR(200)				--�����˺�ʱ��
	AS
	UPDATE PersonageInfo SET P_LoginPwd=@P_LoginPwd,P_NickName=@P_NickName,P_Head=@P_Head,P_Phone=@P_Phone,P_MyExplain=@P_MyExplain,P_DataTime=@P_DataTime
	WHERE P_LoginName=@P_LoginName
	
 GO	
 --ɾ��
  IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_PersonageInfo')
  DROP PROC Delete_PersonageInfo
 GO
 CREATE PROC Delete_PersonageInfo
	@P_LoginName NVARCHAR(16) 				--��¼����
	AS
	DELETE FROM PersonageInfo WHERE P_LoginName=@P_LoginName
GO


------����վ��Ϣ���洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_WebInfo')
	DROP PROC Select_WebInfo
GO
	CREATE PROC Select_WebInfo
	AS
	SELECT * FROM WebInfo
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_WebInfo')
	DROP PROC Insert_WebInfo
GO
	CREATE PROC Insert_WebInfo
	@Web_Name NVARCHAR(16),				--��վ����
	@Web_Index NVARCHAR(2000) ,			--��վ��ҳ
	@Web_Date DATETIME 					--������վ����
	AS
	Insert Into WebInfo
	VALUES(@Web_Name,@Web_Index,@Web_Date)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_WebInfo')
	DROP PROC Update_WebInfo
GO
	CREATE PROC Update_WebInfo
	@Web_No INT ,						--���
	@Web_Name NVARCHAR(16),				--��վ����
	@Web_Index NVARCHAR(2000) ,			--��վ��ҳ
	@Web_Date DATETIME 					--������վ����
	AS
	Update WebInfo Set Web_Name=@Web_Name,Web_Index=@Web_Index,Web_Date=@Web_Date WHERE Web_No=@Web_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_WebInfo')
	DROP PROC Delete_WebInfo
GO
	CREATE PROC Delete_WebInfo
	@Web_No INT 						--���
	AS
	delete  FROM WebInfo WHERE Web_No=@Web_No
GO



------�����±��洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Article')
	DROP PROC Select_Article
GO
	CREATE PROC Select_Article
	AS
	SELECT * FROM Article
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Article')
	DROP PROC Insert_Article
GO
	CREATE PROC Insert_Article
	@A_Title NVARCHAR(100),					--����
	@A_Content NVARCHAR(400),				--����
	@A_TypeName NVARCHAR(20),				--��������
	@A_DateTime NVARCHAR(50),				--����ʱ��
	@A_Author NVARCHAR(100)					--����
	AS
	Insert Into Article
	VALUES(@A_Title,@A_Content,@A_TypeName,@A_DateTime,@A_Author)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Article')
	DROP PROC Update_Article
GO
	CREATE PROC Update_Article
	@A_No INT ,						--���
	@A_Title NVARCHAR(100),					--����
	@A_Content NVARCHAR(400),				--����
	@A_TypeName NVARCHAR(20),				--��������
	@A_DateTime NVARCHAR(50),				--����ʱ��
	@A_Author NVARCHAR(100)					--����
	AS
	Update Article Set A_Title=@A_Title,A_Content=@A_Content,A_TypeName=@A_TypeName,A_DateTime=@A_DateTime,A_Author=@A_Author WHERE A_No=@A_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Article')
	DROP PROC Delete_Article
GO
	CREATE PROC Delete_Article
	@A_No INT 						--���
	AS
	delete  FROM Article WHERE A_No=@A_No
GO



------�����۱��洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Comment')
	DROP PROC Select_Comment
GO
	CREATE PROC Select_Comment
	AS
	SELECT * FROM Comment
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Comment')
	DROP PROC Insert_Comment
GO
	CREATE PROC Insert_Comment
	@A_No INT,									--�������
	@NickName NVARCHAR(16),						--�ǳ�
	@Com_Content NVARCHAR(200),					--��������
	@Com_Datetime NVARCHAR(50) ,				--����ʱ��
	@Aduit_No INT,								--������
	@Com_Cause NVARCHAR(200) 					--ʧ��ԭ��
	AS
	Insert Into Comment
	VALUES(@A_No,@NickName,@Com_Content,@Com_Datetime,@Aduit_No,@Com_Cause)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Comment')
	DROP PROC Update_Comment
GO
	CREATE PROC Update_Comment
	@Com_No INT ,								--���
	@A_No INT,									--�������
	@NickName NVARCHAR(16),						--�ǳ�
	@Com_Content NVARCHAR(200),					--��������
	@Com_Datetime NVARCHAR(50) ,				--����ʱ��
	@Aduit_No INT,								--������
	@Com_Cause NVARCHAR(200) 					--ʧ��ԭ��
	AS
	Update Comment Set A_No=@A_No,NickName=@NickName,Com_Content=@Com_Content,Com_Datetime=@Com_Datetime,Aduit_No=@Aduit_No,Com_Cause=@Com_Cause WHERE Com_No=@Com_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Comment')
	DROP PROC Delete_Comment
GO
	CREATE PROC Delete_Comment
	@Com_No INT 						--���
	AS
	delete  FROM Comment WHERE Com_No=@Com_No
GO




------���ظ����洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Reply')
	DROP PROC Select_Reply
GO
	CREATE PROC Select_Reply
	AS
	SELECT * FROM Reply
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Reply')
	DROP PROC Insert_Reply
GO
	CREATE PROC Insert_Reply
	@Com_No INT ,								--�������
	@R_Content NVARCHAR(200) ,					--�ظ�����
	@R_Datetime NVARCHAR(50) 					--ʱ��
	AS
	Insert Into Reply
	VALUES(@Com_No,@R_Content,@R_Datetime)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Reply')
	DROP PROC Update_Reply
GO
	CREATE PROC Update_Reply
	@R_No INT ,									--���
	@Com_No INT ,								--�������
	@R_Content NVARCHAR(200) ,					--�ظ�����
	@R_Datetime NVARCHAR(50) 					--ʱ��
	AS
	Update Reply Set Com_No=@Com_No,R_Content=@R_Content,R_Datetime=@R_Datetime WHERE R_No=@R_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Reply')
	DROP PROC Delete_Reply
GO
	CREATE PROC Delete_Reply
	@R_No INT 						--���
	AS
	delete  FROM Reply WHERE R_No=@R_No
GO


------�����Ա��洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_MassageBoard')
	DROP PROC Select_MassageBoard
GO
	CREATE PROC Select_MassageBoard
	AS
	SELECT * FROM MassageBoard
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_MassageBoard')
	DROP PROC Insert_MassageBoard
GO
	CREATE PROC Insert_MassageBoard
	@Mb_NickName NVARCHAR(16),				--�ǳ�
	@Mb_Content NVARCHAR(200),				--��������
	@Mb_Datetime NVARCHAR(50),				--����ʱ��
	@Aduit_No INT ,							--������
	@Mb_Cause NVARCHAR(200) 				--ʧ��ԭ��
	AS
	Insert Into MassageBoard
	VALUES(@Mb_NickName,@Mb_Content,@Mb_Datetime,@Aduit_No,@Mb_Cause)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_MassageBoard')
	DROP PROC Update_MassageBoard
GO
	CREATE PROC Update_MassageBoard
	@Mb_No INT ,							--���
	@Mb_NickName NVARCHAR(16),				--�ǳ�
	@Mb_Content NVARCHAR(200),				--��������
	@Mb_Datetime NVARCHAR(50),				--����ʱ��
	@Aduit_No INT ,							--������
	@Mb_Cause NVARCHAR(200) 				--ʧ��ԭ��
	AS
	Update MassageBoard Set Mb_NickName=@Mb_NickName,Mb_Content=@Mb_Content,Mb_Datetime=@Mb_Datetime,Aduit_No=@Aduit_No,Mb_Cause=@Mb_Cause WHERE Mb_No=@Mb_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_MassageBoard')
	DROP PROC Delete_MassageBoard
GO
	CREATE PROC Delete_MassageBoard
	@Mb_No INT 						--���
	AS
	delete  FROM MassageBoard WHERE Mb_No=@Mb_No
GO



------����˱��洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Aduit')
	DROP PROC Select_Aduit
GO
	CREATE PROC Select_Aduit
	AS
	SELECT * FROM Aduit
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Aduit')
	DROP PROC Insert_Aduit
GO
	CREATE PROC Insert_Aduit
	@Aduit_Name NVARCHAR(50) 						--�ǳ�
	AS
	Insert Into Aduit
	VALUES(@Aduit_Name)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Aduit')
	DROP PROC Update_Aduit
GO
	CREATE PROC Update_Aduit
	@Aduit_No INT ,					--���
	@Aduit_Name NVARCHAR(50) 						--�ǳ�
	AS
	Update Aduit Set Aduit_Name=@Aduit_Name WHERE Aduit_No=@Aduit_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Aduit')
	DROP PROC Delete_Aduit
GO
	CREATE PROC Delete_Aduit
	@Aduit_No INT 						--���
	AS
	delete  FROM Aduit WHERE Aduit_No=@Aduit_No
GO


------����Ϣͳ�Ʊ��洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_InfoCount')
	DROP PROC Select_InfoCount
GO
	CREATE PROC Select_InfoCount
	AS
	SELECT * FROM InfoCount
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_InfoCount')
	DROP PROC Insert_InfoCount
GO
	CREATE PROC Insert_InfoCount
	@A_No INT ,					--�������
	@IC_Count NVARCHAR(50) 						--�����
	AS
	Insert Into InfoCount
	VALUES(@A_No,@IC_Count)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_InfoCount')
	DROP PROC Update_InfoCount
GO
	CREATE PROC Update_InfoCount
	@A_No INT ,					--�������
	@IC_Count NVARCHAR(50) 						--�����
	AS
	Update InfoCount Set IC_Count=@IC_Count WHERE A_No=@A_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_IC_Count')
	DROP PROC Delete_IC_Count
GO
	CREATE PROC Delete_IC_Count
	@A_No INT 						--���
	AS
	delete  FROM IC_Count WHERE A_No=@A_No
GO



------�����ͱ��洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_ArticleType')
	DROP PROC Select_ArticleType
GO
	CREATE PROC Select_ArticleType
	AS
	SELECT * FROM ArticleType
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_ArticleType')
	DROP PROC Insert_ArticleType
GO
	CREATE PROC Insert_ArticleType
	@At_Name NVARCHAR(50)							--��������
	AS
	Insert Into ArticleType
	VALUES(@At_Name)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_ArticleType')
	DROP PROC Update_ArticleType
GO
	CREATE PROC Update_ArticleType
	@At_No INT  ,					--�������
	@At_Name NVARCHAR(50)							--��������
	AS
	Update ArticleType Set At_Name=@At_Name WHERE At_No=@At_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_ArticleType')
	DROP PROC Delete_ArticleType
GO
	CREATE PROC Delete_ArticleType
	@At_No INT 						--���
	AS
	delete  FROM ArticleType  WHERE At_No=@At_No
GO


------����¼��־���洢����----------------------------------------------------------------------------------

--��ѯ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_LoginLog')
	DROP PROC Select_LoginLog
GO
	CREATE PROC Select_LoginLog
	AS
	SELECT * FROM LoginLog
GO

--���
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_LoginLog')
	DROP PROC Insert_LoginLog
GO
	CREATE PROC Insert_LoginLog
	@P_LoginName NVARCHAR(50),							--��¼�˺�
	@Log_ipAddress NVARCHAR(15),						--��¼IP��ַ
	@Log_Country NVARCHAR(15) ,							--����
	@Log_Province NVARCHAR(15),							--ʡ��
	@Log_City NVARCHAR(15),								--����
	@Log_Date NVARCHAR(15)								--ʱ��
	AS
	Insert Into LoginLog
	VALUES(@P_LoginName,@Log_ipAddress,@Log_Country,@Log_Province,@Log_City,@Log_Date)
GO

--�޸�
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_LoginLog')
	DROP PROC Update_LoginLog
GO
	CREATE PROC Update_LoginLog
	@Log_No INT,						--���
	@P_LoginName NVARCHAR(50),							--��¼�˺�
	@Log_ipAddress NVARCHAR(15),						--��¼IP��ַ
	@Log_Country NVARCHAR(15) ,							--����
	@Log_Province NVARCHAR(15),							--ʡ��
	@Log_City NVARCHAR(15),								--����
	@Log_Date NVARCHAR(15)								--ʱ��
	AS
	Update LoginLog Set P_LoginName=@P_LoginName,Log_ipAddress=@Log_ipAddress,Log_Country=@Log_Country,Log_Province=@Log_Province,Log_City=@Log_City,
	Log_Date=@Log_Date WHERE Log_No=@Log_No
GO

--ɾ��
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_LoginLog')
	DROP PROC Delete_LoginLog
GO
	CREATE PROC Delete_LoginLog
	@Log_No INT 						--���
	AS
	delete  FROM LoginLog  WHERE Log_No=@Log_No
GO






	
	