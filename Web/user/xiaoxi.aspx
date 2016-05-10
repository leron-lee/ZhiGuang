<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="xiaoxi.aspx.cs" Inherits="Web.user.xiaoxi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                消息提醒
            </div>
            <div class="b_r" style="margin-right:5px;">
                
            </div>
        </div>
    </div>
    <div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w">
        <div style="padding:5px;">
            <div class="b_l_w">
                邀请好友注册成功通知
            </div>
            <div class="b_l_w">
                <asp:RadioButtonList ID="xiaoxi_reg" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="1" Selected="True">开</asp:ListItem>
                <asp:ListItem Value="0">关</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                返现到账通知
            </div>
            <div class="b_l_w">
                <asp:RadioButtonList ID="xiaoxi_fx" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="1" Selected="True">开</asp:ListItem>
                <asp:ListItem Value="0">关</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <asp:Button ID="tj_bt" runat="server" Text="提交设置" CssClass="bt_hon" OnClick="tj_bt_Click"></asp:Button>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <b>注：</b>需关注微信公众号才能接收消息
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
