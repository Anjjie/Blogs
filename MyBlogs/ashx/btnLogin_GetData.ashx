<%@ WebHandler Language="C#" Class="btnLogin_GetData" %>
using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class btnLogin_GetData : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string loginName = context.Request["name"];
        string loginPwd= context.Request["pwd"];
        PersonageInfo obj = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName", loginName);
        if (obj.P_LoginName==null)
        {
            context.Response.Write("对不起，你输入的账号不存在！<br />Sorry, the account you entered does not exist!");
        }
        else
        {
            if (obj.P_LoginPwd!=loginPwd)
            {
                context.Response.Write("对不起，你输入的密码有误！<br />Sorry, the password you entered is wrong!");
            }
            else
            {
                context.Response.Write("Yes");
            }
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}