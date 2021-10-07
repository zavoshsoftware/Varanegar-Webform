<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="Varanegar.ErrorPages.Oops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/errorPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>خطا
                    </h2>
                    <p class="tagline">
                       متاسفانه هنگام پردازش درخواست شما خطایی رخ داده است
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
خطا                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Main -->
      
    <section id="content" class="top-padding">
           <div class="container">
            <div class="no-content-box wow fadeInRightBig">
                <div class="vcenter-container">
                    <div class="vcenter notfoundpageContent">
                        <h2>خطا</h2>
                        <h3>متاسفانه هنگام پردازش درخواست شما خطایی رخ داده است.</h3>
                        <p>
                            متاسفانه در صفحه مورد نظر شما خطایی رخ داده است،
                             لطفا دوباره تلاش کنید
                            . 
                            می توانید از طریق لینک های زیر، صفحه مورد نظر خود را پیدا کنید
                            
                        </p>
                        <div class="notfoundpageLinks">
                            <a href="/default.aspx" class="btn btn-success">صفحه اصلی سایت</a>
                     
                            <a href="/Blog" class="btn btn-success">اخبار و تازه ها</a>
                            <a href="/About" class="btn btn-success">درباره ما</a>
                            <a href="/Contact" class="btn btn-success">تماس با ما</a>
                            <a href="/career" class="btn btn-success">پیوستن به ما</a>
                            <a href="/customer" class="btn btn-success">مشتریان</a>

                        </div>
                    </div>
                    <!-- End .vcenter -->
                </div>
                <!-- End .vcenter-container -->
            </div>
            <!-- End .no-content-box -->
        </div>
    </section>
</asp:Content>
