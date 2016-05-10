$(function () {
    s_sheng_cao();
    $("#s_sheng").change(function () {
        var zhi = $(this).val();
        if (zhi == "") {
            $("#s_shi").find("option").not($("#s_shi").find("option").eq(0)).remove();
            $("#s_xian").find("option").not($("#s_xian").find("option").eq(0)).remove();
        } else {
            s_shi_cao(zhi);
        }
    });
    $("#s_shi").change(function () {
        var zhi = $(this).val();
        s_xian_cao(zhi);
    });
});
function s_sheng_cao() {
    $.post("/ajax/s_s_x.aspx?s_sheng=&cache=" + Math.random(), function (data) {
        var strt = data.split(",");
        for (i = 0; i < strt.length ; i++) {
            if (strt[i] != "") {
                var xstrt = strt[i].split(":");
                $("#s_sheng").append("<option value='" + xstrt[0] + "'>" + xstrt[1] + "</option>");
            }
        }
    });
}
function s_shi_cao(zhi) {
    if (zhi != "" && zhi != "0") {
        $.post("/ajax/s_s_x.aspx?s_shi=" + zhi + "&cache=" + Math.random(), function (data) {
            var strt = data.split(",");
            $("#s_shi").find("option").not($("#s_shi").find("option").eq(0)).remove();
            $("#s_xian").find("option").not($("#s_xian").find("option").eq(0)).remove();
            for (i = 0; i < strt.length ; i++) {
                if (strt[i] != "") {
                    var xstrt = strt[i].split(":");
                    $("#s_shi").append("<option value='" + xstrt[0] + "'>" + xstrt[1] + "</option>");
                }
            }
        });
    }
}
function s_xian_cao(zhi) {
    if (zhi != "" && zhi != "0") {
        $.post("/ajax/s_s_x.aspx?s_xian=" + zhi + "&cache=" + Math.random(), function (data) {
            var strt = data.split(",");
            $("#s_xian").find("option").not($("#s_xian").find("option").eq(0)).remove();
            for (i = 0; i < strt.length ; i++) {
                if (strt[i] != "") {
                    var xstrt = strt[i].split(":");
                    $("#s_xian").append("<option value='" + xstrt[0] + "'>" + xstrt[1] + "</option>");
                }
            }
        });
    }
}
function s_s_x_mo(shengid, shiid, xianid) {
    setTimeout(function () {
        if (shengid != "") {
            $("#s_sheng option[value='" + shengid + "']").attr("selected", "true");
            s_shi_cao(shengid);
        }
        if (shiid != "") {
            s_xian_cao(shiid);
            $("#s_shi option[value='" + shiid + "']").attr("selected", "true");
        }
        if (xianid != "") {
            $("#s_xian option[value='" + xianid + "']").attr("selected", "true");
        }
    },100);
}