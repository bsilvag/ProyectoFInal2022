using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class AltaPronostico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            List<Ciudad> pCiudad = LogicaCiudad.ListarCiudad();
            List<Pais> pPais = LogicaPais.ListarPaises();
        

            if (pCiudad.Count > 0 && pPais.Count > 0)
            {
                cboCiudad.DataSource = pCiudad;
                cboCiudad.DataTextField = "NombreC";
                cboCiudad.DataValueField = "CodC";
                cboCiudad.DataBind();

                cboPais.DataSource = pPais;
                cboPais.DataTextField = "NombreP";
                cboPais.DataValueField = "CodP";
                cboPais.DataBind();
            }
            else
            {
                LblError.Text = "Error: no existe una ciudad registrada. Debe registrar la ciudad primero";
                txtTempMax.Enabled = false;
                txtTempMin.Enabled = false;
                txtVelocidad.Enabled = false;
                txtProbL.Enabled = false;
                txtProbT.Enabled = false;
                btnAgregar.Enabled = false;
                cboCiudad.Enabled = false;
            }
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int CodIntP = 0;
        string oMensaje = "";
        int TempMax = 0;
        int TempMin = 0;
        int Velocidad = 0;
        string TipoCielo = "";
        int ProbL = 0;
        int ProbT = 0;
        string CodC = "";
        string CodP = "";

        try
        {
            TempMax = Convert.ToInt32(txtTempMax.Text);
            TempMin = Convert.ToInt32(txtTempMin.Text);
            Velocidad = Convert.ToInt32(txtVelocidad.Text);
            TipoCielo = Convert.ToString(RblTipoCielo.Text);
            ProbL = Convert.ToInt32(txtProbL.Text);
            ProbT = Convert.ToInt32(txtProbT.Text);
            CodC = Convert.ToString(cboCiudad.SelectedValue);
            CodP = Convert.ToString(cboPais.SelectedValue);
           
        }
        catch
        {
            oMensaje = "Error al ingresar sus datos, por favor intentalo de nuevo.";
        }

        if (oMensaje != "")
        {
            LblError.Text = oMensaje;
        }
        else
        {
            try
            {
                Ciudad unaC = LogicaCiudad.Buscar(CodC, CodP);

                Usuario unUsu = (Usuario)Session["Usuario"];

                Pronostico P = new Pronostico(CodIntP, clnFecha.SelectedDate, Velocidad, ProbL, ProbT, TipoCielo, TempMax, TempMin, unaC, unUsu);

                LogicaPronostico.Alta(P);
                LblError.Text = "Alta con exito";

                txtTempMax.Text = "";
                txtTempMin.Text = "";
                txtVelocidad.Text = "";
                txtProbL.Text = "";
                txtProbT.Text = "";

            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }



}