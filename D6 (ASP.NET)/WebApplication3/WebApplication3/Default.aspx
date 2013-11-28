<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="myButton" text="Mare buton" runat="server" OnClick="myButton_Click"/>
    <br />
    <asp:Label ID="myLabel" runat="server"></asp:Label>
    <br />
    <asp:HyperLink id="myLink" NavigateUrl="About.aspx" Text="Link sme'" runat="server" />
    <asp:Button ID="myButton2" Text="Redirect" runat="server" OnClick="myButton2_Click" />
    </div>
    </form>
</body>
</html>
