<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="shang_four.aspx.cs" Inherits="Web.shang_four" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            专柜列表
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div style="padding:5px;">
    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
    <ItemTemplate>
        <div class="b_l_w" style="padding:5px 0px 5px 0px;border-bottom:1px dashed #ccc;">
            <div class="b_l_w">
                <b style="font-size:14px;"><%#Eval("name") %></b>
            </div>
            <div class="b_l_w">
                电话：<%#Eval("phone") %>
            </div>
            <div class="b_l_w">
                地址：<%#Eval("address") %>
            </div>
        </div>
    </ItemTemplate>
    </asp:Repeater>
    <div class="clear"></div>
</div>
</asp:Content>
