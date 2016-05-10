<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="um_sel.aspx.cs" Inherits="Web.admin.username.um_sel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>查看用户</strong></li></ul>

<div class="b_l_w" style="padding:10px 0px 10px 0px;">
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>&nbsp;&nbsp;账号：</td>
        <td>&nbsp;<asp:TextBox ID="username" runat="server" Width="90px"></asp:TextBox></td>
        <td>&nbsp;&nbsp;推荐账号：</td>
        <td>&nbsp;<asp:TextBox ID="tj_username" runat="server" Width="90px"></asp:TextBox></td>
        <td>&nbsp;&nbsp;代理地区：</td>
        <td>
            <select id="s_sheng" name="s_sheng" class="select">
                <option value="">请选择省份</option>
            </select>
            <select id="s_shi" name="s_shi" class="select">
                <option value="">请选择城市</option>
            </select>
            <select id="s_xian" name="s_xian" class="select">
                <option value="">请选择县区</option>
            </select>
            <script>
                $(function () {
                    s_s_x_mo("<%=_dl_sheng%>", "<%=_dl_shi%>", "<%=_dl_xian%>");
                });
            </script>
        </td>
        <td>&nbsp;&nbsp;大V：</td>
        <td>
            <asp:DropDownList ID="dv" runat="server">
            <asp:ListItem Value="">全部</asp:ListItem>
            <asp:ListItem Value="1">大V</asp:ListItem>
            </asp:DropDownList>
        </td>
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
                代理级别
            </th>
            <th>
                会员级别
            </th>
            <th>
                余额
            </th>
            <th>
                红包
            </th>
            <th>
                现金卷
            </th>
            <th style="width:130px;">
                注册时间
            </th>
            <th style="width:70px;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <%#Eval("username")%>&nbsp;
            </td>
            <td>
                <%#get.username(Eval("tj_username"))%>&nbsp;
            </td>
            <td>
                <%#(Eval("name"))%>&nbsp;
            </td>
            <td>
                <%#get.jb(Eval("username"))%>
                <br />
                <div style="text-align:center;">
                    <a href="jb_up.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>">修改</a>
                </div>
            </td>
            <td>
                <%#get.jb2(Eval("username"))%>
                <br />
                <div style="text-align:center;">
                    <a href="jb_up.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>">修改</a>
                </div>
            </td>
            <td>
                <%#get.ye(Eval("username"))%>元
            </td>
            <td>
                <%#get.hb(Eval("username"))%>元
            </td>
            <td>
                <%#get.xfj(Eval("username"))%>元
            </td>
            <td>
                <%#Eval("times")%>&nbsp;
            </td>
            <td>
            <a href="um_in.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>">查看</a>
            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server">删除</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;"><asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>
</asp:Content>

