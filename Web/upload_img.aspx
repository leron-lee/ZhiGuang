<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_img.aspx.cs" Inherits="Web.upload_img" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <base target="_self" />
    <script type="text/jscript">
        function foo() {
            window.close();
            var flag = document.getElementById('TextBoxname').value;
            if (window.opener != undefined) {
                window.opener.returnValue = flag;
            } else {
                window.returnValue = flag;
            }
        }
    </script>
</head>
<body>
    <form id="uploadform" runat="server">
    <div style="width:100%;text-align:center;">
        
        <asp:TextBox ID="TextBoxname" Text="" runat="server" style="display:none;"></asp:TextBox>
        <table style="width:455px;height:82px;" cellpadding="1" cellspacing="1">
        <tr>
            <td colspan="2" style="text-align:left;height:20px;color:#0000FF;font-size:12px;font-weight:bold;">
                文件上传：
            </td>
        </tr>
        <tr>
        <td bgcolor="#E8F1FF">
        <asp:FileUpload ID="myFile" runat="server" Width="98%" />
        </td>
        <td bgcolor="#E8F1FF" style="width:45px;text-align:right;">
        <asp:Button ID="Button1" runat="server" Text="上传" onclick="Button1_Click" />
        </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>