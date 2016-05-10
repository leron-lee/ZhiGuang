<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="chongzhi_ye.aspx.cs" Inherits="Web.user.chongzhi_ye" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            充值金额
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
                <asp:TextBox ID="s1" runat="server" CssClass="yan1" placeholder="请输入充值金额"></asp:TextBox>
            </div>
        </div>
        <div class='b_l_w' style="margin-top:5px;">
            <asp:Button ID="cz_je" runat="server" Text="提交充值" OnClick="cz_je_Click" CssClass="bt_hon"></asp:Button>
        </div>
        <div class='b_l_w' style="margin-top:5px;">
            为了方便购物，体验微店购物的乐趣，快捷，推荐充值200-500元
        </div>
        <div class="clear"></div>
    </div>
</div>
</asp:Content>
