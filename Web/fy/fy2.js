var pagex = 2;
var ifjz = 1;
var fyurl = location.href.replace("#jzz_a", "");
function jz() {
    if (ifjz == 1) {
        ifjz = 0;
        $(".djjz").hide();
        $(".jzz").show();
        var newfyurl = fyurl + "&pagex=" + pagex;
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
                    $(".djjz").show();
                }
                $(".jzz").hide();
            });
        }, 100);
    }
}