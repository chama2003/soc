<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierregister.aspx.cs" Inherits="webform.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Registration</title>
    
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
         <div class="form-container">
             <asp:Label ID="Label1" runat="server" Text="Full Name"></asp:Label>
             <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
             <asp:Label ID="Label4" runat="server" Text="Contact Number"></asp:Label>
             <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
             <asp:Label ID="Label5" runat="server" Text="Enter new pin "></asp:Label>
             <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
             <asp:Label ID="Label6" runat="server" Text="Confirm pin "></asp:Label>
             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" Text="Add supplier" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
