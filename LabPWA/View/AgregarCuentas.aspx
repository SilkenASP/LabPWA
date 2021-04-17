<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarCuentas.aspx.cs" Inherits="LabPWA.View.AgregarCuentas" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-5">

            <div>
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
</asp:Content>

