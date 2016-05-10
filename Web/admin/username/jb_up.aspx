<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="jb_up.aspx.cs" Inherits="Web.admin.username.jb_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <ul class="navLocation"><li><strong>修改级别</strong></li></ul>
    <div style="padding:10px;">
        <table cellpadding="10" cellspacing="10">
            <tr>
                <td style="text-align:right;">当前会员：</td>
                <td>
                    <%=username %>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">当前上级会员：</td>
                <td>
                    <%=sj %>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">代理级别：</td>
                <td>
                    <asp:RadioButtonList ID="jb" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList>
                </td>
            </tr>

             <tr>
                <td style="text-align:right;">会员级别：</td>
                <td>
                    <asp:RadioButtonList ID="jb2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">设置新的上级会员：</td>
                <td>
                    <asp:TextBox ID="tj_username" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">设置代理所在区域：</td>
                <td>
                        <select id="s_sheng" name="s_sheng">
                            <option value="">请选择您所在的省份</option>
                        </select>
                        <select id="s_shi" name="s_shi">
                            <option value="">请选择您所在的城市</option>
                        </select>
                        <select id="s_xian" name="s_xian">
                            <option value="">请选择您所在的县区</option>
                        </select>
                        <script>
                            $(function () {
                                s_s_x_mo("<%=dl_sheng%>", "<%=dl_shi%>", "<%=dl_xian%>");
                            });
                        </script>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">是否大V？</td>
                <td>
                    <asp:RadioButtonList ID="ifdv" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">大V分红</td>
                <td>
                    <asp:TextBox ID="dvfh" runat="server" CssClass="formTitle yan1"></asp:TextBox> %
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"></td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="tj_xg" runat="server" Text="提交修改" CssClass="formInput01" OnClick="tj_xg_Click"></asp:Button>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div class="clear"></div>
    </div>
</asp:Content>

