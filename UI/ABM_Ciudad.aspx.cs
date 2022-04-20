
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



public partial class ABM_Ciudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }



    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;
        txtCodC.Enabled = false;
        txtCodP.Enabled = false;
    }



    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtCodC.Enabled = false;
        txtCodP.Enabled = false;
    }



    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodC.Enabled = true;
        txtCodP.Enabled = true;
        txtCodC.Text = "";
        txtCodP.Text = "";
        txtNombreC.Text = "";



        LblError.Text = "";
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string _CodC = Convert.ToString(txtCodC.Text);
            string _CodP = Convert.ToString(txtCodP.Text);



            Ciudad _objeto = Logica.LogicaCiudad.Buscar(_CodC, _CodP);



            if (_objeto == null)
            {
                this.ActivoBotonesA();
                Session["Ciudad"] = null;
                Session["Pais"] = Logica.LogicaPais.Buscar(txtCodP.Text);
            }



            else
            {
                this.ActivoBotonesBM();



                Session["Ciudad"] = _objeto;
                Session["Pais"] = _objeto.Pais;



                txtCodC.Text = _objeto.CodC;
                txtNombreC.Text = _objeto.NombreC;
                txtCodP.Text = _objeto.Pais.CodP;



                LblError.Text = _objeto.Pais.ToString();
            }



        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }



    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais _unP = (Pais)Session["Pais"];



            if (_unP == null)
                throw new Exception("Debe seleccionar un País");



            Ciudad unaC = new Ciudad(txtCodC.Text.Trim(), txtNombreC.Text.Trim(), _unP);



            Logica.LogicaCiudad.Alta(unaC);



            this.LimpioFormulario();
            LblError.Text = "Alta de Ciudad con éxito";



        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }




    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad _unaC = (Ciudad)Session["Ciudad"];
            Pais _unaP = (Pais)Session["Pais"];



            if (_unaP == null)
                throw new Exception("Debe seleccionar un País");



            _unaC.CodC = txtCodC.Text.Trim();
            _unaC.NombreC = txtNombreC.Text.Trim();
            _unaC.Pais = _unaP;



            Logica.LogicaCiudad.Modificar(_unaC);



            this.LimpioFormulario();
            LblError.Text = "Modificacion de Ciudad con éxito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }



    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad _unaC = (Ciudad)Session["Ciudad"];
            Logica.LogicaCiudad.Eliminar(_unaC);



            this.LimpioFormulario();
            LblError.Text = "Eliminacion de Ciudad con éxito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}