var liList = document.querySelectorAll(".sideBar li");
console.log(liList)
init();
function init() {
    for (var i = 0; i < liList.length; i++) {
        liList[0].addEventListener("click", clickLiHandel);
    }
}
function clickLiHandel() {
    liList[0].style.background= "red";
}