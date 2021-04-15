<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="EstadoCuenta.aspx.cs" Inherits="LabPWA.View.EstadoCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid bg-white">
            <h1 class="display-5 text-center py-4">Bienvenido al estado de la Cuenta</h1>

            <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Nombre" ID="nombrelbl" CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12 h5">
                        <asp:TextBox cssClass="form-control form-control-plaintext" Text ="Aqui va el nombre del cliente" ID="nombretxt" runat="server" />
                    </div>
            </div>
            <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Tipo De Cuenta" ID="tCuentalbl" CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12 h5">
                        <asp:TextBox cssClass="form-control form-control-plaintext" Text ="Aqui va el tipo de cuenta del cliente" ID="tCuentatxt" runat="server" />
                    </div>
            </div>
            <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Tasa de Interes" ID="Label3" CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12 h5">
                        <asp:TextBox cssClass="form-control form-control-plaintext" Text ="Tasa Pasiva" ID="tInterestxt" runat="server" />
                    </div>
            </div>
            <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Monto" ID="Label1" CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12 h5">
                        <asp:TextBox cssClass="form-control form-control-plaintext" Text ="$0.00" ID="TextBox1" runat="server" />
                    </div>
            </div>
            <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Estado De Cuenta" ID="estadolbl" CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12 h5">
                        <asp:TextBox cssClass="form-control form-control-plaintext" Text ="activo" ID="estadotxt" runat="server" />
                    </div>
            </div>
            <div class="row justify-content-center h5 pt-3 pb-5 ">
                    <asp:Label Text="Numero De Cuenta" ID="Label2" CssClass="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12 h5">
                        <asp:TextBox cssClass="form-control form-control-plaintext" Text ="Aqui va el numero de la cuenta del cliente" ID="TextBox2" runat="server" />
                    </div>
            </div>
        </div>
</asp:Content>
