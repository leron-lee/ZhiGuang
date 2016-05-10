<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="mail.aspx.cs" Inherits="Web.admin.mail.mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    
    <ul class="navLocation"><li><strong>邮箱信息设置</strong></li></ul>


    <div class="infoBox">
                
  
            <table width="100%" class="table898">
            <tr>
                <td style="text-align:right;">
                    发送邮箱账号：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" Width="500px"  runat="server" CssClass="formTitle" ></asp:TextBox>
                    （比如liubin3982786@163.com）
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    发送邮箱密码：
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" Width="500px"  runat="server" CssClass="formTitle" ></asp:TextBox>
                    （比如3982786）
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    发送邮箱SMTP：
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" Width="500px"  runat="server" CssClass="formTitle" ></asp:TextBox>
                    （比如smtp.163.com）
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    接受邮件地址：
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" Width="500px"  runat="server" CssClass="formTitle" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
            <td>&nbsp;
            </td>
            <td>
            <asp:Button ID="Button1" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="False" onclick="Button1_Click"  />
            </td>
            </tr>
            </table>

    </div>
  
</asp:Content>
