<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowService.aspx.cs" Inherits="Varanegar.ShowService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="innerpage-banner" id="imageSectionDiv">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                    </h1>
                    <p class="tagline">
                        <asp:Literal ID="ltText" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx"><i class="fa fa-circle"></i>خانه</a>
                        <a href="#"><i class="fa fa-angle-left"></i>خدمات</a>
                        <span><i class="fa fa-angle-left"></i>
                            <asp:Literal ID="ltTitleHeader" runat="server"></asp:Literal>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="descSection ">
        <div class="container">
            <div class="row" id="servicedescBody">

                <asp:Literal ID="ltServiceDesc" runat="server"></asp:Literal>
            </div>
        </div>
    </section>

    <section>
        <div class="container">
            <asp:Repeater ID="rptServiceSteps" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 r-test">
                                <ul class="r-feature">
                                 <li>
                                     <h2>
                                     <a href='<%# String.Format("/Services/{0}/{1}", Eval("ServiceName"), Eval("ServiceStepName")) %>'><%# Eval("ServiceStepTitle") %></a>
                                </h2> </li>
                                </ul>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


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
                    <a class="btn-common bounce-top-black" href="/contactus.aspx">با ما در تماس باشید</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
