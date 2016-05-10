<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Web.user.address" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            收货地址
        </div>
        <div class="b_r" style="margin-right:5px;">
            <a href="address_in.aspx" class="a_lv">添加新地址</a>
        </div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w" style="background-color:#fff;">
        </div>
        <div class="b_l_w">
            <div style="padding:5px;">
                <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="b_l_w" style="border-bottom:1px solid #ccc;padding:5px 0px 5px 0px;">
                        <div class="b_l_w">
                            <div class="b_l"><b>姓名：<%#Eval("name") %></b></div>
                            <div class="b_r">
                                <b style="color:red;"><%#mo(Eval("mo")) %></b>
                            </div>
                        </div>
                        手机：<%#Eval("phone") %><br />
                        <%--邮政编码：<%#Eval("code") %><br />--%>
                        收货地址：<%#get.s_sheng(Eval("sheng")) %><%#get.s_shi(Eval("shi")) %><%#get.s_xian(Eval("xian")) %><%#Eval("address") %>
                        <div class="b_l_w">
                            <a href="?mo=<%#Eval("id") %>" class="a_hon">设为默认</a>
                            <a href="address_in.aspx?id=<%#Eval("id") %>" class="a_lan" style="margin-left:5px;">修改</a>
                            <a href="?del=<%#Eval("id") %>" class="a_huang" style="margin-left:5px;">删除</a>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
                <div class="clear"></div>
            </div>
        </div>
    </div>
</asp:Content>
