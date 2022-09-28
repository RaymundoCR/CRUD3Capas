using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;

namespace Datos
{
    public class DEstado
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        public static List<Estado> _listaEstados = new List<Estado>();
        public static Estado _estadoS = new Estado();
        public static String _query;
        public static SqlCommand _comando;
        public List<Estado> Consultar()
        {
            int id = -1;
            _listaEstados = new List<Estado>();
            _query = $"consultarEstados";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = _comando.ExecuteReader();
                while (reader.Read())
                {
                    Estado estado = new Estado();
                    estado.id = Convert.ToInt32(reader["id"]);
                    estado.nombre = reader["nombre"].ToString();
                    estado.curp = reader["CURP"].ToString();
                    _listaEstados.Add(estado);
                }
                con.Close();
            }
            return _listaEstados;
        }
        public Estado Consultar(int id)
        {
            _query = $"consultarEstados";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = _comando.ExecuteReader();
                while (reader.Read())
                {
                    _estadoS = new Estado();
                    _estadoS.id = Convert.ToInt32(reader["id"]);
                    _estadoS.nombre = reader["nombre"].ToString();
                    _estadoS.curp = reader["CURP"].ToString();
                }
                con.Close();
            }
            return _estadoS;
        }
    }
}
