// 一言Api
fetch('https://v1.hitokoto.cn')
.then(function (res){
  return res.json();
})
.then(function (data) {
  var hitokoto = document.getElementById('hitokoto');
  hitokoto.innerText = data.hitokoto; 
  var hitokoto_from = document.getElementById('hitokoto_from')
  hitokoto_from.innerText='——'+data.from;
})
.catch(function (err) {
  console.error(err);
})


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