/// <reference path="../../JQ_File/jquery-3.2.1.min.js" />

function isNotHide_SkipPageBtn(bool, UpNextType) {
    var $PageIndex = $("#PageIndex");
    var $UpPage = $("#UpPage");
    var $NextPage = $("#NextPage");
    var $LastPage = $("#LastPage");
    if (bool == true) {
        switch (UpNextType) {
            case "up":
                $PageIndex.hide();
                $UpPage.hide();
                break;
            case "next":
                $NextPage.hide();
                $LastPage.hide();
                break;
            default:
                $PageIndex.hide();
                $UpPage.hide();
                $NextPage.hide();
                $LastPage.hide();
                break;
        }
    } else {
        switch (UpNextType) {
            case "up":
                $PageIndex.show();
                $UpPage.show();
                break;
            case "next":
                $NextPage.show();
                $LastPage.show();
                break;
            default:
                $PageIndex.show();
                $UpPage.show();
                $NextPage.show();
                $LastPage.show();
                break;
        }
    }

}

function LoadData_All() {
    var $content_Data = $("#content_Data");
    var data = {
        "type": "front",
        "pageNo":"1"
    }
    $.ajax({
        type: "get",
        data:data,
        url: "../../ashx/GetArticlePaging.ashx",
        success: function (ret) {
            var retData = ret.split('&&');
            if (retData.length != 3)
                return;
            $("#pageCount").html(retData[1]);
            $("#ArticleCount").html(retData[0]);
            var a = "";
            for (var i = 0; i < retData[1]; i++) {
                var no = (i + 1);
                a += '<a class="aPageNo" name="PageNo" href="#body">' + no + '</a>';
            }
            $("#divPageNo").html(a);

            if (retData[1]==1) {
                $("#PageBackground").hide();
            }
            $content_Data.html(retData[2]);
            isNotHide_SkipPageBtn(true, "up");
            PageAutoOneselfAdd();
            left_DataInfo_click();
        }
    });
}

function left_DataInfo_click() {
    $(".left_DataInfo").click(function () {
        window.open("../ReadArticle.html?n=" + $(".title").eq($(this).index(".left_DataInfo")).data("no"), "top");
    });
}

