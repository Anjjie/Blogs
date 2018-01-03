/// <reference path="../JQ_File/jquery-3.2.1.min.js" />

var minNum = 0;
var maxNum = 14;
var sumNum = 0;

function LoadInfo(min,max) {
    var $divContent = $("#divContent");
    $.ajax({
        type: "get",
        url: "../ashx/GetCommentAll.ashx",
        success: function (ret) {
            var retData = $.parseJSON(ret);
            var count = 0;
            var ulOrli = '<ul class="ulContent_Title">'
               + '<li>文章</li>'
               + '<li>作者</li>'
               + '<li>内容</li>'
               + '<li>时间</li>'
               + '<li>&nbsp;</li></ul>';
            $.each(retData, function (i, obj) {
                if (i >= min && i <= max) {
                    minNum = min;
                    maxNum = max;
                    ulOrli += "<ul class='ulContent_Content'>";
                    ulOrli += "<li>" + obj.GetArticle.A_Title + "</li><li>" + obj.GetArticle.A_Author + "</li>"
                        + "<li>" + obj.Com_Content + "</li><li>" + obj.Com_Datetime + "</li>";
                    ulOrli += "<li><a href='javascript:;'>查看</a>&nbsp;&nbsp;<a href='javascript:;'>回复</a> </li></ul>";
                }
                sumNum = i;
                count = i;
            });
                if (count > 14) {
                    ulOrli += '<ul class="ulContent_Botton"><li>'
                   + '<a id="IndexPage" href="javascript:;" >首页</a>&nbsp;&nbsp;'
                   + '<a id="UpPage" href="javascript:;" >上一页</a>&nbsp;&nbsp;'
                   + '<a id="NextPage" href="javascript:;" >下一页</a>&nbsp;&nbsp;'
                   + '<a id="TrailerPage" href="javascript:;" >尾页</a>'
                   + '</li></ul>';
                }
            $divContent.html(ulOrli);
            AllPageFunction();
        }
    });
}

function AllPageFunction() {
    $("#IndexPage").click(function () {
        LoadInfo(0,14);
    });

    $("#UpPage").click(function () {
        minNum = minNum - 15;
        maxNum = maxNum - 14;
        if (minNum < 0) {
            minNum = 0;
            maxNum = 14;
        }
        LoadInfo(minNum, maxNum);
    });

    $("#NextPage").click(function () {
        minNum = minNum + 15;
        maxNum = maxNum + 14;
        if (maxNum > sumNum) {
            minNum = sumNum - 14;
            maxNum = sumNum;
        }
        LoadInfo(minNum, maxNum);
    });

    $("#TrailerPage").click(function () {
        minNum = sumNum-14;
        LoadInfo(minNum, sumNum);
    });
}