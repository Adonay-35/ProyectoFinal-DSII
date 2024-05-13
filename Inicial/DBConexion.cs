using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inicial
{
    internal class DBConexion
    {
        protected MySqlConnection _CONEXION = new MySqlConnection();

        protected Boolean Conectar()
        {
            Boolean Resultado = false;
            try
            {
                _CONEXION.ConnectionString = "Server=localhost;Port=3306;Database=bdescuela;Uid=sistema-user;Pwd=1234BSSISTEMA;SslMode=None;";
                _CONEXION.Open();
                Resultado = true;

            }
            catch (Exception)
            {
                Resultado = false;
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

