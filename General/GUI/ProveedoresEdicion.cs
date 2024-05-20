using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class ProveedoresEdicion : Form
    {
        private bool Validar()
        {
            Boolean Valido = true;
            try
            {
                if (txbProveedor.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbProveedor, "El campo Proveedor no puede estar vacío");
                    Valido = false;
                }
                if (txbContacto.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbContacto, "El campo Contacto no puede estar vacío");
                    Valido = false;
                }
                if (txbDireccion.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbDireccion, "El campo Direccion no puede estar vacío");
                    Valido = false;
                }
                if (txbCorreo.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbCorreo, "El campo Email no puede estar vacío");
                    Valido = false;
                }
            }
            catch (Exception)
            {
                Valido = false;
            }
            return Valido;
        }

        public ProveedoresEdicion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    CLS.Proveedores oProveedor = new CLS.Proveedores();

                    oProveedor.Proveedor = txbProveedor.Text;
                    oProveedor.Contacto = txbContacto.Text;
                    oProveedor.Direccion = txbDireccion.Text;
                    oProveedor.Correo = txbCorreo.Text;

                    if (txbIDProveedor.Text.Trim().Length == 0)
                    {
                        if (oProveedor.Insertar())
                        {
                            MessageBox.Show("Registro guardado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser guardado");
                        }
                    }
                    else
                    {
                        oProveedor.IDProveedor = Convert.ToInt32(txbIDProveedor.Text);
                        if (oProveedor.Actualizar())
                        {
                            MessageBox.Show("Registro actualizado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser actualizado");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProveedoresEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
