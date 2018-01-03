<%@ WebHandler Language="C#" Class="GetCommentByConn" %>

using System;
using System.Web;
using System.Collections.Generic;
using Models;
using BLL;

public class GetCommentByConn : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<Comment> list= Comment_Manager.GetCommentByConn("A_No",context.Request["no"]);
        int count = list.Count;
        string content = "";
        if (count > 0)
        {
            foreach (Comment obj in list)
            {
                if (obj.GetAduit.Aduit_Name == "通过")
                {
                    content += "<div class=\"divComment\">";
                    content += "<div class=\"divNickName\">" + obj.NickName + "</div>"
                                + "<div class=\"divContent\">" + obj.Com_Content + "</div>"
                                + "<div class=\"divDateTime\">" + obj.Com_Datetime + "</div>";
                     content += "</div>";
                }
            }
           
        }
        else
        {
            content = "暂时还没有评论信息";
        }
        context.Response.Write(content);
    }


    public bool IsReusable {
        get {
            return false;
        }
    }

}