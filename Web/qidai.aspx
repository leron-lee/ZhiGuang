<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="qidai.aspx.cs" Inherits="Web.qidai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
    $(function () {
        $(".ding").click(function () {
            var ts = $(this);
            var id = $(this).attr("value");
            $.post("/ajax/ding.aspx?id=" + id + "&cache=" + Math.random(), function (data) {
                if (data == 1) {
                    var dqz = ts.find("span").html();
                    dqz = parseInt(dqz) + 1;
                    ts.find("span").html(dqz);
                }
                else if (data == 2) {
                    alert("重复");
                }
            });
        });
        $(".cai").click(function () {
            var ts = $(this);
            var id = $(this).attr("value");
            $.post("/ajax/cai.aspx?id=" + id + "&cache=" + Math.random(), function (data) {
                if (data == 1) {
                    var dqz = ts.find("span").html();
                    dqz = parseInt(dqz) + 1;
                    ts.find("span").html(dqz);
                }
                else if (data == 2) {
                    alert("重复");
                }
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w w100">
    <%=get.gethtml(5) %>
</div>
<div class="b_l_w">
    <div class="b_l_w">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="100%" EnableViewState="false">
        <ItemTemplate>
            <div style="border:1px solid #ccc;padding:5px;border-radius:5px;">
                <div class="w100">
                    <div class="b_l_w">
                        <img src="<%#Eval("x_img") %>" height="140px" width="100%" class="now" />
                    </div>
                    <div class="b_l_w" style="margin-top:5px;text-align:center;line-height:16px;height:16px;overflow:hidden;">
                        <%#Eval("name") %>
                    </div>
                    <div class="b_l_w" style="margin-top:5px;">
                        <div class="b_l">
                            <a href="javascript::" class="ding" value="<%#Eval("id") %>"><img src="/images/ding.png" class="now" />&nbsp;<span><%#Eval("s6") %></span></a>
                        </div>
                        <div class="b_r">
                            <a href="javascript::" class="cai" value="<%#Eval("id") %>"><img src="/images/cai.png" class="now" />&nbsp;<span><%#Eval("s7") %></span></a>
                        </div>
                    </div>
                </div>
                <div style="clear:both;"></div>
            </div>
        </ItemTemplate>
        <ItemStyle Width="50%" />
        </asp:DataList>
    </div>
    <div class="b_r" style="margin-right:5px;">
        <%=fystr %>
    </div>
</div>
</asp:Content>

