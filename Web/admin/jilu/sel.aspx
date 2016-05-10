<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sel.aspx.cs" Inherits="Web.admin.jilu.sel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


<ul class="navLocation"><li><strong>提现记录</strong></li></ul>

<div class="b_l_w" style="padding:10px 0px 10px 0px;">
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>&nbsp;&nbsp;用户名：</td>
        <td>&nbsp;<asp:TextBox ID="username" runat="server" CssClass="formTitle l20"></asp:TextBox></td>
        <td>&nbsp;&nbsp;状态：</td>
        <td>
            <asp:RadioButtonList ID="zt" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
            <asp:ListItem Value="1">提现中</asp:ListItem>
            <asp:ListItem Value="2">完成</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" 
                UseSubmitBehavior="false" onclick="Button1_Click"></asp:Button></td>
    </tr>
</table>
</asp:Panel>
</div>

    <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th>
                用户名
            </th>
            <th>
                内容
            </th>
            <th style="width:100px;">
                金额
            </th>
            <th style="width:80px;">
                状态
            </th>
            <th style="width:130px;">
                时间
            </th>
            <th style="width:130px;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server"  EnableViewState="false">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <%#Eval("tj_username") %>
            </td>
            <td>
                <%#Eval("nt") %>
            </td>
            <td>
                <%#get.jfcaostr(Eval("cao"),Eval("JF")) %>
            </td>
            <td>
                <%#get.jfzt(Eval("zt")) %>
            </td>
            <td>
                <%#Eval("times") %>
            </td>
            <td style="text-align:center;">
                <%#tjcz(Eval("id"),Eval("zt")) %>&nbsp;  
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

    <div style="float:left;width:100%;display:inline;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>

</asp:Content>
