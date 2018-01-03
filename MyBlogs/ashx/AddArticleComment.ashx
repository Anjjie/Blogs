<%@ WebHandler Language="C#" Class="AddArticleComment" %>

using System;
using System.Web;


using Models;
using BLL;

public class AddArticleComment : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        Comment obj = new Comment() {
            Aduit_No = 1,
            A_No =Convert.ToInt32( context.Request["articleNo"]),
            Com_Content=context.Request["Comment"],
            Com_Datetime=DateTime.Now.ToString(),
            Com_Cause="",
            NickName = context.Request["nickName"]
        };
        int n = Comment_Manager.InsertComment(obj);
        if (n>0)
        {
                context.Response.Write("0");
        }
        else
        {
                 context.Response.Write("1");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}