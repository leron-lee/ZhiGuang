<%@ Page Title="" Language="C#" MasterPageFile="~/cart/Cart.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.cart.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    body { background-image: url(/images/bg.jpg); }
</style>
<script>
    $(window).load(function () {
        $("#dgh").height($("#digf").height());
    });
    function jian(id) {
        var sum = $("#sum_" + id).val();
        if (sum > 1) {
            sum--;
        }
        $("#sum_" + id).val(sum);
        pdku(id);
    }
    function jia(id) {
        var sum = $("#sum_" + id).val();
        

        if(sum <6)
        {
            sum++;
        }
        $("#sum_" + id).val(sum);
        pdku(id);
    }
    function del(id){
        $.post("ajax/del.aspx?id="+id+"&cache=" + Math.random(), function (data) {
            $("#cart_div_"+id).slideUp(500,function(){
                $(this).remove();
                zj();
            });
        });
    }
    function pdku(id) {
        var ku = $("#ku_" + id).val();
        var sum = $("#sum_" + id).val();
        if (parseInt(sum) > parseInt(ku)) {
            sum = ku;
            $("#sum_" + id).val(ku);
        }
        var dj = $("#dj_" + id).val();
        var xjg = dj * sum;
        $("#xj_" + id).attr("xj",xjg);
        $("#xj_sp_" + id).html(xjg);
        zj();

        $.post("ajax/shu.aspx?id="+id+"&shu="+sum+"&cache=" + Math.random(), function (data) {

        });
    }
    var gong = <%=gong %>;
    var dqxj = 0;

    $(function () {
        zj();
        $(function () {
            $("img[id^='img_']").click(function () {
                var vl = $(this).attr("value");
                var id = $(this).attr("_id");
                if (vl == "0") {
                    $(this).attr("value", "1");
                    $(this).attr("src", "/images/gou2.png");
                    $("#xj_" + id).attr("name", "xj");
                    dqxj++;
                } else {
                    $(this).attr("value", "0");
                    $(this).attr("src", "/images/gou1.png");
                    $("#xj_" + id).attr("name", "");
                    dqxj--;
                }
                if (dqxj == gong) {
                    $("#quan_img").attr("value", "1");
                    $("#quan_img").attr("src", "/images/gou2.png");
                } else {
                    $("#quan_img").attr("value", "0");
                    $("#quan_img").attr("src", "/images/gou1.png");
                }
                zj();
            });
            $("#quan_img").click(function () {
                var vl = $(this).attr("value");
                if (vl == "0") {
                    $(this).attr("value", "1");
                    $(this).attr("src", "/images/gou2.png");
                    $("img[id^='img_']").attr("src", "/images/gou2.png");
                    $("img[id^='img_']").attr("value", "1");
                    $("input[id^='xj_']").attr("name", "xj");
                    dqxj = gong;
                } else {
                    $(this).attr("value", "0");
                    $(this).attr("src", "/images/gou1.png");
                    $("img[id^='img_']").attr("src", "/images/gou1.png");
                    $("img[id^='img_']").attr("value", "0");
                    $("input[id^='xj_']").attr("name", "");
                    dqxj = 0;
                }
                zj();
            });
        });
    });
    function zj() {
        var xjz = $("input[name='xj']").length;
        var pric = 0;
        for (var ik = 0; ik < xjz; ik++) {
            pric += parseFloat($("input[name='xj']").eq(ik).attr("xj"));
        }
        $("#zongji").html(pric);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div style="padding:5px;background-color:#fff;">
    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
    <ItemTemplate>
        <div id="cart_div_<%#Eval("id") %>" class="b_l_w">
            <input id="ku_<%#Eval("id") %>" type="hidden" value="<%#get.yk_two_ku(Eval("cc")) %>" />
            <input id="dj_<%#Eval("id") %>" type="hidden" value="<%#get.jg(Eval("mid"),Request) %>" />
            <input id="xj_<%#Eval("id") %>" name="" type="hidden" xj="<%#get.jg(Eval("mid"),Request)*Convert.ToDouble(Eval("shu")) %>" value="<%#Eval("id") %>" />

            <div class="b_l_w" style="padding-bottom:5px;border-bottom:1px solid #ccc;margin-top:5px;">
                <div class="b_l" style="border:1px solid #ccc;width:100px;margin-left:20px;">
                    <div style="position:absolute;margin:12px 0px 0px -15px;">
                        <img id='img_<%#Eval("id") %>' _id="<%#Eval("id") %>" src="/images/gou1.png" value="0" width="25px" />
                    </div>
                    <%--<a href="/pro_l.aspx?id=<%#Eval("mid") %>">--%>
                        <img src="<%#get.m_str(Eval("mid"),"x_img") %>" width="100%" />
                    <%--</a>--%>
                </div>
                <div class="b_l" style="width:155px;margin:-5px 0px 0px 10px;">
                    <div style="font-size:14px;font-weight:bold;">
                        <a href="/pro_l.aspx?id=<%#Eval("mid") %>">
                            <%#get.m_str(Eval("mid"),"name") %>
                        </a>
                    </div>
                    <div  style="display:none;">
                        颜色:<%#get.yk_one_name(Eval("ys")) %> 尺寸:<%#get.yk_two_name(Eval("cc")) %> 库存:<%#get.yk_two_ku(Eval("cc")) %>
                    </div>
                    <div style="color:#E43B3E;font-size:14px;font-weight:bold;">
                        ￥<span id="xj_sp_<%#Eval("id") %>"><%#get.jg(Eval("mid"),Request) %></span>
                    </div>
                    <div>
                        <div class="b_l">数量：</div>
                        <div class="b_l">
                            <table align="center" class="sltable <%#iftj(0) %>" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="td1"><a href='javascript:;' class="jian" onclick="jian(<%#Eval("id") %>)"><img src='/images/jian.jpg' width='100%' /></a></td>
                                    <td class="td2"><input id="sum_<%#Eval("id") %>" name="sum_<%#Eval("id") %>" value="<%#Eval("shu") %>" type="text" class="yan4" onblur="pdku(<%#Eval("id") %>);" /></td>
                                    <td class="td1"><a href='javascript:;' class="jia" onclick="jia(<%#Eval("id") %>)"><img src='/images/jia.jpg' width='100%' /></a></td>
                                </tr>
                            </table>
                            <span class="<%#iftj(1) %>"><%#Eval("shu") %>件</span>
                        </div>
                    </div>
                </div>
                <div class="b_r" style="margin-top:30px;">
                    <a href="javascript:;" style="font-weight:bold;background-color:#E43B3E;color:#fff;display:block;padding:0px 5px 0px 5px;" onclick="del(<%#Eval("id") %>)">X</a>
                </div>
            </div>
        </div>
    </ItemTemplate>
    </asp:Repeater>
    <%=myzd %>
    <div class="clear"></div>
</div>
<div class="b_l_w" style="background-color:#E2E2E2;">
    <div style="padding:5px;">
        <b style="color:#000;font-size:14px;">总计:</b><b style="color:#E43B3E;font-size:18px;">￥<span id="zongji">0</span></b>
        <div class="clear"></div>
    </div>
</div>
<div id="dgh" class="b_l_w"></div>
<div id="digf" style="position:fixed;bottom:50px;left:0px;width:100%;">
    <div class="b_l_w" style="border-top:1px solid #DDDDDD;background-color:#EEEEEE;padding:10px 0px 10px 0px;">
        <div class="doc">
        <div class="b_l" style="margin:5px 0px 0px 5px;">
            <img id="quan_img" src="/images/gou1.png" value="0" width="25px" />
        </div>
        <div class="b_l" style="margin:5px 0px 0px 5px;font-size:14px;">
            全选
        </div>
        <div class="b_r" style="margin-right:5px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-right:5px;">
                            <a href="/pro.aspx" class="bt_cheng" style="border-radius:5px;width:70px;">继续购物</a>
                        </td>
                        <td>
                            <asp:Button ID="js" runat="server" Text="结算" CssClass="bt_hon" style="border-radius:5px;width:70px;" OnClick="js_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </div>
</div>
</asp:Content>
