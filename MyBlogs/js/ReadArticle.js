/// <reference path="JQ_File/jquery-3.2.1.min.js" />



function LoadReadInfo() {
    var data = { "title": decodeURI($(location).attr("href").split('=')[1]) }
    $.ajax({
        type: "get",
        url: "ashx/GetArticleByConn.ashx",
        data:data,
        success: function (ret) {
            var retData = $.parseJSON(ret);
            var datas = { "no": "" }
            $.each(retData, function (i, obj) {
                $("#divTitle").html(obj.A_Title);
                $("#lbType").html(obj.A_DateTime);
                $("#lbDate").html(obj.A_TypeName);
                $("#divContent").html(obj.A_Content);
                datas.no = obj.A_No;
            });
            
            $.ajax({
                type: "get",
                url: "ashx/GetCommentByConn.ashx",
                data: datas,
                success: function (ret) {
                    $("#divAllComment").html(ret);
                }
            });
        }
    });
}

function btnOk_click() {
    $("#btnOk").click(function () {
        var data = {
            "nickName": $("#txtNickName").val(),
            "Comment": $("#txtComment_Content").val(),
            "articleNo": decodeURI($(location).attr("href").split('=')[1])
        }
        if (data.nickName=="") {
            alert("请输入昵称后评价！");
            return;
        }
        if (data.Comment == "") {
            alert("请输入评价内容！");
            return;
        }
         $.ajax({
                type: "get",
                data: data,
                url:"ashx/AddArticleComment.ashx",
                success:  function (ret) {
                    if (ret=="0") {
                        alert("评价成功！\n审核成功！");
                        $("#txtNickName").val("");
                        $("#txtComment_Content").val("");
                        LoadReadInfo();
                    } else {
                        alert("评价失败，中途出现问题，请联系管理员！");
                    }
                }
            });
        });
}
