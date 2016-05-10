<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="hb_shuoming.aspx.cs" Inherits="Web.user.hb_shuoming" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;">
            红包说明
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
    <div style="padding:5px;">
        <div class="b_l_w">
            <%=get.gethtml(7) %>
        </div>
        <div class="clear"></div>
    </div>
</div>
</asp:Content>
