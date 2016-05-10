<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="html.aspx.cs" Inherits="Web.html" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            <%=type_two_name %>
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div style="padding:5px;">
    <div class="w100">
        <%=nt %>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>
