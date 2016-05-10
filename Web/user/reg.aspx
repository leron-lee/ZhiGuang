<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="Web.user.reg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
    <script>
        function yz() {
            var phone = $("#<%=phone.ClientID%>").val();
            var s_xian = $("#s_xian").val();
            var pwd = $("#<%=pwd.ClientID%>").val();

            if (phone.length != 11) {
                alert('请输入11位的手机号码');
                return false;
            } else if (s_xian == "") {
                alert('请选择所在地');
                return false;
            } else if (pwd.length < 6) {
                alert('请设置大于6个字符的密码');
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div style="padding:5px;position:relative;z-index:2;background-color:#fff;">
    <div class="b_l_w" style="text-align:center;">
        <b style="font-size:18px;">会员注册</b>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="phone" runat="server" placeholder="请输入您的手机号码" CssClass="yan1"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="pwd" TextMode="Password" runat="server" placeholder="请设置登录密码"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <asp:Button ID="reg_bt" runat="server" Text="注册" CssClass="bt_hon" OnClick="reg_bt_Click" OnClientClick="return yz();"></asp:Button>
    </div>
    <div class="b_l_w dis" style="margin-top:5px;">
        <a href="login.aspx" class="bt_lv">已有账号？立即登录</a>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>
