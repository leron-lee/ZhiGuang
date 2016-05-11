
<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="merchandise.aspx.cs" Inherits="Web.admin.Merchandise.merchandise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--商品编辑页面-->
<script type="text/javascript">
    function getCookie(c_name) {
        if (document.cookie.length > 0) {
            c_start = document.cookie.indexOf(c_name + "=")
            if (c_start != -1) {
                c_start = c_start + c_name.length + 1
                c_end = document.cookie.indexOf(";", c_start)
                if (c_end == -1) c_end = document.cookie.length
                return unescape(document.cookie.substring(c_start, c_end))
            }
        }
        return "";
    }
    function cball(cb) {
        var ck = document.getElementsByTagName("input");
        for (var i = 0; i < ck.length; i++) {
            if (ck[i].type == "checkbox") {
                ck[i].checked = cb.checked;
            }
        }
    }
    function show() {
        var hf = "Merchandise_insert.aspx?typeid=";
        var vl = $("#<%=DropDownList1.ClientID%>").val();
        if (getCookie("fx") != "") {
            location.href = hf + "7";
        }
        else {
            if (vl == "0") {
                alert("请选择栏目");
            } else {
                location.href = hf + vl;
            }
        }
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<ul class="navLocation"><li><strong>查看信息</strong></li></ul>

<div style="float:left;display:inline;width:100%;margin-top:10px;">

<div class="b_l">
<asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>&nbsp;&nbsp;名称：</td>
        <td>&nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="formTitle l20"></asp:TextBox></td>
        <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" 
                UseSubmitBehavior="false" onclick="Button1_Click"></asp:Button></td>
    </tr>
</table>
</asp:Panel>
</div>

<div class="b_r" style="margin-right:10px;">
    
    <asp:LinkButton ID="LinkButton6" runat="server" onclick="LinkButton6_Click" CssClass="lan" Visible="false">选中推荐/取消</asp:LinkButton>
    <asp:LinkButton ID="LinkButton_del" runat="server"  OnClientClick="return confirm('确认要删除吗？')" onclick="LinkButton_del_Click" CssClass="hon">选中删除</asp:LinkButton>                             
    <a href="javascript:show();" class="lv">添加新信息</a>
    <asp:DropDownList ID="DropDownList1" runat="server" EnableViewState="false">
    <asp:ListItem Value="0">==显示全部信息==</asp:ListItem>
    </asp:DropDownList>

    <script type="text/javascript">
        function selectUrl() {
            var o = document.getElementById("<%=DropDownList1.ClientID %>")
            var url;
            o.onchange = function () {
                url = o.value;
                if (url != "0") {
                    location.href = "merchandise.aspx?typeid=" + url;
                } else {
                    location.href = "merchandise.aspx";
                }
            }
        }
        selectUrl()
    </script>

</div>

</div>



<div style="float:left;display:inline;width:100%;margin-top:10px;">
    <table id="talbe110" class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th style="width:5%;">
                <input onclick="cball(this)" type="checkbox" />
            </th>
            <th style="width:25%;">
                名称
            </th>
            <th style="width:19%">
                类别
            </th>
            <th style="width:12%">
                缩略图
            </th>
            <th style="width:10%;">
                上架？
            </th>
            <th style="width:18%">
                发布时间
            </th>
            <th style="width:12%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
        <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <input name="Item" type="checkbox" value='<%#Eval("id")%>' />
            </td>
            <td>
                <%#Eval("name")%>
            </td>
            <td style="text-align:left;">
                <%#typename(Eval("type_two_id"))%>
            </td>
            <td style="height:72px;">
                <img <%# get.imgwh(get.ynimg(Eval("x_img").ToString()),102,66)%> />
            </td>
            <td>
                <%#get.ifsj(Eval("ifsj")) %>
            </td>
            <td>
                <%#Eval("times")%>
            </td>
            <td>
                <div>
                    <asp:LinkButton ID="LinkButton3" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">上移</asp:LinkButton>
                    <a href="Merchandise_insert.aspx?id=<%#Eval("id") %>&url=<%=Server.UrlEncode(Request.RawUrl)%>" class="lv">编辑</a>
                    <asp:LinkButton ID="LinkButton4" CommandName="ding" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="lan">置顶</asp:LinkButton>
                </div>
                <div style="padding-top:8px;">
                    <asp:LinkButton ID="LinkButton2" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="huang">下移</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CssClass="hon">删除</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton5" CommandName="di" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="huang">置底</asp:LinkButton>
                </div>
                <div style="padding-top:8px;">
                    <%#types(Eval("id")) %>
                </div>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;display:inline;margin-top:10px;"><div style="float:right;display:inline;margin-right:25px;"><asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>
</asp:Content>

