using DatabaseLayer.Model;
using DatabaseLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabPWA.View
{
    public partial class RegisterUserWebForm : System.Web.UI.Page
    {
        private readonly IUsuario db = new RUsuario();
        private string tipoCuenta;
        private Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Usuario item = new Usuario
            {
                clave = this.txtClave.Text,
                Nombre = this.txtNombre.Text,
                Username = this.txtUsername.Text,
                Cuenta = new List<Cuenta>(),
                Transaccion = new List<Transaccion>()
            };
            Cuenta oCuenta = new Cuenta
            {
                Activo = 1,
                Interes = float.Parse(this.txtTasaInteres.Text),
                Saldo = float.Parse(this.txtSaldoInicial.Text),
                NumeroCuenta = rnd.Next(100) + item.Nombre.Substring(0, 3) + rnd.Next(100),
                Tipo = this.DropDownList1.SelectedValue.ToString()
            };
            Transaccion oTransaccion = new Transaccion
            {
                Accion = "Inicio de cuenta",
                Fecha = DateTime.Now,
                Monto = float.Parse(this.txtSaldoInicial.Text),
                NuevoSaldo = float.Parse(this.txtSaldoInicial.Text),
                NumeroCuenta = oCuenta.NumeroCuenta
            };
            item.Cuenta.Add(oCuenta);
            item.Transaccion.Add(oTransaccion);
            var resp = db.RegisterUser(item);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoCuenta = (sender as DropDownList).SelectedValue;
            if (tipoCuenta == "Cuenta de ahorros")
            {
                this.Label2.Visible = true;
                this.txtSaldoInicial.Visible = true;
                this.txtSaldoInicial.Text = "0";
            }
            else
            {
                this.Label2.Visible = false;
                this.txtSaldoInicial.Visible = false;
                this.txtSaldoInicial.Text = "0";
            }
        }
    }
}