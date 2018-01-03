<%@ WebHandler Language="C#" Class="GetLeaveWordInfo" %>

using System;
using System.Web;

using BLL;
using Models;
using System.Collections.Generic;

public class GetLeaveWordInfo : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<MassageBoard> list = MassageBoard_Manager.GetMassageBoardByConn("Aduit_No","1");
        var LeaveWordContent = "";
        foreach (MassageBoard obj in list)
        {
            LeaveWordContent += "<div class=\"LeaveWordContent_Background\">"
                            +"<div class=\"NickNameDate\">"
                                +" <label class=\"lbNickName\">"+obj.Mb_NickName+"</label>"
                                 +"<label class=\"lbDateTime\">"+obj.Mb_Datetime+"</label>"
                            +" </div>"
                             +"<div class=\"content\">"+obj.Mb_Content+"</div>"
                         +"</div>";
        }
        context.Response.Write(LeaveWordContent);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}