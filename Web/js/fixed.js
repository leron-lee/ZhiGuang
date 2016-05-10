/* www.planeArt.cn */
var position = function () {
    var isIE6 = !-[1, ] && !window.XMLHttpRequest,
        html = document.getElementsByTagName('html')[0];

    // 给IE6 fixed 提供一个“不抖动的环境”
    // 只需要 html 与 body 标签其一使用背景静止定位即可让IE6下滚动条拖动元素也不会抖动
    // 注意：IE6如果 body 已经设置了背景图像静止定位后还给 html 标签设置会让 body 设置的背景静止(fixed)失效	
    if (isIE6 && document.body.currentStyle.backgroundAttachment !== 'fixed') {
        html.style.backgroundImage = 'url(about:blank)';
        html.style.backgroundAttachment = 'fixed';
    };

    return {
        fixed: isIE6 ? function (elem) {
            var style = elem.style,
                dom = '(document.documentElement)',
                left = parseInt(style.left) - document.documentElement.scrollLeft,
                top = parseInt(style.top) - document.documentElement.scrollTop;
            this.absolute(elem);
            style.setExpression('left', 'eval(' + dom + '.scrollLeft + ' + left + ') + "px"');
            style.setExpression('top', 'eval(' + dom + '.scrollTop + ' + top + ') + "px"');
        } : function (elem) {
            elem.style.position = 'fixed';
        },

        absolute: isIE6 ? function (elem) {
            var style = elem.style;
            style.position = 'absolute';
            style.removeExpression('left');
            style.removeExpression('top');
        } : function (elem) {
            elem.style.position = 'absolute';
        }
    };
}();

//使用方法 要放到 底部
//$(function () {
//    var elem = document.getElementById('fixed121');
//    elem.style.left = '0px';
//    elem.style.top = '0px';
//    position.fixed(elem);
//});