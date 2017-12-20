/// <reference path="../JQ_File/jquery-3.2.1.min.js" />

//页面内容链接函数
//设置关联内容链接
function PageContentUrl() {
    var name = $(".left_li").data("LoginName");
    //alert(name);
    var $a = $("a[name='aURL']");
    $a.click(function () {
        var index = $(this).index("a");
        var allUrl = ["UpdateInfo", "SetHead", "UpdatePassword", "SetIssue", "SetEmail","SetPhone"];
        var getUrl = "../Personage_" + allUrl[index] + ".html?name=" + name;
        if (allUrl[index] == "SetHead") {
            getUrl = "../Personage_" + allUrl[index] + ".aspx?name=" + name;
        }
        $(this).attr({
            "target": "_blank",
            "href": getUrl });
    });
    
}

//加载信息
function LoadUserInfo() {
    var name = { "name": $(location).attr("href").split("=")[1] };
    var $a = $("a[name='aURL']");
    var $lbHint = $("label[name='lbHint']");
    var count = $a.length;
    $.getJSON("../ashx/GetUserInfo.ashx", name, function (data) {
        $.each(data, function (i, obj) {
            for (var i = 0; i < count; i++) {
                switch (i) {
                    case 0:
                        if (obj.P_NickName == "") {
                            $lbHint.eq(i).html("&nbsp;未完善");
                            $a.eq(i).html("完善");
                        } else {
                            if (obj.P_MyExplain=="") {
                                $lbHint.eq(i).html("&nbsp;未完善");
                                $a.eq(i).html("完善");
                            } else {
                                $lbHint.eq(i).css("color", "#00BB00");
                                $lbHint.eq(i).html("&nbsp;已完善");
                                $a.eq(i).html("更改");
                            }
                        }
                        break;
                    case 1:
                        if (obj.P_NickName == "") {
                            $lbHint.eq(i).html("&nbsp;未设置");
                            $a.eq(i).html("设置");
                        } else {
                            $lbHint.eq(i).css("color", "#00BB00");
                            $lbHint.eq(i).html("&nbsp;已设置");
                            $a.eq(i).html("更换");
                        }
                        break;
                    case 2:
                        var level = 0;
                        var hint = "";
                        var pwd = obj.P_LoginPwd;
                        var color = "";
                        if (/\d/.test(pwd)) level++;  //数字
                        if (/[a-z]/.test(pwd)) level++;  //小写
                        if (/[A-Z]/.test(pwd)) level++;  //大写
                        if (/\W/.test(pwd)) level++;  //特殊符号
                       
                        switch (level) {
                            case 1:
                                color = "#CE0000";
                                hint = "&nbsp;不安全";
                                break;
                            case 2:
                                color = "#CE0000";
                                hint = "强度较低";
                                break;
                            case 3:
                                color = "#EAC100";
                                hint = "强度一般";
                                break;
                            case 4:
                                color = "#00BB00";
                                hint = "强度较高";
                                break;
                        }
                        $lbHint.eq(i).css("color", color);
                        $lbHint.eq(i).html(hint);
                        break;
                    case 3:
                        $.getJSON("../ashx/GetPersonage_Issue.ashx", name, function (data) {
                            if (data != null) {
                                $lbHint.eq(3).css("color", "#00BB00");
                                $lbHint.eq(3).html("已设置");
                                $a.eq(3).html("更改");
                               
                            } else {
                                $lbHint.eq(3).html("未设置");
                                $a.eq(3).html("设置");
                            }
                        });
                       
                        break;
                    case 4:
                        $lbHint.eq(i).css("color", "#CE0000");
                        $lbHint.eq(i).html("正在开发");
                        break;
                    case 5:
                        if (obj.P_Phone == "") {
                            $lbHint.eq(i).html("&nbsp;已绑定");
                            $a.eq(i).html("设置");
                        } else {
                            $lbHint.eq(i).css("color", "#00BB00");
                            $lbHint.eq(i).html("&nbsp;已绑定");
                            $a.eq(i).html("更改");
                        }
                        break;
                }
            }
        });
    });
}


