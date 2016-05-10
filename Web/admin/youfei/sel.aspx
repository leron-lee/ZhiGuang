<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sel.aspx.cs" Inherits="Web.admin.youfei.sel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>邮费设置</strong></li></ul>
    <div class="b_l_w">
        <div style="padding:10px;">
            <table width="100%" class="table898" cellpadding="0" cellspacing="5">
                <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr>
                        <td style="text-align:right;">
                            <%#Eval("sheng") %>：
                        </td>
                        <td>
                            <input name="sheng_<%#Eval("id") %>" type="text" value="<%#Eval("price") %>" class="formTitle yan1" /> 元
                        </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="tj_xg" runat="server" Text="修改" CssClass="formInput01" OnClick="tj_xg_Click"></asp:Button>
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
