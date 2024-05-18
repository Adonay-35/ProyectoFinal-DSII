using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Ventas
    {
        MySqlDataReader resultado;
        DataTable tabla = new DataTable();
        MySqlConnection sqlConexion = new MySqlConnection();

        Int32 _IDVenta;
        DateTime _FechaVenta;
        Int32 _IDUsuario;
        Int32 _IDCliente;
        string _IDProducto;
        Int32 _Cantidad;
        double _Total;

        public Int32 IDVenta { get => _IDVenta; set => _IDVenta = value; }
        public DateTime FechaVenta { get => _FechaVenta; set => _FechaVenta = value; }
        public Int32 IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public Int32 IDCliente { get => _IDCliente; set => _IDCliente = value; }
        public string IDProducto { get => _IDProducto; set => _IDProducto = value; }
        public Int32 Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Total { get => _Total; set => _Total = value; }


        public bool Insertar()
        {
            bool Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("INSERT INTO Ventas(FechaVenta, IDUsuario, IDCliente, IDProducto, Cantidad, Total) VALUES(");
            Sentencia.Append("FechaVenta='" + _FechaVenta.ToString("yyyy-MM-dd") + "', ");
            Sentencia.Append("IDUsuario=" + _IDUsuario + ", ");
            Sentencia.Append("IDCliente=" + _IDCliente + ", ");
            Sentencia.Append("IDProducto='" + _IDProducto + "', ");
            Sentencia.Append("Cantidad=" + _Cantidad + ", ");
            Sentencia.Append("Total=" + _Total);

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

        public bool Actualizar()
        {
            bool Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("UPDATE Ventas SET ");
            Sentencia.Append("FechaVenta='" + _FechaVenta.ToString("yyyy-MM-dd") + "', ");
            Sentencia.Append("IDUsuario=" + _IDUsuario + ", ");
            Sentencia.Append("IDCliente=" + _IDCliente + ", ");
            Sentencia.Append("IDProducto='" + _IDProducto + "', ");
            Sentencia.Append("Cantidad=" + _Cantidad + ", ");
            Sentencia.Append("Total=" + _Total);
            Sentencia.Append(" WHERE IDVenta='" + _IDVenta + "';");

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

        public bool Eliminar()
        {
            bool Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("DELETE FROM Ventas ");
            Sentencia.Append("WHERE IDVenta='" + _IDVenta + "';");

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

        /*public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();

            try
            {
                sqlConexion.ConnectionString = "Server=localhost;Port=3306;Database=sistemaventas;Uid=sistema-user;Pwd=root;SslMode=None;";
                MySqlCommand comando = new MySqlCommand("ObtenerUsuarios", sqlConexion);
                comando.CommandType = CommandType.StoredProcedure;
                sqlConexion.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    listaUsuarios.Add(new Usuarios(
                        resultado.GetInt32(0),
                        resultado.GetString(1)
                        ));
                }

                return listaUsuarios;
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
        }*/

        /*public List<Clientes> ObtenerClientes()
        {
            List<Clientes> listaClientes = new List<Clientes>();

            try
            {
                sqlConexion.ConnectionString = "Server=localhost;Port=3306;Database=sistemaventas;Uid=sistema-user;Pwd=root;SslMode=None;";
                MySqlCommand comando = new MySqlCommand("ObtenerClientes", sqlConexion);
                comando.CommandType = CommandType.StoredProcedure;
                sqlConexion.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    listaClientes.Add(new Clientes(
                        resultado.GetInt32(0),
                        resultado.GetString(1),
                        resultado.GetString(2)
                        ));
                }

                return listaClientes;
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
        }*/

        /*public List<Productos> ObtenerProductos()
        {
            List<Productos> listaProductos = new List<Productos>();

            try
            {
                sqlConexion.ConnectionString = "Server=localhost;Port=3306;Database=sistemaventas;Uid=sistema-user;Pwd=root;SslMode=None;";
                MySqlCommand comando = new MySqlCommand("ObtenerProductos", sqlConexion);
                comando.CommandType = CommandType.StoredProcedure;
                sqlConexion.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    listaProductos.Add(new Productos(
                        resultado.GetInt32(0),
                        resultado.GetString(1)
                        ));
                }

                return listaProductos;
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
        }*/
    }

}
