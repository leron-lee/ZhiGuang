<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.zjd._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table898 td { padding: 10px; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>砸金蛋管理</strong></li></ul>

    <div class="infoBox">
        <table width="100%" class="table898" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align:right;">
                    活动地址：
                </td>
                <td>
                    http://<%=Request.Url.Authority %>/zjd
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    每日限额：
                </td>
                <td>
                    <asp:TextBox ID="hb" runat="server" Text="0" CssClass="formTitle yan1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    前几名免费抽一次？
                </td>
                <td>
                    <asp:TextBox ID="qian" runat="server" Text="0" CssClass="formTitle yan1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    活动说明：
                </td>
                <td>
                    <script type="text/javascript">
                        $(function () {
                            var oFCKeditor = new FCKeditor('<%= nt.ClientID %>');
                            oFCKeditor.BasePath = '/L_editor/'
                            oFCKeditor.Height = 450;
                            oFCKeditor.ReplaceTextarea();
                        });
                    </script>
                    <asp:TextBox ID="nt" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    开始时间：
                </td>
                <td>
                    <asp:TextBox ID="ktimes" runat="server" Text="" CssClass="formTitle"></asp:TextBox>
                    (格式:2014-1-1)格式不能填错
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    结束时间：
                </td>
                <td>
                    <asp:TextBox ID="jtimes" runat="server" Text="" CssClass="formTitle"></asp:TextBox>
                    (格式:2014-1-1)格式不能填错
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="tj_bt" runat="server" Text=" 修改 "  CssClass="formInput01"  UseSubmitBehavior="False"  OnClick="tj_bt_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

