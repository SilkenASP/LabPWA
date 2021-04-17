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
        private string tiempo;
        private float interes;
        private readonly IUsuario db = new RUsuario();
        private string tipoCuenta;
        private Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (float.Parse(this.txtSaldoInicial.Text) <= 0 && this.DropDownList1.SelectedValue != "Cuenta corriente")
            {
                return;
            }
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
                Interes = this.txtSaldoInicial.Text == "0" ? 0.15f : float.Parse(this.txtSaldoInicial.Text) < 60000 && float.Parse(this.txtSaldoInicial.Text) > 20000 ? 0.35f : 0.5f,
                Saldo = this.txtSaldoInicial.Text == "0" ? 0 : float.Parse(this.txtSaldoInicial.Text),
                NumeroCuenta = rnd.Next(100) + item.Nombre.Substring(0, 3) + rnd.Next(100),
                Tipo = this.DropDownList1.SelectedValue.ToString()
            };
            if (this.DropDownList1.SelectedValue.Equals("Deposito a plazo"))
            {
                oCuenta.TiempoVigencia = this.drpIntereses.SelectedItem.Text;
                oCuenta.Interes = float.Parse(this.drpIntereses.SelectedValue.ToString());
            }
            if (oCuenta.Tipo == "Cuenta corriente")
            {
                oCuenta.Interes = 0;
            }
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
            var resp = await db.RegisterUser(item);
            if (resp.IsSuccess)
            {
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                Response.Redirect("index.aspx");
            }
            else
            {
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
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
                this.Label2.Visible = true;
                this.txtSaldoInicial.Visible = true;
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
                tiempo = this.drpIntereses.SelectedItem.Text;
                interes = float.Parse(this.drpIntereses.SelectedItem.Value.ToString());
            }
        }
    }
}