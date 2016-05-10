<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.admin.xfj.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/dntmanager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ul class="navLocation"><li><strong>消费劵管理</strong></li></ul>
    <div class="b_l_w">
        <div style="padding:5px;">
            <div class="b_l_w">
                <asp:Panel ID="Panel1" CssClass="ManagerForm" runat="server" DefaultButton="cao_bt">
                    <fieldset>
                        <legend style="background:url(../images/icons/icon44.jpg) no-repeat 6px 50%;">操作消费劵</legend>
                        <table width="100%" class="table898" align="left" cellpadding="5" cellspacing="5">
                            <tr>
                                <td style="text-align:right;">
                                    用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="username" runat="server" CssClass="formTitle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    操作：
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="cao" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True">增加</asp:ListItem>
                                    <asp:ListItem>扣除</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    消费劵：
                                </td>
                                <td>
                                    <asp:TextBox ID="jf" runat="server" CssClass="formTitle yan2" Text="0"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    备注：
                                </td>
                                <td>
                                    <asp:TextBox ID="bz" runat="server" CssClass="formTitle" Width="300px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="cao_bt" runat="server" Text=" 提交 "  CssClass="formInput01" UseSubmitBehavior="false" OnClick="cao_bt_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </div>
            <asp:Panel ID="Panel2" CssClass="ManagerForm" runat="server" DefaultButton="search_bt">
                    <fieldset>
                        <legend style="background:url(../images/icons/icon44.jpg) no-repeat 6px 50%;">消费劵记录</legend>
                        <div class="b_l_w" style="margin-top:10px;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>用户名：</td>
                                    <td>
                                        <asp:TextBox ID="search_username" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;<asp:Button ID="search_bt" runat="server" Text="搜索" UseSubmitBehavior="false" OnClick="search_bt_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="b_l_w" style="margin-top:10px;">
                            <style>
                                .tabBox .tabTitleMain th{ text-align: center; }
                                .tabBox td { padding: 10px; text-align: center; }
                            </style>
                            <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
                                <tr class="tabTitleMain">
                                    <th>
                                        用户名
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                    <th>
                                        操作消费劵
                                    </th>
                                    <th>
                                        当前消费劵
                                    </th>
                                    <th style="width:300px;">
                                        备注
                                    </th>
                                    <th style="width:130px;">
                                        时间
                                    </th>
                                    <th style="width:70px;">
                                        操作
                                    </th>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("username") %>
                                        </td>
                                        <td>
                                            <%#get.cao(Eval("cao")) %>
                                        </td>
                                        <td>
                                            <%#Eval("jf") %>
                                        </td>
                                        <td>
                                            <%#Eval("dqjf") %>
                                        </td>
                                        <td>
                                            <%#Eval("bz") %>
                                        </td>
                                        <td>
                                            <%#Eval("times") %>
                                        </td>
                                        <td>
                                            <a class="lv" href="javascript:;" onclick="if(confirm('确定删除？')){location.href='?del=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>';}">删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <div class="b_l_w" style="margin-top:10px;">
                            <div class='b_r'>
                                <%=fystr %>
                            </div>
                        </div>
                    </fieldset>
            </asp:Panel>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>

