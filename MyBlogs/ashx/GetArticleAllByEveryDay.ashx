<%@ WebHandler Language="C#" Class="GetArticleAllByEveryDay" %>

using System;
using System.Web;

using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Models;
using BLL;

public class GetArticleAllByEveryDay : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        string EvarydayLeft = "";
        string EvarydayRight = "";
        //context.Response.Write("Hello World");
        int count = Article_Manager.GetArticleByConns("A_TypeName","日常").Count;

        int pageNo = Convert.ToInt32(context.Request["pageNo"]);

        List<Article> list = Article_Manager.GetArticlePagingByConn(pageNo, 14,"日常");
        if (count == 0)
        {
            context.Response.Write("0&&0&&<sanp style='width:100%;text-align:center;'>没有数据</span> ");
            return;
        }

        foreach (Article obj in list)
        {
            string[] date = obj.A_DateTime.Split('-');
            if (date.Length!=3)
            {
                date = date[0].Split('/');
            }
            string year = date[0];
            string monthDay = date[1] + "-" + date[2].Split(' ')[0];
            EvarydayLeft += "<div class=\"EvarydayContent_Data\">"
                            +"<div class=\"yuanYear-Evaryday\"><div></div></div>"
                            +"<div class=\"divYearMonth\">"
                                +"<p class=\"pYear\" id=\"pYear\">"+year+"</p>"
                                +"<p class=\"pMonthDay\" id=\"pMonthDay\">"+monthDay+"</p>"
                            +"</div>"
                        +"</div>";

            EvarydayRight += " <div class=\"EvarydayContent_Data\" name=\"divEvarydayContent_Data\">"
                             +"<div class=\"background-Content\">"
                                 +"<div class=\"divTriangle\"></div>"
                                 +"<div class=\"left-ContentImage\">"
                                    +" <div id=\"divImage\" style=\"background-image:url(../../images/SaveImage/"+ obj.A_CoverImageUrl +" );\"></div>"
                                 +"</div>"
                                 +"<div class=\"right-ContentInfo\">"
                                    +" <ul>"
                                       +"  <li class=\"liTitle\" data-no=\""+obj.A_No+"\">"+obj.A_Title+"</li>"
                                        +" <li class=\"liType\">"+obj.A_TypeName+"</li>"
                                        +" <li class=\"liContent\">"+obj.A_Content+"</li>"
                                    +" </ul>"
                                +" </div>"
                             +"</div>"
                         +"</div>";
        }

        int pageCount = Convert.ToInt32(Math.Ceiling((double)(count / 14))) + 1;

        string returnData = count + "&&" + pageCount + "&&" + EvarydayLeft+ "&&"+EvarydayRight;

        context.Response.Write(returnData);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}