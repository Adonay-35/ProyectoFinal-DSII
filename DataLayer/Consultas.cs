using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Consultas
    {
        public static DataTable USUARIOS()
        {
            DataTable Resultado = new DataTable();
            string Consulta = @"SELECT * FROM Usuarios;";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado;
        }

        public static DataTable PRODUCTOS()
        {
            DataTable Resultado = new DataTable();
            string Consulta = @"SELECT IDProducto, Producto, Stock, Precio, FechaCreacion, FechaVencimiento, Descripcion, IDProveedor, IDCategoria
                                FROM Productos ORDER BY Producto ASC;";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error: " + ex.Message);
            }
            return Resultado;
        }

    }
}
