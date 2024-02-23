<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            height: 800px;
        }
    </style>
    
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Acceso a datos con sql</h1>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            
            <br />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </div>
        <div>
            <br />
            Nombre&nbsp
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            App&nbsp;
            <asp:TextBox ID="AppTxt" runat="server"></asp:TextBox>
            <br />
            Apm&nbsp;
            <asp:TextBox ID="ApmTxt" runat="server"></asp:TextBox>
            <br />
            Celular&nbsp;
            <asp:TextBox ID="CelularTxt" runat="server"></asp:TextBox>
            <br />
            Tel Oficina&nbsp;
            <asp:TextBox ID="TelTxt" runat="server"></asp:TextBox>
            <br />
            Correo Personal&nbsp;
            <asp:TextBox ID="CorreoTxt" runat="server"></asp:TextBox>
            <br />
            Correo Corp&nbsp;
            <asp:TextBox ID="CorreoCorTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Agregar Cliente" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="800px"></asp:ListBox>
            <br />
            <asp:Button ID="Button4" runat="server" Text="MostrarListaClientes" OnClick="Button4_Click" />

        </div>
    </form>
</body>
</html>
