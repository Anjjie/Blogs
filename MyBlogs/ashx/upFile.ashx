<%@ WebHandler Language="C#" Class="upFile" %>

using System;
using System.Web;
using System.IO;
using System.Text;

public class upFile : IHttpHandler {

    public void ProcessRequest (HttpContext context) {


        context.Response.ContentType = "text/plain";
        var name = context.Request["name"];
        //context.Response.Write("Hello World");
        HttpFileCollection files = HttpContext.Current.Request.Files;
        if (files.Count>0)
        {
            HttpPostedFile post = files[0];
            if (post.ContentLength>0)
            {
                string[] fileSuffix = Path.GetFileName(post.FileName).Split('.') ;
                var suffix = fileSuffix[fileSuffix.Length-1];
                string fileName = "";
                string path = context.Server.MapPath("~/images/SaveImage")+"\\"+name;
                string filePath = "";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                for (int i = 0; ; i++)
                {
                    fileName = name+"_"+i+"."+suffix;
                    fileName = "thisArticle_new_" + fileName;
                    filePath =path+@"\"+ fileName;
                    if (!File.Exists(filePath))
                    {
                        break;
                    }
                }

                post.SaveAs(filePath);

                StringBuilder sb = new StringBuilder("{");
                sb.Append("fileName:'"+fileName+"'");
                sb.Append("}");
                context.Response.Write(sb.ToString());
                    context.Response.End();
            }
        }


    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}