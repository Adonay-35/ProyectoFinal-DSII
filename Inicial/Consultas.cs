using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    internal class Consultas
    {
        public static DataTable ALUMNOS()
        {
            DataTable Resultado = new DataTable();
            string Consulta = @"SELECT Id, nombres, apellidos FROM alumnos ORDER BY nombres ASC;";
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
    }
}
