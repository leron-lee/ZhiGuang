<%@ Page Title="" Language="C#" MasterPageFile="~/cart/Cart.master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="Web.cart.order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#<%=address.ClientID%>").find("input").change(function () {
                youfei($(this).val());
            });
            youfei(<%=addressid%>);
        <%=alert%>
        });
        function youfei(id) {
            $.post("/ajax/youfei.aspx?id=" + id + "&cache=" + Math.random(), function (data) {
                $("#sp_youfei").html(data);
                $("#youfei").val(data);
                pdzf();
            });
        }

        function xy() {

            if ($("#<%=CheckBox2.ClientID%>").is(':checked') == false) {
                alert("请确认已阅读和同意礼尚挚广退换货协议 ！");
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div style="padding: 5px; background-color: #fff;">
        <div class="b_l_w">
            <b class="ahc1">收货地址</b>
        </div>
        <div class="b_l_w" style="margin-top: 5px;">
            <asp:RadioButtonList ID="address" runat="server"></asp:RadioButtonList>
        </div>
        <div class="b_l_w" style="margin-top: 5px; padding-bottom: 10px; border-bottom: 1px dashed #ccc;">
            <a href="/user/address_in.aspx?url=<%=Server.UrlEncode(Request.RawUrl) %>" class="a_huang">添加新地址</a>
        </div>
        <div class="b_l_w" style="margin-top: 5px;">
            <b class="ahc1">商品列表</b>
        </div>
        <div class="b_l_w">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="b_l_w">
                        <div class="b_l_w" style="padding-bottom: 5px; border-bottom: 1px solid #ccc; margin-top: 5px;">
                            <div class="b_l" style="border: 1px solid #ccc; width: 100px;">
                                <img src="<%#get.m_str(Eval("mid"),"x_img") %>" width="100%" />
                            </div>
                            <div class="b_l" style="width: 195px; margin: -5px 0px 0px 10px;">
                                <div style="font-size: 14px; font-weight: bold;">
                                    <%#liu.zifu(get.m_str(Eval("mid"),"name"),13) %>
                                </div>
                                <div style="display: none;">
                                    颜色:<%#get.yk_one_name(Eval("ys")) %> 尺寸:<%#get.yk_two_name(Eval("cc")) %>
                                </div>
                                <div style="color: #E43B3E; font-size: 14px; font-weight: bold;">
                                    ￥<span id='xj_sp_<%#Eval("id") %>'><%#get.jg(Eval("mid"),Request) %></span>
                                </div>
                                <div class="b_l_w">
                                    <div class="b_l">数量：</div>
                                    <div class="b_l">
                                        <%#Eval("shu") %>
                                    </div>
                                </div>
                                <%--<div class="b_l_w">
                                <%#sfxs() %>
                            </div>--%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clear"></div>
    </div>
    <div class="b_l_w">
        <div style="padding: 5px;">
            <div class='dis'>
                <asp:Literal ID="zddy" runat="server"></asp:Literal>
            </div>
            <input id="youfei" name="youfei" type="hidden" value="0" />
            <input id="z_1" type="hidden" value="<%=_zong %>" />
            <input id="z_2_2" type="hidden" value="<%=s8 %>" /><!--能抵用多少红包-->
            <input id="z_2" type="hidden" value="<%=get.hb(username) %>" /><!--红包-->
            <input id="z_3" type="hidden" value="<%=get.xfj(username) %>" /><!--消费劵-->
            <input id="z_4" type="hidden" value="<%=get.ye(username) %>" /><!--余额-->
            <script>
                function pdzf() {
                    var z_1 = parseFloat($("#z_1").val());
                    var z_2_2 = parseFloat($("#z_2_2").val());
                    var z_2 = parseFloat($("#z_2").val());
                    var z_3 = parseFloat($("#z_3").val());
                    var z_4 = parseFloat($("#z_4").val());

                    var hb_ipt = $("#hb_ipt").attr("checked");
                    var xfj_ipt = $("#xfj_ipt").attr("checked");
                    var ye_ipt = $("#ye_ipt").attr("checked");
                    if (hb_ipt == "checked") {
                        if (z_2 >= z_2_2) {
                            z_1 = z_1 - z_2_2;
                        } else {
                            z_1 = z_1 - z_2;
                        }
                    }

                    var youfei = $("#youfei").val();
                    z_1 = parseFloat(youfei) + z_1;

                    $("#hxzf").html(ForDight(z_1));
                }
                function ForDight(x) {
                    var f = parseFloat(x);
                    if (isNaN(f)) {
                        return false;
                    }
                    var f = Math.round(x * 100) / 100;
                    var s = f.toString();
                    var rs = s.indexOf('.');
                    if (rs < 0) {
                        rs = s.length;
                        s += '.';
                    }
                    while (s.length <= rs + 2) {
                        s += '0';
                    }
                    return s;
                }

                function check(vi)//当选中时改变样式
                {

                    if (vi.checked) {
                        $("#fp").css('display', '');
                    } else {
                        $("#fp").css('display', 'none');
                    }

                }
            </script>

            <div class='b_l_w'>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <span style="color: #000; font-size: 14px;">订单总计:</span>￥<%=_ddzong %> = <b style="color: #E43B3E; font-size: 14px;">￥<span id="zongji"><%=_zong %></span></b>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <span style="color: red;">特价商品会员不参与打折</span>
                </asp:Panel>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-right: 5px;">
                            <input id="hb_ipt" name="hb_ipt" type="checkbox" onclick="pdzf();" />红包可抵扣<%=s8 %>元</td>
                        <td>当前红包：<%=get.hb(username) %>元
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-right: 5px;">
                            <input id="xfj_ipt" name="zffs" type="radio" value="xfjzf" />消费劵支付</td>
                        <td>当前消费劵：<%=get.xfj(username) %>元
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-right: 5px;">
                            <input id="ye_ipt" name="zffs" type="radio" value="yezf" />余额支付</td>
                        <td>当前余额：<%=get.ye(username) %>元
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-right: 5px;">
                            <input name="zffs" type="radio" value="zfb" />支付宝支付(在APP中使用)</td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top: 5px;">
                <table cellpadding="0" cellspacing="0" style="display:none;">
                    <tr>
                        <td style="padding-right: 5px;">
                            <input name="zffs" type="radio" value="wx" checked="checked" />微信支付(只能在微信使用)</td>
                        <td></td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="padding-right: 5px;">

                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="check(this)" />
                            备注（请注明颜色，规格）
                        </td>
                        <td></td>

                    </tr>
                    <tr id="fp" style="display: none;">
                        <td style="padding-right: 5px;" colspan="2">
                            <div class="ipt">
                                <asp:TextBox ID="TextBox1" MaxLength="60" placeholder="请注明颜色，规格" runat="server" Style="display: block; width: 100%; height: 100%; border: 0px; background-color: transparent; position: relative; z-index: 2;"></asp:TextBox>
                            </div>
                        </td>
                      

                    </tr>
                    <tr>
                        <td style="padding-right: 5px;">

                            <asp:CheckBox ID="CheckBox2" runat="server" />已阅读和同意礼尚挚广<a href="/html.aspx?id=32" target="_blank" style="color: red;">退换货协议</a>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <div class="b_l_w" style="border-top: 1px solid #DDDDDD; background-color: #EEEEEE;">
        <div style="padding: 5px;">
            <div class="b_l" style="margin-top: 7px;">
                邮费：<span id="sp_youfei" style="color: #E43B3E;">0</span>元
            </div>
            <div class="b_r" style="width: 80px;">
                <asp:Button ID="bt_zf" runat="server" Text="去支付" CssClass="bt_hon" OnClick="bt_zf_Click" OnClientClick="return xy();"></asp:Button>
            </div>
            <div class="b_r" style="margin: 7px 20px 0px 0px;">
                <b style="color: #000; font-size: 14px;">共付:</b><b style="color: #E43B3E; font-size: 14px;">￥<span id="hxzf"><asp:Literal ID="zong" runat="server"></asp:Literal></span></b>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
