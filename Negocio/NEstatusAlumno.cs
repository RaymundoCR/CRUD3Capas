using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NEstatusAlumno
    {
        public List<EstatusAlumno> Consultar()
        {
            DEstatusAlumno dEstatus = new DEstatusAlumno();
            var result = dEstatus.Consultar();
            return result;
        }

        public EstatusAlumno Consultar(int id)
        {
            DEstatusAlumno dEstatus = new DEstatusAlumno();
            var result = dEstatus.Consultar(id);
            return result;
        }
    }
}
