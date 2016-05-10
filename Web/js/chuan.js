function chuan_two(v1, v2) {
    var obj = new Object();
    v1 = v1.replace(/(^\s*)|(\s*$)/g, '');//取出前后空格
    v2 = v2.replace(/(^\s*)|(\s*$)/g, '');//取出前后空格
    var wm = window.showModalDialog('/upload_img.aspx', obj, 'dialogHeight:100px;dialogWidth:460px;status:no;scroll:no;help:no');
    if (wm == undefined) {
        wm = window.returnValue;
    }
    if (typeof (wm) !== "undefined") {
        if (wm != "") {
            document.getElementById(v1).value = wm;
            document.getElementById(v2).src = wm;
        }
    }
}
function chuan_one(v1) {
    var obj = new Object();
    v1 = v1.replace(/(^\s*)|(\s*$)/g, '');///取出前后空格
    var wm = window.showModalDialog('/upload_img.aspx', obj, 'dialogHeight:100px;dialogWidth:460px;status:no;scroll:no;help:no');
    if (wm == undefined) {
        wm = window.returnValue;
    }
    if (typeof (wm) !== "undefined") {
        if (wm != "") {
            document.getElementById(v1).value = wm;
        }
    }
}

function chuan_one_yzm(v1) {
    var obj = new Object();
    v1 = v1.replace(/(^\s*)|(\s*$)/g, '');///取出前后空格
    var wm = window.showModalDialog('/upload_img.aspx?yzm=true', obj, 'dialogHeight:100px;dialogWidth:460px;status:no;scroll:no;help:no');
    if (wm == undefined) {
        wm = window.returnValue;
    }
    if (typeof (wm) !== "undefined") {
        if (wm != "") {
            document.getElementById(v1).value = wm;
        }
    }
}