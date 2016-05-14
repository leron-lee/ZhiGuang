<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="Web.fx.Apply" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <!---->
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>申请门店入驻</title>
    <link rel="stylesheet" href="/css/body.css" />
    <script src="/ajax/s_s_x.js"></script>
    <style>
        .ipt input, .ipt textarea {
            height:initial;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="b_l_w" style="background-color: #F9F9F9; padding: 10px 0px 10px 0px;">
            <div class="b_l_w">
                <div class="b_l" style="color: #FE4600; font-size: 14px; margin-left: 5px; font-weight: bold;">
                    提交个人信息申请入驻
                </div>
                <div class="b_r" style="margin-right: 5px;">
                </div>
            </div>
        </div>
        <div class="clear w100">
            <img src="/images/cart5.jpg" />
        </div>
        <div style="padding: 5px; position: relative; z-index: 2; background-color: #fff;">
            <div class="b_l_w">
                <div class="ipt">
                    <%=username %>
                </div>
            </div>
            <div class="b_l_w" style="margin-top: 5px;">
                <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>女</asp:ListItem>
                    <asp:ListItem selected="true">男</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="b_l_w <%=dp %>" style="margin-top: 5px;">
                <div class="ipt">
                    <asp:TextBox ID="Age" runat="server" placeholder="请输入您的年龄"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top: 5px;">
                <div class="ipt">
                    <asp:TextBox ID="TrueName" runat="server" placeholder="请输入您的真实姓名"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top: 5px;">
                <div class="ipt">
                    <asp:TextBox ID="phone" runat="server" placeholder="请输入您的联系电话"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 33%;">
                            <select id="s_sheng" name="s_sheng" class="select" >
                                <option value="">请选择省份</option>
                            </select>
                        </td>
                        <td style="width: 33%; padding-left: 2px;">
                            <select id="s_shi" name="s_shi" class="select" >
                                <option value="">请选择城市</option>
                            </select>
                        </td>
                        <td style="width: 33%; padding-left: 2px;">
                            <select id="s_xian" name="s_xian" class="select" >
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
            <div class="b_l_w" style="margin-top: 5px;">
                <div class="ipt">
                    <asp:TextBox ID="address" runat="server" placeholder="请输入您的地址"></asp:TextBox>
                </div>
            </div>           
            <div class="b_l_w " style="margin-top: 5px;">
                <div class="ipt">
                    <asp:TextBox ID="IDCard" runat="server" placeholder="请输入身份证号码"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w  " style="margin-top: 5px;">
                <div class="ipt">
                    <asp:TextBox ID="InvitationCode" runat="server" placeholder="输入推荐码"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top: 10px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="bt" runat="server" Text="保存修改" CssClass="bt_hon" OnClick="bt_Click"></asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="clear"></div>
        </div>
    </form>
</body>
</html>
