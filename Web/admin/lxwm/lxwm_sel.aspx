<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="lxwm_sel.aspx.cs" Inherits="Web.admin.lxwm.lxwm_sel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table898 td { padding: 10px 0px 10px 0px; }
    .table898 .td1 { text-align:right;width:200px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ul class="navLocation">
    <li><strong>留言信息</strong></li>
</ul>
<div class="infoBox">
    <table width="100%" class="table898" cellpadding="0" cellspacing="0">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
            <tr>
                <td class="td1">姓名：</td>
                <td>
                    <%#Eval("name") %>
                </td>
            </tr>
            <tr>
                <td class="td1">公司名称：</td>
                <td>
                    <%#Eval("gsmc") %>
                </td>
            </tr>
            <tr>
                <td class="td1">联系电话：</td>
                <td>
                    <%#Eval("tel") %>
                </td>
            </tr>
            <tr>
                <td class="td1">邮箱：</td>
                <td>
                    <%#Eval("email") %>
                </td>
            </tr>
            <tr>
                <td class="td1">内容：</td>
                <td>
                    <%#Eval("neir") %>
                </td>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td>&nbsp;
            </td>
            <td>
                <a href="javascript:window.history.back();">返回</a>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
