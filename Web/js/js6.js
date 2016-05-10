
//try{
//    //去除微信下面导航条
//    document.addEventListener('WeixinJSBridgeReady',onBridgeReady);
//    function onBridgeReady(){
//        WeixinJSBridge.call('showToolbar');//hideToolbar
//    }
//} catch (err)
//{ }

$(function () {
    $(".w100").width("100%");
    $(".w100 img").not(".now").width("100%").height("auto");
});

$(function () {
    //纯数字验证开始
    $(".yan1").bind("keyup", function () {
        this.value = this.value.replace(/\D/g, '');
    });
    $(".yan1").bind("afterpaste", function () {
        this.value = this.value.replace(/\D/g, '')
    });
    $(".yan1").bind("blur", function () {
        this.value = this.value.replace(/\D/g, '')
    });
    //纯数字验证结束
    //数字+小数点 验证开始
    $(".yan2").bind("keyup", function () {
        if (isNaN(this.value)) {
            document.execCommand('undo');
        }
    });
    $(".yan2").bind("afterpaste", function () {
        if (isNaN(this.value)) {
            document.execCommand('undo');
        }
    });
    $(".yan2").bind("blur", function () {
        if (isNaN(this.value)) {
            this.value = "";
        }
    });
    //数字+小数点 验证结束
    //中文 验证开始
    $(".yan3").bind("keyup", function () {
        this.value = this.value.replace(/[ -~]/g, '');
    });
    $(".yan3").bind("afterpaste", function () {
        this.value = this.value.replace(/[ -~]/g, '');
    });
    $(".yan3").bind("blur", function () {
        this.value = this.value.replace(/[ -~]/g, '');
    });
    //中文 验证结束
    //大于0的小数 验证开始
    $(".yan4").bind("keyup", function () {
        this.value = this.value.replace(/\D/g, '');
        if (this.value <= 0) {
            this.value = 1;
        }
    });
    $(".yan4").bind("afterpaste", function () {
        this.value = this.value.replace(/\D/g, '');
        if (this.value <= 0) {
            this.value = 1;
        }
    });
    $(".yan4").bind("blur", function () {
        this.value = this.value.replace(/\D/g, '');
        if (this.value <= 0) {
            this.value = 1;
        }
    });
    //大于0的小数 验证结束
});

// <a href="javascript:void(0)" onclick="SetHome(this,window.location)">设为首页</a>
// <a href="javascript:void(0)" onclick="shoucang(document.title,window.location)">加入收藏</a>

// 设置为主页 
function SetHome(obj, vrl) {
    try {
        obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
    }
    catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', vrl);
        } else {
            alert("您的浏览器不支持，请按照下面步骤操作：1.打开浏览器设置。2.点击设置网页。3.输入：" + vrl + "点击确定。");
        }
    }
}
// 加入收藏 兼容360和IE6 
function shoucang(sTitle, sURL) {
    try {
        window.external.addFavorite(sURL, sTitle);
    }
    catch (e) {
        try {
            window.sidebar.addPanel(sTitle, sURL, "");
        }
        catch (e) {
            alert("加入收藏失败，请使用Ctrl+D进行添加");
        }
    }
}

$(function () {
    $("input[type='text'],input[type='password'],textarea").focus(function () {
        $(".fixed").hide();
    });
    $("input[type='text'],input[type='password'],textarea").blur(function () {
        $(".fixed").show();
    });
});