<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="LabPWA.View.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 class="display-5 text-center py-4">Bienvenido al Historial</h1>
        <div class="container h5 p-5">
            <div class="row justify-content-center">
                <asp:GridView ID="grdTransacciones" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="886px">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    <Columns>
                        <asp:BoundField DataField="NumeroCuenta" HeaderText="Numero Cuenta" ReadOnly="true"/>
                        <asp:BoundField DataField="Accion" HeaderText="Accion" ReadOnly="true"/>
                        <asp:BoundField DataField="Monto" HeaderText="Monto" ReadOnly="true"/>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="true"/>
                        <asp:BoundField DataField="NuevoSaldo" HeaderText="Nuevo Saldo" ReadOnly="true"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
