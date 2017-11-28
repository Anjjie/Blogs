<%@ WebHandler Language="C#" Class="GetArticleAll" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetArticleAll : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<Article> list = Article_Manager.GetAllArticle();
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Article>));
        dcjs.WriteObject(context.Response.OutputStream,list);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}