<%@ WebHandler Language="C#" Class="SelectLoginLogDesc" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class SelectLoginLogDesc : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<LoginLog> list = LoginLog_Manager.GetAllLoginLogByDesc(context.Request["name"]);
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<LoginLog>));
        dcjs.WriteObject(context.Response.OutputStream,list);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}