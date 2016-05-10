<%@ Page Title="" Language="C#" MasterPageFile="~/cjh/master.Master" AutoEventWireup="true" CodeBehind="country.aspx.cs" Inherits="Web.cjh.country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/swipe.js" type="text/javascript"></script>
    <style>
        #position {
        }

        li {
            list-style-type: none;
            float: left;
            font-family: Tahoma;
            color: #898883;
            font-size: 20px;
            font-weight: bold;
            margin-left: 3px;
        }

        .on {
            color: red;
        }

        #slider {
            width: 100%;
            overflow: hidden;
            width: 100%;
            float: left;
        }

            #slider .dimg {
                float: left;
                position: relative;
            }

                #slider .dimg img {
                    width: 100%;
                }

            #slider .divdhbody {
                width: 50000px;
                position: relative;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="b_l_w ">

        <div id="slider">
            <div class="divdhbody">

                <asp:Literal ID="Literal1" runat="server"></asp:Literal>


            </div>
        </div>
        <div class="b_l_w" style="position: relative; margin-top: -23px;">
            <div class="b_r" style="margin-right: 3px;">
                <ul id="position">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>



                </ul>
            </div>
        </div>
        <script>

            var slider =
              Swipe(document.getElementById('slider'), {
                  auto: 3000,
                  continuous: true,
                  callback: function (pos) {
                      var i = bullets.length;
                      while (i--) {
                          bullets[i].className = ' ';
                      }
                      bullets[pos].className = 'on';
                  }
              });
            var bullets = document.getElementById('position').getElementsByTagName('li');
        </script>

    </div>

    <div class="b_l_w " style="padding-top: 10px; padding-bottom: 10px;">
        <table class="" width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 50%; border-right: 2px solid #cbcbcb; text-align: center; color: #747474; font-size: 16px;">
                    <a href="/default.aspx">茶佳会
                    </a>
                </td>
                <td style="font-size: 16px; text-align: center; font-weight: bold; color: red;">
                    <a href="/user/">VIP专区
                    </a>
                </td>
            </tr>
        </table>
    </div>

    <div class="b_l_w " style="padding: 8px;">


        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <a style="width: 29%; height: 36px; float: left; line-height: 36px; border: 1px solid red; text-align: center; margin-bottom: 10px; margin-right: 3%;" href="country.aspx?sheng=<%#Eval("id") %>">
                    <%#Eval("name") %>
                </a>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <a style="width: 29%; height: 36px; float: left; line-height: 36px; border: 1px solid red; text-align: center; margin-bottom: 10px; margin-right: 3%;" href="country.aspx?shi=<%#Eval("id") %>">
                    <%#Eval("name") %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                <a style="width: 29%; height: 36px; float: left; line-height: 36px; border: 1px solid red; text-align: center; margin-bottom: 10px; margin-right: 3%;" href="default.aspx?xian=<%#Eval("id") %>">
                    <%#Eval("name") %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
