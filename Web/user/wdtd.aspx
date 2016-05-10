<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="wdtd.aspx.cs" Inherits="Web.user.wdtd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="b_l_w" style="background-color: #F9F9F9; padding: 10px 0px 10px 0px;">
        <div class="b_l_w">
            <div class="b_l" style="color: #FE4600; font-size: 14px; margin-left: 5px; font-weight: bold;">
                我的团队
            </div>
            <div class="b_r" style="margin-right: 5px;">
            </div>
        </div>
    </div>
    <div class="clear w100">
        <img src="/images/cart5.jpg" />
    </div>
    <div style="padding: 5px; position: relative; z-index: 2; background-color: #fff;">

        <div class="b_l_w" >
            <div class="w100">

                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td >
                            <a href="wdtdm.aspx?type=1">
                                <img src="images/c1.jpg" width="100%" /></a>
                        </td>
                        <td style="width:15%;font-size:16px;"><asp:Literal ID="Literal1" runat="server"></asp:Literal>人</td>
                        <td style="width:10%;">
                            
                             <img src="images/c5.jpg" width="100%" />
                        </td>
                    </tr>
                      <tr>
                        <td >
                            <a href="wdtdm.aspx?type=2">
                                <img src="images/c2.jpg" width="100%" /></a>
                        </td>
                        <td style="width:15%;font-size:16px;"><asp:Literal ID="Literal2" runat="server"></asp:Literal>人</td>
                        <td style="width:10%;">
                             <img src="images/c5.jpg" width="100%" />
                        </td>
                    </tr>

                     <tr>
                        <td >
                            <a href="wdtdm.aspx?type=3">
                                <img src="images/c3.jpg" width="100%" /></a>
                        </td>
                        <td style="width:15%;font-size:16px;"><asp:Literal ID="Literal3" runat="server"></asp:Literal>人</td>
                        <td style="width:10%;">
                             <img src="images/c5.jpg" width="100%" />
                        </td>
                    </tr>
                </table>

            </div>



        </div>
    </div>

</asp:Content>
