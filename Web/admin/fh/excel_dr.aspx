<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="excel_dr.aspx.cs" Inherits="Web.admin.fh.excel_dr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

     <ul class="navLocation"><li><strong>电子面单发货</strong></li></ul>
    <div class="b_l_w">
        <div style="padding:10px;">
           
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;导入文件：
                        </td>
                        <td>
                           

                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="formTitle" />
                        </td>
                        
                    </tr>
                </table>
            </div>
            
            <div class="b_l_w" style="margin-top:5px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;　　　　　
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="fhdz_bt" runat="server" Text="提交修改" CssClass="formInput01" OnClick="fhdz_bt_Click" UseSubmitBehavior="false" ></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
           
            <div class="clear"></div>
        </div>
    </div>

</asp:Content>
