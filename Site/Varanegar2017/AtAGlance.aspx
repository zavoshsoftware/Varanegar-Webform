<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AtAGlance.aspx.cs" Inherits="Varanegar.AtAGlance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>ورانگر در یک نگاه
                    </h2>
                    <p class="tagline">
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>
                        <a href="about"><i class="fa fa-angle-left"></i>درباره ما</a>
                        <span><i class="fa fa-angle-left"></i>
                            ورانگر در یک نگاه
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <section id="area-main" class="padding">
        <h5 class="hidden">hidden</h5>
        <div class="container">
            <div class="row">
                <article class="glanceText clearfix">
                    <div class="col-md-12">
                        <asp:Literal ID="ltText1" runat="server"></asp:Literal>                     
                    </div>
                </article>
            </div>
            <div class="row top-padding">
                <asp:Repeater ID="rptTexts" runat="server">
                    <ItemTemplate>
                           <%# Eval("TextBody") %>
                    </ItemTemplate>
                </asp:Repeater>
              <%--  <article class="blog-wrap clearfix">
                    <div class="col-md-6">
                        <div class="row">
                            <img src="images/strategy2.jpg" alt="استراتژی ورانگر">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="glanceItem r-test">
                            <h3>استراتژی ورانگر</h3>

                            <p>استراتژی های ورانگر در انجام مأموریت سازمانی خود، پیشرفت به سوی چشم اندازهای تعریف شده، فعالیت و همكاری با افراد و سازمان های موجود در بخش های زیر می باشد:</p>

                            <ul class="r-feature">
                                <li>سازمان های پخش مویرگی چند حوزه ای (سراسری)</li>
                                <li>مجموعه های فروش و پخش مویرگی تک حوزه ای</li>
                                <li>شرکت های پخش مویرگی در حوزه های مواد غذایی، لبنی، بهداشتی و آرایشی، نوشیدنی و آشامیدنی، محصولات فرهنگی، صنایع دارویی</li>

                                <li>فروشگاه های زنجیره ای</li>

                                <li>فروش و پخش کسب و کارهای متوسط و کوچک</li>

                            </ul>
                        </div>
                    </div>
                </article>
                <article class="blog-wrap clearfix">
                    <div class="col-md-6">
                        <div class="glanceItem row r-test">
                            <h3>فعالیت های اصلی ورانگر</h3>
                            <p>ورانگر بعنوان اولین و بزرگترین تولید کننده نرم افزارهای تخصصی حوزه پخش بعنوان پیشکسوت نرم افزاری در این حوزه محسوب می گردد و خدمات متفاوتی را به مشتریان خود ارایه می نماید.</p>

                            <ul class="r-feature">
                                <li>تولید و ارایه نرم افزارهای تخصصی فروش و پخش مویرگی</li>
                                <li>ارایه راهکارهای تخصصی و ویژه در صنعت پخش</li>
                                <li>ارایه مشاوره راهبردی در حوزه فروش و پخش</li>
                                <li>ارایه مشاوره مدیریت به سازمان ها و نهادهای وابسته به صنعت پخش</li>
                                <li>تولید نرم افزارهای ویژه و تخصصی سفارش مشتری</li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <img src="images/varanegar.jpg" alt="blog post">
                        </div>
                    </div>
                </article>
                <article class="blog-wrap clearfix">
                    <div class="col-md-6">
                        <div class="row">
                            <img src="images/vision.jpg" alt="blog post">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="glanceItem">
                            <h3>چشم انداز</h3>

                            <p>
                                ما قصد داریم تا افق چشم انداز سال 1404 همواره بعنوان برترین و معتبرترین تولید کننده نرم افزارهای یکپارچه تخصصی فروش و پخش مویرگی در ایران با استفاده از فن آوری های روز مبتنی بر نیاز مشتریان، جایگاه خود را حفظ نموده و محصولات خود را در تمامی کشورهای خاورمیانه ارایه و از طرفی در بازارهای خارجی نیز به رقابت با شرکت های بین المللی بپردازیم. ما با داشتن مشتریان بزرگ در حوزه صنعت پخش، همواره برای رسیدن به اهدافمان برای کسب به حداکثر رساندن رضایتمندی مشتریان، مطمئن ترین و قابل اعتمادترین همراه برای آنان خواهیم بود.
