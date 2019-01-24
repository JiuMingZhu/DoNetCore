// 一言Api
fetch('https://v1.hitokoto.cn')
    .then(function (res) {
        return res.json();
    })
    .then(function (data) {
        var hitokoto = document.getElementById('hitokoto');
        hitokoto.innerText = data.hitokoto;
        var hitokoto_from = document.getElementById('hitokoto_from')
        hitokoto_from.innerText = '——' + data.from;
    })
    .catch(function (err) {
        console.error(err);
    })

/* 鼠标特效 */
var a_idx = 0;
jQuery(document).ready(function ($) {
    $("body").click(function (e) {
        var a = new Array("富强", "民主", "文明", "和谐", "自由", "平等", "公正", "法治", "爱国", "敬业", "诚信", "友善");
        var $i = $("<span />").text(a[a_idx]);
        a_idx = (a_idx + 1) % a.length;
        var x = e.pageX,
            y = e.pageY;
        $i.css({
            "z-index": 99999999999999999999999999999999999999999999999999999999999999999999999999,
            "top": y - 20,
            "left": x,
            "position": "absolute",
            "font-weight": "bold",
            "color": "#ff6651"
        });
        $("body").append($i);
        $i.animate({
            "top": y - 180,
            "opacity": 0
        },
            1500,
            function () {
                $i.remove();
            });
    });
});

/* MarkDown文章渲染 */
//marked.setOptions({
//    renderer: new marked.Renderer(),
//    gfm: true,
//    tables: true,
//    breaks: false,
//    pedantic: false,
//    sanitize: false,
//    smartLists: true,
//    smartypants: false
//});

//marked.setOptions({
//    highlight: function (code) {
//        return hljs.highlightAuto(code).value;
//    }
//});

//var temp = document.getElementById('markdown').innerText
//document.getElementById('markdown').innerHTML = marked(temp);

var markdownTexts = document.getElementsByClassName('markdown')
for (var i = 0; i < markdownTexts.length; i++) {
    markdownTexts[i].innerHTML = marked(markdownTexts[i].innerText);
}

hljs.initHighlightingOnLoad();