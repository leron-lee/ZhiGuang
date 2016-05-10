<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="can.aspx.cs" Inherits="Web.admin.wx.can" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ul class="navLocation"><li><strong>基本信息设置</strong></li></ul>
<div class="infoBox">
    <table width="100%" class="table898">
        <tr>
            <td style="text-align:right;">
                URL：
            </td>
            <td>
                http://<%=Request.Url.Authority %><%=Request.Url.AbsolutePath.Replace("can","url") %>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                Token：
            </td>
            <td>
                <%=getwx.Token() %>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                AppId：
            </td>
            <td>
                <asp:TextBox ID="AppId" Width="500px"  runat="server" CssClass="formTitle" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                AppSecret：
            </td>
            <td>
                <asp:TextBox ID="AppSecret" Width="500px"  runat="server" CssClass="formTitle" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="false" OnClick="Button1_Click"  />
            </td>
        </tr>
    </table>
</div>
</asp:Content>
