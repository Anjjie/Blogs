<%@ WebHandler Language="C#" Class="AddArticle" %>

using System;
using System.Web;

using Models;
using BLL;

public class AddArticle : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        PersonageInfo pObj = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName",context.Request["ID"]);
        Article obj = new Article() {
            A_Author = pObj.P_NickName,
            A_Content = context.Request["content"],
            A_DateTime = DateTime.Now.ToString(),
            A_Title =context.Request["title"],
            A_TypeName=context.Request["articleType"],
            A_CoverImageUrl=context.Request["coverImageUrl"]
        };
        int n = Article_Manager.InsertArticle(obj);
        if (n>0)
        {
            context.Response.Write("1");
        }
        else
        {
            context.Response.Write("0");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}