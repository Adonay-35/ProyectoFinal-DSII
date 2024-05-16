namespace General.GUI
{
    partial class ProductosEdicion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbStock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbProducto = new System.Windows.Forms.TextBox();
            this.txbIDProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbIDCategoria = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbIDProveedor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbFechaFabricacion = new System.Windows.Forms.TextBox();
            this.txbFechaVencimiento = new System.Windows.Forms.TextBox();
            this.Notificador = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "FechaVencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "FechaFabricacion";
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(80, 200);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(307, 20);
            this.txbPrecio.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Precio";
            // 
            // txbStock
            // 
            this.txbStock.Location = new System.Drawing.Point(80, 142);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(307, 20);
            this.txbStock.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Stock";
            // 
            // txbProducto
            // 
            this.txbProducto.Location = new System.Drawing.Point(80, 81);
            this.txbProducto.Name = "txbProducto";
            this.txbProducto.Size = new System.Drawing.Size(307, 20);
            this.txbProducto.TabIndex = 37;
            // 
            // txbIDProducto
            // 
            this.txbIDProducto.Location = new System.Drawing.Point(80, 21);
            this.txbIDProducto.Name = "txbIDProducto";
            this.txbIDProducto.ReadOnly = true;
            this.txbIDProducto.Size = new System.Drawing.Size(103, 20);
            this.txbIDProducto.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "IDProducto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(312, 473);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 46;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(80, 473);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 45;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(80, 354);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(307, 20);
            this.txbDescripcion.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Descripcion";
            // 
            // txbIDCategoria
            // 
            this.txbIDCategoria.FormattingEnabled = true;
            this.txbIDCategoria.Location = new System.Drawing.Point(80, 437);
            this.txbIDCategoria.Name = "txbIDCategoria";
            this.txbIDCategoria.Size = new System.Drawing.Size(307, 21);
            this.txbIDCategoria.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "IDCategoria";
            // 
            // txbIDProveedor
            // 
            this.txbIDProveedor.FormattingEnabled = true;
            this.txbIDProveedor.Location = new System.Drawing.Point(80, 394);
            this.txbIDProveedor.Name = "txbIDProveedor";
            this.txbIDProveedor.Size = new System.Drawing.Size(307, 21);
            this.txbIDProveedor.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "IDProveedor";
            // 
            // txbFechaFabricacion
            // 
            this.txbFechaFabricacion.Location = new System.Drawing.Point(80, 255);
            this.txbFechaFabricacion.Name = "txbFechaFabricacion";
            this.txbFechaFabricacion.Size = new System.Drawing.Size(307, 20);
            this.txbFechaFabricacion.TabIndex = 53;
            // 
            // txbFechaVencimiento
            // 
            this.txbFechaVencimiento.Location = new System.Drawing.Point(80, 315);
            this.txbFechaVencimiento.Name = "txbFechaVencimiento";
            this.txbFechaVencimiento.Size = new System.Drawing.Size(307, 20);
            this.txbFechaVencimiento.TabIndex = 54;
            // 
            // Notificador
            // 
            this.Notificador.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Notificador.ContainerControl = this;
            // 
            // ProductosEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 499);
            this.Controls.Add(this.txbFechaVencimiento);
            this.Controls.Add(this.txbFechaFabricacion);
            this.Controls.Add(this.txbIDProveedor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txbIDCategoria);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbProducto);
            this.Controls.Add(this.txbIDProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProductosEdicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductosEdicion";
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txbStock;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txbProducto;
        public System.Windows.Forms.TextBox txbIDProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox txbIDCategoria;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox txbIDProveedor;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txbFechaFabricacion;
        public System.Windows.Forms.TextBox txbFechaVencimiento;
        private System.Windows.Forms.ErrorProvider Notificador;
    }
}