function PageAutoOneselfAdd() {
    var $pageCount = $("#pageCount");
    var pageCount=Number( $pageCount.html());
    var aPageNo = $("a[name='PageNo']");
    aPageNo.click(function () {
        var no = $(this).html();
        if ($("#txtContent").val()!="") {
            GetPageInfoData(false,no);
        } else {
            GetPageInfoData(true, no);
        }
        
        $("#pageNo").html(no);

        var clickPageNo = $(this).html();
        var count = aPageNo.length;
        if ($(this).html() != 1) {
            isNotHide_SkipPageBtn(false, "up");
        } else {
            isNotHide_SkipPageBtn(true, "up");
        }
        if ($(this).html() != pageCount) {
            isNotHide_SkipPageBtn(false, "next");
        } else {
            isNotHide_SkipPageBtn(true, "next");
        }

        switch ($(this).index("a[name='PageNo']")) {
            case 0:
                if ($(this).html() == 2) {
                    aPageNo.eq(1).css("color", "#ffffff");
                    $("a[name='PageNo']").not(aPageNo.eq(2)).css("color", "#000000");
                    for (var i = 0; i < count; i++) {
                        var pageNo = Number(aPageNo.eq(i).html()) - 1;
                        aPageNo.eq(i).html(pageNo)
                    }
                } 
                else if ($(this).html()!=1) {
                    aPageNo.eq(2).css("color", "#ffffff");
                    $("a[name='PageNo']").not(aPageNo.eq(2)).css("color", "#000000");
                    for (var i = 0; i < count; i++) {
                        var pageNo = Number(aPageNo.eq(i).html()) - 2;
                        console.log(pageNo);
                        aPageNo.eq(i).html(pageNo)
                    }
                }  else {
                    $(this).css("color", "#ffffff");
                    $("a[name='PageNo']").not($(this)).css("color", "#000000");
                }
                break;
            case 1:
                if ($(this).html() != 2) {
                    aPageNo.eq(2).css("color", "#ffffff");
                    $("a[name='PageNo']").not(aPageNo.eq(2)).css("color", "#000000");
                    for (var i = 0; i < count; i++) {
                        var pageNo = Number(aPageNo.eq(i).html()) - 1;
                        console.log(pageNo);
                        aPageNo.eq(i).html(pageNo)
                    }
                } else {
                    $(this).css("color", "#ffffff");
                    $("a[name='PageNo']").not($(this)).css("color", "#000000");
                }
                break;
            case 3:
                    aPageNo.eq(2).css("color", "#ffffff");
                    $("a[name='PageNo']").not(aPageNo.eq(2)).css("color", "#000000");
                    for (var i = 0; i < count; i++) {
                        var pageNo = pageNo = Number(aPageNo.eq(i).html()) + 1;
                        if (clickPageNo == (pageCount - 1)) {
                            aPageNo.eq(3).css("color", "#ffffff");
                            $("a[name='PageNo']").not(aPageNo.eq(3)).css("color", "#000000");
                            return;
                        }
                        console.log(pageNo);
                        aPageNo.eq(i).html(pageNo);
                    } 
                break;
            case 4:
                for (var i = 0; i < count; i++) {
                    var pageNo = 0;
                    if ($(this).html() == pageCount) {
                        $(this).css("color", "#ffffff");
                        $("a[name='PageNo']").not($(this)).css("color", "#000000");
                        return;
                    }
                    if (clickPageNo == (pageCount - 1)) {
                       
                        aPageNo.eq(3).css("color", "#ffffff");
                        $("a[name='PageNo']").not(aPageNo.eq(3)).css("color", "#000000");
                        pageNo = Number(aPageNo.eq(i).html()) + 1;
                    } else {
                        
                        aPageNo.eq(2).css("color", "#ffffff");
                        $("a[name='PageNo']").not(aPageNo.eq(2)).css("color", "#000000");
                        pageNo = Number(aPageNo.eq(i).html()) + 2;
                    }
                    console.log(pageNo);
                    aPageNo.eq(i).html(pageNo);
                }
                break;
            default:
                $(this).css("color", "#ffffff");
                $("a[name='PageNo']").not($(this)).css("color", "#000000");
                break;
        }
    });
}

