<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowProduct.aspx.cs" Inherits="Varanegar.ShowProduct" %>

<%@ Register Src="~/Controls/UCOtherBrand.ascx" TagPrefix="uc1" TagName="UCOtherBrand" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="imageSectionDiv">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Literal ID="ltProTitle" runat="server"></asp:Literal></h1>
                    <p class="tagline">
                        <asp:Literal ID="ltbannerText" runat="server"></asp:Literal></p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link"><a href="/default.aspx"><i class="fa fa-circle"></i>خانه</a><i class="fa fa-angle-left"></i><h2>
                        <asp:HyperLink ID="hlProductGroup" runat="server">
                            <asp:Literal ID="ltlProGroupID" runat="server"></asp:Literal></asp:HyperLink></h2>
                        <span><i class="fa fa-angle-left"></i>
                            <asp:Literal ID="ltProTitle2" runat="server"></asp:Literal></span></div>
                </div>
            </div>
        </div>
    </section>
    <section id="responsive" class="padding">
        <div class="container">
            <div class="row progroupPage">
                <div class="col-md-8 col-sm-8 r-test prosection proTitle">
                    <h3>
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h3>
                    <asp:Panel ID="pnlNoData" CssClass="alert alert-danger" Visible="false" runat="server">اطلاعاتی جهت نمایش موجود نمی باشد.</asp:Panel>
                    <p>
                        <asp:Literal ID="ltDesc" runat="server"></asp:Literal></p>
                </div>
                <div class="col-md-4 col-sm-4 r-test prosection proTitle">
                    <div class="widget">
                        <div class="list-group">
                            <a href="#" class="list-group-item active">محصولات</a>
                            <div class="accordion" id="accordion2">
                                <asp:Repeater ID="rptProductGroup" runat="server" OnItemDataBound="rptProductGroup_OnItemDataBound">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfProgroupID" Value='<%# Eval("ProductGroupID") %>' runat="server" />
                                        <div class="accordion-heading collapseClass"><a href='<%# Eval("ProductGroupName","/Product/{0}") %>'><%# Eval("ProductGroupTitle") %></a><a style="float: left" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href='<%# Eval("ProductGroupID","#{0}") %>'><i class="fa fa-arrow-down" onclick="if($(this).hasClass('fa-arrow-up')) {$(this).removeClass('fa-arrow-up'); $(this).addClass('fa-arrow-down')}else if($(this).hasClass('fa-arrow-down')){$(this).removeClass('fa-arrow-down'); $(this).addClass('fa-arrow-up')};"></i></a></div>
                                        <div id='<%# Eval("ProductGroupID") %>' class="accordion-body collapse">
                                            <asp:Repeater ID="rptProducts" runat="server">
                                                <ItemTemplate>
                                                    <div class="accordion-inner"><a href='<%# String.Format("/Product/{0}/{1}", Eval("ProductGroupName"), Eval("ProductName")) %>' class="list-group-item"><%# Eval("ProductTitle") %></a></div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="widget">
                        <h4>درباره ما</h4>
                        <img class="img-responsive" src="/images/varanegarteam.jpg" alt="شرکت ورانگر">
                        <p>ورانگر اولین و معتبرترین تولیدکننده نرم افزارهای تخصصی فروش و پخش مویرگی بعنوان پیشکسوت نرم افزاری در حوزه پخش، متمایزترین محصولات و خدمات را ارایه نموده که بسیاری از بزرگان صنعت مذکور از این خدمات استفاده می نمایند.</p>
                    </div>
                    <uc1:UCOtherBrand runat="server" ID="UCOtherBrand" />
                </div>
            </div>
        </div>
    </section>
    <section class="we-do bg-grey padding ProductWhiteBox">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>نرم افزارهای مرتبط</h2>
                    <div class="service-slider owl-carousel">
                        <asp:Repeater ID="rptPro" runat="server">
                            <ItemTemplate>
                                <div class="item white-box text-center">
                                    <img src='<%# Eval("ProductImage_Thumb","/Uploads/Product/Thumbs/{0}") %>' height="115px" width="100%" alt='<%# Eval("ProductTitle") %>' />
                                    <h4><a href='<%# String.Format("/product/{0}/{1}", Eval("ProductGroupName"), Eval("ProductName")) %>'><%# Eval("ProductTitle") %></a></h4>
                                    <p><%# Eval("ProductSumery") %></p>
                                    <a href='<%# String.Format("/product/{0}/{1}", Eval("ProductGroupName"), Eval("ProductName")) %>' class="readmore">مشاهده محصول</a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
