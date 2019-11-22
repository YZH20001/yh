window.onload = function () {
    //通过js实现登录框居中
    function playauto() {
        //获取浏览器宽高度
        var width = $(window).width();//宽
        var height = $(window).height();//高
        $(".d1").css({ left: width / 2 - 450 , top: height / 2 - 175 })
    }
    //当动态改变浏览器窗口时
    $(window).resize(function () {
        playauto();
    })
    //点击编辑显示
    $(".btn-edit").click(function () {
        playauto();//点击执行初始化函数
        $("#gb").show();
        $(".d1").show();
    });
    //点击按钮关闭
    $(".close").click(function () {
        $("#gb").hide();
        $(".d1").hide();
    });
    //登录框拖动
    //鼠标按下
    $(".title").mousedown(function (e) {
        //获取鼠标位置
        var x = e.clientX;
        var y = e.clientY;
        var Left = $(".d1").offset().left;//登录框距离左边位置
        var Top = $(".d1").offset().top;//登录框距离上边位置
        var _x=x-Left;
        var _y = y - Top;
        $(document).mousemove(function(e){
           //动态获取鼠标位置
           var nx=e.clientX;
           var ny=e.clientY;
           var n_left=nx-_x-120;//定位左边
           var n_top=ny-_y-50;//定位上边
           $(".d1").css({ left:n_left, top: n_top })
        });
        $(document).mouseup(function(){
            $(document).unbind("mousemove");
            $(document).unbind("mouseup");
        });
    });
};