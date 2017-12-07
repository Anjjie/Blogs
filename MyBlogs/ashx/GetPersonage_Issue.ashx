<%@ WebHandler Language="C#" Class="GetPersonage_Issue" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetPersonage_Issue : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        Issue obj = Issue_Manager.GetIssueByConn("P_LoginName", context.Request["name"]);
        List<Issue> list = new List<Issue>();
        if (obj.P_LoginName != null)
        {
            list.Add(obj);
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Issue>));
            dcjs.WriteObject(context.Response.OutputStream,list);
        }
        else
        {
            context.Response.Write("null");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}