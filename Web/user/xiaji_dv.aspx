<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="xiaji_dv.aspx.cs" Inherits="Web.user.xiaji_dv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table121 th { background-color: #F9F9F9; }
        .table121 th, .table121 td { border: 1px solid #ccc;text-align:center; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                设置大V
            </div>
        </div>
    </div>
    <div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w">
        <div style="padding:5px;">
            <div class="b_l_w">
                <table class="table121" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            是否大V
                        </th>
                        <th>
                            用户名
                        </th>
                        <th>
                            姓名
                        </th>
                        <th>
                            分红
                        </th>
                        <th style="width:50px;">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#ifdv(Eval("ifdv")) %>
                            </td>
                            <td>
                                <%#Eval("username") %>
                            </td>
                            <td>
                                <%#Eval("name") %>
                            </td>
                            <td>
                                <%#dvfh(Eval("dvfh")) %>%
                            </td>
                            <td>
                                <a href="xiaji_dv_up.aspx?id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>" style="color:blue;">编辑</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="b_l_w" style="padding:10px 0px 10px 0px;">
                <center>   
                    <%=fystr %>
                </center>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
