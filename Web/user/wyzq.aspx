<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="wyzq.aspx.cs" Inherits="Web.user.wyzq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            <%=alert%>
        });
    </script>
    <style>
        .aswa {
        display:none;
        }
        body {
        
         background-image: url(images/ib.jpg); background-size: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="b_l_w" style="height: 100%; width: 100%; text-align: center;">
        <div style="padding: 5px;">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 70px; padding: 45px 0px 0px 46px;">

                        <div class="b_l_w">
                            <img src="<%=r["img"] %>" width="70px" height="70px" style="border-radius: 10px;" />
                        </div>

                    </td>
                    <td style="padding: 15px 0px 0px 20px;">

                        <div class="b_l_w" style="color: black; font-size: 16px;">
                            <div class="b_l_w">
                                我是<%=r["name"] %>
                            </div>
                            <div class="b_l_w">
                                <div class="b_l">
                                    我为<span style="color:green;">[礼尚挚广]</span>推广
                                </div>



                            </div>
                          
                        </div>
                    </td>
                </tr>
               
               
                <tr>
                    <td colspan="2" style="text-align:center;padding:6px 0px 6px 0px;color:black;font-size:16PX;">
                     <img src="<%=img %>" width="120px" style="border-radius: 10px;" />



                    </td>
                </tr>
                  <tr>
                    <td colspan="2" style="text-align:center;padding:16px 0px 6px 0px;color:black;font-size:16PX;">
                       长按二维码，欢迎您进入礼尚挚广 <br /><br />
                       
                       礼尚挚广不是一个人人创业的平台，<br />而是有心人创富的基地！
                    </td>
                </tr>
            </table>

            <div class="b_l_w dis">
                <%=get.nt(26) %>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <b>我的推广链接</b>(长按链接复制)
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <span style="color: blue;">http://<%=Request.Url.Authority %>/?tj_username=<%=get.username_id(username) %></span>
            </div>
            <div class="b_l_w dis" style="margin-top: 5px;">
                <b>我的推广二维码</b>(长按图片发送给朋友)
            </div>
            <div class="b_l_w" style="text-align:center;">
                <a href="/html/ewm.aspx?username=<%=username%>"> </a>
                    
            </div>
            <div class="clear"></div>
        </div>
    </div>
    
</asp:Content>
