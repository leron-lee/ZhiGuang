<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sisu.aspx.cs" Inherits="Web.admin.sisu.sisu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


<ul class="navLocation"><li><strong>查看网站内容</strong></li></ul>


<div class="b_l_w" style="padding:10px 0px 10px 0px;"><div style="float:right;display:inline;margin-right:10px;"><a href="sisu_up.aspx?tid=<%=Request.QueryString["tid"] %>&url=<%=Server.UrlEncode(Request.RawUrl) %>" class="lan">增加</a></div></div>

    <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
			<th style="width:5%;">
				序号
			</th>
            <th style="width:20%">
                名称
            </th>
            <th style="width:10%;">
                类型
            </th>
            <th style="width:50%">
                内容
            </th>
            <th style="width:20%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server"  EnableViewState="false">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
			<td>
				<%#Eval("id")%>
			</td>
            <td>
                <div style="height:20px;overflow:hidden;"><%#Eval("username")%></div>
            </td>
            <td>
                <%#get.ltype(Eval("ltype")) %>
            </td>
            <td>
                <%#ltype(Eval("ltype"),Eval("ntest"))%>&nbsp;
            </td>
            <td style="text-align:center;">
                <a href='sisu_up.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>      
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

    <div style="float:left;width:100%;display:inline;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>

</asp:Content>