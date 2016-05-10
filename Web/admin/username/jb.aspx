<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="jb.aspx.cs" Inherits="Web.admin.username.jb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>级别名称</strong></li></ul>

    <div style="padding:10px;">
        <table cellpadding="5" cellspacing="5">
            <tr>
                <td>级别一：</td>
                <td>
                    <asp:TextBox ID="s1" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td class="dis22">
                    收益：
                </td>
                <td class="dis22">
                    <asp:TextBox ID="s1_zhe" runat="server" CssClass="formTitle yan2" Text="0" Width="30px"></asp:TextBox>
                    %
                </td>
            </tr>
            <tr>
                <td>级别二：</td>
                <td>
                    <asp:TextBox ID="s2" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td class="dis22">
                    收益：
                </td>
                <td class="dis22">
                    <asp:TextBox ID="s2_zhe" runat="server" CssClass="formTitle yan2" Text="0" Width="30px"></asp:TextBox>
                    %
                </td>
            </tr>
            <tr>
                <td>级别三：</td>
                <td>
                    <asp:TextBox ID="s3" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td class="dis22">
                    收益：
                </td>
                <td class="dis22">
                    <asp:TextBox ID="s3_zhe" runat="server" CssClass="formTitle yan2" Text="0" Width="30px"></asp:TextBox>
                    %
                </td>
            </tr>
            <tr>
                <td>级别四：</td>
                <td>
                    <asp:TextBox ID="s4" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td class="dis22">
                    收益：
                </td>
                <td class="dis22">
                    <asp:TextBox ID="s4_zhe" runat="server" CssClass="formTitle yan2" Text="0" Width="30px"></asp:TextBox>
                    %
                </td>
            </tr>
            <tr>
                <td>级别五：</td>
                <td>
                    <asp:TextBox ID="s5" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td class="dis22">
                    收益：
                </td>
                <td class="dis22">
                    <asp:TextBox ID="s5_zhe" runat="server" CssClass="formTitle yan2" Text="0" Width="30px"></asp:TextBox>
                    %
                </td>
            </tr>
            <tr>
                <td>级别六：</td>
                <td>
                    <asp:TextBox ID="s6" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td class="dis22">
                    收益：
                </td>
                <td class="dis22">
                    <asp:TextBox ID="s6_zhe" runat="server" CssClass="formTitle yan2" Text="0" Width="30px"></asp:TextBox>
                    %
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="tj_xg" runat="server" Text="修改" CssClass="formInput01" OnClick="tj_xg_Click"></asp:Button>
                </td>
            </tr>
        </table>
        <div class="clear"></div>
    </div>
</asp:Content>
