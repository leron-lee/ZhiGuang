<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="wysdv.aspx.cs" Inherits="Web.admin.username.wysdv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>申请列表</strong></li></ul>
    <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th>
                名称
            </th>
            <th>
                粉丝数
            </th>
            <th>
                联系方式
            </th>
            <th>
                地区
            </th>
            <th>
                审核
            </th>
           
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">

            <td>
                <%#Eval("name")%>
            </td>
            <td>
                <%#get.ren(Eval("username"))%>
            </td>
            <td>
                <%#Eval("phone")%>
            </td>
            <td>
                <%#get.s_sheng(Eval("s_sheng"))%>
                <%#get.s_shi(Eval("s_shi"))%>
                <%#get.s_xian(Eval("s_xian"))%>
            </td>
            <td>
                <%#get.sh(Eval("sh")) %>
            </td>
            <td style="text-align:center;display:none;">
                <a href='wysdv_up.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv <%#get.sh_class(Eval("sh")) %>">审核通过</a>
                <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

    <div style="float:left;width:100%;display:inline;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</asp:Content>
