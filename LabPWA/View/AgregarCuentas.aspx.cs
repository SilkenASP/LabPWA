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
    public struct Intereses
    {
        public string Tiempo { get; set; }
        public string interes { get; set; }
    }
    public partial class AgregarCuentas : System.Web.UI.Page
    {
        private readonly ICuenta db = new RCuenta();
        private string tipoCuenta;
        private Random rnd = new Random();
        private Usuario LoggedUser;
        private float interes;
        private string tiempo;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser = (Usuario)Session["LoggedUser"];
            if (!IsPostBack)
            {
                List<Intereses> intereses = new List<Intereses>
            {
                new Intereses
                {
                    Tiempo="30 dias",
                    interes= "0.25"
                },
                new Intereses
                {
                    Tiempo="60 dias",
                    interes= "0.250"
                },
                new Intereses
                {
                    Tiempo="90 dias",
                    interes= "0.2500"
                },
                new Intereses
                {
                    Tiempo="120 dias",
                    interes= "0.25000"
                },
                new Intereses
                {
                    Tiempo="150 dias",
                    interes= "0.5"
                },
                new Intereses
                {
                    Tiempo="180 dias",
                    interes= "0.50"
                },
                new Intereses
                {
                    Tiempo="360 dias",
                    interes= "0.500"
                }
            };
                this.drpIntereses.DataSource = intereses;
                this.drpIntereses.DataTextField = "Tiempo";
                this.drpIntereses.DataValueField = "interes";
                this.drpIntereses.DataBind();
            }
        }

        protected async void btnRegister_Click(object sender, EventArgs e)
        {
            var itemSelected = this.DropDownList1.SelectedValue;
            var cantidad = from item in LoggedUser.Cuenta
                           where item.Tipo.Equals(itemSelected) && item.Tipo != "Deposito a plazo"
                           select item;
            if (cantidad.Count() > 0)
            {
                ///Lanzar una excepcion porque el usuario ya posee esa cuenta
                string script = string.Format("alert('El usuario ya posee una cuenta del tipo : {0}');", itemSelected);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }
            Cuenta oCuenta = new Cuenta
            {
                Activo = 1,
                Interes = this.drpIntereses.Visible ? float.Parse(this.drpIntereses.SelectedValue) : float.Parse(this.txtSaldoInicial.Text) < 20000 ? 0.15f : float.Parse(this.txtSaldoInicial.Text) < 60000 ? 0.35f : 0.5f,
                Saldo = float.Parse(this.txtSaldoInicial.Text),
                NumeroCuenta = rnd.Next(100) + LoggedUser.Nombre.Substring(0, 3) + rnd.Next(100),
                Tipo = this.DropDownList1.SelectedValue.ToString(),
                TiempoVigencia = this.drpIntereses.SelectedItem.Text
            };
            if (oCuenta.Tipo == "Cuenta corriente")
            {
                oCuenta.Interes = 0;
            }
            if (oCuenta.Saldo > 0)
            {
                oCuenta.Activo = 1;
            }
            else
            {
                oCuenta.Activo = 0;
            }
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
            var resp = await db.Post(oCuenta, LoggedUser, oTransaccion);
            if (resp.IsSuccess)
            {
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                Response.Redirect("EstadoCuenta.aspx");
            }
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
                this.lblintereses.Visible = false;
                this.drpIntereses.Visible = false;
            }
            else if (tipoCuenta == "Cuenta corriente")
            {
                this.Label2.Visible = false;
                this.txtSaldoInicial.Visible = false;
                this.txtSaldoInicial.Text = "0";
                this.lblintereses.Visible = false;
                this.drpIntereses.Visible = false;
            }
            else
            {
                this.Label2.Visible = true;
                this.txtSaldoInicial.Visible = true;
                this.txtSaldoInicial.Text = "0";
                this.lblintereses.Visible = true;
                this.drpIntereses.Visible = true;
            }
        }

        protected void drpIntereses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                tiempo = this.drpIntereses.SelectedItem.Value.ToString();
                interes = float.Parse(this.drpIntereses.SelectedValue.ToString());
            }
        }
    }
}