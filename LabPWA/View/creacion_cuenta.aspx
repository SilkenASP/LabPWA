<%@ Page Language="C#" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <style>
        body{
            width:100%;
            max-width: 100%;
            height: 100%;
            max-height:100%;
            background-color: indigo;
        }
        #form1{
           width: 50%;
           margin-top: 2%;
           margin-left: 25%;
        }
        #contendor-principal{
            padding-top: 10%;
            max-width:100%;
        }

        #formulario{  
             border: 2px solid black;
             padding: 5%;
             border-radius: 25px;
             box-shadow: 10px 15px 20px black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid mb-5 py-5" id="contendor-principal">
             <h1 class="text-white display-1 py-5 text-center">Creacion de Cuenta</h1>
            <div class="container p-0 mb-5 w-100 bg-white rounded" id="formulario">

                <div class="row justify-content-center h5 pt-5">
                    <asp:Label Text="Correo" ID="Correolbl" CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="Correo" runat="server" />
                    </div>
                </div>
                
                <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Usuario" ID="Usuariolbl" CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="Usuario" runat="server" />
                    </div>
                </div>

                <div class="row justify-content-center h5">
                    <asp:Label Text="Contraseña" ID="Contraseñalbl" CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="password" runat="server" />
                    </div>
                </div>
                
                <div class="row justify-content-center h5 py-3">
                    <asp:Label Text="Confirmacion de Contraseña" ID="Confirmedlbl" CssClass="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-4 col-sm-12 col-xs-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="Confirmed" runat="server" />
                    </div>
                </div>
                <br />
                <div class="row justify-content-center">
                    <div class="col-xl-2 col-lg-2 col-md-4 col-sm-12 col-xs-12">
                        <asp:Button cssClass="btn btn-outline-danger btn-lg mb-5" Text="Cancelar" runat="server" />
                    </div>
                    <div class="col-xl-3 col-lg-4 col-sm-12 col-xs-12">
                        <asp:Button cssClass="btn btn-outline-success btn-lg mb-5" Text="crear una cuenta" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
