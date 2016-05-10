<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="huifu.aspx.cs" Inherits="Web.admin.wx.huifu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation">
        <li><strong>被动自动回复设置</strong></li>
    </ul>

    <div class="b_l_w" style="padding: 10px 0px 10px 0px;">
        <div class="b_l">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;&nbsp;关键词：</td>
                    <td>&nbsp;<asp:TextBox ID="gjc" runat="server" CssClass="formTitle l20"></asp:TextBox></td>
                    <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" 
                            UseSubmitBehavior="false" onclick="Button1_Click"></asp:Button></td>
                </tr>
            </table>
            </asp:Panel>
        </div>
        <div style="float: right; display: inline; margin-right: 10px;"><a href="huifu_in.aspx?url=<%=Server.UrlEncode(Request.RawUrl) %>" class="lan">增加</a></div>
    </div>

    <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th>标题</th>
            <th style="width:100px;">图片</th>
            <th style="width:300px;">链接</th>
            <th>关键词</th>
            <th style="width: 170px;">操作</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
            <ItemTemplate>
                <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                    <td><%#Eval("name") %></td>
                    <td><a href="<%#Eval("img") %>" target="_blank"><img src="<%#Eval("img") %>" width="80px" height="80px" /></a></td>
                    <td><%#Eval("href") %></td>
                    <td><%#getwx.gjc(Eval("gjc")) %></td>
                    <td style="text-align: center;">
                        <asp:LinkButton ID="LinkButton2" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">下移</asp:LinkButton>
                        <a href='huifu_in.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                        <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <div style="float: left; width: 100%; display:inline;margin-top: 10px;">
        <div style="float: right; display: inline; margin-right: 25px;">
            <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal>
        </div>
    </div>
</asp:Content>

