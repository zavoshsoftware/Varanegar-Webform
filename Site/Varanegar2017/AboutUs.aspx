<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Varanegar.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>درباره ورانگر
                    </h2>
                    <p class="tagline">
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            درباره ما
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <!-- Responsive image with left -->
    <section id="responsive" class="padding aboutsec">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-sm-8 r-test">
                    <h3>
                        <asp:Literal ID="ltAbout1" runat="server"></asp:Literal>

                    </h3>
                    <p>
                        <asp:Literal ID="ltAbout2" runat="server"></asp:Literal>
                    </p>

                </div>
                <div class="col-md-6 col-sm-4">
                        <div id="about-slider" class="owl-carousel">
                            <asp:Repeater ID="rptSection1" runat="server">
                                <ItemTemplate>
                                    <div class="item">
                                        <img src='<%# Eval("ImgUrlAddress","/uploads/Images/{0}") %>' alt='<%# Eval("ImageTitle") %>'>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                </div>
            </div>
        </div>
    </section>


    <!-- Counters -->
    <section class="counter-bg">
        <h5 class="hidden">hidden</h5>
        <div class="container-fluid">
            <div class="row number-counters">
                <div class="col-md-3 col-sm-6 text-center">
                    <div class="counters-item">
                        <strong data-to="3000">0</strong>
                        <p>حوزه توزيع و فروشگاه</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 text-center">
                    <div class="counters-item">
                        <img src="images/shape.png" alt="slash">
                        <strong data-to="120">0</strong>
                        <p>کارشناس نرم افزار</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 text-center">
                    <div class="counters-item">
                        <img src="images/shape.png" alt="slash">
                        <strong data-to="600">0</strong>
                        <p>مشتری فعال</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 text-center">
                    <div class="counters-item">
                        <img src="images/shape.png" alt="slash">
                        <strong data-to="10000">0</strong>
                        <p>نسخه انلاين تبلت و موبايل</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Skills with Description -->
    <section class="info-section">
        <div class="row">
            <div class="col-md-6 col-xs-12 block">
                <div class="description">
                    <div class="skil-leftbar">
                        <h3>
                            <asp:Literal ID="ltAbout3" runat="server"></asp:Literal>
                        </h3>
                        <p class="text-justify">
                            <asp:Literal ID="ltAbout4" runat="server"></asp:Literal>
                        </p>
                        <p class="text-center">
                            <a href="/varanegar-glance" class="btn btn-success">ادامه مطلب</a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-xs-12 block">
                <div class="bg" id="aboutDivBG1"></div>
            </div>
        </div>
    </section>

    <section id="thinkers" class="bg-grey padding">
        <div class="container">
            <div class="row text-center">
                <div class="col-md-12">
                    <p class="title">مدیران ورانگر</p>
                    <h2 class="heading">اعضای هیات مدیره</h2>
                </div>
            </div>
            <div class="row">
                
               <%-- <div id="publication-slider" class="owl-carousel">--%>
                    
                    <asp:Repeater ID="rptmanager" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4">
                           
                                    <div class="thinker-image">
                                        <div class="col-md-8 col-md-offset-2">
                                        <img src='<%# Eval("ManagerImg","/Uploads/team/{0}") %>' alt='<%# Eval("ManagerTitle") %>' class="img-responsive" />
                                       </div> <div class="overlay">
                                            <div class="overlay-inner">
                                                <ul class="social-link text-center">
                                                    <li><a href='<%# Eval("LinkedinLink") %>' class="text-center"><i class="fa fa-linkedin"></i><span></span></a></li>
                                                    <li><a href='<%# Eval("EmailLink","mailto:{0}") %>' class="text-center"><i class="fa fa-mail-forward"></i><span></span></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                <div class="text-center top-padding4">
                                    <h3><%# Eval("ManagerTitle") %></h3>
                                    <small><%# Eval("ManagerPost") %></small>
                                    <p><%# Eval("ManagerDesc") %></p>
                               </div></div>
                        </ItemTemplate>
                    </asp:Repeater>

<%--                </div>--%>
            </div>
        </div>
    </section>

    <section id="client" class="padding">
        <div class="container">
            <div class="col-md-12 text-center">

                <h2>برخی مشتریان ما</h2>
                <div id="client-slider" class="owl-carousel">
                    <div class="item">
                        <img src="/images/logo/1.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/2.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/3.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/4.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/1.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/2.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/3.jpg" alt="logo Image" width="195px" height="85px">
                    </div>
                    <div class="item">
                        <img src="/images/logo/4.jpg" alt="logo Image" width="195px" height="85px">
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
