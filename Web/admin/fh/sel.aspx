<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sel.aspx.cs" Inherits="Web.admin.fh.sel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table123 { border-collapse:collapse;}
    .table123 .one { color:#404040;background-color:#F3F3F3;}
    .table123 td{ border:1px solid #E4E4E4;padding:10px;text-align:left;line-height:23px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>待发货订单列表</strong></li></ul>
    <div class="b_l_w" style="padding:10px 0px 10px 0px;">
        <div class='b_l' style="margin-left:5px;">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="sx_bt">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            省份：
                        </td>
                        <td>
                            <asp:DropDownList ID="sheng" runat="server">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left:5px;">
                            订单编号：
                        </td>
                        <td>
                            <asp:TextBox ID="ordernumber" runat="server"></asp:TextBox>
                        </td>
                        <td style="padding-left:5px;">
                            <asp:Button ID="sx_bt" runat="server" Text="筛选" UseSubmitBehavior="false" OnClick="sx_bt_Click" CssClass="formInput01"></asp:Button>
                        </td>
                        <td style="padding-left:5px;">
                            当前待发货的订单总数：<b style="color:red;"><%=zong %></b>单
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
    <div class="b_l_w" style="padding-bottom:10px;">
        <div class='b_l' style="margin-left:5px;">
            <asp:Panel ID="Panel2" runat="server" DefaultButton="fh_bt">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        选择快递：
                    </td>
                    <td>
                        <asp:DropDownList ID="fname_id" runat="server">
                        <asp:ListItem Value="">请选择快递</asp:ListItem>
                       
                        <asp:ListItem Value="shentong">申通</asp:ListItem>
                      
                        </asp:DropDownList>
                    </td>
                    <td style="padding-left:5px;">
                        起始单号：
                    </td>
                    <td>
                        <asp:TextBox ID="danhao" runat="server" CssClass="yan1"></asp:TextBox>
                    </td>
                    <td style="padding-left:5px;">
                        发货前：
                    </td>
                    <td>
                        <asp:TextBox ID="fq" runat="server" CssClass="yan1" Width="50px"></asp:TextBox>
                        单
                    </td>
                    <td>
                        <script>
                            function fh() {
                                var fname_id = $("#<%=fname_id.ClientID%>").val();
                                var danhao = $("#<%=danhao.ClientID%>");
                                var fq = $("#<%=fq.ClientID%>");

                                var zong = parseInt(fq.val());

                                if (fname_id == "") {
                                    alert("请选择快递");
                                    return false;
                                }
                                else if (danhao.val() == "") {
                                    alert('请输入起始单号');
                                    return false;
                                }
                                var xdanhao = parseInt(danhao.val());
                                if (!confirm("一共" + zong + "笔订单:起始单号从" + xdanhao + "到" + (xdanhao + zong - 1) + "，确认发货？")) {
                                    return false;
                                }
                            }
                        </script>
                        <asp:Button ID="fh_bt" runat="server" Text="发货这些订单" OnClick="fh_bt_Click" OnClientClick="return fh();" CssClass="formInput01"></asp:Button>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </div>
    </div>
    <div class="b_l_w">
        <table class="table123" width="100%" cellpadding="0" cellspacing="0">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>

            <tr>
                <td class="one" colspan="4">
                    订单编号：<%#Eval("ordernumber") %>
                    &nbsp;
                    下单时间：<%#Eval("times") %>
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
                    订单金额<br /><b style="font-size:16px;color:red;"><%#Eval("price") %>元</b>
                </td>
                <td style="vertical-align:top;">
                    收货人：<%#Eval("name") %><br />
                    联系电话：<%#Eval("tel") %><br />
                    邮政编码：<%#Eval("code") %><br />
                    收货地址：<%#Eval("address") %><br />
                </td>
            </tr>

            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="b_l_w" style="height: 15px; overflow: hidden;"></div>
    <div class="b_l_w" style="text-align: center; line-height: 23px;padding-bottom:10px;">
        <div class="b_r" style="margin-right:10px;">
            <%=fystr%>
        </div>
    </div>
</asp:Content>
