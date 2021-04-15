using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabPWA.View
{
    public partial class EstadoCuenta : System.Web.UI.Page
    {
        private Usuario LoggedUser;
        private float totalSaldo=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser = (Usuario)Session["LoggedUser"];
            this.txtNombre.Text = LoggedUser.Nombre;
            this.grdCuentas.DataSource = LoggedUser.Cuenta;
            this.grdCuentas.DataBind();
            foreach (var item in LoggedUser.Cuenta)
            {
                totalSaldo += float.Parse(item.Saldo.ToString());
            }
            this.txtSaldoTotal.Text = "$"+totalSaldo.ToString();
        }
    }
}