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
            var divType = "";
            $.each(datas, function (i, obj) {
                divType += ' <div class="divArticleType_Button" data-no="'+obj.At_No+'">' + obj.At_Name+ '</div>';
            });
            $divArticleType.html(divType);
        }
    });
}