<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AgencyRequest.aspx.cs" Inherits="Varanegar.AgencyRequest" %>
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
    
       <section id="area-main" class="top-padding4">
                        <div class="container">
                            <div class="row contact">
                                <div class="col-md-12 col-sm-12 col-xs-12">

                                    <div class="row careerForm">
                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">نام شرکت(*):</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtFirstName" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="نام شرکت / موسسه(*)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtFirstName" ID="rfvName" runat="server" ErrorMessage="نام را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:شماره ثبت</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtLastName" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="شماره ثبت*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ControlToValidate="txtLastName" ValidationGroup="form1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام خانوادگی را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>

                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">

                                                <div class="col-md-4 col-sm-4 col-xs-12">:سال تاسیس(*)</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtFathedName" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="سال تاسیس(*)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtFathedName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="نام پدر را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <p class="clear"></p>
                                        </div>


                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:پست الکترونیک(*)</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtNationalSHID" ValidationGroup="form1" runat="server" CssClass="form-control" placeholder="پست الکترونیک(*)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtNationalSHID" ID="RequiredFieldValidator3" runat="server" ErrorMessage="شماره شناسنامه را وارد نمایید" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">


                                                <div class="col-md-4 col-sm-4 col-xs-12">:تلفن ثابت(*)</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtNationalID" runat="server" CssClass="form-control" placeholder="تلفن ثابت(*)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtNationalID" ErrorMessage="کد ملی را وارد نمایید" ID="RequiredFieldValidator4" runat="server" Display="None">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*محل تولد</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtBirthPlace" runat="server" CssClass="form-control" placeholder="محل تولد*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtBirthPlace" ErrorMessage="محل تولد را وارد نمایید" ID="RequiredFieldValidator5" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <p class="clear"></p>

                                        </div>

                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*تاریخ تولد</div>
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
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*ایمیل</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ایمیل*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtEmail" ErrorMessage="ایمیل را وارد نمایید" ID="RequiredFieldValidator6" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="form1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="ایمیل وارد شده صحیح نمی باشد" Display="None">*</asp:RegularExpressionValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*شماره تماس ثابت</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="شماره تماس ثابت*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtPhone" ErrorMessage="شماره تماس ثابت را وارد نمایید" ID="RequiredFieldValidator7" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <p class="clear"></p>
                                        </div>
                                        <div class="rowdiv">
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*شماره همراه</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="شماره همراه*"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ValidationGroup="form1" ControlToValidate="txtMobile" ErrorMessage="شماره همراه را وارد نمایید" ID="RequiredFieldValidator8" runat="server" Display="None">*</asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*وضعیت تاهل</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlMarriage" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">وضعیت تاهل</asp:ListItem>
                                                        <asp:ListItem Value="1">مجرد</asp:ListItem>
                                                        <asp:ListItem Value="2">متاهل</asp:ListItem>
                                                        <asp:ListItem Value="3">متارکه کرده</asp:ListItem>
                                                    </asp:DropDownList>
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

                                                <div class="col-md-4 col-sm-4 col-xs-12">:*وضعیت اسکان</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlHome" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0">وضعیت اسکان*</asp:ListItem>
                                                        <asp:ListItem Value="1">منزل والدین</asp:ListItem>
                                                        <asp:ListItem Value="2">منزل شخصی</asp:ListItem>
                                                        <asp:ListItem Value="3">استیجاری</asp:ListItem>
                                                        <asp:ListItem Value="4">غیره</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-12">
                                                <div class="col-md-4 col-sm-4 col-xs-12">:*بیمه تامین اجتماعی هستید؟</div>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:DropDownList ID="ddlInsurance" runat="server" Width="100%" CssClass="form-control">
                                                        <asp:ListItem Value="0"> بیمه تامین اجتماعی هستید؟*</asp:ListItem>
                                                        <asp:ListItem Value="true"> بلی</asp:ListItem>
                                                        <asp:ListItem Value="false">خیر</asp:ListItem>
                                                    </asp:DropDownList>
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


                                            <asp:Button ID="btnFinishForm1" OnClientClick="$('html,body').animate({ 'scrollTop': 0 }, 1000);" ValidationGroup="form1" runat="server" Text="مرحله بعد" CssClass="hvr-bounce-to-bottom" />
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
                    <p>
                        سال هاست بزرگان صنعت پخش با ما هستند.
                    </p>
                    <a class="btn-common bounce-top-black" href="/contact">با ما در تماس باشید</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
