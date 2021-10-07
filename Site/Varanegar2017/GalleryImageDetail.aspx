<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GalleryImageDetail.aspx.cs" Inherits="Varanegar.GalleryImageDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="imageSectionDiv" style="background: url(/images/slide_1.jpg) no-repeat center center/cover;">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Literal ID="ltProTitle" runat="server"></asp:Literal></h1>
                    <p class="tagline">
                        <asp:Literal ID="ltbannerText" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx">
                            <i class="fa fa-circle"></i>خانه
                        </a>
                        <a href="/gallery">
                            <i class="fa fa-circle"></i>گالری
                        </a>
                        <span><i class="fa fa-angle-left"></i>
                            <asp:Literal ID="ltTitle2" runat="server"></asp:Literal></span>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:Panel ID="pnlVideo" runat="server">
        <section id="responsive" class="padding">
            <div class="container">
                <div class="row progroupPage">
                    <div class="col-md-8 col-sm-8 r-test prosection proTitle">
                        <h2>
                            <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h2>
                        <p>
                            <asp:Literal ID="ltDesc" runat="server"></asp:Literal>
                            <asp:Image ID="imgDesc" runat="server" />
                        </p>
                    </div>
                    <div class="col-md-4 col-sm-4 r-test prosection proTitle">
                        <div class="widget">
                            <div class="list-group">
                                <a href="#" class="list-group-item active">دسته بندی مطالب</a>
                                <div class="accordion" id="accordion2">
                                    <asp:Repeater ID="rptGalleryGroup" runat="server">
                                        <ItemTemplate>
                                            <div class="accordion-heading collapseClass">
                                                <a href="/gallery">
                                                    <%# Eval("Title") %>
                                                </a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>

    <asp:Panel ID="pnlImage" runat="server">


        <section id="grid-layout" class="top-padding">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <div class="zerogrid">
                            <div class="wrap-container">
                                <div class="wrap-content clearfix">
                                    <asp:Repeater ID="rptImages" runat="server">
                                        <ItemTemplate>
                                            <div class="col-md-4">
                                                <div class="wrap-col">
                                                    <div class="item-container">
                                                        <a class="fancybox" href='<%# Eval("ImageUrl","/Uploads/Gallery/{0}") %>' data-fancybox-group="gallery">
                                                            <div class="overlay text-center">
                                                                <div class="overlay-inner">
                                                                    <h4>'<%# Eval("Title") %>'</h4>
                                                                    <div class="line"></div>
                                                                    <p>'<%# Eval("summery") %>'</p>
                                                                </div>
                                                            </div>
                                                            <img src='<%# Eval("ImageUrl","/Uploads/Gallery/{0}") %>' alt='<%# Eval("Title") %>' style="max-width: 300px;" /></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <p class="clear"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

      <%--  <section id="portfolio" class="portfolio_3 padding">
            <div class="project-wrapper clearfix custometlist">

                <asp:Repeater ID="rptImages" runat="server">
                    <ItemTemplate>
                        <figure class="mix work-item galleryBox image">
                            <img src='<%# Eval("ImageUrl","/Uploads/Gallery/{0}") %>' height="150px" width="150px" alt='<%# Eval("Title") %>'>
                            <a class="overlay text-center" href='<%# Eval("Id","/gallery/{0}") %>'>
                                <div class="overlay-inner">
                                    <h4><%# Eval("Title") %></h4>
                                </div>
                            </a>
                        </figure>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>--%>
    </asp:Panel>
    <script src="/js/jquery-2.1.4.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/js/jquery-countTo.js"></script>
    <script src="/js/jquery.appear.js"></script>
    <script src="/js/owl.carousel.min.js"></script>
    <script src="/js/jquery.fancybox.js"></script>
    <script src="/js/popup.js"></script>
    <script src="/js/functions.js"></script>
</asp:Content>
