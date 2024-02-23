<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="WebApplication1.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Operaciones en la tabla Diagnostico</h1>
        <br />

        <h2>Inserción</h2>
        <div>
            Asignación:
            <asp:DropDownList ID="DropDownListDiagnostico" runat="server">
            </asp:DropDownList>
            <br />
            Diagnóstico:
            <asp:TextBox ID="TextBoxDiagnostico" runat="server"></asp:TextBox>
            <br />
            Refacciones:
            <asp:TextBox ID="TextBoxRefacciones" runat="server"></asp:TextBox>
            <br />
            Costo Aproximado:
            <asp:TextBox ID="TextBoxCostoAprox" runat="server"></asp:TextBox>
            <br />
            Extra:
            <asp:TextBox ID="TextBoxExtra" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonInsertar" runat="server" Text="Insertar" OnClick="ButtonInsertar_Click" />
        </div>
        <br />
        <h2>Mostrar en GridView</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
            OnRowCommand="GridView1_RowCommand" DataKeyNames="iddiagnostico">
            <Columns>
                <asp:BoundField DataField="iddiagnostico" HeaderText=" ID Diagnóstico" ReadOnly="True" />
                <asp:BoundField DataField="asignaid" HeaderText="ID Asignación" />
                <asp:BoundField DataField="diagnostico" HeaderText="Diagnóstico" />
                <asp:BoundField DataField="refacciones" HeaderText="Refacciones" />
                <asp:BoundField DataField="costoAprox" HeaderText="Costo Aproximado" />
                <asp:BoundField DataField="extra" HeaderText="Extra" />
                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
            </Columns>
        </asp:GridView>
        <br />
        <h2>Eliminar</h2>
        <asp:Label ID="LabelEliminar" runat="server" Visible="False"></asp:Label>
        <br />
        <!-- Actualizar -->
        <h2>Actualizar</h2>
        <asp:Label ID="LabelActualizar" runat="server" Visible="False"></asp:Label>
    </form>
    </form>
</body>
</html>
