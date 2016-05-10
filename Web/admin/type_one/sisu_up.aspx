<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sisu_up.aspx.cs" Inherits="Web.admin.type_one.sisu_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<%if (Request.QueryString["id"] == null)
    { %>
                
<ul class="navLocation"><li><strong>增加</strong></li></ul>
<%}
    else
    { %>
                
<ul class="navLocation"><li><strong>修改</strong></li></ul>
<%} %>

<div class="infoBox">
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
<fieldset>
              
<table width="100%" class="table898">
<tr>
    <td>
    名称:
    </td>
    <td>
        <asp:TextBox ID="TextBox3" Width="500px" MaxLength="100"  runat="server" CssClass="formTitle"></asp:TextBox>
    </td>
</tr>
<tr>
<td>&nbsp;
</td>
<td>

<asp:Button ID="Button1" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click" />

</td>
</tr>
            </table>

            </fieldset>
</asp:Panel>
</div>            
</asp:Content>