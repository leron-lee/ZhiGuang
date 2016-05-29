<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="pro.aspx.cs" Inherits="Web.pro1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .datable td {
            width: 33%;
            border: 1px solid #D9D9D9;
        }

            .datable td a {
                display: block;
                height: 30px;
                line-height: 30px;
                text-align: center;
            }

                .datable td a.a {
                    color: #E33638;
                }
    </style>
    <script src="/fy/fy.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color: #fff;">
        <div class="b_l_w">
            <table class="datable" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <a href="<%=url("px",ata("1")) %>" class="<%=iffx("1") %><%=iffx("2") %>">默认<span><%=ifpx("1","▼") %><%=ifpx("2","▲") %></span></a>
                    </td>
                    <td>
                        <a href="<%=url("px",ata("3")) %>" class="<%=iffx("3") %><%=iffx("4") %>">价格<span><%=ifpx("3","▼") %><%=ifpx("4","▲") %></span></a>
                    </td>
                    <td>
                        <a href="<%=url("px",ata("5")) %>" class="<%=iffx("5") %><%=iffx("6") %>">销量<span><%=ifpx("5","▼") %><%=ifpx("6","▲") %></span></a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="b_l_w">
            <div class="fyneirong">
                <!--分页内容开始-->
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="100%" EnableViewState="false">
                    <ItemTemplate>
                        <div style="border: 1px solid #ccc; padding: 5px; border-radius: 5px;">
                            <div class="w100">
                                <div class="b_l_w">
                                    <a href="pro_l.aspx?id=<%#Eval("id") %>">
                                        <img src="<%#Eval("x_img") %>" height="140px" width="100%" class="now" /></a>
                                </div>
                                <div class="b_l_w" style="margin-top: 5px; text-align: center; line-height: 16px; height: 16px; overflow: hidden;">
                                    <a href="pro_l.aspx?id=<%#Eval("id") %>"><%#Eval("name") %></a>
                                </div>
                                <div class="b_l_w" style="margin-top: 5px;">
                                    <b style="color: red; font-size: 16px;">￥<%#get.jg(Eval("id"),Request) %></b>
                                    <s>￥<%#Eval("s1") %></s>
                                    <br />
                                    <span style="color: #999999;">销量:<%#Eval("s3") %></span>
                                </div>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="50%" />
                </asp:DataList>
                <!--分页内容结束-->
            </div>
            <div class="jzz"><a id="jzz_a" name="jzz_a">&nbsp;</a>加载中...</div>
        </div>
    </div>
</asp:Content>
