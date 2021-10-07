<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowAgentInfo.aspx.cs" Inherits="Varanegar.ShowAgentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="/css/AdminStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>درخواست نمایندگی
                    </h1>
                    <p class="tagline">
                        درخواست نمایندگی فروش نرم افزار
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            درخواست نمایندگی</span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    
             <section id="responsive" class="padding aboutsec">
        <div class="container">

             <asp:MultiView ID="mvAgentInfo" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwInfo" runat="server">
                  <div class="FormView">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">مشخصات کلی</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group col-md-4">
                            <label>نام</label>
                            <asp:Label ID="lblName" runat="server" CssClass="form-control"></asp:Label>

                        </div>
                        <div class="form-group col-md-4">
                            <label>شماره ملی</label>
                            <asp:Label ID="lblNationalCode" runat="server" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>شماره شناسنامه</label>
                            <asp:Label ID="lblBirthCerId" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>صادره از</label>
                            <asp:Label ID="lblBirthCerPlace" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>



                        <div class="form-group col-md-4">
                            <label>شهر</label>
                            <asp:Label ID="lblCity" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>


                        <div class="form-group col-md-4">
                            <label>کد پستی</label>
                            <asp:Label ID="lblPostalCode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
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




                        <div class="form-group col-md-12">
                            <label>آدرس</label>
                            <asp:Label ID="lblAddress" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">اطلاعات شرکت</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group col-md-4">
                            <label>نام شرکت</label>
                            <asp:Label ID="lblCompanyName" runat="server" CssClass="form-control"></asp:Label>

                        </div>
                        <div class="form-group col-md-4">
                            <label>تلفن شرکت</label>
                            <asp:Label ID="lblCompanyPhone" runat="server" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>مالکیت</label>
                            <asp:Label ID="lblCompanyOwnership" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>آدرس شرکت</label>
                            <asp:Label ID="lblCompanyAddress" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>



                        <div class="form-group col-md-4">
                            <label>کد پستی</label>
                            <asp:Label ID="lblCompanyPostalCode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>


                        <div class="form-group col-md-4">
                            <label>مساحت فضای کاری</label>
                            <asp:Label ID="lblArea" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>تعداد کارکنان</label>
                            <asp:Label ID="lblEmployee" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>


                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">سوابق کاری</h3>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">مورد 1</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group col-md-4">
                                    <label>نام محل کار</label>
                                    <asp:Label ID="lblplaceName1" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>نوع صنعت</label>
                                    <asp:Label ID="lblIndustry1" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>از سال</label>
                                    <asp:Label ID="lblStartdate1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>تا سال</label>
                                    <asp:Label ID="lblFinishDate1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>سمت</label>
                                    <asp:Label ID="lblPost1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>توضیحات</label>
                                    <asp:Label ID="lbljobDesc1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlJob2" runat="server" Visible="false">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">مورد 2</h3>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group col-md-4">
                                        <label>نام محل کار</label>
                                        <asp:Label ID="lblplaceName2" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>نوع صنعت</label>
                                        <asp:Label ID="lblIndustry2" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>از سال</label>
                                        <asp:Label ID="lblStartdate2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>تا سال</label>
                                        <asp:Label ID="lblFinishDate2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>سمت</label>
                                        <asp:Label ID="lblPost2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>توضیحات</label>
                                        <asp:Label ID="lbljobDesc2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlJob3" runat="server" Visible="false">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">مورد 3</h3>
                                </div>
                                <div class="panel-body">

                                    <div class="form-group col-md-4">
                                        <label>نام محل کار</label>
                                        <asp:Label ID="lblplaceName3" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>نوع صنعت</label>
                                        <asp:Label ID="lblIndustry3" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>از سال</label>
                                        <asp:Label ID="lblStartdate3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>تا سال</label>
                                        <asp:Label ID="lblFinishDate3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>سمت</label>
                                        <asp:Label ID="lblPost3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>توضیحات</label>
                                        <asp:Label ID="lbljobDesc3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>

                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>



                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">اطلاعات تکمیلی</h3>
                    </div>
                    <div class="panel-body">


                        <div class="form-group col-md-4">
                            <label>آیا تا کنون در زمینه فروش نرم افزار فعالیت نموده اید؟</label>
                            <asp:Label ID="lblSoftwareBefore" runat="server" CssClass="form-control"></asp:Label>
                            <asp:Label ID="lblSoftwareBeforeDesc" runat="server" CssClass="form-control"></asp:Label>

                        </div>
                        <div class="form-group col-md-4">
                            <label>آیا در حال حاضر نمایندگی یا عاملیت فروش از سایر شرکت ها می باشید ؟</label>
                            <asp:Label ID="lblIsAgent" runat="server" CssClass="form-control"></asp:Label>
                            <asp:Label ID="lblIsAgentDesc" runat="server" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>آیا دارای مکان اداری یا تجاری برای ارائه خدمات خود هستید؟</label>
                            <asp:Label ID="lblCommercialPlace" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            <asp:Label ID="lblCommercialPlaceDesc" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>آیا در حال حاضر بیمه هستید؟</label>
                            <asp:Label ID="lblInsurance" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>آیا دسترسی به اینترنت پر سرعت دارید؟</label>
                            <asp:Label ID="lblInternet" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>میزان آشنایی با نرم افزار های ورانگر پیشرو؟</label>
                            <asp:Label ID="lblVaranegarSoftwareIntroduce" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>


                        <div class="form-group col-md-4">
                            <label>نحوه آشنایی شما با شرکت ورانگر؟</label>
                            <asp:Label ID="lblHowKnowUs" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>دلایل اصلی شما برای علاقهمندی به فعالیت به عنوان عاملیت فروش؟</label>
                            <asp:Label ID="lblReason" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>




            </div>
        
              </asp:View>
         <asp:View ID="vwError" runat="server">
             <div class="alert alert-danger">
                 کاربر گرامی اطلاعاتی جهت نمایش موجود نمی باشد.
             </div>
         </asp:View>
    </asp:MultiView>
        
        </div>
    </section>
      
</asp:Content>
