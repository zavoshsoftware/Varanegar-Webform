<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BlogList.aspx.cs" Inherits="Varanegar.BlogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function AddCurrentToPaging(currentMenu) {
            $('li.pageli').removeClass('activepage');
            $(currentMenu).addClass('activepage');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="innerpage-banner" id="bloglistheaderImage" style="background: url(/images/slide_1.jpg) no-repeat center center/cover;">
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
                        <a href="/blog"><i class="fa fa-angle-left"></i>اخبار و تازه ها</a>
                        <span><i class="fa fa-angle-left"></i>
                            <asp:Literal ID="lttitle" runat="server"></asp:Literal>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Blog Starts Here -->
    <section id="area-main" class="padding">
        <h4 class="hidden">hidden</h4>
        <div class="container">
            <div class="row">
                <article class="blog-wrap clearfix">
                    <asp:Repeater ID="rptBlogs" runat="server">
                        <ItemTemplate>
                            <div class="col-md-12 col-sm-12 col-xs-12 blogitem">
                                     <div class="col-md-9 blog-content-bg">
                                    <h3><a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>'><%# Eval("BlogTitle") %></a></h3>
                                    <ul class="blog-author">
                                        <li> <i class="fa fa-user"></i>بازدید:
                                            <span class="fontyekanNumbers">
                                             <%# Eval("visit") %> </span></li>

                                        <li> <i class="fa fa-clock-o"></i>
                                            <span class="fontyekanNumbers">
                                            <%# string.Format("{0:dd MMMM yy}",Eval("SubmitDate")) %></span>
                                             </li>
                                    </ul>
                                    <p>
                                        <%# Eval("summeryText") %>
                                    </p>
                                         <div class="text-right">
                                    <a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>' class="readmore bounce-top">ادامه مطلب</a>
                                </div></div>
                                

                                <div class="col-md-3 blog-content-pic">
                                 <a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>'>   <img src='<%# Eval("BlogImage","/uploads/blog/{0}") %>' alt='<%# Eval("BlogTitle") %>' class="img-responsive" height="420px"></a>
                                </div>
                           
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </article>
                
                
                 <div class="pagination-container clear-margin clearfix">

                            <!-- End.pagination-info -->
                            <ul class="pagination pull-right">
                                <asp:Repeater ID="rptPageNum" runat="server" OnItemDataBound="rptPageNum_ItemDataBound" OnItemCommand="rptPageNum_ItemCommand">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfPageID" runat="server" Value='<%# Eval("pageid") %>' />
                                        <li id='<%# Eval("pageid") %>' class="pageli">

                                            <asp:LinkButton ID="c" runat="server" CommandArgument='<%# Eval("pageid") %>' CssClass="active">
                                                <asp:Label ID="lblPageNum" runat="server" Text='<%# Eval("pageid") %>'></asp:Label>
                                            </asp:LinkButton>
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
