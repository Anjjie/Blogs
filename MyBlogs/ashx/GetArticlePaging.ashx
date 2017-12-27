<%@ WebHandler Language="C#" Class="GetArticlePaging" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetArticlePaging : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string ulAndli = "";
        //context.Response.Write("Hello World");
        int count = Article_Manager.GetAllArticle().Count;

        int pageNo = Convert.ToInt32(context.Request["pageNo"]);

        List<Article> list = Article_Manager.GetArticlePaging(pageNo,14);
        if (count==0)
        {
            context.Response.Write("null&&null&<sanp style='width:100%;text-align:center;'>没有数据</span> ");
            return;
        }
        if (context.Request["type"]=="front")
        {
            foreach (Article obj in list)
            {
                ulAndli += "<div class=\"left_DataInfo\">"
                + "<div class=\"divImage\">没有</div>"
                + "<div class=\"divDataContent\">"
                    + "<div class=\"title\">"+obj.A_Title+"</div>"
                    + "<div class=\"typeDate\">"+obj.A_TypeName+"&nbsp;&nbsp;"+obj.A_DateTime+"</div>"
                   + "<div class=\"content\">"+obj.A_Content+"</div>"
                    + "</div>"
                + "</div>";
            }
        }
        else
        {
            foreach (Article obj in list)
            {
                ulAndli += "<ul class=\"ulContent_Content\"><li class=\"liSelect\"><input type=\"checkbox\" name=\"chkSel\" value=\"\" /></li>"
                + "<li class=\"liId\" name=\"no\">&nbsp;" + (obj.A_No + 1) + "</li>"
                + "<li class=\"liTitle\">&nbsp;" + obj.A_Title + "</li>"
                + "<li class=\"liAuthor\">" + obj.A_Author + "</li>"
                + "<li class=\"liArticleType\">" + obj.A_TypeName + "</li>"
                + "<li class=\"liArticleTime\">" + obj.A_DateTime + "</li>"
                + "<li class=\"liClickNum\">1</li>"
                + "<li class=\"liComm\"> <a name=\"aBtnCompile\" href=\"javascript:;\" >编辑</a>"
                + "&nbsp;<a name=\"aBtnDelete\" href=\"javascript:;\" >删除</a></li></ul>";
            }
        }
        int pageCount = Convert.ToInt32(Math.Ceiling((double)(count / 14))) + 1;

        string returnData = count + "&&" + pageCount + "&&" + ulAndli;

        context.Response.Write(returnData);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}