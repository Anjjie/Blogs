<%@ WebHandler Language="C#" Class="GetArticleAllByDesc" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetArticleAllByDesc : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
         List<Article> list = Article_Manager.GetArticleAllByDesc();
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Article>));
        dcjs.WriteObject(context.Response.OutputStream,list);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}