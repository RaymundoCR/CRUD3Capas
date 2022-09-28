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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NAlumno objNAlu = new NAlumno();
            NEstado objNEstado = new NEstado();
            NEstatusAlumno objNEstatus = new NEstatusAlumno();
            Alumno objAlumno = new Alumno();
            Estado objEstado = new Estado();
            EstatusAlumno objEstatus = new EstatusAlumno();

            int id = int.Parse(Request.QueryString["id"]);
            //objNAlu.Consultar(id);
            objAlumno = objNAlu.Consultar(id);

            lbId.Text = objAlumno.id.ToString();
            lbNombre.Text = objAlumno.nombre;
            lbPApellido.Text = objAlumno.primerApellido;
            lbSApellido.Text = objAlumno.segundoApellido;
            lbFechaNacimiento.Text = objAlumno.fNacimiento.ToString();
            lbCurp.Text = objAlumno.curp;
            lbCorreo.Text = objAlumno.correo;
            lbTelefono.Text = objAlumno.telefono;
            lbSueldo.Text = objAlumno.sueldo.ToString();
            objEstado = objNEstado.Consultar(id);
            lbEstado.Text = objEstado.nombre;
            objEstatus = objNEstatus.Consultar(id);
            lbEstatus.Text = objEstatus.nombre;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NAlumno objNAlumno = new NAlumno();
            int id = int.Parse(Request.QueryString["id"]);

            objNAlumno.Eliminar(id);
            Response.Redirect("Index.aspx");
        }
    }
}