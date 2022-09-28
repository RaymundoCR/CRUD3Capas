using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    internal interface ICRUD
    {
        List<Alumno> Consultar();
        Alumno Consultar(int id);
        void Agregar(Alumno estatus);
        void Actualizar(Alumno estatus);
        void Eliminar(int id);
    }
}
