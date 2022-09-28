using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NEstado
    {
        public List<Estado> Consultar()
        {
            DEstado dEstado = new DEstado();
            var result = dEstado.Consultar();
            return result;
        }
        public Estado Consultar(int id)
        {
            DEstado dEstado = new DEstado();
            var result = dEstado.Consultar(id);
            return result;
        }

        //public Estado devolverEstado()
        //{
        //    Estado dEstado = new Estado();


        //}
    }
}
