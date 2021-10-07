<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ShowBlog.aspx.cs" Inherits="Varanegar.ShowBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="innerpage-banner innerpage-bannerBlog" id="bloglistheaderImage">
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
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-sm-8 floatright">

                    <div class="col-md-4 floatright">
                        <asp:Image ID="imgBlog" runat="server" CssClass="img-responsive" Height="200px" />

                    </div>
                    <div class="col-md-8 floatright">
                        <h3>
                            <asp:Literal ID="ltBlogTitle" runat="server"></asp:Literal></h3>
                        <ul class="blog-author">
                            <li><a href="#"><i class="fa fa-user"></i>بازدید:
                                    <asp:Label ID="ltVisitnumb" runat="server" Text=""></asp:Label>
                            </a></li>

                            <li><a href="#"><i class="fa fa-clock-o"></i>
                                <asp:Label ID="ltDate" runat="server" Text=""></asp:Label>


                            </a></li>
                        </ul>
                    </div>

                    <div class="col-md-12 blog-item">

                        <div class="blog-content">

                            <asp:Literal ID="ltbody" runat="server"></asp:Literal>
                        </div>


                    </div>
                </div>

                <aside class="col-md-4 col-sm-4 floatright">

                    <%-- <div class="widget">
                        <h4>رستاک</h4>
                        <a href="http://www.rastaksoft.com/">
                        <img class="img-responsive" src="/images/Rastak-Banner-n.jpg" alt="رستاک">
                            </a>
                        <p>
گروه رستاک با پشتوانه تجربی ۱۰ ساله ورانگر در صنعت فروش و توزیع مویرگی در اردیبهشت ماه سال ۱۳۸۷ فعالیت خود را در زمینه طراحی و تولید نرم افزار فروش و پخش مویرگی آغاز نمود.                        </p>
                    </div>
                    --%>
                    <div class="widget">
                        <h4>گروه های اخبار</h4>
                        <ul class="category">
                            <asp:Repeater ID="rptCategory" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# Eval("BlogGroupName","/blog/{0}") %>'>
                                        <%# Eval("BlogGroupTitle") %>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                    <div class="widget">
                        <h4>پر بازدید ترین اخبار</h4>
                        <ul class="category">
                            <asp:Repeater ID="rptmostvisitBlogs" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="pull-right">
                                            <a class="nopadding" href="#">
                                                <a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>'>
                                                    <img src='<%# Eval("BlogImage","/uploads/blog/{0}") %>' height="70px" width="70px" alt='<%# Eval("BlogTitle") %>' />
                                                </a>
                                            </a>
                                        </div>
                                        <div class="pull-right">
                                            <a href='<%# String.Format("/blog/{0}/{1}", Eval("BlogGroupName"), Eval("BlogName")) %>' class="mr5">
                                                <%# Eval("BlogTitle") %>
                                            </a>
                                        </div>
                                        <div style="clear: both;"></div>

                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                </aside>

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
