<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="shang.aspx.cs" Inherits="Web.shang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            请选择省份
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div style="padding:5px;">
    <div class="zglist">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
            <a href="shang_two.aspx?id=<%#Eval("id") %>"><%#Eval("name") %></a>
        </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>
