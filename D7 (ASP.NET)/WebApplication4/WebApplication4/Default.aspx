<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Repeater ID="myRepeater" runat="server">
            <HeaderTemplate>
                <table class="tabel">
                    <thead>
                        <tr>
                            <th>First name</th>
                            <th>Last name</th>
                            <th>City</th>
                            <th>Department</th>
                            <th>Salary</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                        <tr>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("City") %></td>
                            <td><%# Eval("Department") %></td>
                            <td><%# Eval("Salary") %></td>
                        </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="9" 
             DataSourceID="employeesDataSource" CssClass="tabel">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="employeesDataSource" TypeName="WebApplication4.EmployeeService" 
            SelectMethod="GetAll" runat="server">

            
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
