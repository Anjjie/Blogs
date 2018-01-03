<%@ WebHandler Language="C#" Class="AddLeaveWord" %>

using System;
using System.Web;
using BLL;
using Models;

public class AddLeaveWord : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        // context.Response.Write("Hello World");
        MassageBoard obj = new MassageBoard() {
            Aduit_No = 1,
            Mb_Cause = "",
            Mb_Content = context.Request["content"],
            Mb_Datetime = DateTime.Now.ToString(),
            Mb_NickName=context.Request["nickName"]
        };
        int n = MassageBoard_Manager.InsertMassageBoard(obj);
        if (n>0)
        {
            context.Response.Write("留言成功！\n等待审核，合法性。");
        }
        else
        {
                context.Response.Write("留言失败！");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}