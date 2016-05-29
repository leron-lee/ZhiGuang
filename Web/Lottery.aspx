<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lottery.aspx.cs" Inherits="Web.Lottery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="/lottery/style/common.css" rel="stylesheet" type="text/css" />
    <link href="/lottery/style/index.css" rel="stylesheet" type="text/css" />
    <link href="/lottery/style/other.css" rel="stylesheet" type="text/css" />

    <link href="/lottery/style/Merry Christmas.css" rel="stylesheet" type="text/css" />
    <script src="/lottery/script/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/lottery/utility/jquery.cookie.js" type="text/javascript"></script>
    <script src="/lottery/utility/validate/pagevalidator.js" type="text/javascript"></script>
    <script src="/lottery/utility/globals.js" type="text/javascript"></script>
    <script src="/lottery/script/web_qq.js" type="text/javascript"></script>
    <script src="/lottery/script/jquery.flexslider-min.js" type="text/javascript"></script>
    <script src="/lottery/utility/LoginForm.js" type="text/javascript"></script>
    <script src="/lottery/Utility/validate/WebAjax.js"></script>
    <script rel="script" src="/lottery/script/mySystem.js"></script>
    <script rel="script" src="/lottery/script/layer/layer.js"></script>
    <link href="/lottery/script/layer/skin/layer.css" rel="stylesheet" type="text/css" />
</head>
<style>
    .main-bg {
        width: 100%;
        <!-- height: 1854px; -->
    }
