using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;



public partial class ListadoPronosticoxCiudadespx : System.Web.UI.Page
{
       protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (!IsPostBack){
            Session["ListaP"] = Logica.LogicaPais.ListarPaises();
            cboPais.DataSource = Session["ListaP"];
            cboPais.DataBind();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
   

   
    protected void cboPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Pais unP = ((List<EntidadesCompartidas.Pais>)Session["ListaP"])[cboPais.SelectedIndex];

            if (unP != null)
            {
                
                Session["ListaC"] = Logica.LogicaCiudad.ListarCiudadesPais(unP);
           
                   GVCiudades.DataSource = Session["ListaC"];
                   GVCiudades.DataBind();
            }
            else
            {
                GVCiudades.DataSource = null;
                GVCiudades.DataBind();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }


    protected void GVCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Ciudad unaC = ((List<EntidadesCompartidas.Ciudad>)Session["ListaC"])[GVCiudades.SelectedIndex];

            if (unaC != null)
            {
                List<EntidadesCompartidas.Pronostico> _listaPP = Logica.LogicaPronostico.ListarPronxCiudad(unaC);

                GVPronosticos.DataSource = _listaPP;
                GVPronosticos.DataBind();
            }
            else
            {
                
                GVPronosticos.DataSource = null;
                GVPronosticos.DataBind();
                LblError.Text = "No existe Pronóstico asociado a la Ciudad";
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
   
}



}



