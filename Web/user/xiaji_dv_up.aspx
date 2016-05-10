<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="xiaji_dv_up.aspx.cs" Inherits="Web.user.xiaji_dv_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                设置大V
            </div>
        </div>
    </div>
    <div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w">
        <div style="padding:5px;position:relative;z-index:2;background-color:#fff;">
            <div class="b_l_w">
                用户名：<%=_username %>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                是否大V
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <asp:DropDownList ID="ifdv" runat="server" CssClass="select">
                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <div class="b_l">
                    设置佣金率(%)
                </div>
                <div class="b_r">
                    最高不能超过<b style="color:red;"><%=bl %></b>%
                </div>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <div class="ipt">
                    <asp:TextBox ID="dvfh" runat="server" placeholder="请输入佣金率(%)" CssClass="yan1"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <asp:Button ID="tj_bt" runat="server" Text="提交设置" CssClass="bt_hon" OnClick="tj_bt_Click"></asp:Button>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>

