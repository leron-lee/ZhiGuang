<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.user.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .listtable td { width: 50%; padding-bottom: 5px; }
    .listtable td a { border-radius: 0px; }
    .tm { filter: Alpha(Opacity=0); opacity: 0; -moz-opacity: 0; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="b_l_w" style="height:120px;background-image:url(images/1.jpg);background-size:100% 100%;color:red;">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:70px;padding:25px 0px 0px 20px;">
                    
                    <div class="b_l_w">
                        <img src="<%=r["img"] %>" width="70px" height="70px" style="border-radius:10px;" onerror="this.src='images/toux.jpg';" />
                    </div>
                    <div class="b_l_w" style="margin-top:-70px;">
                        <script>
                            function sc() {
                                $("#<%=lbUploadPhoto.ClientID%>").click();
                            }
                        </script>
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="tm" onchange="sc();" style="width:70px;height:70px;"></asp:FileUpload>
                        <div style="width:0px;height:0px;overflow:hidden;position:absolute;">
                            <asp:Button ID="lbUploadPhoto" runat="server" Text="" OnClick="lbUploadPhoto_Click"></asp:Button>
                        </div>
                    </div>
                </td>
                <td style="padding:25px 0px 0px 20px;">
                    <b style="font-size:16px;color:red;"><%=r["username"] %></b>
                    <div class="b_l_w" style="color:red;">
                        <div class="b_l_w">
                            <%=r["name"] %>
                        </div>
                        <div class="b_l_w">
                            <div class="b_l">
                                <%=get.jb(r["username"]) %>
                            </div>
                            <div class="b_r dis" style="margin-right:20px;">
                                <a href="/html/ewm.aspx?username=<%=username %>" style="color:red;border:1px solid #ccc;padding:0px 2px 0px 2px;display:block;">我的二维码</a>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class='b_l_w' style="height:60px;background-image:url(images/2.jpg);background-size:100% 100%;font-size:14px;">
        <table width="100%" cellpadding="0" cellspacing="0" style="height:60px;">
            <tr>
                <td style="width:33%;text-align:center;color:red;" onclick="location.href='xiaji.aspx';">
                    直接推荐
                    <br />
                    <%=ren %>
                </td>
                <td style="width:33%;text-align:center;color:red;" onclick="location.href='dongtai_ye.aspx';">
                    今日收入
                    <br />
                    <%=get.jinshou(username) %>
                </td>
                <td style="width:33%;text-align:center;color:red;" onclick="location.href='wdcc.aspx';">
                    全部财产
                    <br />
                    <%=get.ye(username) %>
                </td>
            </tr>
        </table>
    </div>
    <div class="b_l_w" style="background-size:100%;">
        <div class="b_l_w w100" style="border-bottom:1px solid #000;">
            <a href="shoporder.aspx"><img src="images/index1.jpg" /></a>
        </div>
        <div class="b_l_w" style="padding:10px 0px 10px 0px;">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z1dis %>"><%=z1 %></div>
                        <a href="shoporder.aspx?zt=1">
                            <img src="images/menu1.png" height="48px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z2dis %>"><%=z2 %></div>
                        <a href="shoporder.aspx?zt=2">
                            <img src="images/menu2.png" height="48px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z3dis %>"><%=z3 %></div>
                        <a href="shoporder.aspx?zt=3">
                            <img src="images/menu3.png" height="48px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <div class="vhon <%=z4dis %>"><%=z4 %></div>
                        <a href="shoporder.aspx?zt=4&pj=1">
                            <img src="images/menu4.png" height="48px" />
                        </a>
                    </td>
                    <td style="width:20%;text-align:center;">
                        <a href="/html.aspx?id=34">
                            <img src="images/menu5.png" height="48px" />
                        </a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="b_l_w" style="border-top:5px solid #F5C680;">
            <div class="w100">
                <a href="wdcc.aspx"><img src="images/index_r2_c1.jpg" /></a>
            </div>
            <div class="w100">
                <a href="wdtd.aspx"><img src="images/index_r7_c1.jpg" /></a>
            </div>
            <div class="w100">
                <a href="wyzq.aspx"><img src="images/index_r3_c1.jpg" /></a>
            </div>
          
            <div class="w100">
                <a href="up_center.aspx"><img src="images/index_r5_c1.jpg" /></a>
            </div>
            <div class="w100">
                <a href="address.aspx"><img src="images/index_r6_c1.jpg" /></a>
            </div>
            <div class="w100">
                <a href="xiaoxi.aspx"><img src="images/xiaoxi.jpg" /></a>
            </div>
        </div>
    </div>
</asp:Content>
