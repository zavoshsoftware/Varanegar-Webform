<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SuperAdmin/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductSetting.aspx.cs" Inherits="MashadCarpet.Admin.SuperAdmin.ProductSetting" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

 
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<%--    <script src="../js/jquery-2.1.4.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $("#ContentPlaceHolder1_txtTitle").keypress(function ()
            {
                $("#ContentPlaceHolder1_txtName").val($(this).val());
            })});
    </script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                  
                    <asp:BoundField DataField="ProductTitle" HeaderText="عنوان" />
                     <asp:BoundField DataField="En_ProductTitle" HeaderText="عنوان انگلیسی" />

                    <asp:BoundField DataField="ProductName" HeaderText="عنوان سیستمی" />
                    <asp:BoundField DataField="ProductGroupTitle" HeaderText="گروه" />
                    
                   
                      
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>
               
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("ProductID") %>' CommandName="DoEdit" CssClass="lb">ویرایش</asp:LinkButton>
                            <br />
                             <i class="fa fa-remove"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("ProductID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>
                          
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
                            <asp:TextBox ID="txtPrio" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            
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
                        <td>عنوان انگلیسی:
                        </td>
                        <td>
                            <asp:TextBox ID="txtENTitle" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="none"  ErrorMessage="عنوان انگلیسی را وارد نمایید." ControlToValidate="txtENTitle" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr> 

                    <tr>
                        <td>توضیحات کوتاه</td>
                        <td>
                            <asp:TextBox ID="txtSummery" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" Width="300px"></asp:TextBox>
                              </td>
                    </tr>
                    <tr>
                        <td>توضیحات کوتاه انگلیسی</td>
                        <td>
                            <asp:TextBox ID="txtSummery_En" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" Width="300px"></asp:TextBox>
                          </td>
                    </tr>
                    <tr>
                        <td>عنوان سیستمی:
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="none"  runat="server" ErrorMessage="عنوان سیستمی را وارد نمایید." ControlToValidate="txtName" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvName" runat="server" Display="none"  ErrorMessage="عنوان سیستمی معتبر نمی باشد."  ControlToValidate="txtName" ForeColor="Red" OnServerValidate="cvName_ServerValidate">*</asp:CustomValidator>
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
                    </tr>
                    <tr>
                        <td>گروه محصول:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductGroup" runat="server" CssClass="form-control" Width="300px"></asp:DropDownList>

                            <asp:CustomValidator Display="none"  ID="cvProGroup" ForeColor="Red" OnServerValidate="cvProGroup_ServerValidate" runat="server" ErrorMessage="گروه محصول را وارد نمایید">*</asp:CustomValidator>
                        </td>
                    </tr>

                    


                      <tr>
                        <td>توضیحات:
                        </td>
                        <td>
                           
                            
                            <FTB:FreeTextbox id="reDesc" runat="server" ValidateRequestMode="Disabled"/>
                           </td>
                    </tr>

                    <tr>
                        <td>توضیحات انگلیسی:
                        </td>
                        <td>
                            <FTB:FreeTextbox id="reEN_Desc" runat="server" ValidateRequestMode="Disabled"/>
                            
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
