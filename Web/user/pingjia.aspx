<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="pingjia.aspx.cs" Inherits="Web.user.pingjia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            商品评价
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div class="clear w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
    <div style="padding:5px;">
        <div class="b_l_w">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="b_l_w" style="margin-top:5px;">
                    <div style="border:1px solid #eee;border-radius:5px 5px 0px 0px;background-color:#F4F4F4;border-bottom:1px solid #C9C9C9;padding:5px;">
                        <div class="b_l">编号：<%#Eval("ordernumber") %></div>
                        <div class="b_r">创建时间：<%#Convert.ToDateTime(Eval("times")).ToShortDateString() %></div>
                        <div style="clear:both;"></div>
                    </div>
                    <div style="background-color:#fff;padding:5px;border-radius:0px 0px 5px 5px;border-bottom:5px solid #E6E6E6;border-left:1px solid #c9c9c9;border-right:1px solid #c9c9c9;">
                        <asp:Repeater ID="Repeater111" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <div style="border:1px solid #EBE9EA;padding:5px;margin-top:-1px;">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width:122px;" valign="top">
                                            <a href="/pro_l.aspx?id=<%#Eval("mid") %>"><img src="<%#Eval("mx_img") %>" width="120px" style="border:1px solid #EBEBEB;" /></a>
                                        </td>
                                        <td valign="top" style="padding-left:10px;">
                                            <div class="b_l_w">
                                                <div class="b_l_w">
                                                    <a href="/pro_l.aspx?id=<%#Eval("mid") %>" style="font-size:14px;font-weight:bold;"><%#Eval("mname") %></a>
                                                </div>
                                                <div class="b_l_w" style="margin-top:5px;">
                                                    <span style="color:#DB090C;font-size:14px;">￥<%#Eval("price") %></span>
                                                    X
                                                    <%#Eval("sum") %><br />
                                                 
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div class="b_l_w" style="margin-top:5px;">
                                    <div class="ipt">
                                        <textarea name="txt_<%#Eval("id") %>" style="height:50px;" placeholder="请输入评价内容"></textarea>
                                    </div>
                                </div>
                                <div style="clear:both;"></div>
                            </div>
                            <div style="clear:both;height:5px;"></div>
                        </ItemTemplate>
                        </asp:Repeater>
                        <div style="clear:both;"></div>
                    </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="b_l_w" style="margin-top:5px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="pj_bt" runat="server" Text="提交评价" OnClick="pj_bt_Click" CssClass="bt_hon"></asp:Button>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear"></div>
    </div>
</div>
</asp:Content>
