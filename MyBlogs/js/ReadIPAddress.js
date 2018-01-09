/// <reference path="JQ_File/jquery-3.2.1.min.js" />
function LoadInfo() {
    var data = { "no": Number(encodeURI($(location).attr("href").split('=')[1])) };
    $.ajax({
        type: "get",
        data: data,
        url: "ashx/GetLoginLogByConn.ashx",
        success: function (ret) {
            var retData = $.parseJSON(ret);
            $.each(retData, function (i, obj) {
                $("#Log_No").html("编号（"+obj.Log_No+"）");
                $("#userName").html(obj.P_LoginName);
                $("#nickName").html(obj.GetPersonageInfo.P_NickName);
                $("#IPAddress").html(obj.Log_ipAddress);
                $("#Country").html(obj.Log_Country);
                $("#Province").html(obj.Log_Province);
                $("#City").html(obj.Log_City);
                $("#DateTime").html(obj.Log_Date);
            });
          
        }
    });
}