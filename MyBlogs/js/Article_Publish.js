/// <reference path="../JQ_File/jquery-3.2.1.min.js" />

function CloseHint() {

    window.onbeforeunload = function () {
            if ( $("#txtTitle").val()!="") {
                return "确定要离开吗？离开后当前输入的数据见清除掉！";
            } else if ($("#Content_iframe").contents().find("body").html()!="") {
                return "确定要离开吗？离开后当前输入的数据见清除掉！";
            }
    }
   
}

function GetColor() {
    var $colpick_new_color = $(".colpick_new_color");
    var $colpick_submit = $(".colpick_submit");
    var $One_FontColor_A = $(".One_FontColor_A");
    var $colpick = $(".colpick");

    $colpick_submit.click(function () {
        var color = $colpick_new_color.css("background-color");
        $One_FontColor_A.css("background-color", color);
        foreColor(color);
        $colpick.hide();
    });
}

function One_table_AddUrl_Click() {
    var $One_table_AddUrl = $(".One_table_AddUrl");
    var $Background_AddUrl = $(".Background_AddUrl");
    var $btnUrlOk = $("#btnUrlOk");
    var $txtUrl = $("#txtUrl");
    var $txtUrlTitle = $("#txtUrlTitle");
    var $btnUrlReset = $("#btnUrlReset");
    var $One_a_AddUrl = $("#One_a_AddUrl");

    var click = 1;
    
    /*$One_a_AddUrl.click(function () {
        if (click!=1) {
            $Background_AddUrl.hide();
            $One_table_AddUrl.removeClass("backgroundColor");
            click--;
            return;
        }
        $Background_AddUrl.show();
        $One_table_AddUrl.addClass("backgroundColor");
        click++;
    });*/

    $One_a_AddUrl.focus(function () {
        $Background_AddUrl.show();
        $One_table_AddUrl.addClass("backgroundColor");
        return;
    });

    $One_a_AddUrl.blur(function () {
        $Background_AddUrl.hide();
        $One_table_AddUrl.removeClass("backgroundColor");
        return;
    });

    $btnUrlOk.click(function () {
        $Background_AddUrl.hide();
        $One_table_AddUrl.removeClass("backgroundColor");
        click--;
        createLink($txtUrlTitle.val(), "http://" + $txtUrl.val());
    });

    $btnUrlReset.click(function () {
        $txtUrlTitle.val("");
        $txtUrl.val("");
    });

}

function editors(command,isTrue,isNull){
    editor = document.getElementById("Content_iframe").contentWindow;
    editor.document.execCommand(command, isTrue, isNull);
}

function bold() {
    editors("bold",true,null);
}

function italic() {
    editors("italic", true, null);
}

function strikeThrough() {
    editors("strikeThrough", true, null);
}

function insertUnorderedList() {
    editors("insertUnorderedList", true, null);
}

function insertOrderedList() {
    editors("insertOrderedList", true, null);
}

function justifyLeft() {
    editors("justifyLeft", true, null);
}

function justifyCenter() {
    editors("justifyCenter", true, null);
}

function justifyRight() {
    editors("justifyRight", true, null);
}

function createLink(title,url) {
    editors("insertHTML", true, "<a href='" + url + "'>" + title + "</a>  &nbsp;&nbsp;&nbsp;   ");
}

function unlink() {
    editors("unlink", true, null);
};

function insertImage(url) {
    editors("insertImage", true, url);
}

function formatBlock(block) {
    editors("formatBlock", true, block);
}

function foreColor(color) {
    editors("foreColor", true, color);
}

function fontName(name) {
    editors("fontName", true, name);
}

function fontSize(size) {
    editors("fontSize", true, size);
}

function btnUp_Click() {
    var $btnUp = $("#btnUp");
    var $selFile = $("#selFile");

    var $Background_AddImage = $(".Background_AddImage");
    

    
    $btnUp.click(function () {
        $selFile.click();
    });

    $selFile.change(function () {
        var filename = $selFile.val().split('\\');
        //filename = filename[0].split('/');
        var fname = filename[filename.length - 1];
        var suffix = fname.split('.');
        suffix = suffix[suffix.length - 1];
        var name = $(location).attr("href").split('=')[1];

        switch (suffix) {
            case "jpg":
            case "jpeg":
            case "png":
                $btnUp.attr("title", fname);
                //showFileHint("#000000", "已选择文件：" + fname);
                
                //判断当前浏览器是否能使用
                if (window.FormData) {
                    //创建FormData表单对象
                    var formData = new FormData();

                    //获取文件添加进去
                    formData.append("upfile", document.getElementById("selFile").files[0]);

                    //创建XMLHttpRequest对象
                    var xmlHttp = new XMLHttpRequest();
                    xmlHttp.open("POST", "../ashx/upFile.ashx?name=" + name );
                    
                    //进度条
                    xmlHttp.upload.addEventListener("progress", upFileProgress, false);
                    //是否上传成功
                    xmlHttp.onload = function () {
                        if (xmlHttp.status==200) {
                            showFileHint("#000000", "文件上传成功！");
                            $Background_AddImage.fadeOut(1000);
                            $(".One_table_AddImage").removeClass("backgroundColor");
                            eval("var ret=" + xmlHttp.responseText);
                            var url = "../images/SaveImage/" + name + "/" + ret.fileName;
                            insertImage(url);
                            $btnUp.attr("title", "未选择图片");
                            $selFile.val("");
                        } else {
                            showFileHint("red", "文件上传失败！");
                        }
                    };
                    xmlHttp.send(formData);
                }
                
                previewImage();
                
                break;
            default:
                $selFile.val("");
                showFileHint("red","选择文件有误，请重新选择！");
                break;
        }



    });

    function previewImage() {
        // 检查是否支持FileReader对象：预览图片
        if (typeof FileReader != 'undefined') {

            var acceptedTypes = {
                'image/png': true,
                'image/jpeg': true,
                'image/gif': true
            };

            //预览图片
            if (acceptedTypes[document.getElementById('selFile').files[0].type] === true) {

                var reader = new FileReader();
                reader.onload = function (event) {
                    var image = new Image();
                    image.src = event.target.result;
                    image.width = 90;
                    //document.body.appendChild(image);
                    $("#AddImage_Show").html(image);
                };
                reader.readAsDataURL(document.getElementById('selFile').files[0]);

            }
        } else {
            showFileHint("red","不支持预览");
        }
    }

    function upFileProgress(evt) {
        var $AddImage_progress = $("#AddImage_progress");
        var $AddImage_Number = $("#AddImage_Number");

        $("#AddImage_progress").css("width", "0%");
        if (evt.lengthComputable) {
            var thisProgress = Math.round(evt.loaded * 100 / evt.total);
            var per = thisProgress + "%";
            $("#AddImage_progress").css("width", per);
            //$AddImage_progress.css("width", per);
            $AddImage_Number.html(per);
            
        } else {
            showFileHint("red","计算出错！");
        }

    }

    function showFileHint(color,content) {
        var $divHint = $("#divHint");
        var $divHint_Content = $("#divHint_Content");
        $divHint.show();
        $divHint_Content.css("color", color);
        $divHint_Content.html(content);
        $divHint.delay(3000).fadeOut(500);

    }

}

