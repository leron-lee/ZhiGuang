<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dzmd_l.aspx.cs" Inherits="Web.admin.fh.dzmd_l" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <title></title>
    <style>
        body { font-size: 14px; line-height: 18px; font-family: 宋体; }
    </style>
    <script language="VBScript">
        dim hkey_root,hkey_path,hkey_key
        hkey_root="HKEY_CURRENT_USER"
        hkey_path="\Software\Microsoft\Internet Explorer\PageSetup"
        '//设置网页打印的页眉页脚为空
        function pagesetup_null()
        on error resume next
        Set RegWsh = CreateObject("WScript.Shell")
        hkey_key="\header" 
        RegWsh.RegWrite hkey_root+hkey_path+hkey_key,""
        hkey_key="\footer"
        RegWsh.RegWrite hkey_root+hkey_path+hkey_key,""
        end function
        '//设置网页打印的页眉页脚为默认值
        function pagesetup_default()
        on error resume next
        Set RegWsh = CreateObject("WScript.Shell")
        hkey_key="\header" 
        RegWsh.RegWrite hkey_root+hkey_path+hkey_key,"&w&b页码，&p/&P"
        hkey_key="\footer"
        RegWsh.RegWrite hkey_root+hkey_path+hkey_key,"&u&b&d"
        end function
    </script>
    <script src="/js/jquery-1.7.2.min.js"></script>
    <script>
        var navigatorName = "Microsoft Internet Explorer";
        var isIE = false;
        if (navigator.appName == navigatorName) {
            isIE = true;
        } else {
            alert("请在IE浏览器中操作");
            window.close();
        }
        $(window).load(function () {
            window.print();
        });
    </script>
</head>
<body style="margin:0px;">
    <form id="form1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" style="width:100mm;height:170mm;">
                <tr>
                    <td style="height:15mm;" valign="top">
                        <div style="float:left;margin:10px 0px 0px 60px;width:110px;">
                            <div>
                                <b style="font-size:26px;">标准快件</b>
                            </div>
                            <div style="font-size:12px;">
                                成就商业 精彩生活
                            </div>
                        </div>
                        <div style="float:right;margin:1px 20px 0px 0px;width:45mm;">
                            <div style="position:absolute;width:45mm;">
                                <div>
                                    <img src="<%#new Code128().getimg(Eval("fdan")) %>" style="width:45mm;height:12mm;" />
                                </div>
                                <div style="text-align:center;line-height:6px;">
                                    <%#Eval("fdan") %>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:20mm;" valign="top">
                        <div style="height:20mm;float:left;width:100%;">
                            <div style="padding-left:40px;padding-right:20px;">
                                <div style="padding-top:5px;">
                                    <div style="float:left;">
                                        <%#Eval("name") %>
                                    </div>
                                    <div style="float:right;">
                                        电话：<%#Eval("tel") %>
                                    </div>
                                    <div style="clear:both;"></div>
                                </div>
                                地址：<%#Eval("address") %><br />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:15mm;" valign="top">
                        <div style="height:15mm;float:left;width:100%;">
                            <div style="padding-left:40px;padding-right:20px;">
                                <div style="padding-top:5px;">
                                    <div style="float:left;">
                                        <b><%=sendMan %></b>
                                    </div>
                                    <div style="float:right;">
                                        电话：<%=sendManPhone %>
                                    </div>
                                    <div style="clear:both;"></div>
                                </div>
                                地址：<%=sendProvince %><%=sendCity %><%=sendCounty %><%=sendManAddress %><br />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:15mm;">
                        <div style="padding-left:40px;">
                            <b style="font-size:27pt;font-family:黑体;">
                                <%#Eval("markDestination") %>
                            </b>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:25mm;" valign="top">
                        <div style="height:25mm;float:left;width:100%;">
                            <div style="float:left;margin:10px 0px 0px 40px;width:15mm;">
                                <img src="<%#ewm.create_two(Eval("fdan").ToString()) %>" style="width:15mm;height:15mm;" />
                                <%--<img src="http://qr.liantu.com/api.php?w=300&text=<%#Eval("fdan") %>" style="width:15mm;height:15mm;" />--%>
                            </div>
                            <div style="float:left;margin:10px 0px 0px 40px;">
                                <b style="font-size:18px;">
                                    收件人签字
                                </b>
                            </div>
                            <div style="float:right;margin:10px 60px 0px 0px;">
                                始发：
                                <br />
                                送达：
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:15mm;" valign="top">
                        <div style="height:15mm;float:left;width:100%;">
                            <div style="float:left;width:45mm;margin:2px 0px 0px 30px;">
                                <div style="width:45mm;position:absolute;">
                                    <div>
                                        <img src="<%#new Code128().getimg(Eval("fdan")) %>" style="width:45mm;height:12mm;" />
                                    </div>
                                    <div style="text-align:center;line-height:6px;">
                                        <%#Eval("fdan") %>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:15mm;" valign="top">
                        <div style="height:15mm;float:left;width:100%;">
                            <div style="padding-left:60px;padding-top:5px;">
                                <div style="float:left;">
                                    <%#Eval("name") %>
                                </div>
                                <div style="float:right;margin-right:40px;">
                                    电话：<%#Eval("tel") %>
                                </div>
                                <div style="clear:both;"></div>
                            </div>
                            <div style="padding-left:20px;padding-right:20px;">
                                地址：<%#Eval("address") %><br />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:15mm;" valign="top">
                        <div style="height:15mm;float:left;width:100%;">
                            <div style="padding-left:60px;padding-top:5px;">
                                <div style="float:left;">
                                    <%=sendMan %>
                                </div>
                                <div style="float:right;margin-right:40px;">
                                    电话：<%=sendManPhone %>
                                </div>
                                <div style="clear:both;"></div>
                            </div>
                            <div style="padding-left:20px;padding-right:20px;">
                                地址：<%=sendProvince %><%=sendCity %><%=sendCounty %><%=sendManAddress %><br />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:35mm;" valign="top">
                        <div style="height:35mm;float:left;width:100%;">
                            <div style="padding:10px 20px 0px 20px;">
                                <%#bz() %>
                                <div style="clear:both;"></div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
