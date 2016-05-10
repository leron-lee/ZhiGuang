<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="cache.aspx.cs" Inherits="Web.admin.wzinfo.cache" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div class="ManagerForm">
            <fieldset>
                
            <legend style="background:url(../images/icons/icon55.jpg) no-repeat 6px 50%;">网站缓存管理</legend>
            
            <table width="100%" class="table898">
 
                <tr>
                    <td style="text-align:right;width:300px;">
                        是否启动缓存？
                    </td>
                    <td>
                        <div class="b_l">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                        <div style="color:Green;float:left;display:inline;margin:13px 0px 0px 10px;"></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;width:300px;">
                        缓存时间：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="formTitle" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"></asp:TextBox> (分钟)
                        <span style="color:Green;"></span>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="False" onclick="Button1_Click"  />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <b>注：</b><br />
                        1.启动缓存可以提高网站访问速度和提高网站性能<br />
                        2.缓存时间来控制缓存内容更换时间
                    </td>
                </tr>
            </table>
            
            </fieldset>
</div>            

</asp:Content>
