<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Varanegar._default" %>

<%@ Register Src="controls/ucnewsletterbox.ascx" TagName="UCNewsLetterBox" TagPrefix="uc1" %>
<%@ Register Src="controls/ucfooterblogitems.ascx" TagName="UCFooterBlogItems" TagPrefix="uc2" %>
<%@ Register Src="controls/ucfooterlinks.ascx" TagName="UCFooterLinks" TagPrefix="uc3" %>
<%@ Register Src="controls/ucfootercontactinfo.ascx" TagName="UCFooterContactInfo" TagPrefix="uc4" %>
<%@ Register Src="controls/ucfootercopyright.ascx" TagName="UcFooterCopyright" TagPrefix="uc5" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="Persian">
<head runat="server">
    <title>ورانگر پیشرو | نرم افزار پخش مویرگی | نرم افزار فروشگاهی</title>
    <meta name="samandehi" content="181602899" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="نرم افزار فروشگاهی, پخش مویرگی, فروش مویرگی, نرم افزار پخش, سیستم پخش مویرگی, سیستم توزیع, توزیع مویرگی, صنعت پخش, vhk'v, ورانگر,  نرم افزار پخش مواد غذایی, نرم افزار پخش لبنیات, نرم افزار پخش محصولات فرهنگی, نرم افزار پخش نوشیدنی, نرم افزار پخش, نرم افزار توزیع و پخش, نرم افزار فروش و توزیع, ورانگر" />
    <meta name="rights" content="آدرس: تهران، ونک پارک، خیابان شیراز جنوبی، انتهای کوچه آقاعلیخانی شرقی، پلاک2، ساختمان ورانگر
