<%@ WebHandler Language="C#" Class="GetMassageAll" %>

using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

using Models;
using BLL;

public class GetMassageAll : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<MassageBoard> list = MassageBoard_Manager.GetAllMassageBoard();
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(List<MassageBoard>));
            dcjs.WriteObject(context.Response.OutputStream,list);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}