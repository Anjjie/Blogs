function NavClick() {
    var $nav_Click = $(".nav_Click");
    var urlName = ["Front_Index", "Front_AboutMe", "Front_Article", "Front_Everyday", "Front_LeaveWord"];
    var url = "";
    $nav_Click.click(function () {
        url = "../../" + urlName[$(this).index()] + ".html";
        window.location.href = url;
    });
}