<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="WebApplication1.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Tabla:
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
            </asp:GridView>

            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Cliente:
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp;
            Auto:
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp;
            Extra:
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp;
            Fallos:
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Actualizar" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
