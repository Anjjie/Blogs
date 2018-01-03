<%@ WebHandler Language="C#" Class="LeaveDeleteArticleOmage" %>

using System;
using System.Web;

using System.IO;
using System.Text;
using BLL;
using Models;

public class LeaveDeleteArticleOmage : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string[] urlName = context.Request["coverImageUrl"].Split('/');
        string url = "images/SaveImage/"+urlName[0]+"/"+urlName[1];
        string path= context.Server.MapPath("~/"+url);
        if (Directory.Exists(path))
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo f in dir.GetFiles())
            {
                File.Delete(f.FullName);
            }
            Directory.Delete(path);
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}