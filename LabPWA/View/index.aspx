<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LabPWA.View.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" class=" py-5 my-5" runat="server">
        <div class="container-fluid" id="contendor-principal">
            <div class="container container p-3 mb-5 w-75 bg-white rounded text-center" id="formulario">
                <br />
                <div class="row justify-content-center h4 ">
                    <asp:Label Text="Correo o Usuario" ID="Userlbl" CssClass="col-xl-4 col-lg-4 col-md-3 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="TextBox2" runat="server" />
                    </div>
                </div>
                
                <div class="row justify-content-center h4 py-3">
                    <asp:Label Text="Contraseña" ID="passwordlbl" CssClass="col-xl-3 col-lg-3 col-md-3 col-sm-12 col-xs-12 col-form-label" runat="server" />
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                        <asp:TextBox cssClass="form-control form-text form-control-lg" ID="TextBox1" runat="server" />
                    </div>
                </div> 

                <br />
                <asp:Button cssClass="btn btn-outline-info btn-lg" Text="Login" runat="server" /> &nbsp;
                <asp:Button cssClass="btn btn-outline-success btn-lg" Text="crear una cuenta" runat="server" />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
