<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Internship.aspx.cs" Inherits="Varanegar.Internship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="bloglistheaderImage" style="background: url(/images/slide_1.jpg) no-repeat center center/cover;">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        دوره های کارآموزی
                    </h1>
                    <p class="tagline">
از دارندگان مدرک کارشناسی در رشته های مهندسی دعوت به گذراندن دوره کارآموزی می گردد.                     </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx"><i class="fa fa-circle"></i>خانه</a>
                     
                        <span><i class="fa fa-angle-left"></i>
                        دوره های کارآموزی
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    
    <section class="descSection ">
        <div class="container">
            <div class="row" id="servicedescBody">
         
                <asp:Literal ID="lblDescription" runat="server"></asp:Literal>

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


