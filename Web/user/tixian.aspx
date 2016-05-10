<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="tixian.aspx.cs" Inherits="Web.user.tixian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function xy() {

            if ($("input[type='checkbox']").is(':checked') == false) {
                alert("请确认已阅读和同意礼尚挚广提现协议 ！");
                return false;
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color: #F9F9F9; padding: 10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color: #FE4600; font-size: 14px; margin-left: 5px;">
                提现到微信钱包
            </div>
            <div class="b_r" style="margin-right: 5px;">
                <a href="tixian_pwd.aspx" class="a_lv">修改提现密码</a>
            </div>
        </div>
    </div>
    <div class="b_l_w w100">
        <img src="/images/cart5.jpg" />
    </div>
    <div class="b_l_w">
        <div style="padding: 5px; z-index: 2; position: relative;">
            <div class="b_l_w" style="padding: 10px 0px 10px 0px; border-bottom: 1px solid #ccc;">
                <div style="font-size: 12px;">余额：<span style="color: #DC181A; font-size: 20px;"><%=JF %>元</span> (每次提现金额必须整数)</div>
                <input type="hidden" name="JF" value="<%=JF %>" />
            </div>
            <div class="b_l_w" style="padding: 10px 0px 10px 0px;">
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">
                        <div class="ipt">
                            <asp:TextBox ID="JE" runat="server" CssClass="yan1" placeholder="请输入提现金额"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">


                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0" Text="支付宝"></asp:ListItem>
                            <asp:ListItem Value="1" Text="微信钱包"></asp:ListItem>
                        </asp:RadioButtonList>


                    </div>
                </div>
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">
                        <div class="ipt">
                            <asp:TextBox ID="zhifubao" runat="server" placeholder="请输入提款账号"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">
                        <div class="ipt">
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="姓名"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">
                        <div class="ipt">
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="电话号码"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">
                        <div class="ipt">
                            <asp:TextBox ID="pay_pwd" runat="server" placeholder="请输入支付密码" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="border-radius: 5px; border: 1px solid #EEEEEE; background-color: #F9F9F9; margin-top: 5px; padding: 5px;">
                        <div class="ipt1">
                            <asp:CheckBox ID="CheckBox2" runat="server" />已阅读和同意礼尚挚广<a href="/html.aspx?id=33" target="_blank" style="color: red;">提现协议</a>
                        </div>
                    </div>
                </div>
                <div class="b_l_w" style="margin-top: 10px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Button1" runat="server" Text="提交申请" CssClass="bt_hon" OnClick="Button1_Click" OnClientClick="return xy();"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
