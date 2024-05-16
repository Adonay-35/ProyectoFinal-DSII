using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION = new MySqlConnection();

        protected Boolean Conectar()
        {
            Boolean Resultado = false;
            try
            {
                _CONEXION.ConnectionString = "Server=localhost;Port=3306;Database=sistemaventas;Uid=sistema-user;Pwd=root;SslMode=None;";
                _CONEXION.Open();
                Resultado = true;

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo establecer la conexión con la base de datos.", ex); ;
            }
            return Resultado;
        }

        protected void Desconectar()
        {
            try
            {
                if (_CONEXION.State == System.Data.ConnectionState.Open)
                {
                    _CONEXION.Close();
                }
            }
            catch (Exception)
            {

            }
        }

    }
}

