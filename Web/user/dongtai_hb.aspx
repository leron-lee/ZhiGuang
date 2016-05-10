<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="dongtai_hb.aspx.cs" Inherits="Web.user.dongtai_hb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="b_l_w" style="background-color:#F9F9F9;padding:10px 0px 10px 0px;">
    <div class="b_l_w">
        <div class="b_l" style="color:#FE4600;font-size:14px;margin-left:5px;">
            红包记录
        </div>
        <div class="b_r" style="margin-right:5px;">
            
        </div>
    </div>
</div>
<div class="b_l_w w100"><img src="/images/cart5.jpg" /></div>
<div class="b_l_w">
    <div style="padding:5px;">
        <div class="b_l_w">
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="b_l_w" style="padding:5px 0px 5px 0px;border-bottom:1px dashed #ccc;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                当前：<%#Eval("dqjf") %>元
                                <div>备注：<%#Eval("bz") %></div>
                            </td>
                            <td style="width:120px;text-align:right;">
                                <%#Eval("times") %>
                                <br />
                                <%#get.cao(Eval("cao")) %>：<%#Eval("jf") %>元
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
            </asp:Repeater>
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
