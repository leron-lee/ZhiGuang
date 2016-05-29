<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pro.master" CodeBehind="ShopFX.aspx.cs" Inherits="Web.fx.ShopFX" %>

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
            <div class="fyneirong">
                <!--分页内容开始-->
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" Width="100%" EnableViewState="false">
                    <ItemTemplate>
                        <div style="border: 1px solid #ccc; padding: 5px; border-radius: 5px;">
                            <div class="w100">
                                <div class="b_l_w">
                                    <a href="/fx/ProductFX.aspx?ShopId=<%#Eval("Id") %>">
                                        <img src="<%#Eval("Logo") %>" height="140px" width="100%" class="now" /></a>
                                </div>
                                <div class="b_l_w" style="margin-top: 5px; text-align: center; line-height: 16px; height: 16px; overflow: hidden;">
                                    <a href="/fx/ProductFX.aspx?ShopId=<%#Eval("Id") %>"><%#Eval("Name") %></a>
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
