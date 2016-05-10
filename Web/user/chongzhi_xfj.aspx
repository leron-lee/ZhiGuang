<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="chongzhi_xfj.aspx.cs" Inherits="Web.user.chongzhi_xfj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            充值消费劵
        </div>
        <div class="b_r" style="margin:0px 5px 0px 0px;">
            
        </div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
    <div style="padding:5px;">
        <div class='b_l_w'>
            <div class="ipt">
                <asp:DropDownList ID="s1" runat="server" CssClass="select">
                <asp:ListItem Value="100">100元(送5个分销名额)</asp:ListItem>
                <asp:ListItem Value="200">200元(送10个分销名额)</asp:ListItem>
                <asp:ListItem Value="300">300元(送20个分销名额)</asp:ListItem>
                <asp:ListItem Value="400">400元(送35个分销名额)</asp:ListItem>
                <asp:ListItem Value="500">500元(送50个分销名额)</asp:ListItem>
                <asp:ListItem Value="1000">1000元(送150个分销名额)</asp:ListItem>
                <asp:ListItem Value="10000">10000元(不限制分销名额)</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class='b_l_w' style="margin-top:5px;">
            <asp:Button ID="cz_je" runat="server" Text="提交充值" OnClick="cz_je_Click" CssClass="bt_hon"></asp:Button>
        </div>
        <div class='b_l_w' style="margin-top:5px;">
            <b>消费劵有效期</b><br />
            100元-500元有效期三个月<br />
            1000元有效期六个月<br />
            10000元有效期一年
        </div>
        <div class="clear"></div>
    </div>
</div>
</asp:Content>
