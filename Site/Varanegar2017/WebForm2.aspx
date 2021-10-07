<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Varanegar.WebForm2" %>
<%@ Register Assembly="GoogleReCaptcha" Namespace="GoogleReCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
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
   <cc1:GoogleReCaptcha ID="ctrlGoogleReCaptcha" runat="server" PublicKey="6Ld3xwsUAAAAAKvDQOF_5F4YETEke3TEmvQeeMl6"
        PrivateKey="6Ld3xwsUAAAAAAyN-JDu4XNWIO2v3K7FylVu84VP" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
               </div>
        </div>
    </section>
</asp:Content>
