<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="Varanegar.SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="careerbanner">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>جست و جو
                    </h2>
                    <p class="tagline">
                        <asp:Literal ID="ltSearchQuery" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            جست و جو
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Responsive image with left -->
    <section id="responsive" class="padding aboutsec">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 searchBoxList">
                    <asp:Panel ID="pnlEmpty" Visible="False" CssClass="alert alert-danger" runat="server">
                        رکوردی برای عبارت جست و جو شده یافت نشد.
                    </asp:Panel>
                    <asp:Panel ID="pnlSearchBox" DefaultButton="btnSearch" runat="server">
                    <div class="col-md-2">
                        <asp:Button ID="btnSearch" runat="server" Text="جست و جو" CssClass="btn btn-submit" OnClick="btnSearch_OnClick" />
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="عبارت مورد نظر خود را اینجا وارد نمایید."></asp:TextBox>
                    </div>
                        <p class="clear"></p>
                    </asp:Panel>

                    <ul>
                        <asp:Repeater ID="rptSearchResult" runat="server">
                            <ItemTemplate>
                                <li>
                                    <span>
                                    <%# Container.ItemIndex + 1 %> - &nbsp;</span>
                                    <a href='<%# Eval("UrlAddress") %>'><%# Eval("Title") %></a>
                                    <br />
                                    <span class="smalltext">
                                    <%# Eval("SmallText") %>
                                    </span>
                                    <hr />
                                </li>
                            </ItemTemplate>

                        </asp:Repeater>
                    </ul>
                </div>

            </div>
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
                    <a class="btn-common bounce-top-black" href="/contact">با ما در تماس باشید</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
