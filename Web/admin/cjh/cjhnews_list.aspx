<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="cjhnews_list.aspx.cs" Inherits="Web.admin.cjh.cjhnews_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    
    <ul class="navLocation">
        <li><strong>茶佳会信息列表</strong></li>
    </ul>
    <div style="float: left; display: inline; width: 100%; margin-top: 3px;">
        <table id="talbe110" class="tabBox" width="100%" cellpadding="0" cellspacing="0">
            <tr class="tabTitleMain">
                <th style="width: 20%">信息名称
                </th>
                <th style="width: 10%">类型
                </th>
                <th style="width: 10%">所属地区
                </th>
                <th style="width: 10%">标识图片
                </th>
                
                <th style="width: 10%">操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
                <ItemTemplate>
                    <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
                        
                        <td>
                            <div style="height: 20px; overflow: hidden;"><%#Eval("title")%></div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;">
                                   <%#Convert.ToInt32(Eval("type"))==1 ? "活动":"资讯" %>
                            </div>
                        </td>
                        <td>
                            <div style="height: 20px; overflow: hidden;">

                                <%#GG(Eval("typeb")) %>
                            </div>
                        </td>
                        <td>
                            
                                <img src="<%#Eval("imgc") %>" width="100" />
                           
                        </td>
                        
                        
                        <td>

                            <a href='add_cjhnews.aspx?id=<%#Eval("id") %>'>编辑</a>
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
