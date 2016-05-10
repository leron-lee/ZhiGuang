<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="xiaji.aspx.cs" Inherits="Web.user.xiaji" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .red { color: red; }
</style>
<script>
    var vzhi = <%=Request.QueryString["v"]%>;
    $(function () {
        if(vzhi==3){
            $(".lia a").attr("href","javascript:;");
        }
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;font-weight:bold;">
                分销会员
            </div>
            <div class="b_r <%=xian_dis %>" style="margin:0px 5px 0px 0px;">
                <a href="xiaji_dv.aspx" class="a_lv dis">设置大V</a>
            </div>
        </div>
    </div>
    <div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w dis">
        <div style="padding:5px;">
            <%=get.ying(username) %>
            级别：<%=jb %><br />
            直接爱粉：<b class="red"><%=ren %></b>人 <br />
            爱粉总数：<b class="red"><%=zren %></b>人
            <br />
            <%--可以分销人数：<b><%=(Convert.ToInt32(get.usernemfxs(username))-Convert.ToInt32(ren)) %></b>人--%>
            <div class="clear"></div>
        </div>
    </div>
    <div class="b_l_w w100 dis"><img src="/images/cart5.jpg" /></div>
    <div class="b_l_w">
        <div style="padding:5px;">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="b_l_w" style="padding:5px 0px 5px 0px;border-bottom:1px dashed #ccc;">
                    <div class="b_l lia">
                        <a href="xiaji.aspx?username=<%#Eval("username") %>&v=<%#Convert.ToInt32(v)+1 %>" value="<%#v %>"><%#get.jb(Eval("username")) %>：<%#get.ying(Eval("username")) %> <%#Eval("name") %> (<span class="red"><%#get.ren(Eval("username")) %></span>)</a><br />
                    </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>

            <asp:Repeater ID="Repeater2" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="b_l_w" style="padding:5px 0px 5px 0px;border-bottom:1px dashed #ccc;">
                    <div class="b_l lia">
                        <%#get.jb(Eval("username")) %>：<%#get.ying(Eval("username")) %> <%#Eval("name") %> (<span class="red"><%#get.ren(Eval("username")) %></span>)<br />
                    </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>

            <div class="b_l_w" style="padding:10px 0px 10px 0px;">
                <center>   
                    <%=fystr %>
                </center>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
