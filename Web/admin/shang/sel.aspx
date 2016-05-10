<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="sel.aspx.cs" Inherits="Web.admin.shang.sel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <ul class="navLocation"><li><strong>专柜列表</strong></li></ul>
    <div class="b_l_w" style="padding:5px 0px 5px 0px;">
        <div class="b_l" style="margin-left:5px;">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="search_tj">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>省份：</td>
                            <td>
                                <asp:DropDownList ID="s_sheng" runat="server" AutoPostBack="true" OnSelectedIndexChanged="s_sheng_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>地区：</td>
                            <td>
                                <asp:DropDownList ID="s_shi" runat="server" AutoPostBack="true" OnSelectedIndexChanged="s_shi_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>县市：</td>
                            <td>
                                <asp:DropDownList ID="s_xian" runat="server"></asp:DropDownList>
                            </td>
                            <td>名称：</td>
                            <td>
                                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="search_tj" runat="server" Text="搜索" OnClick="search_tj_Click" UseSubmitBehavior="false"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
        <div class='b_r' style="margin-right:5px;">
            <a href="in.aspx" class="lv">增加</a>
        </div>
    </div>
    <div class="b_l_w">
        <table class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th>
                省份
            </th>
            <th>
                地区
            </th>
            <th>
                县市
            </th>
            <th>
                名称
            </th>
            <th>
                电话
            </th>
            <th style="width:200px;">
                地址
            </th>
            <th style="width:70px">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">

            <td>
                <%#get.sheng(Eval("sheng")) %>
            </td>
            <td>
                <%#get.shi(Eval("shi")) %>
            </td>
            <td>
                <%#get.xian(Eval("xian")) %>
            </td>
            <td>
                <%#Eval("name") %>
            </td>
            <td>
                <%#Eval("phone") %>
            </td>
            <td>
                <%#Eval("address") %>
            </td>
            <td style="text-align:center;">
                
                <a href='in.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl) %>' class="lv">编辑</a>
                <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
              
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

    <div style="float:left;width:100%;display:inline;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
    </div>
</asp:Content>
