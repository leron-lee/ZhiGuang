<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="up_center.aspx.cs" Inherits="Web.user.up_center" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/ajax/s_s_x.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            个人信息
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div class="clear w100"><img src="/images/cart5.jpg" /></div>
<div style="padding:5px;position:relative;z-index:2;background-color:#fff;">
    <div class="b_l_w">
        <div class="ipt">
            <%=username %>
        </div>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem>男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="name" runat="server" placeholder="请输入您的姓名"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="phone" runat="server" placeholder="请输入您的联系电话"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w dis" style="margin-top:5px;">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:33%;">
                    <select id="s_sheng" name="s_sheng" class="select" <%=disabled %>>
                        <option value="">请选择省份</option>
                    </select>
                </td>
                <td style="width:33%;padding-left:2px;">
                    <select id="s_shi" name="s_shi" class="select" <%=disabled %>>
                        <option value="">请选择城市</option>
                    </select>
                </td>
                <td style="width:33%;padding-left:2px;">
                    <select id="s_xian" name="s_xian" class="select" <%=disabled %>>
                        <option value="">请选择县区</option>
                    </select>
                </td>
            </tr>
        </table>
    </div>
    <script>
        $(function () {
            s_s_x_mo("<%=s_sheng%>", "<%=s_shi%>", "<%=s_xian%>");
        });
    </script>
    <div class="b_l_w" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="address" runat="server" placeholder="请输入您的地址"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w <%=dp %> dis" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="gsname" runat="server" placeholder="推荐输入“英妃.ivfiv1558”品牌总代理"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w <%=dp %>" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="sy_key" runat="server" placeholder="推荐输入真实姓名或微信名"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w <%=dp %>" style="margin-top:5px;">
        <div class="ipt">
            <asp:TextBox ID="sy_contus" runat="server" placeholder="请输入分享内容"></asp:TextBox>
        </div>
    </div>
    <div class="b_l_w" style="margin-top:10px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="bt" runat="server" Text="保存修改" CssClass="bt_hon" OnClick="bt_Click"></asp:Button>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="b_l_w" style="margin-top:5px;">
        <a href="up_pwd.aspx" class="bt_lan">修改密码</a>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>

