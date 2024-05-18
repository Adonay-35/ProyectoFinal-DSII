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
    public partial class VentasEdicion : Form
    {
        Ventas metodosventas = new Ventas();
        private Boolean Validar()
        {
            Boolean Valido = true;
            try
            {
                if (txbIDVenta.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbIDVenta, "Este campo no puede quedar vacío");
                    Valido = false;
                }

                if (!DateTime.TryParse(txbFechaVenta.Text, out _))
                {
                    Notificador.SetError(txbFechaVenta, "Fecha no válida");
                    Valido = false;
                }

                if (cbUsuarios.Text.Trim().Length == 0)
                {
                    Notificador.SetError(cbUsuarios, "Este campo no puede quedar vacío");
                    Valido = false;
                }

                if (cbClientes.Text.Trim().Length == 0)
                {
                    Notificador.SetError(cbClientes, "Este campo no puede quedar vacío");
                    Valido = false;
                }

                if (cbProductos.Text.Trim().Length == 0)
                {
                    Notificador.SetError(cbProductos, "Este campo no puede quedar vacío");
                    Valido = false;
                }

                if (txbCantidad.Text.Trim().Length == 0 || !int.TryParse(txbCantidad.Text, out _))
                {
                    Notificador.SetError(txbCantidad, "Este campo no puede quedar vacío y debe ser un número válido");
                    Valido = false;
                }

                if (txbTotal.Text.Trim().Length == 0 || !double.TryParse(txbTotal.Text, out _))
                {
                    Notificador.SetError(txbTotal, "Este campo no puede quedar vacío y debe ser un número válido");
                    Valido = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la validación: " + ex.Message);
                Valido = false;
            }
            return Valido;
        }

        /*private void MostrarUsuarios(ComboBox cbUsarios)
        {
            List<Usuarios> datos = metodosventas.ObtenerUsuarios();
            cbUsuarios.Items.Add("Selecciona una opción");
            foreach (Usuarios dato in datos)
            {
               cbUsarios.Items.Add(dato.Usuario);
            }
            cbUsarios.SelectedIndex = 0;
        }*/

        /*private void MostrarClientes(ComboBox cbClientes)
        {

            List<Clientes> datos = metodosventas.ObtenerClientes();
            cbClientes.Items.Add("Selecciona una opción");
            foreach (Clientes dato in datos)
            {
                cbClientes.Items.Add(dato.Nombres);
            }
            cbClientes.SelectedIndex = 0;
        }/*

        /*private void MostrarProductos(ComboBox cbProductos)
        {
            List<Productos> datos = metodosventas.ObtenerProductos();
            cbProductos.Items.Add("Selecciona una opción");
            foreach (Productos dato in datos)
            {
                cbProductos.Items.Add(dato.NombreProducto);
            }
            cbProductos.SelectedIndex = 0;
        }*/

        public VentasEdicion()
        {
            InitializeComponent();
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
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    // SINCRONIZAR EL OBJETO CON LA GUI
                    Ventas oVenta = new Ventas();
                    try
                    {

                        oVenta.IDVenta = Convert.ToInt32(txbIDVenta.Text);

                    }
                    catch (Exception)
                    {
                        oVenta.IDUsuario = 0;
                    }

                    try
                    {
                        oVenta.IDUsuario = Convert.ToInt32(cbUsuarios.SelectedIndex);
                        oVenta.IDCliente = Convert.ToInt32(cbClientes.SelectedIndex);

                    }
                    catch (Exception)
                    {
                        oVenta.IDVenta = 0;
                        oVenta.IDCliente = 0;
                        
                    }

                    oVenta.FechaVenta = Convert.ToDateTime(txbFechaVenta.Text);
                    oVenta.IDUsuario = Convert.ToInt32(cbUsuarios.Text);
                    oVenta.IDCliente = Convert.ToInt32(cbClientes.Text);
                    oVenta.IDProducto = Convert.ToString(cbProductos.Text);
                    oVenta.Cantidad = Convert.ToInt32(txbCantidad.Text);
                    oVenta.Total = Convert.ToDouble(txbTotal.Text);

                    if (txbIDVenta.Text.Trim().Length == 0)
                    {
                        // GUARDAR NUEVO REGISTRO
                        if (oVenta.Insertar())
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
                        // ACTUALIZAR REGISTRO
                        if (oVenta.Actualizar())
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

        private void VentasEdicion_Load(object sender, EventArgs e)
        {
            //this.MostrarUsuarios(cbUsuarios);
            //this.MostrarClientes(cbClientes);
            //this.MostrarProductos(cbProductos);
        }
    }   
}
