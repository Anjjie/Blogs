<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personage_SetHead.aspx.cs" Inherits="Personage_SetHead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>XLong博客 - 更改头像</title>
    <%--<link href="css/Login.css" type="text/css" rel='stylesheet' />--%>

    <link rel="stylesheet" href="css/Personage_SetHead.css" />

	<script type="text/javascript" src="JQ_File/jquery-3.2.1.min.js" ></script>

	<script type="text/javascript" src="js/Personage_UpdateInfo.js" ></script>
    <script type="text/javascript" src="js/Personage_SetHead.js"></script>

	<script type="text/javascript">
	    $(function () {
	        $("#userName").val($(location).attr("href").split('=')[1]);
            SetCenterHeight();
            //GetUserName();
            selFile_change();
            GetUPImage();
		});
	</script>

</head>
<body>
    <form id="form1" runat="server">
     <nav>
    	<ul class="Nav">
    		<li><label id="labelLogo">XLong博客</label> <label id="topLabel">· 更改头像</label></li>
    	</ul>
    </nav>
	<center>
		<div id="Content_CenterBack"  style="padding:0;margin:0;">
            <ul style="height:100% ">
                <li class="content_top">
                    <div style="float:left;">
                    <asp:FileUpload ID="selFile" runat="server" style="display:none;"  />
                    <input type="button" id="btnFile" runat="server" value="选择文件" onclick="javascript: $('#selFile').click();" title="未选择文件"  />
                    <asp:TextBox ID="userName" runat="server" Text=""  style="display:none;"></asp:TextBox>
                    <asp:Button ID="btnUp" runat="server"  Text="未选择图片" OnClick="btnUp_Click" style="display:none;" /></div>
                    <div style="height:95%;margin-left:20px; float:left; color:rgba(184, 184, 184, 1);font-size:10pt;display:table;">
                       <p style="display:table-cell;vertical-align:bottom;">注：更换头像仅支持jpg、jpge、png格式，图片大小尽力保持在3M以内。</p> 
                    </div>
                </li>
                <li class="content_middle">
                     <div id="divHead200"></div>
                     <div id="divHead150"></div>
                     <div id="divHead125"></div>
                     <div id="divHead100"></div>
                     <div id="divHead75"></div>
                </li>
                <li class="content_bottom">
                    <div  style="float:left;"> 
                        <%-- <input type="button" id="btnSave" value="保存" />--%>
                        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                    </div>
                    <div style="float:left; margin-top:10px;">
                       <label id="lbHint" runat="server" style="margin-left:20px;color:red;font-size:10pt;"></label></div>
                </li>
            </ul>
			
		</div>
	</center>
    <footer>
    	<ul>
    		<li>XLong博客版权所有&nbsp;&nbsp;&nbsp;&nbsp;站长QQ：1078933133&nbsp;&nbsp;&nbsp;&nbsp;站长E-mail：Anjjiewm@163.com</li>
    	</ul>
    </footer>
    </form>
</body>
</html>
