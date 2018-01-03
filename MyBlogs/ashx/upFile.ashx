<%@ WebHandler Language="C#" Class="upFile" %>

using System;
using System.Web;
using System.IO;
using System.Text;
using BLL;
using Models;

public class upFile : IHttpHandler {

    public void ProcessRequest (HttpContext context) {


        context.Response.ContentType = "text/plain";
        var name = context.Request["name"];
        var type = context.Request["cover"];
        //context.Response.Write("Hello World");
        HttpFileCollection files = HttpContext.Current.Request.Files;

        int articleSum = Article_Manager.GetAllArticle().Count ;
        articleSum = articleSum + 1;
        if (files.Count>0)
        {
            HttpPostedFile post = files[0];
            if (post.ContentLength>0)
            {
                string[] fileSuffix = Path.GetFileName(post.FileName).Split('.') ;
                var suffix = fileSuffix[fileSuffix.Length-1];
                string fileName = "";
                string path = context.Server.MapPath("~/images/SaveImage")+"\\"+(name+articleSum);
                string filePath = "";

                string retInfo = (name+articleSum)+"/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                for (int i = 0; ; i++)
                {
                    if (type=="cover")
                    {
                        fileName = "Cover_"+name+"_"+i+"."+suffix;
                        if (!Directory.Exists(path+"\\CoverImage"))
                        {
                            Directory.CreateDirectory(path+"\\CoverImage");
                        }
                        fileName = "thisArticle_new_"+articleSum + fileName;
                        filePath =path+@"\CoverImage\"+ fileName;
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        retInfo +="CoverImage/"+fileName;
                    }
                    else
                    {
                        fileName = name+"_"+i+"."+suffix;
                        fileName = "thisArticle_new_"+articleSum + fileName;
                        filePath =path+@"\"+ fileName;
                        retInfo +=fileName;

                    }
                    if (!File.Exists(filePath))
                    {
                        break;
                    }

                }

                post.SaveAs(filePath);

                StringBuilder sb = new StringBuilder("{");
                sb.Append("fileName:'"+retInfo+"'");
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