function One_table_AddImage_click() {
    var $One_table_AddImage = $(".One_table_AddImage");
    var $Background_AddImage = $(".Background_AddImage");

    var $One_a_AddImage = $("#One_a_AddImage");

    $One_a_AddImage.focus(function () {
        $One_table_AddImage.addClass("backgroundColor");
        $Background_AddImage.show();
        
    });

    $One_a_AddImage.blur(function () {
        $One_table_AddImage.removeClass("backgroundColor");
        $Background_AddImage.hide();
    });


    //var click = 1;

    //$One_table_AddImage.click(function () {
    //    if (click==1) {
    //        $One_table_AddImage.addClass("backgroundColor");
    //        $Background_AddImage.show();
    //        click++;
    //    } else {
    //        $One_table_AddImage.removeClass("backgroundColor");
    //        $Background_AddImage.hide();
    //        click--;
    //    }
       
    //});


   
}

function Load_Paragraph_Click() {
    var $setParagraph = $("#setParagraph");

    var AllTitle = ["标题1", "标题2", "标题3", "标题4", "标题5", "标题6"];
    var AllFont_Size = ["25","20","15","12","10","5"];
    var AllValie = ["h1", "h2", "h3", "h4", "h5", "h6"];

    var option = "<option>标题</option>";
    for (var i = 0; i < AllTitle.length; i++) {
        option += "<option style='font-size:" + AllFont_Size [i]+ "pt;font-weight:550;'>" + AllTitle[i] + " </option>";
    }
    $setParagraph.html(option);

    $setParagraph.change(function () {
        var val = "";
        switch ($setParagraph.val()) {
            case AllTitle[0]:
                val=AllValie[0];
                break;
            case AllTitle[1]:
                val = AllValie[1];
                break;
            case AllTitle[2]:
                val = AllValie[2];
                break;
            case AllTitle[3]:
                val = AllValie[3];
                break;
            case AllTitle[4]:
                val = AllValie[4];
                break;
            case AllTitle[5]:
                val = AllValie[5];
                break;
            case AllTitle[6]:
                val = AllValie[6];
                break;
            default:
                val = "p";
                break;
        }

        var browser = window.navigator.userAgent;
        if (browser.indexOf('MSIE')>=0) {
            val = "<" + val + ">"
        }
        formatBlock(val);
    });
}

function Load_setFamily_Click() {
    var $setFamily = $("#setFamily");

    var family = ["宋体", "仿宋", "黑体", "楷体", "隶书", "华文彩云",
        "华文细黑", "华文新魏", "华文行楷", "华文中宋", "幼圆",
        "Arial", "Comic Sans MS", "Courier New", "Tahoma", "Times New Roman", "Wingdings"];
    var f_length = family.length;

    var option = "<option>字体</option>";

    for (var i = 0; i < f_length; i++) {
        option += "<option style='font-family:" + family[i] + "'>" + family[i] + "</option>";
    }

    $setFamily.html(option);

    $setFamily.change(function () {
        fontName($setFamily.val());
    });

}

function Load_setFontSize_Click() {
    var $setFontSize = $("#setFontSize");

    var size = ["特小", "较小", "小", "中", "大", "较大", "特大"];
    var s_length = size.length;

    var option = "<option >字体大小</option>";

    for (var i = 0; i < s_length; i++) {
        option += "<option>" + size[i] + "</option>";
    }

    $setFontSize.html(option);

    $setFontSize.change(function () {
        var setSize = "";
        switch ($setFontSize.val()) {
            case size[0]:
                setSize = 1;
                break;
            case size[1]:
                setSize = 2;
                break;
            case size[2]:
                setSize = 3;
                break;
            case size[3]:
                setSize = 4;
                break;
            case size[4]:
                setSize = 5;
                break;
            case size[5]:
                setSize = 6;
                break;
            case size[6]:
                setSize = 7;
                break;
        }
        fontSize(setSize);
    });

}

function Load_setType() {

    $.ajax({
        type: "get",
        url: "../ashx/GetArticleTypeAll.ashx",
        success: function (ret) {
            $("#setType").html(ret);
        }
    });
}


