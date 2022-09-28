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
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //el isportback se tiene que agregar aqui afuerza por que si no, te actualiza los valores del droplist
            //y se envian a la base de tados como 1 1, el status y el estado, ya que al momento de dar click en guardar
            //la pagina sev vuelve a actualizar, esto evita que no se actualice la pagina ya que solo es por un evento
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

        protected void btnGuardarAgregar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            NAlumno addAlumno = new NAlumno();

            alumno.nombre = txtNombre.Text;
            alumno.primerApellido = txtPApellido.Text;
            alumno.segundoApellido = txtSApellido.Text;
            alumno.correo = txtCorreo.Text;
            alumno.telefono = txtTelefono.Text;
            alumno.fNacimiento = Convert.ToDateTime(txtFNacimiento.Text);
            alumno.curp = txtCurp.Text;
            alumno.sueldo = Convert.ToDecimal(txtSueldo.Text);
            alumno.idEstado = Convert.ToInt32(ddlEstado.SelectedValue.ToString());
            alumno.idEstatus = Convert.ToInt32(ddlEstatus.SelectedValue.ToString());

            addAlumno.Agregar(alumno);
            Response.Redirect("Index.aspx");
        }
    }
}