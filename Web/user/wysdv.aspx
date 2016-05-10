<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="wysdv.aspx.cs" Inherits="Web.user.wysdv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function yz() {
            var name = $("#<%=name.ClientID%>").val();
            var phone = $("#<%=phone.ClientID%>").val();
            if (name == "") {
                alert("请输入姓名");
                return false;
            } else if (phone == "") {
                alert("请输入联系方式");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                申请合伙人
            </div>
            <div class="b_r" style="margin-right:5px;">
            
            </div>
        </div>
    </div>
    <div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w">
        <div style="padding:5px;position:relative;z-index:2;background-color:#fff;">
            <div class="b_l_w">
                <div class="ipt">
                    <asp:TextBox ID="name" runat="server" placeholder="请输入姓名"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <div class="ipt">
                    <asp:TextBox ID="phone" runat="server" placeholder="请输入联系方式"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <asp:Button ID="tj_bt" runat="server" Text="提交申请" OnClick="tj_bt_Click" OnClientClick="return yz();" CssClass="bt_hon"></asp:Button>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
