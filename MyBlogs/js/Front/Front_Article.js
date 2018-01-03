/// <reference path="../../JQ_File/jquery-3.2.1.min.js" />
function LoadTypeInfo() {
    var data = { "comType": "1" };
    var $divArticleType = $("#divArticleType");
    $.ajax({
        url: "../../ashx/GetArticleTypeAll.ashx",
        data:data,
        type: "get",
        success: function (retData) {
            var datas = $.parseJSON(retData);
            var divType = '<div class="divArticleType_Button" >全部</div>';
            $.each(datas, function (i, obj) {
                if (obj.At_Name=="日常") {
                    
                } else {
                    divType += '<div class="divArticleType_Button" data-no="' + obj.At_No + '">' + obj.At_Name + '</div>';
                }
            });
            $divArticleType.html(divType);
            divArticleType_Button_Click();
        }
    });
}

function divArticleType_Button_Click() {
    $(".divArticleType_Button").click(function () {
        var urlName = ["Front_ArticleAll", "Front_ArticleTechnology", "Front_Articlejournalism", "Front_ArticleFiiNote"];
        $("#iframe_Type").attr("src", "../../" + urlName[$(this).index()] + ".html");
    });
}