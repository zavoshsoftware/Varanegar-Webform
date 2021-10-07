<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="CareerListSetting.aspx.cs" Inherits="Varanegar.Admin.CareerListSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" CssClass="btn btn-warning" OnClick="btnReturn_Click" CausesValidation="false" />

            <br />
            <br />

            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField DataField="FirstName" HeaderText="نام" />

                    <asp:BoundField DataField="LastName" HeaderText="نام خانوادگی" />
                    <asp:BoundField DataField="RegisterDate" HeaderText="تاریخ ثبت" />



                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>

                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("careerID") %>' CommandName="DoDetail" CssClass="lb">مشاهده جزییات</asp:LinkButton>
                            <br />
                            <i class="fa fa-times"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("careerID") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>

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
                        <h3 class="panel-title">بخش اول: اطلاعات عمومی</h3>
                    </div>
                    <div class="panel-body">


                            <div class="form-group col-md-4">
                    <label>نام</label>
                    <asp:Label ID="lblFirstName" runat="server" CssClass="form-control"></asp:Label>

                </div>
                <div class="form-group col-md-4">
                    <label>نام خانوادگی</label>
                    <asp:Label ID="lblLastName" runat="server" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>نام پدر</label>
                    <asp:Label ID="lblFatherName" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>شماره شناسنامه</label>
                    <asp:Label ID="lblNationalShID" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>



                <div class="form-group col-md-4">
                    <label>کد ملی</label>
                    <asp:Label ID="lblNationalId" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>تاریخ تولد</label>
                    <asp:Label ID="lblBirthDay" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>محل تولد</label>
                    <asp:Label ID="lblBirthPlace" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>پست الکترونیک</label>
                    <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>شماره تلفن ثابت</label>
                    <asp:Label ID="lblPhone" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>تلفن همراه</label>
                    <asp:Label ID="lblMobile" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>


                <div class="form-group col-md-4">
                    <label>وضعیت تاهل</label>
                    <asp:Label ID="lblMarriage" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>تعداد فرزندان</label>
                    <asp:Label ID="lblChildrenNumb" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>


                <div class="form-group col-md-4">
                    <label>وضعیت اسکان</label>
                    <asp:Label ID="lblHome" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>بیمه تامین اجتماعی؟</label>
                    <asp:Label ID="lblInsurance" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>


                <div class="form-group col-md-4">
                    <label>وضعیت نظام وظیفه</label>
                    <asp:Label ID="lblMilitery" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>



                <div class="form-group col-md-12">
                    <label>آدرس</label>
                    <asp:Label ID="lblAddress" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                    </div>
                </div>


                          <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">بخش دوم: سوابق کاری و تحصیلی</h3>
                    </div>
                    <div class="panel-body">


                            <div class="form-group col-md-4">
                    <label>تخصص</label>
                    <asp:Label ID="lblExpertOn" runat="server" CssClass="form-control"></asp:Label>

                </div>
                <div class="form-group col-md-4">
                    <label>تسلط به زبان انگلیسی</label>
                    <asp:Label ID="lblLang" runat="server" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>مقطع تحصیلی</label>
                    <asp:Label ID="lblDegree" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>رشته تحصیلی</label>
                    <asp:Label ID="lblMajor" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>



                <div class="form-group col-md-4">
                    <label>میزان آشنایی با صنعت پخش</label>
                    <asp:Label ID="lblintro" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>چگونه با ورانگر آشنا شدید</label>
                    <asp:Label ID="lblIntroVaranegar" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-6">
                    <label>با چه نرم افزارهایی آشنایی دارید</label>
                    <asp:Label ID="lblSoftware" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-6">
                    <label>سوابق کاری</label>
                    <asp:Label ID="lblHistory" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
 
                    </div>
                </div>

            
                          <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">بخش سوم: همکاری با ورانگر</h3>
                    </div>
                    <div class="panel-body">


                            <div class="form-group col-md-4">
                    <label>مايليد در زمان اضافه كار، كار كنيد؟</label>
                    <asp:Label ID="lblovertime" runat="server" CssClass="form-control"></asp:Label>

                </div>
                <div class="form-group col-md-4">
                    <label>مايليد در شيفت شب كار كنيد؟</label>
                    <asp:Label ID="lblNight" runat="server" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>مايليد به ماموريت‌هاي داخل كشور برويد؟</label>
                    <asp:Label ID="lblMission" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>مايليد در تعطيلات آخر هفته فعاليت داشته باشيد؟</label>
                    <asp:Label ID="lblWeekend" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>



                <div class="form-group col-md-4">
                    <label>آيا نقص عضو يا عمل جراحي يا بيماري دارید؟</label>
                    <asp:Label ID="lblSurg" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>آيا سابقه محكوميت كيفري داشته‌ايد؟</label>
                    <asp:Label ID="lblCon" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>

               
                <div class="form-group col-md-4">
                    <label>آيا دخانيات مصرفي مي‌كنيد؟</label>
                    <asp:Label ID="lblSmoking" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
      <div class="form-group col-md-4">
                    <label>آيا ضامن براي ضمانت كار خود داريد؟</label>
                    <asp:Label ID="lblWarr" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                    </div>
                </div>


                    <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">بخش چهارم: پرسش نهایی</h3>
                    </div>
                    <div class="panel-body">


                            <div class="form-group col-md-4">
                    <label>نوع همکاری</label>
                    <asp:Label ID="lblWorkingType" runat="server" CssClass="form-control"></asp:Label>

                </div>
                <div class="form-group col-md-4">
                    <label>تاریخ شروع همکاری</label>
                    <asp:Label ID="lblStartWork" runat="server" CssClass="form-control"></asp:Label>
                </div>

                <div class="form-group col-md-4">
                    <label>ميزان حقوق درخواستي (ريال)</label>
                    <asp:Label ID="lblSallary" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <label>رزومه</label>
                    <asp:HyperLink ID="hlResume" runat="server" CssClass="btn btn-primary">دانلود</asp:HyperLink>
                </div>



                <div class="form-group col-md-8">
                    <label>توضیحات تکمیلی</label>
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
