<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="wx_login.aspx.cs" Inherits="Web.user.wx_login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .abt_huang { display: block; width: 100%; padding: 20px 0px 20px 0px;line-height:16px; border: 0px; background-color: #FF4800; color: #fff;border-bottom:2px solid #B21900; font-size: 14px; font-weight: bold; border-radius: 5px;text-align:center; }
        .abt_lv { display: block; width: 100%; padding: 20px 0px 20px 0px;line-height:16px; border: 0px; background-color: #134720; color: #fff;border-bottom:2px solid #513013; font-size: 14px; font-weight: bold; border-radius: 5px;text-align:center; }
    </style>
    <script>
        $(function () {
            $("#<%=bt2.ClientID%>").click();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <input type="hidden" name="openid" value="<%=openid %>" />
    <input type="hidden" name="sex" value="<%=sex %>" />
    <input type="hidden" name="img" value="<%=img %>" />
    <input type="hidden" name="name" value="<%=name %>" />
    <input type="hidden" name="province" value="<%=province %>" />
    <input type="hidden" name="city" value="<%=city %>" />
    <div style="padding:10px;">
        <div class="b_l_w" style="margin-top:50px;">
            <asp:Button ID="bt1" runat="server" Text="已有账号，绑定原账号" CssClass="abt_huang" OnClick="bt1_Click"></asp:Button>
        </div>
        <div class="b_l_w" style="margin-top:10px;">
            <asp:Button ID="bt2" runat="server" Text="还没账号，设置新账号" CssClass="abt_lv" OnClick="bt2_Click"></asp:Button>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>