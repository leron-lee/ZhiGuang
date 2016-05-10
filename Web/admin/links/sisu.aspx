<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sisu.aspx.cs" Inherits="Web.admin.links.sisu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


<ul class="navLocation"><li><strong>列表</strong></li></ul>



    <div class="b_l_w" style="padding:10px 0px 10px 0px;"><div style="float:right;display:inline;margin-right:10px;"><a href="sisu_up.aspx?tid=<%=Request.QueryString["tid"] %>&url=<%=Server.UrlEncode(Request.RawUrl) %>" class="lan">增加</a></div></div>

    <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th>
                名称
            </th>
            <th style="width:150px">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">

            <td>
                <div style="height:20px;overflow:hidden;"><%#Eval("name")%></div>
            </td>
            <td style="text-align:center;">
                
                <asp:LinkButton ID="LinkButton2" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">下移</asp:LinkButton>
                <a href='sisu_up.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
              
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>



    <div style="float:left;width:100%;display:inline;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>

</asp:Content>
