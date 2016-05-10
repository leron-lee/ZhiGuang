<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="jilu.aspx.cs" Inherits="Web.user.jilu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            提现记录
        </div>
        <div class="b_r" style="margin:0px 5px 0px 0px;">
            <a href="tixian.aspx" class="a_lv">提现</a>
        </div>
        <div class="b_r" style="margin:0px 5px 0px 0px;">
            余额：<span style="color:#D13D3D;"><%=get.ye(username) %></span>元
        </div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
    <ItemTemplate>
        <div class="b_l_w" style="padding:10px 0px 10px 0px;border-bottom:1px solid #ccc;">
            <div class="b_l" style="margin-left:5px;">
                <%#Eval("nt") %>
                <br />
                <span style="color:#ccc;"><%#Eval("times") %></span>
            </div>
            <div class="b_r" style="margin-right:5px;">
                <%#get.jfcaostr(Eval("cao"),Eval("JF")) %>元
                <br />
                <%#get.jfzt(Eval("zt")) %>
            </div>
        </div>
    </ItemTemplate>
    </asp:Repeater>
</div>
<div class="b_l_w" style="padding:10px 0px 10px 0px;">
    <center>   
        <%=fystr %>
    </center>
</div>
</asp:Content>
