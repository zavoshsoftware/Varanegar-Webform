<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNewsLetterBox.ascx.cs" Inherits="Varanegar.Controls.UCNewsLetterBox" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:ValidationSummary CssClass="alert alert-danger" ValidationGroup="nl" ID="ValidationSummary1" runat="server" />
        <asp:Panel ID="pnlSuccess" Visible="false" CssClass="alert alert-success" runat="server">با تشکر، ایمیل شما با موفقیت ثبت گردید.</asp:Panel>
        <div class="input-group input-group-sm" id="nlBox"><span class="input-group-btn">
            <asp:LinkButton ID="lbNewsLetter" CssClass="btn" runat="server" OnClick="lbNewsLetter_Click" ValidationGroup="nl"><i class="fa fa-long-arrow-left"></i></asp:LinkButton></span><asp:TextBox ID="txtNewsletter" runat="server" CssClass="form-control" placeholder="ایمیل خود را وارد نمایید"></asp:TextBox><asp:RegularExpressionValidator ValidationGroup="nl" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" ErrorMessage="ایمیل وارد شده صحیح نمی باشد." ControlToValidate="txtNewsletter" Display="None">*</asp:RegularExpressionValidator>
<%--            <asp:CustomValidator ID="cvNewsletter" ValidationGroup="nl" runat="server" ErrorMessage="این ایمیل قبلا در خبرنامه ورانگر به ثبت رسیده است." Display="None" OnServerValidate="cvNewsletter_ServerValidate">*</asp:CustomValidator>--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="nl" runat="server" ErrorMessage="ایمیل خود را وارد نمایید" ControlToValidate="txtNewsletter" Display="None">*</asp:RequiredFieldValidator></div>
      <%--  <asp:Panel ID="pnlCaptcha" runat="server" Visible="false">
            <div class="input-group input-group-sm" id="captchaPanel"><span class="input-group-btn" style="width: 30%;">
                <asp:Image ID="imgCaptcha" runat="server" /></span><asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" placeholder="عبارت امنیتی مقابل را وارد نمایید"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="nl" runat="server" ErrorMessage="عبارت امنیتی را وارد نمایید" ControlToValidate="txtCaptcha" Display="None">*</asp:RequiredFieldValidator><asp:CustomValidator ID="cvCaptcha" ValidationGroup="nl" runat="server" ErrorMessage="عبارت امنیتی وارد شده صحیح نمی باشد." Display="None" OnServerValidate="cvCaptcha_ServerValidate">*</asp:CustomValidator></div>
        </asp:Panel>--%>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <img src="/images/loading_blue.gif" />
    </ProgressTemplate>
</asp:UpdateProgress>
