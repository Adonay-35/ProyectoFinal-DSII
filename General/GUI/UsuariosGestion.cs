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
    public partial class UsuariosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void Cargar()
        {
            try
            {
                //_DATOS.DataSource = DataLayer.Consultas.USUARIOS();
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
                    _DATOS.Filter = "Usuario like '%" + txbFiltro.Text + "%'";
                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }

        public UsuariosGestion()
        {
            InitializeComponent();
        }

        private void UsuariosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
            lblRegistros.Text = _DATOS.Count.ToString();
        }

        private void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea ELIMINAR el registro seleccionado", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Usuarios oUsuario = new CLS.Usuarios();
                    oUsuario.IDUsuario = (Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDUsuario"].Value.ToString()));
                    if (oUsuario.Elminar())
                    {
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El Registro no ha sido eliminado");
                    }
                    Cargar();
                    lblRegistros.Text = _DATOS.Count.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea EDITAR el registro seleccionado", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuariosEdicion oUsuario = new UsuariosEdicion();
                    oUsuario.txbIDUsuario.Text = dataGridView1.CurrentRow.Cells["IDUsuario"].Value.ToString();
                    oUsuario.txbUsuario.Text = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
                    oUsuario.txbClave.Text = dataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
                    oUsuario.cbRol.Text = dataGridView1.CurrentRow.Cells["IDRol"].Value.ToString();
                    oUsuario.txbIDEmpleado.Text = dataGridView1.CurrentRow.Cells["IDEmpleado"].Value.ToString();
                    oUsuario.cbEstado.Text = dataGridView1.CurrentRow.Cells["IDEstado"].Value.ToString();
                    oUsuario.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
