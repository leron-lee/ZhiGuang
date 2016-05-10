<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />
            <meta http-equiv="X-UA-Compatible" content="IE=8" />
            <title></title>
            <script src="/js/jquery-1.3.2.js" type="text/javascript"></script>
		    <link rel="stylesheet" href="css/bootstrap.min.css" />
		    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" />
            <link rel="stylesheet" href="css/matrix-login.css" />
            <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />

            <script>
                function showimg() {
                    var sw = $("#vcodeimg").show();
                    $("#vcodeimg").attr("src", "/Image.aspx?" + Math.random());
                }
            </script>
</head>
<body>
    
<!--[if IE 6]>
<div class="b_l_w" style="background-color:#FFFF9B;padding:10px 0px 10px 0px;text-align:center;font-size:14px;color:#E27839;">
您使用的浏览器版本过低，无法正常浏览使用后台，请升级到： <a href="http://windows.microsoft.com/zh-cn/internet-explorer/ie-8-worldwide-languages" target="_blank" style="color:#0088CC;">Internet Explorer 8</a> 或 <a href="http://www.google.com/chrome" target="_blank" style="color:#0088CC;">Google Chrome</a> 或 360浏览器和搜狗浏览器的高速模式
</div>
<![endif]-->

    <div id="loginbox" style="width:455px;"> 

    <form id="Login" runat="server" class="form-vertical" >
    <asp:Panel ID="Panel1" runat="server" DefaultButton="login_sub">
           
				 <div class="control-group normal_text"> <h3><img src="images/bg/logo.png" alt="Logo" /></h3>
				 </div>
                <div class="control-group">
                    <div class="controls">
                        <div class="main_input_box">
                            <span class="add-on bg_lg"><i class="icon-user"></i></span><input name="s1" type="text" placeholder="账号" style="width:312px;" />
                        </div>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <div class="main_input_box">
                            <span class="add-on bg_ly"><i class="icon-lock"></i></span><input name="s2" type="password" placeholder="密码" style="width:312px;" />
                        </div>
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <div class="main_input_box">
                            <span class="add-on bg_lh"><i class="icon-tags"></i></span><input name="s3" type="text" placeholder="验证码" style="width:191px;" onfocus="showimg()" />
                            <img id="vcodeimg" style="cursor:pointer;position:absolute;margin:0px 0px 0px 5px;" onclick="this.src='/image.aspx?' + Math.random()" title="点击刷新验证码"  src="/image.aspx" />
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <div style="float:left;margin-left:50px;">
                        <asp:Button ID="login_sub" runat="server" Text="登 录" OnClick="Button1_Click" CssClass="btn btn-success"></asp:Button>
                    </div>
                    <div style="float:left;margin-left:50px;">
                        <input type="reset" value="重 置" class="btn btn-success" />
                    </div>
                </div>
        
        <script src="js/matrix.login.js"></script>
    </asp:Panel>
    </form>
</div>
</body>
</html>

