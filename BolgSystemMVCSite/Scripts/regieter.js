//获取要操作的元素
var ImgList = document.querySelectorAll("#bg_wrap div");
var index = 0;
setInterval(function () {
    ImgList[index].style.opacity = 0;
    index++;
    if (index > 2) {
        index = 0;
    }
    ImgList[index].style.opacity = 1;
},2000)