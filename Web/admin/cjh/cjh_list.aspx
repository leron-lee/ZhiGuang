<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="cjh_list.aspx.cs" Inherits="Web.admin.cjh.cjh_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">



    <ul class="navLocation">
        <li><strong>茶佳会列表</strong></li>
    </ul>
    <div style="float: left; display: inline; width: 100%; margin-top: 3px;">
        <table id="talbe110" class="tabBox" width="100%" cellpadding="0" cellspacing="0">
            <tr class="tabTitleMain">
                <th style="width: 20%">地区名称
                </th>
                <th style="width: 10%">登陆账号
                </th>
                <th style="width: 10%">登陆密码
                </th>
                <th style="width: 10%">姓名
                </th>
                <th style="width: 10%">电话
                </th>
                <th style="width: 20%">地址
                </th>
                <th style="width: 10%">注册时间
                </th>
                <th style="width: 10%">操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
                <ItemTemplate>
                    <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#GG(Eval("sheng"),Eval("shi"),Eval("xian"))%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("username")%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("password")%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("name")%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("tel")%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("address")%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("times")%></div>
                        </td>
                        
                        <td>

                            <a href='add_cjh.aspx?id=<%#Eval("id") %>'>编辑</a>
                            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CausesValidation="False">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div style="float: left; width: 100%;">
            <div style="float: right; display: inline; margin-right: 25px;">
                <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
