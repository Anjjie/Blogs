<%@ WebHandler Language="C#" Class="GetArticleTypeAll" %>

using System;
using System.Web;

using System.Collections.Generic;
using Models;
using BLL;

public class GetArticleTypeAll : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        List<ArticleType> list = ArticleType_Manager.GetAllArticleType();
        var option = "<option value='===请选择文章类型==='>===请选择文章类型===</option>";
        foreach (ArticleType obj in list)
        {
            option += "<option value='"+obj.At_No+"'>"+obj.At_Name+"</option>";
        }
        context.Response.Write(option);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}