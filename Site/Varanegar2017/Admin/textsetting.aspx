<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="textsetting.aspx.cs" Inherits="Varanegar.Admin.textsetting" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="../js/jquery-2.1.4.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSuccess" CssClass="alert alert-success" Visible="false" runat="server">
        اطلاعات با موفقیت تغییر یافت.
    </asp:Panel>
        <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <br />
            <br />
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdTable_RowCommand" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="ردیف">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TextTitle" HeaderText="عنوان" />
                  
                  
                    <asp:TemplateField HeaderText="تنظیمات">
                        <ItemTemplate>
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="DoEdit" CommandArgument='<%# Eval("TextID") %>'>ویرایش</asp:LinkButton>
                            <br />
                              
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </asp:View>
        <asp:View ID="vwEdit" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <%--  <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
            </telerik:RadStyleSheetManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnableTheming="True">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>--%>
            <div class="ad-div">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
                <table>
                    <tr>
                        <td>عنوان</td>
                        <td>

                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="عنوان را وارد نمایید.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>عنوان انگلیسی</td>
                        <td>
                            <asp:TextBox ID="txtEN_Title" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
    <tr>
            <td>متن</td>
            <td>     
       
   
                <FTB:FreeTextbox id="reDesc" runat="server" ValidateRequestMode="Disabled"/>

              </td>
        </tr>
         <tr>
            <td>متن انگلیسی</td>
            <td>    <FTB:FreeTextbox id="reDescEn" runat="server" ValidateRequestMode="Disabled"/>
            </td>
        </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="ثبت" OnClick="btnSave_Click" CssClass="btn btn-success" />
                            <asp:Button ID="btnCancel" runat="server" Text="انصراف" OnClick="btnCancel_Click" CssClass="btn btn-danger" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
    
    </asp:MultiView>
     
</asp:Content>
