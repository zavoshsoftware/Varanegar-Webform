<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AgentQuestions.aspx.cs" Inherits="Varanegar.AgentQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <asp:Panel ID="pnlSuccess" CssClass="alert alert-success" Visible="false" runat="server">کاربر گرامی درخواست شما با موفقیت ثبت گردید. </asp:Panel>
            <asp:Panel ID="pnlError" CssClass="alert alert-danger" Visible="false" runat="server">با عرض پوزش، در هنگام پردازش درخواست شما خطایی رخ داده است. لطفا اطلاعات ورودی خود را چک کرده و مجدد تلاش کنید. </asp:Panel>
               <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="agent" CssClass="alert alert-danger"  />
            <div class="row ddlitems">
                <div class="alert alert-info">
                    <input type="radio" name="type" id="allot" checked="checked" value="person" />حقیقی
                    <input type="radio" name="type" id="transfer" value="company" />حقوقی
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">مشخصات کلی</div>
                <div class="panel-body formQuestionary">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                                  <div class="col-md-6 col-sm-12 demoreq">
                        <div class="form-group">
                            <label for="exampleInputName2">نام و نام خانوادگی *:</label>
                            <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="نام و نام خانوادگی *"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="agent" runat="server" ControlToValidate="txtName" ErrorMessage="نام و نام خانوادگی خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">شماره شناسنامه*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtBirthCerId" runat="server" placeholder="شماره شناسنامه*"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="agent" runat="server" ControlToValidate="txtBirthCerId" ErrorMessage="شماره شناسنامه خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">استان*:</label>
                            <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" ></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">تلفن ثابت به همراه کد*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtHomePhone" runat="server" placeholder="تلفن ثابت *"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="agent" runat="server" ControlToValidate="txtHomePhone" ErrorMessage="تلفن ثابت  خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">ایمیل*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="ایمیل*"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="agent" runat="server" ControlToValidate="txtEmail" ErrorMessage="ایمیل را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="agent" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="ایمیل وارد شده صحیح نمی باشد" Display="None">*</asp:RegularExpressionValidator>
                              </div>
                    </div>
                    <div class="col-md-6 col-sm-12 demoreq">


                        <div class="form-group">
                            <label for="exampleInputName2">شماره ملی *:</label>
                            <asp:TextBox CssClass="form-control" ID="txtNationalCode" runat="server" placeholder="شماره ملی *"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNationalCode" ValidationGroup="agent" ErrorMessage="شماره ملی خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">صادره از*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtBirthPlace" runat="server" placeholder="صادره از*"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">شهر*:</label>
                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">موبایل*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtMobile" runat="server" placeholder="موبایل*"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="agent" runat="server" ControlToValidate="txtMobile" ErrorMessage="شماره موبایل خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">کد پستی*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtPostal" runat="server" placeholder="کد پستی*"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="agent" runat="server" ControlToValidate="txtPostal" ErrorMessage="کد پستی خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
              
                    <div class="col-md-12 col-sm-12 demoreq">
                        <div class="form-group">
                            <label for="exampleInputEmail2">آدرس محل سکونت*:</label>
                            <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtHomeAddress" runat="server" placeholder="آدرس محل سکونت*"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="agent" runat="server" ControlToValidate="txtHomeAddress" ErrorMessage="آدرس محل سکونت خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default companyform">
                <div class="panel-heading">مشخصات شرکت</div>
                <div class="panel-body formQuestionary">
                    <div class="col-md-6 col-sm-12 demoreq">
                        <div class="form-group">
                            <label for="exampleInputName2">نام شرکت *:</label>
                            <asp:TextBox CssClass="form-control" ID="txtCompanyName" runat="server" placeholder="نام شرکت *"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">مالکیت*:</label>
                            <asp:DropDownList ID="ddlOwnership" runat="server" CssClass="form-control">
                                <asp:ListItem Value="rent">استیجاری</asp:ListItem>
                                <asp:ListItem Value="own">شخصی</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">کد پستی*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtPostalCode" runat="server" placeholder="کد پستی*"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">تعداد کارکنان*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtEmployeNumb" runat="server" placeholder="تعداد کارکنان*"></asp:TextBox>
                        </div>

                    </div>
                    <div class="col-md-6 col-sm-12 demoreq">
                        <div class="form-group">
                            <label for="exampleInputName2">تلفن شرکت *:</label>
                            <asp:TextBox CssClass="form-control" ID="txtCompanyPhone" runat="server" placeholder="تلفن شرکت *"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">آدرس شرکت*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtCompanyAddress" runat="server" placeholder="آدرس شرکت*"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail2">مساحت فضای کاری*:</label>
                            <asp:TextBox CssClass="form-control" ID="txtarea" runat="server" placeholder="مساحت فضای کاری*"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">سوابق کاری</div>
                <div class="panel-body formQuestionary" id="firstjob">
                    <div class="row">
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">نام محل کار*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtPlaceName1" runat="server" placeholder="نام محل کار*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">نوع صنعت*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtIndustryType1" runat="server" placeholder="نوع صنعت*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">از سال*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtStartDate1" runat="server" placeholder="از سال*"></asp:TextBox>
                        
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStartDate1" ValidationExpression="^\d+$"  ValidationGroup="agent" ErrorMessage="لطفا برای سال شروع مقدار عددی وارد نمایید" Display="None">        </asp:RegularExpressionValidator> 
                                
                                    </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">تا سال*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtEndDate1" runat="server" placeholder="تا سال*"></asp:TextBox>
                          
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEndDate1" ValidationExpression="^\d+$"  ValidationGroup="agent" ErrorMessage="لطفا برای سال پایان مقدار عددی وارد نمایید" Display="None">        </asp:RegularExpressionValidator> 
                                
                                  </div>
                        </div>
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">سمت*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtPost1" runat="server" placeholder="سمت*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">توضیحات*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtdesc1" runat="server" placeholder="توضیحات*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2"></label>
                                <button type="button" id="btnplus1" class="btn btn-success">
                                    <i class="fa fa-plus"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                      <div class="row" id="secondjob">
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">نام محل کار*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtPlaceName2" runat="server" placeholder="نام محل کار*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">نوع صنعت*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtIndustryType2" runat="server" placeholder="نوع صنعت*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">از سال*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtStartDate2" runat="server" placeholder="از سال*"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtStartDate2" ValidationExpression="^\d+$"  ValidationGroup="agent" ErrorMessage="لطفا برای سال شروع مقدار عددی وارد نمایید" Display="None">        </asp:RegularExpressionValidator> 
  </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">تا سال*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtEndDate2" runat="server" placeholder="تا سال*"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEndDate2" ValidationExpression="^\d+$"  ValidationGroup="agent" ErrorMessage="لطفا برای سال پایان مقدار عددی وارد نمایید" Display="None">        </asp:RegularExpressionValidator> 
    </div>
                        </div>
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">سمت*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtPost2" runat="server" placeholder="سمت*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">توضیحات*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtdesc2" runat="server" placeholder="توضیحات*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2"></label>
                                <button type="button" id="btnplus2" class="btn btn-success">
                                    <i class="fa fa-plus"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                          <div class="row" id="thirdjob">
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">نام محل کار*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtPlaceName3" runat="server" placeholder="نام محل کار*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">نوع صنعت*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtIndustryType3" runat="server" placeholder="نوع صنعت*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">از سال*:</label>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtStartDate3" ValidationExpression="^\d+$"  ValidationGroup="agent" ErrorMessage="لطفا برای سال شروع مقدار عددی وارد نمایید" Display="None">        </asp:RegularExpressionValidator> 

                                <asp:TextBox CssClass="form-control" ID="txtStartDate3" runat="server" placeholder="از سال*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">تا سال*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtEndDate3" runat="server" placeholder="تا سال*"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtEndDate3" ValidationExpression="^\d+$"  ValidationGroup="agent" ErrorMessage="لطفا برای سال پایان مقدار عددی وارد نمایید" Display="None">        </asp:RegularExpressionValidator> 
  </div>
                        </div>
                        <div class="col-md-2 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">سمت*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtPost3" runat="server" placeholder="سمت*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">توضیحات*:</label>
                                <asp:TextBox CssClass="form-control" ID="txtdesc3" runat="server" placeholder="توضیحات*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2"></label>
                                <button type="button" id="btnplus3" class="btn btn-success">
                                    <i class="fa fa-plus"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">اطلاعات تکمیلی</div>
                <div class="panel-body">
                    <div class="formQuestionary">
                        <div class="col-md-6 col-sm-12 demoreq">
                            <div class="form-group">
                                <label for="exampleInputName2">آیا تا کنون در زمینه فروش نرم افزار فعالیت نموده اید :</label>
                                <p class="clear"></p>
                                <asp:DropDownList ID="ddlSoftwareBefore" runat="server" CssClass="form-control with25">
                                    <asp:ListItem Value="1">بلی</asp:ListItem>
                                    <asp:ListItem Value="0">خیر</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox CssClass="form-control with70" ID="txtSoftwareBefore" runat="server" placeholder="نام نرم افزار و شرکت مربوطه"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label for="exampleInputName2">آیا در حال حاضر نمایندگی یا عاملیت فروش از سایر شرکت ها می باشید:</label>
                                <p class="clear"></p>
                                <asp:DropDownList ID="ddlIsAgent" runat="server" CssClass="form-control with25">
                                  <asp:ListItem Value="1">بلی</asp:ListItem>
                                    <asp:ListItem Value="0">خیر</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox CssClass="form-control with70" ID="txtIsAgent" runat="server" placeholder="توضیحات"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label for="exampleInputName2">آیا دارای مکان اداری یا تجاری برای ارائه خدمات خود هستید؟:</label>
                                <p class="clear"></p>
                                <asp:DropDownList ID="ddlCommercialPlace" runat="server" CssClass="form-control with25">
                                     <asp:ListItem Value="1">بلی</asp:ListItem>
                                    <asp:ListItem Value="0">خیر</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox CssClass="form-control with70" ID="txtCommercialPlace" runat="server" placeholder="توضیحات"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail2">نحوه آشنایی شما با شرکت ورانگر:</label>
                                <asp:DropDownList ID="ddlHowKnowUs" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">از همکاران شرکت می باشد</asp:ListItem>
                                    <asp:ListItem Value="2">آگهی روزنامه</asp:ListItem>
                                    <asp:ListItem Value="3">در شرکت مشتری مشغول به کار هستم</asp:ListItem>
                                    <asp:ListItem Value="4">آگهی در شبکه های اجتماعی</asp:ListItem>
                                    <asp:ListItem Value="5">دوستان و آشنایان</asp:ListItem>
                                    <asp:ListItem Value="6">وب سایت</asp:ListItem>
                                    <asp:ListItem Value="7">همایش و رویدادها</asp:ListItem>
                                    <asp:ListItem Value="8">سایر موارد</asp:ListItem>

                                </asp:DropDownList>
                            </div>

                        </div>



                        <div class="col-md-6 col-sm-12 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">آیا در حال حاضر بیمه هستید:</label>
                                <asp:DropDownList ID="ddlInsurance" runat="server" CssClass="form-control">
                                <asp:ListItem Value="1">بلی</asp:ListItem>
                                    <asp:ListItem Value="0">خیر</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail2">آیا دسترسی به اینترنت پر سرعت دارید:</label>
                                <asp:DropDownList ID="ddlInternet" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">بلی</asp:ListItem>
                                    <asp:ListItem Value="0">خیر</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail2">میزان آشنایی با نرم افزار های ورانگر پیشرو:</label>
                                <asp:DropDownList ID="ddlVaranegarSoftwareIntroduce" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">کاربر سیستم ورانگر در شرکت های مشتری هستم</asp:ListItem>
                                    <asp:ListItem Value="2">دارای گواهینامه آموزشی از شرکت ورانگر پیشرو هستم</asp:ListItem>
                                    <asp:ListItem Value="3">آشانایی ندارم</asp:ListItem>
                                    <asp:ListItem Value="4">سایر</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="col-md-12 col-sm-12 demoreq">
                            <div class="form-group">
                                <label for="exampleInputEmail2">دلایل اصلی شما برای علاقهمندی به فعالیت به عنوان عاملیت فروش:</label>
                                <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtReasonForDo" runat="server" placeholder="توضیحات"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:Button ID="btnSubmit" runat="server" Text="ثبت درخواست" CssClass="btn btn-success btnsubmitagent" OnClick="btnSubmit_Click"  ValidationGroup="agent"/>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $("#btnplus1").click(function () {
                $('#secondjob').slideDown();
            });
            $("#btnplus2").click(function () {
                $('#thirdjob').slideDown();
            });

            $('input[type=radio][name=type]').change(function () {
                $('.companyform').slideToggle();

            });
        });
    </script>
</asp:Content>
