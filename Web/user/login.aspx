<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.user.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function yz() {
        var phone = $("#<%=phone.ClientID%>");
        var pwd = $("#<%=pwd.ClientID%>");
        if (phone.val() == "") {
            alert("请输入手机号码");
            phone.focus();
            return false;
        } else if (pwd.val() == "") {
            alert("请输入密码");
            pwd.focus();
            return false;
        }
    }
    $(function () {
        is_weixin();
    });
    function is_weixin() {
        var ua = navigator.userAgent.toLowerCase();
        if (ua.match(/MicroMessenger/i) == "micromessenger") {
            $("#xianshi").hide();
            $("#<%=wx_bt.ClientID%>").click();
        } else {

        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div id="xianshi" style="padding:5px;">
    <div class="b_l_w" style="text-align:center;">
        <b style="font-size:18px;">会员登录</b>
    </div>
    <asp:Panel ID="login_pl" runat="server" DefaultButton="login_bt">
        <div class="b_l_w" style="margin-top:10px;">
            <div class="ipt">
                <asp:TextBox ID="phone" runat="server" placeholder="请输入您的手机号码" CssClass="yan1"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="pwd" TextMode="Password" runat="server" placeholder="请输入您的密码"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="login_bt" runat="server" Text="登录" CssClass="bt_hon" OnClick="login_bt_Click" OnClientClick="return yz();"></asp:Button>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="wxlogin" class="b_l_w dis" style="margin-top:5px;">
            <asp:Button ID="wx_bt" runat="server" Text="微信登录" CssClass="bt_lv" OnClick="wx_bt_Click"></asp:Button>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <a href="reg.aspx" class="bt_cheng">还没有账号？立即注册</a>
        </div>
    </asp:Panel>
    <div class="clear"></div>
</div>
</asp:Content>
