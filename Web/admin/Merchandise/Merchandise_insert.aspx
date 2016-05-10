<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="Merchandise_insert.aspx.cs" Inherits="Web.admin.Merchandise.Merchandise_insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<%if (Request.QueryString["id"] == null)
{ %>
    <ul class="navLocation"><li><strong>添加信息</strong></li></ul>
<%}
else
{ %>        
    <ul class="navLocation"><li><strong>修改信息</strong></li></ul>
<%} %>

<asp:Panel ID="Panel2" runat="server" DefaultButton="Button1">
    <div class="infoBox">
        <table width="100%" class="table898" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align:right;">
                    名称：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                    <a href="?px=ture">从上一条数据中修改添加</a>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    请选择类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="0">请选择类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <tr>
                    <td style="text-align:right;">
                        是否特价？
                    </td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList>
                        (如果选择了特价就不参与分红了)
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="Panel8" runat="server" Visible="false">
                <tr>
                    <td style="text-align:right;">
                        是否推荐？
                    </td>
                    <td>
                        <asp:RadioButtonList ID="tj" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        首页推荐？
                    </td>
                    <td>
                        <asp:RadioButtonList ID="sy_tj" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        今天上新？
                    </td>
                    <td>
                        <asp:RadioButtonList ID="jrsx" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="Panel6" runat="server">
            <tr>
                <td style="text-align:right;">
                    图片：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox2"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox2.ClientID) %>
                    </div>
                    <div class="b_l" style="margin:7px 0px 0px 5px;">
                        <%--(下载模块时这里上传附件)--%>
                    </div>
                </td>           
            </tr>
            </asp:Panel>
            <tr style="display:none;">
                <td style="text-align:right;">
                    视频：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox8"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox8.ClientID) %>
                    </div>
                    <div class="b_l" style="margin:7px 0px 0px 5px;">
                        (FLV、MP4格式)
                    </div>
                </td>           
            </tr>
            <tr style="display:none;">
                <td style="text-align:right;">
                    产品规格：
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>           
            </tr>

            <asp:Panel ID="Panel9" runat="server" Visible="false">
                <tr>
                    <td style="text-align:right;">简介：</td>
                    <td><asp:TextBox ID="TextBox24" Width="500px" runat="server" CssClass="formTitle" TextMode="MultiLine" Height="50px"></asp:TextBox></td>           
                </tr>
            </asp:Panel>
            
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            
            <tr>
                <td style="text-align:right;">图片二：</td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox20"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox20.ClientID) %>
                    </div>
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">图片三：</td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox21"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox21.ClientID) %>
                    </div>
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">图片四：</td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox22"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox22.ClientID) %>
                    </div>
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">图片五：</td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="TextBox23"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(TextBox23.ClientID) %>
                    </div>
                </td>           
            </tr>

            <tr>
                <td style="text-align:right;">原价：</td>
                <td><asp:TextBox ID="TextBox10" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">现价：</td>
                <td><asp:TextBox ID="TextBox11" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">销量：</td>
                <td><asp:TextBox ID="TextBox12" Text="0" runat="server" CssClass="formTitle yan1"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">红包：</td>
                <td><asp:TextBox ID="TextBox17" Text="0" runat="server" CssClass="formTitle yan1"></asp:TextBox>
                    (这里设置红包能抵用多少钱)
                </td>           
            </tr>
            <tr class='dis'>
                <td style="text-align:right;">增加分销：</td>
                <td><asp:TextBox ID="TextBox18" Text="0" runat="server" CssClass="formTitle yan1"></asp:TextBox> 人</td>           
            </tr>
            <tr>
                <td style="text-align:right;">货号：</td>
                <td><asp:TextBox ID="TextBox19" Width="200px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>

            </asp:Panel>

            <asp:Panel ID="Panel10" runat="server" Visible="false">
                <tr>
                    <td style="text-align:right;">是否上架：</td>
                    <td>
                        <asp:RadioButtonList ID="ifsj" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>           
                </tr>
                <tr>
                    <td style="text-align:right;">省级售价：</td>
                    <td><asp:TextBox ID="price_sheng" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">市级售价：</td>
                    <td><asp:TextBox ID="price_shi" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">县级售价：</td>
                    <td><asp:TextBox ID="price_xian" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">大V售价：</td>
                    <td><asp:TextBox ID="price_dv" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">利润：</td>
                    <td>
                        <script>
                            $(function () {
                                $("#<%=lirun.ClientID%>").blur(function () {
                                    var lirun = $("#<%=lirun.ClientID%>").val();

                                    var fh_sheng = $("#<%=fh_sheng.ClientID%>");
                                    var fh_shi = $("#<%=fh_shi.ClientID%>");
                                    var fh_xian = $("#<%=fh_xian.ClientID%>");
                                    var fh_one = $("#<%=fh_one.ClientID%>");
                                    var fh_two = $("#<%=fh_two.ClientID%>");
                                    var fh_three = $("#<%=fh_three.ClientID%>");

                                    fh_sheng.val(ForDight((lirun) * 0.01));
                                    fh_shi.val(ForDight((lirun) * 0.02));
                                    fh_xian.val(ForDight((lirun) * 0.03));
                                    fh_one.val(ForDight((lirun) * 0.30));
                                    fh_two.val(ForDight((lirun) * 0.05));
                                    fh_three.val(ForDight((lirun) * 0.05));
                                });
                            });
                            function ForDight(x) {
                                var f = parseFloat(x);
                                if (isNaN(f)) {
                                    return false;
                                }
                                var f = Math.round(x * 100) / 100;
                                var s = f.toString();
                                var rs = s.indexOf('.');
                                if (rs < 0) {
                                    rs = s.length;
                                    s += '.';
                                }
                                while (s.length <= rs + 2) {
                                    s += '0';
                                }
                                return s;
                            }
                        </script>
                        <asp:TextBox ID="lirun" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox>
                    </td>           
                </tr>
                <tr>
                    <td style="text-align:right;">省级分红：</td>
                    <td><asp:TextBox ID="fh_sheng" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">市级分红：</td>
                    <td><asp:TextBox ID="fh_shi" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">县级分红：</td>
                    <td><asp:TextBox ID="fh_xian" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr class="dis">
                    <td style="text-align:right;">大V分红：</td>
                    <td><asp:TextBox ID="fh_dv" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">一级分红：</td>
                    <td><asp:TextBox ID="fh_one" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">二级分红：</td>
                    <td><asp:TextBox ID="fh_two" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
                <tr>
                    <td style="text-align:right;">三级分红：</td>
                    <td><asp:TextBox ID="fh_three" Text="0" runat="server" CssClass="formTitle yan2"></asp:TextBox></td>           
                </tr>
            </asp:Panel>

            <asp:Panel ID="Panel7" runat="server" Visible="false">
            <tr>
                <td style="text-align:right;">我喜欢：</td>
                <td><asp:TextBox ID="TextBox15" Text="0" runat="server" CssClass="formTitle yan1"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">我不喜欢：</td>
                <td><asp:TextBox ID="TextBox16" Text="0" runat="server" CssClass="formTitle yan1"></asp:TextBox></td>           
            </tr>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" Visible="false">
                
            <tr>
                <td style="text-align:right;">颜色：</td>
                <td><asp:TextBox ID="TextBox13" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                    (多个颜色请用,号隔开 比如：红色,蓝色)
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">尺码：</td>
                <td><asp:TextBox ID="TextBox14" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                    (多个尺寸请用,号隔开 比如：M,XL)
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注十六：</td>
                <td><asp:TextBox ID="TextBox25" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注十七：</td>
                <td><asp:TextBox ID="TextBox26" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注十八：</td>
                <td><asp:TextBox ID="TextBox27" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注十九：</td>
                <td><asp:TextBox ID="TextBox28" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十：</td>
                <td><asp:TextBox ID="TextBox29" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十一：</td>
                <td><asp:TextBox ID="TextBox30" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十二：</td>
                <td><asp:TextBox ID="TextBox31" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十三：</td>
                <td><asp:TextBox ID="TextBox32" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十四：</td>
                <td><asp:TextBox ID="TextBox33" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十五：</td>
                <td><asp:TextBox ID="TextBox34" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十六：</td>
                <td><asp:TextBox ID="TextBox35" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十七：</td>
                <td><asp:TextBox ID="TextBox36" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十八：</td>
                <td><asp:TextBox ID="TextBox37" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注二十九：</td>
                <td><asp:TextBox ID="TextBox38" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            <tr>
                <td style="text-align:right;">备注三十：</td>
                <td><asp:TextBox ID="TextBox39" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox></td>           
            </tr>
            
            </asp:Panel>
            
            <asp:Panel ID="Panel4" runat="server">

            <tr class="dis">
                <td style="text-align:right;">
                    页面title：
                </td>
                <td>
                    <asp:TextBox ID="TextBox4"  Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>           
            </tr>
            <tr class="dis">
                <td style="text-align:right;">
                    页面关键字：
                </td>
                <td style="height:70px;">
                    <asp:TextBox ID="TextBox5" TextMode="MultiLine" Width="500px" Height="50px"  runat="server" CssClass="formTitle"></asp:TextBox>
                </td>           
            </tr>
            <tr class="dis">
                <td style="text-align:right;">
                    页面描述：
                </td>
                <td style="height:70px;">
                    <asp:TextBox ID="TextBox6" TextMode="MultiLine" Width="500px" Height="50px"  runat="server" CssClass="formTitle"></asp:TextBox>
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">
                    内容：
                </td>
                <td>
                    <script type="text/javascript">
                        $(function () {
                            var oFCKeditor = new FCKeditor('<%= TextBox7.ClientID %>');
                            oFCKeditor.BasePath = '/L_editor/'
                            oFCKeditor.Height = 450;
                            oFCKeditor.ReplaceTextarea();
                        });
                    </script>
                    <asp:TextBox ID="TextBox7"  Width="100%" Height="250px"   runat="server" CssClass="formTitle" TextMode="MultiLine"></asp:TextBox>
                </td>           
            </tr>
            <tr class="dis">
                <td style="text-align:right;">
                    点击数：
                </td>
                <td style="height:70px;">
                    <asp:TextBox ID="TextBox9" Text="0" runat="server" CssClass="formTitle" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" ></asp:TextBox>
                </td>           
            </tr>
            <tr>
                <td style="text-align:right;">
                    时间：
                </td>
                <td style="height:70px;">
                    <asp:TextBox ID="times" Text="" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>           
            </tr>

            </asp:Panel>

            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="text-align:left;">
                                    <asp:Button ID="Button1" runat="server" Text=" 添加 "  CssClass="formInput01"  UseSubmitBehavior="False"  onclick="Button1_Click"  />

                </td>
            </tr>
            </table>

    </div>
</asp:Panel>
</asp:Content>
