using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Categorias
    {
        MySqlDataReader resultado;
        DataTable tabla = new DataTable();
        MySqlConnection sqlConexion = new MySqlConnection();

        Int32 _IDCategoria;
        String _Categoria;

        public Categorias(int idCategoria, string categoria)
        {
            this._IDCategoria = idCategoria;
            this._Categoria = categoria;
        }

        public int IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }

        public override string ToString()
        {
            return this._IDCategoria + " - " + this._Categoria;
        }
    }
}

