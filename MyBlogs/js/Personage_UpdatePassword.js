
//获取验证码
function btnGetVerify_click() {
    var btnGetVerify = $("#btnGetVerify");
    var datas = {"user":$(location).attr("href").split('=')[1]};
    var code = "";
    var time = 180;//设置三分钟，删除验证码
    var btnTime = 60;
    //定时器，删除验证码
    var subInTime = function () {
        setTimeout(function () {
            if (time == 0) {
                code = "";
                time = 180;
            } else {
                time--;
                subInTime();
            }
        }, 1000);
    };

    //重获验证码
    var SaveTimeBtnVal = function () {
        setTimeout(function () {
            if (btnTime == 0) {
                btnGetVerify.attr("disabled", false);
                btnGetVerify.val("重新获取");
                btnTime = 60;
            } else {
                btnTime--;
                btnGetVerify.attr("disabled", true);
                btnGetVerify.val(btnTime + "后重新获取");
                SaveTimeBtnVal();
            }
        }, 1000);
    }

    //获取验证码
    function GetCode() {
        $.ajax({
            type: "get",
            data: datas,
            url: "../ashx/GetVerifyCode.ashx",
            success: function (returnInfo) {
                code = returnInfo;
                alert("测试验证码：" + returnInfo);
                subInTime();//启动定时器
                SaveTimeBtnVal();
                btnGetVerify.data("code", code);
            }
        });
    }

    btnGetVerify.click(function () {
        GetCode();
    });
}

//修改密码
function UpdatePassword() {
    var txtPassword = $("#txtPassword");
    var txtNewPassword = $("#txtNewPassword");
    var txtNewPasswordOK = $("#txtNewPasswordOK");
    var txtPhoneVerifyCode = $("#txtPhoneVerifyCode");
    var thisHint = $("#thisHint");
    var btnSave = $("#btnSave");
    var btnGetVerify = $("#btnGetVerify");

    function CheckInfo() {
        if (txtPassword.val()=="") {
            return "＊『对不起，原密码不能为空！』";
        } else if (txtNewPassword.val() == "") {
            return "＊『对不起，新密码不能为空！』";
        } else if (txtNewPasswordOK.val() != txtNewPassword.val()) {
            return "＊『对不起，两次密码不一致，请重新输入！』";
        } else if (txtPhoneVerifyCode.val() == "") {
            return "＊『对不起，验证码不能为空！』";
        } else if (btnGetVerify.data("code") != txtPhoneVerifyCode.val()) {
            alert(btnGetVerify.data("code"));
            return "＊『对不起，验证码有误！』";
        } else {
            return "Yes";
        }
    }

    btnSave.click(function () {
        if (CheckInfo() != "Yes") {
            thisHint.html(CheckInfo());
            return;
        }
        var datas = {
            "name":$(location).attr("href").split('=')[1],
            "password": txtPassword.val(),
            "newPassword": txtNewPasswordOK.val()
        };
        thisHint.html("");
        $.ajax({
            type: "get",
            data: datas,
            url: "../ashx/UpdatePassword.ashx",
            success: function (info) {
                thisHint.html(info);
            }
        });
    });

   


}