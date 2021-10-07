<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="CustomerSetting.aspx.cs" Inherits="Varanegar.Admin.CustomerSetting" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>


 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnAdd" runat="server" Text="افزودن" CssClass="btn btn-success" OnClick="btnAdd_Click" />
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" CssClass="btn btn-warning" OnClick="btnReturn_Click" CausesValidation="false" />
            <a href="/Admin/CustomerSetting.aspx?type=Recycle" class="btn btn-default">مشاهده مشتریان حذف شده</a>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4" style="float: right;">
                    <asp:TextBox ID="txtSearch" runat="server" Width="100%" CssClass="form-control" placeholder="نام مشتری را وارد نمایید"></asp:TextBox>
                </div>
                <div class="col-md-1" style="float: right;">
                    <asp:Button ID="btnSearch" runat="server" Text="جست و جو" OnClick="btnSearch_OnClick" CssClass="btn btn-success" />
                </div>
                <div class="col-md-1" style="float: right;">
                    <asp:Button ID="btnShowAll" runat="server" Text="نمایش همه" OnClick="btnShowAll_OnClick" CssClass="btn btn-default" />
                </div>
            </div>
            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <br />
            <asp:GridView ID="grdTable" OnDataBound="grdTable_OnDataBound" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Priority" HeaderText="ردیف" />
                    <asp:BoundField DataField="CustomerTitle" HeaderText="عنوان" />
                    <asp:BoundField DataField="CustomerName" HeaderText="عنوان سیستمی" />
                    <asp:BoundField DataField="CustomerGroupTitle" HeaderText="گروه" />
                    <asp:CheckBoxField DataField="IsInHome" HeaderText="نمایش در صفحه اصلی" />
                    <asp:TemplateField HeaderText="تصویر">
                        <ItemTemplate>
                            <img src='<%# Eval("ImgLogo","/Uploads/Customers/{0}") %>' height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfValue" Value='<%# Eval("CustomersID") %>' runat="server" />
                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("CustomersID") %>' CommandName="DoEdit" CssClass="lb">ویرایش</asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("CustomersID") %>' CommandName="DoDelete" CssClass="lb">   <i class="fa fa-times"></i>حذف</asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="lbRecycle" runat="server" CommandArgument='<%# Eval("CustomersID") %>' CommandName="recycle" CssClass="lb">
                                    <i class="fa fa-check"></i>بازیابی</asp:LinkButton>
                               <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("CustomersID") %>' CommandName="Province" CssClass="lb">
                                    <i class="fa fa-check"></i>مدیریت استان ها</asp:LinkButton>
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
                        <td>ردیف:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPri" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="none"
                                ErrorMessage="برای فیلد ردیف، مقدار عددی وارد نمایید" ControlToValidate="txtPri" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
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

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="none" ErrorMessage="عنوان انگلیسی را وارد نمایید." ControlToValidate="txtENTitle" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>عنوان سیستمی:
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="none" runat="server" ErrorMessage="عنوان سیستمی را وارد نمایید." ControlToValidate="txtName" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvName" runat="server" Display="none" ErrorMessage="عنوان سیستمی معتبر نمی باشد." ControlToValidate="txtName" ForeColor="Red" OnServerValidate="cvName_ServerValidate">*</asp:CustomValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>گروه مشتری:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductGroup" runat="server" CssClass="form-control" Width="300px"></asp:DropDownList>

                            <asp:CustomValidator Display="none" ID="cvProGroup" ForeColor="Red" OnServerValidate="cvProGroup_ServerValidate" runat="server" ErrorMessage="گروه محصول را وارد نمایید">*</asp:CustomValidator>
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
                        <td>شروع استقرار:
                        </td>
                        <td>

                           
                                <asp:DropDownList ID="ddlStartMonth" runat="server" Width="300px" CssClass="form-control floatright">
                                    <asp:ListItem Value="0">ماه</asp:ListItem>
                                    <asp:ListItem Value="1">فروردین</asp:ListItem>
                                    <asp:ListItem Value="2">اردیبهشت</asp:ListItem>
                                    <asp:ListItem Value="3">خرداد</asp:ListItem>
                                    <asp:ListItem Value="4">تیر</asp:ListItem>
                                    <asp:ListItem Value="5">مرداد</asp:ListItem>
                                    <asp:ListItem Value="6">شهریور</asp:ListItem>
                                    <asp:ListItem Value="7">مهر</asp:ListItem>
                                    <asp:ListItem Value="8">آبان</asp:ListItem>
                                    <asp:ListItem Value="9">آذر</asp:ListItem>
                                    <asp:ListItem Value="10">دی</asp:ListItem>
                                    <asp:ListItem Value="11">بهمن</asp:ListItem>
                                    <asp:ListItem Value="12">اسفند</asp:ListItem>
                                </asp:DropDownList>
                             
                                <asp:DropDownList ID="ddlStartYear" runat="server" Width="300px"  CssClass="form-control floatright">
                                    <asp:ListItem Value="0">سال</asp:ListItem>
                                    <asp:ListItem Value="1360">1360</asp:ListItem>
                                    <asp:ListItem Value="1361">1361</asp:ListItem>
                                    <asp:ListItem Value="1362">1362</asp:ListItem>
                                    <asp:ListItem Value="1363">1363</asp:ListItem>
                                    <asp:ListItem Value="1364">1364</asp:ListItem>
                                    <asp:ListItem Value="1365">1365</asp:ListItem>
                                    <asp:ListItem Value="1366">1366</asp:ListItem>
                                    <asp:ListItem Value="1367">1367</asp:ListItem>
                                    <asp:ListItem Value="1368">1368</asp:ListItem>
                                    <asp:ListItem Value="1369">1369</asp:ListItem>
                                    <asp:ListItem Value="1370">1370</asp:ListItem>
                                    <asp:ListItem Value="1371">1371</asp:ListItem>
                                    <asp:ListItem Value="1372">1372</asp:ListItem>
                                    <asp:ListItem Value="1373">1373</asp:ListItem>
                                    <asp:ListItem Value="1374">1374</asp:ListItem>
                                    <asp:ListItem Value="1375">1375</asp:ListItem>
                                    <asp:ListItem Value="1376">1376</asp:ListItem>
                                    <asp:ListItem Value="1377">1377</asp:ListItem>
                                    <asp:ListItem Value="1378">1378</asp:ListItem>
                                    <asp:ListItem Value="1379">1379</asp:ListItem>
                                    <asp:ListItem Value="1380">1380</asp:ListItem>
                                    <asp:ListItem Value="1381">1381</asp:ListItem>
                                    <asp:ListItem Value="1382">1382</asp:ListItem>
                                    <asp:ListItem Value="1383">1383</asp:ListItem>
                                    <asp:ListItem Value="1384">1384</asp:ListItem>
                                    <asp:ListItem Value="1385">1385</asp:ListItem>
                                    <asp:ListItem Value="1386">1386</asp:ListItem>
                                    <asp:ListItem Value="1387">1387</asp:ListItem>
                                    <asp:ListItem Value="1388">1388</asp:ListItem>
                                    <asp:ListItem Value="1389">1389</asp:ListItem>
                                    <asp:ListItem Value="1390">1390</asp:ListItem>
                                    <asp:ListItem Value="1391">1391</asp:ListItem>
                                    <asp:ListItem Value="1392">1392</asp:ListItem>
                                    <asp:ListItem Value="1393">1393</asp:ListItem>
                                    <asp:ListItem Value="1394">1394</asp:ListItem>
                                    <asp:ListItem Value="1395">1395</asp:ListItem>
                                </asp:DropDownList>
                        </td>
                    </tr>
                           <tr>
                        <td>پایان استقرار:
                        </td>
                        <td>
                                <asp:DropDownList ID="ddlFinishMonth" runat="server" Width="300px"  CssClass="form-control floatright">
                                    <asp:ListItem Value="0">ماه</asp:ListItem>
                                    <asp:ListItem Value="1">فروردین</asp:ListItem>
                                    <asp:ListItem Value="2">اردیبهشت</asp:ListItem>
                                    <asp:ListItem Value="3">خرداد</asp:ListItem>
                                    <asp:ListItem Value="4">تیر</asp:ListItem>
                                    <asp:ListItem Value="5">مرداد</asp:ListItem>
                                    <asp:ListItem Value="6">شهریور</asp:ListItem>
                                    <asp:ListItem Value="7">مهر</asp:ListItem>
                                    <asp:ListItem Value="8">آبان</asp:ListItem>
                                    <asp:ListItem Value="9">آذر</asp:ListItem>
                                    <asp:ListItem Value="10">دی</asp:ListItem>
                                    <asp:ListItem Value="11">بهمن</asp:ListItem>
                                    <asp:ListItem Value="12">اسفند</asp:ListItem>
                                </asp:DropDownList>
                             
                                <asp:DropDownList ID="ddlFinishYear" runat="server" Width="300px"  CssClass="form-control floatright">
                                    <asp:ListItem Value="0">سال</asp:ListItem>
                                    <asp:ListItem Value="1360">1360</asp:ListItem>
                                    <asp:ListItem Value="1361">1361</asp:ListItem>
                                    <asp:ListItem Value="1362">1362</asp:ListItem>
                                    <asp:ListItem Value="1363">1363</asp:ListItem>
                                    <asp:ListItem Value="1364">1364</asp:ListItem>
                                    <asp:ListItem Value="1365">1365</asp:ListItem>
                                    <asp:ListItem Value="1366">1366</asp:ListItem>
                                    <asp:ListItem Value="1367">1367</asp:ListItem>
                                    <asp:ListItem Value="1368">1368</asp:ListItem>
                                    <asp:ListItem Value="1369">1369</asp:ListItem>
                                    <asp:ListItem Value="1370">1370</asp:ListItem>
                                    <asp:ListItem Value="1371">1371</asp:ListItem>
                                    <asp:ListItem Value="1372">1372</asp:ListItem>
                                    <asp:ListItem Value="1373">1373</asp:ListItem>
                                    <asp:ListItem Value="1374">1374</asp:ListItem>
                                    <asp:ListItem Value="1375">1375</asp:ListItem>
                                    <asp:ListItem Value="1376">1376</asp:ListItem>
                                    <asp:ListItem Value="1377">1377</asp:ListItem>
                                    <asp:ListItem Value="1378">1378</asp:ListItem>
                                    <asp:ListItem Value="1379">1379</asp:ListItem>
                                    <asp:ListItem Value="1380">1380</asp:ListItem>
                                    <asp:ListItem Value="1381">1381</asp:ListItem>
                                    <asp:ListItem Value="1382">1382</asp:ListItem>
                                    <asp:ListItem Value="1383">1383</asp:ListItem>
                                    <asp:ListItem Value="1384">1384</asp:ListItem>
                                    <asp:ListItem Value="1385">1385</asp:ListItem>
                                    <asp:ListItem Value="1386">1386</asp:ListItem>
                                    <asp:ListItem Value="1387">1387</asp:ListItem>
                                    <asp:ListItem Value="1388">1388</asp:ListItem>
                                    <asp:ListItem Value="1389">1389</asp:ListItem>
                                    <asp:ListItem Value="1390">1390</asp:ListItem>
                                    <asp:ListItem Value="1391">1391</asp:ListItem>
                                    <asp:ListItem Value="1392">1392</asp:ListItem>
                                    <asp:ListItem Value="1393">1393</asp:ListItem>
                                    <asp:ListItem Value="1394">1394</asp:ListItem>
                                    <asp:ListItem Value="1395">1395</asp:ListItem>
                                </asp:DropDownList>
                        </td>
                    </tr>
                             <tr>
                        <td>تعداد شعب:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBranchNumber" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="none"
                                ErrorMessage="برای فیلد تعداد شعب، مقدار عددی وارد نمایید" ControlToValidate="txtBranchNumber" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                        
                            <asp:RequiredFieldValidator ID="rfvBranchnumber" Display="none" runat="server" ErrorMessage="تعداد شعب را وارد نمایید." ControlToValidate="txtBranchNumber" ForeColor="Red">*</asp:RequiredFieldValidator>
                            
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
                        <td>نمایش در صفحه اصلی؟: 
                        </td>
                        <td>
                            <asp:CheckBox ID="chkInHome" runat="server" />

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
            <div class="alert alert-danger">
                آیا مایل به حذف 
            <asp:Label ID="lblDelete" runat="server" Text="Label"></asp:Label>
                هستید؟
            <br />
                <br />
                <asp:Button ID="btnYes" runat="server" Text="بلی" OnClick="btnYes_Click" CssClass="btn btn-success" />
                <asp:Button ID="btnNo" runat="server" Text="خیر" OnClick="btnNo_Click" CssClass="btn btn-warning" />
            </div>
        </asp:View>
        
        
                <asp:View ID="vwProvince" runat="server">
                    <asp:CheckBoxList ID="cblProvince" runat="server"></asp:CheckBoxList>
                    
                    <br/>
                    <asp:Button ID="btnSubmitProvince" runat="server" Text="ثبت" CssClass="btn btn-success" OnClick="btnSubmitProvince_OnClick" />
                            <asp:Button ID="btnCanceleProvince" runat="server" Text="انصراف" CssClass="btn btn-danger" OnClick="btnCanceleProvince_OnClick" CausesValidation="false" />
                     
        </asp:View>
    </asp:MultiView>
</asp:Content>
