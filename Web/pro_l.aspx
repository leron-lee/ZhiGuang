<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="pro_l.aspx.cs" Inherits="Web.pro_l" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/fy/fy2.js"></script>
<link href="/fy/fy.css" rel="stylesheet" />
<style>
    .qta a { float: left; border: 1px solid #B4B4B4; padding: 5px 10px 5px 10px; margin: 5px 5px 0px 0px; }
    .qta a.a { border: 1px solid #C30109; background-image:url(/images/gou.jpg);background-repeat:no-repeat;background-position:right bottom; }
    .qhtable td a { display: block; height: 30px; line-height: 30px; text-align: center; font-size: 14px; border-bottom: 1px solid #ccc; padding-left: 10px; }
    .qhtable td a.a { border-bottom: 1px solid #D93536; }
</style>
<script>
    $(function () {
        $(".sltable .jian").click(function () {
            var sum = $("#sum").val();
            if (sum > 1) {
                sum--;
            }
            $("#sum").val(sum);
            pdku();
        });
        $(".sltable .jia").click(function () {
            var sum = $("#sum").val();
            sum++;
            $("#sum").val(sum);
            pdku();
        });
        var ys = $("#ys").attr("value");//颜色
        yk_two(ys);
    });
    function pdku() {
        var ku = $("#ku").val();
        var sum = $("#sum").val();


        if (parseInt(sum) > parseInt(ku)) {
            $("#sum").val(ku);
        }
    }
    $(window).load(function () {
        $("#dgh").height($("#digf").height());
    });
    function ljgm() {
        var mid = $("#mid").val();//ID
        var ys = $("#ys").attr("value");//颜色
        var cc = $("#cc").attr("value");//尺寸
        var sum = $("#sum").val();//数量

        if (mid == "" || ys == "" || cc == "") {
            alert("请选择颜色和尺寸");
        } else {
            alert("这里跳转到购物页面");
        }
    }
    function jrgwc() {
        var mid = $("#mid").val();//ID
        var ys = $("#ys").attr("value");//颜色
        var cc = $("#cc").attr("value");//尺寸
        var sum = $("#sum").val();//数量

        //if (mid == "" || ys == "" || cc == "") {
         //   alert("请选择颜色和尺寸");
      //  } else {
      //      alert("这里加入购物车操作");
       // }
    }
    function yk_two(id) {
        /*
        $.post("/ajax/yk_two.aspx?id=" + id + "&cache=" + Math.random(), function (data) {
            $("#cc_div").html(data);
            var yk_two_id = $("#cc_div a").eq(0).attr("value");//ID
            var yk_two_ku = $("#cc_div a").eq(0).attr("ku");//库存
            $("#cc").val(yk_two_id);
            $("#yk_two_ku").html(yk_two_ku);
            $("#ku").val(yk_two_ku);
            bd();
        });
        */
    }
    function bd() {
        $("#ys_div a").click(function () {
            var vl = $(this).attr("value");
            $("#ys").val(vl);
            $("#ys_div a").removeClass("a");
            $(this).addClass("a");

            yk_two(vl);
        });

        $("#cc_div a").click(function () {
            var vl = $(this).attr("value");
            var yk_two_ku = $(this).attr("ku");//库存
            $("#yk_two_ku").html(yk_two_ku);
            $("#cc").val(vl);
            $("#cc_div a").removeClass("a");
            $(this).addClass("a");
        });
    }
</script>

<link href="css/photoswipe.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/klass_min.js"></script>
<script type="text/javascript" src="js/code_photoswipe_min.js"></script>
<script type="text/javascript">
    $(function () {
        $(".Gallery a").photoSwipe({ loop: false });
    });
</script>

<script src="/js/swipe.js" type="text/javascript"></script>
<style>
    #position { }
    li { list-style-type: none; float: left; font-family: Tahoma; color: #898883; font-size: 20px; font-weight: bold; margin-left: 3px; }
    .on { color:red;}
    #slider { width: 100%; overflow: hidden; height: 300px; width: 100%; float: left; }
    #slider .dimg { float: left; position: relative; }
    #slider .dimg img { width: 100%; height: 300px; }
    #slider .divdhbody { width:50000px;position:relative;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<input id="mid" name="mid" type="hidden" value="<%=Request.QueryString["id"] %>" />
<input id="ys" name="ys" type="hidden" value="<%=ys %>" />
<input id="cc" name="cc" type="hidden" value="<%=cc %>" />
<input id="ku" name="ku" type="hidden" value="6" />
    
    <div class="b_l_w" style="background-color:#fff;">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
        <div class="b_l_w w100">
            <div id="slider">
                <div class="divdhbody Gallery">
                    <%#get.kong(Eval("x_img"),"<div class='dimg'><a href='"+Eval("x_img")+"'><img src='"+Eval("x_img")+"' /></a></div>") %>
                    <%#get.kong(Eval("s11"),"<div class='dimg'><a href='"+Eval("s11")+"'><img src='"+Eval("s11")+"' /></a></div>") %>
                    <%#get.kong(Eval("s12"),"<div class='dimg'><a href='"+Eval("s12")+"'><img src='"+Eval("s12")+"' /></a></div>") %>
                    <%#get.kong(Eval("s13"),"<div class='dimg'><a href='"+Eval("s13")+"'><img src='"+Eval("s13")+"' /></a></div>") %>
                    <%#get.kong(Eval("s14"),"<div class='dimg'><a href='"+Eval("s14")+"'><img src='"+Eval("s14")+"' /></a></div>") %>
                </div>
            </div>
            <div class="b_l_w" style="position:relative;margin-top:-23px;">
                <div class="b_r" style="margin-right:3px;">
                    <ul id="position">
                        <%#get.kong(Eval("x_img"),"<li class='on'>●</li>") %>
                        <%#get.kong(Eval("s11"),"<li>●</li>") %>
                        <%#get.kong(Eval("s12"),"<li>●</li>") %>
                        <%#get.kong(Eval("s13"),"<li>●</li>") %>
                        <%#get.kong(Eval("s14"),"<li>●</li>") %>
                    </ul>
                </div>
            </div>
            <script>
                $(function () {
                    var bodyw = $(".doc").width;
                    $("#slider .dimg").width(bodyw).height(150);
                });
                var slider =
                  Swipe(document.getElementById('slider'), {
                      auto: 3000,
                      continuous: true,
                      callback: function (pos) {
                          var i = bullets.length;
                          while (i--) {
                              bullets[i].className = ' ';
                          }
                          bullets[pos].className = 'on';
                      }
                  });
                var bullets = document.getElementById('position').getElementsByTagName('li');
            </script>
        </div>
        <div class="b_l_w">
            <div style="padding:5px;">
                <div class="b_l_w">
                    <b style="font-size:16px;">
                        <%#Eval("name") %>
                    </b>
                </div>
                <div class="b_l_w">
                    货号：<%#Eval("s10") %><br /></div>
                <div class="b_l_w <%=hb %>">
                    <div class="b_l">
                        <table>
                            <tr>
                                <td><img src="/images/hb.png" /></td>
                                <td>红包可抵用<b style="color:#E23537;"><%#Eval("s8") %></b>元</td>
                            </tr>
                        </table>
                    </div>
                    <div class="b_r dis">
                        可兑换分销名额<b style="color:#E23537;"><%#Eval("s9") %></b>名
                    </div>
                </div>
                <div class="b_l_w" style="color:#ccc;">
                    <%#Eval("guige") %>
                </div>
                <div class="b_l_w">
                    <s>建议零售价：￥<%#Eval("s1") %></s></div>
                <div class="b_l_w">
                    <div class='b_l'>
                        会员价：<b style="color:#E23537;font-size:16px;">￥<%#get.jg(Eval("id"),Request) %></b></div>
                    <div class="b_l" style="margin-left:5px;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width:36px;">已售：</td>
                                <td>
                                    <%#Eval("s3") %>件
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="b_l_w" style="display:none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width:36px;">颜色：</td>
                                <td>
                                    <div id="ys_div" class="qta">
                                        <%#qd(Eval("id")) %>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="b_l_w" style="margin-top:5px;display:none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width:36px;">尺寸：</td>
                                <td>
                                    <div id="cc_div" class="qta">
                                        
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="b_l_w" style="margin-top:5px;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width:36px;">数量：</td>
                                <td>
                                    <table align="left" class="sltable" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="td1"><a href='javascript:;' class="jian"><img src='/images/jian.jpg' width='100%' /></a></td>
                                            <td class="td2"><input id="sum" name="sum" value="1" type="text" class="yan4" onblur="pdku();" /></td>
                                            <td class="td1"><a href='javascript:;' class="jia"><img src='/images/jia.jpg' width='100%' /></a></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                 <div class="b_l_w" style="margin-top:5px;">
                        <div class="b_l">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    
                                    <td style="font-size:12px;"">新疆、甘肃、宁夏、青海、内蒙古、西藏邮费另加10元</td>
                                </tr>
                            </table>
                        </div>
                        <div class="b_r">
                            
                        </div>
                    </div>
                    <div class="b_l_w" style="margin-top:5px;">
                        <div class="b_l">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width:36px;">库存：</td>
                                    <td>
                                        <span id="yk_two_ku">50<%=ku %></span>件
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="b_r">
                            
                        </div>
                    </div>
                <div class="clear"></div>
            </div>
        </div>
        </ItemTemplate>
        </asp:Repeater>
        <script>
            $(function () {
                $(".qh_a").click(function () {
                    $(".qh_a").removeClass("a");
                    $(this).addClass("a");
                    var inx = $(this).attr("value");
                    $(".qh_div").hide();
                    $(".qh_div").eq(inx).show();
                });
            });
        </script>
        <div class="b_l_w" style="border-top:10px solid #F2F2F2;margin-top:10px;">
            <table class="qhtable" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:50%;border-right:1px solid #ccc;">
                        <a href="javascript:;" class="qh_a a" value="0">商品详情</a>
                    </td>
                    <td style="width:50%;">
                        <a href="javascript:;" class="qh_a" value="1">客户评论<span style="font-size:12px;">(<%=pzong %>)</span></a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="b_l_w">
            <div style="padding:5px;">
                <div class="b_l_w w100 qh_div">
                    <div class="b_l_w">
                        <%=nrtext %>
                    </div>
                    <div class="b_l_w" style="margin-top:5px;">
                        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                            推荐产品
                        </div>
                    </div>
                    <div class="b_l_w">
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="100%" EnableViewState="false">
                        <ItemTemplate>
                            <div style="border:1px solid #ccc;padding:5px;border-radius:5px;">
                                <div class="w100">
                                    <div class="b_l_w">
                                        <a href="pro_l.aspx?id=<%#Eval("id") %>"><img src="<%#Eval("x_img") %>" height="160px" width="100%" class="now" /></a>
                                    </div>
                                    <div class="b_l_w" style="margin-top:5px;text-align:center;line-height:16px;height:16px;overflow:hidden;">
                                        <a href="pro_l.aspx?id=<%#Eval("id") %>"><%#Eval("name") %></a>
                                    </div>
                                    <div class="b_l_w" style="margin-top:5px;">
                                        <b style="color:red;font-size:16px;">￥<%#Eval("s2") %></b><s>￥<%#Eval("s1") %></s><br /><span style="color:#999999;">销量:<%#Eval("s3") %></span></div>
                                </div>
                                <div style="clear:both;"></div>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="50%" />
                        </asp:DataList>
                    </div>
                    <div class="b_l_w">
                        <%=get.gethtml(6) %>
                    </div>
                </div>
                <div class="b_l_w w100 qh_div dis">
                    <div class="fyneirong">
                    <!--分页内容开始-->
                    <asp:Repeater ID="Repeater2" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="b_l_w" style="padding:5px 0px 5px 0px;border-bottom:1px dashed #ccc;">
                            <div class="b_l_w">
                                <div class="b_l">
                                    <%#get.ying(Eval("username")) %>
                                </div>
                                <div class="b_r">
                                    <%#Eval("times") %>
                                </div>
                            </div>
                            <div class="b_l_w">
                                <%#Eval("nt") %>
                            </div>
                        </div>
                    </ItemTemplate>
                    </asp:Repeater>
                    <!--分页内容结束-->
                    </div>
                    <div class="djjz <%=ditk %>"><a href="javascript:;" onclick="jz();">点击加载更多</a></div>
                    <div class="jzz"><a id="jzz_a" name="jzz_a">&nbsp;</a>加载中...</div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <script>
        function ljgm() {
            $("#<%=ljgm_bt.ClientID %>").click();
        }
        function jrgwc() {
            $("#<%=jrgwc_bt.ClientID %>").click();
        }
    </script>
    <div id="dgh" class="clear"></div>
    <div id="digf" style="position:fixed;bottom:50px;left:0px;width:100%;">
        <div class="doc">
            <div style="padding:10px;background-color:#fff;">
                <table width="100%" cellpadding="0" cellspacing="0" class="w100">
                    <tr>
                        <td style="width:49%;"><a href="javascript:;" onclick="ljgm();"><img src="/images/ljgm.jpg" /></a></td>
                        <td style="width:2%;"></td>
                        <td style="width:49%;"><a href="javascript:;" onclick="jrgwc();"><img src="/images/jrgwc.jpg" /></a></td>
                    </tr>
                </table>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <div style="display:none;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="ljgm_bt" runat="server" Text="立即购买" OnClick="ljgm_bt_Click"></asp:Button>
            <asp:Button ID="jrgwc_bt" runat="server" Text="加入购物车" OnClick="jrgwc_bt_Click"></asp:Button>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
