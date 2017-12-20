use MyBlogsDB

--��ѯ�����¡����������Ӵ�С
if exists(select * from sys.procedures where name='Select_ArticleAllByDesc')
  drop proc Select_ArticleAllByDesc 
go
 create proc Select_ArticleAllByDesc
 as
 select * from article order by A_No desc
 
--��ѯ����¼��־�����������Ӵ�С
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_LoginLogByDesc')
	DROP PROC Select_LoginLogByDesc
GO
	CREATE PROC Select_LoginLogByDesc
	@P_LoginName varchar(16)
	AS
	SELECT top(9) * FROM LoginLog where P_LoginName=@P_LoginName order by Log_No desc 
GO

--ɾ�������¡�������Ϣ
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Delete_ArticleMore')
  DROP PROC Delete_ArticleMore
GO
 CREATE PROC Delete_ArticleMore
 @MoreNo varchar(1000) 
 as
 Delete from Article where A_No in (@MoreNo)
 
 
 Delete from Article where A_No in (69,81)
 
 exec Delete_ArticleMore '86'
 select * from Article