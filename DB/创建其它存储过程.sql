use MyBlogsDB

--��ѯ�����¡����������Ӵ�С
if exists(select * from sys.procedures where name='Select_ArticleAllByDesc')
  drop proc Select_ArticleAllByDesc 
go
 create proc Select_ArticleAllByDesc
 as
 select * from article order by A_No desc
GO

--��ѯ����¼��־�����������Ӵ�С
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_LoginLogByDesc')
	DROP PROC Select_LoginLogByDesc
GO
	create PROC Select_LoginLogByDesc
	@P_LoginName varchar(16)
	AS
	SELECT top(9) * FROM LoginLog where P_LoginName=@P_LoginName order by Log_No desc 
GO

exec Select_LoginLogByDesc 'Anjjie_Blogs888'

--��ѯ�����¡���ҳ��ʾ
go
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_ArticlePaging')
  drop proc Select_ArticlePaging
go
  create proc Select_ArticlePaging
  @PageNo int =1,
  @PageSize int=15 
  as
  select * from (select ROW_NUMBER() over(order by A_No desc)Rid,* from Article) ArticlePaging
  where Rid>=(@PageNo-1)*@PageSize+1 and Rid<=@PageNo*@PageSize
 
 GO
 
 exec Select_ArticlePaging 1
 
 --��ѯ�����¡���ҳ��ʾ:����
go
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_ArticlePagingByConn')
  drop proc Select_ArticlePagingByConn
go
  create proc Select_ArticlePagingByConn
  @Conn varchar(200),
  @PageNo int =1,
  @PageSize int=15 
  as
  select * from (select ROW_NUMBER() over(order by A_No desc)Rid,* from Article where A_TypeName=@Conn ) ArticlePaging
  where Rid>=(@PageNo-1)*@PageSize+1 and Rid<=@PageNo*@PageSize
 
 GO
 
  exec Select_ArticlePagingByConn '����',1
  
   --��ѯ�����¡���ҳ��ʾ:ȫ����ز�ѯ������
go
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_ArticleDescPagingByConn')
  drop proc Select_ArticleDescPagingByConn
go
  create proc Select_ArticleDescPagingByConn
  @Conn varchar(200),
    @PageNo int =1,
  @PageSize int=15 
  as
  select * from (select ROW_NUMBER() over(order by A_No desc)Rid,* from Article where A_Title like @Conn 
   or A_Author like @Conn  
   or A_Content like @Conn  
   or A_TypeName like @Conn  
   or A_DateTime like @Conn  ) ArticlePaging
  where Rid>=(@PageNo-1)*@PageSize+1 and Rid<=@PageNo*@PageSize

 GO
   exec Select_ArticleDescPagingByConn '%��%',1
 
 --��ѯ�����¡���ʾ:ȫ����ز�ѯ������
go
IF EXISTS(SELECT * FROM sys.procedures WHERE name='Select_ArticleDescCorrelationByConn')
  drop proc Select_ArticleDescCorrelationByConn
go
  create proc Select_ArticleDescCorrelationByConn
  @Conn varchar(200)
  as
  select * from Article where A_Title like @Conn 
   or A_Author like @Conn  
   or A_Content like @Conn  
   or A_TypeName like @Conn  
   or A_DateTime like @Conn 

 GO
 Select_ArticleDescCorrelationByConn '%��%'