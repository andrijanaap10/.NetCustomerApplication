﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="App.LoginForm" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
 <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
 <title>Agent Form</title>
</head>
<body>
    <div class ="container">
            <form class="row g-3 bg-light" runat="server" method="post" >
  <div class="mb-3">
    <label for="inputUsername" class="form-label">Username</label>
      <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
  </div>
  <div class="mb-3">
    <label for="inputPassword" class="form-label">Password</label>
      <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
  </div>
  
  <asp:Button ID="ButtonLogin" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="ButtonLogin_Click"/>
</form>
    </div>
    
  
</body>
</html>
