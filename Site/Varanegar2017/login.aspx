<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Varanegar.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpage-banner" id="bloglistheaderImage">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2>
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                    </h2>
                    <p class="tagline">
                        <asp:Literal ID="ltbannerText" runat="server"></asp:Literal>
                    </p>
                </div>
                <div class="col-md-12 text-right">
                    <div class="other-page-link">
                        <a href="/default.aspx"><i class="fa fa-circle"></i>خانه</a>

                        <span><i class="fa fa-angle-left"></i>
                            ورود
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Blog Starts Here -->
    <section id="area-main" class="padding">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
            <div class="container">
                <div class="row loginpage">
                    <div class="col-md-8"></div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="ایمیل"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ایمیل وارد شده صحیح نمی باشد" ValidationGroup="l" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ایمیل را وراد نمایید" ValidationGroup="l" ControlToValidate="txtEmail" ForeColor="Red">*</asp:RequiredFieldValidator>


                            </div>
                            <label for="inputEmail3" class="col-sm-3 control-label">ایمیل:</label>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="کلمه عبور"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="کلمه عبور را وارد نمایید" ValidationGroup="l" ControlToValidate="txtPass" ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>
                            <label for="inputPassword3" class="col-sm-3 control-label">کلمه عبور:</label>

                        </div>

                        <div class="form-group">
                            <div class="col-sm-9">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-default floatright" OnClick="btnLogin_OnClick" ValidationGroup="l" Text="ورود" />
                                <%--                            <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-default" OnClick="Button1_OnClick" />--%>
                            </div>
                            <div class="col-sm-3">
                            </div>
                        </div>
                    </div>
                    <asp:CustomValidator ID="cvLogin" runat="server" ErrorMessage="نام کاربری یا کلمه عبور صحیح نمی باشد" ForeColor="Red" OnServerValidate="cvLogin_ServerValidate" ValidationGroup="l">*</asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger text-right directionRTL" ValidationGroup="l" />

                    <p class="clear"></p>
                </div>
            </div>
        </asp:Panel>
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