</style>
<body>
    <form runat="server" id="form1">
        <!--在线客服-->
        <div class="head">
        </div>
        <header><img src="" /> </header>
        <div class="main_choujiang">
            <div class="chou">
                <!--抽奖-->
                <div class="chou_left">
                    <div class="myBox">
                        <ul id="cj-a" class="cj">
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                            <li><div></div></li>
                        </ul>
                        <input class="actionCj" type="button" value="点我抽奖" style="color:red;" />
                    </div>
                </div>

                <!--抽奖结束-->
                <!--规则说明-->
                <div class="chou_right">
                    <div class="rules">
                        <div class="rules_title">
                            <h1>活动规则</h1>
                            <samp><a target="_blank" href="http://www.21688.com/default.aspx?promotion=13Winnerslist">查看中奖名单</a></samp>
                        </div>
                        <div class="noticeContent" id="sdpage">
                            <ul>
                            </ul>
                        </div>
                        <div class="rules_txt">
                            <div class="txt_one">
                                1、每个用户拥有三次抽奖机会，中奖的买家请您及时与我们的在线客服取得联系，
                                过期所有中奖记录将予以作废，还请知悉。
                            </div>
                            <div class="txt_one">
                                2、<span style="color:Red;">参与活动每次收取20积分</span>，抽中实物奖品需要点击领取奖励，奖品我们将随订单一起为您发
                                出，奖品型号款式随机发送，不接受买家指定。
                            </div>
                            <div class="txt_one">
                                3、本次抽奖如抽到易卷，将由系统自动赠送对应面额的易卷<br />到您的
                                指定账户中。
                            </div>
                            <div class="txt_one"> 4、本活动解释权归拿呗网所有！ </div>
                        </div>
                    </div>
                </div>
                <!--规则说明结束-->
            </div>
            <!--抽奖结束-->
            <!--满就送开始-->
            <div class="main_man"> <img src="../images/shengdan/mjs.PNG" /> </div>
            <!--满就送结束-->
            <div class="main-bg">
                <div class="main">
                    <!-- InstanceBeginEditable name="编辑区" -->
                    <script type=text/javascript>
                        var _c = _h = 0;
                        $(function () {
                            $('#play > li').click(function () {
                                var i = $(this).attr('alt') - 1;
                                clearInterval(_h);
                                _c = i;
                                play();
                                change(i);
                            })
                            $("#pic img").hover(function () { clearInterval(_h) }, function () { play() });
                            play();
                        })

                        function play() {
                            _h = setInterval("auto()", 3000);
                        }

                        function change(i) {
                            $('#play > li').addClass("bg normal");

                            $("#li" + i).removeClass("bg normal");
                            $("#li" + i).addClass("bg active");
                            $("#pic img").hide().eq(i).fadeIn('slow');
                        }

                        function auto() {
                            _c = _c > 0 ? 0 : _c + 1;
                            change(_c);
                        }

                    </script>

                </div>

                <div class="food2" id="KTV">
                    <script>
                        $(document).on("mouseover", ".ranking-category li", function (event) {
                            $(".ranking-category li").removeClass('newsCurrent');
                            $(this).addClass('newsCurrent');
                            var index = $(this).index();
                            $(".category-product").hide();
                            $(".category-product").eq(index).show();
                        })
                        $(document).on("mouseover", ".ranking-right li", function (event) {
                            $(".ranking-right li").removeClass('newsCurrent2');
                            $(this).addClass('newsCurrent2');
                            var index = $(this).index();
                            $(".ranking-list").hide();
                            $(".ranking-list").eq(index).show();

                        })
                    </script>
                </div>
            </div>

        </div>

    </form>
    <script>
        $(document).on('mouseenter', '.sidebarcom-oper li,.sidebarcom-survey,.sidebarcom-top', function () {
            $(this).addClass('curr');
            //var cartList = $('.cartList').html();
            //var shopCar = $('#shopping-car');
            //shopCar.html("");
            //shopCar.append(cartList);
            $('.cartList').show();
            var css_cartlist = $('#shopping-car').find('.cartList');
            css_cartlist.css('postion', 'initial')
        })
        $(document).on('mouseleave', '.sidebarcom-oper li,.sidebarcom-survey,.sidebarcom-top', function () {
            $(this).removeClass('curr');
            //var shopCar = $('#shopping-car');
            //shopCar.hide();
            $('.cartList').hide();
        })
        $(document).on('mouseover', '.sku-box .sku-content', function () {
            var index = $(this).index();
            $(this).addClass('sku-currt2');
            $('.image-box a').eq(index).addClass('sku-currt1');
            $(this).mouseleave(function () {
                $(this).removeClass('sku-currt2');
                $('.image-box a').removeClass('sku-currt1');
            })
        })

        //开奖公告滚动
        function Notice(obj) {
            $(obj).find('ul').animate({
                marginTop: "-84px"
            }, 500, function () {
                $(this).css({ marginTop: "0px" }).find("li:first").appendTo(this);
            });
        }
        $(document).ready(function () {
            setInterval('Notice(".noticeContent")', 5000);
        });
    </script>
    <script>
        $(function () {
            getShoppingCart();
            //首页banner效果
            $('.flexslider').flexslider({
                directionNav: true,
                pauseOnAction: false
            });
            $('.proTag span[val]').bind('click', function () {
                var $this = $(this);
                var val = $this.attr('val');
                if (!!val) {
                    var vals = val.split('_');
                    location.href = '/listProduct.aspx?cateId=' + (!!vals[1] ? vals[1] : 1) + '&SubjectType=' + vals[0];
                }
            });

        });
    </script>
    <script>
        function islogin() {
            var userInfo = decodeURI($.cookie("SessionUserInfo"));
            userInfo = userInfo.split("]&SessionKey")[0].substring(1, userInfo.split("]&2")[0].length);
            var obj = JSON.parse(userInfo);
            //obj.userName
            //obj.id
            if (obj.id != null) {
                $.ajax({
                    url: "/API/GetUserGeneralAccount.ashx",
                    data: { userid: obj.id },
                    success: function (data) {
                        var newdata = eval("(" + data + ")");
                        var srtr = "Hi," + obj.userName + "！<br /><i>账户余额: " + newdata.RemainAmount + "</i>"
                        $("#userinfo").html(srtr);
                    }
                });
            }
        }
        $(document).ready(function () {
            islogin();
            //上传数据包
            $(".upData .dataWp").hover(function () {
                $(this).find(".subUp").show();
            }, function () {
                $(this).find(".subUp").hide();
            })
            //隐藏分类
            $(".cateMenu ul li").hover(function () {
                $(this).find(".subCate").show();
            }, function () {
                $(this).find(".subCate").hide();
            })

        })
        $(function () {
            var navH = $(".navWp").offset().top;
            //滚动条事件
            $(window).scroll(function () {
                var scroH = $(this).scrollTop();
                if (scroH >= navH) {
                    $(".navWp").addClass("fixed");
                } else if (scroH < navH) {
                    $(".navWp").removeClass("fixed");
                }
            })
        })
        
    </script>
    <script>
        $(".upId a").hover(function () {
            var nIndex = $(".upId a").index(this);
            $(".titleUp").eq(nIndex).show().siblings(".titleUp").hide();
            
        })
        function layer_pic(obj) {
            $("#information").show();
            $(".commonshow").text(obj);
            layer.open({
                type: 1,
                title: false,
                closeBtn: 0,
                area: '516px',
                skin: 'layui-layer-nobg', //没有背景色
                shadeClose: true,
                content: $('#information')
            });
        };
        $.ajax({
        url: "/api/GetRaffleTop.ashx",
        success: function(data) {
            $("#sdpage ul").html(data);
            }
        });
    </script>
</body>
</html>
