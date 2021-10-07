<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Varanegar.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>تماس با ورانگر</h2>
                    <p class="tagline">با ما در تماس باشید</p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link"><a href="default.aspx"><i class="fa fa-circle"></i>خانه</a><span><i class="fa fa-angle-left"></i>تماس با ما</span></div>
                </div>
            </div>
        </div>
    </section>
    <section id="area-main" class="top-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3238.022372961478!2d51.40166653912846!3d35.75025485295085!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x370091ddcfacad50!2sVaranegar+Consulting+Group!5e0!3m2!1sen!2sir!4v1468835984672" width="100%" height="350" frameborder="0" style="border: 0" allowfullscreen></iframe>
                </div>
            </div>
            <div class="row contact top-padding">
                <div class="col-md-4">
                    <h3>با ما در تماس باشید</h3>
                    <ul class="address"> 
                        <li><i class="icon-icons158"></i>دفتر مرکزی: تهران، ونک پارک، خیابان شیراز جنوبی، انتهای کوچه آقاعلیخانی شرقی، پلاک2، ساختمان ورانگر </li>
                        <li><i class="fa fa-phone"></i><span>021-87135000</span></li>
                        <li><a href="mailto:info@varanegar.com"><i class="icon-icons208"></i>info@varanegar.com</a></li>
                    </ul>
                    <h3>برنامه روزانه</h3>
                    <p><span>شنبه تا چهارشنبه:</span> 08:00 - 17:00</p>
                    <p><span>پنج شنبه:</span> 09:00 - 15:00</p>
                    <ul class="social-link text-right">
                        <li><a href="https://www.facebook.com/%D9%88%D8%B1%D8%A7%D9%86%DA%AF%D8%B1-%D9%BE%DB%8C%D8%B4%D8%B1%D9%88-1538684639494633" class="text-center"><i class="fa fa-facebook"></i><span></span></a></li>
                        <li><a href="https://twitter.com/PishroVaranegar" class="text-center"><i class="fa fa-twitter"></i><span></span></a></li>
                        <li><a href="https://www.linkedin.com/company/varanegarpishro" class="text-center"><i class="fa fa-linkedin"></i><span></span></a></li>
                        <li><a href="https://www.instagram.com/varanegar.pishro/" class="text-center"><i class="fa fa-instagram"></i><span></span></a></li>
                    </ul>
                </div>
                <div class="col-md-8 ">
                    <asp:Panel ID="pnlSuccess" runat="server" Visible="false" CssClass="alert alert-success">با تشکر. پیغام شما با موفقیت ثبت گردید.</asp:Panel>
                    <asp:ValidationSummary ID="ValidationSummary1" CssClass="alert alert-danger" ValidationGroup="comment" runat="server" />
                    <div id="result"></div>
                    <div class="row contactdiv">
                        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                            <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="نام*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtname" Display="None" ID="RequiredFieldValidator1" ValidationGroup="comment" runat="server" ErrorMessage="نام خود را وارد نمایید">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                            <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="ایمیل*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtemail" Display="None" ID="RequiredFieldValidator2" ValidationGroup="comment" runat="server" ErrorMessage="ایمیل خود را وارد نمایید">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" Display="None" ValidationGroup="comment" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="ایمیل وارد شده صحیح نمی باشد">*</asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                            <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="موبایل"></asp:TextBox>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                            <asp:DropDownList ID="ddlReciever" runat="server" class="form-control"></asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="دریافت کننده پیغام خود را مشخص نمایید" ValidationGroup="comment" Display="None" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-md-12">
                            <asp:TextBox ID="txtcomment" runat="server" Rows="5" TextMode="MultiLine" class="form-control" placeholder="پیغام شما*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtcomment" Display="None" ID="RequiredFieldValidator3" ValidationGroup="comment" runat="server" ErrorMessage="نظر خود را وارد نمایید">*</asp:RequiredFieldValidator>
                            <asp:Button ID="btnSend" runat="server" Text="ارسال پیغام" OnClick="btnSend_Click" ValidationGroup="comment" />
                        </div>
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
                    <p>سال هاست بزرگان صنعت پخش با ما هستند.</p>
                    <a class="btn-common bounce-top-black" href="/contact">با ما در تماس باشید</a></div>
            </div>
        </div>
    </section>
    <script src="/js/jquery-2.1.4.min.js"></script>
    <script src="/js/jquery.cookie.min.js"></script>
    <script src="/js/bootstrap.min.min.js"></script>
    <script src="/js/jquery.collapsible.min.js"></script>
    <script src="/js/jquery.mapit.min.js"></script>
    <script src="/js/map_initializer.min.js"></script>
    <script src="/js/owl.carousel.min.js"></script>
    <script src="/js/jquery-countTo.min.js"></script>
    <script src="/js/jquery.appear.min.js"></script>
    <script src="/js/wow.min.js"></script>
    <script src="/js/functions.min.js"></script>
</asp:Content>
