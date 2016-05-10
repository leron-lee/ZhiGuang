<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="new_type_in.aspx.cs" Inherits="Web.admin.news.new_type_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="ManagerForm">
            <fieldset>
            <%if (Request.QueryString["id"] == null)
                  { %>
                <legend style="background:url(../images/icons/icon52.jpg) no-repeat 6px 50%;">添加信息类型</legend>
                <%}
                  else
                  { %>
                <legend style="background:url(../images/icons/icon55.jpg) no-repeat 6px 50%;">修改信息类型</legend>
                <%} %>
            
                <table width="100%" class="table898">
            <tr>
                <td  style="text-align:right;">
                名称：
                </td>
                <td>
                <asp:TextBox ID="TextBox1" MaxLength="100"  runat="server" CssClass="formTitle"></asp:TextBox>
                
                </td>
                
            </tr>
            <tr>
                <td  style="text-align:right;">
                title：
                </td>
                <td>
                <asp:TextBox ID="TextBox2"  runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  style="text-align:right;">
                关键字：
                </td>
                <td>
                <asp:TextBox ID="TextBox3"   runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  style="text-align:right;">
                描述：
                </td>
                <td>
                <asp:TextBox ID="TextBox4"   runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
                <td>
                                    <asp:Button ID="Button1" runat="server" Text=" 添加 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click"  />

                </td>
            </tr>
            </table>
            </fieldset>
    </div>
</asp:Content>
