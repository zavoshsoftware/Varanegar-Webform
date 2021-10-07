<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="DemoListSetting.aspx.cs" Inherits="Varanegar.Admin.DemoListSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" CssClass="btn btn-warning" OnClick="btnReturn_Click" CausesValidation="false" />

           
            <asp:Button ID="btnExportToExcell" runat="server" Text="خروجی اکسل" CssClass="btn btn-default" OnClick="btnExportToExcell_Click" CausesValidation="false" />

            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField DataField="Name" HeaderText="نام و نام خانوادگی" />

                    <asp:BoundField DataField="CompanyName" HeaderText="نام سازمان / شرکت" />
                    <asp:BoundField DataField="RegisterDate" HeaderText="تاریخ ثبت" />

                      <asp:BoundField DataField="Title" HeaderText="دریافت کننده" />
                    <asp:BoundField DataField="Mobile" HeaderText="شماره همراه" />


                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>

                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("RequestID") %>' CommandName="DoDetail" CssClass="lb">مشاهده جزییات</asp:LinkButton>
                            <br />
                            <i class="fa fa-times"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("RequestID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>

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
            <div class="FormView">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">درخواست دمو نرم افزار</h3>
                    </div>
                    <div class="panel-body">


                            <div class="form-group col-md-4">
                    <label>نام و نام خانوادگی</label>
                    <asp:Label ID="lblName" runat="server" CssClass="form-control"></asp:Label>

                </div>
                <div class="form-group col-md-4">
                    <label>نام سازمان / شرکت</label>
                    <asp:Label ID="lblCompanyName" runat="server" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>زمینه فعالیت</label>
                    <asp:Label ID="lblField" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>سمت سازمانی</label>
                    <asp:Label ID="lblPost" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>



                <div class="form-group col-md-4">
                    <label>شماره تماس ثابت</label>
                    <asp:Label ID="lblPhone" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>پست الکترونیک</label>
                    <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
    <div class="form-group col-md-4">
                    <label>شماره همراه</label>
                    <asp:Label ID="lblMobile" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>نحوه آشنایی با ورانگر</label>
                    <asp:Label ID="lblFamiliarMethodTitle" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>توضیحات</label>
                    <asp:Label ID="lblDesc" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                    </div>
                </div>
                <asp:Button ID="btnCancel" runat="server" Text="بازگشت" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="false" />

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
