<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Consulta con dataset en bd Mysql</h1>

        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Width="500px" Height="60px" BorderColor="red" BackColor="Bisque" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Consultas de datatable a un dataset" OnClick="Button1_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="Bisque" HeaderStyle-BackColor="WhiteSmoke" Width="500px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True" OnPageIndexChanging="GridView1_PageIndexChanging"></asp:GridView>

        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Generar Multiples consultas ds" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="700px" BorderColor="Red" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Width="700px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" BackColor="Beige"></asp:GridView>
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Incremental" Width="600px"  BackColor="Chocolate" height="300px" OnClick="Button3_Click" />
        <br />
        <br />
        MANIPULAR DATOS DE UN DATATABLE, SACAR CORREOS PERSANALES DE LOS CLIENTES
        <br />
        <asp:Button ID="Button4" runat="server" Text="OBTENER CORREOS" OnClick="Button4_Click" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" ></asp:DropDownList>
        <br />

        <br />
        AGREGAR UN NUEVO ROW DE 
        <br />
        <br />
        Id cliente: 
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp &nbsp &nbsp
        Nombre:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        &nbsp &nbsp &nbsp
        Apellido paterno:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <br />
        Apellido Materno:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="Crear un nuevo data row" Width="300px"  OnClick="Button5_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Width="900px"></asp:Label>
        <br />
        <asp:GridView ID="GridView3" runat="server" OnPageIndexChanging="GridView3_PageIndexChanging" OnSelectedIndexChanged="GridView3_SelectedIndexChanged"></asp:GridView>
        <div>
        </div>

    </form>
</body>
</html>
