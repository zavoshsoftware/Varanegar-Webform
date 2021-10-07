<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="AgentRequests.aspx.cs" Inherits="Varanegar.Admin.AgentRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvSetting" runat="server">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnReturn" runat="server" Text="بازگشت" CssClass="btn btn-warning" OnClick="btnReturn_Click" CausesValidation="false" />

            <br />
            <br />

            <asp:Panel ID="pnlEmptyForm" runat="server" Visible="false">
                <p class="alert alert-danger">اطلاعاتی جهت نمایش موجود نمی باشد.</p>
            </asp:Panel>
            <asp:GridView ID="grdTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grdTable_RowCommand" Width="100%" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdTable_PageIndexChanging">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="نام" />
                    <asp:BoundField DataField="Email" HeaderText="ایمیل" />
                    <asp:BoundField DataField="Mobile" HeaderText="موبایل" />
                    <asp:BoundField DataField="RegisterDate" HeaderText="تاریخ ثبت" />
                    <asp:TemplateField HeaderText="توضیحات">
                        <ItemTemplate>

                            <i class="fa fa-edit"></i>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="DoDetail" CssClass="lb">مشاهده جزییات</asp:LinkButton>
                            <br />
                            <i class="fa fa-times"></i>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="DoDelete" CssClass="lb">حذف</asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </asp:View>
        <asp:View ID="vwEdit" runat="server">
            <div class="FormView">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">مشخصات کلی</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group col-md-4">
                            <label>نام</label>
                            <asp:Label ID="lblName" runat="server" CssClass="form-control"></asp:Label>

                        </div>
                        <div class="form-group col-md-4">
                            <label>شماره ملی</label>
                            <asp:Label ID="lblNationalCode" runat="server" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>شماره شناسنامه</label>
                            <asp:Label ID="lblBirthCerId" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>صادره از</label>
                            <asp:Label ID="lblBirthCerPlace" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>



                        <div class="form-group col-md-4">
                            <label>شهر</label>
                            <asp:Label ID="lblCity" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>


                        <div class="form-group col-md-4">
                            <label>کد پستی</label>
                            <asp:Label ID="lblPostalCode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>پست الکترونیک</label>
                            <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>شماره تلفن ثابت</label>
                            <asp:Label ID="lblPhone" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>تلفن همراه</label>
                            <asp:Label ID="lblMobile" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>




                        <div class="form-group col-md-12">
                            <label>آدرس</label>
                            <asp:Label ID="lblAddress" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">اطلاعات شرکت</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group col-md-4">
                            <label>نام شرکت</label>
                            <asp:Label ID="lblCompanyName" runat="server" CssClass="form-control"></asp:Label>

                        </div>
                        <div class="form-group col-md-4">
                            <label>تلفن شرکت</label>
                            <asp:Label ID="lblCompanyPhone" runat="server" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>مالکیت</label>
                            <asp:Label ID="lblCompanyOwnership" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>آدرس شرکت</label>
                            <asp:Label ID="lblCompanyAddress" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>



                        <div class="form-group col-md-4">
                            <label>کد پستی</label>
                            <asp:Label ID="lblCompanyPostalCode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>


                        <div class="form-group col-md-4">
                            <label>مساحت فضای کاری</label>
                            <asp:Label ID="lblArea" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>تعداد کارکنان</label>
                            <asp:Label ID="lblEmployee" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>


                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">سوابق کاری</h3>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">مورد 1</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group col-md-4">
                                    <label>نام محل کار</label>
                                    <asp:Label ID="lblplaceName1" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>نوع صنعت</label>
                                    <asp:Label ID="lblIndustry1" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>از سال</label>
                                    <asp:Label ID="lblStartdate1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>تا سال</label>
                                    <asp:Label ID="lblFinishDate1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>سمت</label>
                                    <asp:Label ID="lblPost1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>توضیحات</label>
                                    <asp:Label ID="lbljobDesc1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlJob2" runat="server" Visible="false">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">مورد 2</h3>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group col-md-4">
                                        <label>نام محل کار</label>
                                        <asp:Label ID="lblplaceName2" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>نوع صنعت</label>
                                        <asp:Label ID="lblIndustry2" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>از سال</label>
                                        <asp:Label ID="lblStartdate2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>تا سال</label>
                                        <asp:Label ID="lblFinishDate2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>سمت</label>
                                        <asp:Label ID="lblPost2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>توضیحات</label>
                                        <asp:Label ID="lbljobDesc2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlJob3" runat="server" Visible="false">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">مورد 3</h3>
                                </div>
                                <div class="panel-body">

                                    <div class="form-group col-md-4">
                                        <label>نام محل کار</label>
                                        <asp:Label ID="lblplaceName3" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>نوع صنعت</label>
                                        <asp:Label ID="lblIndustry3" runat="server" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>از سال</label>
                                        <asp:Label ID="lblStartdate3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>تا سال</label>
                                        <asp:Label ID="lblFinishDate3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>سمت</label>
                                        <asp:Label ID="lblPost3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>توضیحات</label>
                                        <asp:Label ID="lbljobDesc3" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                                    </div>

                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>



                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">اطلاعات تکمیلی</h3>
                    </div>
                    <div class="panel-body">


                        <div class="form-group col-md-4">
                            <label>آیا تا کنون در زمینه فروش نرم افزار فعالیت نموده اید؟</label>
                            <asp:Label ID="lblSoftwareBefore" runat="server" CssClass="form-control"></asp:Label>
                            <asp:Label ID="lblSoftwareBeforeDesc" runat="server" CssClass="form-control"></asp:Label>

                        </div>
                        <div class="form-group col-md-4">
                            <label>آیا در حال حاضر نمایندگی یا عاملیت فروش از سایر شرکت ها می باشید ؟</label>
                            <asp:Label ID="lblIsAgent" runat="server" CssClass="form-control"></asp:Label>
                            <asp:Label ID="lblIsAgentDesc" runat="server" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>آیا دارای مکان اداری یا تجاری برای ارائه خدمات خود هستید؟</label>
                            <asp:Label ID="lblCommercialPlace" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                            <asp:Label ID="lblCommercialPlaceDesc" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>آیا در حال حاضر بیمه هستید؟</label>
                            <asp:Label ID="lblInsurance" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>آیا دسترسی به اینترنت پر سرعت دارید؟</label>
                            <asp:Label ID="lblInternet" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>

                        <div class="form-group col-md-4">
                            <label>میزان آشنایی با نرم افزار های ورانگر پیشرو؟</label>
                            <asp:Label ID="lblVaranegarSoftwareIntroduce" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>


                        <div class="form-group col-md-4">
                            <label>نحوه آشنایی شما با شرکت ورانگر؟</label>
                            <asp:Label ID="lblHowKnowUs" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                        <div class="form-group col-md-4">
                            <label>دلایل اصلی شما برای علاقهمندی به فعالیت به عنوان عاملیت فروش؟</label>
                            <asp:Label ID="lblReason" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>



                <asp:Button ID="btnCancel" runat="server" Text="بازگشت" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="false" />

            </div>
        </asp:View>
        <asp:View ID="vwDelete" runat="server">
            آیا مایل به حذف 
            <asp:Label ID="lblDelete" runat="server" Text="Label"></asp:Label>
            هستید؟
            <asp:Button ID="btnYes" runat="server" Text="بلی" OnClick="btnYes_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnNo" runat="server" Text="خیر" OnClick="btnNo_Click" CssClass="btn btn-warning" />

        </asp:View>

    </asp:MultiView>
</asp:Content>
