<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="in.aspx.cs" Inherits="Web.admin.shang._in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <ul class="navLocation"><li><strong>专柜<%=st %></strong></li></ul>
    <div class="infoBox">
        <table width="100%" class="table898" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align:right;">
                    区域：
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="s_sheng" runat="server" AutoPostBack="true" OnSelectedIndexChanged="s_sheng_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="s_shi" runat="server" AutoPostBack="true" OnSelectedIndexChanged="s_shi_SelectedIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="s_xian" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rs_xian" ControlToValidate="s_xian" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    名称：
                </td>
                <td>
                    <asp:TextBox ID="name" runat="server" CssClass="formTitle" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rname" ControlToValidate="name" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    电话：
                </td>
                <td>
                    <asp:TextBox ID="phone" runat="server" CssClass="formTitle" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rphone" ControlToValidate="phone" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    地址：
                </td>
                <td>
                    <asp:TextBox ID="address" runat="server" CssClass="formTitle" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="raddress" ControlToValidate="address" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="tj_bt" runat="server" Text="" CssClass="formInput01" OnClick="tj_bt_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
