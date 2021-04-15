<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="LabPWA.View.Transacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5 text-center pt-4">Bienvenido A la Seccion de movimientos de la cuenta Bancaria</h1>
    <div class = "container">
            <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="monto" ID="montolbl" CssClass="col-xl-1 col-lg-1 col-md-1 col-sm-12 col-xs-12 col-form-label pt-3" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="montotxt" runat="server" />
                    </div>
            </div>

            <div class="row justify-content-center">
                    <div class="col-xl-1 col-lg-1 col-md-4 col-sm-12 col-xs-12">
                        <asp:Button cssClass="btn btn-outline-danger btn-lg mb-5" Text="retiro" runat="server" />
                    </div>
                    <div class="col-xl-2 col-lg-2 col-sm-12 col-xs-12">
                        <asp:Button cssClass="btn btn-outline-success btn-lg mb-5" Text="abono" runat="server" />
                    </div>
            </div>

        </div>
</asp:Content>
