<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="menu_two_in.aspx.cs" Inherits="Web.admin.yk.menu_two_in" %>
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
                    尺寸：
                </td>
                <td>
                    <asp:TextBox ID="name" Width="150px" runat="server" CssClass="formTitle"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rname" ControlToValidate="name" runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    数量：
                </td>
                <td>
                    <asp:TextBox ID="ku" Width="150px" Text="0" runat="server" CssClass="formTitle yan1"></asp:TextBox>
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
