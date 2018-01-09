/// <reference path="JQ_File/jquery-3.2.1.min.js" />
function Content_Div(){
    var $divEvarydayContent_Data = $(".EvarydayContent_Data[name='divEvarydayContent_Data']");
    var $divYearMonth = $(".divYearMonth");
    var $yuanYear_Evaryday = $(".yuanYear-Evaryday");
    var $background_Content = $(".background-Content");

    $divEvarydayContent_Data.on({
        "mouseover": function () {
            var index = $(this).index();
            
            $yuanYear_Evaryday.eq(index).addClass("yuanYear-Evaryday_hover");
            $background_Content.eq(index).addClass("background-Content_hover");
            $divYearMonth.eq(index).addClass("divYearMonth_hover");
        },
        "mouseout": function () {
            var index = $(this).index();
            $yuanYear_Evaryday.eq(index).removeClass("yuanYear-Evaryday_hover");
            $background_Content.eq(index).removeClass("background-Content_hover");
            $divYearMonth.eq(index).removeClass("divYearMonth_hover");
        }
    });

    $divYearMonth.on({
        "mouseover": function () {
            var index = $(this).index(".divYearMonth");
            console.log(index);
            $yuanYear_Evaryday.eq(index).addClass("yuanYear-Evaryday_hover");
            $background_Content.eq(index).addClass("background-Content_hover");
            $divYearMonth.eq(index).addClass("divYearMonth_hover");
        },
        "mouseout": function () {
            var index = $(this).index(".divYearMonth");
            $yuanYear_Evaryday.eq(index).removeClass("yuanYear-Evaryday_hover");
            $background_Content.eq(index).removeClass("background-Content_hover");
            $divYearMonth.eq(index).removeClass("divYearMonth_hover");
        }
    });


}

var thisNo=0;
var countPage=0;

function LoadData() {
    var data = {
        "pageNo": "1"
    }
    $.ajax({
        type: "get",
        data: data,
        url: "ashx/GetArticleAllByEveryDay.ashx",
        success: function (ret) {
            var retData = ret.split('&&');
            console.log("总数据："+retData[0]+" | 总页数："+retData[1]);
            
            $(".EvarydayLeft").html(retData[2]);
            $(".EvarydayRight").html(retData[3]);
            $("#RollWire").width($(".divEvarydayContent").height());
            Content_Div();

            countPage=retData[1];
            thisNo = 1;
            background_Content_click();
        }
    });
}

function background_Content_click() {
    $(".background-Content").click(function () {
        window.open("ReadArticle.html?n=" + $(".liTitle").eq($(this).index(".background-Content")).data("no"), "top");
    });
}

function LoadMoreData() {
    $("#btnLoadMore").click(function () {
        thisNo++;
        if (thisNo > countPage) {
            $(this).val("已加载全部数据");
            return;
        }
        var data = {
            "pageNo": thisNo
        }
        $.ajax({
            type: "get",
            data: data,
            url: "ashx/GetArticleAllByEveryDay.ashx",
            success: function (ret) {
                var retData = ret.split('&&');
                console.log("总数据：" + retData[0] + " | 总页数：" + retData[1]);
                $(".EvarydayLeft").append(retData[2]);
                $(".EvarydayRight").append(retData[3]);
                $("#RollWire").width($(".divEvarydayContent").height());
                Content_Div();
                background_Content_click();
            }
        });
    });
}