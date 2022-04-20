using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EntidadesCompartidas;
using Logica;
using System.Collections.Generic;


public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;

        try
        {
            DateTime _hoy = DateTime.Now;

            List<EntidadesCompartidas.Pronostico> _lista = Logica.LogicaPronostico.ListarPronosticoxDia(_hoy);

            GridView.DataSource = _lista;
            GridView.DataBind();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}