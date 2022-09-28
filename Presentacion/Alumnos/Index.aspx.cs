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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Alumno> listAlumno = new List<Alumno>();
            if (!IsPostBack)
            {
                cargarPag();
            }
            //int id = int.Parse(Request.QueryString["id"]);
            //List<Alumno> listaAlumnos = new List<Alumno>();
            //NAlumno objNAlumno = new NAlumno();
            //listaAlumnos = objNAlumno.Consultar();
            //ddlEstatus.DataSource = listaAlumnos;
            //ddlEstatus.DataValueField = "id";
            //ddlEstatus.DataTextField = "nombre";
            //ddlEstatus.DataBind();
        }

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando utilizamos el diferentes paginas en el gridView nos da error al momento de cambiar de pagina
            //por lo tanto cuando el e.CommantdName sea igual a =="Page" se omite
            if(e.CommandName == "Page")
            {
                return;
            }
            int nReg = Convert.ToInt32(e.CommandArgument);
            GridViewRow reglon = gvAlumnos.Rows[nReg];
            TableCell Celda = reglon.Cells[0];
            int id = Convert.ToInt32(Celda.Text);

            //e.CommandName = 
            switch (e.CommandName)
            {
                case "btnDetalles":
                    Response.Redirect($"Details.aspx?id={id}");
                    break;
                case "btnEditar":
                    Response.Redirect($"Edit.aspx?id={id}");
                    break;
                case "btnEliminar":
                    Response.Redirect($"Delete.aspx?id={id}");
                    break;
                default:
                    break;
            }

        }

        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //establece el indice de la pagina que se esta mostrando al momento de usar el AllowPaging y PageZize en las 
            //propiedades del GridWiew
            gvAlumnos.PageIndex = e.NewPageIndex;
            cargarPag();
        }

        protected void cargarPag()
        {
            NAlumno objAlu = new NAlumno();
            gvAlumnos.DataSource = objAlu.Consultar();
            gvAlumnos.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx?");
        }
    }
}