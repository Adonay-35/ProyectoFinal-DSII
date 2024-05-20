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
    public partial class ClientesEdicion : Form
    {
        private bool Validar()
        {
            Boolean Valido = true;
            try
            {
                if (txbNombres.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbNombres, "El campo Proveedor no puede estar vacío");
                    Valido = false;
                }
                if (txbApellidos.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbApellidos, "El campo Contacto no puede estar vacío");
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

        public ClientesEdicion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    CLS.Clientes oCliente = new CLS.Clientes();

                    oCliente.Nombres = txbNombres.Text;
                    oCliente.Apellidos = txbApellidos.Text;
                    oCliente.Correo = txbCorreo.Text;

                    if (txbIDCliente.Text.Trim().Length == 0)
                    {
                        if (oCliente.Insertar())
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
                        oCliente.IDCliente = Convert.ToInt32(txbIDCliente.Text);
                        if (oCliente.Actualizar())
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

        private void ClientesEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
