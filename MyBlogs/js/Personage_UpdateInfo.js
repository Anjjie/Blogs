/// <reference path="JQ_File/jquery-3.2.1.min.js" />

//设置页面中间布局高度
function SetCenterHeight() {
	var height = document.documentElement.clientHeight - 195;
	var $center = $("center");
	if(height < 500) {
		height = 600;
	}
	$center.height(height);
	window.onresize = function() {
		SetCenterHeight();
	}
}

//账号获取
function GetUserName() {
    $("#txtUserName").val($(location).attr("href").split('=')[1]);
}

function CheckInfo() {
    var txtUserName = $("#txtUserName");
    var txtNickName = $("#txtNickName");
    if (txtUserName.val()=="") {
        return "对不起，账户加载出错！";
    } else if (txtNickName.val()=="") {
        return "对不起，请输入新的昵称！";
    } else {
        return "Yes";
    }
    
}

//保存按钮
function btnSave_Click() {
    var btnSave = $("#btnSave");
    var txtUserName = $("#txtUserName");
    var txtNickName = $("#txtNickName");
    var txtMyExplain = $("#txtMyExplain");
    btnSave.click(function () {
        if (CheckInfo() != "Yes") {
            alert(CheckInfo());
            return;
        }
        var datas = {
            "name": txtUserName.val(),
            "nickName": txtNickName.val(),
            "explain": txtMyExplain.val()
        };
        $.ajax({
            type: "get",
            data: datas,
            url: "ashx/UpdateMyInfo.ashx",
            success: function (info) {
                alert(info);
            }
        });


    });
}