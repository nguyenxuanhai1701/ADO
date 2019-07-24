<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ODPNET.aspx.cs" Inherits="ADO.ODPNET" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ODPNET</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="EmpNM" runat="server" Text="Employee Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmpNM" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="ReqEmpNM" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Employee's name is required" ControlToValidate="txtEmpNM"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegexEmpNM" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Employee's name is invalid"  ControlToValidate="txtEmpNM" ValidationExpression="[a-z]{1,10}"></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="txtGender" runat="server" Width="128px">
                            <asp:ListItem Selected="True">Choose gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Salary" runat="server" Text="Salary"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="ReqTxtSalary" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Employee's salary is required" ControlToValidate="txtSalary"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="txtSalary" ForeColor="Red" Display="Dynamic" ErrorMessage="Salary must be a number"></asp:CompareValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" Width="67px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Mess" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <div>
                <asp:DataGrid ID="dtg" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateColumn HeaderText="STT">
                            <ItemTemplate>
                                <asp:Label ID="STT" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="EmployeeID" HeaderText="Employee ID" ReadOnly="true"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Name" HeaderText="Name" ReadOnly="true"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Gender" HeaderText="Gender" ReadOnly="true"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Salary" HeaderText="Salary" ReadOnly="true"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
    </form>
</body>
</html>
