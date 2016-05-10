<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="Online.aspx.cs" Inherits="Web.admin.Online.Online" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/dntmanager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>在线咨询</strong></li></ul>

<div class="b_l" style="width:99%;margin-left:5px;">

<div class="ManagerForm">
            <fieldset>

                <legend style="background:url(../images/icons/icon52.jpg) no-repeat 6px 50%;">增加在线咨询</legend>

            
            <table width="95%" class="table898" cellpadding="10" cellspacing="10">
                <tr>
                    <td style="text-align:right;">是否启动</td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="" AutoPostBack="true" 
                            GroupName="3434" oncheckedchanged="RadioButton1_CheckedChanged" />是
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="" AutoPostBack="true" 
                            GroupName="3434" oncheckedchanged="RadioButton2_CheckedChanged" />否
                    </td>
                </tr>
             <tr>
                <td  style="text-align:right;">
                请选择类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">QQ  客服</asp:ListItem>
                        <asp:ListItem Value="6">企业QQ  客服</asp:ListItem>
                        <asp:ListItem Value="2">阿里旺旺</asp:ListItem>
                        <asp:ListItem Value="3">MSN  客服</asp:ListItem>
                        <asp:ListItem Value="4">skype客服</asp:ListItem>
                        <asp:ListItem Value="5">雅虎通</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td  style="text-align:right;">
                帐号：
                </td>
                <td>
                <asp:TextBox ID="TextBox1" MaxLength="100"  runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  style="text-align:right;">
                说明：
                </td>
                <td>
                <asp:TextBox ID="TextBox2" MaxLength="100"  runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  style="text-align:right;">
                &nbsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text=" 添加 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click"  />
                </td>
            </tr>
	    <tr>
                <td style="text-align:right;">&nbsp;</td>
                <td style="padding-top:10px;"><b>注：</b>如果QQ显示未启动请在<a href="http://wp.qq.com" target="_blank">http://wp.qq.com</a>这里启动服务开设起来</td>
            </tr>
            </table>
            </fieldset>
    </div>

<div  style="float:left;display:inline;width:100%;margin-top:3px;">
    <table id="talbe110" class="tabBox" cellspacing="0" cellpadding="0" width="100%">
        <tr class="tabTitleMain">
            <th style="width:20%;">
                咨询类型
            </th>
            <th style="width:30%">
                帐号
            </th>
            <th style="width:30%">
                说明
            </th>
            <th style="width:20%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <div style="overflow:hidden;height:20px;"><%#qqstr(Eval("pint"))%></div>
            </td>
            <td>
                <div style="overflow:hidden;height:20px;"><%#(Eval("username"))%></div>
            </td>
            <td>
                <div style="overflow:hidden;height:20px;"><%#(Eval("ntest"))%></div>
            </td>
            <td style="text-align:center;">
            <asp:LinkButton ID="LinkButton2" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CausesValidation="False" CssClass="lan">上移</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CausesValidation="False" CssClass="lan">下移</asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CausesValidation="False" CssClass="hon">删除</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
</div>

</div>

</asp:Content>

