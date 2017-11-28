<%@ WebHandler Language="C#" Class="AddLoginLog" %>

using System;
using System.Web;
using Models;
using BLL;

public class AddLoginLog : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        LoginLog obj = new LoginLog() {
            P_LoginName = context.Request["name"],
            Log_Country = context.Request["Country"],
            Log_Province = context.Request["Province"],
            Log_City = context.Request["City"],
            Log_ipAddress = context.Request["ip"],
            Log_Date = DateTime.Now.ToString()
        };
        int n = LoginLog_Manager.InsertLoginLog(obj);
        if (n>0)
        {
                context.Response.Write("Yes");
        }
        else
        {
                 context.Response.Write("No");
        }

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}