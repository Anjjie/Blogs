<%@ WebHandler Language="C#" Class="GetUserInfo" %>

using System;
using System.Web;

using Models;
using BLL;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

public class GetUserInfo : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<PersonageInfo> list = new List<PersonageInfo>();
        list.Add(PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName",context.Request["name"]));
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<PersonageInfo>));
        dcjs.WriteObject(context.Response.OutputStream,list);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}