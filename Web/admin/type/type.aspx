<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="type.aspx.cs" Inherits="Web.admin.type.type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/dntmanager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>栏目管理</strong></li></ul>

    <div class="b_l" style="width:99%;margin-left:5px;">

    <asp:Panel ID="Panel1" CssClass="ManagerForm" runat="server" Visible="false">
        <fieldset>
            <legend style="background:url(../images/icons/icon44.jpg) no-repeat 6px 50%;">添加信息</legend>
            <asp:Panel ID="Panel2" runat="server" DefaultButton="Button1">
                <table width="100%" class="table898">
                    <tr>
                    <td style="text-align:right;width:200px;">
                        信息名：
                    </td>
                    <td style="width:150px;">
                        <asp:TextBox ID="TextBox3" MaxLength="100"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text=" 添加 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click"  />
                    </td>
                </tr>
                </table>
            </asp:Panel>
        </fieldset>
    </asp:Panel>
    
    
    <div class="ManagerForm">
            <fieldset>
                
            <legend style="background:url(../images/icons/icon55.jpg) no-repeat 6px 50%;">栏目列表</legend>
                 
                 <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal>

            </fieldset>
    </div>    
    
    </div>
            
</asp:Content>