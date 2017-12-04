/// <reference path="../JQ_File/jquery-3.2.1.min.js" />

//加载相关登录用户的信息
function LoadInfo() {
    var name = { "name": $(location).attr("href").split("=")[1] };
    var $divHead = $("#divHead");
    var $divArticleCount = $("#divArticleCount");
    var $divMassageCount = $("#divMassageCount");
    var $ulRecentlyArticle = $("#ulRecentlyArticle");
    var $divLoginLogContent = $("#divLoginLogContent");


    $.getJSON("../ashx/GetUserInfo.ashx", name,
        function (data) {
            var articleli = "";

            $.each(data, function (i, obj) {
                var imageUrl = "url(" + obj.P_Head + ")";
                $divHead.css("background-image", imageUrl);
                $divHead.html(obj.P_LoginName);

                $.getJSON("../ashx/GetArticleAll.ashx", function (data) {
                    $.each(data, function (i, obj) {
                        $divArticleCount.html(i + 1);
                    });
                    $.getJSON("../ashx/GetMassageAll.ashx", function (data) {
                        $.each(data, function (i, obj) {
                            $divMassageCount.html(i + 1);
                        });
                        $.getJSON("../ashx/GetArticleAllByDesc.ashx", function (data) {
                            $.each(data, function (i, obj) {
                                if ((i + 1) <= 10) {
                                    articleli += "<li class='liArticleContent'>" + obj.A_Title + "</li>";
                                }
                                $ulRecentlyArticle.html(articleli);
                            });


                            $.getJSON("../ashx/SelectLoginLogDesc.ashx",name, function (data) {
                                var addulorli = " <ul class='ulLoginLog'>"
                                           + "<li class='liLoginLogTitle' style='flex:2;'>IP</li>"
                                           + "<li class='liLoginLogTitle'>国家</li>"
                                           + "<li class='liLoginLogTitle'>省份</li>"
                                           + "<li class='liLoginLogTitle'>城市</li>"
                                           + "<li class='liLoginLogTitle' style='flex:2;'>时间</li>"
                                            + "<li class='liLoginLogTitle'><a href='#'>更多</a></li>"
                                        + "</ul>";
         
                                $.each(data, function (i, obj) {
                                    addulorli += " <ul class='ulLoginLog'>"
                                           + "<li class='liLoginLog' style='flex:2;'>" + obj.Log_ipAddress + "</li>"
                                           + "<li class='liLoginLog'>" + obj.Log_Country + "</li>"
                                           + "<li class='liLoginLog'>" + obj.Log_Province + "</li>"
                                           + "<li class='liLoginLog'>" + obj.Log_City + "</li>"
                                           + "<li class='liLoginLog' style='flex:2;'>" + obj.Log_Date.split(" ")[0] + "</li>"
                                           + "<li class='liLoginLog'><a href='#'>查看详细</a></li>"
                                        + "</ul>";
                                });
                                $divLoginLogContent.html(addulorli);
                            });
                        });
                    });
                });

            });
        }
       );
   
}
//获取登录值
function saveName() {
    var $left_li = $(".left_li");
    $left_li.data("LoginName", $(location).attr("href").split("=")[1]);
}

//导航选择显示页面
function leftNavgation_Click() {
    var $left_li = $(".left_li");
    $left_li.click(function () {
		switch($(this).html()) {
			case "个人资料":
			    window.location.href = "Backstage_Personage.html?name=" + $(this).data("LoginName");
				break;
			case "安全设置":
			    window.location.href = "Backstage_PersonageSecurity.html?name=" + $(this).data("LoginName");
				break;
		}

	});
}

