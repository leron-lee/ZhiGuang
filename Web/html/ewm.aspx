<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="ewm.aspx.cs" Inherits="Web._html.ewm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body { background-image:url(/user/images/indexbg.jpg);background-size:100%; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class='b_l_w'>
        <div style="padding:20px;">
            <div style="padding:20px;background-color:#fff;">
                <div class="b_l_w">
                    <asp:Image ID="img" runat="server" Width="100%"></asp:Image>
                </div>
                <div class="b_l_w" style="background-color:#525151;color:#fff;text-align:center;padding:3px 0px 3px 0px;">
                    快来扫一扫，抢占你的地盘！
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>