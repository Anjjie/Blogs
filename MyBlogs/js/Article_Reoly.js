/// <reference path="../JQ_File/jquery-3.2.1.min.js" />
function LoadInfo() {
    var $divContent = $("#divContent");
    var info = [
    { "name": "6666", "names": "丑八怪", "content": "感谢", "date": "2017-12-14" },
    { "name": "1111", "names": "王尼玛", "content": "感谢", "date": "2017-12-13" },
    { "name": "2222", "names": "asdw", "content": "感谢", "date": "2017-12-13" },
    { "name": "3333", "names": "qq的爱", "content": "感谢", "date": "2017-12-13" },
    { "name": "4444", "names": "天上地下", "content": "感谢", "date": "2017-12-13" },
    { "name": "5555", "names": "java语言最流弊", "content": "感谢", "date": "2017-12-13" },
    { "name": "6666", "names": "php世界最好的语言", "content": "感谢", "date": "2017-12-13" },
    { "name": "7777", "names": "啥子", "content": "感谢", "date": "2017-12-13" },
    { "name": "8888", "names": "咳咳", "content": "感谢", "date": "2017-12-13" },
    { "name": "9999", "names": "奥斯卡骄傲", "content": "感谢", "date": "2017-12-13" },
    { "name": "123123", "names": "艾莎打网球", "content": "感谢", "date": "2017-12-13" },
    { "name": "234234", "names": "消除星星", "content": "感谢", "date": "2017-12-13" },
    { "name": "567567", "names": "企鹅额", "content": "感谢", "date": "2017-12-13" },
    { "name": "677567viwedpj", "names": "驱蚊器翁", "content": "感谢", "date": "2017-12-12" },
    { "name": "56434", "names": "UI噢UI", "content": "感谢", "date": "2017-12-12" }];

    var ulOrli = '<ul class="ulContent_Title">'
                + '<li>评论内容</li>'
                + '<li>昵称</li>'
                + '<li>回复内容</li>'
                + '<li>时间</li>'
                + '<li>&nbsp;</li></ul>';

    var count = info.length;
    for (var i = 0; i < count; i++) {
        ulOrli += "<ul class='ulContent_Content'>";
        ulOrli += "<li>" + info[i].name + "</li><li>" + info[i].names + "</li>"
            + "<li>" + info[i].content + "</li><li>" + info[i].date + "</li>";
        ulOrli += "<li><a href='javascript:;'>查看</a>&nbsp;&nbsp;<a href='javascript:;'>回复</a> </li></ul>";
    }
    ulOrli += '<ul class="ulContent_Botton"><li>'
                + '<a href="javascript:;" >首页</a>&nbsp;&nbsp;'
                + '<a href="javascript:;" >上一页</a>&nbsp;&nbsp;'
                + '<a href="javascript:;" >下一页</a>&nbsp;&nbsp;'
                + '<a href="javascript:;" >尾页</a>'
                + '</li></ul>';
    $divContent.html(ulOrli);

}