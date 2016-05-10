<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="address_in.aspx.cs" Inherits="Web.user.address_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                <%=sv %>地址
            </div>
            <div class="b_r" style="margin-right:5px;">
                
            </div>
        </div>
    </div>
    <div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w">
    <div style="padding:5px;position:relative;z-index:2;">
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="name" runat="server" placeholder="收货人姓名"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="phone" runat="server" placeholder="手机号码" CssClass="yan1"></asp:TextBox>
            </div>
        </div>
        <%--<div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="code" runat="server" placeholder="邮政编码" CssClass="yan1"></asp:TextBox>
            </div>
        </div>--%>
        <div class="b_l_w" style="margin-top:5px;">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:33%;">
                        <select id="s_sheng" name="s_sheng" class="select">
                            <option value="">请选择省份</option>
                        </select>
                    </td>
                    <td style="width:33%;padding-left:2px;">
                        <select id="s_shi" name="s_shi" class="select">
                            <option value="">请选择城市</option>
                        </select>
                    </td>
                    <td style="width:33%;padding-left:2px;">
                        <select id="s_xian" name="s_xian" class="select">
                            <option value="">请选择县区</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
        <script>
            $(function () {
                s_s_x_mo("<%=sheng%>", "<%=shi%>", "<%=xian%>");
            });
        </script>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="address" runat="server" placeholder="请输入详细地址" TextMode="MultiLine" Height="80px"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="bt_tj" runat="server" Text="" CssClass="bt_hon" OnClick="bt_tj_Click"></asp:Button>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear"></div>
    </div>
    </div>
</asp:Content>

