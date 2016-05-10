<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="new_type.aspx.cs" Inherits="Web.admin.news.new_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div style="float:left;display:inline;width:100%;margin-top:20px;font-weight:bold;">
<div class="b_l">
    查看信息
</div>
<div class="b_r">
    <a href="new_type_in.aspx" style="color:Green;">■添加信息类型</a>
    &nbsp;
</div>
</div>
<div style="float:left;display:inline;width:100%;margin-top:3px;">
    <table id="talbe110" class="Grid" width="100%">
        <tr>
            <th style="width:50px;">
                序号
            </th>
            <th>
                名称
            </th>
            <th style="width:12%;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr>
            <td>
                <%#Eval("id") %>
            </td>
            <td>
            <a href="news.aspx?typeid=<%#Eval("id") %>">
                <%#Eval("name")%>
            </a>
            </td>
            <td>
            
            <asp:LinkButton ID="LinkButton3" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server">上移</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server">下移</asp:LinkButton>
            <a href="new_type_in.aspx?id=<%#Eval("id") %>">编辑</a>
            <a href="news.aspx?typeid=<%#Eval("id") %>">查看</a>
            
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;"><div style="float:right;display:inline;margin-right:25px;"><asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>

</asp:Content>
