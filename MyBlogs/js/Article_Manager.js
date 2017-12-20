/// <reference path="../JQ_File/jquery-3.2.1.min.js" />

function AddHintInfo() {
    var hint = '<div id="divHint" style="display:none; width:500px; position:absolute;left:50%;top:0;margin-left:-250px;background-color:#ffffff;border:1px solid rgba(0, 0, 0, 0.2)"><div style="width:100%;height:30px;background-color:#c6c6c6;line-height:30px;-moz-user-select:none;-ms-user-select:none;-webkit-user-select:none;user-select:none;"><label id="divHint_lbTitle" style="padding-left:10px;color:#ffffff;">标题</label></div><div style="word-wrap:break-word; width:100%;background-color:rgba(235, 235, 235, 0.29);"><lable style="padding-left:10px;color:#000000;" id="divHint_lbContent"></lable></div><div style="width:100%;height:25px;padding-top:10px; background-color:rgba(235, 235, 235, 0.29);text-align:right;"><input type="button" value="确定" id="hint_BtnOk" style="margin-right:5px;" /><input type="button" value="取消" id="hint_BtnCancel"style="margin-right:5px;" /></div></div>';
    var $body = $("body");
    $body.append(hint);
}

function divHint_show(title, titleFontColor, content, contentFontColor) {
    var $divHint_lbTitle = $("#divHint_lbTitle");
    var $divHint_lbContent = $("#divHint_lbContent");

    $("#hint_BtnCancel").show();
    $("#hint_BtnOk").show();

    $("#divHint").slideDown(1000);
    $divHint_lbTitle.html(title);
    $divHint_lbTitle.css("color", titleFontColor);
    $divHint_lbContent.html(content);
    $divHint_lbContent.css("color", contentFontColor);
}

function divHint_hide(title, titleFontColor, content, contentFontColor) {
    var $divHint_lbTitle = $("#divHint_lbTitle");
    var $divHint_lbContent = $("#divHint_lbContent");

    $("#hint_BtnCancel").hide();
    $("#hint_BtnOk").hide();

    $divHint_lbTitle.html(title);
    $divHint_lbTitle.css("color", titleFontColor);
    $divHint_lbContent.html(content);
    $divHint_lbContent.css("color", contentFontColor);
    $("#divHint").slideDown(1000, function () {
        $("#divHint").delay(1000).slideUp(1000);
    });
    

}

function divHint_Hide(isShow) {
    var $divHint = $("#divHint");
    var $hint_BtnOk = $("#hint_BtnOk");
    $divHint.slideUp(1000);
    switch (isShow) {
        case "show": $hint_BtnOk.show(); break;
        default: $hint_BtnOk.hide(); break;
    }
}

function showTopNavMore() {
    var $atopNav = $("#atopNav");
    var $divNavMore = $(".divNavMore");
    var $divtopNav = $(".divtopNav");
    var click = 0;

    $atopNav.click(function () {
        if (click == 1) {
            $divNavMore.slideUp(500);
            $divtopNav.html("▶&nbsp;更多");
            click = 0;
            return;
        }
        $divtopNav.html("▼&nbsp;更多");
        $divNavMore.slideDown(500);
        click = 1;
    });

    //$atopNav.blur(function () {
    //    click = 0;
    //    $divNavMore.slideUp(500, function () {
    //        $divtopNav.html("▶&nbsp;更多");
    //    });
    //});
    

}

