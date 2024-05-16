using General.CLS;
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
    public partial class ProductosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.PRODUCTOS(); // <---- PONER NOMBRE DE CONSULTA
                FiltrarLocalmente();
            }
            catch (Exception)
            {

            }
        }

        private void FiltrarLocalmente()
        {
            try
            {
                if (txbFiltro.Text.Trim().Length <= 0)
                {
                    _DATOS.RemoveFilter();
                }
                else
                {
                    _DATOS.Filter = "Producto like '%" + txbFiltro.Text + "%'";

                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductosEdicion f = new ProductosEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProductosEdicion oProducto = new ProductosEdicion();
                        oProducto.txbIDProducto.Text = dataGridView1.CurrentRow.Cells["IDProducto"].Value.ToString();
                        oProducto.txbProducto.Text = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                        oProducto.txbStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                        oProducto.txbPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                        oProducto.txbDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                        oProducto.txbIDProveedor.Text = dataGridView1.CurrentRow.Cells["IDProveedor"].Value.ToString();
                        oProducto.txbFechaFabricacion.Text = dataGridView1.CurrentRow.Cells["FechaFabricacion"].Value.ToString();
                        oProducto.txbFechaVencimiento.Text = dataGridView1.CurrentRow.Cells["FechaVencimiento"].Value.ToString();
                        oProducto.txbIDCategoria.Text = dataGridView1.CurrentRow.Cells["IDCategoria"].Value.ToString();
                        oProducto.ShowDialog();

                        Cargar();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Desea ELIMINAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Producto oProducto = new Producto();
                        oProducto.IDProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProducto"].Value.ToString());

                        if (oProducto.Eliminar())
                        {
                            MessageBox.Show("Registro eliminado");
                        }
                        else
                        {
                            MessageBox.Show("El registro no ha sido eliminado");
                        }

                        Cargar();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public ProductosGestion()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SELECCIONAR TODA LA FILA
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ProductosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
            lblRegistros.Text = dataGridView1.Rows.Count.ToString();
        }

        private void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
