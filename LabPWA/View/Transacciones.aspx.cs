using DatabaseLayer.Model;
using LabPWA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabPWA.View
{
    public partial class Transacciones : System.Web.UI.Page
    {
        private readonly ICuenta db = new RCuenta();
        private Usuario LoggedUser;
        private List<String> cuentas = new List<string>();
        private int cuenta;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser = (Usuario)Session["LoggedUser"];
            if (!IsPostBack)
            {
                var cuentas = from item in LoggedUser.Cuenta
                              where item.Tipo != "Deposito a plazo"
                              select item;
                this.drpCuenta.DataSource = cuentas;
                this.drpCuenta.DataTextField = "Tipo";
                this.drpCuenta.DataValueField = "Tipo";
                this.drpCuenta.DataBind();
            }
        }

        protected async void btnDepositar_Click(object sender, EventArgs e)
        {
            if (float.Parse(this.montotxt.Text) == 0)
            {
                string script = string.Format("alert('{0}');", "La cantidad a retirar es invalida");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }

            float monto = float.Parse(this.montotxt.Text);
            var index = this.drpCuenta.SelectedIndex;
            var resp = await db.Depositar(LoggedUser.Cuenta.ToList()[index], monto,1);
            if (resp.IsSuccess)
            {
                Session["LoggedUser"] = resp.Result;
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                Response.Redirect("EstadoCuenta.aspx");
            }
            else
            {
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void btnRetirar_Click(object sender, EventArgs e)
        {
            RetirarDinero();
        }
        private async void RetirarDinero()
        {
            if (float.Parse(this.montotxt.Text)==0)
            {
                string script = string.Format("alert('{0}');", "La cantidad a retirar es invalida");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }
            int Estado = 1;
            float monto = float.Parse(this.montotxt.Text);
            int index = this.drpCuenta.SelectedIndex;
            ConfigurationClass oConf;
            var respu = db.ValidarMinimo(LoggedUser.Cuenta.ToList()[index], monto);
            if (!respu.IsSuccess)
            {
                //Preguntar si desea proseguir, si desea proseguir, cambiar Estado a 0
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "confirmClient()", true);
                //var proseguir = this.HiddenField1.ClientID;
                //if (bool.Parse(proseguir))
                //{
                //    Estado = 0;
                //}
                //else
                //{
                //    return;
                //}
                Estado = 0;
            }
            try
            {
                oConf = new ConfigurationClass
                {
                    RetiroDiario = float.Parse(Session["RetiroDiario"].ToString()),
                    UltimoRetiro = DateTime.Parse(Session["UltimoRetiro"].ToString())
                };
            }
            catch (Exception ex)
            {
                Session["RetiroDiario"] = 0;

                oConf = new ConfigurationClass
                {
                    RetiroDiario = 0,
                    UltimoRetiro = DateTime.Now
                };
            }
            var resp = await db.Retirar(monto, oConf, LoggedUser.Cuenta.ToList()[index], Estado);
            if (resp.IsSuccess)
            {
                Session["RetiroDiario"] = double.Parse(Session["RetiroDiario"].ToString()) + monto;
                Session["UltimoRetiro"] = DateTime.Now;
                Session["LoggedUser"] = resp.Result;
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                //Mostrar el error
                string script = string.Format("alert('{0}');", resp.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void drpCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.cuenta = (sender as DropDownList).SelectedIndex;
                if (drpCuenta.SelectedValue == "Cuenta corriente")
                {
                    this.btnRetirar.Enabled = false;
                }
                else
                {
                    this.btnRetirar.Enabled = true;
                }
            }
        }
    }
}