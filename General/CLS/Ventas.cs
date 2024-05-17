using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Venta
    {
        string _IDVenta;
        DateTime _FechaVenta;
        Int32 _IDUsuario;
        Int32 _IDCliente;
        string _IDProducto;
        Int32 _Cantidad;
        double _Total;

        public string IDVenta { get => _IDVenta; set => _IDVenta = value; }
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
            Sentencia.Append("INSERT INTO Ventas(IDVenta, FechaVenta, IDUsuario, IDCliente, IDProducto, Cantidad, Total) VALUES(");
            Sentencia.Append("'" + _IDVenta + "', ");
            Sentencia.Append("'" + _FechaVenta.ToString("yyyy-MM-dd HH:mm:ss") + "', ");
            Sentencia.Append(_IDUsuario + ", ");
            Sentencia.Append(_IDCliente + ", ");
            Sentencia.Append("'" + _IDProducto + "', ");
            Sentencia.Append(_Cantidad + ", ");
            Sentencia.Append(_Total + ");");

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
            Sentencia.Append("FechaVenta='" + _FechaVenta.ToString("yyyy-MM-dd HH:mm:ss") + "', ");
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
    }

}
