/// <reference path="../JQ_File/jquery-3.2.1.min.js" />
//document.title=window.prompt("后台安全访问密码","");

var CheckCode = "我的博客与后台登录！";//保存的验证码

//信息校验不能为空
function CheckInfo() {
    var $loginName = $("#txtLoginName");
    var $loginPwd = $("#txtLoginPwd");
    var $txtVerifyCode = $("#txtVerifyCode");
    if($loginName.val() == "") {
        return "温馨提示：请输入登录账号！<br/>warm prompt:Please enter your login account!";
    } else if($loginPwd.val() == "") {
        return "温馨提示：请输入登录密码！<br/>warm prompt:Please enter the login password!";
    } else{
        return "Yes";
    }
	
}

//获取验证码按钮
function GetVerifyCode() {
    var time = 60;//设置时间60秒
    var saveFunction;//设置保存计时器函数
    var $btnGetPhoneVerify = $("#btnGetPhoneVerify");
    var $txtLoginName = $("#txtLoginName");
    var $liHint = $("#liHint");
    $btnGetPhoneVerify.on({
        "click": function () {
            $liHint.html("");
            if (CheckInfo() != "Yes")
            {
                $liHint.html(CheckInfo());
                return;
            }
            var getData = { "user": $txtLoginName.val() };
            $.ajax({
                url: "../ashx/GetVerifyCode.ashx",
                type: "get",
                data: getData,
                success: function (date) {
                    if (date == "对不起，你输入的账号不存在！<br />Sorry, the account you entered does not exist!") {
                        $liHint.html(date);
                        return;
                    }
                    alert("内测手机验证码：" + date);
                    $liHint.html("发送成功!");
                    CheckCode = date;
                    saveFunction = setInterval(function () {
                        $btnGetPhoneVerify.val(time + "秒后重新获取验证码");
                        $btnGetPhoneVerify.attr("disabled", true);
                        time--;
                        if (time == 0) {
                            clearInterval(saveFunction);
                            time = 60;
                            CheckCode = "我的博客与后台登录！";
                            $btnGetPhoneVerify.val("重新获取验证码");
                            $btnGetPhoneVerify.attr("disabled", false);
                        }

                    }, 1000);
                }
            });
        }
    });
}

//登录按钮的单击事件
function btnLogin_Click() {
        var $btnLogin = $("#btnLogin");
        var $liHint=$("#liHint");
        var $txtLoginName=$("#txtLoginName");
        var $txtLoginPwd=$("#txtLoginPwd");
        var $txtVerifyCode=$("#txtVerifyCode");
        $btnLogin.click(function () {
            $liHint.html("");
            if (CheckInfo() == "Yes") {
                var getData = { "name": $txtLoginName.val(),"pwd":$txtLoginPwd.val() };
                $.ajax({
                    beforn: function () { $liHint.html("正在验证信息..."); },
                    url: "../ashx/btnLogin_GetData.ashx",
                    type:"get",
                    data: getData,
                    success: function (date) {
                        if (date != "Yes") {
                            $liHint.html(date);
                            return;
                        }
                        if ($txtVerifyCode.val()=="") {
                            $liHint.html("对不起，验证码不能为空！<br />Sorry, the verification code cannot be empty!");
                            return;
                        }
                        if (CheckCode == "我的博客与后台登录！" && CheckCode != $txtVerifyCode.val()) {
                            $liHint.html("对不起，验证码有误！<br />Sorry, the verification code is wrong!");
                        } else {
                            setLog($txtLoginName.val());
                            CheckCode = "我的博客与后台登录！";
                        }
                    }
                });
            } else {
                $liHint.html(CheckInfo());
            }
        });
}

function setLog(nameVal) {
    var $liHint = $("#liHint");
    var CPCUrl = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js";
    var ipUrl = "http://chaxun.1616.net/s.php?type=ip&output=json&callback=?&_=" + Math.random();
    var log = {
        "name": $("#txtLoginName").val(),
        "Country": "",
        "Province": "",
        "City": "",
        "ip": ""
    };
    $.getScript(CPCUrl, function () {
        log.Country = remote_ip_info.country;
        log.Province = remote_ip_info.province;
        log.City = remote_ip_info.city;
        $.getJSON(ipUrl, function (data) {
            log.ip = data.Ip;
            $.ajax({
                type: "get",
                url: "../ashx/AddLoginLog.ashx",
                data:log,
                success: function (returnInfo) {
                    if (returnInfo == "Yes") {
                        $liHint.html("登录成功!");
                        window.location.href = "../Backstage_Index.html?myLoginName=" + nameVal;
                    } else {
                        alert("失败！");
                    }
                }
            });


        });
    });
}