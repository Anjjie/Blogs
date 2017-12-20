/// <reference path="../JQ_File/jquery-3.2.1.min.js" />
function LoadInfo() {
    var $divContent = $("#divContent");
    var info = [
    { "name": "天天吃吃吃吃hi吃吃次hi什么鬼", "names": "Xlong", "content": "文章不错", "date": "2017-12-14" },
    { "name": "天气不错，出来散散心吧", "names": "Xlong", "content": "我的博客就是这个样子", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱上了大手大脚熬枯受淡极乐世界迪", "names": "Xlong", "content": "66666", "date": "2017-12-13" },
    { "name": "爱是承诺冰箱家族viwedpj", "names": "Xlong", "content": "666888", "date": "2017-12-12" },
    { "name": "阿萨德群翁群无所多错", "names": "Xlong", "content": "加油", "date": "2017-12-12" }];
    
    var ulOrli = '<ul class="ulContent_Title">'
                +'<li>文章</li>'
                +'<li>作者</li>'
                +'<li>内容</li>'
                +'<li>时间</li>'
                +'<li>&nbsp;</li></ul>';

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