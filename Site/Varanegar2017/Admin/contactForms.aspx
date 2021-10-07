<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="contactForms.aspx.cs" Inherits="Varanegar.Admin.contactForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" CssClass="btn btn-warning" OnClick="btnReturn_Click" CausesValidation="false" />

            <br />
            <br />
            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger pnlEmptyForm">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="CommentDate" HeaderText="تاریخ ثبت" />
                    <asp:BoundField DataField="Name" HeaderText="نام" />
                    <asp:BoundField DataField="Mobile" HeaderText="موبایل" />
                    <asp:BoundField DataField="Email" HeaderText="ایمیل" />
                    <asp:BoundField DataField="Title" HeaderText="دریافت کننده" />
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate> 
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("contactid") %>' CommandName="DoEdit" CssClass="lb">مشاهده پیغام</asp:LinkButton>
                            <br />
                            <i class="fa fa-times"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("contactid") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>
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
                        <td>تاریخ ثبت</td>
                        <td>
                            <asp:Label ID="lblSubmitDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>نام:
                        </td>
                        <td>
                             <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                      </td>
                    </tr>

                    <tr>
                        <td>ایمیل:
                        </td>
                        <td>
                             <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                          <tr>
                        <td>موبایل:
                        </td>
                        <td>
                             <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>دریافت کننده:
                        </td>
                        <td>
                             <asp:Label ID="lblReciever" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>متن پیغام:
                        </td>
                        <td>
                             <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                           
                            <asp:Button ID="btnCancel" runat="server" Text="بازگشت" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="vwDelete" runat="server">
            آیا مایل به حذف 
            <asp:Label ID="lblDelete" runat="server" Text="Label"></asp:Label>
            هستید؟
            <asp:Button ID="btnYes" runat="server" Text="بلی" OnClick="btnYes_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnNo" runat="server" Text="خیر" OnClick="btnNo_Click" CssClass="btn btn-warning" />

        </asp:View>

    </asp:MultiView>
</asp:Content>
