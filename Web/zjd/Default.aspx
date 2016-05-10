<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.zjd.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/activity-style.css" rel="stylesheet" type="text/css">
    <script src="js/wScratchPad.js" type="text/javascript"></script>
    <script src="js/alert.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("body").addClass("activity-scratch-card-winning");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="main">
        <div class="cover">
            <div id="egg" class="eggBox">
                <p class="hammer" id="hammer">锤子</p>
                <sup></sup>
            </div>
        </div>
        <div class="content">
            <div id="zjl" style="display: none" class="boxcontent boxwhite">
                <div class="box">
                    <div class="title-red"><span>恭喜你中奖了</span></div>
                    <div class="Detail">
                        <p>您中了：<span id="zj" class="red"></span></p>
                    </div>
                </div>
            </div>
            <div class="boxcontent boxwhite">
                <div class="box">
                    <div class="title-brown"><span>活动说明：</span></div>
                    <div class="Detail">
                        <%=new SqlHelper().ExecuteScalar("select nt from zjd where id = 1") %>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;"></div>
    </div>
    <script type="text/javascript">/*window.sncode = "";*/
        window.prize = "";
        var winprize = "";
        var zjl = 0;
        var goon = true;
        $(function () {
            $('#egg').bind("click", function () {
                var _this = $(this);
                if (goon) {
                    document.getElementById('txt').innerHTML = winprize;

                    $(".hammer").animate({
                        "top": _this.position().top - 25,
                        "left": _this.position().left + 125
                    }, 30, function () {
                        _this.addClass("curr");
                        _this.find("sup").show();
                        $(".hammer").hide();

                        $.post("ajax/cai.aspx?cache=" + Math.random(), function (data) {
                            zjl = data;
                            if (zjl == 100) {//抽奖次数已经用完
                                alert("抽奖次数已经用完，每转发网站到朋友圈可获得一次机会，每邀请一个朋友注册成功可增加一次机会。");
                            } else if (zjl == 101) {//活动未开始
                                alert("活动未开始");
                            } else if (zjl == 105) {//活动时间9点到10点
                                alert("活动时间9点到10点");
                            } else if (zjl == 102) {//活动已结束
                                alert("活动已结束");
                            } else if (zjl == 103) {//请先登录
                                alert("请先登录");
                                location.href = "/user";
                            } else if (zjl == 104) {//今日红包已经全部抽完,明天要趁早来哦
                                alert("今日红包已经全部抽完,明天要趁早来哦");
                                location.href = "/user";
                            } else {
                                $("#zj").html(zjl + "元现金红包");
                                $("#zjl").slideToggle(500);
                                _this.find("sup").addClass('win');
                            }
                        });

                        goon = false;
                    });
                }
            });
        });
    </script>
</asp:Content>

