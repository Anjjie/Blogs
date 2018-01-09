/// <reference path="JQ_File/jquery-3.2.1.min.js" />

//加载问题库数据
function LoadIssueInfo() {
    var $selIssue1 = $("#selIssue1");
    var $selIssue2 = $("#selIssue2");
    var $selIssue3 = $("#selIssue3");

    var option = "";
    $.getJSON("ashx/GetIssueInfo.ashx", function (data) {
        $.each(data, function (i,obj) {
            option += "<option value='" + obj.IssueI_Name + "'>" + obj.IssueI_Name + "</option>";
        });
        $selIssue1.append(option);
        $selIssue2.append(option);
        $selIssue3.append(option);
    });
}

//校验信息完整
function CheckInfoPage1() {
    var $txtAnswer = $(".txtAnswer");
    if ($txtAnswer.eq(0).val() == "") {
        return "对不起，问题一答案不能为空！";
    } else if ($txtAnswer.eq(1).val() == "") {
        return "对不起，问题二答案不能为空！";
    } else if ($txtAnswer.eq(2).val() == "") {
        return "对不起，问题三答案不能为空！";
    } else {
        return "Yes";
    }
}

//【上一步】【下一步】
function LoadLastNext() {
    var name = { "name": $(location).attr("href").split('=')[1] }

    var $divGetVerifyCode = $("#divGetVerifyCode");
    var $txtPhoneVerify = $("#txtPhoneVerify");


    var $btnNext = $("#btnNext");
    var $btnLast = $("#btnLast");
    var $btnSave = $("#btnSave");

    var lbIssue = ["lbIssue1", "lbIssue2", "lbIssue3"];
    var lbIssues = ["lbIssues1", "lbIssues2", "lbIssues3"];

    var $txtAnswer = $(".txtAnswer");

    var $Content_Page1 = $("#Content_Page1");
    var $Content_Page2 = $("#Content_Page2");

    var $lbHint = $("#lbHint");
   
    $.getJSON("ashx/GetPersonage_Issue.ashx", name, function (data) {
        LoadIssueInfo();
        if (data == null) {
            $Content_Page2.css("display", "block");
            $Content_Page1.css("display", "none");
            $btnLast.css("display", "none");
            $btnSave.data("type","添加");
        } else {
            $.each(data,function (i,obj) {
                var lbIssueCount = lbIssue.length;
                for (var i = 0; i < lbIssueCount; i++) {
                    switch (lbIssue[i]) {
                        case "lbIssue1":
                            $("#" + lbIssue[i]).html(obj.Issue_1);
                            break;
                        case "lbIssue2":
                            $("#" + lbIssue[i]).html(obj.Issue_2);
                            break;
                        case "lbIssue3":
                            $("#" + lbIssue[i]).html(obj.Issue_3);
                            break;
                    }
                }

                function CheckInfoAnswer() {
                    if ($txtAnswer.eq(0).val() != obj.Answer_1) {
                        return "对不起，问题一答案不正确！";
                    }
                    if ($txtAnswer.eq(1).val() != obj.Answer_2) {
                        return "对不起，问题二答案不正确！";
                    }
                    if ($txtAnswer.eq(2).val() != obj.Answer_3) {
                        return "对不起，问题三答案不正确！";
                    }
                    if ($txtPhoneVerify .val()== "") {
                        return "对不起，请输入手机验证码！";
                    }
                    if ($txtPhoneVerify.val() != $divGetVerifyCode.data("verifyCode")) {
                        return "对不起，验证码有误，请重新确认！";
                    }
                    return "Yes";
                }

                $btnNext.click(function () {
                    $lbHint.html("");
                    if (CheckInfoAnswer()!="Yes") {
                        $lbHint.html("温馨提示："+CheckInfoAnswer());
                        return;
                    }
                   
                    $btnSave.data("type", "修改");
                    $Content_Page2.css("display", "block");
                    $Content_Page1.css("display", "none");
                });

                $btnLast.click(function () {
                    $Content_Page2.css("display", "none");
                    $Content_Page1.css("display", "block");
                });

            });
           
        }
    });
    
   

}

