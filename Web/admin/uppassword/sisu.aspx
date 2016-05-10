<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sisu.aspx.cs" Inherits="Web.admin.uppassword.sisu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>查看管理账号</strong></li></ul>


<div style="float:left;display:inline;width:100%;margin-top:20px;">
<div style="float:left;font-weight:bold;"></div>
<div style="float:right;display:inline;margin-right:10px;"><a href="pass_in.aspx" class="lan">增加</a></div>
</div>

<div>

<div style="float:left;display:inline;width:100%;margin-top:3px;">
    <table id="talbe110" class="tabBox" width="100%">
        <tr class="tabTitleMain">
			<th style="width:5%;">
				序号
			</th>
            <th style="width:50%">
                名称
            </th>
            <th style="width:20%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
			<td>
				<%#Eval("id")%>
			</td>
            <td>
                <div style="height:20px;overflow:hidden;"><%#Eval("username")%></div>
            </td>
            <td>
            <a href='uppassword.aspx?id=<%#Eval("id") %>' class="lv">编辑</a>      
            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass='<%#get.kong(ifid(Eval("id")),"hon") %>'><%#ifid(Eval("id"))%></asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>

</div>

</asp:Content>
