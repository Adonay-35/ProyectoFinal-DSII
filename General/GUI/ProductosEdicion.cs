using DataLayer;
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
    public partial class ProductosEdicion : Form
    {
        Productos metodosProveedores = new Productos();

        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (txbIDProducto.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbIDProducto, "El campo 'ID Producto' no puede quedar vacío");
                    valido = false;
                }
                if (txbProducto.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbProducto, "El campo 'Nombre Producto' no puede quedar vacío");
                    valido = false;
                }
                if (txbStock.Text.Trim().Length == 0 || !int.TryParse(txbStock.Text, out int stock) || stock <= 0)
                {
                    Notificador.SetError(txbStock, "El campo 'Stock' debe ser un valor mayor que cero");
                    valido = false;
                }
                if (txbPrecio.Text.Trim().Length == 0 || !double.TryParse(txbPrecio.Text, out double precio) || precio <= 0)
                {
                    Notificador.SetError(txbPrecio, "El campo 'Precio' debe ser un valor mayor que cero");
                    valido = false;
                }
                if (txbDescripcion.Text.Trim().Length == 0)
                {
                    Notificador.SetError(txbDescripcion, "El campo 'Descripción' no puede quedar vacío");
                    valido = false;
                }
                if (txbFechaFabricacion.Text.Trim().Length == 0 || !DateTime.TryParse(txbFechaFabricacion.Text, out DateTime fechaCreacion))
                {
                    Notificador.SetError(txbFechaFabricacion, "El campo 'Fecha de Creación' no puede quedar vacío y debe ser una fecha válida");
                    valido = false;
                }
                if (txbFechaVencimiento.Text.Trim().Length == 0 || !DateTime.TryParse(txbFechaVencimiento.Text, out DateTime fechaVencimiento))
                {
                    Notificador.SetError(txbFechaVencimiento, "El campo 'Fecha de Vencimiento' no puede quedar vacío y debe ser una fecha válida");
                    valido = false;
                }
                if (cbProveedor.Text.Trim().Length == 0 || !int.TryParse(cbProveedor.Text, out int idProveedor) || idProveedor <= 0)
                {
                    Notificador.SetError(cbProveedor, "El campo 'ID Proveedor' debe ser un valor mayor que cero");
                    valido = false;
                }
                if (cbCategoria.Text.Trim().Length == 0 || !int.TryParse(cbCategoria.Text, out int idCategoria) || idCategoria <= 0)
                {
                    Notificador.SetError(cbCategoria, "El campo 'ID Categoría' debe ser un valor mayor que cero");
                    valido = false;
                }
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }

        public ProductosEdicion()
        {
            InitializeComponent();
        }


        private void MostrarProveedores(ComboBox cbProveedor)
        {
            List<Proveedores> datos = metodosProveedores.ObtenerProveedores();
            cbProveedor.Items.Add("Selecciona una opción");
            foreach (Proveedores dato in datos)
            {
                cbProveedor.Items.Add(dato.Proveedor);
            }
            cbProveedor.SelectedIndex = 0;
        }

        private void MostrarCategorias(ComboBox cbCategoria)
        {

            List<Categorias> datos = metodosProveedores.ObtenerCategorias();
            cbCategoria.Items.Add("Selecciona una opción");
            foreach (Categorias dato in datos)
            {
                cbCategoria.Items.Add(dato.Categoria);
            }
            cbCategoria.SelectedIndex = 0;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    // SINCRONIZAR EL OBJETO CON LA GUI
                    Productos oProducto = new Productos();
                    try
                    {
                        oProducto.IDProducto = Convert.ToInt32(txbProducto.Text);
                    }
                    catch (Exception)
                    {
                        oProducto.IDProducto = 0;
                    }

                    try
                    {
                        oProducto.IDProveedor = Convert.ToInt32(cbProveedor.SelectedIndex);
                        //oProducto.IDEstado = Convert.ToInt32(cbEstados.SelectedIndex);
                        //oProducto.IDEmpleado = Convert.ToInt32(txbIDEmpleado.Text);
                    }
                    catch (Exception)
                    {
                        oProducto.IDProveedor = 0;
                        //oProducto.IDEstado = 0;
                    }
                    oProducto.NombreProducto = txbProducto.Text.Trim();
                    oProducto.Stock = Convert.ToInt32(txbStock.Text);
                    oProducto.Precio = Convert.ToDouble(txbPrecio.Text);
                    oProducto.Descripcion = txbDescripcion.Text.Trim();
                    oProducto.IDProveedor = Convert.ToInt32(cbProveedor.Text);
                    oProducto.FechaCreacion = Convert.ToDateTime(txbFechaFabricacion.Text);
                    oProducto.FechaVencimiento = Convert.ToDateTime(txbFechaVencimiento.Text);
                    oProducto.IDCategoria = Convert.ToInt32(cbCategoria.Text);

                    if (string.IsNullOrWhiteSpace(txbIDProducto.Text))
                    {
                        // GUARDAR NUEVO REGISTRO
                        if (oProducto.Insertar())
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
                        if (oProducto.Actualizar())
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductosEdicion_Load(object sender, EventArgs e)
        {
            this.MostrarProveedores(cbProveedor);
            this.MostrarCategorias(cbCategoria); 
        }
    }
}
