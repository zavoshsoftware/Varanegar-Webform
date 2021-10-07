<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="GalleryGroupSetting.aspx.cs" Inherits="Varanegar.Admin.GalleryGroupSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:MultiView ID="mvSetting" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnAdd" runat="server" Text="افزودن" OnClick="btnAdd_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" OnClick="btnReturn_Click" CssClass="btn btn-warning" CausesValidation="false" />
           
            <br />
            <br />
            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger pnlEmptyForm">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:Panel ID="pnlSuccess" runat="server" Visible="false" CssClass="alert alert-success">
                اطلاعات با موفقیت تغییر یافت.
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server"  AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdProductGroup_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Priority" HeaderText="ردیف" />
                    <asp:BoundField DataField="Title" HeaderText="عنوان" />
                    <asp:TemplateField HeaderText="تنظیمات">
                        <ItemTemplate>
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="DoEdit" CssClass="lb">ویرایش</asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="DoDelete" CssClass="lb"> <i class="fa fa-times"></i>حذف</asp:LinkButton>
                           
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
                            <asp:TextBox ID="txtPri" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>عنوان</td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="عنوان را وارد نمایید." ControlToValidate="txtTitle" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                        <td>تصویر</td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />
                                        <dfn>برای نمایش بهتر، تصویری در سایز 750px * 415px انتخاب نمایید</dfn>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgEditImages" runat="server" Height="150px" Width="200px" />

                                    </td>

                                </tr>
                            </table>

                        </td>
                    </tr>
                     
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="ثبت" OnClick="btnSave_Click" CssClass="btn btn-success" />
                            <asp:Button ID="btnCancel" runat="server" Text="بازگشت" OnClick="btnCancel_Click" CssClass="btn btn-warning" CausesValidation="false" />
                        </td>
                    </tr>

                </table>
            </div>
        </asp:View>

        <asp:View ID="vwDelete" runat="server">
           <div class="alert alert-danger">
            آیا مایل به حذف
                <asp:Label ID="lblDelete" runat="server" Text=""></asp:Label>
            هستید؟
                 <br />
            با حذف این گروه، مطالب زیر مجموعه آن نیز حذف می شوند.
                <br />
                <br />
          
            <asp:Button ID="btnAgree" runat="server" Text="بلی" OnClick="btnAgree_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnDeny" runat="server" Text="خیر" OnClick="btnDeny_Click" CssClass="btn btn-warning" />
       </div>

        </asp:View>



    </asp:MultiView>
</asp:Content>
