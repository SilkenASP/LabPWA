<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUserWebForm.aspx.cs" Inherits="LabPWA.View.RegisterUserWebForm" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <style>
        body {
            width: 100%;
            max-width: 100%;
            height: 100%;
            max-height: 100%;
            background-color: indigo;
        }

        #form1 {
            width: 96%;
            height: 50%;
            margin-left: 2%;
            margin-top: 3%;
            border-radius: 1%;
            box-shadow: 10px 15px 20px black;
            background-color: #fff;
        }

        #contendor-principal {
            padding-top: 10%;
            max-width: 100%;
        }

        #formulario {
            border: 2px solid black;
            padding: 5%;
            border-radius: 25px;
            box-shadow: 10px 15px 20px black;
        }
    </style>
</head>
<body>
    <form id="form1" class="m-5" runat="server">
        <div class="container p-5">

            <div>
                <br />
                <div class="row">
                    <asp:Label ID="Label1" CssClass="col-6" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="txtNombre" CssClass="col-6" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="Label4" CssClass="col-6" runat="server" Text="Usuario: "></asp:Label>
                    <asp:TextBox ID="txtUsername" CssClass="col-6" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="Label5" CssClass="col-6" runat="server" Text="Clave: "></asp:Label>
                    <asp:TextBox ID="txtClave" CssClass="col-6" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="Label6" CssClass="col-6" runat="server" Text="Seleccione su tipo de cuenta:"></asp:Label>
                    <asp:DropDownList AutoPostBack="true" ID="DropDownList1" CssClass="col-6" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>Cuenta corriente</asp:ListItem>
                        <asp:ListItem>Cuenta de ahorros</asp:ListItem>
                        <asp:ListItem>Deposito a plazo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="Label2" CssClass="col-6" runat="server" Text="Saldo inicial:" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtSaldoInicial" Text="0" CssClass="col-6" runat="server" Visible="false"></asp:TextBox>
                </div>
                <br />
                <div class="row">
                    <asp:Label ID="lblintereses" CssClass="col-6" Visible="false" runat="server" Text="Tiempo"></asp:Label>
                    <asp:DropDownList ID="drpIntereses" CssClass="col-6" AutoPostBack="true" Visible="false" runat="server" OnSelectedIndexChanged="drpIntereses_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <br />
                <div class="row">
                    <asp:Button ID="btnRegister" CssClass="btn btn-success" runat="server" Text="Registrar" OnClick="btnRegister_Click" />
                </div>
            </div>

        </div>
    </form>

</body>
</html>
