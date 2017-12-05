<%@ WebHandler Language="C#" Class="UpdatePassword" %>

using System;
using System.Web;
using Models;
using BLL;

public class UpdatePassword : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        string returnInfo = "";
        PersonageInfo obj = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName",context.Request["name"]);
        if (context.Request["password"] != obj.P_LoginPwd)
        {
            returnInfo = "对不起，你的原密码输入有误！";
        }
        else
        {
            obj.P_LoginPwd = context.Request["newPassword"];
            int n = PersonageInfo_Manager.UpdatePersonageInfo(obj);
            if (n > 0)
            {
                returnInfo = "恭喜，保存成功！";
            }
            else
            {
                returnInfo = "保存失败，请检查输入信息合法性！";
            }
        }
        context.Response.Write(returnInfo);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}