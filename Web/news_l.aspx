<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="news_l.aspx.cs" Inherits="Web.news_l" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div style="padding:5px;">
    <div class="b_l_w">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
            <div style="font-size:16px;"><%#Eval("name") %></div>
            <div style="color:#B8B8B8;"><%#Convert.ToDateTime(Eval("times")).ToShortDateString() %></div>
            <div class="w100 <%=imgdis %>" style="padding-top:10px;">
                <img src="<%#Eval("x_img") %>" />
            </div>
            <div class="w100" style="padding-top:10px;">
                <%#Eval("nrtext") %>
            </div>
        </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>
