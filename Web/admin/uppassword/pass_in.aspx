<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="pass_in.aspx.cs" Inherits="Web.admin.uppassword.pass_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>增加账号</strong></li></ul>


        <div class="infoBox">
            <fieldset>
                
                <table style="width:100%;">
                    <tr>
                        <td style="width:20%;height:50px;">
                            账号:
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox4" MaxLength="50"  runat="server" CssClass="formTitle"></asp:TextBox>
                        
                        </td>
                    </tr>
                    <tr>
                        <td style="height:50px;">
                            栏目权限:
                        </td>
                        <td>
                            <asp:CheckBoxList ID="qx" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1">系统管理</asp:ListItem>
                            <asp:ListItem Value="2">内容管理</asp:ListItem>
                            <asp:ListItem Value="3">会员管理</asp:ListItem>
                            <asp:ListItem Value="4">订单管理</asp:ListItem>
                            <asp:ListItem Value="5">发货管理</asp:ListItem>
                            <asp:ListItem Value="6">财务管理</asp:ListItem>
                            <asp:ListItem Value="7">栏目管理</asp:ListItem>
                            <asp:ListItem Value="8">微信管理</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:50px;">
                            是否能修改商品分红权:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="iffh" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:50px;">
                            新密码:
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox2" MaxLength="25" TextMode="Password" runat="server" CssClass="formTitle"></asp:TextBox>  
                                                
                        </td>
                    </tr>
                    <tr>
                        <td style="height:50px;">
                            重复密码:
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox3" MaxLength="25" TextMode="Password"  runat="server" CssClass="formTitle"></asp:TextBox>     
                          
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text=" 提交 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>

</asp:Content>
