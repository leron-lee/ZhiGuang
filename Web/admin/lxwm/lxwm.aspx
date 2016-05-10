<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="lxwm.aspx.cs" Inherits="Web.admin.lxwm.lxwm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>查看留言信息</strong></li></ul>

    <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th>
                姓名
            </th>
            <th>
                公司名称
            </th>
            <th>
                电话
            </th>
            <th>
                电子邮件
            </th>
            <th style="width:130px;">
                发布时间
            </th>
            <th style="width:130px;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <%#Eval("name") %>
            </td>
            <td>
                <%#Eval("gsmc")%>
            </td>
            <td>
                <%#Eval("tel") %>
            </td>
            <td>
                <%#Eval("email")%>
            </td>
            <td>
                <%#Eval("times") %>
            </td>
            <td style="text-align:center;">

            <a href="lxwm_sel.aspx?id=<%#Eval("id") %>" class="lv">查看</a>
            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
            
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

    <div style="float:left;width:100%;display:inline;margin-top:10px;">
        <div style="float:right;display:inline;margin-right:25px;">
            <%=fystr %>
        </div>
    </div>

</asp:Content>
