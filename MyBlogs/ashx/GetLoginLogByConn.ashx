<%@ WebHandler Language="C#" Class="GetLoginLogByConn" %>

using System;
using System.Web;

    using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetLoginLogByConn : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        List<LoginLog> list = new List<LoginLog>();
            list.Add(LoginLog_Manager.GetLoginLogByConn("Log_No",context.Request["no"]));
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<LoginLog>));
        dcjs.WriteObject(context.Response.OutputStream,list);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}