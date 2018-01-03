<%@ WebHandler Language="C#" Class="GetArticleByConn" %>

using System;
using System.Web;
using BLL;
using Models;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

public class GetArticleByConn : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<Article> list = new List<Article>();
        string title = context.Request["title"];
        list.Add(Article_Manager.GetArticleByConn("A_No",title));
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Article>));
         dcjs.WriteObject(context.Response.OutputStream,list);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}