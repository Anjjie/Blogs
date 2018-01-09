/// <reference path="JQ_File/jquery-3.2.1.min.js" />

function GetUPImage() {

    if ($("#btnUp").val() != "未选择图片") {

        var NameAndPath = $("#btnUp").val().split('|');
        var divImage = ["divHead200", "divHead150", "divHead125", "divHead100", "divHead75"];
        var count = divImage.length
        for (var i = 0; i < count; i++) {
            $("#" + divImage[i]).css("background-image", "url(images/SaveHead/" + NameAndPath[1] + ")");
        };
        $("#btnFile").attr("title", NameAndPath[0]);
        $("#btnUp").val("未选择图片");

    } else {
        var data = { "name": $("#userName").val() };
        $.getJSON("ashx/GetUserInfo.ashx", data, function (data) {
            $.each(data, function (i,obj) {
                var divImage = ["divHead200", "divHead150", "divHead125", "divHead100", "divHead75"];
                var count = divImage.length
                for (var i = 0; i < count; i++) {
                    $("#" + divImage[i]).css("background-image", "url("+obj.P_Head+ ")");
                };
            });
        });
    }


};


//选择图片值更换事件
function selFile_change() {
    var selFile = $("#selFile");
    var btnFile = $("#btnFile");
    var btnUp = $("#btnUp");
    var lbHint = $("#lbHint");


        selFile.change(function () {
            //保存名称
            var fileName = selFile.val().split("/");
            fileName = fileName[0].split("\\");
            fileName = fileName[fileName.length - 1];

            var fileSuffix = fileName.split('.');
            fileSuffix = fileSuffix[fileSuffix.length - 1];

            switch (fileSuffix) {
                case "jpeg":
                case "jpg":
                case "png":
                    btnUp.click();
                    break;
                default:
                    btnFile.attr("title", "未选择图片");
                    lbHint.html("温馨提示：选择的文件格式有误，请重新选择！");
                    break;
            }
           

    });
}