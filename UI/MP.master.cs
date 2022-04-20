using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class MP : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Usuario _unUsu = (Usuario)Session["Usuario"];
            if (!(Session["Usuario"] is EntidadesCompartidas.Usuario))
            {
                Response.Redirect("Principal.aspx");
            }
            lblNombUsu.Text = _unUsu.Nombre.ToString();
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }
}