function hideli_IdAuthorClickNum(isShow,liName) {
    var $liId = $(".liId");
    var $liAuthor = $(".liAuthor");
    var $liClickNum = $(".liClickNum");
    var $liSelect = $(".liSelect");

    var id_length = $liId.length;
    var author_length = $liAuthor.length;
    var clickNum_length = $liClickNum.length;
    var select_length = $liSelect.length;


    switch (liName) {
        case "id":
            switch (isShow) {
                case "hide":
                    for (var i = 0; i < id_length; i++)
                        $liId.eq(i).hide();
                    break;
                case "show":
                    for (var i = 0; i < id_length; i++)
                        $liId.eq(i).show();
                    break;
            }
            break;
        case "author":
            switch (isShow) {
                case "hide":
                    for (var i = 0; i < author_length; i++)
                        $liAuthor.eq(i).hide();
                    break;
                case "show":
                    for (var i = 0; i < author_length; i++)
                        $liAuthor.eq(i).show();
            }
            break;
        case "clicknum":
            switch (isShow) {
                case "hide":
                    for (var i = 0; i < clickNum_length; i++)
                        $liClickNum.eq(i).hide();
                    break;
                case "show":
                    for (var i = 0; i < clickNum_length; i++)
                        $liClickNum.eq(i).show();
                    break;
            }
            break;
        case "select":
            switch (isShow) {
                case "hide":
                    for (var i = 0; i < select_length; i++)
                        $liSelect.eq(i).hide();
                    break;
                case "show":
                    for (var i = 0; i < select_length; i++)
                        $liSelect.eq(i).show();
                        $divNavMore.slideUp(500);
                        $divtopNav.html("▶&nbsp;更多");
                        click = 0;
                    break;
            }
            break;
        default:
            switch (isShow) {
                case "hide":
                    for (var i = 0; i < id_length; i++) 
                        $liId.eq(i).hide();

                    for (var i = 0; i < author_length; i++) 
                        $liAuthor.eq(i).hide();

                    for (var i = 0; i < clickNum_length; i++) 
                        $liClickNum.eq(i).hide();
                    for (var i = 0; i < select_length; i++) 
                        $liSelect.eq(i).hide();
                    break;
                case "show":
                    for (var i = 0; i < id_length; i++) 
                        $liId.eq(i).show();

                    for (var i = 0; i < author_length; i++) 
                        $liAuthor.eq(i).show();

                    for (var i = 0; i < clickNum_length; i++) 
                        $liClickNum.eq(i).show();
                    for (var i = 0; i < select_length; i++)
                        $liSelect.eq(i).show();
                   
                    break;
            }
            break;

    }

    
    

}

function showli_IdAuthorClickNum() {
    var $chkId = $("#chkId");
    var $chkAuthor = $("#chkAuthor");
    var $chkClickNum = $("#chkClickNum");
    var $chkAll_Nav = $("#chkAll_Nav");
    var $chkSel_Nav = $("#chkSel_Nav");

    var $liDeleteSel = $("#liDelectSel");

    var $divNavMore = $(".divNavMore");
    var $divtopNav = $(".divtopNav");


    $chkId.click(function () {
        if ($chkId.is(":checked")) {
            hideli_IdAuthorClickNum("show", "id");
        } else {
            hideli_IdAuthorClickNum("hide", "id");
        }
    });
    $chkAuthor.click(function () {
        if ($chkAuthor.is(":checked")) {
            hideli_IdAuthorClickNum("show", "author");
        } else {
            hideli_IdAuthorClickNum("hide", "author");
        }
    });
    $chkClickNum.click(function () {
        if ($chkClickNum.is(":checked")) {
            hideli_IdAuthorClickNum("show", "clicknum");
        } else {
            hideli_IdAuthorClickNum("hide", "clicknum");
        }
    });
    $chkAll_Nav.click(function () {
        if ($chkAll_Nav.is(":checked")) {
            hideli_IdAuthorClickNum("show", "");
            $chkId.prop("checked", true);
            $chkAuthor.prop("checked", true);
            $chkClickNum.prop("checked", true);
            $chkSel_Nav.prop("checked", true);
            $liDeleteSel.show();
            selAllCheck();

            $divNavMore.delay(500).slideUp(500);
            $divtopNav.html("▶&nbsp;更多");

        } else {
            hideli_IdAuthorClickNum("hide", "");
            $chkId.prop("checked", false);
            $chkAuthor.prop("checked", false);
            $chkClickNum.prop("checked", false);
            $chkSel_Nav.prop("checked", false);
            $liDeleteSel.hide();
           
        }
    });
    $chkSel_Nav.click(function () {
        if ($chkSel_Nav.is(":checked")) {
            $liDeleteSel.show();
            $divNavMore.delay(500).slideUp(500);
            $divtopNav.html("▶&nbsp;更多");
            selAllCheck();
            hideli_IdAuthorClickNum("show", "select");
            
        } else {
            hideli_IdAuthorClickNum("hide", "select");
            $liDeleteSel.hide();
        }
    });
}

