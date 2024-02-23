<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>manejo de tabla Automovil</h1>
            <br />
            <br />
            <h2>Insercion Automovil</h2>
            <br />
            Modelo:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Marca:
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1"></asp:DropDownList>
            <br />
            Año
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Color
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Placas
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Estado
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Agregar con Mysql Parameter" OnClick="Button2_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>

</body>
</html>
