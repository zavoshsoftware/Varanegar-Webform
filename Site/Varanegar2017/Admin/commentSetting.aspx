<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="commentSetting.aspx.cs" Inherits="Varanegar.Admin.commentSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlCheck" CssClass="alert alert-info" runat="server" Visible="false">
        آیا مطمئن به تایید نظر می باشید
          <br />
        <br />
        <asp:TextBox ID="txtComment" CssClass="form-control" Width="400px" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnYes" runat="server" Text="بلی" CssClass="btn btn-success" OnClick="btnYes_Click" />
        <asp:Button ID="btnNo" runat="server" Text="خیر" CssClass="btn btn-danger" OnClick="btnNo_Click" />
    </asp:Panel>
      <asp:Panel ID="pnlDelete" CssClass="alert alert-danger" runat="server" Visible="false">
     
      آیا مایل به حذف
               
            هستید؟
                <br />
            <asp:Button ID="btnAgree" runat="server" Text="بلی" OnClick="btnAgree_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnDeny" runat="server" Text="خیر" OnClick="btnDeny_Click" CssClass="btn btn-warning" />
      </asp:Panel>
    <asp:Panel ID="pnlEmptyForm" CssClass="alert alert-danger" runat="server" Visible="false">
        <p>اطلاعاتی جهت نمایش موجود نمی باشد.</p>
    </asp:Panel>
    <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdProductGroup_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="CommentDate" HeaderText="تاریخ ثبت" />
            <asp:CheckBoxField DataField="IsValid" HeaderText="تایید؟" />
            <asp:BoundField DataField="Name" HeaderText="نام کاربر" />
            <asp:BoundField DataField="Email" HeaderText="ایمیل" />

            <asp:BoundField DataField="BlogTitle" HeaderText="عنوان وبلاگ" />

            <asp:TemplateField HeaderText="تنظیمات">
                <ItemTemplate>
                    <i class="fa fa-edit"></i>
                    <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="DoEdit" CssClass="lb">تایید نظر</asp:LinkButton>
                    <br />
                    <%--    <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbPages" runat="server" CommandArgument='<%# Eval("ProductGroupID") %>' CommandName="ShowProducts" CssClass="lb">مشاهده زیر گروه محصولات</asp:LinkButton>
                            <br />--%>
                    <i class="fa fa-times"></i>
                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>

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
</asp:Content>
