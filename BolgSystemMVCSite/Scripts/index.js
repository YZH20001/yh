var createM = document.querySelector(".create"),
    showOrHidden = document.querySelector(".showorhidden"),
    sanJiao = document.querySelector("#sanjiao"),
    articleA = document.querySelector(".article"),
    sanjiaoArticle = document.querySelector("#sanjiaoarticle"),
    showorHiddenArticle = document.querySelector("#showorhiddenarticle");

console.log(sanjiaoArticle);
init();
function init() {
   
  
    articleA.addEventListener("mouseout", mouseroutArticleHandler);
    createM.addEventListener("click", clickHandler);
    articleA.addEventListener("click", clickArticleHandler);
}
function mouseroverHandler() {
    createM.style.background = "aqua";
}
function mouseroutHandler() {
    createM.style.background = "none";
}
function mouseroverArticleHandler() {
    articleA.style.background = "aqua";
}
function mouseroutArticleHandler() {
    articleA.style.background = "none";
}
function clickHandler() {
    if (showOrHidden.style.display == "block") {
        showOrHidden.style.display = "none";
        sanJiao.style.transform = "rotate(0)";
    } else {
        showOrHidden.style.display = "block";
        sanJiao.style.transform = "rotate(180deg)";
    }
}
function clickArticleHandler() {
    if (showorHiddenArticle.style.display == "block") {
        showorHiddenArticle.style.display = "none";
        sanjiaoArticle.style.transform = "rotate(0)";
    } else {
        showorHiddenArticle.style.display = "block";
        sanjiaoArticle.style.transform = "rotate(180deg)";
    }
}