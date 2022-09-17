using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Net.NetworkInformation;

namespace Datos
{
    public class DAlumno : ICRUD
    {
        //string que guarda el nombre de la conexion, en el archivo web.config esta la conexion
        public static string _cnnString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        //lista para agregar los alumnos que vamos a obtener al momento de consulatar la base de 
        public static List<Alumno> _listaAlumnos = new List<Alumno>();
        public static List<ItemTablaISR> _listaTablaISR = new List<ItemTablaISR>();
        public static String _query;
        public static SqlCommand _comando;
        public List<Alumno> Consultar()
        {
            try
            {
                int id = -1;
                _listaAlumnos = new List<Alumno>();
                _query = $"consultarAlumnos";
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader reader = _comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.id = Convert.ToInt32(reader["id"]);
                        alumno.nombre = reader["nombre"].ToString();
                        alumno.primerApellido = reader["primerApellido"].ToString();
                        alumno.segundoApellido = reader["segundoApellido"].ToString();
                        alumno.correo = reader["correo"].ToString();
                        alumno.telefono = reader["telefono"].ToString();
                        alumno.fNacimiento = Convert.ToDateTime(reader["fechaNacimiento"].ToString());
                        alumno.curp = reader["curp"].ToString();
                        //compara el sueldomensual por si tiene un nulo entonces agrega un 0, de lo contrario devuelve el valor que tiene
                        alumno.sueldo = DBNull.Value.Equals(reader["sueldo"]) ? 0 : Convert.ToDecimal(reader["sueldo"]);
                        alumno.idEstado = Convert.ToInt32(reader["idEstadoOrigen"]);
                        alumno.idEstatus = Convert.ToInt32(reader["idEstatus"]);
                        _listaAlumnos.Add(alumno);
                    }
                    con.Close();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _listaAlumnos;
        }

        static Alumno _objAlumno = new Alumno();
        public Alumno Consultar(int id)
        {
            Alumno alumno = new Alumno();
            try
            {
                _query = $"consultarAlumnos";
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.Add(new SqlParameter("@id", id));
                    con.Open();
                    SqlDataReader reader = _comando.ExecuteReader();
                    while (reader.Read())
                    {
                        alumno.id = Convert.ToInt32(reader["id"]);
                        alumno.nombre = reader["nombre"].ToString();
                        alumno.primerApellido = reader["primerApellido"].ToString();
                        alumno.segundoApellido = reader["segundoApellido"].ToString();
                        alumno.correo = reader["correo"].ToString();
                        alumno.telefono = reader["telefono"].ToString();
                        alumno.fNacimiento = Convert.ToDateTime(reader["fechaNacimiento"].ToString());
                        alumno.curp = reader["curp"].ToString();
                        //compara el sueldomensual por si tiene un nulo entonces agrega un 0, de lo contrario devuelve el valor que tiene
                        alumno.sueldo = DBNull.Value.Equals(reader["sueldo"]) ? 0 : Convert.ToDecimal(reader["sueldo"].ToString());
                        alumno.idEstado = Convert.ToInt32(reader["idEstadoOrigen"]);
                        alumno.idEstatus = Convert.ToInt32(reader["idEstatus"]);
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return alumno;
        }
        public void Agregar(Alumno alumno)
        {
            try
            {
                _query = ($"agregarAlumnos");
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@nombre", alumno.nombre);
                    _comando.Parameters.AddWithValue("@primerA", alumno.primerApellido);
                    _comando.Parameters.AddWithValue("@segundoA", alumno.segundoApellido);
                    _comando.Parameters.AddWithValue("@correo", alumno.correo);
                    _comando.Parameters.AddWithValue("@telefono", alumno.telefono);
                    _comando.Parameters.AddWithValue("@fechaN", alumno.fNacimiento);
                    _comando.Parameters.AddWithValue("@curp", alumno.curp);
                    _comando.Parameters.AddWithValue("@sueldo", alumno.sueldo);
                    _comando.Parameters.AddWithValue("@estado", alumno.idEstado);
                    _comando.Parameters.AddWithValue("@estatus", alumno.idEstatus);
                    con.Open();
                    _comando.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Actualizar(Alumno alumno)
        {
            try
            {
                _listaAlumnos = new List<Alumno>();
                _query = $"actualizarAlumnos";
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@id", alumno.id);
                    _comando.Parameters.AddWithValue("@nombre", alumno.nombre);
                    _comando.Parameters.AddWithValue("@primerApellido", alumno.primerApellido);
                    _comando.Parameters.AddWithValue("@segundoApellido", alumno.segundoApellido);
                    _comando.Parameters.AddWithValue("@correo", alumno.correo);
                    _comando.Parameters.AddWithValue("@telefono", alumno.telefono);
                    _comando.Parameters.AddWithValue("@fechaNacimiento", alumno.fNacimiento);
                    _comando.Parameters.AddWithValue("@curp", alumno.curp);
                    _comando.Parameters.AddWithValue("@sueldo", alumno.sueldo);
                    _comando.Parameters.AddWithValue("@idEstadoOrigen", alumno.idEstado);
                    _comando.Parameters.AddWithValue("@idEstatus", alumno.idEstatus);
                    con.Open();
                    _comando.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                _listaAlumnos = new List<Alumno>();
                _query = $"eliminarAlumnos '{id}'";
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    _comando.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<ItemTablaISR> ConsultarTablaISR()
        {
             try
            {
                int id = -1;
                _listaTablaISR = new List<ItemTablaISR>();
                _query = $"consultarTablaISR";
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader reader = _comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ItemTablaISR itemTisr = new ItemTablaISR();
                        itemTisr.limInferior = Convert.ToDecimal(reader["LimInf"]);
                        itemTisr.limSuperior = Convert.ToDecimal(reader["LimSup"]);
                        itemTisr.CuotaFija = Convert.ToDecimal(reader["CuotaFija"]);
                        itemTisr.ExedLimInf = Convert.ToDecimal(reader["ExedLimInf"]);
                        itemTisr.Subsidio = Convert.ToDecimal(reader["Subsidio"]);
                        _listaTablaISR.Add(itemTisr);
                    }
                    con.Close();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _listaTablaISR;
        }
    }
}
