<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_master.Master" CodeBehind="InfoFX.aspx.cs" Inherits="Web.fx.InfoFX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function closeimg(imgstr, testr) {
            $("#" + imgstr).attr("src", "/images/bmjj-1.jpg");
            $("#" + testr).attr("value", "");
        }
        $("#ctl00_body_TextLogo").bind('input propertychange', function() {
            $("#ctl00_body_ImgLogo")[0].src = $("#ctl00_body_TextLogo").val();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <ul class="navLocation">
        <li><strong>基本信息设置</strong></li>
    </ul>

    <div class="infoBox">

        <table width="100%" class="table898">
            <tr>
                <td style="text-align: right;">门店名称：
                </td>
                <td>
                    <asp:TextBox ID="TextName" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">门店LOGO：
                </td>
                <td>
                    <div class="b_l">
                        <asp:Image ID="ImgLogo" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                        <asp:TextBox ID="TextLogo" runat="server" CssClass="formTitle" ></asp:TextBox>                    
                        <%=get.upload(TextLogo.ClientID) %>
                    </div>
                    <div class="b_l" style="margin: 7px 0px 0px 5px;">
                    </div>
                </td>
            </tr>

            <style>
                #idsdg td {
                    border: 0px;
                    padding: 5px 0px 0px 0px;
                }

                    #idsdg td img {
                        padding-bottom: 5px;
                    }

                #idsdg2 td {
                    border: 0px;
                    padding: 5px 0px 0px 0px;
                }

                    #idsdg2 td img {
                        padding-bottom: 5px;
                    }
            </style>
            <tr>
                <td>&nbsp;
                </td>
                <td>
                    <asp:Button ID="BtnSave" runat="server" Text=" 保存 " CssClass="formInput01" UseSubmitBehavior="False" OnClick="BtnSave_Click" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>

