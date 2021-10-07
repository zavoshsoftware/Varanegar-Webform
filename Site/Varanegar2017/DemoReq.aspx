﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DemoReq.aspx.cs" Inherits="Varanegar.DemoReq" %>
<%@ Register Assembly="GoogleReCaptcha" Namespace="GoogleReCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src='https://www.google.com/recaptcha/api.js?hl=fa'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>درخواست دمو
                    </h1>
                    <p class="tagline">
                        با تکمیل فرم زیر کارشناسان ما جهت ارائه
                         دمو نرم افزار با شما تماس خواهند گرفت.
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            درخواست دمو نرم افزار</span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Responsive image with left -->
    <section id="responsive" class="padding aboutsec">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="col-md-10 alert alert-info mt30">

                        <div class="widget">
                            <h4>ورانگر</h4>
                            <p class="activecolorlink">
                                ورانگر اولین و معتبرترین تولیدکننده نرم افزارهای تخصصی 
                            <a href="http://www.varanegar.com/Product/sales-and-distribution-software">فروش و پخش مویرگی 
                            </a>
                                بعنوان با سابقه ترین شرکت نرم افزاری در حوزه پخش، متمایزترین محصولات و خدمات را ارایه نموده که بسیاری از بزرگان صنعت مذکور از این خدمات استفاده می نمایند. محصولات متفاوت با امکانات مورد نیاز روز در این بازار و خدمات متمایز در ارایه و استقرار، جذابیت استفاده هرچه بیشتر محصولات و خدمات را برای مشتریان میسر ساخته است. 
