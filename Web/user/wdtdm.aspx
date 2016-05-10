<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="wdtdm.aspx.cs" Inherits="Web.user.wdtdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="b_l_w" style="background-color: #F9F9F9; padding: 10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color: #FE4600; font-size: 14px; margin-left: 5px; font-weight: bold;">
                我的团队 —— <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
            
            <div class="b_r" style="margin-right: 5px;">
            </div>
        </div>
    </div>
    <div class="clear w100">
        <img src="/images/cart5.jpg" />
    </div>
    <div style="padding: 5px; position: relative; z-index: 2; background-color: #fff;">

        <div class="b_l_w">
            <div class="w100">

                <table width="100%" cellpadding="0" cellspacing="0">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width:33%;height:30px;overflow:hidden;font-size:14px;"><%#Eval("lgname") %></td>
                                <td style="width: 50%;overflow:hidden;font-size:14px;text-align:left;"><%#Eval("name") %></td>
                                <td style="width: 16%;"><img  src="<%#Eval("img") %>" width="30" style="border-radius: 10px;width:30px;"/></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height:6px;"></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height:1px; line-height:1px;background-color:#e01212;"></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height:6px;"></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

            </div>



        </div>
    </div>
</asp:Content>