function CheckInfoPage2() {
    var $txtAnswer = $(".txtAnswer");
    var $selIssue1 = $("#selIssue1");
    var $selIssue2 = $("#selIssue2");
    var $selIssue3 = $("#selIssue3");


    if ($selIssue1.val() == "请选择问题") {
        return "对不起，【问题一】请选择问题！";
    } else if ($selIssue2.val() == "请选择问题") {
        return "对不起，【问题二】请选择问题！";
    } else if ($selIssue3.val() == "请选择问题") {
        return "对不起，【问题三】请选择问题！";
    } else if ($selIssue1.val() == $selIssue2.val()) {
        return "对不起，问题一和问题二相同，重新选择！";
    } else if ($selIssue1.val() == $selIssue3.val()) {
        return "对不起，问题一和问题三相同，重新选择！";
    } else if ($selIssue2.val() == $selIssue3.val()) {
        return "对不起，问题二和问题三相同，重新选择！";
    } else if ($txtAnswer.eq(3).val() == "") {
        return "对不起，【问题一】答案不能为空！";
    } else if ($txtAnswer.eq(4).val() == "") {
        return "对不起，【问题二】答案不能为空！";
    } else if ($txtAnswer.eq(5).val() == "") {
        return "对不起，【问题三】答案不能为空！";
    }else {
        return "Yes";
    }
}

//保存单击
function btnSave_click() {
    var name = { "name": $(location).attr("href").split('=')[1] }
    var $btnSave = $("#btnSave");
    var $lbHints = $("#lbHints");
    var $txtAnswer = $(".txtAnswer");
    var $selIssue1 = $("#selIssue1");
    var $selIssue2 = $("#selIssue2");
    var $selIssue3 = $("#selIssue3");

    $btnSave.click(function () {
        if (CheckInfoPage2()!="Yes") {
            $lbHints.html("温馨提示："+CheckInfoPage2());
            return;
        }
        var datas = {
            "name": name.name,
            "type": $btnSave.data("type"),
            "Issue1": $selIssue1.val(),
            "Issue2": $selIssue2.val(),
            "Issue3": $selIssue3.val(),
            "Answer1": $txtAnswer.eq(3).val(),
            "Answer2": $txtAnswer.eq(4).val(),
            "Answer3": $txtAnswer.eq(5).val()
        };
        $.ajax({
            type: "get",
            data: datas,
            url: "ashx/SetIssue.ashx",
            success: function (returnInfo) {
                $lbHints.html(returnInfo);
                if (returnInfo == "恭喜，更改密保成功！") {
                    alert(returnInfo);
                    window.close();
                } else if (returnInfo == "恭喜，设置密保成功！") {
                    alert(returnInfo);
                    window.close();
                }
            }
        });
    });
    
}

//获取验证码
function divGetVerifyCode_click() {
    var $divGetVerifyCode = $("#divGetVerifyCode");
    var $lbHint = $("#lbHint");


    var codeTimeout;
    var codeTime = 180;
    var buttonTimeout;
    var buttonTime = 60;
    //按钮禁止时间与开放时间
    buttonTimeout = function () {
        setTimeout(function () {
            buttonTime--;
            if (buttonTime == 0) {
                $divGetVerifyCode.html("重新获取");
                buttonTime = 60;
            } else {
                $divGetVerifyCode.html(buttonTime + "秒后重新获取");
                buttonTimeout();
            }
        }, 1000);
    }

    //设置验证码删除时间
    codeTimeout = function () {
        var name = {"user":$(location).attr("href").split('=')[1]};
        $.ajax({
            type: "get",
            url: "ashx/GetVerifyCode.ashx",
            data: name,
            success: function (verifyCode) {
                $divGetVerifyCode.data("verifyCode", verifyCode);
                alert("测试验证码为：" + $divGetVerifyCode.data("verifyCode"));
            }
        });
        settimeout(function () {
            codeTime--;
            if (codeTime == 0) {
                
                $divGetVerifyCode.data("verifyCode", "");
                codeTime = 180;
            } else {
                codeTimeout();
            }
        }, 1000);
    }

    $divGetVerifyCode.click(function () {
        if ($divGetVerifyCode.html() != "获取验证码") {
            if ($divGetVerifyCode.html() != "重新获取") {
                $lbHint.html("对不起，获取验证码频繁，请等待再次获取时间！");
            } else {
                buttonTimeout();
                codeTimeout();
            }
        } else {
            buttonTimeout();
            codeTimeout();
        }
        
       
    });

    

   


}