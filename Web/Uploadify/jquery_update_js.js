//下面是三个参数的 上传控件ID 返回地址ID

function StartUploadify(kj, fkj) {
    $("#" + kj).uploadify({
        'uploader': '/Uploadify/uploadify2.swf',
        'cancelImg': '/Uploadify/images/cancel.png',
        'buttonText': 'Select Files',
        'buttonImg': '/Uploadify/images/update.png',
        'width': 38,
        'height': 22,
        'script': '/ajax/Upload.ashx',
        'folder': 'uploads',
        'fileDesc': '',
        'fileExt': '*',
        'sizeLimit': 1024 * 1024 * 1024,
        'simUploadLimit': 10,
        'multi': false,/*是否允许上传多文件*/
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) { SetLi_UpdateFiles(c, fkj); },
        'onAllComplete': function (a, b) {
            enabledSaveButton(true);
        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            setTimeout("$('#" + kj + "').uploadifyCancel('" + b + "')", 2000);
        }
    });
}
function StartUploadify_yzm(kj, fkj) {
    $("#" + kj).uploadify({
        'uploader': '/Uploadify/uploadify2.swf',
        'cancelImg': '/Uploadify/images/cancel.png',
        'buttonText': 'Select Files',
        'buttonImg': '/Uploadify/images/update.png',
        'width': 38,
        'height': 22,
        'script': '/ajax/Upload.ashx?yzm=true',
        'folder': 'uploads',
        'fileDesc': '',
        'fileExt': '*',
        'sizeLimit': 1024 * 1024 * 1024,
        'simUploadLimit': 10,
        'multi': false,/*是否允许上传多文件*/
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) { SetLi_UpdateFiles(c, fkj); },
        'onAllComplete': function (a, b) {
            enabledSaveButton(true);
        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            setTimeout("$('#" + kj + "').uploadifyCancel('" + b + "')", 2000);
        }
    });
}
function SetLi_UpdateFiles(objFile, fkj) {
    var vr = objFile.filePath;
    vr = "" + vr;
    $("#" + fkj).val(vr);
}


//下面是三个参数的 上传控件ID 返回地址ID 改变图片ID
function StartUploadify_two(kj, fkj, fkj_two) {
    $("#" + kj).uploadify({
        'uploader': '/Uploadify/uploadify2.swf',
        'cancelImg': '/Uploadify/images/cancel.png',
        'buttonText': 'Select Files',
        'buttonImg': '/Uploadify/images/update.png',
        'width': 38,
        'height': 22,
        'script': '/ajax/Upload.ashx',
        'folder': 'uploads',
        'fileDesc': '',
        'fileExt': '*;',
        'sizeLimit': 1024 * 1024 * 1024,
        'simUploadLimit': 10,
        'multi': false,/*是否允许上传多文件*/
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) { SetLi_UpdateFiles_two(c, fkj, fkj_two); },
        'onAllComplete': function (a, b) {
            enabledSaveButton(true);
        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            setTimeout("$('#" + kj + "').uploadifyCancel('" + b + "')", 2000);
        }
    });
}
function SetLi_UpdateFiles_two(objFile, fkj, fkj_two) {
    var vr = objFile.filePath;
    vr = "" + vr;
    $("#" + fkj).val(vr);
    $("#" + fkj_two).attr("src", vr);
}