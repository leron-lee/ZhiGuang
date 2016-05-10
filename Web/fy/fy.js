$(function () {
    $(window).scroll(function () {
        var maa = $(document).scrollTop();
        var mab = $(window).height();
        var mac = $(document).height();
        if ((maa + mab - mac) >= -10 && (maa + mab - mac) <= 10) {
            jz();
        }
    });
});
var pagex = 2;
var ifjz = 1;
var fyurl = location.href.replace("#jzz_a", "");
function jz() {
    if (ifjz == 1) {
        ifjz = 0;
        $(".jzz").show();
        location.href = "#jzz_a";
        var newfyurl = "";
        if (fyurl.indexOf("?") > 0) {
            newfyurl = fyurl + "&pagex=" + pagex;
        } else {
            newfyurl = fyurl + "?pagex=" + pagex;
        }
        setTimeout(function () {
            $.post("/fy/fy.aspx?url=" + escape(newfyurl) + "&cache=" + +Math.random(), function (data) {
                if ($.trim(data) != "") {
                    $(".fyneirong").html($(".fyneirong").html() + data);

                    try {
                        f55();
                    } catch (e) {
                        
                    }

                    pagex++;
                    ifjz = 1;
                }
                $(".jzz").hide();
            });
        }, 100);
    }
}