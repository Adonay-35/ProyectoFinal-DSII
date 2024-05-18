using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Roles
    {
        MySqlDataReader resultado;
        DataTable tabla = new DataTable();
        MySqlConnection sqlConexion = new MySqlConnection();

        Int32 _IDRol;
        String _Rol;

        public Roles(int idRol, string rol)
        {
            this._IDRol = idRol;
            this._Rol = rol;
        }

        public int IDRol { get => _IDRol; set => _IDRol = value; }
        public string Rol { get => _Rol; set => _Rol = value; }

        public string toString()
        {
            return this._IDRol + " - " + this._Rol;
        }
    }
}
