using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Estados
    {
        Int32 _IDEstado;
        Int32 _Estado;
        String _Descripcion;

        public Estados(int idEstado, int estado, string descripcion)
        {
            this._IDEstado = idEstado;
            this._Estado = estado;
            this._Descripcion = descripcion;
        }

        public int IDEstado { get => _IDEstado; set => _IDEstado = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        public string toString()
        {
            return this._Estado + " - " + this._Descripcion;
        }
    }
}
