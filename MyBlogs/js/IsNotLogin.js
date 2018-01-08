function isNotLogin() {
    $.ajax({
        type: "get",
        url: "../ashx/IsNotLogin.ashx",
        success: function (ret) {
            if (ret == 0) {
                window.location.href = "../Login.html";
            }
        }
    });
}