<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="file_insert.aspx.cs" Inherits="Web.admin.file.file_insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var io = true;
    function selthis(sfd) {
        if (io) {
            sfd.select();
            io = false;
        } else {
            io = true;
        }
    }

</script>
<link href="../css/dntmanager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">



<ul class="navLocation"><li><strong>图片/文件上传</strong></li></ul>



        <div class="infoBox">

               
                <table width="100%" class="table898">
                <tr>
                    <td>
                        图片或者文件名:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" MaxLength="20"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td>上传文件:</td>
                <td>
                    <asp:FileUpload ID="myFile" runat="server" />
                </td>
                </tr>
                <tr>
                <td></td>
                <td>
                <asp:Button ID="Button1" runat="server" Text=" 上传 "  CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click" />
                </td></tr></table>

        </div>

        <div class="b_l" style="width:99%;margin-left:5px;">

        <div class="ManagerForm">
            <script>
                function s(str) {
                    if (confirm('确认要删除吗？')) {
                        location.href = "file_insert.aspx?del=" + str;
                    }
                }
                function cball(cb) {
                    var ck = document.getElementsByTagName("input");
                    for (var i = 0; i < ck.length; i++) {
                        if (ck[i].type == "checkbox") {
                            ck[i].checked = cb.checked;
                        }
                    }
                }
            </script>
            <fieldset>
            <legend style="background:url(../images/icons/icon47.jpg) no-repeat 6px 50%;">图片/文件列表</legend>
            
            <div class="b_l_w" style="padding:5px 0px 5px 0px;">
            <div class="b_r">
                <input onclick="cball(this)" type="checkbox" />全选/反选 <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">批量删除</asp:LinkButton>
            </div>
            </div>
            
                <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                <div style="float:left;width:120px;">
                    <p><%#imgstr(Eval("fileurl"))%></p>
                    <p><div style="overflow:hidden;height:20px;"><%#Eval("filename") %></div></p>
                    <p><input style="border:1px double #ccc; width:100px;" onclick="selthis(this)" type="text" value='<%#Eval("fileurl") %>' /></p>
                    <p><a href="javascript:s(<%#Eval("id") %>);">删除</a></p>
                    <p><input name="Item" type="checkbox" value='<%#Eval("id")%>' /></p>
                    <p>&nbsp;</p>
                </div>
                </ItemTemplate>
                </asp:Repeater>
            </fieldset>
        </div>

        </div>

</asp:Content>
