using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Presentacion.Alumnos
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Estado> listaEstados = new List<Estado>();
                List<EstatusAlumno> listaEstatus = new List<EstatusAlumno>();
                NAlumno objNAlu = new NAlumno();
                NEstado objNEstado = new NEstado();
                NEstatusAlumno objNEstatus = new NEstatusAlumno();
                Alumno objAlumno = new Alumno();
                //int id = int.Parse(Request.QueryString["id"]);
                //objAlumno.id = id;
                //objNAlu.Agregar(objAlumno);
                string id = Request.QueryString["id"];
                txtId.Text = id;

                listaEstados = objNEstado.Consultar();
                ddlEstado.DataSource = listaEstados;
                ddlEstado.DataValueField = "id";
                ddlEstado.DataTextField = "nombre";
                ddlEstado.DataBind();

                listaEstatus = objNEstatus.Consultar();
                ddlEstatus.DataSource = listaEstatus;
                ddlEstatus.DataValueField = "id";
                ddlEstatus.DataTextField = "Nombre";
                ddlEstatus.DataBind();
            }
        }

        protected void btnGuardarActualizar_Click(object sender, EventArgs e)
        {
            //objNAlu.Actualizar(objAlumno);
            if (Page.IsValid)
            {
                Alumno alumno = new Alumno();
                NAlumno addAlumno = new NAlumno();

                alumno.nombre = txtNombre.Text;
                alumno.primerApellido = txtPApellido.Text;
                alumno.segundoApellido = txtSApellido.Text;
                alumno.correo = txtCorreo.Text;
                alumno.telefono = txtTelefono.Text;
                alumno.fNacimiento = Convert.ToDateTime(txtFNacimineto.Text);
                alumno.curp = txtCurp.Text;
                alumno.idEstado = Convert.ToInt32(ddlEstado.SelectedValue);
                alumno.idEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);

                addAlumno.Actualizar(alumno);
                Response.Redirect("Index.aspx");
            }
        }

        protected void cvFnacimientoEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //validacion del lado del servidor
            var fechaNC = txtFNacimineto.Text;
            var FechaCurpfecha = txtCurp.Text.Substring(4, 6);
            var FechNacFormCurp = fechaNC.Substring(2, 2) + fechaNC.Substring(5, 2) + fechaNC.Substring(8,2);
            args.IsValid = FechaCurpfecha == FechNacFormCurp;
        }
    }
}