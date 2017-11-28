<%@ WebHandler Language="C#" Class="GetVerifyCode" %>

using System;
using System.Web;

using Models;
using BLL;
using System.Text;
using System.Linq;

public class GetVerifyCode : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        // context.Response.Write("Hello World");
        string loginName = context.Request["user"];
        PersonageInfo obj =PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName",loginName);
        if (obj.P_LoginName==null)
        {
            context.Response.Write("对不起，你输入的账号不存在！<br />Sorry, the account you entered does not exist!");
        }
        else
        {
            string verifyCode = "";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                verifyCode += r.Next(0, 9);
            }
            SendVerifyCode(verifyCode,obj.P_Phone);
            context.Response.Write(verifyCode);
        }
    }

    public void SendVerifyCode(string verifyCode,string phone) {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}",verifyCode);
        string serverIp = "api.ucpaas.com";
        string serverPort = "443";
        string account = "";     //用户sid
        string token = "";         //用户sid对应的token
        string appId = "";      //对应的应用id，非测试应用需上线使用
        string templatedId = "";          //短信模板id，需通过审核
        //UCSRestRequest api = new UCSRestRequest();
        //api.init(serverIp, serverPort);
        //api.setAccount(account, token);
        //api.enabeLog(true);
        //api.setAppId(appId);
        //api.enabeLog(true);
        //api.SendSMS(phone, templatedId, sb.ToString());
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}