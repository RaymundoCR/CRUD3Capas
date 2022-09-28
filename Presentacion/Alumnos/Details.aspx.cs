using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using Entidades;
using Negocio;

namespace Presentacion.Alumnos
{
    public partial class Details : System.Web.UI.Page
    {
        NAlumno _objNAlu = new NAlumno();
        Alumno _objAlumno = new Alumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            NEstado objNEstado = new NEstado();
            NEstatusAlumno objNEstatus = new NEstatusAlumno();
            
            Estado objEstado = new Estado();
            EstatusAlumno objEstatus = new EstatusAlumno();

            int id = Convert.ToInt32(Request.QueryString["id"]);
            //objNAlu.Consultar(id);

            _objAlumno = _objNAlu.Consultar(id);

            lbId.Text = _objAlumno.id.ToString();
            lbNombre.Text = _objAlumno.nombre;
            lbPApellido.Text = _objAlumno.primerApellido;
            lbSApellido.Text = _objAlumno.segundoApellido;
            lbFechaNacimiento.Text = _objAlumno.fNacimiento.ToString();
            lbCurp.Text = _objAlumno.curp;
            lbCorreo.Text = _objAlumno.correo;
            lbTelefono.Text = _objAlumno.telefono;
            lbSueldo.Text = _objAlumno.sueldo.ToString();
            objEstado = objNEstado.Consultar(id);
            lbEstado.Text = objEstado.nombre;
            objEstatus = objNEstatus.Consultar(id);
            lbEstatus.Text = objEstatus.nombre;
        }

        protected void btnCalcularIMSS_Click(object sender, EventArgs e)
        {
            //Label12.Visible = true;
            //lbEnfermedadesMaternidad.Visible = true;
            //Label13.Visible = true;
            //lbInvalVida.Visible = true;
            //Label14.Visible = true;
            //lbRetido.Visible = true;
            //Label15.Visible = true;
            //lbCesantia.Visible = true;
            //Label16.Visible = true;
            //lbInfonavit.Visible = true;
            AportacionesIMSS result = _objNAlu.CalcularIMSS(_objAlumno.id);
            lblEnfermedadess.Text = Convert.ToString(result.EnfermedadMaternal);
            lblInvalidez.Text = Convert.ToString(result.InvalidezVida);
            lblRetiro.Text = Convert.ToString(result.Retiro);
            lblCesantia.Text = Convert.ToString(result.Cesantia);
            lblInfonavitt.Text = Convert.ToString(result.Infonavid);


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCalcularISR_Click(object sender, EventArgs e)
        {
            NAlumno alumno = new NAlumno();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ItemTablaISR items = alumno.CalcularISR(id);

            lblLimInf.Text = Convert.ToString(items.limInferior);
            lblLimSup.Text = Convert.ToString(items.limSuperior);
            lblCuotaFija.Text = Convert.ToString(items.CuotaFija);
            lblExcedente.Text = Convert.ToString(items.ExedLimInf);
            lblSubsidio.Text = Convert.ToString(items.Subsidio);
            lblImpuesto.Text = Convert.ToString(items.ISR);
            mpeModalISR.Show();
        }

        //protected void btnCalcularISR_Click(object sender, EventArgs e)
        //{
        //    //lb12.Visible = true;
        //    //lbResult.Visible = true;
        //    ItemTablaISR result = _objNAlu.CalcularISR(_objAlumno.id);
        //    lblLimInf.Text = Convert.ToString(result.limInferior);
        //    lblLimSup.Text = Convert.ToString(result.limSuperior);
        //    lblCuotaFija.Text = Convert.ToString(result.CuotaFija);
        //    lblExcedente.Text = Convert.ToString(result.ExedLimInf);
        //    lblSubsidio.Text = Convert.ToString(result.Subsidio);
        //    lblImpuesto.Text = Convert.ToString(result.ISR);
        //}
    }
}