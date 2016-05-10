<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="Web.admin.wx.menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ul class="navLocation"><li><strong>自定义菜单</strong></li></ul>
<div class="infoBox">
    <div class="b_l_w">
        <div class="b_l">
            <asp:LinkButton ID="bt_gx" runat="server" CssClass="lv" OnClick="bt_gx_Click">更新公众号菜单</asp:LinkButton>
            <asp:LinkButton ID="bt_del" runat="server" CssClass="hon" OnClick="bt_del_Click">删除公众号菜单</asp:LinkButton>
        </div>
        <div class="b_r">
            <a href="menu_one_in.aspx?url=<%=Server.UrlEncode(Request.RawUrl) %>" class="lan">增加一级菜单</a>
        </div>
    </div>
    <div class="b_l_w" style="margin-top:10px;">
        <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
            <tr class="tabTitleMain">
                <th>名称</th>
                <th style="width:300px;">链接</th>
                <th style="width: 250px;">操作</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                    <td style="text-align:left;padding-left:10px;font-weight:bold;"><%#Eval("name") %></td>
                    <td style="text-align:left;padding-left:10px;"><%#Eval("href") %></td>
                    <td>
                        <a href="menu_two_in.aspx?menu_one_id=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>" class="huang">添加二级菜单</a>
                        <asp:LinkButton ID="bt_shang" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                        <asp:LinkButton ID="bt_xia" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">下移</asp:LinkButton>
                        <a href='menu_one_in.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                        <asp:LinkButton ID="bt_del" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
                    </td>
                </tr>
                <asp:Repeater ID="Repeater111" runat="server" OnItemCommand="Repeater111_ItemCommand">
                <ItemTemplate>
                    <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                        <td style="text-align:left;padding-left:10px;">　┣&nbsp;<%#Eval("name") %></td>
                        <td style="text-align:left;padding-left:10px;"><%#Eval("href") %></td>
                        <td>
                            <asp:LinkButton ID="bt_shang" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                            <asp:LinkButton ID="bt_xia" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">下移</asp:LinkButton>
                            <a href='menu_two_in.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                            <asp:LinkButton ID="bt_del" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="b_l_w" style="line-height:23px;margin-top:10px;">
        <b>注：</b>每次修改完以后需要点击更新公众号菜单，自定义菜单需要开启自定义菜单接口后方可使用。目前自定义菜单最多包括3个一级菜单，每个一级菜单最多包含5个二级菜单。一级菜单最多4个汉字，二级菜单最多7个汉字，多出来的部分将会以“...”代替。请注意，创建自定义菜单后，由于微信客户端缓存，需要24小时微信客户端才会展现出来。建议测试时可以尝试取消关注公众账号后再次关注，则可以看到创建后的效果。
    </div>
</div>
</asp:Content>
