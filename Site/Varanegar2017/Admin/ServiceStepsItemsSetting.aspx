<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="ServiceStepsItemsSetting.aspx.cs" Inherits="Varanegar.Admin.ServiceStepsItemsSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row" style="margin-bottom: 5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">

            <div class="col-md-9">
                <asp:Label ID="lblserviceTitle" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="col-md-3"><b>:عنوان سرویس</b></div>
        </div>

    </div>

    <div class="row" style="margin-bottom: 5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">

            <div class="col-md-9">
                <asp:Label ID="lblStepTitle" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="col-md-3"><b>:عنوان مرحله</b></div>
        </div>

    </div>


    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a" CssClass="alert alert-danger" />
   
     <div class="row" style="margin-bottom: 5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">
            <div class="col-md-9">
                <asp:TextBox ID="txtPrio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-3"><b>ردیف</b></div>
        </div>

    </div>
     <div class="row" style="margin-bottom: 5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">
            <div class="col-md-9">
                <asp:TextBox ID="txtItem" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ControlToValidate="txtItem" ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ErrorMessage="عنوان آیتم را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
            <div class="col-md-3"><b>عنوان آیتم</b></div>
        </div>

    </div>
        <div class="row" style="margin-bottom: 5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">
            <div class="col-md-9">
                <asp:TextBox ID="txtItemEn" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="a" runat="server" ErrorMessage="عنوان انگلیسی آیتم را وارد نمایید" Display="None" ControlToValidate="txtItemEn">*</asp:RequiredFieldValidator>
            <div class="col-md-3"><b>عنوان انگلیسی آیتم</b></div>
        </div>

    </div>
    <div class="row" style="margin-bottom: 5px;">
        <div class="col-md-6"></div>
        <div class="col-md-6">

            <div class="col-md-9">

                <asp:Button ID="btnSubmit" CssClass="btn btn-success" ValidationGroup="a" runat="server" Text="ثبت تغییرات" OnClick="btnSubmit_Click" />
            
                <asp:Button ID="btnBack" CssClass="btn btn-warning" runat="server" Text="بازگشت" OnClick="btnBack_Click" />


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
        <asp:Button ID="btnNo" runat="server" Text="خیر" CssClass="btn btn-danger" OnClick="btnNo_Click" />
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
            
            <asp:BoundField DataField="Priority" HeaderText="ردیف" />

            <asp:BoundField DataField="ServiceStepItemTitle" HeaderText="عنوان" />

            
            <asp:BoundField DataField="En_ServiceStepItemTitle" HeaderText="عنوان انگلیسی" />


            <asp:TemplateField HeaderText="توضیحات">
                <ItemTemplate>


                    <i class="fa fa-times"></i>
                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("ServiceStepItemID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>

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
