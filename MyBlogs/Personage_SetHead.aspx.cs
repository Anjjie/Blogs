using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  System.IO;
using System.Configuration;
using Models;
using BLL;

public partial class Personage_SetHead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 上传头像
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUp_Click(object sender, EventArgs e)
    {
        try
        {
            this.lbHint.InnerHtml = "";
            if (this.selFile.HasFile)
            {
                if (this.userName.Text=="")
                {
                    this.lbHint.InnerHtml = "请登录账号再进行修改头像信息！";
                    return;
                }
                this.lbHint.InnerHtml = "";
                string fileName = this.selFile.PostedFile.FileName;
                string[] suffixList = fileName.Split('.');
                string suffix = suffixList[suffixList.Length - 1];
                string userImage = this.userName.Text + "." + suffix;
                string filePath = Server.MapPath("images/SaveHead") + "\\" + userImage;
                this.selFile.PostedFile.SaveAs(filePath);
                ConfigurationManager.AppSettings["UpImagePath"]= filePath+"|"+ userImage;
                this.btnUp.Text = fileName+"|"+ userImage;
            }
            else
            {
                this.lbHint.InnerHtml = "你还没有选择图片，请重新选择！";
            }
        }
        catch (Exception ex)
        {
            this.lbHint.InnerHtml= "系统出现异常，请联系管理员！"+ex.Message;
        }
    }

    //保存按钮
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string[] fileInfo = ConfigurationManager.AppSettings["UpImagePath"].Split('|');
            string getPath = fileInfo[0];
            string getName = fileInfo[1];
            string copyPath = Server.MapPath("images/AllHead")+"\\"+ getName;
            if (File.Exists(copyPath))
            {
                File.Delete(copyPath);
            }
            if (File.Exists(getPath))
            {
                File.Copy(getPath, copyPath);
                File.Delete(getPath);
                PersonageInfo Uif = PersonageInfo_Manager.GetPersonageInfoByConn("P_LoginName", this.userName.Text);
                Uif.P_Head = "../images/AllHead/" + getName;
                int n = PersonageInfo_Manager.UpdatePersonageInfo(Uif);
                this.lbHint.InnerHtml = "头像修改成功！";
                this.btnUp.Text = "未选择图片";
            }
            else
            {
                this.lbHint.InnerHtml = "保存失败，请重新选择图片！";
            }

        }
        catch (Exception ex)
        {
            this.lbHint.InnerHtml = "系统出现异常，请联系管理员！";
        }
    }
}