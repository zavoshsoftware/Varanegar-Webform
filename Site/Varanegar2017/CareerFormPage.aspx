<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CareerFormPage.aspx.cs" Inherits="Varanegar.CareerFormPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SuccessMessages() {

            $('#ProgressBar4').slideUp('fast');
            $('#lastProgressBar').slideDown('fast');
        }
    </script>
    <script src="/js/PersianDatePicker.min.js"></script>
    <link href="/css/PersianDatePicker.min.css" rel="stylesheet" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            // Tooltip only Text
            $('.masterTooltip').hover(function () {
                // Hover over code
                var title = $(this).attr('title');
                $(this).data('tipText', title).removeAttr('title');
                $('<p class="tooltip2"></p>')
                .text(title)
                .appendTo('body')
                .fadeIn('slow');
            }, function () {
                // Hover out code
                $(this).attr('title', $(this).data('tipText'));
                $('.tooltip2').remove();
            }).mousemove(function (e) {
                var mousex = e.pageX + 20; //Get X coordinates
                var mousey = e.pageY + 10; //Get Y coordinates
                $('.tooltip2')
                .css({ top: mousey, left: mousex })
            });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>پیوستن به ما
                    </h1>
                    <p class="tagline">
                        نیروی انسانی بزرگترین سرمایه ما است، به جمع موفق‌ها بپیوندید!
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            پیوستن به ما
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlCareerInfo" runat="server">
                <div id="careerInfo">
                    <section class="top-padding4">
                        <div class="container">
                            <div class="row contact">
                                <div class="col-md-12">
                                    <p class="text-justify">
                                        <asp:Literal ID="ltSection1" runat="server"></asp:Literal>

                                    </p>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section class="counter-bg">
                        <h5 class="hidden">hidden</h5>
                        <div class="container-fluid">
                            <div class="row number-counters careerFeature">
                                <h3>
                                    <asp:Literal ID="ltSection2" runat="server"></asp:Literal>
                                </h3>
                            </div>
                        </div>
                    </section>
                    <section class="info-section">
                        <div class="row">
                            <div class="col-md-6 col-xs-12  r-test">
                                <div class="description">
                                    <div class="skil-leftbar">

                                        <h3>
                                            <asp:Literal ID="ltSection3title" runat="server"></asp:Literal>
                                        </h3>
                                        <asp:Literal ID="ltSection3Body" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-xs-12 block">
                                <div id="teamBG" class="bg"></div>
                            </div>
                        </div>
                    </section>
                    <section class="info-section bg-grey">
                        <div class="row">
                            
                            <div class="col-md-12 col-xs-12  r-test">
                                <div class="description">
                                    <div class="skil-leftbar" id="posInfo">

                                        <h3>
                                            <asp:Literal ID="ltSection4title" runat="server"></asp:Literal>
                                        </h3>

                                        <asp:Literal ID="ltSection4body" runat="server"></asp:Literal>


                                    </div>
                                </div>
                            </div>
                    </section>
                    <section id="gotoForm" class=" padding text-center">
                        <div class="container  text-center">
                            <div class="col-md-12 text-center">
                                <div class="contact nopadding">
                                    <asp:Button ID="btnStartForm" runat="server" Text="تکمیل فرم همکاری" OnClick="btnStartForm_Click" CssClass="hvr-bounce-to-bottom" />
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlForm1" runat="server" Visible="false">
                <div class="container">
                    <div class="row top-padding4">
                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="form1" CssClass="alert alert-danger" runat="server" />
                    </div>
                </div>
                <div class="formPage">
                    <!-- Main -->
                    <section class="top-padding4">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="skills">
                                        <ul>
                                            <li>
                                                <p class="pull-right">
                                                    فرم دعوت به همکاری<i class="fa fa-arrow-left"></i>
                                                    <span class="activeColor">اطلاعات عمومی</span>
                                                </p>
                                                <p class="pull-left">0%</p>
                                                <div class="clearfix"></div>
                                            </li>
                                            <li class="progress">
                                                <div class="progress-bar base_color" data-width="0"></div>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                    <section id="area-main" class="top-padding4">
                        <div class="container">
                            <div class="row contact">
                                <div class="col-md-12 col-sm-12 col-xs-12">

                                    <div class="row careerForm">
                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>نام</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtFirstName" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="نام*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtFirstName" ID="rfvName" runat="server" ErrorMessage="نام را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>نام خانوادگی</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtLastName" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="نام خانوادگی*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ControlToValidate="txtLastName" ValidationGroup="form1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام خانوادگی را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">

                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>نام پدر</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtFathedName" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="نام پدر*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtFathedName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="نام پدر را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>


                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>شماره شناسنامه</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtNationalSHID" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="شماره شناسنامه*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtNationalSHID" ID="RequiredFieldValidator3" runat="server" ErrorMessage="شماره شناسنامه را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">


                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>کد ملی</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtNationalID" runat="server" CssClass="form-control" placeholder="کد ملی*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtNationalID" ErrorMessage="کد ملی را وارد نمایید" ID="RequiredFieldValidator4" runat="server" Display="None">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>محل تولد</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtBirthPlace" runat="server" CssClass="form-control" placeholder="محل تولد*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtBirthPlace" ErrorMessage="محل تولد را وارد نمایید" ID="RequiredFieldValidator5" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <p class="clear"></p>

                                        </div>

                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>تاریخ تولد</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">

                                                    <div class="col-md-4 col-sm-4 col-xs-12">

                                                        <asp:DropDownList ID="ddlDay" runat="server" CssClass="form-control floatright">
                                                            <asp:ListItem Value="0">روز*</asp:ListItem>
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem Value="3">3</asp:ListItem>
                                                            <asp:ListItem Value="4">4</asp:ListItem>
                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                            <asp:ListItem Value="8">8</asp:ListItem>
                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                            <asp:ListItem Value="24">24</asp:ListItem>
                                                            <asp:ListItem Value="25">25</asp:ListItem>
                                                            <asp:ListItem Value="26">26</asp:ListItem>
                                                            <asp:ListItem Value="27">27</asp:ListItem>
                                                            <asp:ListItem Value="28">28</asp:ListItem>
                                                            <asp:ListItem Value="29">29</asp:ListItem>
                                                            <asp:ListItem Value="30">30</asp:ListItem>
                                                            <asp:ListItem Value="31">31</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>


                                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control floatright">
                                                            <asp:ListItem Value="0">ماه*</asp:ListItem>
                                                            <asp:ListItem Value="1">فروردین</asp:ListItem>
                                                            <asp:ListItem Value="2">اردیبهشت</asp:ListItem>
                                                            <asp:ListItem Value="3">خرداد</asp:ListItem>
                                                            <asp:ListItem Value="4">تیر</asp:ListItem>
                                                            <asp:ListItem Value="5">مرداد</asp:ListItem>
                                                            <asp:ListItem Value="6">شهریور</asp:ListItem>
                                                            <asp:ListItem Value="7">مهر</asp:ListItem>
                                                            <asp:ListItem Value="8">آبان</asp:ListItem>
                                                            <asp:ListItem Value="9">آذر</asp:ListItem>
                                                            <asp:ListItem Value="10">دی</asp:ListItem>
                                                            <asp:ListItem Value="11">بهمن</asp:ListItem>
                                                            <asp:ListItem Value="12">اسفند</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control floatright">
                                                            <asp:ListItem Value="0">سال* </asp:ListItem>
                                                            <asp:ListItem Value="1330">1330</asp:ListItem>
                                                            <asp:ListItem Value="1331">1331</asp:ListItem>
                                                            <asp:ListItem Value="1332">1332</asp:ListItem>
                                                            <asp:ListItem Value="1333">1333</asp:ListItem>
                                                            <asp:ListItem Value="1334">1334</asp:ListItem>
                                                            <asp:ListItem Value="1335">1335</asp:ListItem>
                                                            <asp:ListItem Value="1336">1336</asp:ListItem>
                                                            <asp:ListItem Value="1337">1337</asp:ListItem>
                                                            <asp:ListItem Value="1338">1338</asp:ListItem>
                                                            <asp:ListItem Value="1339">1339</asp:ListItem>
                                                            <asp:ListItem Value="1340">1340</asp:ListItem>
                                                            <asp:ListItem Value="1341">1341</asp:ListItem>
                                                            <asp:ListItem Value="1342">1342</asp:ListItem>
                                                            <asp:ListItem Value="1343">1343</asp:ListItem>
                                                            <asp:ListItem Value="1344">1344</asp:ListItem>
                                                            <asp:ListItem Value="1345">1345</asp:ListItem>
                                                            <asp:ListItem Value="1346">1346</asp:ListItem>
                                                            <asp:ListItem Value="1347">1347</asp:ListItem>
                                                            <asp:ListItem Value="1348">1348</asp:ListItem>
                                                            <asp:ListItem Value="1349">1349</asp:ListItem>
                                                            <asp:ListItem Value="1350">1350</asp:ListItem>
                                                            <asp:ListItem Value="1351">1351</asp:ListItem>
                                                            <asp:ListItem Value="1352">1352</asp:ListItem>
                                                            <asp:ListItem Value="1353">1353</asp:ListItem>
                                                            <asp:ListItem Value="1354">1354</asp:ListItem>
                                                            <asp:ListItem Value="1355">1355</asp:ListItem>
                                                            <asp:ListItem Value="1356">1356</asp:ListItem>
                                                            <asp:ListItem Value="1357">1357</asp:ListItem>
                                                            <asp:ListItem Value="1358">1358</asp:ListItem>
                                                            <asp:ListItem Value="1359">1359</asp:ListItem>
                                                            <asp:ListItem Value="1360">1360</asp:ListItem>
                                                            <asp:ListItem Value="1361">1361</asp:ListItem>
                                                            <asp:ListItem Value="1362">1362</asp:ListItem>
                                                            <asp:ListItem Value="1363">1363</asp:ListItem>
                                                            <asp:ListItem Value="1364">1364</asp:ListItem>
                                                            <asp:ListItem Value="1365">1365</asp:ListItem>
                                                            <asp:ListItem Value="1366">1366</asp:ListItem>
                                                            <asp:ListItem Value="1367">1367</asp:ListItem>
                                                            <asp:ListItem Value="1368">1368</asp:ListItem>
                                                            <asp:ListItem Value="1369">1369</asp:ListItem>
                                                            <asp:ListItem Value="1370">1370</asp:ListItem>
                                                            <asp:ListItem Value="1371">1371</asp:ListItem>
                                                            <asp:ListItem Value="1372">1372</asp:ListItem>
                                                            <asp:ListItem Value="1373">1373</asp:ListItem>
                                                            <asp:ListItem Value="1374">1374</asp:ListItem>
                                                            <asp:ListItem Value="1375">1375</asp:ListItem>
                                                            <asp:ListItem Value="1376">1376</asp:ListItem>
                                                            <asp:ListItem Value="1377">1377</asp:ListItem>
                                                            <asp:ListItem Value="1378">1378</asp:ListItem>
                                                            <asp:ListItem Value="1379">1379</asp:ListItem>
                                                            <asp:ListItem Value="1380">1380</asp:ListItem>
                                                            <asp:ListItem Value="1381">1381</asp:ListItem>
                                                            <asp:ListItem Value="1382">1382</asp:ListItem>
                                                            <asp:ListItem Value="1383">1383</asp:ListItem>
                                                            <asp:ListItem Value="1384">1384</asp:ListItem>
                                                            <asp:ListItem Value="1385">1385</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ValidationGroup="form1" ID="cvBirthDate" runat="server" Display="None" ErrorMessage="تاریخ تولد را وارد نمایید" OnServerValidate="cvBirthDate_ServerValidate">*</asp:CustomValidator>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>ایمیل</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ایمیل*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtEmail" ErrorMessage="ایمیل را وارد نمایید" ID="RequiredFieldValidator6" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="form1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="ایمیل وارد شده صحیح نمی باشد" Display="None">*</asp:RegularExpressionValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>شماره تماس ثابت</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="شماره تماس ثابت*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtPhone" ErrorMessage="شماره تماس ثابت را وارد نمایید" ID="RequiredFieldValidator7" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ValidationGroup="form1" ID="RegularExpressionValidator2" runat="server" Display="none" ErrorMessage="شماره تماس ثابت را مقدار عددی وارد نمایید" ControlToValidate="txtPhone" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                                                </div>

                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>شماره همراه</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="شماره همراه*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtMobile" ErrorMessage="شماره همراه را وارد نمایید" ID="RequiredFieldValidator8" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ValidationGroup="form1" ID="RegularExpressionValidator3" runat="server" Display="none" ErrorMessage="شماره همراه را مقدار عددی وارد نمایید" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>وضعیت تاهل</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlMarriage" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">وضعیت تاهل</asp:ListItem>
                                                        <asp:ListItem Value="1">مجرد</asp:ListItem>
                                                        <asp:ListItem Value="2">متاهل</asp:ListItem>
                                                        <asp:ListItem Value="3">متارکه کرده</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form1" ID="cvMariage" runat="server" Display="None" ErrorMessage="وضعیت تاهل را وارد نمایید" OnServerValidate="cvMariage_ServerValidate">*</asp:CustomValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">تعداد فرزندان (متاهل)</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtChildren" runat="server" CssClass="form-control" placeholder="تعداد فرزندان (متاهل)"></asp:TextBox>
                                                </div>

                                            </div>
                                            <p class="clear"></p>
                                        </div>

                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">

                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>وضعیت اسکان</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlHome" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">وضعیت اسکان*</asp:ListItem>
                                                        <asp:ListItem Value="1">منزل والدین</asp:ListItem>
                                                        <asp:ListItem Value="2">منزل شخصی</asp:ListItem>
                                                        <asp:ListItem Value="3">استیجاری</asp:ListItem>
                                                        <asp:ListItem Value="4">غیره</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form1" ID="cvHome" runat="server" Display="None" ErrorMessage="وضعیت اسکان را وارد نمایید" OnServerValidate="cvHome_ServerValidate">*</asp:CustomValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>بیمه تامین اجتماعی هستید؟</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlInsurance" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0"> بیمه تامین اجتماعی هستید؟*</asp:ListItem>
                                                        <asp:ListItem Value="true"> بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form1" ID="cvInsu" runat="server" Display="None" ErrorMessage="وضعیت بیمه تامین اجتماعی را وارد نمایید" OnServerValidate="cvInsu_ServerValidate">*</asp:CustomValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">وضعیت نظام وظیفه (آقایان)</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlMilitary" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">وضعیت نظام وظیفه (آقایان)</asp:ListItem>
                                                        <asp:ListItem Value="1">انجام شده</asp:ListItem>
                                                        <asp:ListItem Value="2">معافیت تحصیلی</asp:ListItem>
                                                        <asp:ListItem Value="3">معافیت کفالت</asp:ListItem>
                                                        <asp:ListItem Value="4">معافیت پزشکی</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtAddress" Rows="5" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="آدرس*"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtAddress" ErrorMessage="آدرس را وارد نمایید" ID="RequiredFieldValidator9" runat="server" Display="None">*</asp:RequiredFieldValidator>


                                            <asp:Button ID="btnFinishForm1" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" ValidationGroup="form1" runat="server" OnClick="btnFinishForm1_Click" Text="مرحله بعد" CssClass="hvr-bounce-to-bottom" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlForm2" runat="server" Visible="False">
                <div class="container">
                    <div class="row top-padding4">
                        <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="form2" CssClass="alert alert-danger" runat="server" />
                    </div>
                </div>
                <div id="formPage">
                    <section class="top-padding4">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="skills">
                                        <ul>
                                            <li>
                                                <p class="pull-right">
                                                    فرم دعوت به همکاری 
                  <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#secondStep', '#FirstStep');">اطلاعات عمومی</span>
                                                    <i class="fa fa-arrow-left"></i>
                                                    <span class="activeColor">سوابق کاری و تحصیلی</span>

                                                </p>
                                                <p class="pull-left">40%</p>
                                                <div class="clearfix"></div>
                                            </li>
                                            <li class="progress">
                                                <div class="progress-bar base_color" data-width="40" style="width: 40%;"></div>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <!-- Main -->

                    <section class="top-padding4">
                        <div class="container">

                            <div class="row contact">

                                <div class="col-md-12">
                                    <div class="row careerForm">
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>تخصص</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlExpert" runat="server" AutoPostBack="True" Width="100%" CssClass="form-control" OnSelectedIndexChanged="ddlExpert_OnSelectedIndexChanged">
                                                        <asp:ListItem Value="0">تخصص*</asp:ListItem>
                                                        <asp:ListItem Value="1">بازاریابی</asp:ListItem>
                                                        <asp:ListItem Value="2">برنامه نویسی</asp:ListItem>
                                                        <asp:ListItem Value="3">فروش</asp:ListItem>
                                                        <asp:ListItem Value="4">پشتیبانی</asp:ListItem>
                                                        <asp:ListItem Value="5">سایر</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form2" ID="cvExpert" runat="server" Display="None" ErrorMessage="تخصص خود را وارد نمایید" OnServerValidate="cvExpert_ServerValidate">*</asp:CustomValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">تسلط به زبان انگلیسی</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlLang" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">تسلط به زبان انگلیسی</asp:ListItem>
                                                        <asp:ListItem Value="1">عالی</asp:ListItem>
                                                        <asp:ListItem Value="2">خوب</asp:ListItem>
                                                        <asp:ListItem Value="3">متوسط</asp:ListItem>
                                                        <asp:ListItem Value="4">ضعیف</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>

                                        <div class="rowdiv" id="txtexpertbox" style="display: none;">
                                            <div class="col-md-12 col-sm-12 col-xs-12 speacialrow">
                                                <div class="col-md-2 col-sm-4 col-xs-12 ">:تخصص</div>
                                                <div class="col-md-4 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtOtherExpert" runat="server" CssClass="form-control" placeholder="تخصص*"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12"></div>
                                            <p class="clear"></p>
                                        </div>

                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>مقطع تحصیلی</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlDegree" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">مقطع تحصیلی*</asp:ListItem>
                                                        <asp:ListItem Value="1">دکتری</asp:ListItem>
                                                        <asp:ListItem Value="2">کارشناسی ارشد</asp:ListItem>
                                                        <asp:ListItem Value="3">کارشناسی</asp:ListItem>
                                                        <asp:ListItem Value="4">کاردانی</asp:ListItem>
                                                        <asp:ListItem Value="5">دیپلم</asp:ListItem>
                                                        <asp:ListItem Value="6">زیر دیپلم</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form2" ID="cvDegree" runat="server" Display="None" ErrorMessage="مقطع تحصیلی خود را وارد نمایید" OnServerValidate="cvDegree_ServerValidate">*</asp:CustomValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>رشته تحصیلی</div>

                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtMajor" runat="server" CssClass="form-control" placeholder="رشته تحصیلی*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form2" ControlToValidate="txtMajor" ErrorMessage="رشته تحصیلی خود را وارد نمایید" ID="RequiredFieldValidator10" runat="server" Display="None">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">

                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">
                                                    :<span>*</span> میزان آشنایی با صنعت پخش
                                                </div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlIntroduce" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">
                                             
                                      میزان آشنایی با صنعت پخش*</asp:ListItem>
                                                        <asp:ListItem Value="1">خوب</asp:ListItem>
                                                        <asp:ListItem Value="2">متوسط</asp:ListItem>
                                                        <asp:ListItem Value="3">ضعیف</asp:ListItem>
                                                        <asp:ListItem Value="4">آشنایی ندارم</asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form2" ID="cvIntrod" runat="server" Display="None" ErrorMessage="میزان آشنایی خود با صنعت پخش را وارد نمایید" OnServerValidate="cvIntrod_ServerValidate">*</asp:CustomValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>چگونه با ورانگر آشنا شدید</div>

                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlIntroducrVaranegar" runat="server" Width="100%" CssClass="form-control"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlIntroducrVaranegar_OnSelectedIndexChanged">
                                                        <asp:ListItem Value="0">چگونه با ورانگر آشنا شدید</asp:ListItem>
                                                        <asp:ListItem Value="1">وب سایت ورانگر</asp:ListItem>
                                                        <asp:ListItem Value="2">توصیه دیگران</asp:ListItem>
                                                        <asp:ListItem Value="3">بنر های تبلیغاتی</asp:ListItem>
                                                        <asp:ListItem Value="4">جراید و روزنامه ها</asp:ListItem>
                                                        <asp:ListItem Value="5">دوستان</asp:ListItem>
                                                        <asp:ListItem Value="6">سایر</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form2" ID="cvIntroVaranegar" runat="server" Display="None" ErrorMessage="چگونه با ورانگر آشنا شدید" OnServerValidate="cvIntroVaranegar_ServerValidate">*</asp:CustomValidator>

                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv" id="txtFamiliar" style="display: none;">


                                            <div class="col-md-12 col-sm-12 col-xs-12 speacialrow">
                                                <div class="col-md-6 col-sm-6 col-xs-12"></div>
                                                <div class="col-md-2 col-sm-4 col-xs-12 ">:نحوه آشنایی با ورانگر</div>
                                                <div class="col-md-4 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtOhetFamiliar" runat="server" CssClass="form-control" placeholder="نحوه آشنایی با ورانگر*"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">با چه نرم افزارهایی آشنایی دارید</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtSw" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="با چه نرم افزارهایی آشنایی دارید"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">سوابق کاری</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtHistory" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="سوابق کاری"></asp:TextBox>
                                                </div>

                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-md-12">
                                            <asp:Button ID="btnPerviousFrom2" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" CausesValidation="False" runat="server" OnClick="btnPerviousFrom2_OnClick" Text="مرحله قبل" CssClass="hvr-bounce-to-bottom" />

                                            <asp:Button ID="btnFinishForm2" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" ValidationGroup="form2" runat="server" OnClick="btnFinishForm2_Click" Text="مرحله بعد" CssClass="hvr-bounce-to-bottom" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>

            </asp:Panel>
            <asp:Panel ID="pnlForm3" runat="server" Visible="false">

                <div class="formPage">
                    <section class="top-padding4">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="skills">
                                        <ul>
                                            <li>
                                                <p class="pull-right">
                                                    فرم دعوت به همکاری <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#ThirdStep', '#FirstStep');">اطلاعات عمومی</span>
                                                    <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#ThirdStep', '#secondStep');">سوابق کاری و تحصیلی </span>
                                                    <i class="fa fa-arrow-left"></i>
                                                    <span class="activeColor">همکاری با ورانگر</span>
                                                </p>
                                                <p class="pull-left">60%</p>
                                                <div class="clearfix"></div>
                                            </li>
                                            <li class="progress">
                                                <div class="progress-bar base_color" data-width="60" style="width: 60%"></div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <!-- Main -->

                    <section class="top-padding4">
                        <div class="container">
                            <div class="row contact">
                                <div class="col-md-12">
                                    <div class="row careerForm">
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">مايليد در زمان اضافه كار، كار كنيد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlOvertimeWork" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">مايليد در شيفت شب كار كنيد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlNightWork" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">مايليد به ماموريت‌هاي داخل كشور برويد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlmissionWork" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">مايليد در تعطيلات آخر هفته فعاليت داشته باشيد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlWeekendWork" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">آيا نقص عضو يا عمل جراحي يا بيماري دارید؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlSurgery" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">آيا سابقه محكوميت كيفري داشته‌ايد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlConviction" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">آيا دخانيات مصرفي مي‌كنيد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlSmoking" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-9 col-sm-9 col-xs-12 spanClass">آيا ضامن براي ضمانت كار خود داريد؟<span>*</span></div>
                                                <div class="col-md-3 col-sm-3 col-xs-12">
                                                    <asp:DropDownList ID="ddlWarranty" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="true">بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-md-12">
                                            <asp:Button ID="btnPerviousFrom3" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" CausesValidation="False" runat="server" OnClick="btnPerviousFrom3_OnClick" Text="مرحله قبل" CssClass="hvr-bounce-to-bottom" />

                                            <asp:Button ID="btnFinishForm3" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" ValidationGroup="form2" runat="server" OnClick="btnFinishForm3_Click" Text="مرحله بعد" CssClass="hvr-bounce-to-bottom" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlForm4" runat="server" Visible="false">

                <div class="container">
                    <div class="row top-padding4">
                        <asp:ValidationSummary ID="ValidationSummary3" ValidationGroup="form4" CssClass="alert alert-danger" runat="server" />
                    </div>
                </div>
                <div class="formPage">
                    <section class="top-padding4" id="ProgressBar4">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="skills">
                                        <ul>
                                            <li>
                                                <p class="pull-right">
                                                    فرم دعوت به همکاری 
                  <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#ForthStep', '#FirstStep');">اطلاعات عمومی</span>
                                                    <i class="fa fa-arrow-left"></i>

                                                    <span onclick="gotoNextStep('#ForthStep', '#secondStep');">سوابق کاری و تحصیلی 
                                                    </span>

                                                    <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#ForthStep', '#ThirdStep');">همکاری با ورانگر 
                                                    </span>

                                                    <i class="fa fa-arrow-left"></i>
                                                    <span class="activeColor">پرسش نهایی</span>

                                                </p>
                                                <p class="pull-left">80%</p>
                                                <div class="clearfix"></div>
                                            </li>
                                            <li class="progress">
                                                <div class="progress-bar base_color" data-width="80" style="width: 80%"></div>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                    <section class="top-padding4" id="lastProgressBar">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="skills">
                                        <ul>
                                            <li>
                                                <p class="pull-right">
                                                    فرم دعوت به همکاری 
                  <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#ForthStep', '#FirstStep');">اطلاعات عمومی</span>
                                                    <i class="fa fa-arrow-left"></i>

                                                    <span onclick="gotoNextStep('#ForthStep', '#secondStep');">سوابق کاری و تحصیلی 
                                                    </span>

                                                    <i class="fa fa-arrow-left"></i>
                                                    <span onclick="gotoNextStep('#ForthStep', '#ThirdStep');">همکاری با ورانگر 
                                                    </span>

                                                    <i class="fa fa-arrow-left"></i>
                                                    <span class="activeColor">پرسش نهایی</span>

                                                </p>
                                                <p class="pull-left">100%</p>
                                                <div class="clearfix"></div>
                                            </li>
                                            <li class="progress">
                                                <div class="progress-bar base_color" data-width="100" style="width: 100%"></div>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                    <section class="top-padding4">
                        <div class="container">
                            <div class="row contact">
                                <div class="col-md-12">
                                    <div class="row careerForm">
                                        <div class="rowdiv">

                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>نوع همکاری</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlWorkingType" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">نوع همکاری*</asp:ListItem>
                                                        <asp:ListItem Value="1">تمام وقت</asp:ListItem>
                                                        <asp:ListItem Value="2">ساعتی</asp:ListItem>
                                                        <asp:ListItem Value="3">پروژه ای</asp:ListItem>
                                                        <asp:ListItem Value="4">پیمانکاری</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ValidationGroup="form4" ID="cvWorkType" runat="server" Display="None" ErrorMessage="نوع همکاری خود را وارد نمایید" OnServerValidate="cvWorkType_ServerValidate">*</asp:CustomValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>تاریخ شروع همکاری</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">

                                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"
                                                        placeholder="تاریخ شروع همکاری*"></asp:TextBox>

                                                    <asp:CustomValidator ValidationGroup="form4" ID="cvStartDate" runat="server" Display="None" ErrorMessage="تاریخ شروع همکاری خود را وارد نمایید" OnServerValidate="cvStartDate_OnServerValidate">*</asp:CustomValidator>


                                                </div>

                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:<span>*</span>ميزان حقوق درخواستي (ريال)</div>

                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtSallary" runat="server" CssClass="form-control"
                                                        placeholder=" ميزان حقوق درخواستي (ريال)*"></asp:TextBox>

                                                    <asp:CustomValidator ID="cvSallaryEmpty" ValidationGroup="form4" runat="server"
                                                        ErrorMessage="ميزان حقوق درخواستي خود را وارد نمایید" Display="None"
                                                        OnServerValidate="cvSallaryEmpty_OnServerValidate">*</asp:CustomValidator>

                                                    <asp:CustomValidator ID="cvSalary" ValidationGroup="form4" runat="server"
                                                        ErrorMessage="میزان حقوق درخواستی را مقدار عددی وارد نمایید" Display="None"
                                                        OnServerValidate="cvSalary_OnServerValidate">*</asp:CustomValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">رزومه کاری</div>

                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:FileUpload ID="fuResume" runat="server" placeholder="رزومه" />
                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>


                                        <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                                            <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"
                                                TextMode="MultiLine" placeholder="توضیحات تکمیلی"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 col-sm-12 col-xs-12 form-group ">
                                            <div class="col-md-12 fileDiv">
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control"
                                                        placeholder="تصویر امنیتی*"></asp:TextBox>
                                                    <asp:CustomValidator ID="reCaptchaValid" ValidationGroup="form4" runat="server" ErrorMessage="عبارت امنیتی وارد شده صحیح نمی باشد" Display="None" OnServerValidate="reCaptchaValid_ServerValidate">*</asp:CustomValidator>


                                                    <asp:CustomValidator ID="cvCaptchaEmpty" ValidationGroup="form4" runat="server" ErrorMessage="عبارت امنیتی را وارد نمایید" Display="None" OnServerValidate="cvCaptchaEmpty_OnServerValidate">*</asp:CustomValidator>

                                                </div>

                                                <div class="col-md-4 col-sm-4 col-xs-12">
                                                    <asp:Image ID="imgCaptcha" ImageUrl="~/captcha/CaptchaGenerator.aspx" Width="100%" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-12 col-md-12">

                                            <asp:Button ID="btnPerviousFrom4" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" CausesValidation="False" runat="server" OnClick="btnPerviousFrom4_OnClick" Text="مرحله قبل" CssClass="hvr-bounce-to-bottom" />

                                            <asp:Button ID="btnFinishForm4" ValidationGroup="form4" runat="server" OnClick="btnFinishForm4_Click" Text="مرحله بعد" CssClass="hvr-bounce-to-bottom" OnClientClick="this.disabled = true; this.value = 'در حال پردازش اطلاعات ...';"
                                                UseSubmitBehavior="false" />

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </asp:Panel>
            
              <asp:Panel ID="pnlSuccess" runat="server" CssClass="alert alert-success" Visible="False">
                   
            <div class="container">
                <div class="row top-padding4">
                       اطلاعات شما با موفقیت ثبت گردید.
                  
                </div>
            </div>
                    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
