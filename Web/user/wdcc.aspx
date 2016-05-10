<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="wdcc.aspx.cs" Inherits="Web.user.wdcc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .a_kk { float: left; padding: 2px 5px 2px 5px; color: #fff; background-color: #5A4541; border-radius: 5px; margin-right: 5px; }
        .clan { color: blue; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div class="b_l_w" style="background-image:url(images/indexbg.jpg);background-size:100%;margin-top:10px;">
    <div class="b_l_w" style="border-bottom:1px solid #7F7F7F;">
        <div style="padding:10px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="images/w1.jpg" width="40px" />
                    </td>
                    <td style="padding-left:10px;">
                        <b style="font-size:16px;">
                            余额：<%=get.ye(username) %>元
                        </b>
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>
    </div>
    <div class="b_l_w">
        <div style="padding:10px;">
            <a href="/user/chongzhi_ye.aspx" class="a_kk" style="background-color:#ff6d00;">我要充值</a>
            <a href="/user/dongtai_ye.aspx" class="a_kk" style="background-color:#ff6d00;">金额记录</a>
            <a href="/user/tixian.aspx" class="a_kk" style="background-color:#ff6d00;">提现</a>
            <a href="/user/jilu.aspx" class="a_kk" style="background-color:#ff6d00;">提现记录</a>
            <div class="clear"></div>
        </div>
    </div>
</div>

<div class="b_l_w" style="background-image:url(images/indexbg.jpg);background-size:100%;margin-top:10px;">
    <div class="b_l_w" style="border-bottom:1px solid #7F7F7F;">
        <div style="padding:10px;">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width:40px;">
                        <img src="images/w2.jpg" width="40px" />
                    </td>
                    <td style="padding-left:10px;">
                        <div class='b_r dis'>
                            即将过期的红包<span style="color:red;"><%=gqhb %></span>元
                        </div>
                        <b style="font-size:16px;">
                            T币：<%=cb %>个
                        </b>
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>
    </div>
    <div class="b_l_w dis">
        <div style="padding:10px;">
            <a href="/user/dongtai_hb.aspx" class="a_kk">红包记录</a>
            <a href="/user/hb_shuoming.aspx" class="a_kk">红包说明</a>
            <a href="/dzp" class="a_kk">抢红包</a>
            <div class="clear"></div>
        </div>
    </div>
</div>

<div class="b_l_w" style="background-image:url(images/indexbg.jpg);background-size:100%;margin-top:10px;">
    <div class="b_l_w" style="border-bottom:1px solid #7F7F7F;">
        <div style="padding:10px;">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width:40px;">
                        <img src="images/w3.jpg" width="40px" />
                    </td>
                    <td style="padding-left:10px;">
                        <div class='b_r'>
                            <a href="wyzq.aspx">我要推广 ></a>
                        </div>
                        <b style="font-size:16px;">
                            <a href="wyzq.aspx">一起分享</a>
                        </b>
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>
    </div>
    <div class="b_l_w">
        <div style="padding:10px;">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:50%;padding-right:10px;" valign="top">
                        <b>个人</b><br />
                        直接推荐：<a href="xiaji.aspx" class="clan"><%=get.ren(username) %></a>人<br />
                        团队人数：<a href="xiaji.aspx" class="clan"><%=get.zren(username) %></a>人<br />
                        今日收益：<a href="dongtai_ye.aspx" class="clan"><%=get.jinshou(username) %></a>元<br />
                        总收益：<a href="dongtai_ye.aspx" class="clan"><%=get.zongshou(username) %></a>元
                    </td>
                    <td style="border-left:1px solid #ccc;padding-left:10px;" valign="top" class="<%=ifdl %>">
                        <b><%=get.jb(username) %></b><br />
                        <%=jbmc %>茶客：<a href="xiaji.aspx?lei=dl" class="clan"><%=get.dlren(username) %></a>人<br />
                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                            <div class="b_l_w dis" >
                                <div class="b_l">
                                    大V总数：<a href="xiaji_dv.aspx" class="clan"><%=get.dv_zong(username) %></a>人
                                </div>
                            </div>
                            <div class="b_l_w dis">
                                大V收益：<a href="dongtai_ye.aspx" class="clan"><%=get.dv_shouyi(username) %></a>米
                            </div>
                            <div class="b_l_w dis">
                                <div class="b_l">
                                    <a href="xiaji_dv.aspx" class="clan">大V设置</a>
                                </div>
                                <div class="b_r">
                                    <a href="sh_dv.aspx" class="clan">大V申请审核</a>
                                </div>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>
    </div>
</div>
<asp:Panel ID="Panel5" runat="server">
    <div class="b_l_w" style="background-image:url(images/indexbg.jpg);background-size:100%;margin-top:10px;">
        <div class="b_l_w" style="border-bottom:1px solid #7F7F7F;">
            <div style="padding:10px;">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width:40px;">
                            <img src="images/w4.jpg" width="40px" />
                        </td>
                        <td style="padding-left:10px;">
                            <b style="font-size:16px;">
                                <a href="wysdv.aspx">申请合伙</a>
                            </b>
                        </td>
                    </tr>
                </table>
                <div class="clear"></div>
            </div>
        </div>
        <div class="b_l_w">
            <div style="padding:10px;">
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <b>负责人：<%=name %></b><br />热线电话：<a href="tel:<%=phone %>"><%=phone %></a><br />地址：<%=address %></asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Visible="false">
                    <a tel="057182565239">客服电话:0571-82565239</a>
                </asp:Panel>
                <div class="clear"></div>
            </div>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="Panel4" runat="server" Visible="false">
    <div class="b_l_w" style="background-image:url(images/indexbg.jpg);background-size:100%;margin-top:10px;">
        <div style="padding:10px;">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:49%;">
                        <a href="wysdv.aspx"><img src="images/w5.jpg" width="100%" /></a>
                    </td>
                    <td style="width:2%;">
                        &nbsp;
                    </td>
                    <td style="width:49%;">
                        <a href="wyzdl.aspx"><img src="images/w6.jpg" width="100%" /></a>
                    </td>
                </tr>
            </table>
            <div class="clear"></div>
        </div>
    </div>
</asp:Panel>
</asp:Content>

