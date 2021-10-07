<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Varanegar.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type='text/javascript'>
        var counter = 1;
        function addInput(divName) {
            var cc = counter + 1;
            var newdiv = document.createElement('div');
            newdiv.innerHTML = "Entry " + (counter + 1) + " <br><asp:TextBox ID='txtInput' runat='server'></asp:TextBox>";
            document.getElementById(divName).appendChild(newdiv);
            counter++;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dynamicInput">
            Entry 1<br />
            <input type="text" name="myInputs[]" />
        </div>
        <input type="button" value="Add another text input" onclick="addInput('dynamicInput');" />
    </form>
</body>
</html>
