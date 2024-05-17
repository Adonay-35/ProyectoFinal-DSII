using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace General.CLS
{
    internal class Usuarios
    {
        Int32 _IDUsuario;
        String _Usuario;
        String _Clave;
        Int32 _IDRol;
        Int32 _IDEmpleado;
        Int32 _IDEstado;


        MySqlDataReader resultado;
        DataTable tabla = new DataTable();
        MySqlConnection sqlConexion = new MySqlConnection();

        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public int IDRol { get => _IDRol; set => _IDRol = value; }
        public int IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }
        public int IDEstado { get => _IDEstado; set => _IDEstado = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("INSERT INTO usuarios(Usuario,Clave,IDRol,IDEmpleado,IDEstado) VALUES(");
            Sentencia.Append("'" + _Usuario + "',");
            Sentencia.Append("MD5('" + _Clave + "'),");
            Sentencia.Append(_IDRol + ",");
            Sentencia.Append(_IDEmpleado + ",");
            Sentencia.Append(_IDEstado + ");");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("UPDATE usuarios  SET ");
            Sentencia.Append("Usuario ='" + _Usuario + "',");
            Sentencia.Append("Clave = MD5('" + _Clave + "'),");
            Sentencia.Append("IDRol ='" + _IDRol + "',");
            Sentencia.Append("IDEmpleado =" + _IDEmpleado + ",");
            Sentencia.Append("IDEstado =" + _IDEstado);
            Sentencia.Append(" WHERE IDUsuario =" + _IDUsuario + ";");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public Boolean Elminar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("DELETE FROM  usuarios");
            Sentencia.Append(" WHERE IDUsuario =" + _IDUsuario + ";");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public List<Roles> ObtenerRoles()
        {
            List<Roles> listaRoles = new List<Roles>();

            try
            {
                sqlConexion.ConnectionString = "Server=localhost;Port=3306;Database=sistemaventas;Uid=sistema-user;Pwd=root;SslMode=None;";
                MySqlCommand comando = new MySqlCommand("ObtenerRoles", sqlConexion);
                comando.CommandType = CommandType.StoredProcedure;
                sqlConexion.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    listaRoles.Add(
                        new Roles(
                            resultado.GetInt32(0),
                            resultado.GetString(1)
                            )
                        );
                }

                return listaRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();
                }
            }
        }

        public List<Estados> ObtenerEstados()
        {
            List<Estados> listaEstados = new List<Estados>();

            try
            {
                sqlConexion.ConnectionString = "Server=localhost;Port=3306;Database=sistemaventas;Uid=sistema-user;Pwd=root;SslMode=None;";
                MySqlCommand comando = new MySqlCommand("ObtenerEstados", sqlConexion);
                comando.CommandType = CommandType.StoredProcedure;
                sqlConexion.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    listaEstados.Add(
                        new Estados(
                            resultado.GetInt32(0),
                            resultado.GetInt32(1),
                            resultado.GetString(2)
                            )
                        );
                }

                return listaEstados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();
                }
            }
        }
    }
}
