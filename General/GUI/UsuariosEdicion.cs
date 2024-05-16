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
    public partial class UsuariosEdicion : Form
    {
        Usuarios metodosUsuarios = new Usuarios();
        //DataTable datos;
        //int idUsuario = 0;

        private Boolean Validar()
        {
            Boolean Valido = true;
            try
            {
                if (txbUsuario.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbUsuario, "Este campo no puede quedar vacio");
                    Valido = false;
                }

                if (txbClave.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbClave, "Este campo no puede quedar vacio");
                    Valido = false;
                }

                if (txbIDEmpleado.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbIDEmpleado, "Este campo no puede quedar vacio");
                    Valido = false;
                }

                if (cbRoles.Text.Trim().Length == 0)
                {
                    Notificador.SetError(cbRoles, "Este campo no puede quedar vacio");
                    Valido = false;
                }

                if (cbEstados.Text.Trim().Length == 0)
                {
                    Notificador.SetError(cbEstados, "Este campo no puede quedar vacio");
                    Valido = false;
                }
            }
            catch (Exception)
            {
                Valido = false;
            }
            return Valido;
        }
        public UsuariosEdicion()
        {
            InitializeComponent();
        }

        private void MostrarEstados(ComboBox cbEstados)
        {
            List<Estados> datos = metodosUsuarios.ObtenerEstados();
            cbEstados.Items.Add("Selecciona una opción");
            foreach (Estados dato in datos)
            {
                cbEstados.Items.Add(dato.Estado + 1 + "- " + dato.Descripcion);
            }
            cbEstados.SelectedIndex = 0;
        }

        private void UsuariosEdicion_Load(object sender, EventArgs e)
        {
            this.MostrarEstados(cbEstados);
            this.MostrarRoles(cbRoles);
        }

        private void MostrarRoles(ComboBox cbRoles)
        {
            List<Roles> datos = metodosUsuarios.ObtenerRoles();
            cbRoles.Items.Add("Selecciona una opción");
            foreach (Roles dato in datos)
            {
                cbRoles.Items.Add(dato.Rol);
            }
            cbRoles.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    CLS.Usuarios oUsuario = new CLS.Usuarios();
                    try
                    {
                        oUsuario.IDUsuario = Convert.ToInt32(txbIDUsuario.Text);
                    }
                    catch (Exception)
                    {
                        oUsuario.IDUsuario = 0;
                    }

                    try
                    {
                        oUsuario.IDRol = Convert.ToInt32(cbRoles.SelectedIndex);
                        oUsuario.IDEstado = Convert.ToInt32(cbEstados.SelectedIndex);
                        oUsuario.IDEmpleado = Convert.ToInt32(txbIDEmpleado.Text);
                    }
                    catch (Exception)
                    {
                        oUsuario.IDRol = 0;
                        oUsuario.IDEstado = 0;
                    }
                    oUsuario.Usuario = txbUsuario.Text;
                    oUsuario.Clave = txbClave.Text;
                    if (txbIDUsuario.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTRO
                        if (oUsuario.Insertar())
                        {
                            MessageBox.Show("Registro Guardado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser almacenado");
                        }
                    }
                    else
                    {
                        //ACTUALIZAT REGISTRO
                        if (oUsuario.Actualizar())
                        {
                            MessageBox.Show("Registro Actualizado");
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

            }
        }
    }
}
