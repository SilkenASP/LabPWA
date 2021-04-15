using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabPWA.View
{
    public partial class Historial : System.Web.UI.Page
    {
        private Usuario LoggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser = (Usuario)Session["LoggedUser"];
            this.grdTransacciones.DataSource = LoggedUser.Transaccion;
            this.grdTransacciones.DataBind();
        }
    }
}