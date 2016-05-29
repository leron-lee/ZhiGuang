<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function huangou() {
            alert("您当前积分不足不能换购，继续加油！");
        }

        $(function () {
            $("#logoimg").attr("src", imgUrl);
            $("#sp_name").html(descContent);

        <%=alert%>

            setTimeout(function () {
                $("#div_ding").slideUp();
            }, 5000);
        });
    </script>
    <script src="/js/swipe.js" type="text/javascript"></script>
    <style>
        #position {
        }

        li {
            list-style-type: none;
            float: left;
            font-family: Tahoma;
            color: #898883;
            font-size: 20px;
            font-weight: bold;
            margin-left: 3px;
        }

        .on {
            color: red;
        }

        #slider {
            width: 100%;
            overflow: hidden;
            width: 100%;
            float: left;
        }

            #slider .dimg {
                float: left;
                position: relative;
            }

                #slider .dimg img {
                    width: 100%;
                }

            #slider .divdhbody {
                width: 50000px;
                position: relative;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="b_l_w" style="background-color: white;">
        <div style="padding: 5px;">
            <div class="b_l_w">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 45px;">
                            <img src="/images/logo.jpg" width="35px" />
                        </td>
                        <td>
                            <div style="border: 1px solid #e8e8e8; background-color: white; border-radius: 5px;">
                                <asp:Panel ID="search_pl" runat="server" DefaultButton="search_bt">
                                    <div class="b_l" style="width: 30px; border-right: 1px solid #e8e8e8; margin-left: 2px;">
                                        <asp:Button ID="search_bt" runat="server" Text="" CssClass="search_bt" OnClick="search_bt_Click"></asp:Button>
                                    </div>
                                    <div class="b_l" style="width: 135px; margin-left: 5px;">
                                        <asp:TextBox ID="search_tx" runat="server" CssClass="search_tx" placeholder="请输入商品关键字"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <div class="clear"></div>
                            </div>
                        </td>

                    </tr>
                </table>
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <div class="b_l_w ">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div id="slider">
                    <div class="divdhbody">
                        <%#get.kong(Eval("img1"),"<div class='dimg'><img src='"+Eval("img1")+"' onclick=\"location.href='"+Eval("lj1")+"';\" /></div>") %>
                        <%#get.kong(Eval("img2"),"<div class='dimg'><img src='"+Eval("img2")+"' onclick=\"location.href='"+Eval("lj2")+"';\" /></div>") %>
                        <%#get.kong(Eval("img3"),"<div class='dimg'><img src='"+Eval("img3")+"' onclick=\"location.href='"+Eval("lj3")+"';\" /></div>") %>
                        <%#get.kong(Eval("img4"),"<div class='dimg'><img src='"+Eval("img4")+"' onclick=\"location.href='"+Eval("lj4")+"';\" /></div>") %>
                        <%#get.kong(Eval("img5"),"<div class='dimg'><img src='"+Eval("img5")+"' onclick=\"location.href='"+Eval("lj5")+"';\" /></div>") %>
                        <%#get.kong(Eval("img6"),"<div class='dimg'><img src='"+Eval("img6")+"' onclick=\"location.href='"+Eval("lj6")+"';\" /></div>") %>
                    </div>
                </div>
                <div class="b_l_w" style="position: relative; margin-top: -23px;">
                    <div class="b_r" style="margin-right: 3px;">
                        <ul id="position">
                            <%#get.kong(Eval("img1"),"<li class='on'>●</li>") %>
                            <%#get.kong(Eval("img2"),"<li>●</li>") %>
                            <%#get.kong(Eval("img3"),"<li>●</li>") %>
                            <%#get.kong(Eval("img4"),"<li>●</li>") %>
                            <%#get.kong(Eval("img5"),"<li>●</li>") %>
                            <%#get.kong(Eval("img6"),"<li>●</li>") %>
                        </ul>
                    </div>
                </div>
                <script>

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
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="b_l_w">
        <div class="b_l_w w100">
            <table class="w100" cellspacing="0" cellpadding="0" width="100%" style="margin-top: 10PX;">
                <tbody>
                    <tr>
                        <td style="text-align: center; height: 45px;">
                            <a href="/user/wyzq.aspx">
                                <img src="images/y3.png" width="45" class="now" /></a>
                        </td>
                        <td style="text-align: center;">
                            <a href="lottery.aspx">
                                <img src="images/y5.png" width="45" class="now" /></a>
                        </td>
                        <td style="text-align: center;">
                            <a href="pro_l.aspx?id=51">
                                <img src="images/y1.png" width="45" class="now" /></a>
                        </td>
                        <td style="text-align: center;">
                            <a href="html.aspx?id=27">
                                <img src="images/y4.png" width="45" class="now" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; font-size: 12px; height: 30px;">分享有礼</td>
                        <td style="text-align: center; font-size: 12px;">抽奖</td>
                        <td style="text-align: center; font-size: 12px;">免费资源</td>
                        <td style="text-align: center; font-size: 12px;">公益活动</td>
                    </tr>

                </tbody>
            </table>
            <div class="b_l_w" style="margin-bottom: 5px;">
                <style type="text/css">
                    #ink_con a {
                        font-size: 12px;
                        color: #C00;
                        text-decoration: none;
                        line-height: 26px;
                        display: block;
                    }

                    .shell {
                        background: url("images/lb.png") no-repeat 18px 3px;
                        background-size: 20px 20px;
                        width: 100%;
                        text-align: left;
                        border-top: 1px solid #d7ccc8;
                    }

                    #ink_con {
                        height: 26px;
                        overflow: hidden;
                        padding-left: 45px;
                    }
                </style>
                <!--效果开始-->
                <div class="shell">
                    <div id="ink_con">

                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <a href="news_l.aspx?id=<%#Eval("id") %>"><%#Eval("name") %></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <script>
                    var c, _ = Function;
                    with (o = document.getElementById("ink_con")) { innerHTML += innerHTML; onmouseover = _("c=1"); onmouseout = _("c=0"); }
                    (F = _("if(#%26||!c)#++,#%=o.scrollHeight>>1;setTimeout(F,#%26?10:3000);".replace(/#/g, "o.scrollTop")))();
                </script>
                <!--End-->

            </div>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            </asp:Panel>


            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <table class="w100" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <td style="width: 153px; padding: 5px 0px 5px 5px; border-right: 1px solid #ccc;">
                                <div class="b_l" style="width: 73px;">
                                    <a href="/user">
                                        <img src="<%=img %>" width="73px" height="73px" class="now" style="border-radius: 5px;" />
                                    </a>
                                </div>
                                <div class="b_l" style="width: 75px; margin: 5px 0px 0px 5px;">
                                    <b style="font-size: 14px;"><%=name %></b>
                                    <div class="b_l_w" style="margin-top: 10px;">
                                        <div class="b_l">
                                            <a href="/news.aspx?id=27">
                                                <img src="/images/ai.jpg" /></a>
                                        </div>
                                        <div class="b_l" style="margin: 7px 0px 0px 5px;">
                                            <a href="/news.aspx?id=27" style="line-height: 16px; font-size: 14px;">
                                                <%=int_ai %>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td style="padding-right: 5px;">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>

                                        <td style="text-align: right;">
                                            <a href="/user/shoporder.aspx">
                                                <img src="/images/tubiao2.jpg" width="30px" class="now" /></a>
                                        </td>
                                        <td style="text-align: right;">
                                            <a href="/user/wdcc.aspx">
                                                <img src="/images/tubiao3.jpg" width="30px" class="now" /></a>
                                        </td>
                                        <td style="text-align: right;">
                                            <a href="/user/wdcc.aspx">
                                                <img src="/images/tubiao4.jpg" width="30px" class="now" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </div>


    </div>







    <div class="b_l_w ">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="100%" EnableViewState="false">
            <ItemTemplate>
                <div class="w100">
                    <div class="b_l_w">
                        <a href="pro_l.aspx?id=<%#Eval("id") %>">
                            <img src="<%#Eval("x_img") %>" height="160px" width="100%" class="now" /></a>
                    </div>
                    <div class="b_l_w" style="margin-top: 5px; text-align: center; line-height: 16px; height: 16px; overflow: hidden;">
                        <a href="pro_l.aspx?id=<%#Eval("id") %>"><%#Eval("name") %></a>
                    </div>
                    <div class="b_l_w" style="margin-top: 5px;">
                        <div class="b_l">
                            <b style="color: red; font-size: 16px;">￥<%#get.jg(Eval("id"),Request) %></b>
                        </div>
                        <div class="b_r">
                            <s>￥<%#Eval("s1") %></s>
                        </div>
                        <%--<span style="color:#999999;">销量:<%#Eval("s3") %></span>--%>
                    </div>
                </div>
            </ItemTemplate>
            <ItemStyle Width="50%" />
        </asp:DataList>
    </div>
    <div class="b_l_w w100 ">
        <img src="/images/cnxh.jpg" />
    </div>
    <div class="b_l_w ">
        <asp:DataList ID="DataList2" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="100%" EnableViewState="false">
            <ItemTemplate>
                <div class="w100" style="padding: 2px; background-color: #fff;">
                    <div class="b_l_w">
                        <a href="pro_l.aspx?id=<%#Eval("id") %>">
                            <img src="<%#Eval("x_img") %>" height="160px" width="100%" class="now" /></a>
                    </div>
                    <div class="b_l_w" style="margin-top: 5px; text-align: center; line-height: 16px; height: 16px; overflow: hidden;">
                        <a href="pro_l.aspx?id=<%#Eval("id") %>"><%#Eval("name") %></a>
                    </div>
                    <div class="b_l_w" style="margin-top: 5px;">
                        <div class="b_l_w">
                            <div class="b_l">
                                <s>￥<%#Eval("s1") %></s>
                            </div>
                            <div class='b_r'>
                                <%#Eval("s3") %>人已购
                            </div>
                        </div>
                        <div class="b_l_w">
                            <div class="b_l">
                                <b style="color: red; font-size: 16px;">￥<%#get.jg(Eval("id"),Request) %></b>
                            </div>
                            <div class='b_r'>
                                <a href="pro_l.aspx?id=<%#Eval("id") %>">
                                    <img src="/images/gwc.jpg" width="25px" class="now" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </ItemTemplate>
            <ItemStyle Width="50%" />
        </asp:DataList>
    </div>
    <div class="b_l_w w100">
    </div>
    <div class="b_l_w w100 dis" style="margin-top: 5px;">
        <table cellpadding="0" cellspacing="0" class="w100">
            <tr>
                <td style="padding: 10px;"><a href="/html/img.aspx?src=/images/Android_down.png&href=">
                    <img src="/images/p-bg-6.png" /></a></td>
                <td style="padding: 10px;"><a href="/html/img.aspx?src=/images/ios_down.png&href=<%=Server.UrlEncode("http://www.52525.net/ivfiv.html") %>">
                    <img src="/images/p-bg-5.png" /></a></td>
                <td style="padding: 10px;"><a href="/html/img.aspx?src=/images/guanzhu.jpg&href=<%=Server.UrlEncode("http://mp.weixin.qq.com/s?__biz=MzAwMzEwMjI2Ng==&mid=202157990&idx=1&sn=941988ea3dd55dc3ffdc7f5fba868edd#rd") %>">
                    <img src="/images/p-bg-7.png" /></a></td>
            </tr>
        </table>
    </div>



</asp:Content>