+تلفن: 982187134" />
    <meta name="author" content="http://www.zavosh.org" />
    <meta name="robots" content="index,follow" />
    <meta name="description" content="ورانگر اولین و بزرگترین تولید کننده و ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی و ارائه دهنده نرم افزارهای فروشگاهی می باشد" />
    <meta name="generator" content="Asp.Net" />
    <meta name="google-site-verification" content="AMcEymQrTfKnM1m9hZo1Nd1_OnefjPkl-LSy_qY9wKw" />

    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="css/icomoon-fonts.min.css" />
    <link rel="stylesheet" type="text/css" href="css/settings.min.css" />
    <link rel="stylesheet" type="text/css" href="css/owl.carousel.min.css" />
    <link rel="stylesheet" type="text/css" href="css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/green.min.css" />
    <link rel="stylesheet" type="text/css" href="css/loader.min.css" />
    <link href="css/varanegar.css" rel="stylesheet" />
    <link rel="shortcut icon" href="images/fav.ico" />
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-81246736-1', 'auto');
        ga('send', 'pageview');

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="topbar">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-4 col-xs-9">
                        <ul class="top-left">
                            <li><a href="#"><i class="fa fa-phone"></i>021 87134</a></li>
                            <li><a href="mailto:info@varanegar.com" class="enfonts"><i class="icon-mail-envelope-open5"></i>info@varanegar.com</a></li>
                        </ul>
                    </div>
                    <div class="col-md-8 col-sm-8 col-xs-3 text-right">
                        <ul class="top-right text-right">
                            <li><a href="/Services/support/online-support-e-support">پرتال مشتریان</a></li>
                            <li><a rel="nofollow" target="_blank" href="https://crm.varanegar.com:44399/Account/Login">مدیریت سیستم خرید آنلاین</a></li>
                            <li><a rel="nofollow" target="_blank" href="http://varanegar.com/uploads/license-tracking-Guidance.pdf">راهنمای خرید آنلاین لایسنس ترکینگ</a></li>
                            <li><a class="btn btn-primary" href="/software-demo">درخواست دمو</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <header id="main-navigation" class="index_2">
            <div id="navigation" data-spy="affix" data-offset-top="20">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav class="navbar navbar-default">
                                <div class="navbar-header">
                                    <a class="navbar-brand" href="/">
                                        <img src="images/vlogo2.png" alt="پیشرو ایده ورانگر" class="img-responsive"></a>
                                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#fixed-collapse-navbar" aria-expanded="false">
                                        <span class="icon-bar top-bar"></span><span class="icon-bar middle-bar"></span><span class="icon-bar bottom-bar"></span>
                                    </button>
                                </div>
                                <div class="icon-nav pull-left">
                                    <ul>
                                        <li><a href="#search"><i class="icon-icons185"></i></a></li>
                                    </ul>
                                </div>
                                <div id="fixed-collapse-navbar" class="navbar-collapse collapse navbar-left">
                                    <ul class="nav navbar-nav">
                                        <li class="active"><a href="/default.aspx">صفحه اصلی</a></li>
                                        <li class="static dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">محصولات</a><ul class="megamenu-content dropdown-menu">
                                            <li>
                                                <div class="row">
                                                    <asp:Repeater ID="rptProductGroups" runat="server" OnItemDataBound="rptProductGroups_ItemDataBound">
                                                        <ItemTemplate>
                                                            <div class="col-sm-3">
                                                                <div class="row">
                                                                    <asp:HiddenField ID="hfProductGroupId" Value='<%# Eval("ProductGroupID") %>' runat="server" />
                                                                    <h5 class="title"><a href='<%# Eval("ProductGroupName","/Product/{0}") %>'><%# Eval("ProductGroupTitle") %></a></h5>
                                                                    <ul>
                                                                        <asp:Repeater ID="rptProducts" runat="server">
                                                                            <ItemTemplate>
                                                                                <li><a href='<%# String.Format("/Product/{0}/{1}", Eval("ProductGroupName"), Eval("ProductName")) %>'><%# Eval("ProductTitle") %></a></li>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <div class="MenuImage hidden-xs">
                                                        <img src="images/menuimage.jpg" width="100%" class="img-responsive" alt="محصولات ورانگر پیشرو" />
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        </li>
                                        <li class="static dropdown">
                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">خدمات</a>
                                            <ul class="megamenu-content dropdown-menu serviceitem">
                                                <li>
                                                    <div class="row">
                                                        <asp:Repeater ID="rptServices" runat="server" OnItemDataBound="rptServices_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <div class="col-sm-3">
                                                                    <div class="row">
                                                                        <asp:HiddenField ID="hfServiceId" Value='<%# Eval("ServiceID") %>' runat="server" />
                                                                        <h5 class="title"><a href='<%# Eval("ServiceName","/Services/{0}") %>'><%# Eval("ServiceTitle") %></a></h5>
                                                                        <ul>
                                                                            <asp:Repeater ID="rptServiceSteps" runat="server">
                                                                                <ItemTemplate>
                                                                                    <li><a href='<%# String.Format("/Services/{0}/{1}", Eval("ServiceName"), Eval("ServiceStepName")) %>'><%# Eval("ServiceStepTitle") %></a></li>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <div class="col-sm-3 MenuImage hidden-xs">
                                                            <img src="images/soft2.png" width="100%" class="img-responsive" alt="خدمات ورانگر پیشرو" />
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </li>
                                        <li class="dropdown"><a data-toggle="dropdown" href="#" class="dropdown-toggle">راهکارها</a><ul class="dropdown-menu">
                                            <asp:Repeater ID="rptSolutions" runat="server">
                                                <ItemTemplate>
                                                    <li><a href='<%# Eval("SolutionName","/solution/{0}") %>'><%# Eval("SolutionTitle") %></a></li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                        </li>
                                        <li class="dropdown"><a href="/career" data-toggle="dropdown" class="dropdown-toggle">پیوستن به ما</a><ul class="dropdown-menu">
                                            <li><a href="/career">پیوستن به ما</a></li>
                                            <li><a href="/sales-agent">درخواست نمایندگی</a></li>
                                            <li><a href="/internship">دوره های کارآموزی</a></li>
                                        </ul>
                                        </li>
                                        <li><a href="/customer">مشتریان</a></li>
                                        <li class="dropdown">
                                            <a href="/blog" data-toggle="dropdown" class="dropdown-toggle">اخبار</a><ul class="dropdown-menu">
                                                <asp:Repeater ID="rptBlogGroup" runat="server">
                                                    <ItemTemplate>
                                                        <li><a href="<%# Eval("BlogGroupName","/blog/{0}") %>"><%# Eval("BlogGroupTitle") %></a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <li><a href="gallery">رسانه ورانگر</a></li>
                                            </ul>
                                        </li>
                                        <li><a href="/about">درباره ما</a></li>
                                        <li><a href="/contact">تماس با ما</a></li>
                                    </ul>
                                </div>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <!-- Main-Navigation -->
        <div id="search">
            <button type="button" class="close">×</button>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="عبارت مورد نظر خود را اینجا وارد نمایید"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_OnClick" CssClass="btn btn-primary" Text="جست و جو" />
        </div>
        <section id="main-slider">
            <div class="tp-banner-container">
                <div class="tp-banner">
                    <ul>
                        <asp:Repeater ID="rptSlider" runat="server">
                            <ItemTemplate>
                                <li data-transition="fade" data-slotamount="6">
                                    <img src='<%# Eval("SliderImageUrl","/Uploads/Slider/{0}") %>' alt="slidebg1" data-bgfit="cover" data-bgposition="center center">
                                    <p class="tp-caption sft tp-resizeme title tp-captionright hidden-xs"
                                        data-x="center"
                                        data-y="250"
                                        data-speed="500"
                                        data-start="2200"
                                        data-easing="Power3.easeInOut"
                                        data-elementdelay="0.1"
                                        data-endelementdelay="0.1"
                                        style="z-index: 5;">
                                        <%# Eval("SmallText") %>
                                    </p>
                                    <h2 class="tp-caption sft tp-resizeme tp-captionrightheading  hidden-xs"
                                        data-x="center"
                                        data-y="310"
                                        data-speed="500"
                                        data-start="2600"
                                        data-easing="Power3.easeInOut"
                                        data-elementdelay="0.05"
                                        data-endelementdelay="0.1"
                                        style="z-index: 9;">
                                        <span><%# Eval("BigText") %>
                                        </span>
                                    </h2>
                                    <a href='<%# Eval("LinkAddress") %>' class="tp-caption sft tp-resizeme btn btnslide2"
                                        data-x="center"
                                        data-y="430"
                                        data-speed="500"
                                        data-start="2800"
                                        data-easing="Power3.easeInOut"
                                        data-elementdelay="0.07"
                                        data-endelementdelay="0.1"
                                        style="z-index: 10;"><%# Eval("LinkText") %>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </section>
        <section id="bg-canvas">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-4 canvas-box text-center">
                        <span class="icon-wrap text-center"><i class="icon-icons9"></i></span>
                        <h4>
                            <asp:Literal ID="ltText1" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="ltText2" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div class="col-md-4 col-sm-4 canvas-box text-center">
                        <span class="icon-wrap text-center"><i class="icon-icons96"></i></span>
                        <h4>
                            <asp:Literal ID="ltText3" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="ltText4" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div class="col-md-4 col-sm-4 canvas-box text-center">
                        <span class="icon-wrap text-center"><i class="icon-icons42"></i></span>
                        <h4>
                            <asp:Literal ID="ltText5" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="ltText6" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </section>
        <section id="facts" class="index_2">
            <h3 class="hidden">hidden</h3>
            <div class="container-fluid">
                <div class="row number-counters">
                    <div class="counters-item bg-fifth pull-left text-center">
                        <strong data-to="18000">10</strong><p>نسخه انلاين تبلت و موبايل</p>
                    </div>
                    <div class="counters-item bg-fourth pull-left text-center">
                        <strong data-to="3000">0</strong><p>حوزه توزيع و فروشگاه</p>
                    </div>
                    <div class="counters-item bg-third pull-left text-center">
                        <strong data-to="600">0</strong><p>مشتری فعال</p>
                    </div>
                    <div class="counters-item bg-second pull-left text-center">
                        <strong data-to="120">0</strong><p>کارشناس نرم افزار</p>
                    </div>
                    <div class="counters-item bg-first pull-left text-center">
                        <strong data-to="18">0</strong><p>سال خدمات درخشان</p>
                    </div>
                </div>
            </div>
        </section>
        <section class="info-section index_2_grey index_2">
            <div class="row">
                <div class="col-md-6 col-xs-12 block">
                    <div class="bg" style="background-image: url(images/121.jpg);"></div>
                </div>
                <div class="col-md-6 col-xs-12 block">
                    <div class="center text-center">
                        <p>سال هاست همراه بزرگان صنعت پخش هستیم</p>
                        <h2>
                            <asp:Literal ID="lttext7" runat="server"></asp:Literal></h2>
                        <p>
                            <asp:Literal ID="lttext8" runat="server"></asp:Literal>
                        </p>
                        <a class="btn-black bounce-top" href="/software-demo">درخواست دمو</a>
                        <a class="btn-black bounce-top" href="/about">مطالعه بیشتر</a>
                    </div>
                </div>
                <p class="clear"></p>
            </div>
        </section>
        <section id="project" class="index_2 clearfix">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <p class="title">همراهان ما</p>
                        <h2 class="heading">برخی مشتریان ورانگر</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="work-filter">
                        <ul class="text-center">
                            <asp:Repeater ID="rptCategories" runat="server">
                                <ItemTemplate>
                                    <li><a href="javascript:;" data-filter='<%# Eval("CustomerGroupName",".{0}") %>' class="filter">
                                        <%# Eval("CustomerGroupTitle") %>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <li><a href="javascript:;" data-filter="all" class="active filter">برخی مشتریان</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="project-wrapper">
                <asp:Repeater ID="rptCustomers" runat="server">
                    <ItemTemplate>
                        <figure class='<%# Eval("CustomerGroupName","mix work-item {0}") %>'>
                            <img src='<%# Eval("ImgLogo","/uploads/customers/{0}") %>' width="115px" height="115px" alt='<%# Eval("CustomerTitle") %>'>
                            <a class="overlay text-center" href='<%# Eval("CustomerName","/customer/{0}") %>'>
                                <div class="overlay-inner">
                                    <h4><%# Eval("CustomerTitle") %></h4>
                                    <div class="line"></div>
                                    <p><%# Eval("CustomerGroupTitle") %></p>
                                </div>
                            </a>
                        </figure>
                    </ItemTemplate>
                </asp:Repeater>
                <p class="clear"></p>
            </div>
            <div class="text-center" style="margin: 15px 0;">
                <a href="/customer" class="btn btn-info">مشاهده فهرست مشتریان</a>
            </div>
        </section>
        <section id="bg-rastakparalax" class="index_2">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <img src="images/rastaklogo.png" alt="رستاک" />
                        <h2 style="text-align: center !important;">نرم افزار فروش و پخش مویرگی رستاک</h2>
                        <p class="title">گروه رستاک با پشتوانه تجربی ۱۰ ساله ورانگر در صنعت فروش و توزیع مویرگی در اردیبهشت ماه سال ۱۳۸۷ فعالیت خود را در زمینه طراحی و تولید نرم افزار فروش و پخش مویرگی آغاز نمود. اصلی ترین هدف این گروه، ارائه آخرین راه کار های نرم افزاری در زمینه توزیع و فروش مویرگی می باشد.</p>
                        <a class="btn btn-default" href="http://rastaksoft.com" target="_blank" rel="nofollow">ورود به وب سایت رستاک</a>
                    </div>
                </div>
            </div>
        </section>
        <section id="publication" class="index_2 index_2_grey  padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <p class="title">آخرین مطالب</p>
                        <h2 class="heading">اتاق خبر</h2>
                    </div>
                </div>
                <div class="row">
                    <asp:Repeater ID="rptBlog" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-sm-4 wrap-pulication">
                                <img src='<%# Eval("BlogImage","/uploads/blog/{0}") %>' alt='<%# Eval("BlogTitle") %>' class="img-responsive" height="420px">
                                <h5><%# string.Format("{0:dd MMMM yy}",Eval("SubmitDate")) %></h5>
                                <h4><a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>'><%# Eval("BlogTitle") %></a>
                                </h4>
                                <p class="clear">
                                    <p style="font-size: 13px;"><%# Eval("summeryText") %>  </p>
                                    <a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>'>ادامه مطلب ...</a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
        <section id="bg-paralax" class="index_2">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <p class="title">
                            <asp:Literal ID="ltText10" runat="server"></asp:Literal>
                        </p>
                        <h2 style="text-align: center !important;">
                            <asp:Literal ID="ltText9" runat="server"></asp:Literal></h2>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <div class="container footer_top">
                <div class="row">
                    <div class="col-md-3 col-sm-6">
                        <uc4:UCFooterContactInfo ID="UCFooterContactInfo" runat="server" />
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="footer-col index_2" style="text-align: center;">
                            <h4>لینک های مفید</h4>
                            <p class="clear"></p>
                            <uc3:UCFooterLinks ID="UCFooterLinks1" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="footer-col index_2 news">
                            <h4>آخرین اخبار</h4>
                            <p class="clear"></p>
                            <uc2:UCFooterBlogItems ID="UCFooterBlogItems" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="footer-col index_2 logo">
                            <a href="/default.aspx" class="img-responsive">
                                <img src="/images/vlogo1.png" alt="ورانگر پیشرو"></a><p>ورانگر اولین و معتبرترین تولیدکننده نرم افزارهای تخصصی فروش و پخش مویرگی بعنوان پیشکسوت نرم افزاری در حوزه پخش، متمایزترین محصولات و خدمات را ارایه نموده که بسیاری از بزرگان صنعت مذکور از این خدمات استفاده می نمایند.</p>
                            <h4>ثبت نام در خبر نامه</h4>
                            <p class="clear"></p>
                            <uc1:UCNewsLetterBox ID="UCNewsLetterBox1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </footer>
        <div class="footer-bottom index_2">
            <a href="#" class="go-top text-center"><i class="fa fa-angle-double-up"></i></a>
            <div class="container">
                <div class="row copyright">
                    <uc5:UcFooterCopyright ID="UcFooterCopyright" runat="server" />
                </div>
            </div>
        </div>
        <script src="js/jquery-2.1.4.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script defer async src="js/owl.carousel.min.js"></script>
        <script defer async src="js/jquery-countto.min.js"></script>
        <script defer async src="js/jquery.appear.min.js"></script>
        <script src="js/jquery.mixitup.min.js"></script>
        <script src="js/portfolio.min.js"></script>
        <script defer async src="js/wow.min.js"></script>
        <script src="js/jquery.themepunch.tools.min.js"></script>
        <script src="js/jquery.themepunch.revolution.min.js"></script>
        <script defer async src="js/slider.min.js"></script>
        <script defer async src="js/functions.min.js"></script>
    </form>
</body>
</html>
