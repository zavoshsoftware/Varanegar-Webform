<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowSolution.aspx.cs" Inherits="Varanegar.ShowSolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="innerpage-banner" id="imageSectionDiv">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>
                        <asp:Literal ID="ltSolutionTitle" runat="server"></asp:Literal>
                    </h1>
                    <p class="tagline">
                        <asp:Literal ID="ltbannerText" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx"><i class="fa fa-circle"></i>خانه</a>
                        <a href="#"><i class="fa fa-angle-left"></i>راهکارها</a>
                        <span><i class="fa fa-angle-left"></i>
                            <a href="#">
                                <asp:Literal ID="ltTitleSolution" runat="server"></asp:Literal>

                            </a>

                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="responsive" class="padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 r-test">
                    <h3>مشکلات و نیازهای خاص 
                        <asp:Literal ID="ltProblemTitle" runat="server"></asp:Literal>
                    </h3>
                    <p>
                        <asp:Literal ID="ltProblem" runat="server"></asp:Literal>
                    </p>


                </div>

            </div>
        </div>
    </section>
    <section id="publication">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">

                    <h3 class="heading">
                        <span>مشتریان برگزیده
                            <asp:Literal ID="ltSolutionTitleCu" runat="server"></asp:Literal>
                        </span>

                    </h3>
                </div>
            </div>
            <div class="row">
              
                    <asp:Repeater ID="rptCustomers" runat="server">
                        <ItemTemplate>
                            <div class="col-md-2 solutionCustomer">
                                <img src='<%# Eval("ImgLogo","/Uploads/Customers/{0}") %>' alt='<%# Eval("CustomerTitle") %>'>
                                <h4>
                                    <a href='<%# Eval("CustomerName","/Customer/{0}") %>'>
                                        <%# Eval("CustomerTitle") %>
                                    </a>
                                </h4>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                
            </div>
        </div>
    </section>

</asp:Content>
