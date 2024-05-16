using SesionManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD.GUI
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (oSesion.ValidarPermiso(1))
                //{
                    General.GUI.UsuariosGestion f = new General.GUI.UsuariosGestion();
                    f.MdiParent = this;
                    f.Show();
                //}
            }
            catch (Exception)
            {

            }
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                General.GUI.ProductosGestion f = new General.GUI.ProductosGestion();
                f.MdiParent = this;
                f.Show();

            }
            catch (Exception)
            {

            }
        }
    }
}
