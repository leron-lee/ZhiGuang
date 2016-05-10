<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Web.admin.news.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div style="float:left;display:inline;width:100%;margin-top:20px;">
<div style="float:left;font-weight:bold;">查看<%=typeid(Request.QueryString["typeid"])%></div>
<div style="float:right;display:inline;margin-right:10px;"><a href="news_in.aspx?typeid=<%=Request.QueryString["typeid"].ToString() %>">增加信息</a></div>
</div>
<div style="float:left;display:inline;width:100%;margin-top:3px;">
    <table id="talbe110" class="Grid" width="100%">
        <tr>
            <th style="width:60%">
                信息标题
            </th>
            <th style="width:20%">
                信息类型
            </th>
            <th style="width:20%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr>
            <td>
                <div style="height:20px;overflow:hidden;"><%#Eval("btname")%></div>
            </td>
            <td>
                <div style="height:20px;overflow:hidden;"><%#typeid(Eval("type"))%></div>
            </td>
            <td>
            <asp:LinkButton ID="LinkButton2" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CausesValidation="False">上移</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CausesValidation="False">下移</asp:LinkButton>
            <a href='news_in.aspx?typeid=<%=Request.QueryString["typeid"].ToString() %>&id=<%#Eval("id") %>'>编辑</a>
            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CausesValidation="False">删除</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>
</asp:Content>
