/// <reference path="Personage_UpdatePassword.html" />
/// <reference path="ReadArticle.html" />
/// <reference path="JQ_File/jquery-3.2.1.min.js" />
function DataTime() {
    var canvas = document.getElementById("timeCanvas");
    var ctx = canvas.getContext("2d");
    ctx.strokeStyle = '#00ffff';
    ctx.lineWidth = 17;
    ctx.shadowBlur = 15;
    ctx.shadowColor = '#00ffff'

    function degToRad(degree) {
        var factor = Math.PI / 180;
        return degree * factor;
    }

    function renderTime() {
        var now = new Date();
        var today = now.toDateString();
        var time = now.toLocaleTimeString();
        var hrs = now.getHours();
        var min = now.getMinutes();
        var sec = now.getSeconds();
        var mil = now.getMilliseconds();
        var smoothsec = sec + (mil / 1000);
        var smoothmin = min + (smoothsec / 60);

        //Background
        gradient = ctx.createRadialGradient(250, 250, 5, 250, 250, 300);
        gradient.addColorStop(0, "cadetblue");
        gradient.addColorStop(1, "cadetblue");
        ctx.fillStyle = gradient;
        //ctx.fillStyle = 'rgba(0 ,00 , 00, 1)';
        ctx.fillRect(0, 0, 500, 500);
        //Hours
        //ctx.beginPath();
        //ctx.arc(80, 80, 50, degToRad(270), degToRad((hrs * 30) - 90));
        //ctx.stroke();
        ////Minutes
        //ctx.beginPath();
        //ctx.arc(80, 80, 30, degToRad(270), degToRad((smoothmin * 6) - 90));
        //ctx.stroke();
        ////Seconds
        //ctx.beginPath();
        //ctx.arc(80, 80, 10, degToRad(270), degToRad((smoothsec * 6) - 90));
        //ctx.stroke();
        ////Date
        ctx.font = "25px ";
        ctx.fillStyle = 'rgba(255, 255, 255, 1)'
        ctx.fillText(today, 30, 60);
        //Time
        ctx.font = "25px  Bold";
        ctx.fillStyle = 'rgba(255, 255, 255, 1)';
        ctx.fillText(time + ":" + mil, 70,100);

    }
    setInterval(renderTime, 40);
}

function LoadData() {
    var $AddContent_Div = $("#AddContent_Div");
    var divDataInfo = "";
    $.ajax({
        type: "get",
        url: "ashx/GetArticleAllByDesc.ashx",
        success: function (retData) {
            var data = $.parseJSON(retData);
            $.each(data, function (i, obj) {
                if (i<=10) {
                    divDataInfo += "<div class='content_Data'>"
                 + "<div class='content_Title' data-no='" + obj.A_No + "'>" + obj.A_Title + "</div>"
                    + "<div class='content_DataContent'>"
                        + "<ul>"
                            + "<li class='content_Image' style=' background-image:url(images/SaveImage/" + obj.A_CoverImageUrl + ");'></li>"
                            + "<li class='content_DataInfo'>"
                                + "<ul>"
                                    + "<li class='DataInfo_content' >" + obj.A_Content+ "</li>"
                                    + "<li class='DateTimeAndRead'>"
                                        + "<ul>"
                                            + "<li class='content_Type'>" + obj.A_TypeName + "</li>"
                                            + "<li class='content_DateTime'>" + obj.A_DateTime + "</li>"
                                            + "<li class='liBtn'>"
                                                + "<input class='ReadAll' name='ReadAll' type='button' value='阅读全部 >>' />"
                                            + "</li>"
                                        + "</ul>"
                                    + "</li>"
                                + "</ul>"
                            + "</li>"
                        + "</ul>"
                    + "</div>"
                + "</div>";
                }
            });
           
            $AddContent_Div.html(divDataInfo);
            ReadAll_click();
        }
    });
}

function ReadAll_click() {
    $(".ReadAll").click(function () {
        window.open("ReadArticle.html?n=" + $(".content_Title").eq($(this).index(".ReadAll")).data("no"),"top");
    });
}
