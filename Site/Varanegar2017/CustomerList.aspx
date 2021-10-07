<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Varanegar.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>مشتریان موفق ورانگر
                    </h1>
                    <p class="tagline">
                        ورانگر از دیرباز در تلاش بوده تا با تولید و ارایه نرم افزارهای تخصصی فروش و توزیع مویرگی در کنار مشتریان خود قرار گرفته و با پیشرفت آنان بر خود بالیده و موفقیت خود را نیز در گرو پویایی آنان می داند. 
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            مشتریان
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="portfolio" class="portfolio_3 padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12 customerDesc">
                    <p>
                    ورانگر از دیرباز در تلاش بوده تا با تولید و ارایه نرم افزارهای تخصصی فروش و توزیع مویرگی در کنار مشتریان خود قرار گرفته و با پیشرفت آنان بر خود بالیده و موفقیت خود را نیز در گرو پویایی آنان می داند. <br/>
در اختیار داشتن ابزارهای تخصصی مفید و مورد نیاز مشتریان باعث گردیده تا کنترل فرایندهای مدیریت پخش ساده تر انجام گیرد و سهم بازار بیشتری را از آن خود نمایند.
               </p>
                         </div>
            </div>
            <div class="row">
                <div class="col-md-12">
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
        </div>
        <div class="project-wrapper clearfix custometlist">
            <asp:Repeater ID="rptCustomers" runat="server">
                <ItemTemplate>
                    <figure class='<%# Eval("CustomerGroupName","mix work-item {0}") %>'>
                        <img src='<%# Eval("ImgLogo","/Uploads/Customers/{0}") %>' height="150px" width="150px" alt='<%# Eval("CustomerTitle") %>'>
                        <a class="overlay text-center" href='<%# Eval("CustomerName","/Customer/{0}") %>' <%--'<%# Eval("CustomerName","/Customer/{0}") %>'--%>>
                            <div class="overlay-inner">
                                <h4><%# Eval("CustomerTitle") %></h4>
                            </div>
                        </a>
                    </figure>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </section>
    <!--  End Our Works -->



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
