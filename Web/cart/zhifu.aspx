<%@ Page Title="" Language="C#" MasterPageFile="~/cart/Cart.master" AutoEventWireup="true" CodeBehind="zhifu.aspx.cs" Inherits="Web.cart.zhifu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>

        function xy() {

            if ($("input[type='checkbox']").is(':checked') == false) {
                alert("请确认已阅读和同意茶家会退换货协议 ！");
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div style="padding: 5px;">
        <div class="b_l_w">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>订单号：</td>
                    <td>
                        <%=ordernumber %>
                    </td>
                </tr>
                <tr>
                    <td>需要支付：</td>
                    <td>
                        <b style="color: red;">￥<%=price %></b>
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
        <div class="b_l_w  dis" style="margin-top: 5px;">
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
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="padding-right: 5px;">
                        <input name="zffs" type="radio" value="wx" checked="checked" />微信支付(只能在微信使用)</td>
                    <td></td>
                </tr>
            </table>

            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="padding-right: 5px;">
                       
                        <asp:CheckBox ID="CheckBox2" runat="server" />已阅读和同意礼尚挚广<a href="/html.aspx?type=32" target="_blank" style="color: red;">退换货协议</a>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div class="b_l_w" style="margin-top: 5px;">
            <asp:Button ID="ljzf_bt" runat="server" Text="立即支付" CssClass="bt_hon" OnClick="ljzf_bt_Click"  OnClientClick="return xy();"></asp:Button>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
