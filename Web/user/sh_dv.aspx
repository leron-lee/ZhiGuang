<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="sh_dv.aspx.cs" Inherits="Web.user.sh_dv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                大V申请审核
            </div>
        </div>
    </div>
    <div class='b_l_w'>
        <div style="padding:5px;">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="b_l_w" style="padding:5px 0px 5px 0px;border-bottom:1px dotted #ccc;">
                    姓名：<%#Eval("name") %><br />
                    粉丝数：<%#get.ren(Eval("username")) %><br />
                    联系方式：<%#Eval("phone") %><br />
                    地址：<%#get.s_sheng(Eval("s_sheng"))+get.s_shi(Eval("s_shi"))+get.s_xian(Eval("s_xian")) %><br />
                    状态：<%#get.sh(Eval("sh")) %><br />
                    <a href="xiaji_dv_up.aspx?id=<%#get.username_id(Eval("username")) %>&url=<%#Server.UrlEncode(Request.RawUrl) %>" class="a_lv <%#get.sh_class(Eval("sh")) %>">审核通过</a>
                    <a href="javascript:;" onclick="if(confirm('确定删除？')){location.href='?del=<%#Eval("id") %>&url=<%#Server.UrlEncode(Request.RawUrl) %>';}" class="a_hon" style="margin-left:5px;">删除</a>
                </div>
            </ItemTemplate>
            </asp:Repeater>
            <div class="b_l_w" style="margin-top:5px;">
                <center>
                    <%=fystr %>
                </center>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
