<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="myGridView" AllowPaging="true" AutoGenerateColumns="false" DataSourceID="myDataSrc" OnRowCommand="myGridView_RowCommand" runat="server">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Manager.Name" HeaderText="Manager" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
                <asp:TemplateField HeaderText="Admin">
                    <ItemTemplate>
                        <asp:Button Text="Edit" CommandName="myEdit" CommandArgument='<%# Eval("ID") %>' runat="server" />
                        <asp:Button Text="Delete" CommandName="myDelete" CommandArgument='<%# Eval("ID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="myDataSrc" TypeName="EmployeeService" SelectMethod="GetAll" runat="server" />
        <asp:Button Text="Add employee" OnClick="GoToAdd" runat="server" />
        <asp:Label ID="myLabel" runat="server" />
    </div>
    </form>
</body>
</html>