function SkipPageBtn_Cleck() {
    var $PageIndex = $("#PageIndex");
    var $UpPage = $("#UpPage");
    var $NextPage = $("#NextPage");
    var $LastPage = $("#LastPage");
    var $pageNo = $("#pageNo");

    var no = 0;
    $PageIndex.click(function () {
        isNotHide_SkipPageBtn(false, "next");
        isNotHide_SkipPageBtn(true, "up");
        $("a[name='PageNo']").eq(0).css("color", "#ffffff");
        $("a[name='PageNo']").not($("a[name='PageNo']").eq(0)).css("color", "#000000");
        if ($("#txtContent").val() !== "") {
            GetPageInfoData(false, 1);
        } else {
            GetPageInfoData(true, 1);
        }
        $pageNo.html(1);
    });

    $UpPage.click(function () {
        no = (parseInt($pageNo.html()) - 1);
        $("a[name='PageNo']").eq(no - 1).css("color", "#ffffff");
        $("a[name='PageNo']").not($("a[name='PageNo']").eq(no - 1)).css("color", "#000000");
        $pageNo.html(no);
        if (no == 1) {
            isNotHide_SkipPageBtn(false, "next");
            isNotHide_SkipPageBtn(true, "up");
            return;
        } else if (no < parseInt($("#pageCount").html())) {
            isNotHide_SkipPageBtn(false, "");
        }
        if ($("#txtContent").val() !== "") {
            GetPageInfoData(false, no);
        } else {
            GetPageInfoData(true, no);
        }
        
    });

    $NextPage.click(function () {
        var pageCount = parseInt($("#pageCount").html());
        no = (parseInt($pageNo.html()) + 1);
        if (no > pageCount) {
            return;
        }
        if (no==pageCount) {
            isNotHide_SkipPageBtn(false, "up");
            isNotHide_SkipPageBtn(true, "next");
        } else if (no>1) {
            isNotHide_SkipPageBtn(false, "");
        }
        $("a[name='PageNo']").eq(no - 1).css("color", "#ffffff");
        $("a[name='PageNo']").not($("a[name='PageNo']").eq(no - 1)).css("color", "#000000");
        if ($("#txtContent").val() !== "") {
            GetPageInfoData(false, no);
        } else {
            GetPageInfoData(true, no);
        }
        $pageNo.html(no);
    });

    $LastPage.click(function () {

        window.scrollTo(0,0);

        isNotHide_SkipPageBtn(true, "next");
        isNotHide_SkipPageBtn(false, "up");
        var pageCount = parseInt($("#pageCount").html());
        $pageNo.html($("#pageCount").html());
        if ($("#txtContent").val() !== "") {
            GetPageInfoData(false, $("#pageCount").html());
        } else {
            GetPageInfoData(true, $("#pageCount").html());
        }
        $("a[name='PageNo']").eq(parseInt($("#pageCount").html()) - 1).css("color", "#ffffff");
        $("a[name='PageNo']").not($("a[name='PageNo']").eq(parseInt($("#pageCount").html()) - 1)).css("color", "#000000");
    });

}

function GetPageInfoData(isFind, pageNo) {
    var $content_Data = $("#content_Data");
    if (isFind == false) {
        var data = {
            "type": "front",
            "pageNo": pageNo
        }
        $.ajax({
            type: "get",
            data: data,
            url: "../../ashx/GetArticlePaging.ashx",
            success: function (ret) {
                var retData = ret.split('&&');
                if (retData.length != 3)
                    return;
                $("#pageCount").html(retData[1]);
                $("#ArticleCount").html(retData[0]);
                $content_Data.html(retData[2]);
                //PageAutoOneselfAdd();
            }
        });
    } else {
        var data = {
            "findContent": $("#txtContent").val(),
            "pageNo": pageNo
        }
        $.ajax({
            type: "get",
            data: data,
            url: "../../ashx/Select_ArticleDescPagingByConn.ashx",
            success: function (ret) {
                var retData = ret.split('&&');
                if (retData.length != 3)
                    return;
                $("#pageCount").html(retData[1]);
                $("#ArticleCount").html(retData[0]);
                alert(retData[2]);
                $content_Data.html(retData[2]);
                left_DataInfo_click();
            }
        });

    }
}

function btnFile_click() {
    $("#btnFile").click(function () {
        
        var data = {
            "findContent": $("#txtContent").val(),
            "pageNo": "1"
        }
        $.ajax({
            type: "get",
            data: data,
            url: "../../ashx/Select_ArticleDescPagingByConn.ashx",
            success: function (ret) {
                var retData = ret.split('&&');
                if (retData.length != 3)
                    return;
                $("#pageCount").html(retData[1]);
                $("#ArticleCount").html(retData[0]);
                var a = "";
                for (var i = 0; i < retData[1]; i++) {
                    var no = (i + 1);
                    a += '<a class="aPageNo" name="PageNo" href="#body">' + no + '</a>';
                }

                $("#divPageNo").html(a);
                
                if (retData[1] == 1) {
                    $("#PageBackground").hide();
                } else {
                    $("#PageBackground").show();
                }
                $("#content_Data").html(retData[2]);
                isNotHide_SkipPageBtn(true, "up");
                PageAutoOneselfAdd();
            }
        });
    });
}