اکنون باگذشت بیش از دو دهه و ارایه موفق به بیش از 800 شرکت بزرگ و متوسط حوزه صنعت پخش مویرگی، با گستردگی بیش از 1500 مرکز توزیع در سراسر کشور،
                             <a href="http://www.varanegar.com">گروه مشاورین ورانگر 
                             </a>
                                به عنوان بزرگ ترین و برترین ارایه دهنده نرم افزار های تخصصی فروش و پخش مویرگی کشور شناخته می شود. در حال حاضر با بهره گیری از تجربیات و روش های گوناگون بزرگان صنعت پخش به ما امکان ارایه راهکاری بهینه و در نتیجه حضور موفق در این صنایع را نموده است.

                      <br />
                                برای مشاهده دمو نرم افزارهای ورانگر فرم مقابل را تکمیل نمایید.
                            </p>
                        </div>
                        <div class="widget">
                            <h4>
                                <a href="http://rastaksoft.com/">رستاک
                                </a></h4>

                            <p>
                                گروه رستاک با پشتوانه تجربی ۱۰ ساله ورانگر در صنعت فروش و توزیع مویرگی در اردیبهشت ماه سال ۱۳۸۷ فعالیت خود را در زمینه طراحی و تولید نرم افزار فروش و پخش مویرگی آغاز نمود.   
                            <br />
                                اصلی ترین هدف این گروه، ارائه آخرین راه کار های نرم افزاری در زمینه توزیع و فروش مویرگی می باشد. طراحی و تولید نرم افزار یکپارچه فروش و پخش مویرگی در تمامی بخش ها و فعالیت های صنعت پخش و توزیع مویرگی از دستاوردهای این گروه در طی سال های گذشته است. تجارب ارزنده شرکت ورانگر در طراحی و تولید نرم افزار فروش و پخش مویرگی در طی سال های گذشته، راه را برای حضور مقتدرانه گروه رستاک در بازارهای پخش و توزیع مویرگی بسیار تسهیل نموده است. 
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-12 demoreq">
                    <asp:Panel ID="pnlSuccess" Visible="False" CssClass="alert alert-success" runat="server">درخواست شما با موفقیت ثبت گردید.</asp:Panel>
                    <asp:ValidationSummary ID="vsDemoReq" CssClass="alert alert-danger" runat="server" ValidationGroup="demo" />
                    <div class="form-group">
                        <label for="exampleInputName2">نام و نام خانوادگی *:</label>
                        <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="نام و نام خانوادگی *"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="demo" runat="server" ControlToValidate="txtName" ErrorMessage="نام و نام خانوادگی خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail2">نام سازمان / شرکت*:</label>
                        <asp:TextBox CssClass="form-control" ID="txtCompanyName" runat="server" placeholder="نام سازمان / شرکت*"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="demo" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="نام سازمان یا شرکت خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputName2">زمینه فعالیت:</label>
                        <asp:TextBox CssClass="form-control" ID="txtField" runat="server" ValidationGroup="demo" placeholder="زمینه فعالیت" TextMode="MultiLine"></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputName2">سمت سازمانی:</label>
                        <asp:TextBox CssClass="form-control" ID="txtPost" runat="server" ValidationGroup="demo" placeholder="سمت سازمانی"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail2">شماره تماس ثابت*:</label>
                        <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" placeholder="شماره تماس ثابت*"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="demo" runat="server" ControlToValidate="txtPhone" ErrorMessage="شماره تماس ثابت خود را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="demo" ID="RegularExpressionValidator2" runat="server" Display="none"
                            ErrorMessage="شماره تماس ثابت را مقدار عددی وارد نمایید" ControlToValidate="txtPhone" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>


                    </div>

                    <div class="form-group">
                        <label for="exampleInputName2">پست الکترونیک*:</label>
                        <asp:TextBox CssClass="form-control" ID="txtEmail" TextMode="Email" runat="server" placeholder="پست الکترونیک*"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="demo" runat="server" ControlToValidate="txtEmail" ErrorMessage="پست الکترونیک را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="demo" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="پست الکترونیک وارد شده صحیح نمی باشد" Display="None">*</asp:RegularExpressionValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail2">شماره همراه*:</label>
                        <asp:TextBox CssClass="form-control" ID="txtMobile" runat="server" placeholder="شماره همراه*"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="demo" runat="server" ControlToValidate="txtMobile" ErrorMessage="شماره همراه را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="demo" ID="RegularExpressionValidator6" runat="server" Display="none"
                            ErrorMessage="شماره همراه را مقدار عددی وارد نمایید" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>

                    </div>
                     <div class="form-group">
                        <label for="exampleInputEmail2">نام نرم افزار*:</label>
                        <asp:DropDownList ID="ddlProduct" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:CustomValidator ID="cvProduct" ValidationGroup="demo" runat="server" ErrorMessage="نام نرم افزار مورد نظر را وارد نمایید" OnServerValidate="cvProduct_OnServerValidate" Display="None">*</asp:CustomValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail2">نحوه آشنایی با ورانگر*:</label>
                        <asp:DropDownList ID="ddlfamiliar" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:CustomValidator ID="cvFamiliarToVaranegar" ValidationGroup="demo" runat="server" ErrorMessage="نحوه آشنایی با ورانگر را وارد نمایید" OnServerValidate="cvFamiliarToVaranegar_OnServerValidate" Display="None">*</asp:CustomValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputName2">توضیحات:</label>
                        <asp:TextBox CssClass="form-control" ID="txtDesc" runat="server" placeholder="توضیحات" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <p class="clear"></p>
                    <div class="form-group">
                       
     
      

                          <cc1:GoogleReCaptcha ID="ctrlGoogleReCaptcha" runat="server" PublicKey="6Ld3xwsUAAAAAKvDQOF_5F4YETEke3TEmvQeeMl6"
        PrivateKey="6Ld3xwsUAAAAAAyN-JDu4XNWIO2v3K7FylVu84VP" />
                       
                                <asp:CustomValidator ID="reCaptchaValid" runat="server" ErrorMessage="لطفا هویت خود را با استفاده از captcha تایید کنید" ValidationGroup="demo" Display="None" OnServerValidate="reCaptchaValid_ServerValidate">*</asp:CustomValidator>
                              
                    </div> 
                    <p class="clear"></p>
                    <div class="form-group">
                        <asp:Button ID="btnSubmitReq"  OnClick="btnSubmitReq_OnClick" CssClass="btn btn-success" runat="server" Text="ثبت درخواست" ValidationGroup="demo" />
                    </div>
                </div>
            </div>
        </div>
    </section>



    <section id="slogan">
        <div class="container">
            <div class="row">
                <div class="col-md-12 clearfix">
                    <h5 class="hidden"></h5>
                    <p>
                        سال هاست بزرگان صنعت پخش با ما هستند.
                    </p>
                    <a class="btn-common bounce-top-black" href="/contact">با ما در تماس باشید</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
