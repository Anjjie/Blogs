use MyBlogsDB

--查询【文章】按序号排序从大到小
if exists(select * from sys.procedures where name='Select_ArticleAllByDesc')
  drop proc Select_ArticleAllByDesc 
go
 create proc Select_ArticleAllByDesc
 as
 select * from article order by A_No desc
 
--查询【登录日志】按序号排序从大到小
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_LoginLogByDesc')
	DROP PROC Select_LoginLogByDesc
GO
	CREATE PROC Select_LoginLogByDesc
	@P_LoginName varchar(16)
	AS
	SELECT top(9) * FROM LoginLog where P_LoginName=@P_LoginName order by Log_No desc 
GO