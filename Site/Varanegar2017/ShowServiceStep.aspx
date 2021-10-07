<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowServiceStep.aspx.cs" Inherits="Varanegar.ShowServiceStep" %>

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


                        <asp:HyperLink ID="hlService" runat="server">
                            <i class="fa fa-angle-left"></i>
                            <asp:Literal ID="ltlhlServiceTitle" runat="server"></asp:Literal>
                        </asp:HyperLink>

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
 <%--   <asp:Panel ID="pnlPhone" runat="server" Visible="False">
        <section id="facts">
            <div class="container-fluid">
                <div class="row number-counters phonenumb">
                    <!-- first count item -->
                    <div class="col-md-3 col-sm-3 col-xs-12 text-center">
                        <div class="counters-item newcolor row">
                            <strong>
                                <asp:Literal ID="lt_gp1_P1" runat="server"></asp:Literal>
                                </strong>
                            <ul>
                                <li><i class="fa fa-phone"></i> <asp:Literal ID="lt_gp1_P2" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-mobile"></i> <asp:Literal ID="lt_gp1_P3" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-envelope"></i>
                                    <asp:HyperLink ID="hl_gp1_P4" runat="server"></asp:HyperLink>
                                   </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-12 text-center">
                        <div class="counters-item purple row">
                         <strong>
                                <asp:Literal ID="lt_gp2_P1" runat="server"></asp:Literal>
                                </strong>
                                <ul>
                                <li><i class="fa fa-phone"></i> <asp:Literal ID="lt_gp2_P2" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-mobile"></i> <asp:Literal ID="lt_gp2_P3" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-envelope"></i>
                                    <asp:HyperLink ID="hl_gp2_P4" runat="server"></asp:HyperLink>
                                   </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-12 text-center">
                        <div class="counters-item pink row">
                                  <strong>
                                <asp:Literal ID="lt_gp3_P1" runat="server"></asp:Literal>
                                </strong>
                                <ul>
                                <li><i class="fa fa-phone"></i> <asp:Literal ID="lt_gp3_P2" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-mobile"></i> <asp:Literal ID="lt_gp3_P3" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-envelope"></i>
                                    <asp:HyperLink ID="hl_gp3_P4" runat="server"></asp:HyperLink>
                                   </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-12 text-center">
                        <div class="counters-item green row">
                                 <strong>
                                <asp:Literal ID="lt_gp4_P1" runat="server"></asp:Literal>
                                </strong>
                                <ul>
                                <li><i class="fa fa-phone"></i> <asp:Literal ID="lt_gp4_P2" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-mobile"></i> <asp:Literal ID="lt_gp4_P3" runat="server"></asp:Literal> </li>
                                <li><i class="fa fa-envelope"></i>
                                    <asp:HyperLink ID="hl_gp4_P4" runat="server"></asp:HyperLink>
                                   </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>--%>

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
