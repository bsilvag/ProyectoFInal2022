using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Logueo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
    }

    protected void BtnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Usuario unUsu = Logica.LogicaUsuario.Logueo(TxtNombUsu.Text.Trim(), TxtPass.Text.Trim());
            if (unUsu != null)
            {
                Session["Usuario"] = unUsu;
                Response.Redirect("Principal.aspx");
            }
            else
                LblError.Text = "Datos Incorrectos";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}