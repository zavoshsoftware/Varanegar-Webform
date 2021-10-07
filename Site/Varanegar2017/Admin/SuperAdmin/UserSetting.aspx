﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SuperAdmin/MainMaster.Master" AutoEventWireup="true" CodeBehind="UserSetting.aspx.cs" Inherits="Varanegar.Admin.SuperAdmin.UserSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
           
            <asp:Button ID="btnAdd" runat="server" Text="افزودن" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnRet" runat="server" Text="بازگشت" OnClick="btnRet_Click" CssClass="btn btn-warning" CausesValidation="false" />
            <br />
            <br />
            <asp:Panel ID="pnlSuccess" runat="server" Visible="false" CssClass="alert alert-success">
                اطلاعات با موفقیت تغییر یافت.

            </asp:Panel>
            <br />
        
            <br />
            <br />
             <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger pnlEmptyForm">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" Width="100%" 
                CellPadding="4" ForeColor="#333333" GridLines="None" 
                OnRowCommand="grdProductGroup_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField DataField="Firstname" HeaderText="نام"></asp:BoundField>
                    <asp:BoundField DataField="LastFamily" HeaderText="نام خانوادگی"></asp:BoundField>
                 
                    <asp:BoundField DataField="RegisterDate" HeaderText="تاریخ ثبت نام" DataFormatString="{0:d}" />
                
                    <asp:TemplateField HeaderText="نقش کاربر">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfRoleID" runat="server" Value='<%# Eval("fk_RoleID") %>' />
                            <asp:Label ID="lblRole" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField DataField="Phone" HeaderText="تلفن" />
                    <asp:BoundField DataField="Mobile" HeaderText="موبایل" />
                    <asp:BoundField DataField="Email" HeaderText="ایمیل" />
                        <asp:BoundField DataField="Password" HeaderText="کلمه عبور" />
                     
                    <asp:TemplateField HeaderText="تنظیمات">
                        <ItemTemplate>
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CssClass="lb" CommandName="DoEdit" CommandArgument='<%# Eval("UserID") %>'>ویرایش</asp:LinkButton>
                            <br />
                            <i class="fa fa-times"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CssClass="lb" CommandName="DoDelete" CommandArgument='<%# Eval("UserID") %>'>حذف</asp:LinkButton><br />



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
                        <td>نام&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator Display="Dynamic" ID="rfvFname" runat="server" ErrorMessage="نام را وارد نمایید." ForeColor="Red" ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>نام خانوادگی</td>
                        <td>
                            <asp:TextBox ID="txtFamily" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام خانوادگی را وارد نمایید." ForeColor="Red" ControlToValidate="txtFamily">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>نقش کاربر</td>
                        <td>
                            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control" Height="40"></asp:DropDownList>
                            <asp:CustomValidator Display="Dynamic" ID="cvRole" runat="server" ErrorMessage="نقش کاربر را وارد نمایید" OnServerValidate="cvRole_ServerValidate" ForeColor="Red">*</asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>ایمیل</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmail" runat="server" ErrorMessage="ایمیل را وارد نمایید." ForeColor="Red" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator Display="Dynamic" ID="cvEmail" runat="server" ErrorMessage="این ایمیل قبلا وارد شده است" OnServerValidate="cvEmail_ServerValidate" ForeColor="Red">*</asp:CustomValidator>

                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ErrorMessage="ایمیل را صحیح وارد نمایید.">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>کلمه عبور</td>
                        <td>

                            <asp:TextBox ID="txtpass" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvPass" runat="server" ErrorMessage="کلمه عبور را وارد نمایید." ForeColor="Red" ControlToValidate="txtpass">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>تلفن</td>
                        <td>

                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                             </td>
                    </tr>
                    <tr>
                        <td>موبایل</td>
                        <td>

                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
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
            آیا مایل به حذف
                <asp:Label ID="lblDelete" runat="server" Text=""></asp:Label>
            هستید؟
                <br />
            <asp:Button ID="btnAgree" runat="server" Text="بلی" OnClick="btnAgree_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnDeny" runat="server" Text="خیر" OnClick="btnDeny_Click" CssClass="btn btn-warning" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
