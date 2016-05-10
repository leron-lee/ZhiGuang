<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="tixian_newpwd.aspx.cs" Inherits="Web.user.tixian_newpwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            设置提现密码
        </div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
    <div style="padding:5px;">
        <div class="b_l_w">
            <div class="ipt">
                <asp:TextBox ID="pay_pwd" runat="server" placeholder="请设置提现密码" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <div class="ipt">
                <asp:TextBox ID="cfpay_pwd" runat="server" placeholder="再次请设置提现密码" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="bt_bj" runat="server" Text="确认提交" CssClass="bt_hon" OnClick="bt_bj_Click"></asp:Button>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear"></div>
    </div>
</div>
</asp:Content>