using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Clientes
    {
        MySqlDataReader resultado;
        DataTable tabla = new DataTable();
        MySqlConnection sqlConexion = new MySqlConnection();

        public int _IDCliente;
        public string _Nombres;
        public string _Apellidos;
        public string _Correo;

        public Clientes(int idCliente, string cliente, string apellidos)
        {
            this._IDCliente = idCliente;
            this._Nombres = cliente;
            this._Apellidos = apellidos;
        }


        public int ICliente { get => _IDCliente; set => _IDCliente = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Correo { get => _Correo; set => _Correo = value; }

        public string toString()
        {
            return this._Nombres + " - " + this._Apellidos;
        }

    }
}
