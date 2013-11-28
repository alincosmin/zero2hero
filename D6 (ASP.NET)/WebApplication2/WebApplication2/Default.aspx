<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Mare smecherie de server</p>
            <asp:CheckBox ID="myCheckBox" Text="Show panel" runat="server" AutoPostBack="true" OnCheckedChanged="myCheckBox_CheckedChanged" />
            <asp:Panel ID="myPanel" runat="server">
                <asp:Label ID="myLabel" runat="server">Asta-i un textbox:</asp:Label>
                <asp:TextBox ID="myTextBox" runat="server" />
                <asp:Button Text="Label" ID="myButton" OnClick="myButton_Click" runat="server" />
                <asp:Button Text="Page title" ID="myButton2" OnClick="myButton2_Click" runat="server" />
                <asp:PlaceHolder id="myPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="myPlaceHolder2" runat="server"></asp:PlaceHolder>
                <br />
                <asp:PlaceHolder ID="myPlaceHolder3" runat="server"></asp:PlaceHolder>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