function LoadData() {
    var $divContent = $("#divContent");
    var $divContentBottom = $(".divContentBottom");

    var ulAndli = "";
    var count = 0;

    $.getJSON("../ashx/GetArticleAll.ashx", function (data) {
        $.each(data, function (i, obj) {
            
            ulAndli += '<ul class="ulContent_Content"><li class="liSelect"><input type="checkbox" name="chkSel" value="" /></li>'
            + '<li class="liId" name="no">&nbsp;' + (obj.A_No + 1) + '</li>'
            + '<li class="liTitle">&nbsp;' + obj.A_Title + '</li>'
            + '<li class="liAuthor">' + obj.A_Author + '</li>'
            //+ '<li class="liArticleContent">' + obj.A_Content + '</li>'
            + '<li class="liArticleType">' + obj.A_TypeName + '</li>'
            + '<li class="liArticleTime">' + obj.A_DateTime + '</li>'
            + '<li class="liClickNum">1</li>'
            + '<li class="liComm"> <a name="aBtnCompile" href="javascript:;" >编辑</a>&nbsp;<a name="aBtnDelete" href="javascript:;" >删除</a></li></ul>';
            count = i;
        });
        $divContent.html(ulAndli);

        hideli_IdAuthorClickNum("hide", "");
        if (count >= 15) {
            $divContentBottom.show();
        }
        deleteData();
    });

}

function selAllCheck() {
    var $chkSel_All = $("#chkSel_All");
    var $chkSel = $("input[name='chkSel']");
    $chkSel_All.click(function () {
        if ($chkSel_All.is(":checked")) {
            for (var i = 0; i < $chkSel.length; i++) {
                $chkSel.eq(i).prop("checked",true)
            }
        } else {
            for (var i = 0; i < $chkSel.length; i++) {
                $chkSel.eq(i).prop("checked", false)
            }
        }
    });
}

function deleteData() {
    var $aBtnDelete = $("a[name='aBtnDelete']");
    var $aDelectSel = $("#aDelectSel");
    var $no = $("li[name='no']");

    $aBtnDelete.click(function () {
        var filtration = 0;
        var no = $no.eq($(this).index("a[name='aBtnDelete']")).html();
        no = ((no.split(';')[1]) - 1);
        var data = {"commtype":0,"no":no};
        divHint_show("删除提示", "#ffffff", "你是否要删除当前选择的信息?", "");

        var $hint_BtnCancel = $("#hint_BtnCancel");
        var $hint_BtnOk = $("#hint_BtnOk");
        $hint_BtnOk.click(function () {
            filtration++;
            if (filtration == 1) {
                $.ajax({
                    type: "get",
                    url: "../ashx/DeleteArticle.ashx",
                    data: data,
                    success: function (ret) {
                        divHint_hide("删除提示", "#ffffff", ret, "red"); LoadData();
                    }
                });
            }
        });
        $hint_BtnCancel.click(function () {
            divHint_Hide("show");
        });

    });

    $aDelectSel.click(function () {
        var $chkSel = $("input[name='chkSel']:checked");
        var count = $chkSel.length;
        if (count <= 0) {
            divHint_hide("系统提示", "#ffffff", "对不起，请选择删除内容再点击[一键删除]!", "red");
            return;
        }

        
        //var no = $no.eq($(this).index("a[name='aBtnDelete']")).html();
        //alert(no);
        var no = "";

        $chkSel.each(function () {
            no += $no.eq($(this).index("input[name='chkSel']")).html();
        });
        no = no.split('&nbsp;');
        var data = { "commtype": 1, "no": "" };
        for (var i = 1; i < no.length; i++) {
            data.no += (no[i]-1) + ",";
        }
        data.no = data.no.substring(0, data.no.length-1)
        
        divHint_show("一键删除", "#ffffff", "&nbsp;你是否要删除当前选择的所有信息?<br />&nbsp; 确定后将永久删除当前选择信息。", "");

        var $hint_BtnCancel = $("#hint_BtnCancel");
        var $hint_BtnOk = $("#hint_BtnOk");
        var filtration = 0;
        $hint_BtnOk.click(function () {
            filtration++;
            alert(filtration);
            if (filtration == 1) {
                
                alert("显示当前判断");
                //$.ajax({
                //    type: "get",
                //    url: "../ashx/DeleteArticle.ashx",
                //    data: data,
                //    success: function (ret) {
                //        divHint_hide("系统提示", "#ffffff", ret, "red"); LoadData();
                //    }
                //});
                divHint_Hide("show");
            }
            
        });

        $hint_BtnCancel.click(function () {
            divHint_Hide("show");
        });

    });

}