<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="add_cjh.aspx.cs" Inherits="Web.admin.cjh.add_cjh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">




    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <ul class="navLocation">
        <li><strong>茶佳会信息添加</strong></li>
    </ul>
    <div class="infoBox">
        <table cellpadding="10" class="table898" cellspacing="10">
            <tr>
                <td style="text-align: right;">登陆账号：</td>
                <td>
                    <asp:TextBox ID="TextBox1" Width="300px" runat="server" CssClass="formTitle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">登陆密码：</td>
                <td>
                    <asp:TextBox ID="TextBox2" Width="300px" runat="server" CssClass="formTitle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">所在区域：</td>
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
                <td style="text-align: right;">姓名：</td>
                <td>
                    <asp:TextBox ID="TextBox3" Width="200px" runat="server" CssClass="formTitle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">微信：</td>
                <td>
                    <asp:TextBox ID="TextBox4" Width="200px" runat="server" CssClass="formTitle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">电话：</td>
                <td>
                    <asp:TextBox ID="TextBox5" Width="200px" runat="server" CssClass="formTitle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">地址：</td>
                <td>
                    <asp:TextBox ID="TextBox6" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;"></td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="tj_xg" runat="server" Text="保存" CssClass="formInput01" OnClick="tj_xg_Click" ></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div class="clear"></div>
    </div>


</asp:Content>
