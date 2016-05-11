<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminFx.aspx.cs" Inherits="Web.AdminFx.AdminFx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <!---->
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link href="css/body.css" rel="stylesheet" />
    <script src="/js/jquery-1.3.2.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="css/uniform.css" />
    <link rel="stylesheet" href="css/select2.css" />
    <link rel="stylesheet" href="css/matrix-style.css" />
    <link rel="stylesheet" href="css/matrix-media.css" />
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script>
        function ifrshw(hr, name) {
            if (hr.indexOf('?') > 0)
            {
                document.getElementById("frmright").src = hr + "&temp=" + Math.random();
            }
            else
            {
                document.getElementById("frmright").src = hr + "?" + Math.random();
            }            
        }
    </script>
    <script src="js/jquery.ui.custom.js"></script>
    <script src="js/jquery.uniform.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/matrix.js"></script>
    <script src="js/matrix.tables.js"></script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">

        <!--Header-part-->
        <div id="header">
            <h1><a href="index.html">&nbsp;</a></h1>
        </div>
        <!--close-Header-part-->

        <!--sidebar-menu-->
        <div id="sidebar">
            <a href="javascript:;" class="visible-phone"><i class="icon icon-home"></i>Dashboard</a>
            <ul>

                <li class="submenu open"><a href="javascript:;"><i class="icon icon-list-alt"></i><span>商品管理 ⅴ</span></a>
                    <ul>
                        <li><a href="javascript:ifrshw('Merchandise/Merchandise.aspx?typeid=7',this);">商品编辑</a></li>

                    </ul>
                </li>

                <li class="submenu open"><a href="javascript:;"><i class="icon icon-eject"></i><span>订单列表 ⅴ</span></a>
                    <ul>
                        <li><a href="javascript:ifrshw('shoporder/shoporder.aspx',this);">订单列表</a></li>
                    </ul>
                </li>

                <li class="submenu open"><a href="javascript:;"><i class="icon icon-dashboard"></i><span>发货管理 ⅴ</span></a>
                    <ul>
                        <li><a href="javascript:ifrshw('fh/sel.aspx',this);">待发货订单列表</a></li>
                        <li><a href="javascript:ifrshw('fh/excel_list.aspx',this);">历史Excel列表</a></li>
                    </ul>
                </li>

                <li class="submenu open"><a href="javascript:;"><i class="icon icon-file-alt"></i><span>财务管理 ⅴ</span></a>
                    <ul>
                        <li><a href="javascript:ifrshw('jilu/sel.aspx',this);">提现记录</a></li>

                    </ul>
                </li>
                                
                <li class="submenu open"><a href="javascript:;"><i class="icon icon-cog"></i><span>系统管理 ⅴ</span></a>
                    <ul>
                        <li><a href="AdminFx.aspx?logout=">退出登录</a></li>
                    </ul>
                </li>

            </ul>
        </div>
        <!--sidebar-menu-->
        <div id="user-nav" style="line-height: 27px; color: #999999;">
            <div class="b_r" style="margin-right: 5px;">
                <a href="/" target="_blank" style="color: #999999;">前台首页</a>
            </div>
            <%=adminstr %>，您好！<%=tit %>！<%=ip %>
        </div>
        <!--main-container-part-->
        <div id="content">
            <!--breadcrumbs-->
            <script>
                $(function () {
                    setInterval("jc()", 1000);

                    var iewidth = document.body.scrollWidth;
                    iewidth = iewidth - 220;
                    $("#user-nav").width(iewidth);
                });
                var dy = 1;
                var h = 0;
                function jc() {
                    if (dy == 1) {
                        h = document.body.clientHeight;
                        dy = 2;
                    }
                    $("#frmright").height(h - 27);
                }
            </script>
            <iframe id="frmright" name="frmright" frameborder="0" scrolling="auto" src="Merchandise/Merchandise.aspx?typeid=7" width="100%" height="100%" style="z-index: 1;"></iframe>
        </div>

    </form>
</body>
</html>
