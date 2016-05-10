<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="shoporder_l.aspx.cs" Inherits="Web.user.shoporder_l" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
            订单中心
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div class="clear w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w" style="background-color:#F9F9F9;">
    <div style="padding:5px;">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
        <b style="color:#AE1B2D;">收件信息：</b><br />
        收件人：<%#Eval("name") %><br />
        联系电话：<%#Eval("tel") %><br />
        邮政编码：<%#Eval("code") %><br />
        收货地址：<%#Eval("address") %><br />
        下单时间：<%#Eval("times") %><br />
        <b style="color:#AE1B2D;">发货信息：</b><br />
        快递名称：<%#Eval("fname") %><br />
        快递单号：<%#Eval("fdan") %>
        <a class="<%#get.ztdis(Eval("zt")) %>" href="http://m.kuaidi100.com/result.jsp?com=shentong&nu=<%#Eval("fdan") %>" style="color:blue;">查看物流</a>
        <br />
        发货时间：<%#Eval("ftimes") %><br />
            
        </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
<div style="padding:5px;">
    <div class="b_l_w">
        <span style="font-size:14px;">商品详情：</span>
    </div>
    <div class="b_l_w" style="background-image:url(/user/images/user6.jpg);margin-top:5px;">
        <asp:Repeater ID="Repeater2" runat="server" EnableViewState="false">
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
                                <div class="b_l_w " style="margin-top:5px;">
                                    <span style="color:#DB090C;font-size:14px;">￥<%#Eval("price") %></span>
                                    X
                                    <%#Eval("sum") %><br />
                                    货号：<%#get.m_str(Eval("mid"),"s10") %><br />
                                   
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="clear:both;"></div>
            </div>
        </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="b_l_w dis" style="margin-top:10px;">
        <div class='b_l_w dis'>
            使用红包：<b style="color:#DB090C;"><%=hb %></b>元<br />
            使用消费劵：<b style="color:#DB090C;"><%=xfj %></b>元<br />
            使用余额：<b style="color:#DB090C;"><%=ye %></b>元<br />
        </div>
        <div class="b_l_w">
            <div class="b_l" style="margin-top:5px;">
                交易状态：<%=zt %>
            </div>
            <div class="b_r">
                订单金额：<span style="color:#DB090C;font-size:22px;">￥<%=zong %></span>(含运费)
            </div>
        </div>
    </div>
    <div class="clear"></div>
</div>
</div>

</asp:Content>
