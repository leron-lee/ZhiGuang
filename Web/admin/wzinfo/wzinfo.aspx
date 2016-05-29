<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="wzinfo.aspx.cs" Inherits="Web.admin.wzinfo.wzinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function closeimg(imgstr, testr) {
            $("#" + imgstr).attr("src", "/images/bmjj-1.jpg");
            $("#" + testr).attr("value", "");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <ul class="navLocation">
        <li><strong>基本信息设置</strong></li>
    </ul>

    <div class="infoBox">

        <table width="100%" class="table898">
            <tr>
                <td style="text-align: right;">网站名称：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">上传按钮：</td>
                <td>
                    <asp:RadioButton ID="scan_1" runat="server" GroupName="2341" Text="FLASH进度条模式" AutoPostBack="true" OnCheckedChanged="scan_1_CheckedChanged"></asp:RadioButton>
                    <asp:RadioButton ID="scan_2" runat="server" GroupName="2341" Text="普通模式" AutoPostBack="true" OnCheckedChanged="scan_2_CheckedChanged"></asp:RadioButton>
                    (有些服务器<span style="color: red;">安全级别设置</span>下不支持FLASH进度条上传模式的情况下，请切换到<span style="color: red;">普通模式</span>)
                </td>
            </tr>
            <tr class="dis">
                <td style="text-align: right;">特价产品分红：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="tj_fh" runat="server" CssClass="formTitle yan2" Text="1"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin: 7px 0px 0px 5px;">
                        元
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">特价产品限购：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="tj_xg" runat="server" CssClass="formTitle yan1" Text="1"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin: 7px 0px 0px 5px;">
                        件
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">分享须知：</td>
                <td style="padding: 5px 0px 5px 0px; line-height: 23px;">1.进入“公众号设置”》“功能设置”里填写“JS接口安全域名”。<br />
                    2.需要在本后台的微信管理-参数设置，填写 AppId 和 AppSecret (在公众平台的开发者中心查看)
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">分享LOGO：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin: 2px 0px 0px 5px;">
                        <%=get.upload(TextBox2.ClientID) %>
                    </div>
                    <div class="b_l" style="margin: 7px 0px 0px 5px;">
                    </div>
                </td>
            </tr>
            <tr class="dis">
                <td style="text-align: right;">首页title：</td>
                <td>
                    <asp:TextBox ID="TextBox3" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr class="">
                <td style="text-align: right;">分享标题：</td>
                <td style="height: 70px">
                    <asp:TextBox ID="TextBox4" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr class="">
                <td style="text-align: right;">分享内容：</td>
                <td style="height: 70px">
                    <asp:TextBox ID="TextBox5" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: right;">JS代码：</td>
                <td style="height: 70px">
                    <asp:TextBox ID="TextBox6" Width="500px" TextMode="MultiLine" Height="50px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>

            <style>
                #idsdg td {
                    border: 0px;
                    padding: 5px 0px 0px 0px;
                }

                    #idsdg td img {
                        padding-bottom: 5px;
                    }

                #idsdg2 td {
                    border: 0px;
                    padding: 5px 0px 0px 0px;
                }

                    #idsdg2 td img {
                        padding-bottom: 5px;
                    }
            </style>

            <tr class="">
                <td style="text-align: right;">滚动图片：</td>
                <td>

                    <table id="idsdg" style="text-align: center;" cellspacing="0" cellpadding="0" width="750px">
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg1" runat="server" Style="display: none;"></asp:TextBox>
                                <p>链接:<asp:TextBox ID="lj1" runat="server" Width="80px"></asp:TextBox></p>
                                <p class="dis">文字:<asp:TextBox ID="wz1" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image1.ClientID %>','<%=tximg1.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image2" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg2" runat="server" Style="display: none;"></asp:TextBox>
                                <p>链接:<asp:TextBox ID="lj2" runat="server" Width="80px"></asp:TextBox></p>
                                <p class="dis">文字:<asp:TextBox ID="wz2" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image2.ClientID %>','<%=tximg2.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image3" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg3" runat="server" Style="display: none;"></asp:TextBox>
                                <p>链接:<asp:TextBox ID="lj3" runat="server" Width="80px"></asp:TextBox></p>
                                <p class="dis">文字:<asp:TextBox ID="wz3" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image3.ClientID %>','<%=tximg3.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image4" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg4" runat="server" Style="display: none;"></asp:TextBox>
                                <p>链接:<asp:TextBox ID="lj4" runat="server" Width="80px"></asp:TextBox></p>
                                <p class="dis">文字:<asp:TextBox ID="wz4" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image4.ClientID %>','<%=tximg4.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image5" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg5" runat="server" Style="display: none;"></asp:TextBox>
                                <p>链接:<asp:TextBox ID="lj5" runat="server" Width="80px"></asp:TextBox></p>
                                <p class="dis">文字:<asp:TextBox ID="wz5" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image5.ClientID %>','<%=tximg5.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image6" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg6" runat="server" Style="display: none;"></asp:TextBox>
                                <p>链接:<asp:TextBox ID="lj6" runat="server" Width="80px"></asp:TextBox></p>
                                <p class="dis">文字:<asp:TextBox ID="wz6" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image6.ClientID %>','<%=tximg6.ClientID %>')">删除</a></div>
                            </td>
                        </tr>
                        <tr>
                            <td><%=get.upload(tximg1.ClientID,Image1.ClientID) %></td>
                            <td><%=get.upload(tximg2.ClientID,Image2.ClientID) %></td>
                            <td><%=get.upload(tximg3.ClientID,Image3.ClientID) %></td>
                            <td><%=get.upload(tximg4.ClientID,Image4.ClientID) %></td>
                            <td><%=get.upload(tximg5.ClientID,Image5.ClientID) %></td>
                            <td><%=get.upload(tximg6.ClientID,Image6.ClientID) %></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr style="display: none;">
                <td style="text-align: right;">滚动图片2：</td>
                <td>

                    <table id="idsdg2" style="text-align: center;" cellspacing="0" cellpadding="0" width="750px">
                        <tr>
                            <td>
                                <asp:Image ID="Image7" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg7" runat="server" Style="display: none;"></asp:TextBox>
                                <p class="">链接:<asp:TextBox ID="lj7" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image7.ClientID %>','<%=tximg7.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image8" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg8" runat="server" Style="display: none;"></asp:TextBox>
                                <p class="">链接:<asp:TextBox ID="lj8" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image8.ClientID %>','<%=tximg8.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image9" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg9" runat="server" Style="display: none;"></asp:TextBox>
                                <p class="">链接:<asp:TextBox ID="lj9" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image9.ClientID %>','<%=tximg9.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image10" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg10" runat="server" Style="display: none;"></asp:TextBox>
                                <p class="">链接:<asp:TextBox ID="lj10" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image10.ClientID %>','<%=tximg10.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image11" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg11" runat="server" Style="display: none;"></asp:TextBox>
                                <p class="">链接:<asp:TextBox ID="lj11" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image11.ClientID %>','<%=tximg11.ClientID %>')">删除</a></div>
                            </td>
                            <td>
                                <asp:Image ID="Image12" runat="server" ImageUrl="/images/bmjj-1.jpg" Width="100px" Height="100px" />
                                <asp:TextBox ID="tximg12" runat="server" Style="display: none;"></asp:TextBox>
                                <p class="">链接:<asp:TextBox ID="lj12" runat="server" Width="80px"></asp:TextBox></p>
                                <div class="b_l_w"><a href="javascript:;" onclick="closeimg('<%=Image12.ClientID %>','<%=tximg12.ClientID %>')">删除</a></div>
                            </td>
                        </tr>
                        <tr>
                            <td><%=get.upload(tximg7.ClientID,Image7.ClientID) %></td>
                            <td><%=get.upload(tximg8.ClientID,Image8.ClientID) %></td>
                            <td><%=get.upload(tximg9.ClientID,Image9.ClientID) %></td>
                            <td><%=get.upload(tximg10.ClientID,Image10.ClientID) %></td>
                            <td><%=get.upload(tximg11.ClientID,Image11.ClientID) %></td>
                            <td><%=get.upload(tximg12.ClientID,Image12.ClientID) %></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr style="display: none;">
                <td style="text-align: right;">版权：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_bq" Width="70%" Height="80px" TextMode="MultiLine" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text=" 修改 " CssClass="formInput01" UseSubmitBehavior="False" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>
