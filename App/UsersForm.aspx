<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersForm.aspx.cs" Inherits="App.UsersForm" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title>User Form</title>
</head>
<body>
    <div class="container">
        <form class="row g-3 bg-light" runat="server" method="post">
            <div class="bg-primary p-4 rounded mb-3 mt-3">
                <h1 class="text-center text-light">User Bonuses</h1>
            </div>

            <div class="col-md-6">
                <label for="customerName" class="form-label">Full name</label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblNameError" CssClass="text-danger" runat="server"></asp:Label>
            </div>

            <div class="col-md-6">
                <label for="customerId" class="form-label">ID Customer</label>
                <asp:TextBox ID="txtID" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="lblIDError" CssClass="text-danger" runat="server"></asp:Label>
            </div>

            <div class="col-md-6">
                <label for="customerEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                <asp:Label ID="lblEmailError" CssClass="text-danger" runat="server"></asp:Label>
            </div>

            <div class="col-md-6">
                <label for="customerPhone" class="form-label">Phone number</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="lblPhoneError" CssClass="text-danger" runat="server"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="reward" class="form-label">Reward</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                    <asp:ListItem>20% discount</asp:ListItem>
                    <asp:ListItem>10% discount</asp:ListItem>
                    <asp:ListItem>Free shipping</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-6">
                <label for="customerSearchID" class="form-label">Search Customers by ID:</label>
                <asp:TextBox ID="txtSearchID" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="row">
                <div class="col-4 text-start mt-3">
                    <asp:Button ID="btnSearchCustomer" CssClass="btn btn-secondary" runat="server" Text="Search Customers" OnClick="btnSearchCustomer_Click" />
                </div>
                <div class="col-4 text-center mt-3">
                    <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg" runat="server" Text="Submit" OnClick="Button1_Click" />
                </div>
                <div class="col-4 text-end mt-3">
                    <asp:Button ID="btnGenerateReport" CssClass="btn btn-secondary" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
