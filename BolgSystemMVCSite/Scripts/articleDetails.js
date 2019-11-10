(function (d, w) {
    //1.获取要操作的元素
    var btnLike = document.querySelector("#btnLike"),
        likeBox = document.querySelector("#likeBox")
     
    btnLike.addEventListener("click", function (e) {
        heart(e);
    });
    //工厂加工
    var arr = [];//将产生的心存起来
    function heart(e) {
        var likediv = d.createElement("div");
        likediv.classList.add("likeWrap");
        likediv.innerHTML = '<i class="iconfont icon-xinheart118"></i>';
        likeBox.appendChild(likediv);
        arr.push({
            el: likediv,
            top: e.clientY ,
            left: e.clientX-10 ,
            color: "rgb(" + Math.random() * 256 + "," + Math.random() * 256 + "," + Math.random() * 256 + ")",
            scale: 1,
            opacity: 1,
        });
        likeMove();
    };
    function likeMove() {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].opacity <= 0) {
                likeBox.removeChild(arr[i].el);
                arr.splice(i, 1);
                return;
            }
            arr[i].top--;
            arr[i].scale += 0.01;
            arr[i].opacity -= 0.01;
            arr[i].el.style.cssText = `
                                 top:${arr[i].top}px;
                                 left:${arr[i].left}px;
                                 color:${arr[i].color};
                                 transform:scale(${arr[i].scale});
                                 opacity:${arr[i].opacity};
                    `;
        }
        requestAnimationFrame(likeMove);
    }
})(document, window);