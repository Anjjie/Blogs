<%@ WebHandler Language="C#" Class="GetIssueInfo" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetIssueInfo : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        List<Issue_library> listObj = Issue_library_Manager.GetAllIssue_library();
        List<Issue_library> list = new List<Issue_library>();
        Random r = new Random() ;
        for (int i = 0; i < 10; i++)
        {
            int n= r.Next(0,listObj.Count);
            list.Add(listObj[n]);
            listObj.Remove(listObj[n]);
        }
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Issue_library>));
        dcjs.WriteObject(context.Response.OutputStream,list);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}