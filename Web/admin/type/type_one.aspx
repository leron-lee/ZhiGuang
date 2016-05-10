<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="type_one.aspx.cs" Inherits="Web.admin.type.type_one" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    #tdaaaa *{border:0px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>修改一级类型</strong></li></ul>

<asp:Panel ID="Panel2" runat="server" CssClass="infoBox" DefaultButton="Button1">
    <table width="100%" class="table898">
    <tr>
        <td style="text-align:right;">系统栏目无法删除？：</td>
        <td id="tdaaaa">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td style="text-align:right;">
            名称：
        </td>
        <td>
            <asp:TextBox ID="TextBox3" Width="500px"  runat="server" CssClass="formTitle"></asp:TextBox>         
        </td>         
    </tr>
    <tr class="dis">
        <td style="text-align:right;">
            英文名称：
        </td>
        <td>
            <asp:TextBox ID="type_one_name_en" Width="500px"  runat="server" CssClass="formTitle"></asp:TextBox>         
        </td>         
    </tr>
    <tr style="display:none;">
        <td style="text-align:right;">
            图片：
        </td>
        <td>
            <div class="b_l">
                <asp:TextBox ID="TextBox1"  runat="server" CssClass="formTitle"></asp:TextBox>
            </div>
            <div class="b_l" style="margin:2px 0px 0px 5px;">
                <%=get.upload(TextBox1.ClientID) %>
            </div>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="text-align:left;">
            <asp:Button ID="Button1" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click"  />
        </td>
    </tr>
    </table>
</asp:Panel>
<asp:Literal ID="Literal1" runat="server" Visible="false" ></asp:Literal>

</asp:Content>
