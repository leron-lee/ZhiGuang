<%@ Page Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="ApplyInfor.aspx.cs" Inherits="Web.fx.ApplyInfor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table898 td {
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <ul class="navLocation">
        <li><strong>申请门店提交信息</strong></li>
    </ul>



    <div class="infoBox">
        <table width="100%" class="table898">
            <tr>
                <td style="text-align: right; width: 200px;">账号：
                </td>
                <td>

                    <asp:Literal ID="UserName" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 200px;">推荐账号：
                </td>
                <td>

                    <asp:Literal ID="tj_UserName" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">姓名：
                </td>
                <td>

                    <asp:Literal ID="TrueName" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">性别：
                </td>
                <td>

                    <asp:Literal ID="Sex" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">年龄：
                </td>
                <td>

                    <asp:Literal ID="Age" runat="server"></asp:Literal>

                </td>
            </tr>
            
            <tr>
                <td style="text-align: right;">联系方式：
                </td>
                <td>

                    <asp:Literal ID="Phone" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">地址：
                </td>
                <td>

                    <asp:Literal ID="Address" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr >
                <td style="text-align: right;">身份证号码：
                </td>
                <td>
                    <asp:Literal ID="IDCard" runat="server" ></asp:Literal>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">申请时间：
                </td>

                <td>

                    <asp:Literal ID="InsertTime" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;">审核状态：
                </td>

                <td>

                    <asp:Literal ID="Status" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <a href="javascript:window.history.back();">返回</a>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

