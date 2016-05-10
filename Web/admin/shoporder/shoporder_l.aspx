<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="shoporder_l.aspx.cs" Inherits="Web.admin.shoporder.shoporder_l" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    body { line-height:23px;}
    .table123,.xqtable { border-collapse:collapse;}
    .table123 .one { color:#404040;background-color:#F3F3F3;}
    .table123 td{ border:1px solid #E4E4E4;padding:10px;text-align:left;}
    .xqtable td { padding:5px;border:1px solid #ccc;}
    .xqtable .td1 { text-align:right;width:200px;}
    .r4 { width:99%;margin:0px auto;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>订单详情</strong></li></ul>

<div class="r4">
    <div class="jl">
        
        <div class="b_l_w" style="margin:10px 0px 0px 0px;">
        <table class="xqtable" cellpadding="0" cellspacing="0" width="100%">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
            
                <tr>
                    <td class="td1">订单号：</td>
                    <td><%#Eval("ordernumber") %></td>
                </tr>
                <tr>
                    <td class="td1">收货人：</td>
                    <td><%#Eval("name") %></td>
                </tr>
                <tr>
                    <td class="td1">联系电话：</td>
                    <td><%#Eval("tel") %></td>
                </tr>
                <tr>
                    <td class="td1">邮政编码：</td>
                    <td><%#Eval("code") %></td>
                </tr>
                <tr>
                    <td class="td1">收货地址：</td>
                    <td><%#Eval("address") %></td>
                </tr>

        </ItemTemplate>
        </asp:Repeater>
                <tr>
                    <td class="td1">状态：</td>
                    <td>
                        <asp:RadioButtonList ID="zt" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">未付款</asp:ListItem>
                        <asp:ListItem Value="2">已付款</asp:ListItem>
                        <asp:ListItem Value="3">已发货</asp:ListItem>
                        <asp:ListItem Value="4">交易完成</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="td1">快递单号：</td>
                    <td>
                        <asp:TextBox ID="fdan" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="td1">快递名称：</td>
                    <td>
                        <asp:DropDownList ID="fname_id" runat="server">
                        <asp:ListItem Value="">请选择快递</asp:ListItem>
                        <asp:ListItem Value="ems">ems快递</asp:ListItem>
                        <asp:ListItem Value="huitongkuaidi">汇通快运</asp:ListItem>
                        <asp:ListItem Value="quanfengkuaidi">全峰快递</asp:ListItem>
                        <asp:ListItem Value="shentong">申通</asp:ListItem>
                        <asp:ListItem Value="shunfeng">顺丰</asp:ListItem>
                        <asp:ListItem Value="tiantian">天天快递</asp:ListItem>
                        <asp:ListItem Value="zhongtong">中通速递</asp:ListItem>
                        <asp:ListItem Value="yunda">韵达快运</asp:ListItem>
                        <asp:ListItem Value="yuantong">圆通速递</asp:ListItem>
                        <asp:ListItem Value="youzhengguonei">邮政包裹挂号信</asp:ListItem>
                        <asp:ListItem Value="youzhengguoji">邮政国际包裹挂号信</asp:ListItem>
                        <asp:ListItem Value="aae">aae全球专递</asp:ListItem>
                        <asp:ListItem Value="anjie">安捷快递</asp:ListItem>
                        <asp:ListItem Value="anxindakuaixi">安信达快递</asp:ListItem>
                        <asp:ListItem Value="biaojikuaidi">彪记快递</asp:ListItem>
                        <asp:ListItem Value="bht">bht</asp:ListItem>
                        <asp:ListItem Value="baifudongfang">百福东方国际物流</asp:ListItem>
                        <asp:ListItem Value="coe">中国东方（COE）</asp:ListItem>
                        <asp:ListItem Value="changyuwuliu">长宇物流</asp:ListItem>
                        <asp:ListItem Value="datianwuliu">大田物流</asp:ListItem>
                        <asp:ListItem Value="debangwuliu">德邦物流</asp:ListItem>
                        <asp:ListItem Value="dhl">dhl</asp:ListItem>
                        <asp:ListItem Value="dpex">dpex</asp:ListItem>
                        <asp:ListItem Value="dsukuaidi">d速快递</asp:ListItem>
                        <asp:ListItem Value="disifang">递四方</asp:ListItem>
                        <asp:ListItem Value="fedex">fedex（国外）</asp:ListItem>
                        <asp:ListItem Value="feikangda">飞康达物流</asp:ListItem>
                        <asp:ListItem Value="fenghuangkuaidi">凤凰快递</asp:ListItem>
                        <asp:ListItem Value="feikuaida">飞快达</asp:ListItem>
                        <asp:ListItem Value="guotongkuaidi">国通快递</asp:ListItem>
                        <asp:ListItem Value="ganzhongnengda">港中能达物流</asp:ListItem>
                        <asp:ListItem Value="guangdongyouzhengwuliu">广东邮政物流</asp:ListItem>
                        <asp:ListItem Value="gongsuda">共速达</asp:ListItem>
                        <asp:ListItem Value="hengluwuliu">恒路物流</asp:ListItem>
                        <asp:ListItem Value="huaxialongwuliu">华夏龙物流</asp:ListItem>
                        <asp:ListItem Value="haihongwangsong">海红</asp:ListItem>
                        <asp:ListItem Value="haiwaihuanqiu">海外环球</asp:ListItem>
                        <asp:ListItem Value="jiayiwuliu">佳怡物流</asp:ListItem>
                        <asp:ListItem Value="jinguangsudikuaijian">京广速递</asp:ListItem>
                        <asp:ListItem Value="jixianda">急先达</asp:ListItem>
                        <asp:ListItem Value="jjwl">佳吉物流</asp:ListItem>
                        <asp:ListItem Value="jymwl">加运美物流</asp:ListItem>
                        <asp:ListItem Value="jindawuliu">金大物流</asp:ListItem>
                        <asp:ListItem Value="jialidatong">嘉里大通</asp:ListItem>
                        <asp:ListItem Value="jykd">晋越快递</asp:ListItem>
                        <asp:ListItem Value="kuaijiesudi">快捷速递</asp:ListItem>
                        <asp:ListItem Value="lianb">联邦快递（国内）</asp:ListItem>
                        <asp:ListItem Value="lianhaowuliu">联昊通物流</asp:ListItem>
                        <asp:ListItem Value="longbanwuliu">龙邦物流</asp:ListItem>
                        <asp:ListItem Value="lijisong">立即送</asp:ListItem>
                        <asp:ListItem Value="lejiedi">乐捷递</asp:ListItem>
                        <asp:ListItem Value="minghangkuaidi">民航快递</asp:ListItem>
                        <asp:ListItem Value="meiguokuaidi">美国快递</asp:ListItem>
                        <asp:ListItem Value="menduimen">门对门</asp:ListItem>
                        <asp:ListItem Value="ocs">OCS</asp:ListItem>
                        <asp:ListItem Value="peisihuoyunkuaidi">配思货运</asp:ListItem>
                        <asp:ListItem Value="quanchenkuaidi">全晨快递</asp:ListItem>
                        <asp:ListItem Value="quanjitong">全际通物流</asp:ListItem>
                        <asp:ListItem Value="quanritongkuaidi">全日通快递</asp:ListItem>
                        <asp:ListItem Value="quanyikuaidi">全一快递</asp:ListItem>
                        <asp:ListItem Value="rufengda">如风达</asp:ListItem>
                        <asp:ListItem Value="santaisudi">三态速递</asp:ListItem>
                        <asp:ListItem Value="shenghuiwuliu">盛辉物流</asp:ListItem>
                        <asp:ListItem Value="sue">速尔物流</asp:ListItem>
                        <asp:ListItem Value="shengfeng">盛丰物流</asp:ListItem>
                        <asp:ListItem Value="saiaodi">赛澳递</asp:ListItem>
                        <asp:ListItem Value="tiandihuayu">天地华宇</asp:ListItem>
                        <asp:ListItem Value="tnt">tnt</asp:ListItem>
                        <asp:ListItem Value="ups">ups</asp:ListItem>
                        <asp:ListItem Value="wanjiawuliu">万家物流</asp:ListItem>
                        <asp:ListItem Value="wenjiesudi">文捷航空速递</asp:ListItem>
                        <asp:ListItem Value="wuyuan">伍圆</asp:ListItem>
                        <asp:ListItem Value="wxwl">万象物流</asp:ListItem>
                        <asp:ListItem Value="xinbangwuliu">新邦物流</asp:ListItem>
                        <asp:ListItem Value="xinfengwuliu">信丰物流</asp:ListItem>
                        <asp:ListItem Value="yafengsudi">亚风速递</asp:ListItem>
                        <asp:ListItem Value="yibangwuliu">一邦速递</asp:ListItem>
                        <asp:ListItem Value="youshuwuliu">优速物流</asp:ListItem>
                        <asp:ListItem Value="yuanchengwuliu">远成物流</asp:ListItem>
                        <asp:ListItem Value="yuanweifeng">源伟丰快递</asp:ListItem>
                        <asp:ListItem Value="yuanzhijiecheng">元智捷诚快递</asp:ListItem>
                        <asp:ListItem Value="yuntongkuaidi">运通快递</asp:ListItem>
                        <asp:ListItem Value="yuefengwuliu">越丰物流</asp:ListItem>
                        <asp:ListItem Value="yad">源安达</asp:ListItem>
                        <asp:ListItem Value="yinjiesudi">银捷速递</asp:ListItem>
                        <asp:ListItem Value="zhaijisong">宅急送</asp:ListItem>
                        <asp:ListItem Value="zhongtiekuaiyun">中铁快运</asp:ListItem>
                        <asp:ListItem Value="zhongyouwuliu">中邮物流</asp:ListItem>
                        <asp:ListItem Value="zhongxinda">忠信达</asp:ListItem>
                        <asp:ListItem Value="zhimakaimen">芝麻开门</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="td1">发货时间：</td>
                    <td><asp:Literal ID="ftimes" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="td1">订单备注：</td>
                    <td>
                        <asp:TextBox ID="bz" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="提交修改" UseSubmitBehavior="false" OnClick="Button1_Click"></asp:Button>
                        <a href="<%=Request.QueryString["url"] %>">返回</a>
                    </td>
                </tr>
                </table>
        </div>

        <div class="b_l_w" style="padding:30px 0px 10px 0px;">

        <style>
            .table314 td { color:#9B9B9B;text-align:center;padding:5px;vertical-align:middle;}
            .table314 th { border-bottom:2px solid #CA1C33;padding-bottom:10px;font-weight:100;}
        </style>

        <table class="table314" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <th>商品</th>
            <th style="width:85px;">数量</th>
            <th style="width:85px;">&nbsp;</th>
            <th style="width:85px;">单价</th>
        </tr>

        <asp:Repeater ID="Repeater2" runat="server" EnableViewState="false">
        <ItemTemplate>

        <tr>
            <td style="text-align:left;">
                <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="vertical-align:top;padding-left:10px;">
                        <a href="/pro_l.aspx?id=<%#Eval("mid") %>" target="_blank"><img src="<%#Eval("mx_img") %>" width="70px" height="70px" style="border:1px solid #ccc;" /></a>
                    </td>
                    <td style="vertical-align:top;text-align:left;padding-left:10px;line-height:20px;width:250px;">
                        <a href="/pro_l.aspx?id=<%#Eval("mid") %>" target="_blank"><b><%#Eval("mname") %></b></a><br />
                        货号：<%#get.m_str(Eval("mid"),"s10") %><br />
                        颜色：<%#Eval("ys") %><br />
                        尺寸：<%#Eval("cc") %><br />
                    </td>
                </tr>
                </table>
            </td>
            <td><%#Eval("sum") %></td>
            <td>X</td>
            <td style="color:#C80000;font-weight:bold;">￥<%#Eval("price") %></td>
        </tr>

        </ItemTemplate>
        </asp:Repeater>

        </table>

        </div>

        <div class="b_l_w" style="position:relative;border-top:1px solid #ccc;background-color:#EDEDED;padding:20px 0px 20px 0px;margin-top:-1px;">
            <div class="b_l">
                使用红包：<b style="color:red;"><%=hb %></b>元
            </div>
            <div class="b_l" style="margin-left:5px;">
                使用消费劵：<b style="color:red;"><%=xfj %></b>元
            </div>
            <div class="b_l" style="margin-left:5px;">
                使用余额：<b style="color:red;"><%=ye %></b>元
            </div>
            <div class="b_r" style="margin:-4px 5px 0px 0px;">
                商品总价：<b style="font-size:20px;line-height:20px;color:red;">￥<asp:Literal ID="s2" runat="server" EnableViewState="false"></asp:Literal></b>
            </div>
            <div class="b_r" style="margin:0px 15px 0px 0px;">
                商品总数：<asp:Literal ID="s1" runat="server" EnableViewState="false"></asp:Literal> 件
            </div>
        </div>

    </div>
</div>

</asp:Content>

