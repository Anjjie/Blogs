USE MyBlogsDB

------【站主信息】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_PersonageInfo')
  DROP PROC Select_PersonageInfo
 GO
 CREATE PROC Select_PersonageInfo
 AS
 SELECT * FROM PersonageInfo
 
 GO
 
 
 --添加
 IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_PersonageInfo')
  DROP PROC Insert_PersonageInfo
 GO
 CREATE PROC Insert_PersonageInfo
	@P_LoginName NVARCHAR(16) ,				--登录名称
	@P_LoginPwd NVARCHAR(16),				--登录密码
	@P_NickName NVARCHAR(16),				--昵称
	@P_Head NVARCHAR(200),					--头像
	@P_Phone NVARCHAR(11),					--联系电话
	@P_MyExplain NVARCHAR(2000),			--我的说明（站主说明）
	@P_DataTime NVARCHAR(200)				--创建账号时间
	AS
	INSERT INTO PersonageInfo
	values(@P_LoginName,@P_LoginPwd,@P_NickName,@P_Head,@P_Phone,@P_MyExplain,@P_DataTime)
	
	
GO
 --修改
  IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_PersonageInfo')
  DROP PROC Update_PersonageInfo
 GO
 CREATE PROC Update_PersonageInfo
	@P_LoginName NVARCHAR(16) ,				--登录名称
	@P_LoginPwd NVARCHAR(16),				--登录密码
	@P_NickName NVARCHAR(16),				--昵称
	@P_Head NVARCHAR(200),					--头像
	@P_Phone NVARCHAR(11),					--联系电话
	@P_MyExplain NVARCHAR(2000),			--我的说明（站主说明）
	@P_DataTime NVARCHAR(200)				--创建账号时间
	AS
	UPDATE PersonageInfo SET P_LoginPwd=@P_LoginPwd,P_NickName=@P_NickName,P_Head=@P_Head,P_Phone=@P_Phone,P_MyExplain=@P_MyExplain,P_DataTime=@P_DataTime
	WHERE P_LoginName=@P_LoginName
	
 GO	
 --删除
  IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_PersonageInfo')
  DROP PROC Delete_PersonageInfo
 GO
 CREATE PROC Delete_PersonageInfo
	@P_LoginName NVARCHAR(16) 				--登录名称
	AS
	DELETE FROM PersonageInfo WHERE P_LoginName=@P_LoginName
GO


------【网站信息表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_WebInfo')
	DROP PROC Select_WebInfo
GO
	CREATE PROC Select_WebInfo
	AS
	SELECT * FROM WebInfo
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_WebInfo')
	DROP PROC Insert_WebInfo
GO
	CREATE PROC Insert_WebInfo
	@Web_Name NVARCHAR(16),				--网站名称
	@Web_Index NVARCHAR(2000) ,			--网站主页
	@Web_Date DATETIME 					--创建网站日期
	AS
	Insert Into WebInfo
	VALUES(@Web_Name,@Web_Index,@Web_Date)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_WebInfo')
	DROP PROC Update_WebInfo
GO
	CREATE PROC Update_WebInfo
	@Web_No INT ,						--序号
	@Web_Name NVARCHAR(16),				--网站名称
	@Web_Index NVARCHAR(2000) ,			--网站主页
	@Web_Date DATETIME 					--创建网站日期
	AS
	Update WebInfo Set Web_Name=@Web_Name,Web_Index=@Web_Index,Web_Date=@Web_Date WHERE Web_No=@Web_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_WebInfo')
	DROP PROC Delete_WebInfo
GO
	CREATE PROC Delete_WebInfo
	@Web_No INT 						--序号
	AS
	delete  FROM WebInfo WHERE Web_No=@Web_No
GO



------【文章表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Article')
	DROP PROC Select_Article
GO
	CREATE PROC Select_Article
	AS
	SELECT * FROM Article
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Article')
	DROP PROC Insert_Article
GO
	CREATE PROC Insert_Article
	@A_Title NVARCHAR(100),					--标题
	@A_Content NVARCHAR(400),				--内容
	@A_TypeName NVARCHAR(20),				--文章类型
	@A_DateTime NVARCHAR(50),				--发表时间
	@A_Author NVARCHAR(100)					--作者
	AS
	Insert Into Article
	VALUES(@A_Title,@A_Content,@A_TypeName,@A_DateTime,@A_Author)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Article')
	DROP PROC Update_Article
GO
	CREATE PROC Update_Article
	@A_No INT ,						--序号
	@A_Title NVARCHAR(100),					--标题
	@A_Content NVARCHAR(400),				--内容
	@A_TypeName NVARCHAR(20),				--文章类型
	@A_DateTime NVARCHAR(50),				--发表时间
	@A_Author NVARCHAR(100)					--作者
	AS
	Update Article Set A_Title=@A_Title,A_Content=@A_Content,A_TypeName=@A_TypeName,A_DateTime=@A_DateTime,A_Author=@A_Author WHERE A_No=@A_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Article')
	DROP PROC Delete_Article
