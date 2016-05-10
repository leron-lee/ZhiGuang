<%@ Page Title="" Language="C#" MasterPageFile="~/pro.master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Web.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div style="padding:5px;">
    <div class="b_l_w">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
            <a href="news_l.aspx?id=<%#Eval("id") %>">
                <div style="border:1px solid #ccc;border-radius:5px;padding:10px;background-color:#fff;box-shadow:2px 2px #ccc;">
                    <div class="b_l_w">
                        <div style="font-size:16px;"><%#Eval("name") %></div>
                        <div style="color:#B8B8B8;"><%#Convert.ToDateTime(Eval("times")).ToShortDateString() %></div>
                        
                        <%#get.kong(Eval("x_img"),"<div class='w100'><img src='"+Eval("x_img") +"' /></div>") %>

                        <div style="padding-top:5px;">
                            <%#get.txt(Eval("s15")) %>
                        </div>
                        <div style="text-align:right;">
                            <span style="color:#2D5EAD;">查看详情</span> >
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="clear" style="height:10px;"></div>
            </a>
        </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="b_l_w">
        <div class="b_r" style="margin:5px 0px 0px 0px;">
            <%=fystr %>
        </div>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>
