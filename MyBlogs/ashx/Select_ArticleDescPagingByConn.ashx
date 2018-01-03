<%@ WebHandler Language="C#" Class="Select_ArticleDescPagingByConn" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class Select_ArticleDescPagingByConn : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

         string ulAndli = "";
        //context.Response.Write("Hello World");
        string findContent = context.Request["findContent"];
        int count = Article_Manager.Select_ArticleDescCorrelationByConn(findContent).Count;

        int pageNo = Convert.ToInt32(context.Request["pageNo"]);
        
        List<Article> list = Article_Manager.Select_ArticleDescPagingByConn(pageNo, 14,findContent);
        if (count == 0)
        {
            context.Response.Write("null&&null&<sanp style='width:100%;text-align:center;'>没有数据</span> ");
            return;
        }

        foreach (Article obj in list)
        {
            ulAndli += "<div class=\"left_DataInfo\">"
            + "<div class=\"divImage\" style=\"background-image:url(../../images/SaveImage/"+ obj.A_CoverImageUrl +" );\"></div>"
            + "<div class=\"divDataContent\">"
                + "<div class=\"title\" data-no=\""+obj.A_No+"\">" + obj.A_Title + "</div>"
                + "<div class=\"typeDate\">" + obj.A_TypeName + "&nbsp;&nbsp;" + obj.A_DateTime + "</div>"
               + "<div class=\"content\">" + obj.A_Content + "</div>"
                + "</div>"
            + "</div>";
        }

        int pageCount = Convert.ToInt32(Math.Ceiling((double)(count / 14))) ;

        string returnData = count + "&&" + pageCount + "&&" + ulAndli;

        context.Response.Write(returnData);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}