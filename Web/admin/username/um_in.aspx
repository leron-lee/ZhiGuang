<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="um_in.aspx.cs" Inherits="Web.admin.username.um_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table898 td { padding:10px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>用户信息</strong></li></ul>



            <div class="infoBox">
                <table width="100%" class="table898">
                <tr>
                <td  style="text-align:right;width:200px;">
                    推荐账号：
                </td>
                <td>
                
                    <asp:Literal ID="tj_username" runat="server"></asp:Literal>
                
                </td>
                </tr>
            <tr>
                <td  style="text-align:right;width:200px;">
                账号：
                </td>
                <td>
                
                    <asp:Literal ID="username" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr>
                <td  style="text-align:right;">
                    密码：
                </td>
                <td>
                
                    <asp:Literal ID="pwd" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr>
                <td  style="text-align:right;">
                    支付密码：
                </td>
                <td>
                
                    <asp:Literal ID="pay_pwd" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr>
                <td  style="text-align:right;">
                姓名：
                </td>
                <td>
                
                <asp:Literal ID="name" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr>
                <td  style="text-align:right;">
                联系方式：
                </td>
                <td>
                
                <asp:Literal ID="phone" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr>
                <td  style="text-align:right;">
                    地址：
                </td>
                <td>
                
                <asp:Literal ID="address" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr class="dis">
                <td  style="text-align:right;">
                    分销名额：
                </td>
                <td>
                    <asp:TextBox ID="fx" runat="server" CssClass="formTitle yan1"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td  style="text-align:right;">
                注册时间：
                </td>
                
                <td>
                
                <asp:Literal ID="times" runat="server"></asp:Literal>
                
                </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        
                        <asp:Button ID="Button1" runat="server" Text="修改" onclick="Button1_Click" />
                
                <a href="javascript:window.history.back();">返回</a>

                    </td>
                </tr>
            
            
            </table>

            
    </div>

</asp:Content>

