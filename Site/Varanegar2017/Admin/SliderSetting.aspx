<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="SliderSetting.aspx.cs" Inherits="Varanegar.Admin.SliderSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnAdd" runat="server" Text="افزودن" CssClass="btn btn-success" OnClick="btnAdd_Click" />
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" CssClass="btn btn-warning" OnClick="btnReturn_Click" CausesValidation="false" />
     
            <br />
            <br />
            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger pnlEmptyForm">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                     <asp:BoundField DataField="Priority" HeaderText="ردیف" />
                    <asp:BoundField DataField="SliderTitle" HeaderText="عنوان" />
                     <asp:CheckBoxField DataField="IsActive" HeaderText="اسلایدر فعال؟" />
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>
                            
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("SliderImageUrl","~/Uploads/Slider/{0}") %>' Height="100px" />
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>
                            
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("SliderID") %>' CommandName="DoEdit" CssClass="lb">ویرایش</asp:LinkButton>
                            <br />
                            
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("SliderID") %>' CommandName="DoDelete" CssClass="lb"> <i class="fa fa-remove"></i>حذف</asp:LinkButton>
                         
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
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
                

                <table>
                        <tr>
                        <td>ردیف</td>
                        <td>
                            <asp:TextBox ID="txtPrio" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="none" ErrorMessage="ردیف را وارد نمایید." ControlToValidate="txtPrio" ForeColor="Red">*</asp:RequiredFieldValidator>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="none" 
                                       ErrorMessage="مقدار عددی وارد نمایید" ControlToValidate="txtPrio" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>  
                            
                             </td>
                    </tr>
                    <tr>
                        <td>عنوان:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" Display="none" ErrorMessage="عنوان را وارد نمایید." ControlToValidate="txtTitle" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>متن کوچک:
                        </td>
                        <td>
                            <asp:TextBox ID="txtSmallText" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>

                        </td>
                    </tr> 

                    <tr>
                        <td>متن بزرگ</td>
                        <td>
                            <asp:TextBox ID="txtBigText" runat="server" Rows="5" CssClass="form-control" Width="300px"></asp:TextBox>
                              </td>
                    </tr>
                    <tr>
                        <td>عنوان لینک</td>
                        <td>
                            <asp:TextBox ID="txtLinkTitle" runat="server" Rows="5" CssClass="form-control" Width="300px"></asp:TextBox>
                          </td>
                    </tr>
                    <tr>
                        <td>آدرس لینک:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLinkAddress" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                             </td>
                    </tr>
    <tr>
                        <td>تصویر</td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" /></td>
                                    <td>
                                        <asp:Image ID="imgEditImages" runat="server" Height="150px" />

                                    </td>

                                </tr>
                            </table>

                        </td>
                    </tr>        <tr>
                        <td>اسلایدر فعال ؟
                        </td>
                        <td>
                            <asp:CheckBox ID="chbActiveSlider" runat="server" />
                             </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="ثبت" CssClass="btn btn-success" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="vwDelete" runat="server">
            آیا مایل به حذف 
            <b>
            <asp:Label ID="lblDelete" runat="server" Text="Label"></asp:Label></b>
            هستید؟
            <asp:Button ID="btnYes" runat="server" Text="بلی" OnClick="btnYes_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnNo" runat="server" Text="خیر" OnClick="btnNo_Click" CssClass="btn btn-warning" />

        </asp:View>

    </asp:MultiView>
</asp:Content>
