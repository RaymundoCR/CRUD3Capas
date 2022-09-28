using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Datos;
using Entidades;
using Newtonsoft.Json;

namespace Negocio
{
    public class NAlumno
    {
        public List<Alumno> Consultar()
        {
            DAlumno dAlumno = new DAlumno();
            var result = dAlumno.Consultar();
            return result;
        }
        public Alumno Consultar(int id)
        {
            DAlumno dAlumno = new DAlumno();
            var result = dAlumno.Consultar(id);
            return result;
        }
        public void Agregar(Alumno alumno)
        {
            DAlumno dAlumno = new DAlumno();
            dAlumno.Agregar(alumno);
        }
        public void Actualizar(Alumno alumno)
        {
            DAlumno dAlumno = new DAlumno();
            dAlumno.Actualizar(alumno);
        }
        public void Eliminar(int id)
        {
            DAlumno dAlumno = new DAlumno();
            dAlumno.Eliminar(id);
        }

        public ItemTablaISR CalcularISR(int id)
        {
            //al recibir el resultado del web service, se debe serializar primero a formato json y descerializar a tipo ItemTableISR
            try
            {
                WS.WSAlumnosSoapClient WSAlumnos = new WS.WSAlumnosSoapClient();
                WS.ItemTablaISR wsResult = WSAlumnos.CalcularISR(id);
                string json = JsonConvert.SerializeObject(wsResult);
                return JsonConvert.DeserializeObject<ItemTablaISR>(json);
                

            }
            catch (Exception)
            {
                DAlumno dAlumno = new DAlumno();
                List<ItemTablaISR> tablaISRs = dAlumno.ConsultarTablaISR();
                Alumno alumno = new Alumno();
                alumno = dAlumno.Consultar(id);
                ItemTablaISR table = new ItemTablaISR();
                decimal sueldoQuincenal = alumno.sueldo / 2;

                var itemsISTal =
                    from isr in tablaISRs
                    where sueldoQuincenal < isr.limSuperior && sueldoQuincenal > isr.limInferior
                    select new { limInf = isr.limInferior, limSup = isr.limSuperior, cuota = isr.CuotaFija, ExecLiminf = isr.ExedLimInf, subsidio = isr.Subsidio };

                foreach (var item in itemsISTal)
                {
                    table.limInferior = item.limInf;
                    table.limSuperior = item.limSup;
                    table.CuotaFija = item.cuota;
                    table.ExedLimInf = item.ExecLiminf;
                    table.Subsidio = item.subsidio;
                }

                decimal sQuinLim = (sueldoQuincenal - table.limInferior);
                decimal limExecliminf = sQuinLim * (table.ExedLimInf / 100);
                decimal finISR = limExecliminf + (table.CuotaFija - table.Subsidio);

                table.ISR += finISR;

                return table;
            }
        }

        public AportacionesIMSS CalcularIMSS(int id)
        {
            //try
            //{
            //    WS.WSAlumnosSoapClient WSAlumnos = new WS.WSAlumnosSoapClient();
            //    WS.AportacionesIMSS wsResult = WSAlumnos.CalcularIMSS(id);
            //    string json = JsonConvert.SerializeObject(wsResult);
            //    AportacionesIMSS iMSS = JsonConvert.DeserializeObject<AportacionesIMSS>(json);
            //    return iMSS;
            //}
            //catch (Exception)
            //{
            DAlumno dAlumno = new DAlumno();
            Alumno alumno = new Alumno();
            alumno = dAlumno.Consultar(id);
            decimal uma = Convert.ToDecimal(ConfigurationManager.AppSettings["UMA"]);
            AportacionesIMSS objAport = new AportacionesIMSS();

            objAport.EnfermedadMaternal = ((alumno.sueldo - (uma * 3)) * (1.1m / 100));
            objAport.InvalidezVida = alumno.sueldo * (1.75m / 100);
            objAport.Retiro = alumno.sueldo * (2m / 100);
            objAport.Cesantia = alumno.sueldo * (3.150m / 100);
            objAport.Infonavid = alumno.sueldo * (5m / 100);


            return objAport;
            //}

            //else if (PatrTrab == 2)
            //{
            //    objAport.EnfermedadMaternal = SBC - (UMA * 3) * (0.4m / 100);
            //    objAport.InvalidezVida = SBC * (0.625m / 100);
            //    objAport.Retiro = SBC * (0m / 100);
            //    objAport.Cesantia = SBC * (1.125m / 100);
            //    objAport.Infonavid = SBC * (0m / 100);
            //}
        }
    }
}
