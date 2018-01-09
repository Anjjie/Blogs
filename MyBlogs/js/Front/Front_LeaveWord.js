function LoadLeaveWordInfo() {
    $.ajax({
        type: "get",
        url: "ashx/GetLeaveWordInfo.ashx",
        success: function (ret) {
            $("#divLeaveWordContent").html(ret);
        }
    });
}

function btnSend_Cleck() {
   
    $("#btnSend").click(function () {
        var nickName = $("#txtNickName").val();
        var content = $("#txtLevaeWordContent").val();
        if (content == "") {
            alert("留言内容不能为空！！！");
            return;
        }
        if (nickName == "") {
            alert("昵称不能为空！！！");
            return;
        }
        var data = {
            "nickName": nickName,
            "content": content
        };
        $.ajax({
            type: "get",
            url: "ashx/AddLeaveWord.ashx",
            data:data,
            success: function (ret) {
                alert(ret);
                if (ret!="留言失败！") {
                    LoadLeaveWordInfo();
                    $("#txtNickName").val("");
                    $("#txtLevaeWordContent").val("");
                }
            }
        });

    });
}