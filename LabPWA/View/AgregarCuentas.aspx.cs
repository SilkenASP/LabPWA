using DatabaseLayer.Model;
using DatabaseLayer.Repository;
using LabPWA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabPWA.View
{
    public partial class AgregarCuentas : System.Web.UI.Page
    {
        private readonly ICuenta db = new RCuenta();
        private string tipoCuenta;
        private Random rnd = new Random();
        private Usuario LoggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser = (Usuario)Session["LoggedUser"];
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var itemSelected = this.DropDownList1.SelectedValue;
            var cantidad = from item in LoggedUser.Cuenta
                           where item.Tipo.Equals(itemSelected)
                           select item;
            if (cantidad.Count()>0)
            {
                ///Lanzar una excepcion porque el usuario ya posee esa cuenta
                return;
            }
            Cuenta oCuenta = new Cuenta
            {
                Activo = 1,
                Interes = float.Parse(this.txtTasaInteres.Text),
                Saldo = float.Parse(this.txtSaldoInicial.Text),
                NumeroCuenta = rnd.Next(100) + LoggedUser.Nombre.Substring(0, 3) + rnd.Next(100),
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
            LoggedUser.Cuenta.Add(oCuenta);
            LoggedUser.Transaccion.Add(oTransaccion);
            db.Post(oCuenta, LoggedUser,oTransaccion);
            //var resp = db.RegisterUser(LoggedUser);
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