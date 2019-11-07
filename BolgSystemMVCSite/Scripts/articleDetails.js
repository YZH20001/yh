//1.获取要操作的元素
var btnLike = document.querySelector("#btnLike");
init();
function init() {
    btnLike.addEventListener("click", clickLikeHandler);
}
function clickLikeHandler() {
    console.log(btnLike);
}