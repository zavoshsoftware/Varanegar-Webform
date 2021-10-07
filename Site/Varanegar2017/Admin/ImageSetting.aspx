<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="ImageSetting.aspx.cs" Inherits="Varanegar.Admin.ImageSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSuccess" CssClass="alert alert-success" Visible="false" runat="server">
        اطلاعات با موفقیت تغییر یافت.
    </asp:Panel>
    <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <br />
            <br />
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="grdTable_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Priority" HeaderText="ردیف" />

                    <asp:BoundField DataField="ImageTitle" HeaderText="عنوان" />
                   
                    <asp:TemplateField HeaderText="تصویر">
                        <ItemTemplate>
                            <asp:Image ID="Image1" Height="150px" runat="server" ImageUrl='<%# Eval("ImgUrlAddress","~/uploads/Images/{0}") %>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:CheckBoxField DataField="IsActive" HeaderText="فعال؟" />
                    <asp:TemplateField HeaderText="تنظیمات">
                        <ItemTemplate>
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="DoEdit" CommandArgument='<%# Eval("ImageID") %>'>ویرایش</asp:LinkButton>
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


            <div class="ad-div">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
                <table>
                    <tr>
                        <td>ردیف</td>
                        <td>
                            <asp:TextBox ID="txtPrio" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="none"
                                ErrorMessage="مقدار عددی وارد نمایید" ControlToValidate="txtPrio" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrio" ForeColor="Red" ErrorMessage="ردیف را وارد نمایید.">*</asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>عنوان</td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="عنوان را وارد نمایید.">*</asp:RequiredFieldValidator>
                            <dfn>عنوان تصویر در وب سایت نمایش داده نمی شود و به عنوان alt از آن استفاده می گردد</dfn>
                        </td>
                    </tr>


                    <tr>
                        <td>تصویر</td>
                        <td>
                            <asp:FileUpload ID="fuImage" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td>فعال می باشد؟</td>
                        <td>
                            <asp:CheckBox ID="chkActive" runat="server" />
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
