<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="wyzdl.aspx.cs" Inherits="Web.user.wyzdl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function yz() {
            var name = $("#<%=name.ClientID%>").val();
            var phone = $("#<%=phone.ClientID%>").val();
            var jianjian = $("#<%=jianjian.ClientID%>").val();
            var s_xian = $("#s_xian").val();
            if (name == "") {
                alert("请输入姓名");
                return false;
            } else if (phone == "") {
                alert("请输入联系方式");
                return false;
            } else if (jianjian == "") {
                alert("请输入简介");
                return false;
            } else if (s_xian == "") {
                alert("请选择你要代理的县区");
                return false;
            } else {
                var ifcz = "0";
                $.post("/ajax/dl_xian.aspx?cache=" + Math.random() + "&id=" + s_xian, function (data) {
                    if (data == "1") {
                        alert("该县区已经存在代理，请更换");
                        ifcz = "1";
                    }
                });
                if (ifcz == "1") {
                    return false;
                }
            }
        }
    </script>
    <script src="/ajax/s_s_x.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                我要做代理
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
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:33%;">
                            <select id="s_sheng" name="s_sheng" class="select">
                                <option value="">请选择省份</option>
                            </select>
                        </td>
                        <td style="width:33%;padding-left:2px;">
                            <select id="s_shi" name="s_shi" class="select">
                                <option value="">请选择城市</option>
                            </select>
                        </td>
                        <td style="width:33%;padding-left:2px;">
                            <select id="s_xian" name="s_xian" class="select">
                                <option value="">请选择县区</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <div class="ipt">
                    <asp:TextBox ID="jianjian" runat="server" placeholder="请输入简介" TextMode="MultiLine" Height="60px"></asp:TextBox>
                </div>
            </div>
            <div class="b_l_w" style="margin-top:5px;">
                <asp:Button ID="tj_bt" runat="server" Text="提交申请" OnClick="tj_bt_Click" OnClientClick="return yz();" CssClass="bt_hon"></asp:Button>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>