چشم انداز
                            </p>

                        </div>
                    </div>
                </article>
                <article class="blog-wrap clearfix">
                    <div class="col-md-6">
                        <div class="row glanceItem r-test">
                            <h3>ارزش ها و باورها</h3>

                            <p>ورانگر بعنوان پیشکسوت نرم افزاری در صنعت پخش، خدمات متفاوتی را به مشتریان خود ارایه می نماید.</p>
                            <ul class="r-feature">
                                <li>مشتری، اصلی ترین محور تشکیل دهنده فعالیت اقتصادی و مهمترین دارایی ماست، مسلما هدف ما جلب رضایت آن هاست.</li>
                                <li>خلاقیت و نوآوری در تولید محصولات و ارایه خدمات به موقع و مورد نیاز مشتریان</li>
                                <li>رشد و توسعه سازمانی و دستیابی به افتخارات و جایگاه های ملی</li>
                                <li>مشتری ما حق دارد بهترین محصولات و خدمات را از ما طلب نماید</li>
                                <li>ارتقای سطح علمی و کیفیت سطح زندگی کارکنان</li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <img src="images/customer.jpg" alt="blog post">
                        </div>
                    </div>
                </article>
                <article class="blog-wrap clearfix">
                    <div class="col-md-6">
                        <div class="row">
                            <img src="images/mainActivity.jpg" alt="blog post">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="glanceItem">
                            <h3>ارائه خدمات ورانگر</h3>

                            <p>
                                ارایه مشاوره و راهکارهای مدیریتی متناسب با سازمان ها و مجموعه های پخش در سراسر کشور در راستای مطالعات و امکان سنجی، طراحی و مهندسی، تأمین و تدارک تجهیزات، استقرار و راه اندازی، نگهداری و پشتیبانی از نرم افزارهای تخصصی فروش و پخش مویرگی از اولویت های ماموریت سازمانی ورانگر می باشد.
                <br />
                                استفاده از ابزار و تکنولوژی توسط مشتریان براساس چارچوب های مدیریتی روز دنیا به گونه ای است که فناوری اطلاعات در خدمت اهداف و استراتژی های سازمان قرار گیرد و موجب افزایش ارزش افزوده سازمان گردیده، ریسک های موجود در فعالیت تجاری را تحت کنترل، منابع و عملکرد کارکنان مجموعه را نیز مدیریت نمایند.
                <br />
                                ورانکر بجز استقرار و راه اندازی نرم افزارهای خود در سازمان مشتری محترم، دانش و تجربه موفق خود را در حوزه پخش مویرگی به سازمان منتقل تا ضمن بهینه سازی فرایندهای موجود، بهره وری مورد نظر را در آن سازمان پدیدار سازد.
                            </p>

                        </div>
                    </div>
                </article>
                <article class="blog-wrap clearfix">
                    <div class="col-md-6">
                        <div class="row glanceItem r-test">
                            <h3>محوریت نگرش و دیدگاه ما به کسب و کار خود</h3>

                            <p>
                                ورانگر همواره در تلاش است که سطح دانش علمی و عملی خود را توسعه دهد و در ارایه‌ی بهترین محصولات و خدمات به مشتریان مانند سالیان گذشته برترین باشد.
                            </p>
                            <ul class="r-feature">
                                <li>کسب اعتماد از مشتریان به جهت ارایه خدمات کیفی و اثربخش
                                </li>
                                <li>رعایت استانداردهای حرفه ای در حوزه 1سب و کار
                                </li>
                                <li>توجه و درک درست به نیازهای واقعی مشتریان
                                </li>
                                <li>توجه به تامین نیاز مشتری و نتیجه گرایی
                                </li>
                                <li>رعایت اصول منافع مشترک و رابطه برد _ برد با مشتریان
                                </li>
                                <li>ارایه مشاوره و راهکارهای متناسب با نیاز مشتری و جلوگیری از ارایه برنامه های غیر ضروری
                                </li>

                            </ul>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <img src="images/theory.jpg" alt="blog post">
                        </div>
                    </div>
                </article>--%>
            </div>


        </div>
    </section>


    <!-- Slogan With BUY Button -->
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