GO
	CREATE PROC Delete_Article
	@A_No INT 						--序号
	AS
	delete  FROM Article WHERE A_No=@A_No
GO



------【评价表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Comment')
	DROP PROC Select_Comment
GO
	CREATE PROC Select_Comment
	AS
	SELECT * FROM Comment
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Comment')
	DROP PROC Insert_Comment
GO
	CREATE PROC Insert_Comment
	@A_No INT,									--文章序号
	@NickName NVARCHAR(16),						--昵称
	@Com_Content NVARCHAR(200),					--评价内容
	@Com_Datetime NVARCHAR(50) ,				--评价时间
	@Aduit_No INT,								--审核序号
	@Com_Cause NVARCHAR(200) 					--失败原因
	AS
	Insert Into Comment
	VALUES(@A_No,@NickName,@Com_Content,@Com_Datetime,@Aduit_No,@Com_Cause)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Comment')
	DROP PROC Update_Comment
GO
	CREATE PROC Update_Comment
	@Com_No INT ,								--序号
	@A_No INT,									--文章序号
	@NickName NVARCHAR(16),						--昵称
	@Com_Content NVARCHAR(200),					--评价内容
	@Com_Datetime NVARCHAR(50) ,				--评价时间
	@Aduit_No INT,								--审核序号
	@Com_Cause NVARCHAR(200) 					--失败原因
	AS
	Update Comment Set A_No=@A_No,NickName=@NickName,Com_Content=@Com_Content,Com_Datetime=@Com_Datetime,Aduit_No=@Aduit_No,Com_Cause=@Com_Cause WHERE Com_No=@Com_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Comment')
	DROP PROC Delete_Comment
GO
	CREATE PROC Delete_Comment
	@Com_No INT 						--序号
	AS
	delete  FROM Comment WHERE Com_No=@Com_No
GO




------【回复表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Reply')
	DROP PROC Select_Reply
GO
	CREATE PROC Select_Reply
	AS
	SELECT * FROM Reply
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Reply')
	DROP PROC Insert_Reply
GO
	CREATE PROC Insert_Reply
	@Com_No INT ,								--评价序号
	@R_Content NVARCHAR(200) ,					--回复内容
	@R_Datetime NVARCHAR(50) 					--时间
	AS
	Insert Into Reply
	VALUES(@Com_No,@R_Content,@R_Datetime)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Reply')
	DROP PROC Update_Reply
GO
	CREATE PROC Update_Reply
	@R_No INT ,									--序号
	@Com_No INT ,								--评价序号
	@R_Content NVARCHAR(200) ,					--回复内容
	@R_Datetime NVARCHAR(50) 					--时间
	AS
	Update Reply Set Com_No=@Com_No,R_Content=@R_Content,R_Datetime=@R_Datetime WHERE R_No=@R_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Reply')
	DROP PROC Delete_Reply
GO
	CREATE PROC Delete_Reply
	@R_No INT 						--序号
	AS
	delete  FROM Reply WHERE R_No=@R_No
GO


------【留言表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_MassageBoard')
	DROP PROC Select_MassageBoard
GO
	CREATE PROC Select_MassageBoard
	AS
	SELECT * FROM MassageBoard
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_MassageBoard')
	DROP PROC Insert_MassageBoard
GO
	CREATE PROC Insert_MassageBoard
	@Mb_NickName NVARCHAR(16),				--昵称
	@Mb_Content NVARCHAR(200),				--留言内容
	@Mb_Datetime NVARCHAR(50),				--留言时间
	@Aduit_No INT ,							--审核序号
	@Mb_Cause NVARCHAR(200) 				--失败原因
	AS
	Insert Into MassageBoard
	VALUES(@Mb_NickName,@Mb_Content,@Mb_Datetime,@Aduit_No,@Mb_Cause)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_MassageBoard')
	DROP PROC Update_MassageBoard
GO
	CREATE PROC Update_MassageBoard
	@Mb_No INT ,							--序号
	@Mb_NickName NVARCHAR(16),				--昵称
	@Mb_Content NVARCHAR(200),				--留言内容
	@Mb_Datetime NVARCHAR(50),				--留言时间
	@Aduit_No INT ,							--审核序号
	@Mb_Cause NVARCHAR(200) 				--失败原因
	AS
	Update MassageBoard Set Mb_NickName=@Mb_NickName,Mb_Content=@Mb_Content,Mb_Datetime=@Mb_Datetime,Aduit_No=@Aduit_No,Mb_Cause=@Mb_Cause WHERE Mb_No=@Mb_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_MassageBoard')
	DROP PROC Delete_MassageBoard
GO
	CREATE PROC Delete_MassageBoard
	@Mb_No INT 						--序号
	AS
	delete  FROM MassageBoard WHERE Mb_No=@Mb_No
GO



------【审核表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_Aduit')
	DROP PROC Select_Aduit
