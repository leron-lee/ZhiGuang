<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="shoporder.aspx.cs" Inherits="Web.admin.shoporder.shoporder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table123 { border-collapse:collapse;}
    .table123 .one { color:#404040;background-color:#F3F3F3;}
    .table123 td{ border:1px solid #E4E4E4;padding:10px;text-align:left;line-height:23px;}
</style>
<script>
    function pricefc(id) {
        var price = $("#ipt_price_" + id).val();
        price = escape(price);
        var url = "<%=Server.UrlDecode(Request.RawUrl) %>";
        location.href = "shoporder.aspx?id=" + id + "&price=" + price + "&url=" + url;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>订单列表</strong></li></ul>

<div class="b_l_w" style="padding:5px 0px 5px 0px;">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td>&nbsp;&nbsp;用户名：</td>
            <td>&nbsp;<asp:TextBox ID="_username" runat="server" Width="100px"></asp:TextBox></td>
            <td>&nbsp;&nbsp;订单号：</td>
            <td>&nbsp;<asp:TextBox ID="ordernumber" runat="server" Width="100px"></asp:TextBox></td>
            <td>&nbsp;&nbsp;收货人：</td>
            <td>&nbsp;<asp:TextBox ID="name" runat="server" Width="100px"></asp:TextBox></td>
            <td>&nbsp;&nbsp;快递单号：</td>
            <td>&nbsp;<asp:TextBox ID="fdan" runat="server" Width="100px"></asp:TextBox></td>
            <td>&nbsp;&nbsp;状态：</td>
            <td>
                <asp:RadioButtonList ID="zt" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="1">未付款</asp:ListItem>
                <asp:ListItem Value="2">已付款</asp:ListItem>
                <asp:ListItem Value="3">已发货</asp:ListItem>
                <asp:ListItem Value="4">交易完成</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" UseSubmitBehavior="false" onclick="Button1_Click"></asp:Button></td>
        </tr>
    </table>
    </asp:Panel>
</div>

<div class="r4">
    <div class="b_l_w">
        <div class="jl">
            
            <div class="b_l_w">
                <table class="table123" width="100%" cellpadding="0" cellspacing="0">
                    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>

                    <tr>
                        <td class="one" colspan="5">
                            <div class="b_l">
                                订单编号：<%#Eval("ordernumber") %>
                                &nbsp;
                                下单时间：<%#Eval("times") %>
                            </div>
                            <div class="b_r">
                                用户名：<%#Eval("username") %>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:496px;padding:0px;border-right:0px;">
        
                            <asp:Repeater ID="Repeater111" runat="server" EnableTheming="false">
                            <ItemTemplate>

                            <div class="b_l_w" style="<%#get.gang(Container.ItemIndex,"border-top:1px solid #E4E4E4;")%>">
                                <div class="b_l" style="width:50px;padding:5px;">
                                    <a href="/pro_l.aspx?id=<%#Eval("mid") %>" target="_blank"><img src="<%#Eval("mx_img") %>" width="50px" height="50px" style="border:1px solid #E9E9E9;" /></a>
                                </div>
                                <div class="b_l" style="padding:5px;width:200px;">
                                    <a href="/pro_l.aspx?id=<%#Eval("mid") %>" target="_blank" style="line-height:14px;"><%#Eval("mname") %></a>
                                    <br />
                                    颜色：<%#Eval("ys") %><br />
                                    尺寸：<%#Eval("cc") %><br />
                                </div>
                                <div class="b_l" style="width:70px;padding:5px;text-align:center;">
                                    
                                    <%#Convert.ToDouble(Eval("price")) %>元

                                </div>
                                <div class="b_l" style="width:30px;padding:5px;text-align:center;">
                                    X
                                </div>
                                <div class="b_l" style="width:30px;padding:5px;text-align:center;">
                                    <%#Eval("sum") %>
                                </div>
                            </div>

                            </ItemTemplate>
                            </asp:Repeater>

                        </td>
                        <td style="text-align:center;vertical-align:top;">
                            <b style="font-size:16px;color:red;"><%#Eval("price") %>元</b>
                            <%--<a href="javascript:;" onclick="pricefc(<%#Eval("id") %>);">修改</a>--%>
                            <br />
                            <a href="shoporder_l.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>">订单详情</a>
                        </td>
                        <td style="text-align:center;vertical-align:top;">
                            <%#get.zt(Eval("zt")) %><br />
                            <%#ckwl() %>
                        </td>
                        <td style="text-align:center;vertical-align:top;">
                            <a href="javascript:;" onclick="if(confirm('确定删除？')){location.href='shoporder.aspx?del=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>';}">删除</a>
                        </td>
                    </tr>

                    </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>

            <div class="b_l_w" style="height: 15px; overflow: hidden;"></div>
            <div class="b_l_w" style="text-align: center; line-height: 23px;">
                <div class="b_r">
                    <%=Fystr%>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>

