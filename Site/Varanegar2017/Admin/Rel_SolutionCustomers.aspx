<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="Rel_SolutionCustomers.aspx.cs" Inherits="Varanegar.Admin.Rel_SolutionCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    <div class="row" style="margin-bottom:5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">
              
          <div class="col-md-9">
              <asp:Label ID="lblsolutionTitle" runat="server" Text="Label"></asp:Label></div>
             <div class="col-md-3"><b> :عنوان راهکار</b></div>
        </div>
          
    </div>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a" />
      <div class="row" style="margin-bottom:5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">
              
          <div class="col-md-9">
              <asp:DropDownList ID="ddlCustomers"  ValidationGroup="a" runat="server" CssClass="form-control"></asp:DropDownList></div>
            <asp:CustomValidator ID="CustomValidator1"  ValidationGroup="a" runat="server" ErrorMessage="مشتری را انتخاب نمایید" Display="None" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
               <div class="col-md-3"><b> مشتری</b></div>
        </div>
          
    </div>
    
      <div class="row" style="margin-bottom:5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">
              
          <div class="col-md-9">

              <asp:Button ID="btnSubmit" CssClass="btn btn-success"  ValidationGroup="a" runat="server" Text="ثبت مشتری" OnClick="btnSubmit_Click" />
        <a href="SolutionSetting.aspx" class="btn btn-warning">بازگشت</a>
              
              
                </div>
             <div class="col-md-3"></div>
        </div>
          
    </div>
    <asp:Panel ID="pnlDelete" runat="server" Visible="false" CssClass="alert alert-danger">
        آیا از حذف <b>
            <asp:Label ID="lblDelete" runat="server" Text="Label"></asp:Label>
                   </b>
        اطمینان دارید؟
        <br />
        <br />
        <asp:Button ID="btnYes" runat="server" Text="بلی" CssClass="btn btn-success" OnClick="btnYes_Click" />
        <asp:Button ID="btnNo" runat="server" Text="خیر"  CssClass="btn btn-danger" OnClick="btnNo_Click" />
    </asp:Panel>
      <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                <p class="alert alert-success">اطلاعات با موفقیت ثبت گردید.</p>
            </asp:Panel>
    <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
        <p class="alert alert-danger">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
    </asp:Panel>



    <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%"
         AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>

            <asp:BoundField DataField="CustomerTitle" HeaderText="عنوان" />

            <asp:BoundField DataField="CustomerName" HeaderText="عنوان سیستمی" />
        

            <asp:TemplateField HeaderText="تصویر">
                <ItemTemplate>
                    <img src='<%# Eval("ImgLogo","/Uploads/Customers/{0}") %>' height="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="توضیحات">
                <ItemTemplate>

                  
                    <i class="fa fa-times"></i>
                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("SolutionCustomerID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>

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
