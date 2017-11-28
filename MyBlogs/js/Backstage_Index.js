/// <reference path="../JQ_File/jquery-3.2.1.min.js" />
//设置显示顶部下拉框
function topPull_Down(){
	var $liLoginName=$("#liLoginName");
	var $Pull_Down1=$("#Pull_Down1");
	$liLoginName.on({
		"mousemove":function(){$Pull_Down1.css("display","block")},
		"mouseout":function(){$Pull_Down1.css("display","none")}
	});
}
//设置动画显示遮掩层
function Show_ShadowNavgation(){
	var $divMore=$("#divMore");
	var $Shadow_All=$("#Shadow_All");
	var $Shadows_All=$("#Shadows_All");
	var $Shadow_leftNavgation=$("#Shadow_leftNavgation");
	$Shadow_leftNavgation.css("margin-left","-300px");
	$divMore.click(function(){
		$Shadow_All.css("display","block");
		$Shadows_All.css("display","block");
		$Shadow_leftNavgation.animate({"margin-left":"0"},500);
	});
	$Shadows_All.click(function(){
		$Shadow_leftNavgation.animate({"margin-left":"-300px"},500,function(){
			$Shadow_All.css("display","none");
			$Shadows_All.css("display","none");
		});
	});
	
	
}
//更换嵌套页
function Update_iframe(){
	var $Content_iframe=$("#Content_iframe");
	var $Shadow_Navgation_li=$(".Shadow_Navgation_li");
	$Shadow_Navgation_li.click(function () {
	    var $label_LoginName = $("#label_LoginName");
	    var val = $(this).data("a") + "?name=" + $label_LoginName.data("LoginName");
		$Content_iframe.attr("src",val);
	});
	
}

//获取用户信息
function getAllUserInfo() {
    var $label_LoginName = $("#label_LoginName");
    var $HeadImages = $("#HeadImages");
    var $Content_iframe = $("#Content_iframe");

    var name = $(location).attr("href").split("=");
    var val = { "name": name[1] };
   
    $.getJSON("../ashx/GetUserInfo.ashx",val,
         function (data) {
             $.each(data, function (i,obj) {
                 var imageUrl = "url(" + obj.P_Head + ")";
                 $Content_iframe.attr("src", "Backstage_Personage.html?name=" + obj.P_LoginName);
                 //alert(imageUrl);
                 $label_LoginName.html("超级管理员");
                 $label_LoginName.data("LoginName", obj.P_LoginName);
                 $HeadImages.css("background-image", imageUrl);
             });}
        );


  
}









