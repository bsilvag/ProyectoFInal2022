using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
public partial class ListadoPronosticodia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            
            DateTime _FechaHora = Convert.ToDateTime(clnFechaProno.SelectedDate);
            List<EntidadesCompartidas.Pronostico> _lista = Logica.LogicaPronostico.ListarPronosticoxDia(_FechaHora);
            GVPronosticos.DataSource = _lista;
            GVPronosticos.DataBind();

        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;

        }
    }
}