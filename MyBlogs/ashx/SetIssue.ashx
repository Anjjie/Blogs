<%@ WebHandler Language="C#" Class="SetIssue" %>

using System;
using System.Web;

using Models;
using BLL;

public class SetIssue : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        Issue obj = new Issue() {
            P_LoginName = context.Request["name"],
            Answer_1 = context.Request["Answer1"],
            Answer_2 = context.Request["Answer2"],
            Answer_3 = context.Request["Answer3"],
            Issue_1 = context.Request["Issue1"],
            Issue_2 = context.Request["Issue2"],
            Issue_3 = context.Request["Issue3"]
        };
        int n = 0;
        if (context.Request["type"] == "添加")
        {
            n = Issue_Manager.InsertIssue(obj);
            if (n > 0)
            {
                context.Response.Write("恭喜，设置密保成功！");
            }
            else
            {
                context.Response.Write("设置密保失败！");
            }
        }
        else
        {
            n = Issue_Manager.UpdateIssue(obj);
                if (n > 0)
            {
                context.Response.Write("恭喜，更改密保成功！");
            }
            else
            {
                context.Response.Write("更改密保失败！");
            }
        }


    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}