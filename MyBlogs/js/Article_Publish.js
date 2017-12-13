/// <reference path="../JQ_File/jquery-3.2.1.min.js" />

function CloseHint() {
    window.onbeforeunload = function () {
        //return "你确认离开吗？";
            var n = window.event.screenX - window.screenLeft;

            var b = n > document.documentElement.scrollWidth - 20;

            if (!(b && window.event.clientY < 0 || window.event.altKey)) {
                window.event.returnValue = "真的要刷新页面么？";
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

    var click = 1;
    $One_table_AddUrl.click(function () {
        if (click!=1) {
            $Background_AddUrl.hide();
            $One_table_AddUrl.removeClass("backgroundColor");
            click--;
            return;
        }
        $Background_AddUrl.show();
        $One_table_AddUrl.addClass("backgroundColor");
        click++;
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

function foreColor(color) {
    editors("foreColor", true, color);
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

    var click = 1;

    $One_table_AddImage.click(function () {
        if (click==1) {
            $One_table_AddImage.addClass("backgroundColor");
            $Background_AddImage.show();
            click++;
        } else {
            $One_table_AddImage.removeClass("backgroundColor");
            $Background_AddImage.hide();
            click--;
        }
       
    });
   
}

function Load_Paragraph_Click() {
    var $setParagraph = $("#setParagraph");

    var AllTitle = ["标题1", "标题2", "标题3", "标题4", "标题5", "标题6"];
    var AllValie = ["title1", "title2", "title3", "title4", "title5", "title6"];

    var option = "<option valie='段落'>段落</option>";
    for (var i = 0; i < AllTitle.length; i++) {
        option += "<option valie='" + AllValie[i] + "'>" + AllTitle[i] + "</option>";
    }
    $setParagraph.html(option);


    $setParagraph.select(function () {

    });
}



