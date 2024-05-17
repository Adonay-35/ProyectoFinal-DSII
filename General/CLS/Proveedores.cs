using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Proveedores
    {
        Int32 _IDProveedor;
        String _Proveedor;
        Double _Contacto;
        String _Direccion;
        String _Email;

        public Proveedores(int idProveedor, string proveedor)
        {
            this._IDProveedor = idProveedor;
            this._Proveedor = proveedor;
        }

        public int IDProveedor { get => _IDProveedor; set => _IDProveedor = value; }
        public string Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public double Contacto { get => _Contacto; set => _Contacto = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Email { get => _Email; set => _Email = value; }

        public override string ToString()
        {
            return this._IDProveedor + " - " + this._Proveedor;
        }
    }
}
