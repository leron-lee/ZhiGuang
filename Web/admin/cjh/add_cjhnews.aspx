<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="add_cjhnews.aspx.cs" Inherits="Web.admin.cjh.add_cjhnews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        window.onload = function () {
            var oFCKeditor = new FCKeditor('<%= TextBox3.ClientID %>');
            oFCKeditor.BasePath = '/L_editor/'
            oFCKeditor.Height = 450;
            oFCKeditor.ReplaceTextarea();


            var oFCKeditor2 = new FCKeditor('<%= TextBox2.ClientID %>');
            oFCKeditor2.BasePath = '/L_editor/'
            oFCKeditor2.Height = 260;
            oFCKeditor2.ReplaceTextarea();
        }


       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="infoBox">



        <table width="100%" class="table898">
            <tr>
                <td style="text-align: right;">信息标题:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" MaxLength="100" Width="500" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>



              <tr>
                <td style="text-align:right;">
                    图片：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="img" Width="200" runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(img.ClientID) %>
                    </div>
                    <div class="b_l" style="margin:7px 0px 0px 5px;">
                        支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">信息类型:
                </td>
                <td>

                    <asp:DropDownList ID="DropDownList1" runat="server" Width="170">
                        <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                        <asp:ListItem Text="——活动——" Value="1"></asp:ListItem>
                        <asp:ListItem Text="——资讯——" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

             <tr>
                <td style="text-align: right;">发布地区:
                </td>
                <td>

                    <asp:DropDownList ID="DropDownList2" runat="server" Width="170">
                        <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                      
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="text-align: right;">封面简介:
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" Width="100%" Height="80px" runat="server" CssClass="formTitle" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">内容:
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" Width="100%" Height="280px" runat="server" CssClass="formTitle" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="float: left; width: 100%; text-align: center; display: inline; margin-top: 5px;">

            <asp:Button ID="Button1" runat="server" Text=" 保 存 " CssClass="formInput01"  OnClick="Button1_Click" />

        </div>

    </div>


</asp:Content>
