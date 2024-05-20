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
    public partial class ProveedoresGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void CargarProveedores()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.PROVEEDORES();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }
        public ProveedoresGestion()
        {
            InitializeComponent();
        }

        private void ProveedoresGestion_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea ELIMINAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Proveedores oProveedor = new CLS.Proveedores();
                    oProveedor.IDProveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProveedor"].Value.ToString());
                    oProveedor.Proveedor = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                    oProveedor.Contacto = dataGridView1.CurrentRow.Cells["Contacto"].Value.ToString();
                    oProveedor.Direccion = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                    oProveedor.Correo = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();

                    if (oProveedor.Eliminar())
                    {
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El registro no ha sido eliminado");
                    }
                    CargarProveedores();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProveedoresEdicion oProveedor = new ProveedoresEdicion();

                    oProveedor.txbIDProveedor.Text = dataGridView1.CurrentRow.Cells["IDProveedor"].Value.ToString();
                    oProveedor.txbProveedor.Text = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                    oProveedor.txbContacto.Text = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Contacto"].Value).ToString();
                    oProveedor.txbDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                    oProveedor.txbCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                    oProveedor.ShowDialog();
                    CargarProveedores();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedoresEdicion f = new ProveedoresEdicion();
                f.ShowDialog();
                CargarProveedores();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
