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

public partial class ABM_Pais : System.Web.UI.Page
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
        txtCodP.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtCodP.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodP.Enabled = true;
        txtCodP.Text = "";
        txtNombreP.Text = "";

        LblError.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais _unaP = new Pais(txtCodP.Text.Trim(), txtNombreP.Text.Trim());

            Logica.LogicaPais.Alta(_unaP);
           
     
            this.LimpioFormulario();
            LblError.Text = "Alta de País con exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string _CodP = txtCodP.Text.Trim();
            Pais _objeto = Logica.LogicaPais.Buscar(_CodP);

            if (_objeto == null)
            {
                this.ActivoBotonesA();
                Session["PaisABM"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["PaisABM"] = _objeto;

                txtNombreP.Text = _objeto.NombreP;
            }
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
            Pais _unaP = (Pais)Session["PaisABM"];

            _unaP.NombreP = txtNombreP.Text.Trim();

            Logica.LogicaPais.Modificar(_unaP);
          
            this.LimpioFormulario();
            LblError.Text = "Modificacion de País con éxito";
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
            Pais _unaP = (Pais)Session["PaisABM"];

            Logica.LogicaPais.Eliminar(_unaP);

           
            this.LimpioFormulario();
            LblError.Text = "Eliminacion de País con éxito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}