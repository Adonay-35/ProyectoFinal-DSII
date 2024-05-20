using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    internal class Proveedores
    {
        Int32 _IDProveedor;
        string _Proveedor;
        string _Contacto;
        string _Direccion;
        string _Correo;

        public int IDProveedor { get => _IDProveedor; set => _IDProveedor = value; }
        public string Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public string Contacto { get => _Contacto; set => _Contacto = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Correo { get => _Correo; set => _Correo = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();

            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("INSERT INTO Proveedores(IDProveedor, Proveedor, Contacto, Direccion, Correo) VALUES(");
            Sentencia.Append(_IDProveedor + ", '" + _Proveedor + "', " + _Contacto + ", '" + _Direccion + "', '" + _Correo + "');");

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
            Sentencia.Append("UPDATE proveedores SET ");
            Sentencia.Append("Proveedor='" + _Proveedor + "', ");
            Sentencia.Append("Contacto=" + _Contacto + ", "); 
            Sentencia.Append("Direccion='" + _Direccion + "', "); 
            Sentencia.Append("Correo='" + _Correo + "' "); 
            Sentencia.Append("WHERE IDProveedor=" + _IDProveedor + ";");


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
            Sentencia.Append("DELETE FROM proveedores ");
            Sentencia.Append("WHERE IDProveedor =" + _IDProveedor + ";");

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
