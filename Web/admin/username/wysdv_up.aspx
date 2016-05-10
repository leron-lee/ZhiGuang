<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="wysdv_up.aspx.cs" Inherits="Web.admin.username.wysdv_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table898 td { padding: 10px 0px 10px 0px; }
        .table898 .td1 { text-align:right;width:200px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>编辑</strong></li></ul>
    <div class="infoBox">
        <fieldset>
            <table width="100%" class="table898" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:100px;">
                        用户名：
                    </td>
                    <td>
                        <asp:Literal ID="username" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px;">
                        粉丝数：
                    </td>
                    <td>
                        <asp:Literal ID="fen" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px;">
                        联系方式：
                    </td>
                    <td>
                        <asp:Literal ID="phone" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px;">
                        所在地区：
                    </td>
                    <td>
                        <asp:Literal ID="address" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px;">
                        设置佣金率(%)
                    </td>
                    <td>
                        <asp:TextBox ID="dvfh" runat="server" CssClass="formTitle yan1"></asp:TextBox>
                        %
                        (最高不能超过<b style="color:red;"><%=bl %></b>%)
                        <asp:RequiredFieldValidator ID="rdvfh" ControlToValidate="dvfh" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="确定申请通过" UseSubmitBehavior="false" CssClass="formInput01" OnClick="Button1_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

