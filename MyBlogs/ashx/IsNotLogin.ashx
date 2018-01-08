<%@ WebHandler Language="C#" Class="IsNotLogin" %>

using System;
using System.Web;
using System.Web.SessionState;


public class IsNotLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState  {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        var retState = 0;
            var name=context.Session["loginUser"];
            if (context.Session["loginUser"] == null)
            {
                retState = 0;
            }
            else
            {
                retState = 1;
            }

        context.Response.Write(retState);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }



}