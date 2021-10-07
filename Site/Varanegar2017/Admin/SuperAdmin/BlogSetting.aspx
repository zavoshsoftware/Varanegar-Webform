<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SuperAdmin/MainMaster.Master" AutoEventWireup="true" CodeBehind="BlogSetting.aspx.cs" Inherits="Varanegar.Admin.SuperAdmin.BlogSetting" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery-2.1.4.js"></script>
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
           <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdProductGroup_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Priority" HeaderText="ردیف" />                    
                    <asp:BoundField DataField="BlogTitle" HeaderText="عنوان" />
                    
                    <asp:BoundField DataField="BlogName" HeaderText="عنوان سیستمی" />
                    <asp:BoundField DataField="Visit" HeaderText="تعداد بازدید" />
                 
                    <asp:TemplateField HeaderText="تنظیمات">
                        <ItemTemplate>
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("BlogID") %>' CommandName="DoEdit" CssClass="lb">ویرایش</asp:LinkButton>
                              <br /> 
                            <i class="fa fa-times"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("BlogID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>
                            <br />
                               <i class="fa fa-sitemap"></i>
                            <a href='<%# Eval("BlogID","commentSetting.aspx?ID={0}") %>'>مشاهده نظرات</a>
 
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
          <cc1:JQLoader ID="JQLoader1" runat="server">
                            </cc1:JQLoader>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   
            <div class="ad-div">

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
                <table>
                     <tr>
                        <td>ردیف</td>
                        <td>
                            <asp:TextBox ID="txtPrio" runat="server" CssClass="form-control"  Width="300px"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" 
                                       ErrorMessage="مقدار عددی وارد نمایید" ControlToValidate="txtPrio" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>  
                            
                             </td>
                    </tr>
                    
                    <tr>
                        <td>عنوان</td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                                     <dfn>
                                جهت نمایش بهتر مطالب، طول عنوان نباید بیشتر از 49 کاراکتر باشد
                            </dfn>
                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="عنوان را وارد نمایید." ControlToValidate="txtTitle" ForeColor="Red">*</asp:RequiredFieldValidator>
<%--                   <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtTitle" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{0,49}$" runat="server" ErrorMessage="جهت نمایش بهتر مطالب، طول عنوان نباید بیشتر از 49 کاراکتر باشد" ForeColor="Red">*</asp:RegularExpressionValidator>--%>
                                 </td>
                    </tr>
                    <tr>
                        <td>عنوان انگلیسی</td>
                        <td>
                            <asp:TextBox ID="txtEN_Title" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="عنوان انگلیسی را وارد نمایید." ControlToValidate="txtEN_Title" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  <tr>
                        <td>گروه:
                        </td>
                        <td>
                              <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" Width="300px"></asp:DropDownList>

                            <asp:CustomValidator Display="none"  ID="cvProGroup" ForeColor="Red" OnServerValidate="cvProGroup_ServerValidate" runat="server" ErrorMessage="گروه محصول را وارد نمایید">*</asp:CustomValidator>
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
                                        <asp:Image ID="imgEditImages" runat="server" Height="150px" />

                                    </td>

                                </tr>
                            </table>

                        </td>
                    </tr>
                     

                    <tr>
                        <td>نام سیستمی</td>
                        <td>

                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام سیستمی را وارد نمایید." ControlToValidate="txtName" ForeColor="Red">*</asp:RequiredFieldValidator>

                            <asp:CustomValidator ID="cvName" runat="server" ErrorMessage="عنوان سیستمی معتبر نمی باشد. عنوان سیستمی نباید تکراری باشد" Display="Dynamic" ControlToValidate="txtName" ForeColor="Red" OnServerValidate="cvName_ServerValidate">*</asp:CustomValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>متن کوتاه</td>
                        <td>
                            <asp:TextBox ID="txtSummery" lang='fa'  runat="server" Rows="5" CssClass="form-control" Width="300px" TextMode="MultiLine"></asp:TextBox>
                            <dfn>
                                جهت نمایش بهتر مطالب، طول متن کوتاه نباید بیشتر از 130 کاراکتر باشد
                            </dfn>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="متن کوتاه را وارد نمایید." ControlToValidate="txtSummery" ForeColor="Red">*</asp:RequiredFieldValidator>
<%--                               <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtSummery" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{0,130}$" runat="server" ErrorMessage="جهت نمایش بهتر مطالب، طول متن کوتاه نباید بیشتر از 130 کاراکتر باشد" ForeColor="Red">*</asp:RegularExpressionValidator>--%>
            
                        </td>
                    </tr>
                    <tr>
                        <td>متن کوتاه انگلیسی</td>
                        <td>
                            <asp:TextBox ID="txtSummery_En" runat="server" CssClass="form-control" Width="300px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="متن کوتاه انگلیسی را وارد نمایید." ControlToValidate="txtEN_Title" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>متن وبلاگ</td>
                        <td>
                       
                            
                            <FTB:FreeTextbox id="reDesc2" runat="server" ValidateRequestMode="Disabled"/>
                        </td>
                    </tr>
                     <tr>
                        <td>متن وبلاگ انگیسی</td>
                        <td>
                           
                            <FTB:FreeTextbox id="reEN_Desc2" runat="server" ValidateRequestMode="Disabled"/>    
                        </td>
                    </tr>
             <tr>
                        <td>تاریخ ثبت</td>
                        <td> 
                          
                            <cc1:JQDatePicker Regional="fa" ID="JQDatePicker1" runat="server"></cc1:JQDatePicker>

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
