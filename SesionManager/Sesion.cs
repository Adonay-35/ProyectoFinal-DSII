using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SesionManager
{
    public class Sesion
    {
        private static Sesion _instance;
        private static readonly object _lock = new object();

        String _Usuario;

        public Boolean ValidarPermiso(Int32 pIDOpcion)
        {
            Boolean Resultado = false;
            DataTable Result = new DataTable();
            StringBuilder Sentecia = new StringBuilder();
            Sentecia.Append("SELECT a.IDOpcion, c.Opcion FROM permisos a");
            Sentecia.Append("INNER JOIN usuarios b ON b.IDRol=a.IDRol");
            Sentecia.Append("INNER JOIN opciones c ON c.IDOpcion=a.IDOpcion");
            Sentecia.Append("WHERE b.Usuario='" + _Usuario + "'");
            Sentecia.Append("AND a.IDOpcion=" + pIDOpcion.ToString() + ";");

            DataLayer.DBOperacion oOperacion = new DataLayer.DBOperacion();
            Result = oOperacion.Consultar(Sentecia.ToString());
            if (Result.Rows.Count > 0)
            {
                Resultado = true;
            }
            if (!Resultado)
            {
                MessageBox.Show("Acceso denegado");
            }
            return Resultado;
        }

        public string Usuario
        {
            get => _Usuario;
            set => _Usuario = value;
        }

        public static Sesion ObtenerInstancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Sesion();
                    }
                }
            }
            return _instance;
        }
        private Sesion()
        {

        }

    }
}
