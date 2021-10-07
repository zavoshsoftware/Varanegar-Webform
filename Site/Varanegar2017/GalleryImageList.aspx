<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GalleryImageList.aspx.cs" Inherits="Varanegar.GalleryImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="imageSectionDiv" style="background: url(/images/slide_1.jpg) no-repeat center center/cover;">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>رسانه ورانگر
                    </h1>

                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx">
                            <i class="fa fa-circle"></i>خانه
                        </a>
                        <span><i class="fa fa-angle-left"></i>
                            رسانه ورانگر</span>
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
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="work-filter">
                        <ul class="text-center">
                            <li><a href="javascript:;" data-filter=".videoGroup" class="filter">ویدئو ها</a></li>
                            <li><a href="javascript:;" data-filter=".imageGroup" class="filter">تصاویر</a></li>
                            <li><a href="javascript:;" data-filter="all" class="active filter">همه</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="project-wrapper clearfix">
       
                <asp:Repeater ID="rptVideos" runat="server">
                    <ItemTemplate>
                        <figure class="mix work-item galleryBox videoGroup">
                            <img src='<%# Eval("ImageUrl","/Uploads/Gallery/{0}") %>' alt='<%# Eval("Title") %>'>
                            <a class="overlay text-center" href='<%# Eval("Id","/gallery/{0}") %>'>
                                <div class="overlay-inner">
                                    <h4><%# Eval("Title") %></h4>
                                </div>
                            </a>
                        </figure>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptImages" runat="server">
                    <ItemTemplate>
                        <figure class="mix work-item galleryBox imageGroup">
                            <img src='<%# Eval("ImageUrl","/Uploads/Gallery/{0}") %>' alt='<%# Eval("Title") %>'>
                            <a class="overlay text-center" href='<%# Eval("Id","/gallery/{0}") %>'>
                                <div class="overlay-inner">
                                    <h4><%# Eval("Title") %></h4>
                                </div>
                            </a>
                        </figure>
                    </ItemTemplate>
                </asp:Repeater>
              

            
        </div>
    </section>
</asp:Content>
