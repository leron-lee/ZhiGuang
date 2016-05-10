<%@ Page Title="" Language="C#" MasterPageFile="~/cjh/master.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Web.cjh.news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/body.css" rel="stylesheet" />
   <script src="/js/js6.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 5px;">
        <div class="b_l_w">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div style="font-size: 16px; margin-top:20px; "><%#Eval("title") %></div>
                    <div style="color: #B8B8B8;"><%#Convert.ToDateTime(Eval("times")).ToShortDateString() %></div>
                  
                    <div class="w100" style="padding-top: 10px;">
                        <%#Eval("main") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <asp:Panel ID="Panel1" runat="server" Visible="false">

                <asp:Button ID="Button1" runat="server" Text="报名参加" style="border:0px;width:100%;height:36px;line-height:36px;font-size:22px;color:white;background-color:red;margin-top:30px;" OnClick="Button1_Click" />
            </asp:Panel>
            
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
