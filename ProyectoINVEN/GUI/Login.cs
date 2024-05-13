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
    public partial class Login : Form
    {
        private Boolean _Autorizado = false;

        public bool Autorizado { get => _Autorizado; }
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataLayer.DBOperacion oOperacion = new DataLayer.DBOperacion();
            string query = @"SELECT IDUsuario, Usuario,IDEmpleado,IDRol FROM usuarios WHERE usuario='" + txbUsuario.Text + @"' AND Clave=MD5('" + txbClave.Text + @"');";
            dt = oOperacion.Consultar(query);

            if (dt.Rows.Count == 1)
            {
                SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
                oSesion.Usuario = txbUsuario.Text;
                _Autorizado = true;
                Close();
            }
            else
            {
                lblMensaje.Text = "USUARIO O CLAVE ERRONEOS.";
            }
        }
    }
    }

