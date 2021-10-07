<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowCustomer.aspx.cs" Inherits="Varanegar.ShowCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                    </h2>
                    <p class="tagline">
                        <asp:Literal ID="ltText" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx"><i class="fa fa-circle"></i>خانه</a>
                        <a href="/customer"><i class="fa fa-angle-left"></i>مشتریان</a>
                        <span><i class="fa fa-angle-left"></i>
                            <asp:Literal ID="ltTitleHeader" runat="server"></asp:Literal>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="work-detail">
        <div class="container">
            <div class="row">
                <div class="col-md-8 project-description r-test">
                    <h4>توضیحات</h4>
                    <asp:Literal ID="ltHistory" runat="server"></asp:Literal>
                    <h4>استان های محل شعب</h4>
                    <ul class="r-feature">
                        <asp:Repeater ID="rptProv" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%# Eval("ProvinceName") %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="col-md-4 project-detail">
                    <div class="col-md-6 col-md-offset-3">
                         <asp:Image ID="imgCustomer" runat="server" />
                    </div>
                   <p class="clear"></p>
                    <h4>اطلاعات مشتری</h4>
                    <div class="column clearfix">
                        <h5 class="pull-right">نام مجموعه:</h5>
                        <p class="pull-right">
                            <asp:Literal ID="ltTitleAgain" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div class="column clearfix">
                        <h5 class="pull-right">تاریخ شروع استقرار:</h5>
                        <p class="pull-right">
                            <asp:Literal ID="ltStartDate" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div class="column clearfix">
                        <h5 class="pull-right">تاریخ پایان استقرار:</h5>
                        <p class="pull-right">
                            <asp:Literal ID="ltFinishDate" runat="server"></asp:Literal>
                        </p>
                    </div>
                    <div class="column clearfix">
                        <h5 class="pull-right">تعداد شعب:</h5>
                        <p class="pull-right">
                            <asp:Literal ID="ltBraanchNumber" runat="server"></asp:Literal>

                        </p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class=" link-navigation">
                        <div class="previous">
                            <asp:HyperLink ID="hlPerv" runat="server" CssClass="text-center  bounce-top">
                                <i class="fa fa-angle-left"></i>
                            </asp:HyperLink>قبلی
                        </div>
                        <div class="center-icon">
                            <a href="/customer" class="text-center"><i class="icon-grid"></i></a>
                        </div>
                        <div class="next">بعدی
                            <asp:HyperLink ID="hlNext" runat="server" CssClass="text-center  bounce-top">
                               <i class="fa fa-angle-right"></i>
                            </asp:HyperLink>
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
