<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sisu_up.aspx.cs" Inherits="Web.admin.sisu.sisu_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<%if (Request.QueryString["id"] == null)
  { %>

<ul class="navLocation"><li><strong>网站内容增加</strong></li></ul>
<%}
  else
  { %>

<ul class="navLocation"><li><strong>网站内容修改</strong></li></ul>
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
                    <td>
                        类型：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="ltype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="ltype_SelectedIndexChanged">
                        <asp:ListItem Value="1" Selected="True">内容</asp:ListItem>
                        <asp:ListItem Value="2">背景</asp:ListItem>
                        <asp:ListItem Value="3">链接</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <tr>
                        <td>背景：</td>
                        <td>
                            <div class="b_l">
                                <asp:TextBox ID="bj"  runat="server" CssClass="formTitle"></asp:TextBox>
                            </div>
                            <div class="b_l" style="margin:2px 0px 0px 5px;">
                                <%=get.upload(bj.ClientID) %>
                            </div>
                            <div class="b_l" style="margin:7px 0px 0px 5px;">
                                
                            </div>
                        </td>
                    </tr>
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" Visible="false">
                    <tr>
                        <td>链接：</td>
                        <td>
                            <div class="b_l">
                                <asp:TextBox ID="href" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Visible="false">
                    <tr>
                        <td>
                            内容:
                        </td>
                        <td>
                            <script type="text/javascript">
                                $(function () {
                                    var oFCKeditor = new FCKeditor('<%= TextBox1.ClientID %>');
                                    oFCKeditor.BasePath = '/L_editor/'
                                    oFCKeditor.Height = 450;
                                    oFCKeditor.ReplaceTextarea();
                                });
                            </script>
                            <asp:TextBox ID="TextBox1"  Width="100%" Height="280px"   runat="server" CssClass="formTitle" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
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
