<%@ Page Title="" Language="C#" MasterPageFile="~/cjh/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.cjh._default" %>

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
   
    <div  style="padding-top: 10px; padding-bottom: 10px; padding-left: 10px; padding-right: 10px; background-color: #f0f1f6;float:left;display:inline;">
        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="b_l_w " style="background-color: white;padding:5px;">
                    <table class="" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <a  href="news.aspx?id=<%#Eval("id") %>"><img src="<%#Eval("imgc") %>" style="width: 100%" /></a>
                            </td>
                            <td style="padding-left: 10px; height: 28px; width: 60%; vertical-align: top; line-height: 22px;">
                                <a  href="news.aspx?id=<%#Eval("id") %>">
                                <span style="font-size: 14px; color: #9aba2b; font-weight: bold;"><%#Eval("title") %></span>
                                <br />

                                <%#Eval("jianjie") %></a>
                            </td>
                        </tr>

                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div style="float:left;width:100%;margin-top:10px;">
            <img  src="/images/czm.jpg" width="100%"/>
        </div>
    </div>
</asp:Content>
