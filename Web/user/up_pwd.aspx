<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="up_pwd.aspx.cs" Inherits="Web.user.up_pwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            修改密码
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div class="clear w100"><img src="/images/cart5.jpg" /></div>
    <div style="padding:5px;">
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="ypwd" runat="server" placeholder="请输入原密码"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="xpwd" runat="server" placeholder="请输入新密码" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="cpwd" runat="server" placeholder="请输入重复密码" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:10px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="bt" runat="server" Text="保存修改" CssClass="bt_hon" OnClick="bt_Click"></asp:Button>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
