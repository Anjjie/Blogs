<%@ WebHandler Language="C#" Class="UpdatePhone" %>

using System;
using System.Web;
using Models;
using BLL;

public class UpdatePhone : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string returnInfo = "";
        PersonageInfo obj = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName",context.Request["name"]);
        obj.P_Phone = context.Request["phone"];
        int n = PersonageInfo_Manager.UpdatePersonageInfo(obj);
        if (n > 0)
        {
            returnInfo = "绑定成功！";
        }
        else
        {
            returnInfo = "绑定失败，请检查输入信息合法性！";
        }

        context.Response.Write(returnInfo);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}