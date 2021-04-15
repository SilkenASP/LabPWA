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
    public partial class index : System.Web.UI.Page
    {
        private readonly IUsuario db = new RUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ///Llamar al metodo login, pide usuario y contraseña como parametro, utilizar el objeto db.Login
            ///
            var resp = db.Login(this.nCuentaTxt.Text, this.TextBox1.Text);
            if (resp.IsSuccess)
            {
                Session["LoggedUser"] = resp.Result;
                Response.Redirect("EstadoCuenta.aspx");
            }
            else
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUserWebForm.aspx");
        }
    }
}