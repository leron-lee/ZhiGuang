<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="shoporder.aspx.cs" Inherits="Web.user.shoporder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w w100" style="border-bottom:1px solid #000;">
    <a href="shoporder.aspx"><img src="images/index11.png" /></a>
</div>
<div class="b_l_w">
    <div class="b_l_w" style="padding:10px 0px 0px 0px;">
        <table width="100%" cellpadding="0" cellspacing="0">
     <tr>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z1dis %>"><%=z1 %></div>
                        <a href="shoporder.aspx?zt=1">
                            <img src="images/menu1.png" height="36px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z2dis %>"><%=z2 %></div>
                        <a href="shoporder.aspx?zt=2">
                            <img src="images/menu2.png" height="36px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z3dis %>"><%=z3 %></div>
                        <a href="shoporder.aspx?zt=3">
                            <img src="images/menu3.png" height="36px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z4dis %>"><%=z4 %></div>
                        <a href="shoporder.aspx?zt=4&pj=1">
                            <img src="images/menu4.png" height="36px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <a href="/html.aspx?id=24">
                            <img src="images/menu5.png" height="36px" />
                        </a>
                    </td>
                </tr>
        </table>
    </div>
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
                                                <div class="b_l_w dis" style="margin-top:5px;">
                                                    <span style="color:#DB090C;font-size:14px;">￥<%#Eval("price") %></span>
                                                    X
                                                    <%#Eval("sum") %><br />
                                                   
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div style="clear:both;"></div>
                            </div>
                            <div style="clear:both;height:5px;"></div>
                        </ItemTemplate>
                        </asp:Repeater>
                        <div class="b_l_w" style="margin-top:5px;">
                            <div class="b_l">
                                <%#get.zt(Eval("zt")) %>
                            </div>
                            <div class="b_r">
                                <a href="shoporder_l.aspx?id=<%#Eval("id") %>" class="a_lan">查看订单</a>
                            </div>
                            <div class="b_r <%#pjdis() %>" style="margin-right:5px;">
                                <a href="pingjia.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>" class="a_zi">评价商品</a>
                            </div>
                            <div class="b_r" style="margin-right:5px;">
                                <%#ztimg(Eval("zt"),Eval("ordernumber"),Eval("id")) %>
                            </div>
                            <div class="b_r <%#get.ztdis(Eval("zt")) %>" style="margin-right:5px;">
                                <a class="a_huang" href="http://m.kuaidi100.com/result.jsp?com=shentong&nu=<%#Eval("fdan") %>">查看物流</a>
                            </div>
                            <div class="b_r <%#delztdis() %>" style="margin-right:5px;">
                                <a href="javascript:;" onclick="if(confirm('确定删除？')){location.href='?del=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>';}" class="a_zi">删除订单</a>
                            </div>
                        </div>
                        <div style="clear:both;"></div>
                    </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>
    </div>
    <%=stv %>
</div>
</div>
</div>
    <div class="b_l_w" style="margin-top:10px;padding-bottom:10px;">
        <center>
            <%=fystr %>
        </center>
    </div>
</asp:Content>
