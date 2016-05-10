<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="huifu_in.aspx.cs" Inherits="Web.admin.wx.huifu_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ul class="navLocation">
    <li><strong>被动自动回复设置 - <%=tit %></strong></li>
</ul>
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
    <div class="infoBox">
        <table width="100%" class="table898" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align:right;">
                    标题：
                </td>
                <td>
                    <asp:TextBox ID="name" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    图片：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="img"  runat="server" CssClass="formTitle"></asp:TextBox>
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
                <td style="text-align:right;">
                    内容：
                </td>
                <td>
                    <asp:TextBox ID="nt" Width="500px" TextMode="MultiLine" Height="100px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    链接：
                </td>
                <td>
                    <asp:TextBox ID="href" Width="500px" runat="server" CssClass="formTitle" Text="http://"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    关键词：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="gjc"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:7px 0px 0px 5px;">
                        多个关键词请用","隔开。如果想关注时自动回复请输入（关注回复）
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:left;">
                    <asp:Button ID="Button1" runat="server" Text="" CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click"  />
                </td>
            </tr>
            <tr>
                <td></td>
                <td><b>注：</b>多条图文消息信息，默认第一个为大图,注意，如果图文数超过10，则将会无响应</td>
            </tr>
        </table>
    </div>
</asp:Panel>
</asp:Content>
