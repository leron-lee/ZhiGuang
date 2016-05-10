<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="menu_two_in.aspx.cs" Inherits="Web.admin.wx.menu_two_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ul class="navLocation">
    <li><strong><%=tit %>二级菜单</strong></li>
</ul>
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
    <div class="infoBox">
        <table width="100%" class="table898" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align:right;">
                    名称：
                </td>
                <td>
                    <asp:TextBox ID="name" Width="150px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;padding-top:12px;" valign="top">
                    链接：
                </td>
                <td>
                    <asp:TextBox ID="href" Width="300px" Text="" runat="server" CssClass="formTitle"></asp:TextBox>
                    <div class="b_l_w" style="line-height:23px;">
                        <b>注：</b>这里也可以添加关键字(就是填写被动自动回复消息设置里配置的关键字)，就会触发该条信息事情
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:left;">
                    <asp:Button ID="Button1" runat="server" Text="" CssClass="formInput01" UseSubmitBehavior="False" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
</asp:Content>