GO
	CREATE PROC Select_Aduit
	AS
	SELECT * FROM Aduit
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_Aduit')
	DROP PROC Insert_Aduit
GO
	CREATE PROC Insert_Aduit
	@Aduit_Name NVARCHAR(50) 						--昵称
	AS
	Insert Into Aduit
	VALUES(@Aduit_Name)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_Aduit')
	DROP PROC Update_Aduit
GO
	CREATE PROC Update_Aduit
	@Aduit_No INT ,					--序号
	@Aduit_Name NVARCHAR(50) 						--昵称
	AS
	Update Aduit Set Aduit_Name=@Aduit_Name WHERE Aduit_No=@Aduit_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_Aduit')
	DROP PROC Delete_Aduit
GO
	CREATE PROC Delete_Aduit
	@Aduit_No INT 						--序号
	AS
	delete  FROM Aduit WHERE Aduit_No=@Aduit_No
GO


------【信息统计表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_InfoCount')
	DROP PROC Select_InfoCount
GO
	CREATE PROC Select_InfoCount
	AS
	SELECT * FROM InfoCount
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_InfoCount')
	DROP PROC Insert_InfoCount
GO
	CREATE PROC Insert_InfoCount
	@A_No INT ,					--文章序号
	@IC_Count NVARCHAR(50) 						--浏览量
	AS
	Insert Into InfoCount
	VALUES(@A_No,@IC_Count)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_InfoCount')
	DROP PROC Update_InfoCount
GO
	CREATE PROC Update_InfoCount
	@A_No INT ,					--文章序号
	@IC_Count NVARCHAR(50) 						--浏览量
	AS
	Update InfoCount Set IC_Count=@IC_Count WHERE A_No=@A_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_IC_Count')
	DROP PROC Delete_IC_Count
GO
	CREATE PROC Delete_IC_Count
	@A_No INT 						--序号
	AS
	delete  FROM IC_Count WHERE A_No=@A_No
GO



------【类型表】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_ArticleType')
	DROP PROC Select_ArticleType
GO
	CREATE PROC Select_ArticleType
	AS
	SELECT * FROM ArticleType
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_ArticleType')
	DROP PROC Insert_ArticleType
GO
	CREATE PROC Insert_ArticleType
	@At_Name NVARCHAR(50)							--类型名称
	AS
	Insert Into ArticleType
	VALUES(@At_Name)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_ArticleType')
	DROP PROC Update_ArticleType
GO
	CREATE PROC Update_ArticleType
	@At_No INT  ,					--文章序号
	@At_Name NVARCHAR(50)							--类型名称
	AS
	Update ArticleType Set At_Name=@At_Name WHERE At_No=@At_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_ArticleType')
	DROP PROC Delete_ArticleType
GO
	CREATE PROC Delete_ArticleType
	@At_No INT 						--序号
	AS
	delete  FROM ArticleType  WHERE At_No=@At_No
GO


------【登录日志】存储过程----------------------------------------------------------------------------------

--查询
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_LoginLog')
	DROP PROC Select_LoginLog
GO
	CREATE PROC Select_LoginLog
	AS
	SELECT * FROM LoginLog
GO

--添加
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Insert_LoginLog')
	DROP PROC Insert_LoginLog
GO
	CREATE PROC Insert_LoginLog
	@P_LoginName NVARCHAR(50),							--登录账号
	@Log_ipAddress NVARCHAR(15),						--登录IP地址
	@Log_Country NVARCHAR(15) ,							--国家
	@Log_Province NVARCHAR(15),							--省份
	@Log_City NVARCHAR(15),								--城市
	@Log_Date NVARCHAR(15)								--时间
	AS
	Insert Into LoginLog
	VALUES(@P_LoginName,@Log_ipAddress,@Log_Country,@Log_Province,@Log_City,@Log_Date)
GO

--修改
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Update_LoginLog')
	DROP PROC Update_LoginLog
GO
	CREATE PROC Update_LoginLog
	@Log_No INT,						--序号
	@P_LoginName NVARCHAR(50),							--登录账号
	@Log_ipAddress NVARCHAR(15),						--登录IP地址
	@Log_Country NVARCHAR(15) ,							--国家
	@Log_Province NVARCHAR(15),							--省份
	@Log_City NVARCHAR(15),								--城市
	@Log_Date NVARCHAR(15)								--时间
	AS
	Update LoginLog Set P_LoginName=@P_LoginName,Log_ipAddress=@Log_ipAddress,Log_Country=@Log_Country,Log_Province=@Log_Province,Log_City=@Log_City,
	Log_Date=@Log_Date WHERE Log_No=@Log_No
GO

--删除
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_LoginLog')
	DROP PROC Delete_LoginLog
GO
	CREATE PROC Delete_LoginLog
	@Log_No INT 						--序号
	AS
	delete  FROM LoginLog  WHERE Log_No=@Log_No
GO






	
	