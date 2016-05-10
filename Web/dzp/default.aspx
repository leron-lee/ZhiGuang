<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.dzp._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <title></title>
    <link href="images/activity-style.css" rel="stylesheet" type="text/css">
    <script src="images/jquery.js"></script>
    <script src="images/alert.js"></script>
    <link href="/css/body.css" rel="stylesheet" />
</head>
<body class="activity-lottery-winning">
<form id="form1" runat="server">
    
<div class="main">
<div id="outercont">
<div id="outer-cont">
<div id="outer" style="-webkit-transform: rotate(2136deg);"><img src="images/activity-lottery-11.png" width="310px"></div>
</div>
<div id="inner-cont">
<div id="inner"><img src="images/activity-lottery-2.png"></div>
</div>
</div>
<div class="content">
<div class="boxcontent boxyellow" id="result" style="display:none">
<div class="box">
<div class="title-orange"><span>恭喜您中奖了</span></div>
<div class="Detail">
    <a class="ui-link" href="" id="opendialog" style="display: none;" data-rel="dialog"></a>
    <p>您中了：<span class="red" id="prizetype">一等奖</span></p>
    <p>
        <input name="tel" class="px" id="tel" type="text" placeholder="输入您的手机号码" />
    </p>
    <p>
        <script>
            function pd() {
                var vtel = $("#tel").val();
                if (vtel == "") {
                    alert('输入您的手机号码');
                    return false;
                }
            }
        </script>
        <asp:Button ID="savebtn" runat="server" Text="提 交" CssClass="pxbtn" OnClientClick="return pd();"></asp:Button>
    </p>
</div>
</div>
</div>
<div class="boxcontent boxyellow">
<div class="box">
<div class="title-green">活动说明：</div>
<div class="Detail">
    每小时抽一次
</div>
</div>
</div>
<div class='b_l_w'>
    <div style="padding:0px 15px 0px 15px;">
        <a href="/" class="bt_bai" style="color:#444;">返回首页</a>
        <div class="clear"></div>
    </div>
</div>
</div>

</div>
<script type="text/javascript">
    $(function () {
        window.requestAnimFrame = (function () {
            return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60)
            }
        })();
        var totalDeg = 360 * 3 + 0;
        var steps = [];
        var lostDeg = [36, 66, 96, 156, 186, 216, 276, 306, 336];
        var prizeDeg = [6, 126, 246];
        var prize, sncode;
        var count = 0;
        var now = 0;
        var a = 0.01;
        var outter, inner, timer, running = false;
        function countSteps() {
            var t = Math.sqrt(2 * totalDeg / a);
            var v = a * t;
            for (var i = 0; i < t; i++) {
                steps.push((2 * v * i - a * i * i) / 2)
            }
            steps.push(totalDeg)
        }
        function step() {
            outter.style.webkitTransform = 'rotate(' + steps[now++] + 'deg)';
            outter.style.MozTransform = 'rotate(' + steps[now++] + 'deg)';
            if (now < steps.length) {
                requestAnimFrame(step)
            } else {
                running = false;
                setTimeout(function () {
                    if (prize != null) {
                        if (prize != 100) {
                            if (prize == 1) {
                                alert('恭喜您获得了1元红包，您是第<%=zhi%>名获奖者');
                            } else if (prize == 2) {
                                alert('恭喜您获得了3元红包，您是第<%=zhi%>名获奖者');
                            } else if (prize == 3) {
                                alert('恭喜您获得了5元红包，您是第<%=zhi%>名获奖者');
                            } else if (prize == 4) {
                                alert('恭喜您获得了10元红包，您是第<%=zhi%>名获奖者');
                            } else if (prize == 5) {
                                alert('恭喜您获得了50元红包，您是第<%=zhi%>名获奖者');
                            } else if (prize == 6) {
                                alert('恭喜您获得了100元红包，您是第<%=zhi%>名获奖者');
                            }
    } else {
        alert("一小时以后再来")
    }
} else {
    alert("谢谢您的参与，下次再接再厉")
}
                },
                200)
}
}
        function start(deg) {
            deg = deg || lostDeg[parseInt(lostDeg.length * Math.random())];
            running = true;
            clearInterval(timer);
            totalDeg = 360 * 5 + deg;
            steps = [];
            now = 0;
            countSteps();
            requestAnimFrame(step)
        }
        window.start = start;
        outter = document.getElementById('outer');
        inner = document.getElementById('inner');
        i = 10;

        $("#inner").click(function () {
            $.post("/ajax/dzp.aspx?cache=" + Math.random(), function (data) {
                var zj = data;//0未中奖，1：一等奖 2：二等奖 3：三等奖
                prize = zj;
                if (zj == 1) {
                    start(1);
                } else if (zj == 2) {
                    start(300);
                } else if (zj == 3) {
                    start(240);
                } else if (zj == 4) {
                    start(180);
                } else if (zj == 5) {
                    start(120);
                } else if (zj == 6) {
                    start(60);
                } else if (zj == 100) {
                    alert("一小时以后再来");
                } else {
                    prize = null;
                    start(30);
                }
            });
        });
    });
</script>

</form>
</body>
</html>

