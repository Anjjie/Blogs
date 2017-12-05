//获取验证码
function btnGetVerify_click() {
    var btnGetVerify = $("#btnGetVerify");
    var datas = { "user": $(location).attr("href").split('=')[1] };
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

function btnSave_click() {
   
    var txtUserName = $("#txtUserName");
    var txtPhoneVerify = $("#txtPhoneVerify");
    var txtNewPhone = $("#txtNewPhone");
    var btnSave = $("#btnSave");
    var lbHint = $("#lbHint");

    function CheckInfo() {
        if (txtUserName.val()=="") {
            return "加载用户信息失败！";
        } else if (txtNewPhone.val()=="") {
            return "对不起，新手机号码不能为空！";
        } else if (txtPhoneVerify.val() != txtPhoneVerify.data("code")) {
            return "对不起，您输入的验证码有误！";
        } else {
            return "Yes";
        }
    }

    btnSave.click(function () {
        if (CheckInfo() != "Yes") {
            lbHint.html(CheckInfo());
        }
        lbHint.html("");
        var datas = {
            "name": txtUserName.val(),
            "phone": txtNewPhone.val()
        };
        $.ajax({
            type: "get",
            data: datas,
            url: "../ashx/UpdatePhone.ashx",
            success: function (returnData) {
                lbHint.html(returnData);
            }
        });
    });


}