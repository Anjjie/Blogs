<%@ WebHandler Language="C#" Class="UpdateMyInfo" %>

using System;
using System.Web;
using Models;
using BLL;


public class UpdateMyInfo : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string returnInfo = "";
        PersonageInfo obj = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName",context.Request["name"]);
        obj.P_NickName = context.Request["nickName"];
        obj.P_MyExplain = context.Request["explain"];
        int n = PersonageInfo_Manager.UpdatePersonageInfo(obj);
        if (n>0)
        {
            returnInfo = "保存成功！";
        }
        else
        {
            returnInfo = "保存失败，请检查输入信息合法性！";
        }
        context.Response.Write(returnInfo);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}