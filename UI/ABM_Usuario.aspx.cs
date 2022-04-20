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



public partial class ABM_Usuario : System.Web.UI.Page
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
        txtNombUsu.Enabled = false;
    }



    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtNombUsu.Enabled = false;
    }



    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        txtNombUsu.Enabled = true;
        txtNombUsu.Text = "";
        txtPass.Text = "";
        txtNombre.Text = "";



        LblError.Text = "";
    }



    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario _unUsu = new Usuario(txtNombUsu.Text.Trim(), txtPass.Text.Trim(), txtNombre.Text.Trim());



            Logica.LogicaUsuario.Alta(_unUsu);




            this.LimpioFormulario();
            LblError.Text = "Alta de Usuario con exito";
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
            string _NombUsu = txtNombUsu.Text.Trim();
            Usuario _objeto = Logica.LogicaUsuario.Buscar(_NombUsu);



            if (_objeto == null)
            {
                this.ActivoBotonesA();
                Session["UsuarioABM"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["UsuarioABM"] = _objeto;



                txtPass.Text = _objeto.Pass;
                txtNombre.Text = _objeto.Nombre;
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
            Usuario _unUsu = (Usuario)Session["UsuarioABM"];



            _unUsu.Pass = txtPass.Text.Trim();
            _unUsu.Nombre = txtNombre.Text.Trim();



            Logica.LogicaUsuario.Modificar(_unUsu);
          
            this.LimpioFormulario();
            LblError.Text = "Modificacion de Usuario con éxito";
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
            Usuario _unUsu = (Usuario)Session["UsuarioABM"];



            Logica.LogicaUsuario.Eliminar(_unUsu);




            this.LimpioFormulario();
            LblError.Text = "Eliminacion de Usuario con éxito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}