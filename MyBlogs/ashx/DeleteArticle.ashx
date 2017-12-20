<%@ WebHandler Language="C#" Class="DeleteArticle" %>

using System;
using System.Web;
using BLL;
using Models;

public class DeleteArticle : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string no = context.Request["no"];
        int commType =Convert.ToInt32( context.Request["commtype"]);
        int n = 0;
        string hint = "删除成功!";
        switch (commType)
        {
            case 0:
                Article obj = new Article()
                {
                    A_No = Convert.ToInt32(no)
                };
                n = Article_Manager.DeleteArticle(obj);
                if (n > 0)
                {
                    hint = "删除成功！";
                }
                else
                {
                    hint = "删除操作执行失败，请检查相关数据或者联系管理员！";
                }
                break;
            case 1:
                n = Article_Manager.DeleteArticleMore(no);
                if (n > 0)
                {
                    hint = "全部删除成功！";
                }
                else
                {
                    hint = "删除操作执行失败，请检查相关数据或者联系管理员！";
                }
                break;
        }
        context.Response.Write(hint);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}