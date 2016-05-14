<%@ Page Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="UserReview.aspx.cs" Inherits="Web.admin.UserReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>门店申请审核</strong></li></ul>

<div class="b_l_w" style="padding:10px 0px 10px 0px;">
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>&nbsp;&nbsp;账号：</td>
        <td>&nbsp;<asp:TextBox ID="username" runat="server" Width="90px"></asp:TextBox></td>
        <td>&nbsp;&nbsp;推荐账号：</td>
        <td>&nbsp;<asp:TextBox ID="tj_username" runat="server" Width="90px"></asp:TextBox></td>
        <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" 
                UseSubmitBehavior="false" onclick="Button1_Click"></asp:Button></td>
    </tr>
</table>
</asp:Panel>
</div>

<div style="float:left;display:inline;width:100%;margin-top:3px;">
    <table id="talbe110" class="tabBox" width="100%">
        <tr class="tabTitleMain">
            <th>
                用户账号
            </th>
            <th>
                推荐账号
            </th>
            <th>
                姓名
            </th>
            <th>
                审核状态
            </th>
            <th style="width:130px;">
                申请时间
            </th>
            <th style="width:70px;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <%#Eval("UserName")%>&nbsp;
            </td>
            <td>
                <%#Eval("tj_UserName")%>&nbsp;
            </td>
            <td>
                <%#(Eval("TrueName"))%>&nbsp;
            </td>  
            <td>
                <%#StatusTurn(Convert.ToInt32(Eval("Status")))%>&nbsp;
            </td>          
            <td>
                <%#Eval("InsertTime")%>&nbsp;
            </td>
            <td>
            <a href="/fx/ApplyInfor.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>">查看</a>
            <asp:LinkButton ID="LinkButton1" CommandName="pass" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定通过申请！')" runat="server">通过</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" CommandName="refuse" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定拒绝申请！')" runat="server">拒绝</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" CommandName="cancel" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定取消该用户门店资格！')" runat="server">取消资格</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;"><asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>
</asp:Content>
