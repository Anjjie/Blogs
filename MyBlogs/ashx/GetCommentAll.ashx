<%@ WebHandler Language="C#" Class="GetCommentAll" %>

using System;
using System.Web;

using Models;
using BLL;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

public class GetCommentAll : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        List<Comment> list = Comment_Manager.GetAllComment();
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<Comment>));
        dcjs.WriteObject(context.Response.OutputStream,list);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}