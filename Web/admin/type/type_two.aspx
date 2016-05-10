<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="type_two.aspx.cs" Inherits="Web.admin.type.type_two" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    window.onload = function () {
        var oFCKeditor = new FCKeditor('<%= TextBox5.ClientID %>');
        oFCKeditor.BasePath = '/L_editor/'
        oFCKeditor.Height = 450;
        oFCKeditor.ReplaceTextarea();
    }
</script>

<script type="text/javascript">
    $(function () {
        selectChange();
    });
    function selectChange() {
        var str = "<%=DropDownList2.ClientID%>";
        var ddlList = document.getElementById(str);
        var item = ddlList.options[ddlList.selectedIndex].value;

        if (item == "1") {
            $("#tuos").show();
        } else {
            $("#tuos").hide();
        }
    }
</script>
<style>
    #tdaaaa *{border:0px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<asp:Panel ID="Panel2" runat="server" DefaultButton="Button1">

<%if (Request.QueryString["uid"] == null)
    { %>
    <ul class="navLocation"><li><strong>添加栏目二级信息</strong></li></ul>
<%}
else
{ %>
                
    <ul class="navLocation"><li><strong>修改栏目二级信息</strong></li></ul>
<%} %>

<div class="infoBox">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
        <table width="100%" class="table898">     
        <tr>
            <td style="text-align:right;">所属的类型：</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="0">请选择所属的类型</asp:ListItem>
                </asp:DropDownList>                
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">系统栏目无法删除？：</td>
            <td id="tdaaaa">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>      
        <tr>
            <td style="text-align:right;">该栏目类型类别：</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" onchange="selectChange()">
                    <asp:ListItem Value="1">页面</asp:ListItem>
                    <asp:ListItem Value="2">文章</asp:ListItem>
                    <asp:ListItem Value="3">产品</asp:ListItem>
                    <asp:ListItem Value="6">微期待</asp:ListItem>
                </asp:DropDownList>                         
            </td>
        </tr>   
        <tr class="dis">
            <td style="text-align:right;">
                图片：
            </td>
            <td>
                <div class="b_l">
                    <asp:TextBox ID="TextBox6"  runat="server" CssClass="formTitle"></asp:TextBox>
                </div>
                <div class="b_l" style="margin:2px 0px 0px 5px;">
                    <%=get.upload(TextBox6.ClientID) %>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                名称：
            </td>
            <td>
                <asp:TextBox ID="TextBox1" Width="500px"   runat="server" CssClass="formTitle"></asp:TextBox>    
            </td>         
        </tr>     
        <tr class="dis">
            <td style="text-align:right;">
                英文名称：
            </td>
            <td>
                <asp:TextBox ID="type_two_name_en" Width="500px"   runat="server" CssClass="formTitle"></asp:TextBox>    
            </td>         
        </tr>   
        <tr class="dis">
            <td style="text-align:right;vertical-align:top;">
                <div class="b_l_w" style="margin-top:7px;text-align:right;">title：</div>
            </td>
            <td>
                <asp:TextBox ID="TextBox2"  Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                <br />(当类型是自定义跳转类型的时候这个文本框写链接 如（http://www.baidu.com）)
            </td>
        </tr>
        <tr class="dis">
            <td  style="text-align:right;">
            关键字：
            </td>
            <td style="height:70px;">
                <asp:TextBox ID="TextBox3"  Width="500px" TextMode="MultiLine" Height="50px"  runat="server" CssClass="formTitle"></asp:TextBox>
            </td>
        </tr>
        <tr class="dis">
            <td style="text-align:right;">
                描述：
            </td>
            <td style="height:70px;">
                <asp:TextBox ID="TextBox4"   Width="500px" TextMode="MultiLine" Height="50px" runat="server" CssClass="formTitle"></asp:TextBox>
            </td>
        </tr>     
        <tr id="tuos">
            <td  style="text-align:right;">
                编辑栏目内容：
            </td>
            <td style="height:500px;">
                <asp:TextBox ID="TextBox5"  Width="100%" runat="server" CssClass="formTitle" TextMode="MultiLine"></asp:TextBox>
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
    </asp:Panel>
</div>

<asp:Literal ID="Literal1" runat="server" Visible="false" ></asp:Literal>

</asp:Panel>
</asp:Content>

