var CenterTimer, AW1, AW2;
function ShowWindow(W1, W2, iframesrc, bcolor) {
    AW1 = W1;
    AW2 = W2;
    if (AW1 == '' || typeof AW1 == 'undefined') AW1 = 'messWindow';
    if (AW2 == '' || typeof AW2 == 'undefined') AW2 = 'promptWindow';
    if (bcolor == '' || typeof bcolor == 'undefined') bcolor = '#333333'
    if ($('#' + AW1).length == 0) $('<div id="' + AW1 + '" style="position:absolute;z-index:100;display:none;background-color:' + bcolor + ';top:0;left:0"></div>').appendTo("body");
    if ($('#' + AW2).length == 0) {
        $('<IFRAME id="' + AW2 + '" name="' + AW2 + '" style="position:absolute;z-index:103;background-color:#fff;" src="" frameborder="0" scrolling="no" ></IFRAME>').appendTo("body");
    }
    $('#' + AW2).css({ 'position': 'absolute', 'z-index': '103' });
    $('#' + AW1).css("opacity", 0.8);
    $('#' + AW1).width(document.body.scrollWidth > document.documentElement.clientWidth ? document.body.scrollWidth : document.documentElement.clientWidth);
    $('#' + AW1).height(document.body.scrollHeight > document.documentElement.clientHeight ? document.body.scrollHeight : document.documentElement.clientHeight);
    $('#' + AW1).fadeIn("slow");
    if (iframesrc != '' && typeof iframesrc != 'undefined') {
        $("#" + AW2).attr('src', iframesrc).load(function () { IFrameReSize(AW2); IFrameReSizeWidth(AW2); });
    }
    $('#' + AW2).fadeIn("slow");
    DivCenter();
}
function HideWindow() { $("#" + AW1).fadeOut("slow"); $("#" + AW2).fadeOut("slow"); clearTimeout(CenterTimer); }
function DivCenter() {
    var scrollY = 0;
    if (document.documentElement && document.documentElement.scrollTop) { scrollY = document.documentElement.scrollTop; } else if (document.body && document.body.scrollTop) { scrollY = document.body.scrollTop; }
    else if (window.pageYOffset) { scrollY = window.pageYOffset; } else if (window.scrollY) { scrollY = window.scrollY; }
    var Div = document.getElementById(AW2);
    var Dh = Div.offsetHeight;
    if (Dh > $('#' + AW1).height()) $('#' + AW1).height(Div.offsetHeight + $('#' + AW2).offset().top * 2);
    if (document.documentElement.clientHeight > Dh) { Div.style.top = (document.documentElement.clientHeight - Div.offsetHeight) / 2 + scrollY + 'px'; }
    Div.style.left = (document.body.clientWidth - Div.clientWidth) / 2 + document.body.scrollLeft + 'px';
    CenterTimer = setTimeout("DivCenter()", 500);
}
function AlertLoginReturn(S) { if (S == 1) location.reload(); }
function IFrameReSize(iframename) {
    var pTar = document.getElementById(iframename);
    if (pTar) { if (pTar.contentDocument && pTar.contentDocument.body.offsetHeight) { pTar.style.height = pTar.contentDocument.body.offsetHeight + 'px'; } else if (pTar.Document && pTar.Document.body.scrollHeight) { pTar.style.height = pTar.Document.body.scrollHeight + 'px'; } } 
}
function IFrameReSizeWidth(iframename) {
    var pTar = document.getElementById(iframename);
    if (pTar) { if (pTar.contentDocument && pTar.contentDocument.body.offsetWidth) { pTar.style.width = pTar.contentDocument.body.offsetWidth + 'px'; } else if (pTar.Document && pTar.Document.body.scrollWidth) { pTar.style.width = pTar.Document.body.scrollWidth + 'px'; } }
}

