<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Varanegar.ErrorPages._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/errorPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>خطا 404
                    </h2>
                    <p class="tagline">
                       متاسفانه صفحه مورد نظر شما یافت نشد.
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
                        <h2>خطا 404</h2>
                        <h3>متاسفانه صفحه مورد نظر شما یافت نشد.</h3>
                        <p>
                            متاسفانه صفحه مورد نظر شما یافت نشد،
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
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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

