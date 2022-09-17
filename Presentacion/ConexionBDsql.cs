using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Presentacion
{
    public class ConexionBDsql
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        public void Conexion()
        {

        }
    }
}