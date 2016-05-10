<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="dzmd.aspx.cs" Inherits="Web.admin.fh.dzmd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .table123 { border-collapse:collapse;}
    .table123 .one { color:#404040;background-color:#F3F3F3;}
    .table123 td{ border:1px solid #E4E4E4;padding:10px;text-align:left;line-height:23px;}
</style>
<script>
    function cball(cb) {
        var ck = document.getElementsByTagName("input");
        for (var i = 0; i < ck.length; i++) {
            if (ck[i].type == "checkbox") {
                ck[i].checked = cb.checked;
            }
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>汇通电子面单发货</strong></li></ul>
    <div class="b_l_w">
        <div style="padding:10px;">
            <div class="b_l_w">
                <b>汇通接口</b>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;商家ID：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="parternID" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;商家验证码：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="partnerKey" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="htjk_bt" runat="server" Text="提交修改" CssClass="formInput01" UseSubmitBehavior="false" OnClick="htjk_bt_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <b>寄件人信息</b>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;寄件人姓名：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendMan" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;寄件人电话：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendManPhone" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;　　寄件省：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendProvince" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;　　寄件市：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendCity" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;　寄件区县：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendCounty" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;寄件人地址：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendManAddress" runat="server" CssClass="formTitle" Width="345px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;　寄件邮编：
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="sendPostcode" runat="server" CssClass="formTitle"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;　　　　　
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="fhdz_bt" runat="server" Text="提交修改" CssClass="formInput01" UseSubmitBehavior="false" OnClick="fhdz_bt_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top:10px;">
                <div class="b_l">
                    <b>待发货列表</b>
                </div>
                <div class="b_r" style="margin-right:11px;">
                    全选<input onclick="cball(this)" type="checkbox" />
                </div>
                <div class="b_r" style="margin-right:11px;">
                    <asp:Button ID="xzfh_bt" runat="server" Text="打勾订单发货" UseSubmitBehavior="false" CssClass="formInput01" OnClick="xzfh_bt_Click"></asp:Button>
                </div>
                <div class="b_r" style="margin-right:11px;">
                    <asp:DropDownList ID="htkd_lishi" runat="server" onchange="if(this.selectedIndex!=0){window.open(this.options[this.selectedIndex].value);}this.selectedIndex=0;">
                    <asp:ListItem Value="">历史打印订单</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <table class="table123" width="100%" cellpadding="0" cellspacing="0">
                    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>

                    <tr>
                        <td class="one" colspan="4">
                            <div class="b_l">
                                订单编号：<%#Eval("ordernumber") %>
                                &nbsp;
                                下单时间：<%#Eval("times") %>
                            </div>
                            <div class="b_r">
                                <input name="Item" type="checkbox" value='<%#Eval("id")%>' />
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
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>

