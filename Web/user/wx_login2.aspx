<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="wx_login2.aspx.cs" Inherits="Web.user.wx_login2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    function yz() {
        var phone = $("#<%=phone.ClientID%>");
        var pwd = $("#<%=pwd.ClientID%>");
        var cpwd = $("#<%=cpwd.ClientID%>");

        if (phone.val().length != 11) {
            alert("请输入11位的手机号码");
            phone.focus();
            return false;
        } else if (pwd.val().length < 6 || pwd.val().length > 16) {
            alert("请输入6-16个字符的密码");
            pwd.focus();
            return false;
        }
        else if (cpwd.val() != "") {
            alert("请输入重复密码");
            cpwd.focus();
            return false;
        }
        else if (cpwd.val() != pw.val()) {
            alert("两次密码输入不一致");
            cpwd.focus();
            return false;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div style="padding:5px;">
        <div class="b_l_w" style="text-align:center;">
            <b style="font-size:18px;">设置用户名密码</b>
        </div>
        <div class="b_l_w" style="margin-top:10px;">
            <div class="ipt">
                <asp:TextBox ID="phone" runat="server" placeholder="请输入您的手机号码" CssClass="yan1"></asp:TextBox>
            </div>
            推荐：注册的手机和收货地址的手机号码一致
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="pwd" TextMode="Password" runat="server" placeholder="请输入您的密码"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="cpwd" TextMode="Password" runat="server" placeholder="请再次输入您的密码"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <asp:Button ID="reg_bt" runat="server" Text="提交设置" CssClass="bt_hon" OnClick="reg_bt_Click"></asp:Button>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
