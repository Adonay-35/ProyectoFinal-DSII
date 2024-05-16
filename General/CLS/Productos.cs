using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Producto
    {
        Int32 _IDProducto;
        string _Producto;
        Int32 _Stock;
        double _Precio;
        string _Descripcion;
        Int32 _IDProveedor;
        DateTime _FechaFabricacion;
        DateTime _FechaVencimiento;
        Int32 _IDCategoria;

        public Int32 IDProducto { get => _IDProducto; set => _IDProducto = value; }
        public string NombreProducto { get => _Producto; set => _Producto = value; }
        public Int32 Stock { get => _Stock; set => _Stock = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public Int32 IDProveedor { get => _IDProveedor; set => _IDProveedor = value; }
        public DateTime FechaCreacion { get => _FechaFabricacion; set => _FechaFabricacion = value; }
        public DateTime FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }
        public Int32 IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("INSERT INTO Productos(IDProducto, Producto, Stock, Precio, Descripcion, IDProveedor, FechaCreacion, FechaVencimiento, IDCategoria) VALUES(");
            Sentencia.Append("'" + _IDProducto + "', ");
            Sentencia.Append("'" + _Producto + "', ");
            Sentencia.Append(_Stock + ", ");
            Sentencia.Append(_Precio + ", ");
            Sentencia.Append("'" + _Descripcion + "', ");
            Sentencia.Append(_IDProveedor + ", ");
            Sentencia.Append("'" + _FechaFabricacion.ToString("yyyy-MM-dd") + "', ");
            Sentencia.Append("'" + _FechaVencimiento.ToString("yyyy-MM-dd") + "', ");
            Sentencia.Append(_IDCategoria + ");");

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
            Sentencia.Append("UPDATE Productos SET ");
            Sentencia.Append("Producto='" + _Producto + "', ");
            Sentencia.Append("Stock=" + _Stock + ", ");
            Sentencia.Append("Precio=" + _Precio + ", ");
            Sentencia.Append("Descripcion='" + _Descripcion + "', ");
            Sentencia.Append("IDProveedor=" + _IDProveedor + ", ");
            Sentencia.Append("FechaCreacion='" + _FechaFabricacion.ToString("yyyy-MM-dd") + "', ");
            Sentencia.Append("FechaVencimiento='" + _FechaVencimiento.ToString("yyyy-MM-dd") + "', ");
            Sentencia.Append("IDCategoria=" + _IDCategoria);
            Sentencia.Append(" WHERE IDProducto='" + _IDProducto + "';");

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

        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("DELETE FROM Productos");
            Sentencia.Append(" WHERE IDProducto='" + _IDProducto + "';");

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
