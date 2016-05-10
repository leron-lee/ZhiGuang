<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.Master" AutoEventWireup="true" CodeBehind="flash.aspx.cs" Inherits="Web.admin.cjh.flash" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
    <div class="infoBox">
        <table width="100%" class="table898" cellpadding="0" cellspacing="0">
            <tr>
                <td style="text-align:right;">
                    标题：
                </td>
                <td>
                    <asp:TextBox ID="name" Width="500px" runat="server" CssClass="formTitle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;">
                    图片：
                </td>
                <td>
                    <div class="b_l">
                        <asp:TextBox ID="img"  runat="server" CssClass="formTitle"></asp:TextBox>
                    </div>
                    <div class="b_l" style="margin:2px 0px 0px 5px;">
                        <%=get.upload(img.ClientID) %>
                    </div>
                    <div class="b_l" style="margin:7px 0px 0px 5px;">
                        支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
                    </div>
                </td>
            </tr>
            
            <tr>
                <td style="text-align:right;">
                    链接：
                </td>
                <td>
                    <asp:TextBox ID="href" Width="500px" runat="server" CssClass="formTitle" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td style="text-align:left;">
                    <asp:Button ID="Button1" runat="server" Text="" CssClass="formInput01" UseSubmitBehavior="False"  onclick="Button1_Click"  />
                </td>
            </tr>
            
        </table>
    </div>
</asp:Panel>



    <div style="float:left;display:inline;width:100%;margin-top:3px;">
     <table id="talbe110" class="tabBox" width="100%" cellpadding="0" cellspacing="0">
        <tr class="tabTitleMain">
            <th style="width:20%">
                图片名称
            </th>
            <th style="width:40%">
                图片信息
            </th>
            <th style="width:20%">
                添加时间
            </th>
            <th style="width:20%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Rp_OnItemCommand">
        <ItemTemplate>
          <tr class="tabTextMain" onmouseout="this.style.background='#FFFFFF';" onmouseover="this.style.background='#F4F7FA';">
            <td>
                <div style="height:20px;overflow:hidden;"><%#Eval("name")%></div>
            </td>
            <td>
              <img  width="260" src="<%#Eval("img")%>"/>
            </td>
            <td>
                <%#Eval("times")%>
            </td>
            <td>
            <asp:LinkButton ID="LinkButton2" CommandName="xia" CommandArgument='<%#Eval("id") %>' runat="server" CausesValidation="False">上移</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" CommandName="shang" CommandArgument='<%#Eval("id") %>' runat="server" CausesValidation="False">下移</asp:LinkButton>
            <a href='flash.aspx?id=<%#Eval("id") %>'>编辑</a>
            <asp:LinkButton ID="LinkButton1" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('确定删除吗！')" runat="server" CausesValidation="False">删除</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="float:left;width:100%;"><div style="float:right;display:inline;margin-right:25px;">
        <asp:Literal ID="Literal1" runat="server" EnableViewState="false"></asp:Literal></div></div>
</div>
</asp:Content>
