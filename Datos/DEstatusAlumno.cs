using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DEstatusAlumno
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        public static List<EstatusAlumno> _listaEstatusAlumno = new List<EstatusAlumno>();
        public static EstatusAlumno _EstatusAlumno = new EstatusAlumno();
        public static String _query;
        public static SqlCommand _comando;
        public List<EstatusAlumno> Consultar()
        {
            int id = -1;
            _listaEstatusAlumno = new List<EstatusAlumno>();
            _query = $"consultarEstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = _comando.ExecuteReader();
                while (reader.Read())
                {

                    _EstatusAlumno = new EstatusAlumno();
                    _EstatusAlumno.id = Convert.ToInt32(reader["id"]);
                    _EstatusAlumno.nombre = reader["nombre"].ToString();
                    _EstatusAlumno.clave = reader["Clave"].ToString();
                    _listaEstatusAlumno.Add(_EstatusAlumno);
                }
                con.Close();
            }
            return _listaEstatusAlumno;
        }

        public EstatusAlumno Consultar(int id)
        {
            _listaEstatusAlumno = new List<EstatusAlumno>();
            _query = $"consultarEstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = _comando.ExecuteReader();
                while (reader.Read())
                {
                    _EstatusAlumno.id = Convert.ToInt32(reader["id"]);
                    _EstatusAlumno.nombre = reader["nombre"].ToString();
                    _EstatusAlumno.clave = reader["Clave"].ToString();
                    _listaEstatusAlumno.Add(_EstatusAlumno);
                }
            }
            return _EstatusAlumno;
        }
    }
}
