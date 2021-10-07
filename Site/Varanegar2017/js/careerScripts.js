
function gotoNextStep(currentStep, NextStep) {
    $(currentStep).fadeOut('fast'); $(NextStep).slideDown('fast');
    $('html,body').animate({ 'scrollTop': 0 }, 1000);

}
function FindAndActiveEmptyInput(InputID, inputBadValue) {
    if (InputID.value == inputBadValue) {
        $(InputID).css('border', '1px solid #a94442');
    }
    else {
        $(InputID).css('border', '1px solid #d0d0d0');
    }
}
function FirstStepValidate() {
    var Firstname = document.getElementById('<%=txtFirstName.ClientID %>');
    var LastName = document.getElementById('<%=txtLastName.ClientID %>');
    var FathedName = document.getElementById('<%=txtFathedName.ClientID %>');
    var NationalSHID = document.getElementById('<%=txtNationalSHID.ClientID %>');
    var NationalID = document.getElementById('<%=txtNationalID.ClientID %>');
    var Year = document.getElementById('<%=ddlYear.ClientID %>');
    var Month = document.getElementById('<%=ddlMonth.ClientID %>');
    var Day = document.getElementById('<%=ddlDay.ClientID %>');
    var BirthPlace = document.getElementById('<%=txtBirthPlace.ClientID %>');
    var Email = document.getElementById('<%=txtEmail.ClientID %>');
    var Phone = document.getElementById('<%=txtPhone.ClientID %>');
    var Mobile = document.getElementById('<%=txtMobile.ClientID %>');
    var Marriage = document.getElementById('<%=ddlMarriage.ClientID %>');
    var Home = document.getElementById('<%=ddlHome.ClientID %>');
    var Insurance = document.getElementById('<%=ddlInsurance.ClientID %>');
    var Address = document.getElementById('<%=txtAddress.ClientID %>');

    if (Firstname.value == "" || LastName.value == "" || FathedName.value == ""
     || NationalSHID.value == "" || NationalID.value == "" || Year.value == "0"
        || Month.value == "0" || Day.value == "0" || BirthPlace.value == ""
        || Email.value == "" || Phone.value == "" || Mobile.value == "" || Marriage.value == "0"
        || Home.value == "0" || Insurance.value == "0" || Address.value == ""
       ) {
        $('html,body').animate({ 'scrollTop': 0 }, 1000);
        $('#errorDiv').slideDown('slow');

        FindAndActiveEmptyInput(Firstname, "");
        FindAndActiveEmptyInput(LastName, "");
        FindAndActiveEmptyInput(FathedName, "");
        FindAndActiveEmptyInput(NationalSHID, "");
        FindAndActiveEmptyInput(NationalID, "");
        FindAndActiveEmptyInput(Year, "0");
        FindAndActiveEmptyInput(Month, "0");
        FindAndActiveEmptyInput(Day, "0");
        FindAndActiveEmptyInput(BirthPlace, "");
        FindAndActiveEmptyInput(Email, "");
        FindAndActiveEmptyInput(Phone, "");
        FindAndActiveEmptyInput(Mobile, "");
        FindAndActiveEmptyInput(Marriage, "0");
        FindAndActiveEmptyInput(Home, "0");
        FindAndActiveEmptyInput(Address, "");
        FindAndActiveEmptyInput(Insurance, "0");




    }
    else {
        gotoNextStep('#FirstStep', '#secondStep');
    }

}
function SecondStepValidate() {
    var Expert = document.getElementById('<%=ddlExpert.ClientID %>');
    var Degree = document.getElementById('<%=ddlDegree.ClientID %>');
    var Major = document.getElementById('<%=txtMajor.ClientID %>');
    var Introduce = document.getElementById('<%=ddlIntroduce.ClientID %>');
    var IntroducrVaranegar = document.getElementById('<%=ddlIntroducrVaranegar.ClientID %>');


    if (Introduce.value == "0"
         || Expert.value == "0" || Degree.value == "0" || IntroducrVaranegar.value == ""
          || Major.value == "") {
        $('html,body').animate({ 'scrollTop': 0 }, 1000);
        $('#errorDiv2').slideDown('slow');

        FindAndActiveEmptyInput(Introduce, "0");
        FindAndActiveEmptyInput(Expert, "0");
        FindAndActiveEmptyInput(Degree, "0");
        FindAndActiveEmptyInput(IntroducrVaranegar, "");
        FindAndActiveEmptyInput(Major, "");
    }
    else {
        gotoNextStep('#secondStep', '#ThirdStep');
    }
}
function ThirdStepValidate() {
    var OvertimeWork = document.getElementById('<%=ddlOvertimeWork.ClientID %>');
    var NightWork = document.getElementById('<%=ddlNightWork.ClientID %>');
    var missionWork = document.getElementById('<%=ddlmissionWork.ClientID %>');
    var WeekendWork = document.getElementById('<%=ddlWeekendWork.ClientID %>');
    var Surgery = document.getElementById('<%=ddlSurgery.ClientID %>');
    var Conviction = document.getElementById('<%=ddlConviction.ClientID %>');
    var Smoking = document.getElementById('<%=ddlSmoking.ClientID %>');
    var Warranty = document.getElementById('<%=ddlWarranty.ClientID %>');

    if (OvertimeWork.value == "0"
         || NightWork.value == "0" || missionWork.value == "0" || WeekendWork.value == "0"
          || Surgery.value == "0"
        || Conviction.value == "0" || Smoking.value == "0"
          || Warranty.value == "0") {
        $('html,body').animate({ 'scrollTop': 0 }, 1000);
        $('#errorDiv3').slideDown('slow');

        FindAndActiveEmptyInput(OvertimeWork, "0");
        FindAndActiveEmptyInput(NightWork, "0");
        FindAndActiveEmptyInput(missionWork, "0");
        FindAndActiveEmptyInput(WeekendWork, "0");
        FindAndActiveEmptyInput(Surgery, "0");
        FindAndActiveEmptyInput(Conviction, "0");
        FindAndActiveEmptyInput(Smoking, "0");
        FindAndActiveEmptyInput(Warranty, "0");
    }
    else {
        gotoNextStep('#ThirdStep', '#ForthStep');

    }
}








function ForthStepValidate() {
    var Captcha = document.getElementById('<%=txtCaptcha.ClientID %>');
    var Sallary = document.getElementById('<%=txtSallary.ClientID %>');
    var WorkingType = document.getElementById('<%=ddlWorkingType.ClientID %>');
    var StartDate = document.getElementById('<%=txtStartDate.ClientID %>');



    if (Captcha.value == "" || Sallary.value == "" || WorkingType.value == "0" || StartDate.value == "") {
        $('html,body').animate({ 'scrollTop': 0 }, 1000);
        $('#errorDiv4').slideDown('slow');

        FindAndActiveEmptyInput(Captcha, "");
        FindAndActiveEmptyInput(Sallary, "");
        FindAndActiveEmptyInput(WorkingType, "0");
        FindAndActiveEmptyInput(StartDate, "");

        gotoNextStep('#careerInfo', '#ForthStep');
    }
    else {
        gotoNextStep('#careerInfo', '#ForthStep');

    }
}

function SuccessMessages() {
    $('#successDiv').slideDown('fast');
    $('#ProgressBar4').slideUp('fast');
    $('#lastProgressBar').slideDown('fast');
}