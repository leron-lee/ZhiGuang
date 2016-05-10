<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="wx_login1.aspx.cs" Inherits="Web.user.wx_login1" %>
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
        } else {
            return true;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div style="padding:5px;">
        <div class="b_l_w" style="text-align:center;">
            <b style="font-size:18px;">会员绑定</b>
        </div>
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
            <asp:Button ID="login_bt" runat="server" Text="绑定" CssClass="bt_hon" OnClick="login_bt_Click" OnClientClick="return yz();"></asp:Button>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>

