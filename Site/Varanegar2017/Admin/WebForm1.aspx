<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Varanegar.Admin.WebForm1" %>
<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        jQuery.noConflict();
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <cc1:JQLoader ID="JQLoader1" runat="server">
                            </cc1:JQLoader>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <telerik:RadEditor ID="RadEditor1" runat="server"></telerik:RadEditor>
 
                            <cc1:JQDatePicker ID="JQDatePicker1" runat="server"></cc1:JQDatePicker>
</asp:Content>
