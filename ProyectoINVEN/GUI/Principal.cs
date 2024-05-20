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

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void OpcionProveedores_Click(object sender, EventArgs e)
        {
            General.GUI.ProveedoresGestion gestion = new General.GUI.ProveedoresGestion();
            gestion.MdiParent = this;
            gestion.Show();
        }

        private void opcion2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.GUI.ClientesGestion gestion = new General.GUI.ClientesGestion();
            gestion.MdiParent = this;
            gestion.Show();
        }
    }
}
