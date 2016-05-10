<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="news_in.aspx.cs" Inherits="Web.admin.news.news_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    window.onload = function () {
        var oFCKeditor = new FCKeditor('<%= TextBox5.ClientID %>');
        oFCKeditor.BasePath = '/L_editor/'
        oFCKeditor.Height = 450;
        oFCKeditor.ReplaceTextarea();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="ManagerForm">
            <fieldset>
                
            <%if (Request.QueryString["id"] == null)
                  { %>
                <legend style="background:url(../images/icons/icon52.jpg) no-repeat 6px 50%;">信息增加</legend>
                <%}
                  else
                  { %>
                <legend style="background:url(../images/icons/icon55.jpg) no-repeat 6px 50%;">信息修改</legend>
                <%} %>
            <table width="100%" class="table898">
            <tr>
                <td>
                信息标题:
                </td>
                <td>
                <asp:TextBox ID="TextBox1" MaxLength="100"  runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                信息类型:
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                网站标题title:
                </td>
                <td>
                <asp:TextBox ID="TextBox2"   runat="server" CssClass="formTitle"></asp:TextBox>
                
                </td>
            </tr>
            <tr>
                <td>
                网站关键字key:
                </td>
                <td>
                <asp:TextBox ID="TextBox3"   runat="server" CssClass="formTitle"></asp:TextBox>
                
                </td>
            </tr>
            <tr>
                <td>
                网站描述:
                </td>
                <td>
                <asp:TextBox ID="TextBox4"   runat="server" CssClass="formTitle"></asp:TextBox>
                
                </td>
            </tr>
            <tr>
                <td>
                内容:
                </td>
                <td>
                <asp:TextBox ID="TextBox5"  Width="100%" Height="280px"   runat="server" CssClass="formTitle" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            </table>
            <div style="float:left;width:100%;text-align:center;display:inline;margin-top:5px;">
       
            <asp:Button ID="Button1" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="False" onclick="Button1_Click" />
                
            </div>
            </fieldset>
</div>            
</asp:Content>
