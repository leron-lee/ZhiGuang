<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="Web.admin.yk.menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ul class="navLocation"><li><strong>颜色尺寸列表</strong></li></ul>
<div class="infoBox">
    <div class="b_l_w">
        <div class="b_l">
            <a href="<%=Request.QueryString["url"] %>" class="huang">上一级</a>
        </div>
        <div class="b_r">
            <a href="menu_one_in.aspx?mid=<%=Request.QueryString["mid"] %>&url=<%=Server.UrlEncode(Request.RawUrl) %>" class="lan">增加颜色</a>
        </div>
    </div>
</div>
    <div class="b_l_w" style="margin-top:10px;">
        <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
            <tr class="tabTitleMain">
                <th>颜色</th>
                <th style="width: 250px;">操作</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                    <td style="text-align:left;padding-left:10px;font-weight:bold;"><%#Eval("name") %></td>
                    <td>
                        <a href="menu_two_in.aspx?yk_one_id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>" class="huang">添加尺寸</a>
                        <asp:LinkButton ID="bt_shang" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                        <asp:LinkButton ID="bt_xia" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">下移</asp:LinkButton>
                        <a href='menu_one_in.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                        <asp:LinkButton ID="bt_del" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
                    </td>
                </tr>
                <asp:Repeater ID="Repeater111" runat="server" OnItemCommand="Repeater111_ItemCommand">
                <ItemTemplate>
                    <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                        <td style="text-align:left;padding-left:10px;">
                        　┣&nbsp;<%#Eval("name") %>
                            库存：<%#Eval("ku") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="bt_shang" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                            <asp:LinkButton ID="bt_xia" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">下移</asp:LinkButton>
                            <a href='menu_two_in.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                            <asp:LinkButton ID="bt_del" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
