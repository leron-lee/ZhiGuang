<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="excel_list.aspx.cs" Inherits="Web.admin.fh.excel_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>历史Excel列表</strong></li></ul>
    <div class="b_l_w">
        <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
            <tr class="tabTitleMain">
                <th>
                    名称
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
            <ItemTemplate>
                <tr>
                    <td style="padding:10px;">
                        <a href="<%#Eval("neirong") %>" target="_blank"><%#Eval("name") %>点击下载</a>
                    </td>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="b_l_w" style="height: 15px; overflow: hidden;"></div>
    <div class="b_l_w" style="text-align: center; line-height: 23px;padding-bottom:10px;">
        <div class="b_r" style="margin-right:10px;">
            <%=fystr%>
        </div>
    </div>
</asp:Content>
