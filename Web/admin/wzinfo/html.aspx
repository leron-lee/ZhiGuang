<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="html.aspx.cs" Inherits="Web.admin.wzinfo.html" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/dntmanager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    
    <ul class="navLocation"><li><strong>静态页面管理</strong></li></ul>
    <div class="b_l" style="width:45%;margin-left:35px;">
    <div class="ManagerForm">

    <fieldset>
            <legend style="background:url(../images/icons/icon44.jpg) no-repeat 6px 50%;">生成速度</legend>

            <table width="100%" class="table898">
            <tr>
                <td style="text-align:right;width:100px;">
                    毫秒：
                </td>
                <td style="width:150px;">
                <asp:TextBox ID="TextBox3" Text="0" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text=" 修改 "  CssClass="formInput01" UseSubmitBehavior="False" onclick="Button6_Click"    />
                    (1秒=1000毫秒)
                </td>
            </tr>
            </table>

    </fieldset>

    </div>
    </div>

<div class="infoBox">



            <div class="b_l" style="padding:10px;width:80%;">

            <div class="b_l" style="margin:0px 0px 0px 10px;">
                        <asp:Button ID="Button2" runat="server" Text=" 一键生成全站 " CssClass="formInput01" UseSubmitBehavior="False" onclick="Button2_Click"  />
            </div>

            <div class="b_l" style="margin:0px 0px 0px 10px;">
                        <asp:Button ID="Button3" runat="server" Text=" 生成网站首页 " CssClass="formInput01" UseSubmitBehavior="False" onclick="Button3_Click"  />
            </div>

            <div class="b_l" style="margin:0px 0px 0px 10px;">
                        <asp:Button ID="Button4" runat="server" Text=" 生成二级页面 " CssClass="formInput01" UseSubmitBehavior="False"   onclick="Button4_Click"  />
            </div>

            <div class="b_l" style="margin:0px 0px 0px 10px;">
                        <asp:Button ID="Button5" runat="server" Text=" 生成三级页面 " CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button5_Click"  />
            </div>

           <div class="b_l" style="margin:0px 0px 0px 10px;">
                    <asp:Button ID="Button1" runat="server" Text=" 删除静态页面 "  CssClass="formInput01" UseSubmitBehavior="False" onclick="Button1_Click"  />
            </div>

            <div class="b_l_w" style="text-align:left;">
                <div class="b_l" style="margin:20px 0px 0px 10px;">
                <b>注：</b>
                <asp:Literal ID="ym" runat="server"></asp:Literal>
                </div>
            </div>

            </div>        



</div>

</asp:Content>
