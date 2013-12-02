<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="WebApplication5.Employees1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="empPanel" runat="server">
        <asp:Label Text="Name:   " runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red" runat="server" />
        <asp:RegularExpressionValidator ControlToValidate="txtName" ErrorMessage="**" ForeColor="Orange" ValidationExpression="[A-Z][a-z]+(( |-)[A-Z][a-z]+)*" runat="server" />
        <br />
        <asp:Label Text="Salary:   " runat="server" />
        <asp:TextBox ID="txtSal" type="number" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="txtSal" ErrorMessage="*" ForeColor="Red" runat="server" />
        <asp:RegularExpressionValidator ControlToValidate="txtSal" ErrorMessage="**" ForeColor="Orange" ValidationExpression="0|([1-9][0-9]*)" runat="server" /> 
        <br />
        <asp:Label Text="Manager:   " runat="server" />
        <asp:DropDownList ID="ddlMgr" runat="server" />
        <br />
        <asp:Button ID="saveBtn" Text="Add employee" OnClick="Save_Click" runat="server" />
        <asp:Button Text="Cancel" OnClick="Cancel" runat="server" />
        <br />
        <asp:Label ID="myLabel1" Text="*&nbsp; - Required" ForeColor="Red" runat="server" />
        <br />
        <asp:Label ID="myLabel2" Text="** - Invalid format" ForeColor="Orange" runat="server" />
       
    </asp:Panel>
    </div>
    </form>
</body>
</html>
