<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sisu_up.aspx.cs" Inherits="Web.admin.links.sisu_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">

<%if (Request.QueryString["id"] == null)
    { %>
                
<ul class="navLocation"><li><strong>增加</strong></li></ul>
<%}
    else
    { %>
                
<ul class="navLocation"><li><strong>修改</strong></li></ul>
<%} %>

<div class="infoBox">

            <fieldset>
                
            
            <table width="100%" class="table898">
            <tr>
                <td>
                    名称:
                </td>
                <td>
                <asp:TextBox ID="TextBox3" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr class="dis">
                <td>
                    图片:
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox2"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox2.ClientID) %>
                    </div>
                </td>           
            </tr>
            <tr class="dis">
                <td>
                    链接:
                </td>
                <td>
                <asp:TextBox ID="TextBox1" Text="http://" Width="500px"   runat="server" CssClass="formTitle"></asp:TextBox>
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
</div>
</asp:Panel>
</asp:Content>
